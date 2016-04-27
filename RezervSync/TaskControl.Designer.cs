namespace RezervSync
{
    partial class TaskControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskControl));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectDestination = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDeleteDublicatesFromSourceToDestination = new System.Windows.Forms.RadioButton();
            this.radioButtonDeleteFileDuplicates = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxDestinationArchiv = new System.Windows.Forms.ComboBox();
            this.comboBoxSourceArchiv = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonJoin = new System.Windows.Forms.RadioButton();
            this.radioButtonSync = new System.Windows.Forms.RadioButton();
            this.radioButtonCopy = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttoneditIgnoreFolders = new System.Windows.Forms.Button();
            this.checkBoxDeleteIgnore = new System.Windows.Forms.CheckBox();
            this.listBoxIgnoredFolders = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Source";
            // 
            // buttonSelectDestination
            // 
            this.buttonSelectDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDestination.Image = global::RezervSync.Properties.Resources.openfolderHS;
            this.buttonSelectDestination.Location = new System.Drawing.Point(438, 47);
            this.buttonSelectDestination.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSelectDestination.Name = "buttonSelectDestination";
            this.buttonSelectDestination.Size = new System.Drawing.Size(51, 25);
            this.buttonSelectDestination.TabIndex = 11;
            this.buttonSelectDestination.UseVisualStyleBackColor = true;
            this.buttonSelectDestination.Click += new System.EventHandler(this.buttonSelectDestination_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.Location = new System.Drawing.Point(79, 16);
            this.textBoxSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(354, 22);
            this.textBoxSource.TabIndex = 8;
            this.textBoxSource.TextChanged += new System.EventHandler(this.textBoxSource_TextChanged);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(79, 47);
            this.textBoxDestination.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(354, 22);
            this.textBoxDestination.TabIndex = 9;
            this.textBoxDestination.TextChanged += new System.EventHandler(this.textBoxSource_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDeleteDublicatesFromSourceToDestination);
            this.groupBox1.Controls.Add(this.radioButtonDeleteFileDuplicates);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.radioButtonJoin);
            this.groupBox1.Controls.Add(this.radioButtonSync);
            this.groupBox1.Controls.Add(this.radioButtonCopy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(495, 156);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Что сделать";
            // 
            // radioButtonDeleteDublicatesFromSourceToDestination
            // 
            this.radioButtonDeleteDublicatesFromSourceToDestination.AutoSize = true;
            this.radioButtonDeleteDublicatesFromSourceToDestination.Location = new System.Drawing.Point(5, 129);
            this.radioButtonDeleteDublicatesFromSourceToDestination.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonDeleteDublicatesFromSourceToDestination.Name = "radioButtonDeleteDublicatesFromSourceToDestination";
            this.radioButtonDeleteDublicatesFromSourceToDestination.Size = new System.Drawing.Size(320, 20);
            this.radioButtonDeleteDublicatesFromSourceToDestination.TabIndex = 5;
            this.radioButtonDeleteDublicatesFromSourceToDestination.Text = "Удаление дубликатов из Source в Destination";
            this.toolTip1.SetToolTip(this.radioButtonDeleteDublicatesFromSourceToDestination, resources.GetString("radioButtonDeleteDublicatesFromSourceToDestination.ToolTip"));
            this.radioButtonDeleteDublicatesFromSourceToDestination.UseVisualStyleBackColor = true;
            this.radioButtonDeleteDublicatesFromSourceToDestination.CheckedChanged += new System.EventHandler(this.radioButtonDeleteDublicatesFromSourceToDestination_CheckedChanged);
            // 
            // radioButtonDeleteFileDuplicates
            // 
            this.radioButtonDeleteFileDuplicates.AutoSize = true;
            this.radioButtonDeleteFileDuplicates.Location = new System.Drawing.Point(6, 103);
            this.radioButtonDeleteFileDuplicates.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonDeleteFileDuplicates.Name = "radioButtonDeleteFileDuplicates";
            this.radioButtonDeleteFileDuplicates.Size = new System.Drawing.Size(285, 20);
            this.radioButtonDeleteFileDuplicates.TabIndex = 4;
            this.radioButtonDeleteFileDuplicates.Text = "Удаление дубликатов файлов в Source";
            this.toolTip1.SetToolTip(this.radioButtonDeleteFileDuplicates, "просто удаление дубликатов файлов по содержимому из Source");
            this.radioButtonDeleteFileDuplicates.UseVisualStyleBackColor = true;
            this.radioButtonDeleteFileDuplicates.CheckedChanged += new System.EventHandler(this.radioButtonDeleteFileDuplicates_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxDestinationArchiv);
            this.groupBox4.Controls.Add(this.comboBoxSourceArchiv);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(270, 16);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Size = new System.Drawing.Size(222, 81);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Архивация";
            // 
            // comboBoxDestinationArchiv
            // 
            this.comboBoxDestinationArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDestinationArchiv.FormattingEnabled = true;
            this.comboBoxDestinationArchiv.Location = new System.Drawing.Point(94, 52);
            this.comboBoxDestinationArchiv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxDestinationArchiv.Name = "comboBoxDestinationArchiv";
            this.comboBoxDestinationArchiv.Size = new System.Drawing.Size(123, 24);
            this.comboBoxDestinationArchiv.TabIndex = 3;
            this.comboBoxDestinationArchiv.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestinationArchiv_SelectedIndexChanged);
            // 
            // comboBoxSourceArchiv
            // 
            this.comboBoxSourceArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSourceArchiv.FormattingEnabled = true;
            this.comboBoxSourceArchiv.Location = new System.Drawing.Point(94, 22);
            this.comboBoxSourceArchiv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxSourceArchiv.Name = "comboBoxSourceArchiv";
            this.comboBoxSourceArchiv.Size = new System.Drawing.Size(123, 24);
            this.comboBoxSourceArchiv.TabIndex = 2;
            this.comboBoxSourceArchiv.SelectedIndexChanged += new System.EventHandler(this.comboBoxSourceArchiv_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Source";
            // 
            // radioButtonJoin
            // 
            this.radioButtonJoin.AutoSize = true;
            this.radioButtonJoin.Location = new System.Drawing.Point(6, 76);
            this.radioButtonJoin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonJoin.Name = "radioButtonJoin";
            this.radioButtonJoin.Size = new System.Drawing.Size(250, 20);
            this.radioButtonJoin.TabIndex = 2;
            this.radioButtonJoin.Text = "Объединить Source<==>Destination";
            this.toolTip1.SetToolTip(this.radioButtonJoin, resources.GetString("radioButtonJoin.ToolTip"));
            this.radioButtonJoin.UseVisualStyleBackColor = true;
            this.radioButtonJoin.CheckedChanged += new System.EventHandler(this.radioButtonJoin_CheckedChanged);
            // 
            // radioButtonSync
            // 
            this.radioButtonSync.AutoSize = true;
            this.radioButtonSync.Checked = true;
            this.radioButtonSync.Location = new System.Drawing.Point(6, 49);
            this.radioButtonSync.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonSync.Name = "radioButtonSync";
            this.radioButtonSync.Size = new System.Drawing.Size(273, 20);
            this.radioButtonSync.TabIndex = 1;
            this.radioButtonSync.TabStop = true;
            this.radioButtonSync.Text = "Синхронизировать Destination=Source";
            this.toolTip1.SetToolTip(this.radioButtonSync, resources.GetString("radioButtonSync.ToolTip"));
            this.radioButtonSync.UseVisualStyleBackColor = true;
            this.radioButtonSync.CheckedChanged += new System.EventHandler(this.radioButtonSync_CheckedChanged);
            // 
            // radioButtonCopy
            // 
            this.radioButtonCopy.AutoSize = true;
            this.radioButtonCopy.Location = new System.Drawing.Point(6, 22);
            this.radioButtonCopy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonCopy.Name = "radioButtonCopy";
            this.radioButtonCopy.Size = new System.Drawing.Size(230, 20);
            this.radioButtonCopy.TabIndex = 0;
            this.radioButtonCopy.Text = "Копировать Source->Destination";
            this.toolTip1.SetToolTip(this.radioButtonCopy, "Просто копировать Source в Destination");
            this.radioButtonCopy.UseVisualStyleBackColor = true;
            this.radioButtonCopy.CheckedChanged += new System.EventHandler(this.radioButtonCopy_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttoneditIgnoreFolders);
            this.groupBox2.Controls.Add(this.checkBoxDeleteIgnore);
            this.groupBox2.Controls.Add(this.listBoxIgnoredFolders);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 231);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(495, 194);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Игнорировать папки с подпапками из Source";
            // 
            // buttoneditIgnoreFolders
            // 
            this.buttoneditIgnoreFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttoneditIgnoreFolders.Location = new System.Drawing.Point(380, 18);
            this.buttoneditIgnoreFolders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttoneditIgnoreFolders.Name = "buttoneditIgnoreFolders";
            this.buttoneditIgnoreFolders.Size = new System.Drawing.Size(112, 50);
            this.buttoneditIgnoreFolders.TabIndex = 5;
            this.buttoneditIgnoreFolders.Text = "Править список";
            this.buttoneditIgnoreFolders.UseVisualStyleBackColor = true;
            this.buttoneditIgnoreFolders.Click += new System.EventHandler(this.buttoneditIgnoreFolders_Click);
            // 
            // checkBoxDeleteIgnore
            // 
            this.checkBoxDeleteIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDeleteIgnore.Location = new System.Drawing.Point(380, 74);
            this.checkBoxDeleteIgnore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxDeleteIgnore.Name = "checkBoxDeleteIgnore";
            this.checkBoxDeleteIgnore.Size = new System.Drawing.Size(112, 44);
            this.checkBoxDeleteIgnore.TabIndex = 4;
            this.checkBoxDeleteIgnore.Text = "Удалять их в Destination";
            this.checkBoxDeleteIgnore.UseVisualStyleBackColor = true;
            this.checkBoxDeleteIgnore.CheckedChanged += new System.EventHandler(this.checkBoxDeleteIgnore_CheckedChanged);
            // 
            // listBoxIgnoredFolders
            // 
            this.listBoxIgnoredFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIgnoredFolders.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxIgnoredFolders.FormattingEnabled = true;
            this.listBoxIgnoredFolders.IntegralHeight = false;
            this.listBoxIgnoredFolders.ItemHeight = 16;
            this.listBoxIgnoredFolders.Location = new System.Drawing.Point(2, 18);
            this.listBoxIgnoredFolders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxIgnoredFolders.Name = "listBoxIgnoredFolders";
            this.listBoxIgnoredFolders.Size = new System.Drawing.Size(373, 170);
            this.listBoxIgnoredFolders.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 26);
            // 
            // SortToolStripMenuItem
            // 
            this.SortToolStripMenuItem.Name = "SortToolStripMenuItem";
            this.SortToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.SortToolStripMenuItem.Text = "Сортировать";
            this.SortToolStripMenuItem.Click += new System.EventHandler(this.SortToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxDestination);
            this.groupBox3.Controls.Add(this.buttonSelectDestination);
            this.groupBox3.Controls.Add(this.textBoxSource);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.buttonSelectSource);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(495, 75);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // buttonSelectSource
            // 
            this.buttonSelectSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectSource.Image = global::RezervSync.Properties.Resources.openfolderHS;
            this.buttonSelectSource.Location = new System.Drawing.Point(438, 15);
            this.buttonSelectSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSelectSource.Name = "buttonSelectSource";
            this.buttonSelectSource.Size = new System.Drawing.Size(51, 25);
            this.buttonSelectSource.TabIndex = 10;
            this.buttonSelectSource.UseVisualStyleBackColor = true;
            this.buttonSelectSource.Click += new System.EventHandler(this.buttonSelectSource_Click);
            // 
            // TaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TaskControl";
            this.Size = new System.Drawing.Size(495, 425);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectSource;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonJoin;
        private System.Windows.Forms.RadioButton radioButtonSync;
        private System.Windows.Forms.RadioButton radioButtonCopy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxIgnoredFolders;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxDeleteIgnore;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxDestinationArchiv;
        private System.Windows.Forms.ComboBox comboBoxSourceArchiv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonDeleteFileDuplicates;
        private System.Windows.Forms.RadioButton radioButtonDeleteDublicatesFromSourceToDestination;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SortToolStripMenuItem;
        private System.Windows.Forms.Button buttoneditIgnoreFolders;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
