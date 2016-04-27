using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CommonControls;
using System.ComponentModel;
using System.Threading;

namespace RezervSync
{
    public class c_CopyFile
    {
        const int MaxNumBytesPerTime = 64*1024;        
        string source, destination;
        
        long SizeCopied;

        FileInfo SourceInfo;
        FileInfo DestinationInfo;        

        c_ErrorDataWork ErrorWorkProc = c_ErrorDataWork.Instance;

        BackgroundWorker SourceRead;
        BackgroundWorker DestinationWrite;

        AutoResetEvent 
                        StartSource = new AutoResetEvent(false),
                        StartDestination = new AutoResetEvent(false);
        ManualResetEvent DestinationComplited = new ManualResetEvent(false),
                         SourceComplited = new ManualResetEvent(false);

        c_CircularBuffer CircBuf = new c_CircularBuffer();

        volatile bool CopyRunning = false;

        public long SizeReady
        {
            get
            {
                return SizeCopied;
            }
        }

        public bool IsBusy
        {
            get
            {
                if (SourceRead.IsBusy) return true;
                if (DestinationWrite.IsBusy) return true;
                return false;
            }
            set
            {
                if (!IsBusy)
                {
                    Stop();
                }
            }
        }

        public uint BufferFill
        {
            get
            {
                return CircBuf.GetFIFOCounter();
            }
        }

        public c_CopyFile(uint BufferSize)
        {
            SourceRead = new BackgroundWorker();
            SourceRead.DoWork += new DoWorkEventHandler(SourceRead_DoWork);            
            SourceRead.WorkerSupportsCancellation = true;            

            DestinationWrite = new BackgroundWorker();
            DestinationWrite.DoWork += new DoWorkEventHandler(DestinationWrite_DoWork);            
            DestinationWrite.WorkerSupportsCancellation = true;

            CircBuf.p_BufferSize = BufferSize;
            CircBuf.p_UseEvents = true;

            SourceRead.RunWorkerAsync();
            DestinationWrite.RunWorkerAsync();
        }                

        ~c_CopyFile()
        {
            Stop();
            WaitResult();
            SourceRead.CancelAsync();
            DestinationWrite.CancelAsync();
            while (IsBusy)
            {                
                CircBuf.AbortWait(true);
                Thread.Sleep(100);
            }
        }

        #region  типа commonControls

        public FileInfo CopyFile(FileInfo Source, string Destination, bool owerwrite)
        {
            //траблы - пока вернулся к старым функциям 
            return c_SysIO.CopyFile(Source, Destination, owerwrite);
              
            FileInfo Destfi = new FileInfo(Destination);
            if (!Directory.Exists(Destfi.DirectoryName))
            {
                c_SysIO.CreateDirectoryWithSubDirs(Destfi.DirectoryName);
            }
            else if (owerwrite)
            {
                if (Destfi.Exists)
                {
                    c_SysIO.DeleteFile(Destfi);
                }
            }

            Start(Source.FullName, Destination, true);

            SizeCopied = 0;

            return DestinationInfo;
        }

        public bool CopyDirectory(DirectoryInfo DirSource, DirectoryInfo DirDestination)
        {
            //траблы - пока вернулся к старым функциям 
            return c_SysIO.CopyDirectory(DirSource, DirDestination);            
                 
            if (!DirDestination.Exists)
            {
                DirDestination.Create();
            }

            FileInfo[] Files = DirSource.GetFiles();
            foreach (FileInfo fi in Files)
            {
                FileInfo TempFi = new FileInfo(DirDestination.FullName + "\\" + fi.Name);
                if (TempFi.Exists)
                {
                    c_SysIO.DeleteFile(TempFi);
                }
                Start(fi.FullName, TempFi.FullName, true);                
            }

            DirectoryInfo[] Dirs = DirSource.GetDirectories();
            foreach (DirectoryInfo di in Dirs)
            {
                CopyDirectory(di, new DirectoryInfo(DirDestination.FullName + "\\" + di.Name));
            }

            SizeCopied = 0;
            return true;
        }

        #endregion

        public bool Start(string Source, string Destination, bool WaitCompletion)
        {
            if (Source == null || Destination == null ||
                !File.Exists(Source)) return false;

            source = Source;
            destination = Destination;
            SizeCopied = 0;

            SourceInfo = new FileInfo(source);

            if (File.Exists(destination))
            {
                c_SysIO.DeleteFile(destination);                                
            }

            CircBuf.AbortWait(false);
            CircBuf.FlushBuffer();            

            CopyRunning = true;

            DestinationComplited.Reset();
            SourceComplited.Reset();

            StartSource.Set();
            StartDestination.Set();

            if (WaitCompletion) WaitResult();
            
            CopyRunning = false;     

            return true;
        }

        public void WaitResult()
        {
            DestinationComplited.WaitOne();
            SourceComplited.WaitOne();
       
        }

        public void Stop()
        {
            CopyRunning = false;
            CircBuf.AbortWait(true);
        }

        void DestinationWrite_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] TempData = new byte[MaxNumBytesPerTime];

            while (!DestinationWrite.CancellationPending)
            {
                StartDestination.WaitOne();

                long SizeToCopy = SourceInfo.Length;
                uint SizeReadyToCopy = 0;                

                FileStream DestinationFile = null;

                try
                {

                    DestinationFile = new FileStream(destination, FileMode.CreateNew, FileAccess.Write, FileShare.None, MaxNumBytesPerTime, FileOptions.SequentialScan);                    

                    while (SizeToCopy > 0 && CopyRunning)
                    {
                        long SizeWait = Math.Min(SizeToCopy, (CircBuf.p_BufferSize - MaxNumBytesPerTime));
                        while ((SizeReadyToCopy = CircBuf.GetFIFOCounterWithWait()) < SizeWait && CopyRunning)
                        {
                            CircBuf.WaitWrite();
                        }

                        do
                        {
                            SizeReadyToCopy = Math.Min(SizeReadyToCopy, MaxNumBytesPerTime);
                            if (CircBuf.ReadData(ref TempData, 0, SizeReadyToCopy))
                            {
                                DestinationFile.Write(TempData, 0, (int)SizeReadyToCopy);

                                SizeCopied += SizeReadyToCopy;
                                SizeToCopy -= SizeReadyToCopy;
                            }
                        } while ((SizeReadyToCopy = CircBuf.GetFIFOCounter()) > MaxNumBytesPerTime && CopyRunning);
                    }
                }
                catch (Exception ex)
                {
                    ErrorWorkProc.ErrorProcess(ex);
                }
                finally
                {
                    if (DestinationFile != null)
                    {
                        DestinationFile.Close();
                    }                    
                }

                // обновляем аттрибуты
                try
                {
                    DestinationInfo = new FileInfo(destination);
                    DestinationInfo.Attributes = SourceInfo.Attributes;
                    DestinationInfo.CreationTime = SourceInfo.CreationTime;
                    DestinationInfo.LastAccessTime = SourceInfo.LastAccessTime;
                    DestinationInfo.LastWriteTime = SourceInfo.LastWriteTime;                    
                }
                catch (Exception ex)
                {
                    ErrorWorkProc.ErrorProcess(ex);
                }
                finally
                {
                    CopyRunning = false;

                    // если ожидается чтение                
                    CircBuf.AbortWait(true);

                    DestinationComplited.Set();
                }
            }
        }     

        void SourceRead_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] TempData = new byte[MaxNumBytesPerTime];

            while (!SourceRead.CancellationPending)
            {
                StartSource.WaitOne();

                long SizeToCopy = SourceInfo.Length;
                uint SizeReadyToCopy = 0;

                FileStream SourceFile = null;
                try
                {
                    SourceFile = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.None, MaxNumBytesPerTime, FileOptions.SequentialScan);

                    while (SizeToCopy > 0 && CopyRunning)
                    {
                        SizeReadyToCopy = (uint)Math.Min(SizeToCopy, MaxNumBytesPerTime);
                        if (SizeReadyToCopy != SourceFile.Read(TempData, 0, (int)SizeReadyToCopy))
                        {
                            throw new Exception("Не совпадают размеры для считывания " + SizeReadyToCopy.ToString());
                        }

                        while (CircBuf.GetFIFOCounterFreeWithWait() < SizeReadyToCopy && CopyRunning) ;

                        CircBuf.WriteData(ref TempData, 0, SizeReadyToCopy);

                        SizeToCopy -= SizeReadyToCopy;
                    }
                }
                catch (Exception ex)
                {
                    ErrorWorkProc.ErrorProcess(ex);
                }
                finally
                {
                    if (SourceFile != null)
                    {
                        SourceFile.Close();
                    }
                    SourceComplited.Set();
                }
            }
        }        
    }
}
