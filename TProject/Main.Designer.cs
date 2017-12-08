namespace TProject
{
    partial class Main
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
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.contextMenuVertex = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wayFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wayToВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПерекрестокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openSubMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPageWorkWithBD = new System.Windows.Forms.TabPage();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelEditor = new System.Windows.Forms.Label();
            this.labelSelectTable = new System.Windows.Forms.Label();
            this.comboBoxSelectTable = new System.Windows.Forms.ComboBox();
            this.dataGridViewDataBase = new System.Windows.Forms.DataGridView();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.panelSlideContainer = new System.Windows.Forms.Panel();
            this.textBox_CurrentCoefficient = new System.Windows.Forms.TextBox();
            this.button_Ok_Сalibration = new System.Windows.Forms.Button();
            this.button_Calibration = new System.Windows.Forms.Button();
            this.panelSlide = new System.Windows.Forms.Panel();
            this.label_Layers = new TProject.VerticalLabel();
            this.labelSlide = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_StreetName = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelStreetName = new System.Windows.Forms.Label();
            this.checkBox__TrafficLight = new System.Windows.Forms.CheckBox();
            this.checkBox_StreetLength = new System.Windows.Forms.CheckBox();
            this.labelPolicemans = new System.Windows.Forms.Label();
            this.labelLengthStreet = new System.Windows.Forms.Label();
            this.checkBox_Police = new System.Windows.Forms.CheckBox();
            this.checkBox_Sign = new System.Windows.Forms.CheckBox();
            this.labelRoadSign = new System.Windows.Forms.Label();
            this.panelMapSubstrate = new System.Windows.Forms.Panel();
            this.timerTrafficLight = new System.Windows.Forms.Timer(this.components);
            this.info = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выдатьСведенияОРазработчикахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выдатьСведенияОСистемеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ChooseSubstrate = new System.Windows.Forms.ToolStripMenuItem();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оСистемеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Route = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_StaticView = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_RouteParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuEdge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПерегонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.contextMenuVertex.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPageWorkWithBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.panelSlideContainer.SuspendLayout();
            this.panelSlide.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMapSubstrate.SuspendLayout();
            this.info.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.contextMenuEdge.SuspendLayout();
            this.contextMenuMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxMap.Location = new System.Drawing.Point(-10, -30);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(752, 392);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            // 
            // contextMenuVertex
            // 
            this.contextMenuVertex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEdgeToolStripMenuItem,
            this.editVertexToolStripMenuItem,
            this.wayFromToolStripMenuItem,
            this.wayToВToolStripMenuItem,
            this.удалитьПерекрестокToolStripMenuItem});
            this.contextMenuVertex.Name = "contextMenuStripPictBox";
            this.contextMenuVertex.Size = new System.Drawing.Size(210, 114);
            // 
            // addEdgeToolStripMenuItem
            // 
            this.addEdgeToolStripMenuItem.Name = "addEdgeToolStripMenuItem";
            this.addEdgeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addEdgeToolStripMenuItem.Text = "Добавить перегон";
            this.addEdgeToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenu_AddEdge_Click);
            // 
            // editVertexToolStripMenuItem
            // 
            this.editVertexToolStripMenuItem.Name = "editVertexToolStripMenuItem";
            this.editVertexToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editVertexToolStripMenuItem.Text = "Параметры перекрестка";
            this.editVertexToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenu_EditVertex_Click);
            // 
            // wayFromToolStripMenuItem
            // 
            this.wayFromToolStripMenuItem.Name = "wayFromToolStripMenuItem";
            this.wayFromToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.wayFromToolStripMenuItem.Text = "Маршрут из...";
            this.wayFromToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenu_WayFrom_Click);
            // 
            // wayToВToolStripMenuItem
            // 
            this.wayToВToolStripMenuItem.Name = "wayToВToolStripMenuItem";
            this.wayToВToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.wayToВToolStripMenuItem.Text = "Маршрут в...";
            this.wayToВToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenu_WayToВ_Click);
            // 
            // удалитьПерекрестокToolStripMenuItem
            // 
            this.удалитьПерекрестокToolStripMenuItem.Name = "удалитьПерекрестокToolStripMenuItem";
            this.удалитьПерекрестокToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.удалитьПерекрестокToolStripMenuItem.Text = "Удалить перекресток";
            this.удалитьПерекрестокToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_DeleteVertex_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Готов";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openSubMapFileDialog
            // 
            this.openSubMapFileDialog.Filter = "JPEG|*.JPG|JPEG|*.JPEG";
            // 
            // tabPageWorkWithBD
            // 
            this.tabPageWorkWithBD.ContextMenuStrip = this.contextMenuVertex;
            this.tabPageWorkWithBD.Controls.Add(this.buttonRemove);
            this.tabPageWorkWithBD.Controls.Add(this.buttonEdit);
            this.tabPageWorkWithBD.Controls.Add(this.buttonAdd);
            this.tabPageWorkWithBD.Controls.Add(this.labelEditor);
            this.tabPageWorkWithBD.Controls.Add(this.labelSelectTable);
            this.tabPageWorkWithBD.Controls.Add(this.comboBoxSelectTable);
            this.tabPageWorkWithBD.Controls.Add(this.dataGridViewDataBase);
            this.tabPageWorkWithBD.Location = new System.Drawing.Point(4, 22);
            this.tabPageWorkWithBD.Name = "tabPageWorkWithBD";
            this.tabPageWorkWithBD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkWithBD.Size = new System.Drawing.Size(769, 304);
            this.tabPageWorkWithBD.TabIndex = 1;
            this.tabPageWorkWithBD.Text = "Работа с БД";
            this.tabPageWorkWithBD.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(604, 135);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(154, 23);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "Удалить";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(604, 106);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(154, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(604, 77);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(154, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // labelEditor
            // 
            this.labelEditor.AutoSize = true;
            this.labelEditor.Location = new System.Drawing.Point(601, 60);
            this.labelEditor.Name = "labelEditor";
            this.labelEditor.Size = new System.Drawing.Size(136, 13);
            this.labelEditor.TabIndex = 3;
            this.labelEditor.Text = "Редактирование записей";
            // 
            // labelSelectTable
            // 
            this.labelSelectTable.AutoSize = true;
            this.labelSelectTable.Location = new System.Drawing.Point(601, 7);
            this.labelSelectTable.Name = "labelSelectTable";
            this.labelSelectTable.Size = new System.Drawing.Size(147, 26);
            this.labelSelectTable.TabIndex = 2;
            this.labelSelectTable.Text = "Выберите таблицу для \r\nредактирования из списка:";
            // 
            // comboBoxSelectTable
            // 
            this.comboBoxSelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectTable.FormattingEnabled = true;
            this.comboBoxSelectTable.Items.AddRange(new object[] {
            "Дорожные покрытия",
            "Типы полицейских",
            "Топливо",
            "Автомобили",
            "Штрафы",
            "Водители",
            "Дорожные знаки",
            "Улицы"});
            this.comboBoxSelectTable.Location = new System.Drawing.Point(604, 36);
            this.comboBoxSelectTable.Name = "comboBoxSelectTable";
            this.comboBoxSelectTable.Size = new System.Drawing.Size(154, 21);
            this.comboBoxSelectTable.TabIndex = 1;
            this.comboBoxSelectTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectTable_SelectedIndexChanged);
            // 
            // dataGridViewDataBase
            // 
            this.dataGridViewDataBase.AllowUserToAddRows = false;
            this.dataGridViewDataBase.AllowUserToDeleteRows = false;
            this.dataGridViewDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataBase.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewDataBase.MultiSelect = false;
            this.dataGridViewDataBase.Name = "dataGridViewDataBase";
            this.dataGridViewDataBase.ReadOnly = true;
            this.dataGridViewDataBase.RowHeadersVisible = false;
            this.dataGridViewDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataBase.Size = new System.Drawing.Size(592, 292);
            this.dataGridViewDataBase.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageMap);
            this.tabControlMain.Controls.Add(this.tabPageWorkWithBD);
            this.tabControlMain.Location = new System.Drawing.Point(1, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(777, 330);
            this.tabControlMain.TabIndex = 5;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.panelSlideContainer);
            this.tabPageMap.Controls.Add(this.panelMapSubstrate);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(711, 304);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "Карта";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // panelSlideContainer
            // 
            this.panelSlideContainer.Controls.Add(this.textBox_CurrentCoefficient);
            this.panelSlideContainer.Controls.Add(this.button_Ok_Сalibration);
            this.panelSlideContainer.Controls.Add(this.button_Calibration);
            this.panelSlideContainer.Controls.Add(this.panelSlide);
            this.panelSlideContainer.Controls.Add(this.groupBox1);
            this.panelSlideContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSlideContainer.Location = new System.Drawing.Point(683, 3);
            this.panelSlideContainer.Name = "panelSlideContainer";
            this.panelSlideContainer.Size = new System.Drawing.Size(25, 298);
            this.panelSlideContainer.TabIndex = 13;
            // 
            // textBox_CurrentCoefficient
            // 
            this.textBox_CurrentCoefficient.Enabled = false;
            this.textBox_CurrentCoefficient.Location = new System.Drawing.Point(31, 247);
            this.textBox_CurrentCoefficient.Name = "textBox_CurrentCoefficient";
            this.textBox_CurrentCoefficient.Size = new System.Drawing.Size(161, 20);
            this.textBox_CurrentCoefficient.TabIndex = 16;
            // 
            // button_Ok_Сalibration
            // 
            this.button_Ok_Сalibration.Location = new System.Drawing.Point(161, 274);
            this.button_Ok_Сalibration.Name = "button_Ok_Сalibration";
            this.button_Ok_Сalibration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_Ok_Сalibration.Size = new System.Drawing.Size(31, 23);
            this.button_Ok_Сalibration.TabIndex = 15;
            this.button_Ok_Сalibration.Text = "Ок";
            this.button_Ok_Сalibration.UseVisualStyleBackColor = true;
            this.button_Ok_Сalibration.Click += new System.EventHandler(this.Button_Ok_Сalibration_Click);
            // 
            // button_Calibration
            // 
            this.button_Calibration.Location = new System.Drawing.Point(29, 273);
            this.button_Calibration.Name = "button_Calibration";
            this.button_Calibration.Size = new System.Drawing.Size(131, 25);
            this.button_Calibration.TabIndex = 14;
            this.button_Calibration.Text = "Калибровка масштаба";
            this.button_Calibration.UseVisualStyleBackColor = true;
            this.button_Calibration.Click += new System.EventHandler(this.Button_Calibration_Click);
            // 
            // panelSlide
            // 
            this.panelSlide.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelSlide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSlide.Controls.Add(this.label_Layers);
            this.panelSlide.Controls.Add(this.labelSlide);
            this.panelSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlide.Location = new System.Drawing.Point(0, 0);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(25, 298);
            this.panelSlide.TabIndex = 1;
            this.panelSlide.Click += new System.EventHandler(this.PanelSlide_Click);
            // 
            // label_Layers
            // 
            this.label_Layers.AutoSize = true;
            this.label_Layers.Location = new System.Drawing.Point(3, 111);
            this.label_Layers.Name = "label_Layers";
            this.label_Layers.NewText = null;
            this.label_Layers.RotateAngle = 0;
            this.label_Layers.Size = new System.Drawing.Size(73, 13);
            this.label_Layers.TabIndex = 1;
            this.label_Layers.Text = "verticalLabel1";
            // 
            // labelSlide
            // 
            this.labelSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSlide.AutoSize = true;
            this.labelSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSlide.Location = new System.Drawing.Point(1, 278);
            this.labelSlide.Name = "labelSlide";
            this.labelSlide.Size = new System.Drawing.Size(21, 13);
            this.labelSlide.TabIndex = 0;
            this.labelSlide.Text = "<<";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_StreetName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelStreetName);
            this.groupBox1.Controls.Add(this.checkBox__TrafficLight);
            this.groupBox1.Controls.Add(this.checkBox_StreetLength);
            this.groupBox1.Controls.Add(this.labelPolicemans);
            this.groupBox1.Controls.Add(this.labelLengthStreet);
            this.groupBox1.Controls.Add(this.checkBox_Police);
            this.groupBox1.Controls.Add(this.checkBox_Sign);
            this.groupBox1.Controls.Add(this.labelRoadSign);
            this.groupBox1.Location = new System.Drawing.Point(29, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 132);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Слои";
            // 
            // checkBox_StreetName
            // 
            this.checkBox_StreetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_StreetName.AutoSize = true;
            this.checkBox_StreetName.Checked = true;
            this.checkBox_StreetName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_StreetName.Location = new System.Drawing.Point(15, 23);
            this.checkBox_StreetName.Name = "checkBox_StreetName";
            this.checkBox_StreetName.Size = new System.Drawing.Size(15, 14);
            this.checkBox_StreetName.TabIndex = 2;
            this.checkBox_StreetName.UseVisualStyleBackColor = true;
            this.checkBox_StreetName.CheckedChanged += new System.EventHandler(this.CheckBox_StreetName_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Светофоры";
            // 
            // labelStreetName
            // 
            this.labelStreetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStreetName.AutoSize = true;
            this.labelStreetName.Location = new System.Drawing.Point(36, 23);
            this.labelStreetName.Name = "labelStreetName";
            this.labelStreetName.Size = new System.Drawing.Size(91, 13);
            this.labelStreetName.TabIndex = 3;
            this.labelStreetName.Text = "Название улицы";
            // 
            // checkBox__TrafficLight
            // 
            this.checkBox__TrafficLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox__TrafficLight.AutoSize = true;
            this.checkBox__TrafficLight.Checked = true;
            this.checkBox__TrafficLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox__TrafficLight.Location = new System.Drawing.Point(15, 63);
            this.checkBox__TrafficLight.Name = "checkBox__TrafficLight";
            this.checkBox__TrafficLight.Size = new System.Drawing.Size(15, 14);
            this.checkBox__TrafficLight.TabIndex = 10;
            this.checkBox__TrafficLight.UseVisualStyleBackColor = true;
            this.checkBox__TrafficLight.CheckedChanged += new System.EventHandler(this.CheckBox__TrafficLight_CheckedChanged);
            // 
            // checkBox_StreetLength
            // 
            this.checkBox_StreetLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_StreetLength.AutoSize = true;
            this.checkBox_StreetLength.Checked = true;
            this.checkBox_StreetLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_StreetLength.Location = new System.Drawing.Point(15, 43);
            this.checkBox_StreetLength.Name = "checkBox_StreetLength";
            this.checkBox_StreetLength.Size = new System.Drawing.Size(15, 14);
            this.checkBox_StreetLength.TabIndex = 4;
            this.checkBox_StreetLength.UseVisualStyleBackColor = true;
            this.checkBox_StreetLength.CheckedChanged += new System.EventHandler(this.CheckBox_StreetLength_CheckedChanged);
            // 
            // labelPolicemans
            // 
            this.labelPolicemans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPolicemans.AutoSize = true;
            this.labelPolicemans.Location = new System.Drawing.Point(36, 83);
            this.labelPolicemans.Name = "labelPolicemans";
            this.labelPolicemans.Size = new System.Drawing.Size(75, 13);
            this.labelPolicemans.TabIndex = 9;
            this.labelPolicemans.Text = "Полицейские";
            // 
            // labelLengthStreet
            // 
            this.labelLengthStreet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLengthStreet.AutoSize = true;
            this.labelLengthStreet.Location = new System.Drawing.Point(36, 43);
            this.labelLengthStreet.Name = "labelLengthStreet";
            this.labelLengthStreet.Size = new System.Drawing.Size(113, 13);
            this.labelLengthStreet.TabIndex = 5;
            this.labelLengthStreet.Text = "Протяженности улиц";
            // 
            // checkBox_Police
            // 
            this.checkBox_Police.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_Police.AutoSize = true;
            this.checkBox_Police.Checked = true;
            this.checkBox_Police.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Police.Location = new System.Drawing.Point(15, 83);
            this.checkBox_Police.Name = "checkBox_Police";
            this.checkBox_Police.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Police.TabIndex = 8;
            this.checkBox_Police.UseVisualStyleBackColor = true;
            this.checkBox_Police.CheckedChanged += new System.EventHandler(this.CheckBox_Police_CheckedChanged);
            // 
            // checkBox_Sign
            // 
            this.checkBox_Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_Sign.AutoSize = true;
            this.checkBox_Sign.Checked = true;
            this.checkBox_Sign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Sign.Location = new System.Drawing.Point(15, 103);
            this.checkBox_Sign.Name = "checkBox_Sign";
            this.checkBox_Sign.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Sign.TabIndex = 6;
            this.checkBox_Sign.UseVisualStyleBackColor = true;
            this.checkBox_Sign.CheckedChanged += new System.EventHandler(this.CheckBox_Sign_CheckedChanged);
            // 
            // labelRoadSign
            // 
            this.labelRoadSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRoadSign.AutoSize = true;
            this.labelRoadSign.Location = new System.Drawing.Point(36, 103);
            this.labelRoadSign.Name = "labelRoadSign";
            this.labelRoadSign.Size = new System.Drawing.Size(95, 13);
            this.labelRoadSign.TabIndex = 7;
            this.labelRoadSign.Text = "Дорожные знаки";
            // 
            // panelMapSubstrate
            // 
            this.panelMapSubstrate.AllowDrop = true;
            this.panelMapSubstrate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMapSubstrate.AutoScroll = true;
            this.panelMapSubstrate.BackColor = System.Drawing.Color.Honeydew;
            this.panelMapSubstrate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMapSubstrate.Controls.Add(this.pictureBoxMap);
            this.panelMapSubstrate.Location = new System.Drawing.Point(3, 3);
            this.panelMapSubstrate.Name = "panelMapSubstrate";
            this.panelMapSubstrate.Size = new System.Drawing.Size(682, 298);
            this.panelMapSubstrate.TabIndex = 0;
            // 
            // info
            // 
            this.info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выдатьСведенияОРазработчикахToolStripMenuItem,
            this.выдатьСведенияОСистемеToolStripMenuItem});
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(261, 48);
            // 
            // выдатьСведенияОРазработчикахToolStripMenuItem
            // 
            this.выдатьСведенияОРазработчикахToolStripMenuItem.Name = "выдатьСведенияОРазработчикахToolStripMenuItem";
            this.выдатьСведенияОРазработчикахToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.выдатьСведенияОРазработчикахToolStripMenuItem.Text = "Выдать сведения о разработчиках";
            // 
            // выдатьСведенияОСистемеToolStripMenuItem
            // 
            this.выдатьСведенияОСистемеToolStripMenuItem.Name = "выдатьСведенияОСистемеToolStripMenuItem";
            this.выдатьСведенияОСистемеToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.выдатьСведенияОСистемеToolStripMenuItem.Text = "Выдать сведения о системе";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.базаДанныхToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.ToolStripMenuItem_Route});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(778, 24);
            this.menuStrip2.TabIndex = 12;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.ToolStripMenuItem_Save,
            this.ToolStripMenuItem_SaveAs,
            this.ToolStripMenuItem_ChooseSubstrate});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Открыть";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem_Open_Click);
            // 
            // ToolStripMenuItem_Save
            // 
            this.ToolStripMenuItem_Save.Enabled = false;
            this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
            this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Save.Text = "Сохранить";
            this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripMenuItem_Save_Click);
            // 
            // ToolStripMenuItem_SaveAs
            // 
            this.ToolStripMenuItem_SaveAs.Enabled = false;
            this.ToolStripMenuItem_SaveAs.Name = "ToolStripMenuItem_SaveAs";
            this.ToolStripMenuItem_SaveAs.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_SaveAs.Text = "Сохранить как...";
            this.ToolStripMenuItem_SaveAs.Click += new System.EventHandler(this.ToolStripMenuItem_SaveAS_Click);
            // 
            // ToolStripMenuItem_ChooseSubstrate
            // 
            this.ToolStripMenuItem_ChooseSubstrate.Enabled = false;
            this.ToolStripMenuItem_ChooseSubstrate.Name = "ToolStripMenuItem_ChooseSubstrate";
            this.ToolStripMenuItem_ChooseSubstrate.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_ChooseSubstrate.Text = "Сменить подложку";
            this.ToolStripMenuItem_ChooseSubstrate.Click += new System.EventHandler(this.ToolStripMenu_SubMap_Click);
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оToolStripMenuItem,
            this.оСистемеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оToolStripMenuItem
            // 
            this.оToolStripMenuItem.Name = "оToolStripMenuItem";
            this.оToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.оToolStripMenuItem.Text = "О разработчиках";
            this.оToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_AboutDeveloper_Click);
            // 
            // оСистемеToolStripMenuItem
            // 
            this.оСистемеToolStripMenuItem.Name = "оСистемеToolStripMenuItem";
            this.оСистемеToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.оСистемеToolStripMenuItem.Text = "О системе";
            this.оСистемеToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_AboutSystem_Click);
            // 
            // ToolStripMenuItem_Route
            // 
            this.ToolStripMenuItem_Route.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_StaticView,
            this.ToolStripMenuItem_RouteParameters});
            this.ToolStripMenuItem_Route.Name = "ToolStripMenuItem_Route";
            this.ToolStripMenuItem_Route.Size = new System.Drawing.Size(72, 20);
            this.ToolStripMenuItem_Route.Text = "Маршрут";
            this.ToolStripMenuItem_Route.Click += new System.EventHandler(this.ToolStripMenuItem_Route_Click);
            // 
            // ToolStripMenuItem_StaticView
            // 
            this.ToolStripMenuItem_StaticView.Name = "ToolStripMenuItem_StaticView";
            this.ToolStripMenuItem_StaticView.Size = new System.Drawing.Size(202, 22);
            this.ToolStripMenuItem_StaticView.Text = "Отобразить статически";
            this.ToolStripMenuItem_StaticView.Click += new System.EventHandler(this.ToolStripMenuItem_MakeStaticRoute_Click);
            // 
            // ToolStripMenuItem_RouteParameters
            // 
            this.ToolStripMenuItem_RouteParameters.Name = "ToolStripMenuItem_RouteParameters";
            this.ToolStripMenuItem_RouteParameters.Size = new System.Drawing.Size(202, 22);
            this.ToolStripMenuItem_RouteParameters.Text = "Параметры маршрута";
            this.ToolStripMenuItem_RouteParameters.Click += new System.EventHandler(this.ПараметрыМаршрутаToolStripMenuItem_Click);
            // 
            // contextMenuEdge
            // 
            this.contextMenuEdge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.удалитьПерегонToolStripMenuItem});
            this.contextMenuEdge.Name = "contextMenuStripPictBox";
            this.contextMenuEdge.Size = new System.Drawing.Size(193, 48);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem5.Text = "Параметры перегона";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenu_EditEdge_Click);
            // 
            // удалитьПерегонToolStripMenuItem
            // 
            this.удалитьПерегонToolStripMenuItem.Name = "удалитьПерегонToolStripMenuItem";
            this.удалитьПерегонToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.удалитьПерегонToolStripMenuItem.Text = "Удалить перегон";
            this.удалитьПерегонToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_DeleteEdge_Click);
            // 
            // contextMenuMap
            // 
            this.contextMenuMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9});
            this.contextMenuMap.Name = "contextMenuStripPictBox";
            this.contextMenuMap.Size = new System.Drawing.Size(199, 26);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem9.Text = "Добавить перекресток";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.ToolStripMenu_AddVertex_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 382);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Поиск оптимального маршрута";
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.contextMenuVertex.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPageWorkWithBD.ResumeLayout(false);
            this.tabPageWorkWithBD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.panelSlideContainer.ResumeLayout(false);
            this.panelSlideContainer.PerformLayout();
            this.panelSlide.ResumeLayout(false);
            this.panelSlide.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelMapSubstrate.ResumeLayout(false);
            this.info.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.contextMenuEdge.ResumeLayout(false);
            this.contextMenuMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.ContextMenuStrip contextMenuVertex;
        private System.Windows.Forms.ToolStripMenuItem addEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wayFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wayToВToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openSubMapFileDialog;
        private System.Windows.Forms.TabPage tabPageWorkWithBD;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.Panel panelMapSubstrate;
        private System.Windows.Forms.Timer timerTrafficLight;
        private System.Windows.Forms.ContextMenuStrip info;
        private System.Windows.Forms.ToolStripMenuItem выдатьСведенияОРазработчикахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выдатьСведенияОСистемеToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_StreetName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelStreetName;
        private System.Windows.Forms.CheckBox checkBox__TrafficLight;
        private System.Windows.Forms.CheckBox checkBox_StreetLength;
        private System.Windows.Forms.Label labelPolicemans;
        private System.Windows.Forms.Label labelLengthStreet;
        private System.Windows.Forms.CheckBox checkBox_Police;
        private System.Windows.Forms.Panel panelSlideContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_Sign;
        private System.Windows.Forms.Label labelRoadSign;
        private System.Windows.Forms.Panel panelSlide;
        private System.Windows.Forms.Label labelSlide;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ChooseSubstrate;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Route;
        private VerticalLabel label_Layers;
        private System.Windows.Forms.ContextMenuStrip contextMenuEdge;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ContextMenuStrip contextMenuMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.Button button_Calibration;
        private System.Windows.Forms.Button button_Ok_Сalibration;
        private System.Windows.Forms.TextBox textBox_CurrentCoefficient;
        private System.Windows.Forms.DataGridView dataGridViewDataBase;
        private System.Windows.Forms.Label labelSelectTable;
        private System.Windows.Forms.ComboBox comboBoxSelectTable;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelEditor;
        private System.Windows.Forms.ToolStripMenuItem удалитьПерегонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьПерекрестокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StaticView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_RouteParameters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem оToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оСистемеToolStripMenuItem;
    }
}