using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls;

namespace RezervSync
{
    public partial class f_FolderList : Form
    {
        cc_AppConf AppConf = cc_AppConf.Instance;

        public string[] UncheckedFolders
        {
            set
            {
                folderListFolders.UncheckedFolders = value;
            }
            get
            {
                return folderListFolders.UncheckedFolders;
            }
        }
        public string InitialPath
        {
            set
            {
                folderListFolders.InitialPath = value;
            }
            get
            {
                return folderListFolders.InitialPath;
            }
        }

        long DiskFreeSpace = 0;
        long DiskSize = 0;
        public string DestinationPath
        {
            set
            {
                try
                {
                    System.IO.DriveInfo xx = new System.IO.DriveInfo(value.Substring(0, Math.Min(3, value.Length)));
                    DiskFreeSpace = xx.AvailableFreeSpace;
                    DiskSize = xx.TotalSize;
                    labelDiskCapacity.Text = "Свободно в destination : " + c_CommonFunc.FormatSize(DiskFreeSpace,1000);
                    labelDestSize.Text = "Объем destination : " + c_CommonFunc.FormatSize(DiskSize,1000);
                }
                catch
                {
                }
            }            
        }

        public f_FolderList()
        {
            InitializeComponent();            
            this.DialogResult = DialogResult.Cancel;
            folderListFolders.IgnoredSystemFolders = AppConf.conf.IgnoredSystemFolders;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }         

        private void checkBoxCalkSize_CheckedChanged(object sender, EventArgs e)
        {
            folderListFolders.CalcSize=checkBoxCalkSize.Checked;
        }

        private void folderListFolders_SizeValueChanged(object sender, EventArgs e)
        {            
            FolderList.s_SizeInfo Info = (FolderList.s_SizeInfo)sender;
            if (Info.ProcessRunning)
            {
                labelSizeChecked.Text = "Подсчитываем ...";
            }
            else
            {
                labelSizeChecked.Text = "Выбранный объем : " + c_CommonFunc.FormatSize(Info.SizeChecked,1000);
                if (Info.SizeChecked > DiskSize)
                {
                    if (labelSizeChecked.BackColor != Color.Red)
                        labelSizeChecked.BackColor  = Color.Red;
                }                
                else if (Info.SizeChecked > DiskFreeSpace)
                {
                    if (labelSizeChecked.BackColor != Color.LightPink)
                        labelSizeChecked.BackColor  = Color.LightPink;
                }
                else
                {
                    if (labelSizeChecked.BackColor != SystemColors.Control)
                        labelSizeChecked.BackColor  =  SystemColors.Control;
                }
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            folderListFolders.CheckAll();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            folderListFolders.UncheckAll();
        }       
    }
}

