﻿namespace TProject
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
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.panelRightMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelMapSubstrate = new System.Windows.Forms.Panel();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.menuStrip.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.panelRightMenu.SuspendLayout();
            this.panelMapSubstrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(775, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.panelRightMenu);
            this.tabPageMap.Controls.Add(this.panelMapSubstrate);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(767, 319);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "Карта";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // panelRightMenu
            // 
            this.panelRightMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightMenu.Controls.Add(this.button1);
            this.panelRightMenu.Controls.Add(this.checkBox1);
            this.panelRightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightMenu.Location = new System.Drawing.Point(583, 3);
            this.panelRightMenu.Name = "panelRightMenu";
            this.panelRightMenu.Size = new System.Drawing.Size(181, 313);
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
            this.panelMapSubstrate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMapSubstrate.Controls.Add(this.pictureBoxMap);
            this.panelMapSubstrate.Location = new System.Drawing.Point(3, 3);
            this.panelMapSubstrate.Name = "panelMapSubstrate";
            this.panelMapSubstrate.Size = new System.Drawing.Size(574, 310);
            this.panelMapSubstrate.TabIndex = 0;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.BackColor = System.Drawing.Color.White;
            this.pictureBoxMap.Location = new System.Drawing.Point(48, 3);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(410, 275);
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMap_Paint);
            this.pictureBoxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseDown);
            this.pictureBoxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseMove);
            this.pictureBoxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseUp);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMap);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(775, 345);
            this.tabControlMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 369);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip);
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
            this.tabControlMain.ResumeLayout(false);
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
    }
}
