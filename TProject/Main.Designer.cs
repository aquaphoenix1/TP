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
            this.contextMenuStripPictBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wayFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wayToВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openSubMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabPageWorkWithBD = new System.Windows.Forms.TabPage();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.panelRightMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelMapSubstrate = new System.Windows.Forms.Panel();
            this.subMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTrafficLight = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.contextMenuStripPictBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPageWorkWithBD.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.panelRightMenu.SuspendLayout();
            this.panelMapSubstrate.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.pictureBoxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseDown);
            this.pictureBoxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseMove);
            this.pictureBoxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseUp);
            // 
            // contextMenuStripPictBox
            // 
            this.contextMenuStripPictBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVertexToolStripMenuItem,
            this.addEdgeToolStripMenuItem,
            this.editVertexToolStripMenuItem,
            this.editEdgeToolStripMenuItem,
            this.wayFromToolStripMenuItem,
            this.wayToВToolStripMenuItem});
            this.contextMenuStripPictBox.Name = "contextMenuStripPictBox";
            this.contextMenuStripPictBox.Size = new System.Drawing.Size(210, 158);
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
            this.addEdgeToolStripMenuItem.Name = "addEdgeToolStripMenuItem";
            this.addEdgeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addEdgeToolStripMenuItem.Text = "Добавить перегон";
            this.addEdgeToolStripMenuItem.Click += new System.EventHandler(this.addEdgeToolStripMenuItem_Click);
            // 
            // editVertexToolStripMenuItem
            // 
            this.editVertexToolStripMenuItem.Name = "editVertexToolStripMenuItem";
            this.editVertexToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editVertexToolStripMenuItem.Text = "Параметры перекрестка";
            this.editVertexToolStripMenuItem.Visible = false;
            // 
            // editEdgeToolStripMenuItem
            // 
            this.editEdgeToolStripMenuItem.Name = "editEdgeToolStripMenuItem";
            this.editEdgeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editEdgeToolStripMenuItem.Text = "Параметры улицы";
            // 
            // wayFromToolStripMenuItem
            // 
            this.wayFromToolStripMenuItem.Name = "wayFromToolStripMenuItem";
            this.wayFromToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.wayFromToolStripMenuItem.Text = "Маршрут из...";
            // 
            // wayToВToolStripMenuItem
            // 
            this.wayToВToolStripMenuItem.Name = "wayToВToolStripMenuItem";
            this.wayToВToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.wayToВToolStripMenuItem.Text = "Маршрут в...";
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
            this.statusStrip1.Size = new System.Drawing.Size(775, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openSubMapFileDialog
            // 
            this.openSubMapFileDialog.Filter = "JPEG|*.JPG|JPEG|*.JPEG";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabPageWorkWithBD
            // 
            this.tabPageWorkWithBD.ContextMenuStrip = this.contextMenuStripPictBox;
            this.tabPageWorkWithBD.Controls.Add(this.menuStrip1);
            this.tabPageWorkWithBD.Location = new System.Drawing.Point(4, 22);
            this.tabPageWorkWithBD.Name = "tabPageWorkWithBD";
            this.tabPageWorkWithBD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkWithBD.Size = new System.Drawing.Size(767, 304);
            this.tabPageWorkWithBD.TabIndex = 1;
            this.tabPageWorkWithBD.Text = "Работа с БД";
            this.tabPageWorkWithBD.UseVisualStyleBackColor = true;
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
            this.tabControlMain.Size = new System.Drawing.Size(775, 330);
            this.tabControlMain.TabIndex = 5;
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
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
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
            // subMapToolStripMenuItem
            // 
            this.subMapToolStripMenuItem.Name = "subMapToolStripMenuItem";
            this.subMapToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.subMapToolStripMenuItem.Text = "Подложку";
            this.subMapToolStripMenuItem.Click += new System.EventHandler(this.subMapToolStripMenuItem_Click);
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openMapToolStripMenuItem.Text = "Карту";
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
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
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
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 382);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.contextMenuStripPictBox.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPageWorkWithBD.ResumeLayout(false);
            this.tabPageWorkWithBD.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.panelRightMenu.ResumeLayout(false);
            this.panelRightMenu.PerformLayout();
            this.panelMapSubstrate.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPictBox;
        private System.Windows.Forms.ToolStripMenuItem addVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wayFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wayToВToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openSubMapFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage tabPageWorkWithBD;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.Panel panelRightMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panelMapSubstrate;
        private System.Windows.Forms.ToolStripMenuItem subMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.Timer timerTrafficLight;
        private System.Windows.Forms.MenuStrip menuStrip;
    }
}