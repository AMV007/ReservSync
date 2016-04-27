namespace RezervSync
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControlTask = new System.Windows.Forms.TabControl();
            this.tabPageSimple = new System.Windows.Forms.TabPage();
            this.buttonAddNewTaskFromQuick = new System.Windows.Forms.Button();
            this.taskControlBasic = new RezervSync.TaskControl();
            this.tabPageTasks = new System.Windows.Forms.TabPage();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.ColumnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgress = new RezervSync.DataGridViewProgressColumn();
            this.ColumnDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSyncType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnDeleteIgnored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceArchive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDestinationArchive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripSequence = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDown = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonResetTasks = new System.Windows.Forms.Button();
            this.buttonEditTask = new System.Windows.Forms.Button();
            this.buttonDeleteTask = new System.Windows.Forms.Button();
            this.buttonTaskUp = new System.Windows.Forms.Button();
            this.buttonTaskDown = new System.Windows.Forms.Button();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.buttonRestartTasks = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxPause = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonCompleteTask = new System.Windows.Forms.Button();
            this.buttonStartCurrentTask = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPercent = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRemainTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotalTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarProgress = new RezervSync.InternalProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewConf = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instantaneousSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.AdditionalSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressBarBuffer = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCurrFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewProgressColumn1 = new RezervSync.DataGridViewProgressColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.tabControlTask.SuspendLayout();
            this.tabPageSimple.SuspendLayout();
            this.tabPageTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.contextMenuStripSequence.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.tabControlTask);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(535, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // tabControlTask
            // 
            this.tabControlTask.Controls.Add(this.tabPageSimple);
            this.tabControlTask.Controls.Add(this.tabPageTasks);
            this.tabControlTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTask.Location = new System.Drawing.Point(2, 15);
            this.tabControlTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlTask.Name = "tabControlTask";
            this.tabControlTask.SelectedIndex = 0;
            this.tabControlTask.Size = new System.Drawing.Size(531, 267);
            this.tabControlTask.TabIndex = 6;
            this.tabControlTask.SelectedIndexChanged += new System.EventHandler(this.tabControlTask_SelectedIndexChanged);
            // 
            // tabPageSimple
            // 
            this.tabPageSimple.BackColor = System.Drawing.Color.PaleGreen;
            this.tabPageSimple.Controls.Add(this.buttonAddNewTaskFromQuick);
            this.tabPageSimple.Controls.Add(this.taskControlBasic);
            this.tabPageSimple.Location = new System.Drawing.Point(4, 22);
            this.tabPageSimple.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageSimple.Name = "tabPageSimple";
            this.tabPageSimple.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageSimple.Size = new System.Drawing.Size(523, 241);
            this.tabPageSimple.TabIndex = 0;
            this.tabPageSimple.Text = "Быстрый запуск";
            this.tabPageSimple.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewTaskFromQuick
            // 
            this.buttonAddNewTaskFromQuick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNewTaskFromQuick.Location = new System.Drawing.Point(429, 82);
            this.buttonAddNewTaskFromQuick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddNewTaskFromQuick.Name = "buttonAddNewTaskFromQuick";
            this.buttonAddNewTaskFromQuick.Size = new System.Drawing.Size(90, 63);
            this.buttonAddNewTaskFromQuick.TabIndex = 6;
            this.buttonAddNewTaskFromQuick.Text = "Добавить настройку в очередь ->>";
            this.buttonAddNewTaskFromQuick.UseVisualStyleBackColor = true;
            this.buttonAddNewTaskFromQuick.Click += new System.EventHandler(this.buttonAddNewTaskFromQuick_Click);
            // 
            // taskControlBasic
            // 
            this.taskControlBasic.DeleteIgnoreFolders = false;
            this.taskControlBasic.Destination = "";
            this.taskControlBasic.DetinationArchive = RezervSync.cc_AppConf.e_Archive_Type.None;
            this.taskControlBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskControlBasic.IgnoredFolders = new string[0];
            this.taskControlBasic.Location = new System.Drawing.Point(2, 2);
            this.taskControlBasic.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.taskControlBasic.Name = "taskControlBasic";
            this.taskControlBasic.Size = new System.Drawing.Size(519, 237);
            this.taskControlBasic.Source = "";
            this.taskControlBasic.SourceArchive = RezervSync.cc_AppConf.e_Archive_Type.None;
            this.taskControlBasic.SyncType = RezervSync.c_SyncProcess.e_SyncType.CopyOnly;
            this.taskControlBasic.TabIndex = 7;
            // 
            // tabPageTasks
            // 
            this.tabPageTasks.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tabPageTasks.Controls.Add(this.dataGridViewTasks);
            this.tabPageTasks.Controls.Add(this.panel2);
            this.tabPageTasks.Controls.Add(this.buttonDeleteTask);
            this.tabPageTasks.Controls.Add(this.buttonTaskUp);
            this.tabPageTasks.Controls.Add(this.buttonTaskDown);
            this.tabPageTasks.Location = new System.Drawing.Point(4, 22);
            this.tabPageTasks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageTasks.Name = "tabPageTasks";
            this.tabPageTasks.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageTasks.Size = new System.Drawing.Size(524, 246);
            this.tabPageTasks.TabIndex = 1;
            this.tabPageTasks.Text = "По очереди";
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.AllowUserToDeleteRows = false;
            this.dataGridViewTasks.AllowUserToResizeRows = false;
            this.dataGridViewTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTasks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSource,
            this.ColumnProgress,
            this.ColumnDestination,
            this.ColumnSyncType,
            this.ColumnDeleteIgnored,
            this.ColumnSourceArchive,
            this.ColumnDestinationArchive});
            this.dataGridViewTasks.ContextMenuStrip = this.contextMenuStripSequence;
            this.dataGridViewTasks.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewTasks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewTasks.MultiSelect = false;
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.ReadOnly = true;
            this.dataGridViewTasks.RowHeadersVisible = false;
            this.dataGridViewTasks.RowTemplate.Height = 24;
            this.dataGridViewTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTasks.Size = new System.Drawing.Size(490, 211);
            this.dataGridViewTasks.TabIndex = 0;
            this.dataGridViewTasks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTasks_CellDoubleClick);
            this.dataGridViewTasks.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTasks_CellMouseDown);
            // 
            // ColumnSource
            // 
            this.ColumnSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSource.DataPropertyName = "Source";
            this.ColumnSource.HeaderText = "Source";
            this.ColumnSource.Name = "ColumnSource";
            this.ColumnSource.ReadOnly = true;
            // 
            // ColumnProgress
            // 
            this.ColumnProgress.DataPropertyName = "Progress";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnProgress.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnProgress.HeaderText = "Прогресс";
            this.ColumnProgress.Name = "ColumnProgress";
            this.ColumnProgress.ReadOnly = true;
            this.ColumnProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnProgress.Width = 94;
            // 
            // ColumnDestination
            // 
            this.ColumnDestination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDestination.DataPropertyName = "Destination";
            this.ColumnDestination.HeaderText = "Destination";
            this.ColumnDestination.Name = "ColumnDestination";
            this.ColumnDestination.ReadOnly = true;
            // 
            // ColumnSyncType
            // 
            this.ColumnSyncType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSyncType.DataPropertyName = "SyncType";
            dataGridViewCellStyle2.NullValue = "Синхронизировать Destination=Source";
            this.ColumnSyncType.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSyncType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnSyncType.HeaderText = "Тип синхронизации";
            this.ColumnSyncType.Items.AddRange(new object[] {
            "Копировать Source->Destination",
            "Синхронизировать Destination=Source",
            "Объединить Destination==Source"});
            this.ColumnSyncType.Name = "ColumnSyncType";
            this.ColumnSyncType.ReadOnly = true;
            this.ColumnSyncType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSyncType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnDeleteIgnored
            // 
            this.ColumnDeleteIgnored.DataPropertyName = "DeleteIgnoredFolders";
            this.ColumnDeleteIgnored.HeaderText = "Удалять Игнорируемые";
            this.ColumnDeleteIgnored.Name = "ColumnDeleteIgnored";
            this.ColumnDeleteIgnored.ReadOnly = true;
            this.ColumnDeleteIgnored.Visible = false;
            // 
            // ColumnSourceArchive
            // 
            this.ColumnSourceArchive.DataPropertyName = "SourceArchive";
            this.ColumnSourceArchive.HeaderText = "SourceArchive";
            this.ColumnSourceArchive.Name = "ColumnSourceArchive";
            this.ColumnSourceArchive.ReadOnly = true;
            this.ColumnSourceArchive.Visible = false;
            // 
            // ColumnDestinationArchive
            // 
            this.ColumnDestinationArchive.DataPropertyName = "DestinationArchive";
            this.ColumnDestinationArchive.HeaderText = "DestinationArchive";
            this.ColumnDestinationArchive.Name = "ColumnDestinationArchive";
            this.ColumnDestinationArchive.ReadOnly = true;
            this.ColumnDestinationArchive.Visible = false;
            // 
            // contextMenuStripSequence
            // 
            this.contextMenuStripSequence.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAdd,
            this.ToolStripMenuItemEdit,
            this.toolStripMenuItem3,
            this.ToolStripMenuItemDelete,
            this.ToolStripMenuItemReset,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemUp,
            this.ToolStripMenuItemDown});
            this.contextMenuStripSequence.Name = "contextMenuStripSequence";
            this.contextMenuStripSequence.Size = new System.Drawing.Size(246, 148);
            this.contextMenuStripSequence.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripSequence_Opening);
            // 
            // ToolStripMenuItemAdd
            // 
            this.ToolStripMenuItemAdd.Name = "ToolStripMenuItemAdd";
            this.ToolStripMenuItemAdd.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItemAdd.Text = "Добавить";
            this.ToolStripMenuItemAdd.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItemEdit.Text = "Редактировать";
            this.ToolStripMenuItemEdit.Click += new System.EventHandler(this.buttonEditTask_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(242, 6);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItemDelete.Text = "Удалить";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.buttonDeleteTask_Click);
            // 
            // ToolStripMenuItemReset
            // 
            this.ToolStripMenuItemReset.Name = "ToolStripMenuItemReset";
            this.ToolStripMenuItemReset.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItemReset.Text = "Обнулить выполнение";
            this.ToolStripMenuItemReset.Click += new System.EventHandler(this.buttonResetTasks_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // ToolStripMenuItemUp
            // 
            this.ToolStripMenuItemUp.Name = "ToolStripMenuItemUp";
            this.ToolStripMenuItemUp.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItemUp.Text = "Вверх";
            this.ToolStripMenuItemUp.Click += new System.EventHandler(this.buttonTaskUp_Click);
            // 
            // ToolStripMenuItemDown
            // 
            this.ToolStripMenuItemDown.Name = "ToolStripMenuItemDown";
            this.ToolStripMenuItemDown.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItemDown.Text = "Вниз";
            this.ToolStripMenuItemDown.Click += new System.EventHandler(this.buttonTaskDown_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonAddTask);
            this.panel2.Controls.Add(this.buttonResetTasks);
            this.panel2.Controls.Add(this.buttonEditTask);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 214);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 32);
            this.panel2.TabIndex = 7;
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(2, 3);
            this.buttonAddTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(67, 27);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "Добавить";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // buttonResetTasks
            // 
            this.buttonResetTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetTasks.Location = new System.Drawing.Point(340, 3);
            this.buttonResetTasks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonResetTasks.Name = "buttonResetTasks";
            this.buttonResetTasks.Size = new System.Drawing.Size(174, 27);
            this.buttonResetTasks.TabIndex = 6;
            this.buttonResetTasks.Text = "Сбросить прогресс";
            this.toolTip1.SetToolTip(this.buttonResetTasks, "Обнулить выполнение задания");
            this.buttonResetTasks.UseVisualStyleBackColor = true;
            this.buttonResetTasks.Click += new System.EventHandler(this.buttonResetTasks_Click);
            // 
            // buttonEditTask
            // 
            this.buttonEditTask.Location = new System.Drawing.Point(151, 3);
            this.buttonEditTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEditTask.Name = "buttonEditTask";
            this.buttonEditTask.Size = new System.Drawing.Size(100, 27);
            this.buttonEditTask.TabIndex = 3;
            this.buttonEditTask.Text = "Редактировать";
            this.buttonEditTask.UseVisualStyleBackColor = true;
            this.buttonEditTask.Click += new System.EventHandler(this.buttonEditTask_Click);
            // 
            // buttonDeleteTask
            // 
            this.buttonDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteTask.BackgroundImage = global::RezervSync.Properties.Resources.XSDSchema_ClearWorkspaceCmd;
            this.buttonDeleteTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteTask.Location = new System.Drawing.Point(494, 91);
            this.buttonDeleteTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteTask.Name = "buttonDeleteTask";
            this.buttonDeleteTask.Size = new System.Drawing.Size(30, 27);
            this.buttonDeleteTask.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonDeleteTask, "Удалить");
            this.buttonDeleteTask.UseVisualStyleBackColor = true;
            this.buttonDeleteTask.Click += new System.EventHandler(this.buttonDeleteTask_Click);
            // 
            // buttonTaskUp
            // 
            this.buttonTaskUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTaskUp.BackgroundImage = global::RezervSync.Properties.Resources.GoUp;
            this.buttonTaskUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTaskUp.Location = new System.Drawing.Point(494, 5);
            this.buttonTaskUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTaskUp.Name = "buttonTaskUp";
            this.buttonTaskUp.Size = new System.Drawing.Size(28, 27);
            this.buttonTaskUp.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonTaskUp, "Вверх");
            this.buttonTaskUp.UseVisualStyleBackColor = true;
            this.buttonTaskUp.Click += new System.EventHandler(this.buttonTaskUp_Click);
            // 
            // buttonTaskDown
            // 
            this.buttonTaskDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTaskDown.BackgroundImage = global::RezervSync.Properties.Resources.GoDown;
            this.buttonTaskDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTaskDown.Location = new System.Drawing.Point(494, 182);
            this.buttonTaskDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTaskDown.Name = "buttonTaskDown";
            this.buttonTaskDown.Size = new System.Drawing.Size(30, 27);
            this.buttonTaskDown.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonTaskDown, "Вниз");
            this.buttonTaskDown.UseVisualStyleBackColor = true;
            this.buttonTaskDown.Click += new System.EventHandler(this.buttonTaskDown_Click);
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.BackColor = System.Drawing.Color.DarkGray;
            this.groupBoxAction.Controls.Add(this.buttonRestartTasks);
            this.groupBoxAction.Controls.Add(this.buttonStart);
            this.groupBoxAction.Controls.Add(this.checkBoxPause);
            this.groupBoxAction.Controls.Add(this.buttonStop);
            this.groupBoxAction.Controls.Add(this.buttonCompleteTask);
            this.groupBoxAction.Controls.Add(this.buttonStartCurrentTask);
            this.groupBoxAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAction.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxAction.Size = new System.Drawing.Size(535, 69);
            this.groupBoxAction.TabIndex = 1;
            this.groupBoxAction.TabStop = false;
            this.groupBoxAction.Text = "Действие";
            // 
            // buttonRestartTasks
            // 
            this.buttonRestartTasks.Location = new System.Drawing.Point(114, 16);
            this.buttonRestartTasks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRestartTasks.Name = "buttonRestartTasks";
            this.buttonRestartTasks.Size = new System.Drawing.Size(150, 46);
            this.buttonRestartTasks.TabIndex = 7;
            this.buttonRestartTasks.Text = "Перезапустить все задания";
            this.buttonRestartTasks.UseVisualStyleBackColor = true;
            this.buttonRestartTasks.Click += new System.EventHandler(this.buttonRestartTasks_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(342, 16);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(62, 46);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxPause
            // 
            this.checkBoxPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPause.Location = new System.Drawing.Point(412, 16);
            this.checkBoxPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxPause.Name = "checkBoxPause";
            this.checkBoxPause.Size = new System.Drawing.Size(58, 46);
            this.checkBoxPause.TabIndex = 4;
            this.checkBoxPause.Text = "Пауза";
            this.checkBoxPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxPause.UseVisualStyleBackColor = true;
            this.checkBoxPause.CheckedChanged += new System.EventHandler(this.checkBoxPause_CheckedChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(474, 16);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 46);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonCompleteTask
            // 
            this.buttonCompleteTask.Location = new System.Drawing.Point(5, 16);
            this.buttonCompleteTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCompleteTask.Name = "buttonCompleteTask";
            this.buttonCompleteTask.Size = new System.Drawing.Size(104, 46);
            this.buttonCompleteTask.TabIndex = 9;
            this.buttonCompleteTask.Text = "Запустить незаконченные";
            this.buttonCompleteTask.UseVisualStyleBackColor = true;
            this.buttonCompleteTask.Click += new System.EventHandler(this.buttonCompleteTask_Click);
            // 
            // buttonStartCurrentTask
            // 
            this.buttonStartCurrentTask.Location = new System.Drawing.Point(268, 16);
            this.buttonStartCurrentTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStartCurrentTask.Name = "buttonStartCurrentTask";
            this.buttonStartCurrentTask.Size = new System.Drawing.Size(134, 46);
            this.buttonStartCurrentTask.TabIndex = 8;
            this.buttonStartCurrentTask.Text = "Запустить выделенное задание";
            this.buttonStartCurrentTask.UseVisualStyleBackColor = true;
            this.buttonStartCurrentTask.Click += new System.EventHandler(this.buttonStartCurrentTask_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.BackColor = System.Drawing.Color.MediumAquamarine;
            this.groupBoxLog.Controls.Add(this.listBoxLog);
            this.groupBoxLog.Controls.Add(this.panel1);
            this.groupBoxLog.Controls.Add(this.progressBarProgress);
            this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLog.Location = new System.Drawing.Point(0, 69);
            this.groupBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLog.Size = new System.Drawing.Size(535, 203);
            this.groupBoxLog.TabIndex = 2;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Отчет";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 15;
            this.listBoxLog.Location = new System.Drawing.Point(2, 66);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(531, 135);
            this.listBoxLog.TabIndex = 1;
            this.listBoxLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxLog_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPercent);
            this.panel1.Controls.Add(this.textBoxSpeed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxRemainTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxTotalTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 32);
            this.panel1.TabIndex = 2;
            // 
            // labelPercent
            // 
            this.labelPercent.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPercent.Location = new System.Drawing.Point(483, 0);
            this.labelPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(48, 32);
            this.labelPercent.TabIndex = 6;
            this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpeed.Enabled = false;
            this.textBoxSpeed.Location = new System.Drawing.Point(389, 6);
            this.textBoxSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(74, 20);
            this.textBoxSpeed.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Скорость :";
            // 
            // textBoxRemainTime
            // 
            this.textBoxRemainTime.Enabled = false;
            this.textBoxRemainTime.Location = new System.Drawing.Point(238, 6);
            this.textBoxRemainTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRemainTime.Name = "textBoxRemainTime";
            this.textBoxRemainTime.ReadOnly = true;
            this.textBoxRemainTime.Size = new System.Drawing.Size(76, 20);
            this.textBoxRemainTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Осталось :";
            // 
            // textBoxTotalTime
            // 
            this.textBoxTotalTime.Enabled = false;
            this.textBoxTotalTime.Location = new System.Drawing.Point(85, 6);
            this.textBoxTotalTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTotalTime.Name = "textBoxTotalTime";
            this.textBoxTotalTime.ReadOnly = true;
            this.textBoxTotalTime.Size = new System.Drawing.Size(77, 20);
            this.textBoxTotalTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общее время :";
            // 
            // progressBarProgress
            // 
            this.progressBarProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarProgress.Location = new System.Drawing.Point(2, 15);
            this.progressBarProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarProgress.Name = "progressBarProgress";
            this.progressBarProgress.Size = new System.Drawing.Size(531, 19);
            this.progressBarProgress.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationToolStripMenuItem,
            this.опцииToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(535, 27);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConfigurationToolStripMenuItem
            // 
            this.ConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewConf,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem";
            this.ConfigurationToolStripMenuItem.Size = new System.Drawing.Size(113, 23);
            this.ConfigurationToolStripMenuItem.Text = "Конфигурация";
            // 
            // ToolStripMenuItemNewConf
            // 
            this.ToolStripMenuItemNewConf.Name = "ToolStripMenuItemNewConf";
            this.ToolStripMenuItemNewConf.Size = new System.Drawing.Size(170, 24);
            this.ToolStripMenuItemNewConf.Text = "Новая";
            this.ToolStripMenuItemNewConf.Click += new System.EventHandler(this.ToolStripMenuItemNewConf_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.открытьToolStripMenuItem.Text = "Загрузить";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // опцииToolStripMenuItem
            // 
            this.опцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instantaneousSpeedToolStripMenuItem,
            this.toolStripMenuItem2,
            this.AdditionalSettingsToolStripMenuItem});
            this.опцииToolStripMenuItem.Name = "опцииToolStripMenuItem";
            this.опцииToolStripMenuItem.Size = new System.Drawing.Size(64, 23);
            this.опцииToolStripMenuItem.Text = "Опции";
            // 
            // instantaneousSpeedToolStripMenuItem
            // 
            this.instantaneousSpeedToolStripMenuItem.Name = "instantaneousSpeedToolStripMenuItem";
            this.instantaneousSpeedToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.instantaneousSpeedToolStripMenuItem.Text = "Мгновенная скорость";
            this.instantaneousSpeedToolStripMenuItem.ToolTipText = "Скорость за последнюю секунду";
            this.instantaneousSpeedToolStripMenuItem.Click += new System.EventHandler(this.instantaneousSpeedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // AdditionalSettingsToolStripMenuItem
            // 
            this.AdditionalSettingsToolStripMenuItem.Name = "AdditionalSettingsToolStripMenuItem";
            this.AdditionalSettingsToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.AdditionalSettingsToolStripMenuItem.Text = "Дополнительно";
            this.AdditionalSettingsToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSettingsToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(74, 23);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(164, 24);
            this.ToolStripMenuItemAbout.Text = "О программе";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // progressBarBuffer
            // 
            this.progressBarBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarBuffer.Location = new System.Drawing.Point(360, 9);
            this.progressBarBuffer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarBuffer.Name = "progressBarBuffer";
            this.progressBarBuffer.Size = new System.Drawing.Size(173, 8);
            this.progressBarBuffer.TabIndex = 4;
            this.toolTip1.SetToolTip(this.progressBarBuffer, "Заполнение буффера");
            this.progressBarBuffer.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCurrFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 586);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(535, 23);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.SizeChanged += new System.EventHandler(this.statusStrip1_SizeChanged);
            // 
            // toolStripStatusLabelCurrFile
            // 
            this.toolStripStatusLabelCurrFile.AutoSize = false;
            this.toolStripStatusLabelCurrFile.Name = "toolStripStatusLabelCurrFile";
            this.toolStripStatusLabelCurrFile.Size = new System.Drawing.Size(700, 18);
            this.toolStripStatusLabelCurrFile.Text = "sssssddssssssssssssssssssssssssssdddddddddddddddddddddddddssssddddddddddddddddddd" +
    "ddddddddddddd";
            this.toolStripStatusLabelCurrFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelCurrFile.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // dataGridViewProgressColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewProgressColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProgressColumn1.HeaderText = "Прогресс";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.ReadOnly = true;
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewProgressColumn1.Width = 94;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxLog);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxAction);
            this.splitContainer1.Size = new System.Drawing.Size(535, 559);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 609);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBarBuffer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Синхронизация и копирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.tabControlTask.ResumeLayout(false);
            this.tabPageSimple.ResumeLayout(false);
            this.tabPageTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.contextMenuStripSequence.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxLog.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem опцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instantaneousSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem AdditionalSettingsToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBarBuffer;
        private System.Windows.Forms.CheckBox checkBoxPause;
        private System.Windows.Forms.TabControl tabControlTask;
        private System.Windows.Forms.TabPage tabPageSimple;
        private System.Windows.Forms.TabPage tabPageTasks;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonEditTask;
        private System.Windows.Forms.Button buttonDeleteTask;
        private System.Windows.Forms.Button buttonTaskDown;
        private System.Windows.Forms.Button buttonTaskUp;
        private System.Windows.Forms.Button buttonAddNewTaskFromQuick;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonResetTasks;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStartCurrentTask;
        private System.Windows.Forms.Button buttonRestartTasks;
        private System.Windows.Forms.Button buttonCompleteTask;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurrFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSource;
        private DataGridViewProgressColumn ColumnProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDestination;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnSyncType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeleteIgnored;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceArchive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDestinationArchive;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNewConf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxTotalTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRemainTime;
        private System.Windows.Forms.Label label2;
        private InternalProgressBar progressBarProgress;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPercent;
        private TaskControl taskControlBasic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSequence;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDown;
    }
}

