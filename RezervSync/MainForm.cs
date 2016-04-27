using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonControls;
using System.IO;
using System.Threading;
using System.Management;
using System.Globalization;


namespace RezervSync
{
    public partial class MainForm : Form
    {        
        cc_AppConf AppConf = cc_AppConf.Instance;
        c_ErrorDataWork ErrorWorkProc = c_ErrorDataWork.Instance;
        
        c_CntrlControl CntrolledControls;        

        c_SyncProcess SyncProcess;

        string Desc = "Программа для синхронизации данных с флешкой, также подойдет для синхронизации данных с резервным диском";
        string PS = "P.S. потратил на нее время (не менее недели)";
        
        string FormName
        {
            get
            {                
                string ConfFileName = "default";
                if (!string.IsNullOrEmpty(AppConf.conf.LastSavedConfFile)&&
                    File.Exists(AppConf.conf.LastSavedConfFile))
                {
                    string NewFileName=(new FileInfo(AppConf.conf.LastSavedConfFile)).Name;
                    if (!string.IsNullOrEmpty(NewFileName))
                    {
                        ConfFileName = NewFileName;
                    }
                }                
                string res ='"'+ConfFileName+'"';
                return res;
            }
            set
            {
                this.Text = value+" - "+FormName;
            }
        }

        public MainForm()
        {
            this.Visible = false;

            InitializeComponent();

            AppConf.ReadyToSave = false;
            InitializeForm();

            AddLogInvoke = AddLogInvokeProcess;

            CntrolledControls = new c_CntrlControl(this);
            CntrolledControls.AddControl(buttonStart);
            CntrolledControls.AddControl(buttonStartCurrentTask);
            CntrolledControls.AddControl(buttonRestartTasks);
            CntrolledControls.AddControl(buttonCompleteTask);
            CntrolledControls.AddControl(ConfigurationToolStripMenuItem);
            CntrolledControls.AddControl(AdditionalSettingsToolStripMenuItem);
            CntrolledControls.AddControl(tabControlTask);

            ErrorWorkProc.ErrorSygnal += new EventHandler(ErrorWorkProc_ErrorSygnal);

            SyncProcess = new c_SyncProcess(this, AppConf.conf.InternalBufferSize);
            SyncProcess.ev_AddLog += new EventHandler(SyncProcess_ev_AddLog);
            SyncProcess.ev_AddLogOnly += new EventHandler(SyncProcess_ev_AddLogOnly);
            SyncProcess.ProgressChanged = SyncProcess_ev_ProgressChanged;
            SyncProcess.StatusChanged = SyncProcess_ev_StatusChanded;
            
            if (!AppConf.conf.NoShowAboutBox)
            {
                CommonControls.CommonForms.About xx = new CommonControls.CommonForms.About(Desc, PS);
                xx.Show();
                AppConf.conf.NoShowAboutBox = true;
                AppConf.Save();
            }
            //this.Visible = true;
            this.Show();
            AppConf.ReadyToSave = true;
        }

        void InitializeForm()
        {   
            taskControlBasic.ValueChanged -= taskControlBasic_ValueChanged;            
            taskControlBasic.AllValues=AppConf.conf.CurrentConf; 
            taskControlBasic.ValueChanged+=new EventHandler(taskControlBasic_ValueChanged);

            instantaneousSpeedToolStripMenuItem.Checked = AppConf.conf.CurrentSpeed;
            dataGridViewTasks.DataSource = AppConf.conf.CurrentConf.Tasks.Tables["TaskTable"];

            tabControlTask.SelectedIndex = AppConf.conf.CurrentConf.SelectedTab;

            toolStripStatusLabelCurrFile.Text = "";

            tabControlTask_SelectedIndexChanged(tabControlTask, EventArgs.Empty);

            this.FormName = "Синхронизация и копирование";

            if (AppConf.conf.WindowState != FormWindowState.Maximized)
            {
                if (AppConf.conf.WinSize != null &&
                    AppConf.conf.WinSize.Height != 0 && AppConf.conf.WinSize.Width != 0)
                {
                    this.Size = AppConf.conf.WinSize;
                }

                if (AppConf.conf.WinLocation != null &&
                    AppConf.conf.WinLocation.X > 0 && AppConf.conf.WinLocation.Y > 0 &&
                        AppConf.conf.WinLocation.X < (Screen.PrimaryScreen.WorkingArea.Width - this.Width) &&
                        AppConf.conf.WinLocation.Y < (Screen.PrimaryScreen.WorkingArea.Height - this.Height))
                {
                    this.Location = AppConf.conf.WinLocation;
                }
                else
                {
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
            }
            else
            {
                this.WindowState = AppConf.conf.WindowState;
            }

        } 

        void SyncProcess_ev_StatusChanded(c_SyncProcess.s_StatusParam Param)
        {
            toolStripStatusLabelCurrFile.Text = Param.CurrFile.Normalize();

            textBoxTotalTime.Text=Param.TotalTimeDiff.ToString().Substring(0, 8);

            float Percentage = Param.ProgressPercent;
            if (Param.TaskMode)
            {
                AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[Param.CurrentTask][2] = (int)Percentage;                
                Percentage/= (float)Param.TotalTasks;
                Percentage += ((Param.TotalTasks - Param.NumTasks) *100.0f/ Param.TotalTasks);
            }

            Percentage = CommonControls.c_CommonFunc.MinMax(Percentage, progressBarProgress.Minimum, 100.0f);
            progressBarProgress.Value = (int)Percentage;            
            
            progressBarBuffer.Value = CommonControls.c_CommonFunc.MinMax(
                (int)(((float)Param.CopyFileBufferFill / AppConf.conf.InternalBufferSize) * 100.0f),
                progressBarBuffer.Minimum, progressBarBuffer.Maximum);

            //TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

            if (Param.CurrSize != 0&&
                Param.CurrSize > Param.LastSize
                )
            {                
                if (Param.CopySpeed > 0)
                {   
                    textBoxSpeed.Text = c_SysIO.FormatSize((long)Param.CopySpeed) + "/c";
                    if (Param.OveralSize > 0)
                    {
                        double TimeRemainSeconds = (Param.OveralSize - Param.CurrSize) / Param.AverageSpeed;                        
                        textBoxRemainTime.Text = (new TimeSpan(0, 0, (int)TimeRemainSeconds)).ToString().Substring(0, 8);
                    }
                }
                else if (Param.OveralSize > 0)
                {
                    long TimeRemainTicks = (long)(((double)Param.TotalTimeDiff.Ticks / Param.CurrSize) * Param.OveralSize);
                    TimeRemainTicks -= Param.TotalTimeDiff.Ticks;                    
                    textBoxRemainTime.Text = (new TimeSpan(TimeRemainTicks)).ToString().Substring(0, 8);
                }                
            }

            this.FormName = Percentage.ToString("f1") + "% ";

            labelPercent.Text = Percentage.ToString("f1") + "%";            

            AddLogOnly(Param.AddShowLog);
            ErrorWorkProc.ErrorLog(Param.AddWriteLog);
        }

        void SyncProcess_ev_ProgressChanged(ProgressChangedEventArgs e)
        {
            c_SyncProcess.s_CopyFilesParam CopyFilesParam = (c_SyncProcess.s_CopyFilesParam)e.UserState;            
            if (e.ProgressPercentage == 100)
            {
                switch (CopyFilesParam.SyncType)
                {
                    case c_SyncProcess.e_SyncType.CopyOnly:
                        if (CopyFilesParam.TaskMode) AddLog("Задача копирования закончена");
                        else AddLog("Копирование закончено");
                        if (CopyFilesParam.ErrorSize > 0)
                        {
                            AddLog("Не хватило места, как минимум на " + c_CommonFunc.FormatSize(CopyFilesParam.ErrorSize,1000)); 
                        }
                        break;
                    case c_SyncProcess.e_SyncType.SyncSourceToDest:
                    case c_SyncProcess.e_SyncType.SyncJoinSourceAndDest:
                        if (CopyFilesParam.TaskMode) AddLog("Задача синхронизации закончена");
                        else AddLog("Синхронизация закончена");
                        if (CopyFilesParam.ErrorSize > 0)
                        {
                            AddLog("Не хватило места, как минимум на " + c_CommonFunc.FormatSize(CopyFilesParam.ErrorSize,1000));
                        }
                        break;
                    case c_SyncProcess.e_SyncType.DeleteFileDuplicatesInSource:
                    case c_SyncProcess.e_SyncType.DeleteDublicatesFromSourceInDestination:
                        AddLog("Удалено дубликатов на " + c_CommonFunc.FormatSize(CopyFilesParam.RemovedDuplicatesSize,1000)); 
                        if (CopyFilesParam.TaskMode) AddLog("Задача удаления дубликатов закончена");
                        else AddLog("Удаление дубликатов закончено");                               
                        break;

                }                

                if (CopyFilesParam.TaskMode&&!CopyFilesParam.ForcedTermination)
                {
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[CopyFilesParam.CurrentTaskNumber - 1][2] = 100;
                }                
            }
            else if (e.ProgressPercentage == 101)
            {
                string Report = "Задание закончено ";
                if (CopyFilesParam.TaskMode) Report = "Все задания закончены";
                toolStripStatusLabelCurrFile.Text = Report;
                labelPercent.Text = "100%";

                this.FormName = Report;                

                if (!CopyFilesParam.ForcedTermination)
                {
                    progressBarProgress.Value = 100;
                }
                else AddLog("Все операции остановлены");

                AddLog(Report);
                AddLog("------------------------------------------------------------");                
                AddLog("");

                CntrolledControls.EnableControls();
            }
            else if (e.ProgressPercentage == -1)
            {
                CntrolledControls.DisableControls();

                this.FormName = "Подготовка";
                toolStripStatusLabelCurrFile.Text = "";
                textBoxSpeed.Text = "";
                textBoxTotalTime.Text = "";
                textBoxRemainTime.Text = "";                

                if (CopyFilesParam.TaskMode)
                {
                    if ((CopyFilesParam.TotalTasks - CopyFilesParam.NumTasks) == 1)
                    {
                        progressBarProgress.Value = 0;
                    }
                }
                else progressBarProgress.Value = 0;                
            }
            else if (e.ProgressPercentage == -2)
            {
                listBoxLog.BackColor = System.Drawing.Color.WhiteSmoke;
                for (int i = 0; i < dataGridViewTasks.Rows.Count; i++)
                {
                    dataGridViewTasks.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }       

        void SyncProcess_ev_AddLogOnly(object sender, EventArgs e)
        {
            AddLogOnly((string)sender);
        }

        void SyncProcess_ev_AddLog(object sender, EventArgs e)
        {
            AddLog((string)sender);
        }

        void ErrorWorkProc_ErrorSygnal(object sender, EventArgs e)
        {            
            this.Invoke(AddLogInvoke, sender.ToString(), true);
        }       
        

        delegate void AddLogDelegate(string LogInfo, bool Exception);
        AddLogDelegate AddLogInvoke;
        void AddLogInvokeProcess(string LogInfo, bool Exception)
        {
            listBoxLog.Items.Add(LogInfo);
            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            if (Exception)
            {
                listBoxLog.BackColor = System.Drawing.Color.Red;
                if (SyncProcess.GlobalStatus.TaskMode)
                {
                    dataGridViewTasks.Rows[SyncProcess.GlobalStatus.CurrentTask].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        void AddLogOnly(string [] LogInfo)
        {            
            if (LogInfo!=null&& LogInfo.Length > 0)
            {
                listBoxLog.Items.AddRange(LogInfo);
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }
        }

        void AddLogOnly(string LogInfo)
        {
            listBoxLog.Invoke(AddLogInvoke, LogInfo, false);            
        }

        void AddLog(string LogInfo)
        {
            listBoxLog.Invoke(AddLogInvoke, LogInfo, false);
            ErrorWorkProc.ErrorLog(LogInfo);
        }

        void AddLog(string [] LogInfo)
        {
            if (LogInfo.Length > 0)
            {
                AddLogOnly(LogInfo);
                ErrorWorkProc.ErrorLog(LogInfo);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {            
            switch (tabControlTask.SelectedIndex)
            {
                case 0: // синхронизация
                    SyncProcess.Start(AppConf.conf.CurrentConf);
                    break;
                case 2: // удаление дубликатов
                    break;
            }            
        }   

        private void buttonStop_Click(object sender, EventArgs e)
        {
            SyncProcess.Stop();
            checkBoxPause.Checked = false;
        }

        private void checkBoxPause_CheckedChanged(object sender, EventArgs e)
        {
            SyncProcess.Pause(checkBoxPause.Checked);
        }        
        

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Conf files (*.cnf)|*.cnf| All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;            
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = AppConf.conf.LastSavedConfFile;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    try
                    {
                        SaveConfClass TempSave;
                        // сохраняем текущий файл конфигурации
                        if (File.Exists(AppConf.conf.LastSavedConfFile))
                        {
                            TempSave = new SaveConfClass(AppConf.conf.LastSavedConfFile);
                            // присваиваем сохраняемой конфигурации новые параметры
                            TempSave.conf.CurrentParam = AppConf.conf.CurrentConf;
                            TempSave.Save();
                        }

                        //теперь открываем новую конфигурацию
                        AppConf.conf.LastSavedConfFile = openFileDialog1.FileName;
                        TempSave = new SaveConfClass(AppConf.conf.LastSavedConfFile);                        
                        AppConf.conf.CurrentConf = TempSave.conf.CurrentParam;
                        InitializeForm();                        
                    }
                    catch (Exception ex)
                    {
                        ErrorWorkProc.ErrorProcess(ex);
                    }
                }
            };           
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(AppConf.conf.LastSavedConfFile))
            {
                try
                {
                    SaveConfClass TempSave = new SaveConfClass(AppConf.conf.LastSavedConfFile);
                    // присваиваем сохраняемой конфигурации новые параметры
                    TempSave.conf.CurrentParam = AppConf.conf.CurrentConf;                    
                    TempSave.Save();
                    this.FormName = "Синхронизация и копирование";
                }
                catch (Exception ex)
                {
                    ErrorWorkProc.ErrorProcess(ex);
                }
            }
            else
            {
                сохранитьКакToolStripMenuItem_Click(null, null);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = AppConf.conf.LastSavedConfFile;
            saveFileDialog1.Filter = "Conf files (*.cnf)|*.cnf| All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    AppConf.conf.LastSavedConfFile = saveFileDialog1.FileName;
                    SaveConfClass TempSave = new SaveConfClass(AppConf.conf.LastSavedConfFile);
                    TempSave.conf.CurrentParam = AppConf.conf.CurrentConf;
                    TempSave.Save();
                    this.FormName = "Синхронизация и копирование";
                }
                catch (Exception ex)
                {
                    ErrorWorkProc.ErrorProcess(ex);
                }
            };

        }

        private void listBoxLog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBoxLog.SelectedItem != null)
                {
                    toolTip1.SetToolTip(listBoxLog, listBoxLog.SelectedItem.ToString());
                }
            }
            else
            {
                toolTip1.SetToolTip(listBoxLog, "");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SyncProcess.StopAndWait();            
            AppConf.Save();
            if (File.Exists(AppConf.conf.LastSavedConfFile))
            {
                сохранитьToolStripMenuItem_Click(null,EventArgs.Empty);
            }
        }

        private void instantaneousSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppConf.conf.CurrentSpeed = !AppConf.conf.CurrentSpeed;
            instantaneousSpeedToolStripMenuItem.Checked = AppConf.conf.CurrentSpeed;
            AppConf.Save();
        }

        private void AdditionalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Settings()).ShowDialog();
            SyncProcess.CopyFileBufferSize = AppConf.conf.InternalBufferSize;            
        }               

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            TaskProp xx = new TaskProp();
            if (xx.ShowDialog() == DialogResult.OK)
            {
                AddNewTaskFromFromControl(xx.taskControlParam);                
            }
        }

        private void AddNewTaskFromFromControl(TaskControl Control)
        {
            AppConf.conf.CurrentConf.Tasks.Tables[0].Rows.Add(new object[] { 
                Control.Source, 
                Control.Destination, 
                0, 
                c_SyncProcess.SyncTypeNames[(int)Control.SyncType], 
                Control.IgnoredFolders, 
                Control.DeleteIgnoreFolders,
                Control.SourceArchive,
                Control.DetinationArchive            
            });    
        }

        private void buttonAddNewTaskFromQuick_Click(object sender, EventArgs e)
        {
            AddNewTaskFromFromControl(taskControlBasic);            
        }

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow==null) return;
            
            AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index].Delete();                       
        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {

            if (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow == null) return;
            try
            {
                TaskProp xx = new TaskProp();

                xx.taskControlParam.Source =
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][0].ToString();

                xx.taskControlParam.Destination =
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][1].ToString();

                xx.taskControlParam.SyncType =
                    c_SyncProcess.ConvertStringToType(AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][3].ToString());

                xx.taskControlParam.IgnoredFolders =
                    (string[])AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][4];

                xx.taskControlParam.DeleteIgnoreFolders =
                    (bool)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][5];

                xx.taskControlParam.SourceArchive =
                    (cc_AppConf.e_Archive_Type)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][6];

                xx.taskControlParam.DetinationArchive =
                    (cc_AppConf.e_Archive_Type)AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][7];


                if (xx.ShowDialog() == DialogResult.OK)
                {
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][0] = xx.taskControlParam.Source;
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][1] = xx.taskControlParam.Destination;
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][2] = 0;
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][3] = c_SyncProcess.SyncTypeNames[(int)xx.taskControlParam.SyncType];
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][4] = xx.taskControlParam.IgnoredFolders;
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][5] = xx.taskControlParam.DeleteIgnoreFolders;
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][6] = xx.taskControlParam.SourceArchive;
                    AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][7] = xx.taskControlParam.DetinationArchive;
                }
            }
            catch (Exception ex)
            {
                ErrorWorkProc.ErrorProcess(ex);
            }

            
        }                

        private void taskControlBasic_ValueChanged(object sender, EventArgs e)
        {
            taskControlBasic.GetAllValues(ref AppConf.conf.CurrentConf);            
            AppConf.Save();
        }

        private void buttonTaskUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow == null) return;

            if (dataGridViewTasks.CurrentRow.Index > 0)
            {
                object[] temp = AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index - 1].ItemArray;
                AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index - 1].ItemArray = AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index].ItemArray;
                AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index].ItemArray = temp;
                dataGridViewTasks.CurrentCell = dataGridViewTasks.Rows[dataGridViewTasks.CurrentRow.Index - 1].Cells[dataGridViewTasks.CurrentCell.ColumnIndex];
            }
        }

        private void buttonTaskDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow == null) return;

            if (dataGridViewTasks.CurrentRow.Index < AppConf.conf.CurrentConf.Tasks.Tables[0].Rows.Count - 1)
            {
                object[] temp = AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index + 1].ItemArray;
                AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index + 1].ItemArray = AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index].ItemArray;
                AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index].ItemArray = temp;
                dataGridViewTasks.CurrentCell = dataGridViewTasks.Rows[dataGridViewTasks.CurrentRow.Index + 1].Cells[dataGridViewTasks.CurrentCell.ColumnIndex];
            }
        }

        private void buttonResetTasks_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow == null) return;

            AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][2]=0;                                   
        }

        private void tabControlTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl cc = (TabControl)sender;
            switch (cc.SelectedIndex)
            {
                case 0: //быстрая настройка
                case 2:
                    buttonStart.Visible = true;

                    buttonStartCurrentTask.Visible = false;
                    buttonRestartTasks.Visible = false;
                    buttonCompleteTask.Visible = false;
                    break;
                case 1: // задания
                    buttonStart.Visible = false;
                    buttonStartCurrentTask.Visible = true;
                    buttonRestartTasks.Visible = true;
                    buttonCompleteTask.Visible = true;
                    break;                
            }

            AppConf.conf.CurrentConf.SelectedTab = tabControlTask.SelectedIndex;
        }        

        private void buttonCompleteTask_Click(object sender, EventArgs e)
        {
            SyncProcess.StartTaskMode(0, AppConf.conf.CurrentConf.Tasks.Tables[0].Rows.Count);
        }

        private void buttonRestartTasks_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AppConf.conf.CurrentConf.Tasks.Tables[0].Rows.Count; i++)
            {
                AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[i][2] = 0;
            }
            buttonCompleteTask_Click(null, EventArgs.Empty);
        }

        private void buttonStartCurrentTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow == null) return;

            AppConf.conf.CurrentConf.Tasks.Tables[0].Rows[dataGridViewTasks.CurrentRow.Index][2] = 0;
            SyncProcess.StartTaskMode(dataGridViewTasks.CurrentCell.RowIndex,1);
        }

        private void statusStrip1_SizeChanged(object sender, EventArgs e)
        {
            toolStripStatusLabelCurrFile.Width = statusStrip1.Width - 15;
        }

        private void ToolStripMenuItemNewConf_Click(object sender, EventArgs e)
        {   
            SaveConfClass xx = new SaveConfClass("");
            xx.SetDefaultConfiguration();
            AppConf.conf.CurrentConf = xx.conf.CurrentParam;
            AppConf.conf.LastSavedConfFile = "";
            AppConf.Save();
            InitializeForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SplashScreen.Close();
            this.Activate();  
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {                
                AppConf.conf.WinSize = this.Size;
                AppConf.conf.WindowState = this.WindowState;
                AppConf.Save();
            }
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                AppConf.conf.WinLocation = this.Location;
                AppConf.conf.WindowState = this.WindowState;
                AppConf.Save();
            }
        }

        private void dataGridViewTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonEditTask_Click(null, null);
        }

        private void contextMenuStripSequence_Opening(object sender, CancelEventArgs e)
        {
            bool MenuItemEnabled = (dataGridViewTasks.RowCount == 0 || dataGridViewTasks.CurrentRow == null);
            foreach (ToolStripItem xx in contextMenuStripSequence.Items)
            {
                if(xx!=ToolStripMenuItemAdd&&xx.GetType()==typeof(ToolStripMenuItem))
                {
                    xx.Enabled = !MenuItemEnabled;
                }
            }              
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            (new CommonControls.CommonForms.About(Desc, PS)).ShowDialog();
        }                

        private void dataGridViewTasks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // because, I added contextmenuitem, will be good to select rows with right mouse button
            if (e.Button == MouseButtons.Right)
            {              
                DataGridView xx = (DataGridView)sender;                
                // Set as selected  
                xx.Rows[e.RowIndex].Cells[0].Selected = true;
                //xx.Rows[e.RowIndex].Selected = true;
            }
        }               
    }
}