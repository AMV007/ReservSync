namespace RezervSync
{
    partial class FolderList
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
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.CheckBoxes = true;
            this.treeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFolders.Location = new System.Drawing.Point(0, 0);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(500, 408);
            this.treeViewFolders.TabIndex = 0;
            this.treeViewFolders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterCheck);
            this.treeViewFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewFolders_BeforeExpand);
            // 
            // FolderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewFolders);
            this.Name = "FolderList";
            this.Size = new System.Drawing.Size(500, 408);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFolders;
    }
}
