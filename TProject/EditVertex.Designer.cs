namespace TProject
{
    partial class EditVertex
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
            this.linkLabelID = new System.Windows.Forms.LinkLabel();
            this.labelID = new System.Windows.Forms.Label();
            this.groupBoxTrafficLight = new System.Windows.Forms.GroupBox();
            this.checkBoxWay = new System.Windows.Forms.CheckBox();
            this.numericUpDownRed = new System.Windows.Forms.NumericUpDown();
            this.labelRed = new System.Windows.Forms.Label();
            this.numericUpDownGreen = new System.Windows.Forms.NumericUpDown();
            this.labelGreen = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.groupBoxTrafficLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelID
            // 
            this.linkLabelID.AutoSize = true;
            this.linkLabelID.Location = new System.Drawing.Point(142, 9);
            this.linkLabelID.Name = "linkLabelID";
            this.linkLabelID.Size = new System.Drawing.Size(0, 13);
            this.linkLabelID.TabIndex = 9;
            this.linkLabelID.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(43, 9);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(90, 13);
            this.labelID.TabIndex = 8;
            this.labelID.Text = "Идентификатор:";
            // 
            // groupBoxTrafficLight
            // 
            this.groupBoxTrafficLight.Controls.Add(this.numericUpDownGreen);
            this.groupBoxTrafficLight.Controls.Add(this.labelGreen);
            this.groupBoxTrafficLight.Controls.Add(this.numericUpDownRed);
            this.groupBoxTrafficLight.Controls.Add(this.labelRed);
            this.groupBoxTrafficLight.Controls.Add(this.checkBoxWay);
            this.groupBoxTrafficLight.Location = new System.Drawing.Point(12, 35);
            this.groupBoxTrafficLight.Name = "groupBoxTrafficLight";
            this.groupBoxTrafficLight.Size = new System.Drawing.Size(182, 93);
            this.groupBoxTrafficLight.TabIndex = 10;
            this.groupBoxTrafficLight.TabStop = false;
            this.groupBoxTrafficLight.Text = "Светофор";
            // 
            // checkBoxWay
            // 
            this.checkBoxWay.AutoSize = true;
            this.checkBoxWay.Location = new System.Drawing.Point(10, 19);
            this.checkBoxWay.Name = "checkBoxWay";
            this.checkBoxWay.Size = new System.Drawing.Size(76, 17);
            this.checkBoxWay.TabIndex = 4;
            this.checkBoxWay.Text = "Светофор";
            this.checkBoxWay.UseVisualStyleBackColor = true;
            this.checkBoxWay.CheckedChanged += new System.EventHandler(this.checkBoxWay_CheckedChanged);
            // 
            // numericUpDownRed
            // 
            this.numericUpDownRed.Location = new System.Drawing.Point(117, 37);
            this.numericUpDownRed.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numericUpDownRed.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownRed.Name = "numericUpDownRed";
            this.numericUpDownRed.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownRed.TabIndex = 6;
            this.numericUpDownRed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(7, 39);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(104, 13);
            this.labelRed.TabIndex = 5;
            this.labelRed.Text = "Красный светофор";
            // 
            // numericUpDownGreen
            // 
            this.numericUpDownGreen.Location = new System.Drawing.Point(117, 65);
            this.numericUpDownGreen.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownGreen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownGreen.Name = "numericUpDownGreen";
            this.numericUpDownGreen.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownGreen.TabIndex = 8;
            this.numericUpDownGreen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(7, 67);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(104, 13);
            this.labelGreen.TabIndex = 7;
            this.labelGreen.Text = "Зеленый светофор";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(12, 134);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 11;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // EditVertex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 163);
            this.ControlBox = false;
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.groupBoxTrafficLight);
            this.Controls.Add(this.linkLabelID);
            this.Controls.Add(this.labelID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditVertex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры вершины";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditVertex_Load);
            this.groupBoxTrafficLight.ResumeLayout(false);
            this.groupBoxTrafficLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.GroupBox groupBoxTrafficLight;
        private System.Windows.Forms.CheckBox checkBoxWay;
        private System.Windows.Forms.NumericUpDown numericUpDownGreen;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.NumericUpDown numericUpDownRed;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Button buttonAccept;
    }
}