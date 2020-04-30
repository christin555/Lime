namespace Lime
{
    partial class Directory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Directory));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отделыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewDirectory = new System.Windows.Forms.DataGridView();
            this.button_add = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.nameTable = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel_add_worker = new System.Windows.Forms.Panel();
            this.middleName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.departmentId = new System.Windows.Forms.ComboBox();
            this.positionId = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.seriesPassport = new System.Windows.Forms.TextBox();
            this.numberPassport = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.byWhomPassport = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.registrationAddress = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.limeDataSet = new Lime.limeDataSet();
            this.limeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentsTableAdapter = new Lime.limeDataSetTableAdapters.departmentsTableAdapter();
            this.positionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.positionsTableAdapter = new Lime.limeDataSetTableAdapters.positionsTableAdapter();
            this.whenPassport = new System.Windows.Forms.DateTimePicker();
            this.dateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectory)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel_add_worker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справочникToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1721, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem,
            this.другоеToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // другоеToolStripMenuItem
            // 
            this.другоеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отделыToolStripMenuItem,
            this.должностиToolStripMenuItem});
            this.другоеToolStripMenuItem.Name = "другоеToolStripMenuItem";
            this.другоеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.другоеToolStripMenuItem.Text = "Другое";
            // 
            // отделыToolStripMenuItem
            // 
            this.отделыToolStripMenuItem.Name = "отделыToolStripMenuItem";
            this.отделыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.отделыToolStripMenuItem.Text = "Отделы";
            this.отделыToolStripMenuItem.Click += new System.EventHandler(this.отделыToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.должностиToolStripMenuItem_Click);
            // 
            // dataGridViewDirectory
            // 
            this.dataGridViewDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDirectory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewDirectory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDirectory.Location = new System.Drawing.Point(38, 120);
            this.dataGridViewDirectory.Margin = new System.Windows.Forms.Padding(30, 3, 0, 3);
            this.dataGridViewDirectory.Name = "dataGridViewDirectory";
            this.dataGridViewDirectory.RowHeadersVisible = false;
            this.dataGridViewDirectory.RowHeadersWidth = 51;
            this.dataGridViewDirectory.RowTemplate.Height = 24;
            this.dataGridViewDirectory.ShowCellErrors = false;
            this.dataGridViewDirectory.ShowCellToolTips = false;
            this.dataGridViewDirectory.ShowEditingIcon = false;
            this.dataGridViewDirectory.ShowRowErrors = false;
            this.dataGridViewDirectory.Size = new System.Drawing.Size(1410, 845);
            this.dataGridViewDirectory.TabIndex = 2;
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(1497, 120);
            this.button_add.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(185, 33);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_edit
            // 
            this.button_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_edit.Location = new System.Drawing.Point(1497, 168);
            this.button_edit.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(185, 33);
            this.button_edit.TabIndex = 4;
            this.button_edit.Text = "Редактировать";
            this.button_edit.UseVisualStyleBackColor = true;
            // 
            // button_delete
            // 
            this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_delete.Location = new System.Drawing.Point(1497, 257);
            this.button_delete.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(185, 33);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Удалить";
            this.button_delete.UseVisualStyleBackColor = true;
            // 
            // nameTable
            // 
            this.nameTable.AutoSize = true;
            this.nameTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTable.Location = new System.Drawing.Point(34, 83);
            this.nameTable.Name = "nameTable";
            this.nameTable.Size = new System.Drawing.Size(204, 20);
            this.nameTable.TabIndex = 7;
            this.nameTable.Text = "Название справочника";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(1721, 37);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(32, 0, 1, 0);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(250, 27);
            this.toolStripTextBox1.Text = "Поиск";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.toolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton2.Size = new System.Drawing.Size(124, 24);
            this.toolStripButton2.Text = "Фильтр";
            // 
            // panel_add_worker
            // 
            this.panel_add_worker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_add_worker.AutoScroll = true;
            this.panel_add_worker.AutoSize = true;
            this.panel_add_worker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_add_worker.Controls.Add(this.label14);
            this.panel_add_worker.Controls.Add(this.dateOfBirth);
            this.panel_add_worker.Controls.Add(this.whenPassport);
            this.panel_add_worker.Controls.Add(this.registrationAddress);
            this.panel_add_worker.Controls.Add(this.label12);
            this.panel_add_worker.Controls.Add(this.label11);
            this.panel_add_worker.Controls.Add(this.label10);
            this.panel_add_worker.Controls.Add(this.byWhomPassport);
            this.panel_add_worker.Controls.Add(this.label9);
            this.panel_add_worker.Controls.Add(this.label8);
            this.panel_add_worker.Controls.Add(this.numberPassport);
            this.panel_add_worker.Controls.Add(this.seriesPassport);
            this.panel_add_worker.Controls.Add(this.label7);
            this.panel_add_worker.Controls.Add(this.label6);
            this.panel_add_worker.Controls.Add(this.positionId);
            this.panel_add_worker.Controls.Add(this.departmentId);
            this.panel_add_worker.Controls.Add(this.email);
            this.panel_add_worker.Controls.Add(this.label5);
            this.panel_add_worker.Controls.Add(this.label4);
            this.panel_add_worker.Controls.Add(this.phone);
            this.panel_add_worker.Controls.Add(this.label3);
            this.panel_add_worker.Controls.Add(this.label2);
            this.panel_add_worker.Controls.Add(this.label1);
            this.panel_add_worker.Controls.Add(this.lastName);
            this.panel_add_worker.Controls.Add(this.middleName);
            this.panel_add_worker.Controls.Add(this.firstName);
            this.panel_add_worker.Location = new System.Drawing.Point(38, 120);
            this.panel_add_worker.Margin = new System.Windows.Forms.Padding(30, 3, 0, 3);
            this.panel_add_worker.Name = "panel_add_worker";
            this.panel_add_worker.Size = new System.Drawing.Size(1410, 845);
            this.panel_add_worker.TabIndex = 9;
            this.panel_add_worker.Visible = false;
            // 
            // middleName
            // 
            this.middleName.Location = new System.Drawing.Point(28, 41);
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(349, 22);
            this.middleName.TabIndex = 0;
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(494, 41);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(349, 22);
            this.firstName.TabIndex = 1;
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(940, 41);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(349, 22);
            this.lastName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(939, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отчество";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(494, 96);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(349, 22);
            this.phone.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Номер телефона";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(940, 96);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(349, 22);
            this.email.TabIndex = 9;
            // 
            // departmentId
            // 
            this.departmentId.DataSource = this.departmentsBindingSource;
            this.departmentId.DisplayMember = "name";
            this.departmentId.FormattingEnabled = true;
            this.departmentId.Location = new System.Drawing.Point(29, 171);
            this.departmentId.Name = "departmentId";
            this.departmentId.Size = new System.Drawing.Size(349, 24);
            this.departmentId.TabIndex = 10;
            this.departmentId.ValueMember = "id";
            // 
            // positionId
            // 
            this.positionId.DataSource = this.positionsBindingSource;
            this.positionId.DisplayMember = "name";
            this.positionId.FormattingEnabled = true;
            this.positionId.Location = new System.Drawing.Point(495, 171);
            this.positionId.Name = "positionId";
            this.positionId.Size = new System.Drawing.Size(349, 24);
            this.positionId.TabIndex = 11;
            this.positionId.ValueMember = "id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Отдел";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Должность";
            // 
            // seriesPassport
            // 
            this.seriesPassport.Location = new System.Drawing.Point(29, 248);
            this.seriesPassport.Name = "seriesPassport";
            this.seriesPassport.Size = new System.Drawing.Size(168, 22);
            this.seriesPassport.TabIndex = 14;
            // 
            // numberPassport
            // 
            this.numberPassport.Location = new System.Drawing.Point(210, 248);
            this.numberPassport.Name = "numberPassport";
            this.numberPassport.Size = new System.Drawing.Size(168, 22);
            this.numberPassport.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Серия";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Номер";
            // 
            // byWhomPassport
            // 
            this.byWhomPassport.Location = new System.Drawing.Point(29, 325);
            this.byWhomPassport.Multiline = true;
            this.byWhomPassport.Name = "byWhomPassport";
            this.byWhomPassport.Size = new System.Drawing.Size(815, 136);
            this.byWhomPassport.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(492, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Дата выдачи";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Кем выдан";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 488);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Адрес регистрации";
            // 
            // registrationAddress
            // 
            this.registrationAddress.Location = new System.Drawing.Point(30, 508);
            this.registrationAddress.Multiline = true;
            this.registrationAddress.Name = "registrationAddress";
            this.registrationAddress.Size = new System.Drawing.Size(815, 136);
            this.registrationAddress.TabIndex = 23;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(1497, 212);
            this.button_save.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(185, 33);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Cохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Visible = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // limeDataSet
            // 
            this.limeDataSet.DataSetName = "limeDataSet";
            this.limeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // limeDataSetBindingSource
            // 
            this.limeDataSetBindingSource.DataSource = this.limeDataSet;
            this.limeDataSetBindingSource.Position = 0;
            // 
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataMember = "departments";
            this.departmentsBindingSource.DataSource = this.limeDataSetBindingSource;
            // 
            // departmentsTableAdapter
            // 
            this.departmentsTableAdapter.ClearBeforeFill = true;
            // 
            // positionsBindingSource
            // 
            this.positionsBindingSource.DataMember = "positions";
            this.positionsBindingSource.DataSource = this.limeDataSetBindingSource;
            // 
            // positionsTableAdapter
            // 
            this.positionsTableAdapter.ClearBeforeFill = true;
            // 
            // whenPassport
            // 
            this.whenPassport.Location = new System.Drawing.Point(495, 246);
            this.whenPassport.Name = "whenPassport";
            this.whenPassport.Size = new System.Drawing.Size(348, 22);
            this.whenPassport.TabIndex = 25;
            // 
            // dateOfBirth
            // 
            this.dateOfBirth.Location = new System.Drawing.Point(29, 94);
            this.dateOfBirth.Name = "dateOfBirth";
            this.dateOfBirth.Size = new System.Drawing.Size(349, 22);
            this.dateOfBirth.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(939, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "email";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Дата рождения";
            // 
            // Directory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1721, 999);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.panel_add_worker);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.nameTable);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.dataGridViewDirectory);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Directory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Directory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectory)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_add_worker.ResumeLayout(false);
            this.panel_add_worker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отделыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewDirectory;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label nameTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel_add_worker;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox registrationAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox byWhomPassport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numberPassport;
        private System.Windows.Forms.TextBox seriesPassport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox positionId;
        private System.Windows.Forms.ComboBox departmentId;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.BindingSource limeDataSetBindingSource;
        private limeDataSet limeDataSet;
        private System.Windows.Forms.BindingSource departmentsBindingSource;
        private limeDataSetTableAdapters.departmentsTableAdapter departmentsTableAdapter;
        private System.Windows.Forms.BindingSource positionsBindingSource;
        private limeDataSetTableAdapters.positionsTableAdapter positionsTableAdapter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateOfBirth;
        private System.Windows.Forms.DateTimePicker whenPassport;
        private System.Windows.Forms.Label label5;
    }
}