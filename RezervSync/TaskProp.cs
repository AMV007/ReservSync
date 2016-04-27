using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RezervSync
{
    public partial class TaskProp : Form
    {
        public TaskProp()
        {            
            InitializeComponent();
            taskControlParam.Initialized = true;
            this.DialogResult = DialogResult.Cancel;
            taskControlParam.SyncType = cc_AppConf.DefaultSyncType;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (taskControlParam.Source == ""
                || taskControlParam.Destination == ""
                || taskControlParam.Source == taskControlParam.Destination)
            {
                MessageBox.Show("Неправильно заданы параметры Source и Destination");
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            base.OnKeyDown(e);
        }

        private void taskControlParam_KeyDown(object sender, KeyEventArgs e)
        {

        }        
    }
}
