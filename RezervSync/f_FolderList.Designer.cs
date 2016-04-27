namespace RezervSync
{
    partial class f_FolderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_FolderList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxCalkSize = new System.Windows.Forms.CheckBox();
            this.labelSizeChecked = new System.Windows.Forms.Label();
            this.labelDiskCapacity = new System.Windows.Forms.Label();
            this.labelDestSize = new System.Windows.Forms.Label();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.folderListFolders = new RezervSync.FolderList();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.folderListFolders);
            this.groupBox1.Location = new System.Drawing.Point(5, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 304);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор директорий";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.Location = new System.Drawing.Point(5, 352);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 26);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(86, 352);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxCalkSize
            // 
            this.checkBoxCalkSize.AutoSize = true;
            this.checkBoxCalkSize.Location = new System.Drawing.Point(335, 4);
            this.checkBoxCalkSize.Name = "checkBoxCalkSize";
            this.checkBoxCalkSize.Size = new System.Drawing.Size(177, 21);
            this.checkBoxCalkSize.TabIndex = 6;
            this.checkBoxCalkSize.Text = "Подсчитывать размер";
            this.checkBoxCalkSize.UseVisualStyleBackColor = true;
            this.checkBoxCalkSize.CheckedChanged += new System.EventHandler(this.checkBoxCalkSize_CheckedChanged);
            // 
            // labelSizeChecked
            // 
            this.labelSizeChecked.AutoSize = true;
            this.labelSizeChecked.Location = new System.Drawing.Point(332, 28);
            this.labelSizeChecked.Name = "labelSizeChecked";
            this.labelSizeChecked.Size = new System.Drawing.Size(131, 17);
            this.labelSizeChecked.TabIndex = 7;
            this.labelSizeChecked.Text = "Выбранный объем";
            // 
            // labelDiskCapacity
            // 
            this.labelDiskCapacity.AutoSize = true;
            this.labelDiskCapacity.Location = new System.Drawing.Point(5, 22);
            this.labelDiskCapacity.Name = "labelDiskCapacity";
            this.labelDiskCapacity.Size = new System.Drawing.Size(156, 17);
            this.labelDiskCapacity.TabIndex = 8;
            this.labelDiskCapacity.Text = "Свободно в destination";
            // 
            // labelDestSize
            // 
            this.labelDestSize.AutoSize = true;
            this.labelDestSize.Location = new System.Drawing.Point(5, 5);
            this.labelDestSize.Name = "labelDestSize";
            this.labelDestSize.Size = new System.Drawing.Size(126, 17);
            this.labelDestSize.TabIndex = 9;
            this.labelDestSize.Text = "Объем destination";
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAll.Location = new System.Drawing.Point(582, 352);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(119, 26);
            this.buttonSelectAll.TabIndex = 10;
            this.buttonSelectAll.Text = "Выбрать все";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearAll.Location = new System.Drawing.Point(707, 352);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(117, 26);
            this.buttonClearAll.TabIndex = 11;
            this.buttonClearAll.Text = "Очистить все";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // folderListFolders
            // 
            this.folderListFolders.CalcSize = false;
            this.folderListFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderListFolders.IgnoredSystemFolders = ((System.Collections.Generic.List<string>)(resources.GetObject("folderListFolders.IgnoredSystemFolders")));
            this.folderListFolders.InitialPath = "";
            this.folderListFolders.Location = new System.Drawing.Point(3, 18);
            this.folderListFolders.Name = "folderListFolders";
            this.folderListFolders.Size = new System.Drawing.Size(816, 283);
            this.folderListFolders.TabIndex = 0;
            this.folderListFolders.UncheckedFolders = new string[0];
            this.folderListFolders.SizeValueChanged += new System.EventHandler(this.folderListFolders_SizeValueChanged);
            // 
            // f_FolderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 380);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.labelDestSize);
            this.Controls.Add(this.labelDiskCapacity);
            this.Controls.Add(this.labelSizeChecked);
            this.Controls.Add(this.checkBoxCalkSize);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_FolderList";
            this.Text = "Выбираем копируемые директории";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderList folderListFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxCalkSize;
        private System.Windows.Forms.Label labelSizeChecked;
        private System.Windows.Forms.Label labelDiskCapacity;
        private System.Windows.Forms.Label labelDestSize;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonClearAll;
    }
}