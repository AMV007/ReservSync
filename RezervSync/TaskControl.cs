using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RezervSync
{
    public partial class TaskControl : UserControl
    {
        cc_AppConf.s_MainParam Param = new cc_AppConf.s_MainParam();
        public cc_AppConf.s_MainParam AllValues
        {
            set
            {   
                SyncType = value.SyncType;
                Source = value.Source;
                Destination = value.Destination;
                DeleteIgnoreFolders = value.DeleteIgnoredFolders;
                IgnoredFolders = value.IgnoredFolders;
                SourceArchive = value.SourceArchive;
                DetinationArchive = value.DestinationArchive;                
            }
            get
            {
                return Param;
            }
        }

        public c_SyncProcess.e_SyncType SyncType
        {
            get
            {
                return Param.SyncType;                
            }
            set
            {
                textBoxDestination.Enabled = true;
                buttonSelectDestination.Enabled = true;

                switch (value)
                {
                    case c_SyncProcess.e_SyncType.CopyOnly:
                        radioButtonCopy.Checked = true;
                        break;
                    case c_SyncProcess.e_SyncType.SyncJoinSourceAndDest:
                        radioButtonJoin.Checked = true;
                        break;
                    case c_SyncProcess.e_SyncType.SyncSourceToDest:
                        radioButtonSync.Checked = true;
                        break;
                    case c_SyncProcess.e_SyncType.DeleteFileDuplicatesInSource:
                        radioButtonDeleteFileDuplicates.Checked = true;
                        textBoxDestination.Enabled = false;
                        buttonSelectDestination.Enabled = false;
                        break;
                    case c_SyncProcess.e_SyncType.DeleteDublicatesFromSourceInDestination:
                        radioButtonDeleteDublicatesFromSourceToDestination.Checked = true;
                        break;
                    default:                        
                        break;
                }
            }
        }

        public string Source
        {
            get
            {             
                return Param.Source;
            }
            set
            {
                textBoxSource.Text = value;
            }
        }

        public string Destination
        {           
            set
            {
                textBoxDestination.Text = value;
            }
            get
            {                
                return Param.Destination;
            }
        }

        public bool DeleteIgnoreFolders
        {            
            set
            {
                checkBoxDeleteIgnore.Checked = value;
            }
            get
            {
                return Param.DeleteIgnoredFolders;
            }
        }        

        public string[] IgnoredFolders
        {            
            set
            {
                listBoxIgnoredFolders.Items.Clear();
                if(value!=null) listBoxIgnoredFolders.Items.AddRange(value);
                OnValuesChanged();
            }
            get
            {
                return Param.IgnoredFolders;
            }
        }

        public cc_AppConf.e_Archive_Type SourceArchive
        {
            set
            {
                comboBoxSourceArchiv.SelectedIndex = (int)value;
                comboBoxSourceArchiv.Select(0, 0);
            }
            get
            {
                 return Param.SourceArchive;                
            }
        }

        public cc_AppConf.e_Archive_Type DetinationArchive
        {
            set
            {
                comboBoxDestinationArchiv.SelectedIndex = (int)value;
                comboBoxDestinationArchiv.Select(0, 0);
            }
            get
            {
                return Param.DestinationArchive;
            }
        }
        
        public event EventHandler ValueChanged = null;

        public void GetAllValues(ref cc_AppConf.s_MainParam value)
        {
            value.Source = Param.Source;
            value.Destination = Param.Destination;
            value.DeleteIgnoredFolders = Param.DeleteIgnoredFolders;
            value.DestinationArchive = Param.DestinationArchive;
            value.IgnoredFolders = Param.IgnoredFolders;
            value.SyncType = Param.SyncType;
            value.SourceArchive = Param.SourceArchive;
        }

        public bool Initialized = true;

        void OnValuesChanged()
        {
            if (!Initialized) return;

            Param.Source = textBoxSource.Text;
            Param.Destination = textBoxDestination.Text;

            textBoxDestination.Enabled = true;
            buttonSelectDestination.Enabled = true;

            if (radioButtonCopy.Checked)
            {
                Param.SyncType = c_SyncProcess.e_SyncType.CopyOnly;
            }
            else if (radioButtonSync.Checked)
            {
                Param.SyncType = c_SyncProcess.e_SyncType.SyncSourceToDest;
            }
            else if(radioButtonJoin.Checked)
            {
                Param.SyncType = c_SyncProcess.e_SyncType.SyncJoinSourceAndDest;
            }
            else if (radioButtonDeleteFileDuplicates.Checked)
            {
                Param.SyncType = c_SyncProcess.e_SyncType.DeleteFileDuplicatesInSource;
                textBoxDestination.Enabled = false;
                buttonSelectDestination.Enabled = false;
            }
            else if (radioButtonDeleteDublicatesFromSourceToDestination.Checked)
            {
                Param.SyncType = c_SyncProcess.e_SyncType.DeleteDublicatesFromSourceInDestination;
            }

            Param.IgnoredFolders = new string[listBoxIgnoredFolders.Items.Count];
            for (int i = 0; i < listBoxIgnoredFolders.Items.Count; i++)
            {
                Param.IgnoredFolders[i] = listBoxIgnoredFolders.Items[i].ToString();
            }

            Param.DeleteIgnoredFolders = checkBoxDeleteIgnore.Checked;

            Param.SourceArchive = (cc_AppConf.e_Archive_Type)comboBoxSourceArchiv.SelectedIndex;
            Param.DestinationArchive = (cc_AppConf.e_Archive_Type)comboBoxDestinationArchiv.SelectedIndex;

            if (ValueChanged == null) return;
            ValueChanged.BeginInvoke(this, EventArgs.Empty, null, null);            
        }

        public TaskControl()
        {
            InitializeComponent();            

            comboBoxSourceArchiv.Items.AddRange(Enum.GetNames(typeof(cc_AppConf.e_Archive_Type)));
            comboBoxDestinationArchiv.Items.AddRange(Enum.GetNames(typeof(cc_AppConf.e_Archive_Type)));            
            //OnValuesChanged();
        }

        private void buttonSelectSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialogthis = new FolderBrowserDialog();
            if (Source != "")FolderBrowserDialogthis.SelectedPath = Source;                                    

            if (FolderBrowserDialogthis.ShowDialog() == DialogResult.OK)
            {
                textBoxSource.Text = FolderBrowserDialogthis.SelectedPath;
                /*
                for (int i=0;i<listBoxIgnoredFolders.Items.Count;i++)
                {
                    string Temp = listBoxIgnoredFolders.Items[i].ToString();
                    if (Temp[0] != textBoxSource.Text[0])
                    {
                        Temp=Temp.Remove(0,1);
                        Temp=textBoxSource.Text[0]+Temp;                        
                    }
                    listBoxIgnoredFolders.Items[i] = Temp;
                }
                 */
            }
        }

        private void buttonSelectDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialogthis = new FolderBrowserDialog();
            if (Destination != "") FolderBrowserDialogthis.SelectedPath = Destination;            

            if (FolderBrowserDialogthis.ShowDialog() == DialogResult.OK)
            {
                textBoxDestination.Text = FolderBrowserDialogthis.SelectedPath;
            }	
        }

        private void textBoxSource_TextChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        private void radioButtonCopy_CheckedChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        private void radioButtonSync_CheckedChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        private void radioButtonJoin_CheckedChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        string LastFolder = "";
        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialogthis = new FolderBrowserDialog();
            if (LastFolder != "") FolderBrowserDialogthis.SelectedPath = LastFolder;
            else FolderBrowserDialogthis.SelectedPath = Source;

            if (FolderBrowserDialogthis.ShowDialog() == DialogResult.OK)
            {
                LastFolder = FolderBrowserDialogthis.SelectedPath;
                if (System.IO.Directory.Exists(LastFolder))
                {
                    if (!listBoxIgnoredFolders.Items.Contains(LastFolder))
                    {
                        listBoxIgnoredFolders.Items.Add(LastFolder);
                        listBoxIgnoredFolders.SelectedIndex = listBoxIgnoredFolders.Items.Count - 1;
                        OnValuesChanged();
                    }
                    else
                    {
                        MessageBox.Show(LastFolder+" уже есть", "Внимание !");
                    }
                }                
            }
        }

        private void buttonDeleteAllFolders_Click(object sender, EventArgs e)
        {
            listBoxIgnoredFolders.Items.Clear();
            OnValuesChanged();
        }

        private void buttonDeleteFolder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxIgnoredFolders.SelectedIndices.Count; i++)
            {
                listBoxIgnoredFolders.Items.RemoveAt(listBoxIgnoredFolders.SelectedIndices[i]);
                //listBoxFolders.SelectedIndex = listBoxFolders.Items.Count - 1;
            }
            OnValuesChanged();
        }

        private void checkBoxDeleteIgnore_CheckedChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }
       
        private void comboBoxSourceArchiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        private void comboBoxDestinationArchiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        private void radioButtonDeleteFileDuplicates_CheckedChanged(object sender, EventArgs e)
        {            
            OnValuesChanged();
        }

        private void radioButtonDeleteDublicatesFromSourceToDestination_CheckedChanged(object sender, EventArgs e)
        {
            OnValuesChanged();
        }

        private void SortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Sort(Param.IgnoredFolders);
            listBoxIgnoredFolders.Items.Clear();
            listBoxIgnoredFolders.Items.AddRange(Param.IgnoredFolders);
            OnValuesChanged();              
        }

        private void buttoneditIgnoreFolders_Click(object sender, EventArgs e)
        {
            f_FolderList EditIgnoredFolders = new f_FolderList();

            EditIgnoredFolders.InitialPath = Param.Source;
            EditIgnoredFolders.UncheckedFolders = Param.IgnoredFolders;
            EditIgnoredFolders.DestinationPath = Param.Destination;

            if (EditIgnoredFolders.ShowDialog() == DialogResult.OK)
            {
                Param.IgnoredFolders = EditIgnoredFolders.UncheckedFolders;
                Array.Sort(Param.IgnoredFolders);
                listBoxIgnoredFolders.Items.Clear();
                listBoxIgnoredFolders.Items.AddRange(Param.IgnoredFolders);
                OnValuesChanged();
            }
        }    
    }
}
