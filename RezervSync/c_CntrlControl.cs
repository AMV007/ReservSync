using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RezervSync
{
    public class c_CntrlControl
    {
        private List<object> ControlledControls = new List<object>();
        Form parent;

        public bool AddControl(object NewCntrl)
        {
            if ((NewCntrl == null) || ControlledControls.Contains(NewCntrl))
            {
                return false;
            }
            ControlledControls.Add(NewCntrl);
            return true;
        }

        public void DisableControls()
        {
            parent.Invoke(dd_EnableDisableControls, false);
        }

        public void EnableControls()
        {
            parent.Invoke(dd_EnableDisableControls, true);
        }

        delegate void d_EnableDisableControls(bool State);
        d_EnableDisableControls dd_EnableDisableControls = null;

        private void EnableDisableControls(bool State)
        {
            for (int i = 0; i < ControlledControls.Count; i++)
            {
                string str2 = ControlledControls[i].GetType().ToString();
                switch (str2)
                {
                    case "System.Windows.Forms.Control":
                        ((Control) ControlledControls[i]).Enabled = State;
                        break;
                    case "System.Windows.Forms.Button":
                        ((Button) ControlledControls[i]).Enabled = State;
                        break;
                    case "System.Windows.Forms.MenuItem":
                        ((MenuItem) ControlledControls[i]).Enabled = State;
                        break;
                    case "System.Windows.Forms.ToolStripMenuItem":
                        ((ToolStripMenuItem) ControlledControls[i]).Enabled = State;
                        break;                    
                    case "System.Windows.Forms.DataGridView":
                        ((DataGridView)ControlledControls[i]).Enabled = State;
                        break;
                    case "System.Windows.Forms.TabPage":
                        ((TabPage)ControlledControls[i]).Enabled = State;
                        break;
                    case "System.Windows.Forms.TabControl":
                        ((TabControl)ControlledControls[i]).Enabled = State;
                        break;
                }
            }
        }

        public bool RemoveControl(Control RemovedControl)
        {
            return ControlledControls.Remove(RemovedControl);
        }

        public c_CntrlControl(Form Parent)
        {
            parent = Parent;
            dd_EnableDisableControls = new d_EnableDisableControls(EnableDisableControls);
        }
    }
}

