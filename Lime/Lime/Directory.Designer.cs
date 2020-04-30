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
            this.textBox_search = new System.Windows.Forms.ToolStripTextBox();
            this.button_filtr = new System.Windows.Forms.ToolStripButton();
            this.panel_add_worker = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.dateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.whenPassport = new System.Windows.Forms.DateTimePicker();
            this.registrationAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.byWhomPassport = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numberPassport = new System.Windows.Forms.TextBox();
            this.seriesPassport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.positionId = new System.Windows.Forms.ComboBox();
            this.positionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.limeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.limeDataSet = new Lime.limeDataSet();
            this.departmentId = new System.Windows.Forms.ComboBox();
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.departmentsTableAdapter = new Lime.limeDataSetTableAdapters.departmentsTableAdapter();
            this.positionsTableAdapter = new Lime.limeDataSetTableAdapters.positionsTableAdapter();
            this.panel_pos_dep = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.button_return = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectory)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel_add_worker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            this.panel_pos_dep.SuspendLayout();
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
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // другоеToolStripMenuItem
            // 
            this.другоеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отделыToolStripMenuItem,
            this.должностиToolStripMenuItem});
            this.другоеToolStripMenuItem.Name = "другоеToolStripMenuItem";
            this.другоеToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.другоеToolStripMenuItem.Text = "Другое";
            // 
            // отделыToolStripMenuItem
            // 
            this.отделыToolStripMenuItem.Name = "отделыToolStripMenuItem";
            this.отделыToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.отделыToolStripMenuItem.Text = "Отделы";
            this.отделыToolStripMenuItem.Click += new System.EventHandler(this.отделыToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.должностиToolStripMenuItem_Click);
            // 
            // dataGridViewDirectory
            // 
            this.dataGridViewDirectory.AllowUserToAddRows = false;
            this.dataGridViewDirectory.AllowUserToDeleteRows = false;
            this.dataGridViewDirectory.AllowUserToOrderColumns = true;
            this.dataGridViewDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDirectory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewDirectory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDirectory.Location = new System.Drawing.Point(38, 120);
            this.dataGridViewDirectory.Margin = new System.Windows.Forms.Padding(30, 3, 0, 3);
            this.dataGridViewDirectory.Name = "dataGridViewDirectory";
            this.dataGridViewDirectory.ReadOnly = true;
            this.dataGridViewDirectory.RowHeadersVisible = false;
            this.dataGridViewDirectory.RowHeadersWidth = 51;
            this.dataGridViewDirectory.RowTemplate.Height = 24;
            this.dataGridViewDirectory.ShowCellErrors = false;
            this.dataGridViewDirectory.ShowCellToolTips = false;
            this.dataGridViewDirectory.ShowEditingIcon = false;
            this.dataGridViewDirectory.ShowRowErrors = false;
            this.dataGridViewDirectory.Size = new System.Drawing.Size(1409, 845);
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
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_delete
            // 
            this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_delete.Location = new System.Drawing.Point(1497, 312);
            this.button_delete.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(185, 33);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Удалить";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
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
            this.textBox_search,
            this.button_filtr});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(1721, 37);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // textBox_search
            // 
            this.textBox_search.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_search.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox_search.Margin = new System.Windows.Forms.Padding(32, 0, 1, 0);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(350, 27);
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            this.textBox_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_KeyPress);
            this.textBox_search.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.textBox_search.MouseLeave += new System.EventHandler(this.textBox_search_MouseLeave);
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // button_filtr
            // 
            this.button_filtr.Image = ((System.Drawing.Image)(resources.GetObject("button_filtr.Image")));
            this.button_filtr.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_filtr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_filtr.Name = "button_filtr";
            this.button_filtr.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.button_filtr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_filtr.Size = new System.Drawing.Size(124, 24);
            this.button_filtr.Text = "Фильтр";
            this.button_filtr.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // panel_add_worker
            // 
            this.panel_add_worker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_add_worker.AutoScroll = true;
            this.panel_add_worker.AutoSize = true;
            this.panel_add_worker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_add_worker.Controls.Add(this.linkLabel2);
            this.panel_add_worker.Controls.Add(this.linkLabel1);
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Дата рождения";
            // 
            // dateOfBirth
            // 
            this.dateOfBirth.Location = new System.Drawing.Point(29, 94);
            this.dateOfBirth.Name = "dateOfBirth";
            this.dateOfBirth.Size = new System.Drawing.Size(349, 22);
            this.dateOfBirth.TabIndex = 26;
            // 
            // whenPassport
            // 
            this.whenPassport.Location = new System.Drawing.Point(495, 246);
            this.whenPassport.Name = "whenPassport";
            this.whenPassport.Size = new System.Drawing.Size(348, 22);
            this.whenPassport.TabIndex = 25;
            // 
            // registrationAddress
            // 
            this.registrationAddress.Location = new System.Drawing.Point(30, 508);
            this.registrationAddress.Multiline = true;
            this.registrationAddress.Name = "registrationAddress";
            this.registrationAddress.Size = new System.Drawing.Size(815, 136);
            this.registrationAddress.TabIndex = 23;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Кем выдан";
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
            // byWhomPassport
            // 
            this.byWhomPassport.Location = new System.Drawing.Point(29, 325);
            this.byWhomPassport.Multiline = true;
            this.byWhomPassport.Name = "byWhomPassport";
            this.byWhomPassport.Size = new System.Drawing.Size(815, 136);
            this.byWhomPassport.TabIndex = 18;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Серия";
            // 
            // numberPassport
            // 
            this.numberPassport.Location = new System.Drawing.Point(210, 248);
            this.numberPassport.Name = "numberPassport";
            this.numberPassport.Size = new System.Drawing.Size(168, 22);
            this.numberPassport.TabIndex = 15;
            // 
            // seriesPassport
            // 
            this.seriesPassport.Location = new System.Drawing.Point(29, 248);
            this.seriesPassport.Name = "seriesPassport";
            this.seriesPassport.Size = new System.Drawing.Size(168, 22);
            this.seriesPassport.TabIndex = 14;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Отдел";
            // 
            // positionId
            // 
            this.positionId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.positionsBindingSource, "id", true));
            this.positionId.DataSource = this.positionsBindingSource;
            this.positionId.DisplayMember = "name";
            this.positionId.FormattingEnabled = true;
            this.positionId.Location = new System.Drawing.Point(495, 171);
            this.positionId.Name = "positionId";
            this.positionId.Size = new System.Drawing.Size(349, 24);
            this.positionId.TabIndex = 11;
            this.positionId.ValueMember = "id";
            // 
            // positionsBindingSource
            // 
            this.positionsBindingSource.DataMember = "positions";
            this.positionsBindingSource.DataSource = this.limeDataSetBindingSource;
            // 
            // limeDataSetBindingSource
            // 
            this.limeDataSetBindingSource.DataSource = this.limeDataSet;
            this.limeDataSetBindingSource.Position = 0;
            // 
            // limeDataSet
            // 
            this.limeDataSet.DataSetName = "limeDataSet";
            this.limeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataMember = "departments";
            this.departmentsBindingSource.DataSource = this.limeDataSetBindingSource;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(940, 96);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(349, 22);
            this.email.TabIndex = 9;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Номер телефона";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(494, 96);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(349, 22);
            this.phone.TabIndex = 6;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
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
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(940, 41);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(349, 22);
            this.lastName.TabIndex = 2;
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
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(1497, 217);
            this.button_save.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(185, 33);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Cохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Visible = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // departmentsTableAdapter
            // 
            this.departmentsTableAdapter.ClearBeforeFill = true;
            // 
            // positionsTableAdapter
            // 
            this.positionsTableAdapter.ClearBeforeFill = true;
            // 
            // panel_pos_dep
            // 
            this.panel_pos_dep.Controls.Add(this.label15);
            this.panel_pos_dep.Controls.Add(this.name);
            this.panel_pos_dep.Location = new System.Drawing.Point(38, 120);
            this.panel_pos_dep.Name = "panel_pos_dep";
            this.panel_pos_dep.Size = new System.Drawing.Size(550, 370);
            this.panel_pos_dep.TabIndex = 29;
            this.panel_pos_dep.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Наименование";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(42, 36);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(307, 22);
            this.name.TabIndex = 0;
            // 
            // button_return
            // 
            this.button_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_return.Location = new System.Drawing.Point(1497, 264);
            this.button_return.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(185, 33);
            this.button_return.TabIndex = 30;
            this.button_return.Text = "Отменить";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Visible = false;
            this.button_return.Click += new System.EventHandler(this.nochange_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1390, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 35);
            this.button1.TabIndex = 31;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(1326, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 35);
            this.button2.TabIndex = 32;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(391, 173);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(20, 17);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(858, 174);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(20, 17);
            this.linkLabel2.TabIndex = 29;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "...";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Directory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1721, 999);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_return);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.nameTable);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_add_worker);
            this.Controls.Add(this.panel_pos_dep);
            this.Controls.Add(this.dataGridViewDirectory);
            this.Name = "Directory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Directory_FormClosing);
            this.Load += new System.EventHandler(this.Directory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectory)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_add_worker.ResumeLayout(false);
            this.panel_add_worker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.limeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            this.panel_pos_dep.ResumeLayout(false);
            this.panel_pos_dep.PerformLayout();
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
        private System.Windows.Forms.ToolStripTextBox textBox_search;
        private System.Windows.Forms.ToolStripButton button_filtr;
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
        private System.Windows.Forms.Panel panel_pos_dep;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button button_return;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}