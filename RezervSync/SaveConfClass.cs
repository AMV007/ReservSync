using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RezervSync
{
    public class SaveConfClass : CommonControls.c_AppConf
    {
        public struct Confstruct
        {
            public cc_AppConf.s_MainParam CurrentParam;
        }

        public Confstruct conf;
        public override void SetDefaultConfiguration()
        {
            conf = new Confstruct();
            conf.CurrentParam = new cc_AppConf.s_MainParam();
            conf.CurrentParam.SyncType = c_SyncProcess.e_SyncType.SyncSourceToDest;
            conf.CurrentParam.Source = ApplicationPath;
            conf.CurrentParam.Destination = ApplicationPath;

            conf.CurrentParam.Tasks = cc_AppConf.DefaultDataSet; 
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
            if (conf.CurrentParam.Tasks == null
                     || conf.CurrentParam.Tasks.Tables.Count == 0
                     || conf.CurrentParam.Tasks.Tables[0].Columns.Count < cc_AppConf.DefaultDataSet.Tables[0].Columns.Count
                     )
            {
                return true;
            }
            return false;
        }       
        
        public SaveConfClass(string path)
        {
            conf = new Confstruct();

            if (path != "")
            {
                base.AppConfigurationPath = path;                
                Load();
            }
        }       

    }
}
