namespace RezervSync
{
    partial class CommitDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommitDialog));
            this.buttonReplace = new System.Windows.Forms.Button();
            this.buttonReplaceAll = new System.Windows.Forms.Button();
            this.buttonMissAll = new System.Windows.Forms.Button();
            this.buttonMiss = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxDestination = new System.Windows.Forms.GroupBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.groupBoxDestination.SuspendLayout();
            this.groupBoxSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReplace
            // 
            this.buttonReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReplace.Location = new System.Drawing.Point(12, 222);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(150, 33);
            this.buttonReplace.TabIndex = 1;
            this.buttonReplace.Text = "Заменить";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonReplaceAll
            // 
            this.buttonReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReplaceAll.Location = new System.Drawing.Point(168, 222);
            this.buttonReplaceAll.Name = "buttonReplaceAll";
            this.buttonReplaceAll.Size = new System.Drawing.Size(149, 33);
            this.buttonReplaceAll.TabIndex = 2;
            this.buttonReplaceAll.Text = "Заменить все";
            this.buttonReplaceAll.UseVisualStyleBackColor = true;
            this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
            // 
            // buttonMissAll
            // 
            this.buttonMissAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMissAll.Location = new System.Drawing.Point(168, 261);
            this.buttonMissAll.Name = "buttonMissAll";
            this.buttonMissAll.Size = new System.Drawing.Size(149, 34);
            this.buttonMissAll.TabIndex = 4;
            this.buttonMissAll.Text = "Пропустить все";
            this.buttonMissAll.UseVisualStyleBackColor = true;
            this.buttonMissAll.Click += new System.EventHandler(this.buttonMissAll_Click);
            // 
            // buttonMiss
            // 
            this.buttonMiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMiss.Location = new System.Drawing.Point(12, 261);
            this.buttonMiss.Name = "buttonMiss";
            this.buttonMiss.Size = new System.Drawing.Size(150, 34);
            this.buttonMiss.TabIndex = 3;
            this.buttonMiss.Text = "Пропустить";
            this.buttonMiss.UseVisualStyleBackColor = true;
            this.buttonMiss.Click += new System.EventHandler(this.buttonMiss_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(323, 261);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(136, 34);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxDestination
            // 
            this.groupBoxDestination.Controls.Add(this.labelDestination);
            this.groupBoxDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDestination.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDestination.Name = "groupBoxDestination";
            this.groupBoxDestination.Size = new System.Drawing.Size(588, 108);
            this.groupBoxDestination.TabIndex = 6;
            this.groupBoxDestination.TabStop = false;
            this.groupBoxDestination.Text = "Заменить :";
            // 
            // labelDestination
            // 
            this.labelDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDestination.Location = new System.Drawing.Point(3, 18);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(582, 87);
            this.labelDestination.TabIndex = 0;
            this.labelDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Controls.Add(this.labelSource);
            this.groupBoxSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSource.Location = new System.Drawing.Point(0, 108);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Size = new System.Drawing.Size(588, 103);
            this.groupBoxSource.TabIndex = 7;
            this.groupBoxSource.TabStop = false;
            this.groupBoxSource.Text = "Файлом :";
            // 
            // labelSource
            // 
            this.labelSource.BackColor = System.Drawing.SystemColors.Control;
            this.labelSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSource.Location = new System.Drawing.Point(3, 18);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(582, 82);
            this.labelSource.TabIndex = 1;
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 307);
            this.Controls.Add(this.groupBoxSource);
            this.Controls.Add(this.groupBoxDestination);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMissAll);
            this.Controls.Add(this.buttonMiss);
            this.Controls.Add(this.buttonReplaceAll);
            this.Controls.Add(this.buttonReplace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommitDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CommitDialog";
            this.groupBoxDestination.ResumeLayout(false);
            this.groupBoxSource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button buttonReplaceAll;
        private System.Windows.Forms.Button buttonMissAll;
        private System.Windows.Forms.Button buttonMiss;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxDestination;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label labelSource;
    }
}