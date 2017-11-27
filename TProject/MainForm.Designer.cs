using System.Threading;
using TProject.Way;

namespace TProject
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.panelRightMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelMapSubstrate = new System.Windows.Forms.Panel();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.contextMenuStripPictBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутИзToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageWorkWithBD = new System.Windows.Forms.TabPage();
            this.groupBoxEditor = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxSelectTable = new System.Windows.Forms.ComboBox();
            this.labelSelectTable = new System.Windows.Forms.Label();
            this.dataGridViewDataBase = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openSubMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerTrafficLight = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.panelRightMenu.SuspendLayout();
            this.panelMapSubstrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.contextMenuStripPictBox.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageWorkWithBD.SuspendLayout();
            this.groupBoxEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(775, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapToolStripMenuItem,
            this.subMapToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.открытьToolStripMenuItem.Text = "Открыть..";
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openMapToolStripMenuItem.Text = "Карту";
            // 
            // subMapToolStripMenuItem
            // 
            this.subMapToolStripMenuItem.Name = "subMapToolStripMenuItem";
            this.subMapToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.subMapToolStripMenuItem.Text = "Подложку";
            this.subMapToolStripMenuItem.Click += new System.EventHandler(this.subMapToolStripMenuItem_Click);
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.panelRightMenu);
            this.tabPageMap.Controls.Add(this.panelMapSubstrate);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(767, 304);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "Карта";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // panelRightMenu
            // 
            this.panelRightMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightMenu.Controls.Add(this.button1);
            this.panelRightMenu.Controls.Add(this.button2);
            this.panelRightMenu.Controls.Add(this.checkBox1);
            this.panelRightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightMenu.Location = new System.Drawing.Point(583, 3);
            this.panelRightMenu.Name = "panelRightMenu";
            this.panelRightMenu.Size = new System.Drawing.Size(181, 298);
            this.panelRightMenu.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
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
            this.panelMapSubstrate.Size = new System.Drawing.Size(574, 298);
            this.panelMapSubstrate.TabIndex = 0;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxMap.ContextMenuStrip = this.contextMenuStripPictBox;
            this.pictureBoxMap.Location = new System.Drawing.Point(-2, 3);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(738, 392);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            // 
            // contextMenuStripPictBox
            // 
            this.contextMenuStripPictBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVertexToolStripMenuItem,
            this.addEdgeToolStripMenuItem,
            this.editVertexToolStripMenuItem,
            this.editEdgeToolStripMenuItem,
            this.маршрутИзToolStripMenuItem,
            this.маршрутВToolStripMenuItem});
            this.contextMenuStripPictBox.Name = "contextMenuStripPictBox";
            this.contextMenuStripPictBox.Size = new System.Drawing.Size(210, 136);
            // 
            // addVertexToolStripMenuItem
            // 
            this.addVertexToolStripMenuItem.Name = "addVertexToolStripMenuItem";
            this.addVertexToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addVertexToolStripMenuItem.Text = "Добавить перекресток";
            this.addVertexToolStripMenuItem.Click += new System.EventHandler(this.addVertexToolStripMenuItem_Click);
            // 
            // addEdgeToolStripMenuItem
            // 
            this.addEdgeToolStripMenuItem.Enabled = false;
            this.addEdgeToolStripMenuItem.Name = "addEdgeToolStripMenuItem";
            this.addEdgeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addEdgeToolStripMenuItem.Text = "Добавить перегон";
            this.addEdgeToolStripMenuItem.Click += new System.EventHandler(this.addEdgeToolStripMenuItem_Click);
            // 
            // editVertexToolStripMenuItem
            // 
            this.editVertexToolStripMenuItem.Enabled = false;
            this.editVertexToolStripMenuItem.Name = "editVertexToolStripMenuItem";
            this.editVertexToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editVertexToolStripMenuItem.Text = "Параметры перекрестка";
            this.editVertexToolStripMenuItem.Visible = false;
            this.editVertexToolStripMenuItem.Click += new System.EventHandler(this.editVertexToolStripMenuItem_Click);
            // 
            // editEdgeToolStripMenuItem
            // 
            this.editEdgeToolStripMenuItem.Enabled = false;
            this.editEdgeToolStripMenuItem.Name = "editEdgeToolStripMenuItem";
            this.editEdgeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editEdgeToolStripMenuItem.Text = "Параметры улицы";
            this.editEdgeToolStripMenuItem.Click += new System.EventHandler(this.editEdgeToolStripMenuItem_Click);
            // 
            // маршрутИзToolStripMenuItem
            // 
            this.маршрутИзToolStripMenuItem.Name = "маршрутИзToolStripMenuItem";
            this.маршрутИзToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.маршрутИзToolStripMenuItem.Text = "Маршрут из...";
            this.маршрутИзToolStripMenuItem.Click += new System.EventHandler(this.wayFromToolStripMenuItem_Click);
            // 
            // маршрутВToolStripMenuItem
            // 
            this.маршрутВToolStripMenuItem.Name = "маршрутВToolStripMenuItem";
            this.маршрутВToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.маршрутВToolStripMenuItem.Text = "Маршрут в...";
            this.маршрутВToolStripMenuItem.Click += new System.EventHandler(this.wayToToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageMap);
            this.tabControlMain.Controls.Add(this.tabPageWorkWithBD);
            this.tabControlMain.Location = new System.Drawing.Point(2, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(775, 330);
            this.tabControlMain.TabIndex = 2;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageWorkWithBD
            // 
            this.tabPageWorkWithBD.Controls.Add(this.groupBoxEditor);
            this.tabPageWorkWithBD.Controls.Add(this.comboBoxSelectTable);
            this.tabPageWorkWithBD.Controls.Add(this.labelSelectTable);
            this.tabPageWorkWithBD.Controls.Add(this.dataGridViewDataBase);
            this.tabPageWorkWithBD.Controls.Add(this.menuStrip1);
            this.tabPageWorkWithBD.Location = new System.Drawing.Point(4, 22);
            this.tabPageWorkWithBD.Name = "tabPageWorkWithBD";
            this.tabPageWorkWithBD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkWithBD.Size = new System.Drawing.Size(767, 304);
            this.tabPageWorkWithBD.TabIndex = 1;
            this.tabPageWorkWithBD.Text = "Работа с БД";
            this.tabPageWorkWithBD.UseVisualStyleBackColor = true;
            // 
            // groupBoxEditor
            // 
            this.groupBoxEditor.Controls.Add(this.buttonDelete);
            this.groupBoxEditor.Controls.Add(this.buttonEdit);
            this.groupBoxEditor.Controls.Add(this.buttonAdd);
            this.groupBoxEditor.Location = new System.Drawing.Point(597, 79);
            this.groupBoxEditor.Name = "groupBoxEditor";
            this.groupBoxEditor.Size = new System.Drawing.Size(160, 108);
            this.groupBoxEditor.TabIndex = 4;
            this.groupBoxEditor.TabStop = false;
            this.groupBoxEditor.Text = "Редактирование записей";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(7, 78);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(147, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(7, 49);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(147, 23);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(7, 20);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(147, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxSelectTable
            // 
            this.comboBoxSelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectTable.FormattingEnabled = true;
            this.comboBoxSelectTable.Items.AddRange(new object[] {
            "Типы полицейских",
            "Дорожные покрытия",
            "Топливо",
            "Автомобили",
            "Штрафы",
            "Дорожные знаки",
            "Водители"});
            this.comboBoxSelectTable.Location = new System.Drawing.Point(597, 35);
            this.comboBoxSelectTable.Name = "comboBoxSelectTable";
            this.comboBoxSelectTable.Size = new System.Drawing.Size(160, 21);
            this.comboBoxSelectTable.TabIndex = 3;
            this.comboBoxSelectTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectTable_SelectedIndexChanged);
            // 
            // labelSelectTable
            // 
            this.labelSelectTable.AutoSize = true;
            this.labelSelectTable.Location = new System.Drawing.Point(597, 6);
            this.labelSelectTable.Name = "labelSelectTable";
            this.labelSelectTable.Size = new System.Drawing.Size(144, 26);
            this.labelSelectTable.TabIndex = 2;
            this.labelSelectTable.Text = "Выберите таблицу для\r\nредактирования из списка";
            // 
            // dataGridViewDataBase
            // 
            this.dataGridViewDataBase.AllowUserToAddRows = false;
            this.dataGridViewDataBase.AllowUserToDeleteRows = false;
            this.dataGridViewDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataBase.Location = new System.Drawing.Point(3, 6);
            this.dataGridViewDataBase.MultiSelect = false;
            this.dataGridViewDataBase.Name = "dataGridViewDataBase";
            this.dataGridViewDataBase.ReadOnly = true;
            this.dataGridViewDataBase.RowHeadersVisible = false;
            this.dataGridViewDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataBase.Size = new System.Drawing.Size(588, 295);
            this.dataGridViewDataBase.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openSubMapFileDialog
            // 
            this.openSubMapFileDialog.Filter = "JPEG|*.JPG|JPEG|*.JPEG";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(775, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Готов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(775, 382);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "3GIS";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabPageMap.ResumeLayout(false);
            this.panelRightMenu.ResumeLayout(false);
            this.panelRightMenu.PerformLayout();
            this.panelMapSubstrate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.contextMenuStripPictBox.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageWorkWithBD.ResumeLayout(false);
            this.tabPageWorkWithBD.PerformLayout();
            this.groupBoxEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.Panel panelMapSubstrate;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Panel panelRightMenu;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPictBox;
        private System.Windows.Forms.ToolStripMenuItem addVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subMapToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openSubMapFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem editEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутИзToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутВToolStripMenuItem;
        private System.Windows.Forms.Timer timerTrafficLight;
        private System.Windows.Forms.TabPage tabPageWorkWithBD;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dataGridViewDataBase;
        private System.Windows.Forms.ComboBox comboBoxSelectTable;
        private System.Windows.Forms.Label labelSelectTable;
        private System.Windows.Forms.GroupBox groupBoxEditor;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
    }
}

