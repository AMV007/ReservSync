namespace RezervSync
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownCRCchecksec = new System.Windows.Forms.NumericUpDown();
            this.checkBoxUseCRCIfSlowTimeDifference = new System.Windows.Forms.CheckBox();
            this.numericUpDownTimeDifferenseSec = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxIgnoreTimeZone = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreSummerWinterTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSelectDeletedFilesPath = new System.Windows.Forms.Button();
            this.textBoxDeletedFilesPath = new System.Windows.Forms.TextBox();
            this.checkBoxSaveDeletedFiles = new System.Windows.Forms.CheckBox();
            this.buttonSelectReplacedFilesPath = new System.Windows.Forms.Button();
            this.textBoxReplaceFilesPath = new System.Windows.Forms.TextBox();
            this.checkBoxSaveReplacedFiles = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxShowFileOperations = new System.Windows.Forms.CheckBox();
            this.checkBoxWriteFileOperations = new System.Windows.Forms.CheckBox();
            this.checkBoxUseDifferentConfigurations = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDuplicateBlockSize = new System.Windows.Forms.NumericUpDown();
            this.listBoxIgnoredDuplicateWords = new System.Windows.Forms.ListBox();
            this.checkBoxCalcOverallSize = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveIgnoredSystemDir = new System.Windows.Forms.Button();
            this.buttonAddIgnoredSystemDir = new System.Windows.Forms.Button();
            this.listBoxIgnoredSystemDirs = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteIgnoredDuplicateWords = new System.Windows.Forms.Button();
            this.buttonAddIgnoredDublicateWords = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelHelp = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCRCchecksec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeDifferenseSec)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuplicateBlockSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBufferSize)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownCRCchecksec);
            this.groupBox1.Controls.Add(this.checkBoxUseCRCIfSlowTimeDifference);
            this.groupBox1.Controls.Add(this.numericUpDownTimeDifferenseSec);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxIgnoreTimeZone);
            this.groupBox1.Controls.Add(this.checkBoxIgnoreSummerWinterTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время файлов";
            // 
            // numericUpDownCRCchecksec
            // 
            this.numericUpDownCRCchecksec.Enabled = false;
            this.numericUpDownCRCchecksec.Location = new System.Drawing.Point(492, 144);
            this.numericUpDownCRCchecksec.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCRCchecksec.Name = "numericUpDownCRCchecksec";
            this.numericUpDownCRCchecksec.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownCRCchecksec.TabIndex = 5;
            this.toolTip1.SetToolTip(this.numericUpDownCRCchecksec, "Если 0, то делается при любой разнице во времени");
            // 
            // checkBoxUseCRCIfSlowTimeDifference
            // 
            this.checkBoxUseCRCIfSlowTimeDifference.Location = new System.Drawing.Point(7, 128);
            this.checkBoxUseCRCIfSlowTimeDifference.Name = "checkBoxUseCRCIfSlowTimeDifference";
            this.checkBoxUseCRCIfSlowTimeDifference.Size = new System.Drawing.Size(476, 55);
            this.checkBoxUseCRCIfSlowTimeDifference.TabIndex = 4;
            this.checkBoxUseCRCIfSlowTimeDifference.Text = "Делать проверку CRC, если размеры файлов одинаковые и разница времени файлов мень" +
                "ше, сек.";
            this.toolTip1.SetToolTip(this.checkBoxUseCRCIfSlowTimeDifference, "Актуально если Source и destination имеют разные файловые системы - типа FAT и NT" +
                    "FS, так как присутствует округление времени");
            this.checkBoxUseCRCIfSlowTimeDifference.UseVisualStyleBackColor = true;
            this.checkBoxUseCRCIfSlowTimeDifference.CheckedChanged += new System.EventHandler(this.checkBoxUseCRCIfSlowTimeDifference_CheckedChanged);
            // 
            // numericUpDownTimeDifferenseSec
            // 
            this.numericUpDownTimeDifferenseSec.Location = new System.Drawing.Point(492, 78);
            this.numericUpDownTimeDifferenseSec.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownTimeDifferenseSec.Name = "numericUpDownTimeDifferenseSec";
            this.numericUpDownTimeDifferenseSec.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownTimeDifferenseSec.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownTimeDifferenseSec, "Актуально если Source и destination имеют разные файловые системы - типа FAT и NT" +
                    "FS, так как присутствует округление времени");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Игнорировать разницу времени файлов, если размеры файлов одинаковые и разница не " +
                "более, сек";
            this.toolTip1.SetToolTip(this.label1, "Актуально если Source и destination имеют разные файловые системы - типа FAT и NT" +
                    "FS, так как присутствует округление времени");
            // 
            // checkBoxIgnoreTimeZone
            // 
            this.checkBoxIgnoreTimeZone.AutoSize = true;
            this.checkBoxIgnoreTimeZone.Location = new System.Drawing.Point(7, 50);
            this.checkBoxIgnoreTimeZone.Name = "checkBoxIgnoreTimeZone";
            this.checkBoxIgnoreTimeZone.Size = new System.Drawing.Size(354, 21);
            this.checkBoxIgnoreTimeZone.TabIndex = 1;
            this.checkBoxIgnoreTimeZone.Text = "Игнорировать переход между часовыми поясами";
            this.checkBoxIgnoreTimeZone.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreSummerWinterTime
            // 
            this.checkBoxIgnoreSummerWinterTime.AutoSize = true;
            this.checkBoxIgnoreSummerWinterTime.Location = new System.Drawing.Point(7, 22);
            this.checkBoxIgnoreSummerWinterTime.Name = "checkBoxIgnoreSummerWinterTime";
            this.checkBoxIgnoreSummerWinterTime.Size = new System.Drawing.Size(336, 21);
            this.checkBoxIgnoreSummerWinterTime.TabIndex = 0;
            this.checkBoxIgnoreSummerWinterTime.Text = "Игнорировать переход летнее - зимнее время";
            this.checkBoxIgnoreSummerWinterTime.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSelectDeletedFilesPath);
            this.groupBox2.Controls.Add(this.textBoxDeletedFilesPath);
            this.groupBox2.Controls.Add(this.checkBoxSaveDeletedFiles);
            this.groupBox2.Controls.Add(this.buttonSelectReplacedFilesPath);
            this.groupBox2.Controls.Add(this.textBoxReplaceFilesPath);
            this.groupBox2.Controls.Add(this.checkBoxSaveReplacedFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 190);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Файлы";
            // 
            // buttonSelectDeletedFilesPath
            // 
            this.buttonSelectDeletedFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDeletedFilesPath.Enabled = false;
            this.buttonSelectDeletedFilesPath.Location = new System.Drawing.Point(533, 103);
            this.buttonSelectDeletedFilesPath.Name = "buttonSelectDeletedFilesPath";
            this.buttonSelectDeletedFilesPath.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectDeletedFilesPath.TabIndex = 9;
            this.buttonSelectDeletedFilesPath.Text = "Select";
            this.buttonSelectDeletedFilesPath.UseVisualStyleBackColor = true;
            this.buttonSelectDeletedFilesPath.Click += new System.EventHandler(this.buttonSelectSaveDeletedFilesPath_Click);
            // 
            // textBoxDeletedFilesPath
            // 
            this.textBoxDeletedFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeletedFilesPath.Enabled = false;
            this.textBoxDeletedFilesPath.Location = new System.Drawing.Point(6, 104);
            this.textBoxDeletedFilesPath.Name = "textBoxDeletedFilesPath";
            this.textBoxDeletedFilesPath.Size = new System.Drawing.Size(521, 22);
            this.textBoxDeletedFilesPath.TabIndex = 8;
            // 
            // checkBoxSaveDeletedFiles
            // 
            this.checkBoxSaveDeletedFiles.AutoSize = true;
            this.checkBoxSaveDeletedFiles.Location = new System.Drawing.Point(6, 77);
            this.checkBoxSaveDeletedFiles.Name = "checkBoxSaveDeletedFiles";
            this.checkBoxSaveDeletedFiles.Size = new System.Drawing.Size(442, 21);
            this.checkBoxSaveDeletedFiles.TabIndex = 7;
            this.checkBoxSaveDeletedFiles.Text = "Сохранять удаляемые файлы, для дальнейшего их просмотра";
            this.checkBoxSaveDeletedFiles.UseVisualStyleBackColor = true;
            this.checkBoxSaveDeletedFiles.CheckedChanged += new System.EventHandler(this.checkBoxSaveDeletedFilesPath_CheckedChanged);
            // 
            // buttonSelectReplacedFilesPath
            // 
            this.buttonSelectReplacedFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectReplacedFilesPath.Enabled = false;
            this.buttonSelectReplacedFilesPath.Location = new System.Drawing.Point(534, 48);
            this.buttonSelectReplacedFilesPath.Name = "buttonSelectReplacedFilesPath";
            this.buttonSelectReplacedFilesPath.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectReplacedFilesPath.TabIndex = 6;
            this.buttonSelectReplacedFilesPath.Text = "Select";
            this.buttonSelectReplacedFilesPath.UseVisualStyleBackColor = true;
            this.buttonSelectReplacedFilesPath.Click += new System.EventHandler(this.buttonSelectReplacedFilesPath_Click);
            // 
            // textBoxReplaceFilesPath
            // 
            this.textBoxReplaceFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReplaceFilesPath.Enabled = false;
            this.textBoxReplaceFilesPath.Location = new System.Drawing.Point(6, 49);
            this.textBoxReplaceFilesPath.Name = "textBoxReplaceFilesPath";
            this.textBoxReplaceFilesPath.Size = new System.Drawing.Size(522, 22);
            this.textBoxReplaceFilesPath.TabIndex = 5;
            // 
            // checkBoxSaveReplacedFiles
            // 
            this.checkBoxSaveReplacedFiles.AutoSize = true;
            this.checkBoxSaveReplacedFiles.Location = new System.Drawing.Point(6, 22);
            this.checkBoxSaveReplacedFiles.Name = "checkBoxSaveReplacedFiles";
            this.checkBoxSaveReplacedFiles.Size = new System.Drawing.Size(451, 21);
            this.checkBoxSaveReplacedFiles.TabIndex = 0;
            this.checkBoxSaveReplacedFiles.Text = "Сохранять заменяемые файлы, для дальнейшего их просмотра";
            this.checkBoxSaveReplacedFiles.UseVisualStyleBackColor = true;
            this.checkBoxSaveReplacedFiles.CheckedChanged += new System.EventHandler(this.checkBoxSaveReplacedFiles_CheckedChanged);
            // 
            // checkBoxShowFileOperations
            // 
            this.checkBoxShowFileOperations.AutoSize = true;
            this.checkBoxShowFileOperations.Location = new System.Drawing.Point(6, 21);
            this.checkBoxShowFileOperations.Name = "checkBoxShowFileOperations";
            this.checkBoxShowFileOperations.Size = new System.Drawing.Size(418, 21);
            this.checkBoxShowFileOperations.TabIndex = 1;
            this.checkBoxShowFileOperations.Text = "Отображать операции с файлами (удаление, добавление)";
            this.toolTip1.SetToolTip(this.checkBoxShowFileOperations, "Визуально");
            this.checkBoxShowFileOperations.UseVisualStyleBackColor = true;
            // 
            // checkBoxWriteFileOperations
            // 
            this.checkBoxWriteFileOperations.AutoSize = true;
            this.checkBoxWriteFileOperations.Location = new System.Drawing.Point(6, 46);
            this.checkBoxWriteFileOperations.Name = "checkBoxWriteFileOperations";
            this.checkBoxWriteFileOperations.Size = new System.Drawing.Size(342, 21);
            this.checkBoxWriteFileOperations.TabIndex = 2;
            this.checkBoxWriteFileOperations.Text = "Записывать операции с файлами в лог на диск";
            this.toolTip1.SetToolTip(this.checkBoxWriteFileOperations, "В файл лога");
            this.checkBoxWriteFileOperations.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseDifferentConfigurations
            // 
            this.checkBoxUseDifferentConfigurations.AutoSize = true;
            this.checkBoxUseDifferentConfigurations.Location = new System.Drawing.Point(3, 52);
            this.checkBoxUseDifferentConfigurations.Name = "checkBoxUseDifferentConfigurations";
            this.checkBoxUseDifferentConfigurations.Size = new System.Drawing.Size(467, 21);
            this.checkBoxUseDifferentConfigurations.TabIndex = 3;
            this.checkBoxUseDifferentConfigurations.Text = "Использовать различные конфигурации для разных компьютеров";
            this.toolTip1.SetToolTip(this.checkBoxUseDifferentConfigurations, "Конфигурация будет автоматом сохраняться для каждого компьютера,  удобно при испо" +
                    "льзовании флешки на нескольких компьютерах, запуск программы немножко затормозит" +
                    "ься");
            this.checkBoxUseDifferentConfigurations.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Максимальный размер считываемых и сравниваемых блоков, байт";
            this.toolTip1.SetToolTip(this.label3, "Если файлы большие, то чем этот размер больше, тем быстрее идет сравнивание");
            // 
            // numericUpDownDuplicateBlockSize
            // 
            this.numericUpDownDuplicateBlockSize.Enabled = false;
            this.numericUpDownDuplicateBlockSize.Location = new System.Drawing.Point(492, 22);
            this.numericUpDownDuplicateBlockSize.Maximum = new decimal(new int[] {
            33554432,
            0,
            0,
            0});
            this.numericUpDownDuplicateBlockSize.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDownDuplicateBlockSize.Name = "numericUpDownDuplicateBlockSize";
            this.numericUpDownDuplicateBlockSize.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownDuplicateBlockSize.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numericUpDownDuplicateBlockSize, "Если файлы большие, то чем этот размер больше, тем быстрее идет сравнивание");
            this.numericUpDownDuplicateBlockSize.Value = new decimal(new int[] {
            102400,
            0,
            0,
            0});
            // 
            // listBoxIgnoredDuplicateWords
            // 
            this.listBoxIgnoredDuplicateWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIgnoredDuplicateWords.FormattingEnabled = true;
            this.listBoxIgnoredDuplicateWords.ItemHeight = 16;
            this.listBoxIgnoredDuplicateWords.Location = new System.Drawing.Point(6, 22);
            this.listBoxIgnoredDuplicateWords.Name = "listBoxIgnoredDuplicateWords";
            this.listBoxIgnoredDuplicateWords.Size = new System.Drawing.Size(502, 116);
            this.listBoxIgnoredDuplicateWords.TabIndex = 3;
            this.toolTip1.SetToolTip(this.listBoxIgnoredDuplicateWords, "чувствительно к регистру");
            // 
            // checkBoxCalcOverallSize
            // 
            this.checkBoxCalcOverallSize.AutoSize = true;
            this.checkBoxCalcOverallSize.Location = new System.Drawing.Point(3, 25);
            this.checkBoxCalcOverallSize.Name = "checkBoxCalcOverallSize";
            this.checkBoxCalcOverallSize.Size = new System.Drawing.Size(420, 21);
            this.checkBoxCalcOverallSize.TabIndex = 5;
            this.checkBoxCalcOverallSize.Text = "Подсчитывать перед выполнением задачи размер файлов";
            this.toolTip1.SetToolTip(this.checkBoxCalcOverallSize, "Для отображения прогресса выполнения, но занимает некоторое время");
            this.checkBoxCalcOverallSize.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownBufferSize);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(3, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(615, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Буфферизация при копировании";
            // 
            // numericUpDownBufferSize
            // 
            this.numericUpDownBufferSize.Location = new System.Drawing.Point(182, 20);
            this.numericUpDownBufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBufferSize.Name = "numericUpDownBufferSize";
            this.numericUpDownBufferSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownBufferSize.TabIndex = 1;
            this.numericUpDownBufferSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Размер буффера, Мб";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxWriteFileOperations);
            this.groupBox4.Controls.Add(this.checkBoxShowFileOperations);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(621, 73);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Лог";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxCalcOverallSize);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.checkBoxUseDifferentConfigurations);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(621, 269);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дополнительно";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.buttonRemoveIgnoredSystemDir);
            this.groupBox6.Controls.Add(this.buttonAddIgnoredSystemDir);
            this.groupBox6.Controls.Add(this.listBoxIgnoredSystemDirs);
            this.groupBox6.Location = new System.Drawing.Point(3, 79);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(615, 132);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Игноруруемые системные директории";
            // 
            // buttonRemoveIgnoredSystemDir
            // 
            this.buttonRemoveIgnoredSystemDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveIgnoredSystemDir.Location = new System.Drawing.Point(508, 51);
            this.buttonRemoveIgnoredSystemDir.Name = "buttonRemoveIgnoredSystemDir";
            this.buttonRemoveIgnoredSystemDir.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveIgnoredSystemDir.TabIndex = 2;
            this.buttonRemoveIgnoredSystemDir.Text = "Удалить";
            this.buttonRemoveIgnoredSystemDir.UseVisualStyleBackColor = true;
            this.buttonRemoveIgnoredSystemDir.Click += new System.EventHandler(this.buttonRemoveIgnoredSystemDir_Click);
            // 
            // buttonAddIgnoredSystemDir
            // 
            this.buttonAddIgnoredSystemDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddIgnoredSystemDir.Location = new System.Drawing.Point(508, 22);
            this.buttonAddIgnoredSystemDir.Name = "buttonAddIgnoredSystemDir";
            this.buttonAddIgnoredSystemDir.Size = new System.Drawing.Size(101, 23);
            this.buttonAddIgnoredSystemDir.TabIndex = 1;
            this.buttonAddIgnoredSystemDir.Text = "Добавить";
            this.buttonAddIgnoredSystemDir.UseVisualStyleBackColor = true;
            this.buttonAddIgnoredSystemDir.Click += new System.EventHandler(this.buttonAddIgnoredSystemDir_Click);
            // 
            // listBoxIgnoredSystemDirs
            // 
            this.listBoxIgnoredSystemDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIgnoredSystemDirs.FormattingEnabled = true;
            this.listBoxIgnoredSystemDirs.IntegralHeight = false;
            this.listBoxIgnoredSystemDirs.ItemHeight = 16;
            this.listBoxIgnoredSystemDirs.Location = new System.Drawing.Point(7, 22);
            this.listBoxIgnoredSystemDirs.Name = "listBoxIgnoredSystemDirs";
            this.listBoxIgnoredSystemDirs.Size = new System.Drawing.Size(495, 97);
            this.listBoxIgnoredSystemDirs.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 494);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.numericUpDownDuplicateBlockSize);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 186);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(621, 203);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Удаление дубликатов файлов";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.buttonDeleteIgnoredDuplicateWords);
            this.groupBox8.Controls.Add(this.buttonAddIgnoredDublicateWords);
            this.groupBox8.Controls.Add(this.listBoxIgnoredDuplicateWords);
            this.groupBox8.Location = new System.Drawing.Point(3, 50);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(612, 147);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Слова исключения, файлы содержащие эти слова не удаляются";
            // 
            // buttonDeleteIgnoredDuplicateWords
            // 
            this.buttonDeleteIgnoredDuplicateWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteIgnoredDuplicateWords.Location = new System.Drawing.Point(514, 51);
            this.buttonDeleteIgnoredDuplicateWords.Name = "buttonDeleteIgnoredDuplicateWords";
            this.buttonDeleteIgnoredDuplicateWords.Size = new System.Drawing.Size(92, 23);
            this.buttonDeleteIgnoredDuplicateWords.TabIndex = 5;
            this.buttonDeleteIgnoredDuplicateWords.Text = "Удалить";
            this.buttonDeleteIgnoredDuplicateWords.UseVisualStyleBackColor = true;
            this.buttonDeleteIgnoredDuplicateWords.Click += new System.EventHandler(this.buttonDeleteIgnoredDuplicateWords_Click);
            // 
            // buttonAddIgnoredDublicateWords
            // 
            this.buttonAddIgnoredDublicateWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddIgnoredDublicateWords.Location = new System.Drawing.Point(514, 22);
            this.buttonAddIgnoredDublicateWords.Name = "buttonAddIgnoredDublicateWords";
            this.buttonAddIgnoredDublicateWords.Size = new System.Drawing.Size(92, 23);
            this.buttonAddIgnoredDublicateWords.TabIndex = 4;
            this.buttonAddIgnoredDublicateWords.Text = "Добавить";
            this.buttonAddIgnoredDublicateWords.UseVisualStyleBackColor = true;
            this.buttonAddIgnoredDublicateWords.Click += new System.EventHandler(this.buttonAddIgnoredDublicateWords_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(627, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Дополнительные настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelHelp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 23);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelHelp
            // 
            this.toolStripStatusLabelHelp.AutoSize = false;
            this.toolStripStatusLabelHelp.Name = "toolStripStatusLabelHelp";
            this.toolStripStatusLabelHelp.Size = new System.Drawing.Size(620, 18);
            this.toolStripStatusLabelHelp.Spring = true;
            this.toolStripStatusLabelHelp.Text = "Описание";
            this.toolStripStatusLabelHelp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 517);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCRCchecksec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeDifferenseSec)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuplicateBlockSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBufferSize)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxIgnoreTimeZone;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSummerWinterTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeDifferenseSec;
        private System.Windows.Forms.CheckBox checkBoxUseCRCIfSlowTimeDifference;
        private System.Windows.Forms.NumericUpDown numericUpDownCRCchecksec;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxSaveReplacedFiles;
        private System.Windows.Forms.Button buttonSelectReplacedFilesPath;
        private System.Windows.Forms.TextBox textBoxReplaceFilesPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSelectDeletedFilesPath;
        private System.Windows.Forms.TextBox textBoxDeletedFilesPath;
        private System.Windows.Forms.CheckBox checkBoxSaveDeletedFiles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownBufferSize;
        private System.Windows.Forms.CheckBox checkBoxUseDifferentConfigurations;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxWriteFileOperations;
        private System.Windows.Forms.CheckBox checkBoxShowFileOperations;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox listBoxIgnoredSystemDirs;
        private System.Windows.Forms.Button buttonRemoveIgnoredSystemDir;
        private System.Windows.Forms.Button buttonAddIgnoredSystemDir;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDuplicateBlockSize;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonDeleteIgnoredDuplicateWords;
        private System.Windows.Forms.Button buttonAddIgnoredDublicateWords;
        private System.Windows.Forms.ListBox listBoxIgnoredDuplicateWords;
        private System.Windows.Forms.CheckBox checkBoxCalcOverallSize;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHelp;
    }
}