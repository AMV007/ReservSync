namespace RezervSync
{
    partial class TaskProp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskProp));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.taskControlParam = new RezervSync.TaskControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(244, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 35);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(325, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOK);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 426);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // taskControlParam
            // 
            this.taskControlParam.DeleteIgnoreFolders = false;
            this.taskControlParam.Destination = "";
            this.taskControlParam.DetinationArchive = RezervSync.cc_AppConf.e_Archive_Type.None;
            this.taskControlParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskControlParam.IgnoredFolders = new string[0];
            this.taskControlParam.Location = new System.Drawing.Point(0, 0);
            this.taskControlParam.Name = "taskControlParam";
            this.taskControlParam.Size = new System.Drawing.Size(655, 426);
            this.taskControlParam.Source = "";
            this.taskControlParam.SourceArchive = RezervSync.cc_AppConf.e_Archive_Type.None;
            this.taskControlParam.SyncType = RezervSync.c_SyncProcess.e_SyncType.SyncSourceToDest;
            this.taskControlParam.TabIndex = 0;
            // 
            // TaskProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 479);
            this.Controls.Add(this.taskControlParam);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskProp";
            this.Text = "Праметры задачи";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        public TaskControl taskControlParam;
    }
}