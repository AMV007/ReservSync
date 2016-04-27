using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RezervSync
{
    public class cc_AppConf : CommonControls.c_AppConf
    {
        public enum e_Archive_Type
        {
            None,
            Zip,
            Bzip2,
            Gzip,
            Tar
        }
        
        public struct s_MainParam
        {
            public string Source;
            public e_Archive_Type SourceArchive;
            public string Destination;
            public e_Archive_Type DestinationArchive;

            public string[] IgnoredFolders;
            public bool DeleteIgnoredFolders;
            public c_SyncProcess.e_SyncType SyncType;
            public DataSet Tasks;

            public int SelectedTab;           
        }

        public struct s_ComputerBasedConf
        {
            public s_MainParam Param;
            public string ComputerID;            
        }

        private string ComputerID = "";        

        public struct Confstruct
        {
            public List<cc_AppConf.s_ComputerBasedConf> AppPathsCompBasedID;
            public bool UseDifferentConfigurationsForComputers;

            public s_MainParam CurrentConf;

            public string LastSavedConfFile;

            public bool CalcOvarallSize;

            public bool CurrentSpeed;
            public bool IgnoreTimeZoneChange;
            public bool IgnoreSummerWinterChange;
            public bool UseCRCcheckIfFileTimeDifferensSmall;
            public int FileTimeDifferensCRCCheck;
            public int FileTimeDifferensIgnore;
            public bool SaveReplacedFiles;
            public string ReplacedFilesPath;
            public bool SaveDeletedFiles;
            public string DeletedFilesPath;
            public uint InternalBufferSize;
            public uint DuplicateBlockSize;

            public bool ShowLogFileInfo;
            public bool WriteLogdiskFileInfo;            

            public bool NoShowAboutBox;

            public List<string> IgnoredSystemFolders;
            public List<string> IgnoredDuplicateWords;

            public System.Drawing.Size WinSize;
            public System.Drawing.Point WinLocation;
            public System.Windows.Forms.FormWindowState WindowState;
        }

        public Confstruct conf;

        public static DataSet DefaultDataSet
        {
            get
            {
                DataSet Tasks = new DataSet("Tasks");
                Tasks.Tables.Add("TaskTable");
                Tasks.Tables["TaskTable"].Columns.Add("Source", typeof(string));
                Tasks.Tables["TaskTable"].Columns.Add("Destination", typeof(string));
                Tasks.Tables["TaskTable"].Columns.Add("Progress", typeof(double));
                Tasks.Tables["TaskTable"].Columns.Add("SyncType", typeof(string));
                Tasks.Tables["TaskTable"].Columns.Add("IgnoredFolders", typeof(string[]));
                Tasks.Tables["TaskTable"].Columns.Add("DeleteIgnoredFolders", typeof(bool));

                Tasks.Tables["TaskTable"].Columns.Add("SourceArchive", typeof(e_Archive_Type));
                Tasks.Tables["TaskTable"].Columns.Add("DestinationArchive", typeof(e_Archive_Type));

                return Tasks;
            }
        }


        public const c_SyncProcess.e_SyncType DefaultSyncType = c_SyncProcess.e_SyncType.SyncSourceToDest;
        public override void SetDefaultConfiguration()
        {
            conf = new Confstruct();
            conf.CurrentConf = new s_MainParam();
            conf.CurrentConf.SyncType = DefaultSyncType;
            conf.CurrentConf.Source = ApplicationPath;
            conf.CurrentConf.Destination = ApplicationPath;
            conf.CurrentConf.IgnoredFolders = new string[0];

            conf.LastSavedConfFile = ApplicationPath;

            conf.SaveDeletedFiles = false;
            conf.SaveReplacedFiles = false;                    
            conf.ReplacedFilesPath = ApplicationPath;
            conf.DeletedFilesPath = ApplicationPath;

            conf.WriteLogdiskFileInfo = true;

            conf.IgnoreTimeZoneChange = true;
            conf.IgnoreSummerWinterChange = true;
            conf.UseCRCcheckIfFileTimeDifferensSmall = false;
            conf.FileTimeDifferensCRCCheck = 3;
            conf.FileTimeDifferensIgnore = 3;
            
            conf.InternalBufferSize = 1024 * 1024 * 1;

            conf.AppPathsCompBasedID = new List<s_ComputerBasedConf>();
            conf.UseDifferentConfigurationsForComputers = true;

            conf.IgnoredSystemFolders = new List<string>();
            conf.IgnoredSystemFolders.Add("System Volume Information");
            conf.IgnoredSystemFolders.Add("RECYCLER");

            conf.DuplicateBlockSize = 100 * 1024;
            conf.IgnoredDuplicateWords = new List<string>();

            conf.CurrentConf.Tasks = DefaultDataSet;

            conf.WinSize = new System.Drawing.Size(0,0);
            conf.WinLocation = new System.Drawing.Point(0,0);
            conf.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        public override object SaveO
        {
            get
            {
                return conf;
            }
            set
            {
                conf = (Confstruct)value;
            }
        }

        public override bool NeeedDefaultConf()
        {
            if (conf.InternalBufferSize == 0
               || conf.AppPathsCompBasedID == null
               || conf.CurrentConf.Tasks == null
               || conf.CurrentConf.Tasks.Tables.Count == 0
               || conf.CurrentConf.Tasks.Tables[0].Columns.Count < DefaultDataSet.Tables[0].Columns.Count
               || conf.IgnoredSystemFolders == null
               )
            {
                return true;
            }
            return false;
        }

        public override void Load()
        {
            base.Load();
            if (conf.UseDifferentConfigurationsForComputers)
            {
                if (ComputerID == "")
                {
                    ComputerID = UniqueID.getUniqueID(string.Empty);
                }

                for (int i = 0; i < conf.AppPathsCompBasedID.Count; i++)
                {
                    if (conf.AppPathsCompBasedID[i].ComputerID == ComputerID)
                    {
                        conf.CurrentConf = conf.AppPathsCompBasedID[i].Param;
                    }
                }
            }
        }       

        
        public override void Save()
        {            
            if (conf.UseDifferentConfigurationsForComputers)
            {
                if (ComputerID == "")
                {
                    ComputerID = UniqueID.getUniqueID(string.Empty);
                }

                bool flag = false;
                s_ComputerBasedConf item = new s_ComputerBasedConf();
                item.ComputerID = ComputerID;
                item.Param = conf.CurrentConf;                
                
                for (int i = 0; i < conf.AppPathsCompBasedID.Count; i++)
                {
                    if (conf.AppPathsCompBasedID[i].ComputerID == ComputerID)
                    {
                        flag = true;
                        conf.AppPathsCompBasedID[i] = item;
                    }
                }

                if (!flag)
                {
                    this.conf.AppPathsCompBasedID.Add(item);
                }
            }
            base.Save();
        }

        private cc_AppConf()
        {            
            conf = new Confstruct();
            Load();
        }

        static cc_AppConf CurrInstance = null;
        public static cc_AppConf Instance
        {
            get
            {
                if (CurrInstance == null) CurrInstance = new cc_AppConf();
                return CurrInstance;
            }
        }
        


    }
}
