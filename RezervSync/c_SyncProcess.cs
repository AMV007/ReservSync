using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommonControls;
using System.IO;
using System.Threading;
using System.Management;
using System.Globalization;

namespace RezervSync
{
    public class c_SyncProcess
    {
        cc_AppConf AppConf = cc_AppConf.Instance;
        c_ErrorDataWork ErrorWorkProc = c_ErrorDataWork.Instance;

        c_CopyFile CopyFile;
        CommitResult.QuestionResult ReplaceQuestion = CommitResult.QuestionResult.OK;

        BackgroundWorker CopyFilesWorker;
        BackgroundWorker DrawStatus;

        AutoResetEvent CopyFilesWorkerComplited;        

        volatile bool PauseProcess = false;

        public event EventHandler ev_AddLog = null;
        public event EventHandler ev_AddLogOnly = null;

        public delegate void d_ProgressChanged(ProgressChangedEventArgs e);
        public d_ProgressChanged ProgressChanged = null;

        public delegate void d_StatusChanged(s_StatusParam Param);
        public d_StatusChanged StatusChanged = null;

        System.Windows.Forms.Form parent=null;       

        public enum e_SyncType
        {
            CopyOnly,
            SyncSourceToDest,
            SyncJoinSourceAndDest,
            DeleteFileDuplicatesInSource,
            DeleteDublicatesFromSourceInDestination,
            SyncTypeUnknown
        }

        internal s_StatusParam GlobalStatus = new s_StatusParam();

        public static string[] SyncTypeNames = new string[]{
                                                "Копировать Source->Destination",
                                                "Синхронизировать Destination=Source",
                                                "Объединить Destination==Source",
                                                "Удаление дубликатов файлов в Source",
                                                "Удаление дубликатов из Source в Destination"
                                                };        

        public c_SyncProcess(System.Windows.Forms.Form Parent, uint InternalBufferSize)
        {
            parent = Parent;
            CopyFile = new c_CopyFile(InternalBufferSize);
            CopyFilesWorkerComplited = new AutoResetEvent(true);

            CopyFilesWorker = new BackgroundWorker();
            CopyFilesWorker.DoWork += new DoWorkEventHandler(CopyFilesWorker_DoWork);
            CopyFilesWorker.ProgressChanged += new ProgressChangedEventHandler(CopyFilesWorker_ProgressChanged);
            CopyFilesWorker.WorkerReportsProgress = true;
            CopyFilesWorker.WorkerSupportsCancellation = true;

            DrawStatus = new BackgroundWorker();
            DrawStatus.DoWork += new DoWorkEventHandler(DrawStatus_DoWork);
            DrawStatus.WorkerReportsProgress = true;
            DrawStatus.WorkerSupportsCancellation = true;
        }

        void AddLogOnly(string LogInfo)
        {            
            if (ev_AddLogOnly != null) ev_AddLogOnly.Invoke(LogInfo, EventArgs.Empty);            
        }

        void AddLog(string LogInfo)
        {
            if (ev_AddLog != null) ev_AddLog.Invoke(LogInfo, EventArgs.Empty);                        
        }

        void UpdateProgress(ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null && parent!=null)
            {
                parent.Invoke(ProgressChanged, e);                
            }
        }

        void UpdateStatus(s_StatusParam Param)
        {
            if (StatusChanged != null)
            {
                parent.BeginInvoke(StatusChanged, Param);                
            }
        }

        public uint CopyFileBufferSize
        {
            set
            {
                StopAndWait();
                CopyFile = new c_CopyFile(value);
            }            
        }

        public static e_SyncType ConvertStringToType(string syncTypeName)
        {
            for (int i = 0; i < SyncTypeNames.Length; i++)
            {
                if (syncTypeName == SyncTypeNames[i])
                {
                    return (e_SyncType)i;
                }
            }

            return e_SyncType.SyncTypeUnknown;
        }

        public void Start(cc_AppConf.s_MainParam Param)
        {            
            StopAndWait();

            MainProcessParam = new s_CopyFilesParam();
            MainProcessParam.Destination = Param.Destination;
            MainProcessParam.Source = Param.Source;
            MainProcessParam.SyncType = Param.SyncType;

            MainProcessParam.CurrentTaskNumber = 0;
            MainProcessParam.NumTasks = 1;
            MainProcessParam.TaskMode = false;

            MainProcessParam.IgnoredFolders = new List<string>(Param.IgnoredFolders);
            MainProcessParam.DeleteIgnoredFolders = Param.DeleteIgnoredFolders;

            CopyFilesWorker.RunWorkerAsync();
        }

        public void StartTaskMode(int TaskNumber, int NumTasks)
        {
            StopAndWait();

            MainProcessParam = new s_CopyFilesParam();

            MainProcessParam.CurrentTaskNumber = TaskNumber;
            MainProcessParam.NumTasks = NumTasks;
            MainProcessParam.TaskMode = true;

            CopyFilesWorker.RunWorkerAsync();            
        }
        
        public void Stop()
        {
            if (CopyFilesWorker.IsBusy)
            {
                CopyFile.Stop();
                CopyFilesWorker.CancelAsync();
                AddLog("Экстренное завершение ...");
                AddLog("Все операции останавливаются...");
            }
        }

        public void StopAndWait()
        {
            if (CopyFilesWorker.IsBusy)
            {
                Stop();
                CopyFilesWorkerComplited.WaitOne();
                while (CopyFilesWorker.IsBusy)
                {
                    Thread.Sleep(200);
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        public void Pause(bool Value)
        {
            PauseProcess = Value;
        }

        private void WaitPause()
        {
            while (PauseProcess && !CopyFilesWorker.CancellationPending)
            {
                Thread.Sleep(100);                
            }
        }

        private bool TestIgnoredSystemFolders(string DirName)
        {
            for (int i = 0; i < AppConf.conf.IgnoredSystemFolders.Count; i++)
            {
                if (string.IsNullOrEmpty(AppConf.conf.IgnoredSystemFolders[i])) continue;
                if (DirName.Contains(AppConf.conf.IgnoredSystemFolders[i])) return true;
            }
            return false;
        }

        private bool TestIgnoredFolders(string DirName)
        {
            if (string.IsNullOrEmpty(DirName)) return false;

            int AdditionalVal=0;
            if (MainProcessParam.Source[MainProcessParam.Source.Length - 1] == '\\') AdditionalVal = 1;
            if (DirName.Length < (MainProcessParam.Source.Length - AdditionalVal)) return false;

            string RelativePath = DirName.Remove(0, MainProcessParam.Source.Length - AdditionalVal);
            
            if (string.IsNullOrEmpty(RelativePath)) return false;
            return MainProcessParam.IgnoredFolders.Contains(RelativePath);
        }

        private bool FileExist(FileInfo[] fi, string Name)
        {
            foreach (FileInfo fic in fi)
            {
                if (fic.Name == Name) return true;
            }
            return false;
        }

        private bool DirExist(DirectoryInfo[] di, string Name)
        {
            foreach (DirectoryInfo dic in di)
            {
                if (dic.Name == Name) return true;
            }
            return false;
        }


        private bool TestIgnoredDuplicateWords(string FileName)
        {            
            for (int i = 0; i < AppConf.conf.IgnoredDuplicateWords.Count; i++)
            {
                if (string.IsNullOrEmpty(AppConf.conf.IgnoredDuplicateWords[i])) continue;
                if (FileName.Contains(AppConf.conf.IgnoredDuplicateWords[i])) return true;
            }
            return false;
        }

        private void AddMessageToLog(string Message)
        {
            if (AppConf.conf.ShowLogFileInfo) Status_ShowLog.Add(Message);
            if (AppConf.conf.WriteLogdiskFileInfo) Status_WriteLog.Add(Message);
        }

        private void AddSpecMessageToLog(string Message)
        {
            Status_ShowLog.Add(Message);
            Status_WriteLog.Add(Message);
        }

        void DeleteDirectoriesAndSubDirectories(DirectoryInfo Dir)
        {            
            if (!Dir.Exists||TestIgnoredSystemFolders(Dir.FullName)) return;

            FileInfo[] fis = Dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;
                
                GlobalStatus.CurrFile = fi.FullName;
                c_SysIO.DeleteFile(fi);                
            }

            DirectoryInfo[] dis = Dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;

                DeleteDirectoriesAndSubDirectories(di);                
            }

            if ((Dir.Attributes & (FileAttributes.Hidden | FileAttributes.ReadOnly | FileAttributes.System)) != 0)
            {
                Dir.Attributes = FileAttributes.Normal;
            }

            Dir.Delete();

            AddMessageToLog("Удалена папка " + Dir.FullName);            
        }

        void DeleteIgnoredFoldersInDestination(DirectoryInfo SourceDir, DirectoryInfo DirectoryDest)
        {
            if (MainProcessParam.DeleteIgnoredFolders)
            {
                AddSpecMessageToLog("Удаляем игнорируемые директории в Destination ...");
                for (int i = 0; i < MainProcessParam.IgnoredFolders.Count; i++)
                {
                    string Tmp = DirectoryDest.FullName + MainProcessParam.IgnoredFolders[i];
                    DirectoryInfo Dest = new DirectoryInfo(Tmp);
                    DeleteDirectoriesAndSubDirectories(Dest);
                }

                GlobalStatus.Reset(); 
            }            
        }

        long GetFilesSizes(DirectoryInfo d)
        {            
            if (TestIgnoredSystemFolders(d.FullName) ||
                TestIgnoredFolders(d.FullName)||
                !AppConf.conf.CalcOvarallSize
                ) 
                return 0;

            // сначала подсчитываем размер файлов в директории
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return 0;

                GlobalStatus.CurrFile = fi.FullName;
                size += fi.Length;
            }

            // потом подсчитываем размер файлов в поддиректориях
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return 0;

                size += GetFilesSizes(di);
            }

            return size;
        }

        void CopyFiles(DirectoryInfo SourceDir, DirectoryInfo DirectoryDest)
        {
            if (TestIgnoredSystemFolders(SourceDir.FullName) 
                || TestIgnoredSystemFolders(DirectoryDest.FullName)
                || TestIgnoredFolders(SourceDir.FullName)
                )
            {
                // не копируем
                return;
            }            

            if (!DirectoryDest.Exists) DirectoryDest.Create();

            // сначала копируем файлы в директории
            FileInfo[] fis = SourceDir.GetFiles();

            foreach (FileInfo fi in fis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;

                GlobalStatus.CurrFile = fi.FullName;
                try
                {
                    CopyFile.CopyFile(fi, DirectoryDest.FullName + "\\" + fi.Name, false);
                }
                catch (Exception ex)
                {
                    MainProcessParam.ErrorSize += fi.Length;
                    ex.HelpLink = GlobalStatus.CurrFile;
                    ErrorWorkProc.ErrorProcess(ex);                    
                }
                GlobalStatus.CurrSize += fi.Length;
            }

            // потом копируем поддиректории
            DirectoryInfo[] dis = SourceDir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;
                CopyFiles(di, 
                    new DirectoryInfo(DirectoryDest.FullName + "\\" + di.Name));
            }
        }


        bool CheckSummerWinterTimeAndZoneChange(TimeSpan TimeDiff)
        {
            if ((TimeDiff.TotalHours != 0 &&
                          TimeDiff.Minutes == 0 &&
                          Math.Abs(TimeDiff.Seconds) < AppConf.conf.FileTimeDifferensIgnore)
                          )
            { // имеет место разница поясов или времени
                if (AppConf.conf.IgnoreTimeZoneChange ||
                    ((Math.Abs(TimeDiff.TotalHours) == 1) && AppConf.conf.IgnoreSummerWinterChange))
                {
                    return true;
                }
            }
            return false;
        }

        bool CheckFileDifference(FileInfo fiSource, FileInfo fiDest)
        {            
            bool ReplaceFile = true;
            TimeSpan TimeDifference = fiSource.LastWriteTime - fiDest.LastWriteTime;            

            if (fiSource.Length != fiDest.Length)
            { // если размеры разные
                
            }
            else
            { // размеры одинаковые
                if (fiSource.LastWriteTime == fiDest.LastWriteTime)
                {
                    ReplaceFile = false;
                }
                else if (Math.Abs(TimeDifference.TotalSeconds) < AppConf.conf.FileTimeDifferensIgnore)
                { // игнорируем несколько секунд, так как может быть проблема в файловой системе
                    ReplaceFile = false;
                }

                // проверяем на разницу поясов
                if (AppConf.conf.IgnoreSummerWinterChange || AppConf.conf.IgnoreTimeZoneChange)
                {
                    if (CheckSummerWinterTimeAndZoneChange(TimeDifference))
                    {
                        ReplaceFile = false;
                    }
                    else
                    { // делаем более детальный анализ, так как может быть дело еще в файловой системе
                        for (int i = -AppConf.conf.FileTimeDifferensIgnore; i <AppConf.conf.FileTimeDifferensIgnore; i++)
                        {
                            TimeSpan TempTime = TimeDifference + new TimeSpan(0, 0, i);
                            if (CheckSummerWinterTimeAndZoneChange(TempTime))
                            {
                                ReplaceFile = false;
                                break;
                            }
                        }
                    }
                    
                }               

                // проверяем на CRC если выбрано
                if (AppConf.conf.UseCRCcheckIfFileTimeDifferensSmall
                    && ((Math.Abs(TimeDifference.TotalSeconds) < AppConf.conf.FileTimeDifferensCRCCheck)||
                        AppConf.conf.FileTimeDifferensCRCCheck==0
                        )
                    )
                { // если одинаковый размер и файлы заменять, да еще выбрано проверять CRC, и 
                    // разница по времени между файлами меньше заданной
                    if (CommonControls.c_CRC.GetCRC(fiSource.FullName) == CommonControls.c_CRC.GetCRC(fiDest.FullName))
                    {
                        ReplaceFile = false;
                    }
                    else
                    {
                        ReplaceFile = true;
                    }
                }
            }

            if (ReplaceFile // если размеры разные или не прошел проверку при одинаковых размерах, и дата затираемого больше даты текущего
                && fiSource.LastWriteTime < fiDest.LastWriteTime)
            {   // если дата destination более позднияя чем source    
                ReplaceFile = true;

                // если в диалоге было выбрано пропускать все файлы с разницой во времени
                if (ReplaceQuestion == CommitResult.QuestionResult.MissAll) ReplaceFile = false;                                

                // для объединения не актуально заменять файлы таким образом, там только по дате
                if (MainProcessParam.SyncType == e_SyncType.SyncJoinSourceAndDest) ReplaceFile = false;                
             
                // если все таки файл заменять
                if (ReplaceFile &&        
                    ReplaceQuestion != CommitResult.QuestionResult.ReplaceAll)
                {
                    ReplaceQuestion = CommitResult.GetResult("Внимание ! файл в destination имеет более позднюю дату изменения, чем в source, заменять ?",
                                    fiSource.FullName + "\n" +
                                    c_CommonFunc.FormatSize(fiSource.Length,1000) + "\n" + fiSource.LastWriteTime.ToString(),
                                    fiDest.FullName + "\n" +
                                    c_CommonFunc.FormatSize(fiDest.Length,1000) + "\n" + fiDest.LastWriteTime.ToString()
                                    );
                    if (ReplaceQuestion == CommitResult.QuestionResult.Cancel)
                    {
                        CopyFilesWorker.CancelAsync();
                        return false;
                    }
                    if (ReplaceQuestion == CommitResult.QuestionResult.Miss ||
                        ReplaceQuestion == CommitResult.QuestionResult.MissAll)
                        ReplaceFile = false;
                }
            }
           
            return ReplaceFile;
        }
        
        
        void SyncFiles(DirectoryInfo SourceDir, DirectoryInfo DirectoryDest,
                        bool DeleteDestinationSync, bool DeleteOnly)
        {   
            if (TestIgnoredSystemFolders(SourceDir.FullName) 
                || TestIgnoredSystemFolders(DirectoryDest.FullName)
                || TestIgnoredFolders(SourceDir.FullName)
                )
            {
                // не копируем
                return;
            }
            GlobalStatus.CurrFile = SourceDir.FullName;
            if (!DirectoryDest.Exists)
            {
                if (DeleteOnly) return;
                DirectoryDest.Create();
            }
            
            // файлы и директории из source
            FileInfo[] fis = SourceDir.GetFiles();
            DirectoryInfo[] dis = SourceDir.GetDirectories();
            // файлы и директории изи destination
            FileInfo[] fid = null;
            DirectoryInfo[] did = null;

            if (DeleteDestinationSync || !DeleteOnly)
            {
                fid = DirectoryDest.GetFiles();
                did = DirectoryDest.GetDirectories();
            }

            // копируем - заменяем фалы из source в destination
            if (!DeleteOnly)
            {
                // Разбираемся с файлами            
                FileInfo CurrentDestFile;
                foreach (FileInfo fiSource in fis)
                {
                    if (PauseProcess) WaitPause();
                    if (CopyFilesWorker.CancellationPending) return;

                    try
                    {
                        GlobalStatus.CurrFile = fiSource.FullName;                        
                        if (FileExist(fid, fiSource.Name))
                        { // проверка файлов на соответствие, если существует результирующий файл
                            CurrentDestFile = new FileInfo(DirectoryDest.FullName + "\\" + fiSource.Name);                            
                            
                            bool ReplaceFile = CheckFileDifference(fiSource, CurrentDestFile);

                            // надо, так как в процедуре проверки файлов и выдаче диалога пользователь может все завершить
                            if (PauseProcess) WaitPause();
                            if (CopyFilesWorker.CancellationPending) return;

                            if (ReplaceFile)
                            {

                                if (AppConf.conf.SaveReplacedFiles)
                                {
                                    CopyFile.CopyFile(CurrentDestFile,
                                        AppConf.conf.ReplacedFilesPath + "\\" +
                                        CurrentDestFile.FullName.Substring(MainProcessParam.Destination.Length),
                                        true);
                                }

                                CopyFile.CopyFile(fiSource, DirectoryDest.FullName + "\\" + fiSource.Name, true);

                                AddMessageToLog("Заменен файл : " + CurrentDestFile.FullName);

                            }

                        }
                        else
                        {
                            CopyFile.CopyFile(fiSource, DirectoryDest.FullName + "\\" + fiSource.Name, false);
                            AddMessageToLog("Добавлен файл " + DirectoryDest.FullName + "\\" + fiSource.Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        MainProcessParam.ErrorSize += fiSource.Length;
                        ex.HelpLink = GlobalStatus.CurrFile;
                        ErrorWorkProc.ErrorProcess(ex);
                    }

                    GlobalStatus.CurrSize += fiSource.Length;
                }
            }

            // сначала удаляем ненужные файлы и директории из dest
            if (DeleteDestinationSync)
            {
                // удаляем не существующие файлы в destination                
                foreach (FileInfo fiDest in fid)
                {
                    if (PauseProcess) WaitPause();
                    if (CopyFilesWorker.CancellationPending) return;                 

                    if (!FileExist(fis, fiDest.Name))
                    {
                        try
                        {
                            if (AppConf.conf.SaveDeletedFiles)
                            {
                                CopyFile.CopyFile(fiDest,
                                    AppConf.conf.DeletedFilesPath + "\\" +
                                    fiDest.FullName.Substring(MainProcessParam.Destination.Length)
                                    ,
                                    true);
                            }

                            AddMessageToLog("Удален файл " + fiDest.FullName);
                            c_SysIO.DeleteFile(fiDest);
                        }
                        catch (Exception ex)
                        {
                            ex.HelpLink = GlobalStatus.CurrFile;
                            ErrorWorkProc.ErrorProcess(ex);
                        }
                    }
                }

                // удаляем несуществующие директории в Destination               
                foreach (DirectoryInfo dest in did)
                {
                    if (PauseProcess) WaitPause();
                    if (CopyFilesWorker.CancellationPending) return;
                  
                    if (!DirExist(dis, dest.Name))
                    {
                        try
                        {

                            if (AppConf.conf.SaveDeletedFiles)
                            {
                                CopyFile.CopyDirectory(dest,
                                    new DirectoryInfo(AppConf.conf.DeletedFilesPath + "\\" +
                                        dest.FullName.Substring(MainProcessParam.Destination.Length)));
                            }

                            DeleteDirectoriesAndSubDirectories(dest);
                        }
                        catch (Exception ex)
                        {
                            ex.HelpLink = GlobalStatus.CurrFile;
                            ErrorWorkProc.ErrorProcess(ex);
                        }
                    }
                }
            }           

            // потом синхронизируем поддиректории            
            foreach (DirectoryInfo di in dis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;
                SyncFiles(di,
                    new DirectoryInfo(DirectoryDest.FullName + "\\" + di.Name),
                    DeleteDestinationSync, DeleteOnly);
            }
        }

        public struct s_exist_Files
        {
            public string FileName;
            public long FileSize;
        }
        public List<s_exist_Files> exist_Files = null;
        byte[] SourceReadData = null;
        byte[] DestReadData = null;
        void DeleteDuplicates(DirectoryInfo SourceDir, bool DeleteFiles, bool AddToDublicateList)
        {
            if (TestIgnoredSystemFolders(SourceDir.FullName)                
                || TestIgnoredFolders(SourceDir.FullName)
                )
            {
                // не копируем
                return;
            }            

            // сначала копируем файлы в директории
            FileInfo[] fis = SourceDir.GetFiles();

            // Разбираемся с файлами
            foreach (FileInfo fi in fis)
            {                
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;

                GlobalStatus.CurrFile = fi.FullName;
                GlobalStatus.CurrSize += fi.Length;

                if (TestIgnoredDuplicateWords(fi.Name)) continue;

                bool FilesAreSame = false;                
                for (int i = 0; i < exist_Files.Count; i++)
                {
                    if (PauseProcess) WaitPause();
                    if (CopyFilesWorker.CancellationPending) return;

                    if (exist_Files[i].FileSize == fi.Length)
                    {
                        FileStream SourceFile = new FileStream(exist_Files[i].FileName, FileMode.Open, FileAccess.Read);
                        if (SourceFile != null)
                        {
                            FileStream DestFile = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);            
                            if (DestFile != null)
                            {
                                int SizeDest, SizeSource;
                                long FileOffset=0;

                                while (
                                    ((SizeDest = DestFile.Read(DestReadData, 0, (int)AppConf.conf.DuplicateBlockSize)) > 0)
                                    && ((SizeSource = SourceFile.Read(SourceReadData, 0, (int)AppConf.conf.DuplicateBlockSize)) > 0)
                                    )
                                {
                                    if (SizeSource != SizeDest)
                                    {                                        
                                        ErrorWorkProc.ErrorProcess(new Exception("FileSizes changed, souzrce : " + exist_Files[i].FileName +
                                            " destination " + fi.FullName));
                                        break;
                                    }

                                    for (int k = 0; k < SizeSource; k++)
                                    {
                                        if (DestReadData[k] != SourceReadData[k])
                                        {                                            
                                            FileOffset = fi.Length;
                                            break;
                                        }
                                    }

                                    // файлы разные
                                    if (FileOffset == fi.Length) break; 

                                    FileOffset+=SizeSource;
                                    
                                    if (FileOffset == fi.Length)
                                    {
                                        FilesAreSame = true;
                                        break;
                                    }                                    
                                }
                                DestFile.Close();
                            }
                            else
                            {                                
                                ErrorWorkProc.ErrorProcess(new Exception("Error Access File, cant test it : " + fi.FullName));
                            }

                            SourceFile.Close();
                        }
                        else
                        {                            
                            ErrorWorkProc.ErrorProcess(new Exception("Error Access File, cant test it : " + exist_Files[i].FileName));
                        }

                        if (FilesAreSame)
                        {
                            if (DeleteFiles)
                            {
                                try
                                {
                                    AddMessageToLog("Deleted Same File : " + fi.FullName);
                                    AddMessageToLog("Source File       : " + exist_Files[i].FileName);
                                    MainProcessParam.RemovedDuplicatesSize += fi.Length;

                                    if (AppConf.conf.SaveDeletedFiles)
                                    {
                                        CopyFile.CopyFile(fi,
                                            AppConf.conf.DeletedFilesPath + "\\" +
                                            fi.FullName.Substring(MainProcessParam.Source.Length),
                                            true);
                                    }

                                    c_SysIO.DeleteFile(fi);
                                }
                                catch (Exception ex)
                                {
                                    ex.HelpLink = fi.FullName;
                                    ErrorWorkProc.ErrorProcess(ex);
                                }
                            }
                            break;
                        }                        
                    }
                }

                if (!FilesAreSame&&AddToDublicateList)
                {
                    s_exist_Files NewExFile = new s_exist_Files();
                    NewExFile.FileName = fi.FullName;
                    NewExFile.FileSize = fi.Length;
                    exist_Files.Add(NewExFile);
                }
            }

            // потом копируем поддиректории
            DirectoryInfo[] dis = SourceDir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                if (PauseProcess) WaitPause();
                if (CopyFilesWorker.CancellationPending) return;
                DeleteDuplicates(di, DeleteFiles, AddToDublicateList);
            }
        }
        

        public struct s_CopyFilesParam
        {
            public e_SyncType SyncType;
            public string Source;
            public string Destination;

            public int CurrentTaskNumber;
            public int NumTasks;
            public int TotalTasks;
            public bool TaskMode;

            public long RemovedDuplicatesSize;
            public long ErrorSize;

            public bool ForcedTermination;            

            public List<string> IgnoredFolders;
            public bool DeleteIgnoredFolders;

            public DateTime BeginProcessTime;
        }

        s_CopyFilesParam MainProcessParam = new s_CopyFilesParam();
        void CopyFilesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFilesWorkerComplited.Reset();
            MainProcessParam.BeginProcessTime = DateTime.Now;
            MainProcessParam.TotalTasks = MainProcessParam.NumTasks;
            GlobalStatus.TaskMode = MainProcessParam.TaskMode;

            CopyFilesWorker.ReportProgress(-2, MainProcessParam);
            bool DrawStatusWasRunning = false;

            while ((MainProcessParam.NumTasks-- > 0) && !CopyFilesWorker.CancellationPending)
            {
                int CurrentTaskNumber = MainProcessParam.CurrentTaskNumber;
                GlobalStatus.CurrentTask = CurrentTaskNumber;
                MainProcessParam.CurrentTaskNumber++;
                
                try
                {
                    GlobalStatus.Reset();
                    ResetDrawData = true;
                    ReplaceQuestion = CommitResult.QuestionResult.OK;
                    Status_WriteLog = new List<string>();
                    Status_ShowLog = new List<string>();
                    
                    if (MainProcessParam.TaskMode)
                    {
                        MainProcessParam.Source = (string)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CurrentTaskNumber][0];
                        MainProcessParam.Destination = (string)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CurrentTaskNumber][1];
                        MainProcessParam.SyncType = ConvertStringToType(AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CurrentTaskNumber][3].ToString());
                        MainProcessParam.IgnoredFolders = new List<string>((string[])AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CurrentTaskNumber][4]);
                        MainProcessParam.DeleteIgnoredFolders = (bool)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CurrentTaskNumber][5];
                        double CurrentProgress = (double)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CurrentTaskNumber][2];
                        if (CurrentProgress == 100)
                        {
                            AddLog("Задание " + (CurrentTaskNumber + 1).ToString() + ". " + MainProcessParam.Source + " -> " + MainProcessParam.Destination + " уже выполнено на 100%, пропускается");
                            continue;
                        }
                        else
                        {
                            AddLog("Задание " + (CurrentTaskNumber + 1).ToString() + ". " + MainProcessParam.Source + " -> " + MainProcessParam.Destination + " начало выполнения");
                        }
                    }

                    MainProcessParam.ErrorSize = 0;
                    MainProcessParam.RemovedDuplicatesSize = 0;
                    MainProcessParam.ForcedTermination = CopyFilesWorker.CancellationPending;
                    CopyFilesWorker.ReportProgress(-1, MainProcessParam);
                    
                    DirectoryInfo SourсeDirectory = new DirectoryInfo(MainProcessParam.Source);
                    DirectoryInfo DestinationDirectory = null;
                    DrawStatusWasRunning = true;
                    DrawStatus.RunWorkerAsync();

                    AddSpecMessageToLog(MainProcessParam.SyncType.ToString());

                    switch (MainProcessParam.SyncType)
                    {
                        case e_SyncType.CopyOnly:

                            DestinationDirectory = Directory.CreateDirectory(MainProcessParam.Destination);
                            // если целевая директория существует - то удаляем ее и создаем заново пустой
                            if (DestinationDirectory.Exists)
                            {
                                AddSpecMessageToLog("Подсчет объема удаляемых файлов...");
                                GlobalStatus.OveralSize = GetFilesSizes(DestinationDirectory);
                                AddSpecMessageToLog("Объем : " + c_CommonFunc.FormatSize(GlobalStatus.OveralSize,1000));

                                AddSpecMessageToLog("Удаляем предыдущие файлы из каталога " + MainProcessParam.Destination);
                                DeleteDirectoriesAndSubDirectories(DestinationDirectory);

                                DestinationDirectory.Create();
                            };

                            AddSpecMessageToLog("Подсчет объема...");
                            GlobalStatus.OveralSize = GetFilesSizes(SourсeDirectory);
                            AddSpecMessageToLog("Объем : " + c_CommonFunc.FormatSize(GlobalStatus.OveralSize,1000));

                            GlobalStatus.CurrFile = "";                            

                            AddSpecMessageToLog("Идет копирование...");
                            ResetDrawData = true;
                            CopyFiles(SourсeDirectory, DestinationDirectory);
                            break;

                        case e_SyncType.SyncSourceToDest:

                            DestinationDirectory = Directory.CreateDirectory(MainProcessParam.Destination);
                            DeleteIgnoredFoldersInDestination(SourсeDirectory, DestinationDirectory);                        

                            AddSpecMessageToLog("Подсчет объема...");                            
                            GlobalStatus.OveralSize = GetFilesSizes(SourсeDirectory);
                            GlobalStatus.CurrFile = "";
                            AddSpecMessageToLog("Объем : " + c_CommonFunc.FormatSize(GlobalStatus.OveralSize,1000));

                            AddSpecMessageToLog("Идет синхронизация...");
                            ResetDrawData = true;
                            AddSpecMessageToLog("Удаляем файлы из Destination ...");
                            SyncFiles(SourсeDirectory, DestinationDirectory, true, true);
                            AddSpecMessageToLog("Копируем фалы в Destination ...");
                            SyncFiles(SourсeDirectory, DestinationDirectory, true, false);
                            break;

                        case e_SyncType.SyncJoinSourceAndDest:
                            DestinationDirectory = Directory.CreateDirectory(MainProcessParam.Destination);
                            DeleteIgnoredFoldersInDestination(SourсeDirectory, DestinationDirectory);                        

                            AddSpecMessageToLog("Подсчет объема Source...");
                            GlobalStatus.OveralSize = GetFilesSizes(SourсeDirectory);                            
                            AddSpecMessageToLog("Подсчет объема Destination...");
                            GlobalStatus.OveralSize+= GetFilesSizes(DestinationDirectory);
                            GlobalStatus.CurrFile = "";

                            AddSpecMessageToLog("Объем : " + c_CommonFunc.FormatSize(GlobalStatus.OveralSize,1000));

                            AddSpecMessageToLog("Идет объединение... Source->Destination ...");
                            ResetDrawData = true;
                            SyncFiles(SourсeDirectory, DestinationDirectory, false, false);
                            
                            //----- второй заход в обратном направлении
                            AddSpecMessageToLog("Идет объединение... Destination->Source ...");
                            ResetDrawData = true;
                            // чтобы файлы при удалении правильно копировались
                            MainProcessParam.Destination = SourсeDirectory.FullName;
                            SyncFiles(DestinationDirectory, SourсeDirectory, false, false);
                            break;

                        case e_SyncType.DeleteFileDuplicatesInSource:
                            exist_Files = new List<s_exist_Files>();

                            AddSpecMessageToLog("Подсчет объема ...");
                            GlobalStatus.OveralSize = GetFilesSizes(SourсeDirectory);

                            AddSpecMessageToLog("Объем : " + c_CommonFunc.FormatSize(GlobalStatus.OveralSize,1000));

                            AddSpecMessageToLog("Идет удаление дубликатов...");                            

                            if (DestReadData==null)
                                DestReadData = new byte[AppConf.conf.DuplicateBlockSize];
                            if (SourceReadData==null)
                                SourceReadData = new byte[AppConf.conf.DuplicateBlockSize];
                            ResetDrawData = true;
                            DeleteDuplicates(SourсeDirectory, true, true);
                            break;

                        case e_SyncType.DeleteDublicatesFromSourceInDestination:

                            DestinationDirectory = Directory.CreateDirectory(MainProcessParam.Destination);
                            exist_Files = new List<s_exist_Files>();

                            AddSpecMessageToLog("Подсчет объема Source...");
                            GlobalStatus.OveralSize = GetFilesSizes(SourсeDirectory);
                            AddSpecMessageToLog("Объем Source : " + c_CommonFunc.FormatSize(GlobalStatus.OveralSize,1000));

                            AddSpecMessageToLog("Подсчет объема Destination...");
                            long DestSize = GetFilesSizes(DestinationDirectory);
                            AddSpecMessageToLog("Объем Destination : " + c_CommonFunc.FormatSize(DestSize,1000));
                            GlobalStatus.OveralSize += DestSize;
                         
                            GlobalStatus.CurrFile = "";

                            AddSpecMessageToLog("Идет создание списка файлов в Source ...");
                            if (DestReadData == null)
                                DestReadData = new byte[AppConf.conf.DuplicateBlockSize];
                            if (SourceReadData == null)
                                SourceReadData = new byte[AppConf.conf.DuplicateBlockSize];
                            ResetDrawData = true;
                            DeleteDuplicates(SourсeDirectory, false, true);
                            
                            GlobalStatus.CurrFile = "";                            

                            AddSpecMessageToLog("Идет удаление дубликатов из Destination ...");
                            ResetDrawData = true;
                            DeleteDuplicates(DestinationDirectory,true, false);
                            break;
                        default:
                            throw new Exception("Неизвестный тип задания");
                            
                    }                                        
                }
                catch (Exception ex)
                {
                    ex.HelpLink = GlobalStatus.CurrFile;
                    ErrorWorkProc.ErrorProcess(ex);
                }
                finally
                {
                    if (DrawStatusWasRunning)
                    {
                        DrawStatus.CancelAsync();
                        WaitDrawStatusBusy();
                    }
                    DrawStatusWasRunning = false;

                    MainProcessParam.ForcedTermination = CopyFilesWorker.CancellationPending;
                    CopyFilesWorker.ReportProgress(100, MainProcessParam);                    
                }
            }

            MainProcessParam.ForcedTermination = CopyFilesWorker.CancellationPending;
            CopyFilesWorker.ReportProgress(101, MainProcessParam);                    
            CopyFilesWorkerComplited.Set();
        }

        void CopyFilesWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress(e);            
        }

        void WaitDrawStatusBusy()
        {            
            DrawStatusFinished.WaitOne();
            while (DrawStatus.IsBusy) Thread.Sleep(100);
        }

        public struct s_StatusParam
        {
            public float ProgressPercent;
            public TimeSpan TotalTimeDiff;
            public TimeSpan CurrentTimeDiff;

            public long CurrSize;
            public long OveralSize;
            public long LastSize;            

            public string CurrFile;
            public uint CopyFileBufferFill;

            public int CurrentTask;
            public int NumTasks;
            public int TotalTasks;
            public bool TaskMode;

            public string[] AddWriteLog;
            public string[] AddShowLog;

            public double CopySpeed;
            public double AverageSpeed;

            public void Reset()
            {
                CurrSize = 0;
                OveralSize = 0;
                LastSize = 0;                
                CurrFile = "";                
            }
        }

        List<string> Status_WriteLog;
        List<string> Status_ShowLog;
        AutoResetEvent DrawStatusFinished = new AutoResetEvent(false);
        volatile bool ResetDrawData = false;
        
        double [] AverageSpeed = new double[10];
        int AverageSpeedIndex = 0;

        void DrawStatus_DoWork(object sender, DoWorkEventArgs e)
        {            
            s_StatusParam Param = new s_StatusParam();            
            DateTime LastTime = DateTime.Now;
            DateTime BeginDrawTime = DateTime.Now;
            ResetDrawData = true;

            Param.LastSize = 0;                        

            Param.TaskMode = MainProcessParam.TaskMode;
            Param.CurrentTask = MainProcessParam.CurrentTaskNumber - 1;
            Param.TotalTasks = MainProcessParam.TotalTasks;
            Param.NumTasks = MainProcessParam.NumTasks+1;
            
            while (!DrawStatus.CancellationPending||
                Status_WriteLog.Count>0||
                Status_ShowLog.Count>0)
            {
                Thread.Sleep(500);
                if (ResetDrawData)
                {
                    Param.LastSize = 0;
                    LastTime = DateTime.Now;
                    BeginDrawTime = DateTime.Now;
                    ResetDrawData = false;
                }

                Param.ProgressPercent = 0;
                Param.OveralSize = GlobalStatus.OveralSize;                

                if (GlobalStatus.OveralSize != 0)
                {
                    Param.ProgressPercent = (GlobalStatus.CurrSize * 100.0f / GlobalStatus.OveralSize);
                    Param.TotalTimeDiff = DateTime.Now - MainProcessParam.BeginProcessTime;
                    Param.CurrentTimeDiff = DateTime.Now - LastTime;
                    Param.CurrSize = GlobalStatus.CurrSize + CopyFile.SizeReady;
                }
                else
                {
                    if (!AppConf.conf.CalcOvarallSize)
                    {
                        Param.ProgressPercent = 50;
                        Param.TotalTimeDiff = DateTime.Now - MainProcessParam.BeginProcessTime;
                        Param.CurrentTimeDiff = DateTime.Now - LastTime;
                        Param.CurrSize = GlobalStatus.CurrSize + CopyFile.SizeReady;                        
                    }
                    else
                    {
                        Param.LastSize = 0;
                    }
                }                

                Param.CurrFile = GlobalStatus.CurrFile;
                Param.CopyFileBufferFill = CopyFile.BufferFill;
                Param.AddWriteLog = Status_WriteLog.ToArray();
                
                Status_WriteLog.Clear();
                Param.AddShowLog = Status_ShowLog.ToArray();
                Status_ShowLog.Clear();

                if (Param.CurrentTimeDiff.TotalMilliseconds > 0)
                {
                    Param.CopySpeed = (Param.CurrSize - Param.LastSize) * 1000.0 / Param.CurrentTimeDiff.TotalMilliseconds;
                    
                    AverageSpeed[AverageSpeedIndex] = Param.CopySpeed;
                    if (++AverageSpeedIndex >= AverageSpeed.Length) AverageSpeedIndex = 0;
                    Param.AverageSpeed = 0;
                    for (int i = 0; i < AverageSpeed.Length; i++)
                    {
                        Param.AverageSpeed += AverageSpeed[i];
                    }
                    Param.AverageSpeed /= AverageSpeed.Length;
                }
                else Param.CopySpeed = 0;

                if(!PauseProcess) UpdateStatus(Param);

                if (AppConf.conf.CurrentSpeed)
                { // если в конфигурации выбрана мгновенная скорость, то считаем
                    if (Param.CurrentTimeDiff.TotalSeconds > 5)
                    {
                        LastTime = DateTime.Now;
                        Param.LastSize = GlobalStatus.CurrSize + CopyFile.SizeReady;
                    }
                }
                else
                {
                    LastTime = BeginDrawTime;
                    Param.LastSize = 0;
                }
            };
            DrawStatusFinished.Set();
        }        
    }
}
