using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonControls;

namespace RezervSync
{
    public partial class Settings : Form
    {
        cc_AppConf AppConf = cc_AppConf.Instance;
        c_ErrorDataWork ErrorWorkProc = c_ErrorDataWork.Instance;

        void SetHelpForControl(Control CurrContr)
        {
            foreach (Control xx in CurrContr.Controls)
            {
                SetHelpForControl(xx);
                xx.MouseMove += new MouseEventHandler(Help_MouseMove);
            }
        }

        void Help_MouseMove(object sender, MouseEventArgs e)
        {
            Control xx = (Control)sender;
            string HelpText=toolTip1.GetToolTip(xx);
            if (String.IsNullOrEmpty(HelpText))
            {
                HelpText = xx.Text;
            }
            if (!String.IsNullOrEmpty(HelpText))
            {
                toolStripStatusLabelHelp.Text = HelpText;
            }
            else
            {
                toolStripStatusLabelHelp.Text = "";
            }
        }

        public Settings()
        {
            InitializeComponent();

            checkBoxCalcOverallSize.Checked = AppConf.conf.CalcOvarallSize;
            checkBoxIgnoreTimeZone.Checked = AppConf.conf.IgnoreTimeZoneChange;
            checkBoxIgnoreSummerWinterTime.Checked = AppConf.conf.IgnoreSummerWinterChange;
            checkBoxUseCRCIfSlowTimeDifference.Checked = AppConf.conf.UseCRCcheckIfFileTimeDifferensSmall;
            numericUpDownCRCchecksec.Value = AppConf.conf.FileTimeDifferensCRCCheck;
            numericUpDownTimeDifferenseSec.Value = AppConf.conf.FileTimeDifferensIgnore;
            checkBoxSaveReplacedFiles.Checked = AppConf.conf.SaveReplacedFiles;
            textBoxReplaceFilesPath.Text = AppConf.conf.ReplacedFilesPath;
            checkBoxSaveDeletedFiles.Checked = AppConf.conf.SaveDeletedFiles;
            textBoxDeletedFilesPath.Text = AppConf.conf.DeletedFilesPath;
            checkBoxUseDifferentConfigurations.Checked = AppConf.conf.UseDifferentConfigurationsForComputers;
            numericUpDownBufferSize.Value = AppConf.conf.InternalBufferSize / (1024 * 1024);
            numericUpDownDuplicateBlockSize.Value = AppConf.conf.DuplicateBlockSize;

            checkBoxShowFileOperations.Checked = AppConf.conf.ShowLogFileInfo;
            checkBoxWriteFileOperations.Checked = AppConf.conf.WriteLogdiskFileInfo;

            listBoxIgnoredSystemDirs.Items.AddRange(AppConf.conf.IgnoredSystemFolders.ToArray());
            listBoxIgnoredDuplicateWords.Items.AddRange(AppConf.conf.IgnoredDuplicateWords.ToArray());

            SetHelpForControl(this);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConf.conf.CalcOvarallSize = checkBoxCalcOverallSize.Checked;
            AppConf.conf.IgnoreTimeZoneChange = checkBoxIgnoreTimeZone.Checked;
            AppConf.conf.IgnoreSummerWinterChange = checkBoxIgnoreSummerWinterTime.Checked;
            AppConf.conf.UseCRCcheckIfFileTimeDifferensSmall = checkBoxUseCRCIfSlowTimeDifference.Checked;
            AppConf.conf.FileTimeDifferensCRCCheck = (int)numericUpDownCRCchecksec.Value;
            AppConf.conf.FileTimeDifferensIgnore = (int)numericUpDownTimeDifferenseSec.Value;
            AppConf.conf.SaveReplacedFiles = checkBoxSaveReplacedFiles.Checked;
            AppConf.conf.ReplacedFilesPath = textBoxReplaceFilesPath.Text;
            AppConf.conf.SaveDeletedFiles = checkBoxSaveDeletedFiles.Checked;
            AppConf.conf.DeletedFilesPath = textBoxDeletedFilesPath.Text;
            AppConf.conf.InternalBufferSize = (uint)(numericUpDownBufferSize.Value*(1024 * 1024));
            AppConf.conf.UseDifferentConfigurationsForComputers = checkBoxUseDifferentConfigurations.Checked;
            AppConf.conf.DuplicateBlockSize = (uint)numericUpDownDuplicateBlockSize.Value;

            AppConf.conf.ShowLogFileInfo = checkBoxShowFileOperations.Checked;
            AppConf.conf.WriteLogdiskFileInfo = checkBoxWriteFileOperations.Checked;

            AppConf.conf.IgnoredSystemFolders.Clear();
            for (int i = 0; i < listBoxIgnoredSystemDirs.Items.Count; i++)
            {
                AppConf.conf.IgnoredSystemFolders.Add(listBoxIgnoredSystemDirs.Items[i].ToString());
            }

            AppConf.conf.IgnoredDuplicateWords.Clear();
            for (int i = 0; i < listBoxIgnoredDuplicateWords.Items.Count; i++)
            {
                AppConf.conf.IgnoredDuplicateWords.Add(listBoxIgnoredDuplicateWords.Items[i].ToString());
            }

            AppConf.Save();
        }

        private void checkBoxUseCRCIfSlowTimeDifference_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownCRCchecksec.Enabled = checkBoxUseCRCIfSlowTimeDifference.Checked;
        }

        private void buttonSelectReplacedFilesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialogthis = new FolderBrowserDialog();
            FolderBrowserDialogthis.SelectedPath = AppConf.conf.ReplacedFilesPath;

            if (FolderBrowserDialogthis.ShowDialog() == DialogResult.OK)
            {
                textBoxReplaceFilesPath.Text = FolderBrowserDialogthis.SelectedPath;
            }
        }

        private void checkBoxSaveReplacedFiles_CheckedChanged(object sender, EventArgs e)
        {
            textBoxReplaceFilesPath.Enabled = checkBoxSaveReplacedFiles.Checked;
            buttonSelectReplacedFilesPath.Enabled = checkBoxSaveReplacedFiles.Checked;
        }

        private void checkBoxSaveDeletedFilesPath_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDeletedFilesPath.Enabled = checkBoxSaveDeletedFiles.Checked;
            buttonSelectDeletedFilesPath.Enabled = checkBoxSaveDeletedFiles.Checked;
        }

        private void buttonSelectSaveDeletedFilesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialogthis = new FolderBrowserDialog();
            FolderBrowserDialogthis.SelectedPath = AppConf.conf.DeletedFilesPath;

            if (FolderBrowserDialogthis.ShowDialog() == DialogResult.OK)
            {
                textBoxDeletedFilesPath.Text = FolderBrowserDialogthis.SelectedPath;
            }
        }

        private void buttonAddIgnoredSystemDir_Click(object sender, EventArgs e)
        {
            CommonControls.CommonForms.GetString xx = new CommonControls.CommonForms.GetString(CommonControls.CommonForms.GetString.ViewType.TypeTextBox, 
                "Имя директории", null);
            if (xx.ShowDialog() == DialogResult.OK)
            {
                if (!listBoxIgnoredSystemDirs.Items.Contains(xx.ReturnValue))
                {
                    listBoxIgnoredSystemDirs.Items.Add(xx.ReturnValue);
                }
            }
        }

        private void buttonRemoveIgnoredSystemDir_Click(object sender, EventArgs e)
        {
            listBoxIgnoredSystemDirs.Items.RemoveAt(listBoxIgnoredSystemDirs.SelectedIndex);
        }

        private void buttonAddIgnoredDublicateWords_Click(object sender, EventArgs e)
        {
            CommonControls.CommonForms.GetString xx = new CommonControls.CommonForms.GetString(CommonControls.CommonForms.GetString.ViewType.TypeTextBox,
               "Игнорируемое слово", null);
            if (xx.ShowDialog() == DialogResult.OK)
            {
                if (!listBoxIgnoredDuplicateWords.Items.Contains(xx.ReturnValue))
                {
                    listBoxIgnoredDuplicateWords.Items.Add(xx.ReturnValue);
                }
            }
        }

        private void buttonDeleteIgnoredDuplicateWords_Click(object sender, EventArgs e)
        {
            listBoxIgnoredDuplicateWords.Items.RemoveAt(listBoxIgnoredDuplicateWords.SelectedIndex);
        }        
    }
}