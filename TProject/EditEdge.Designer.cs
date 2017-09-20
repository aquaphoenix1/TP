namespace TProject
{
    partial class EditEdge
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
            this.labelLength = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonMirror = new System.Windows.Forms.Button();
            this.groupBoxWay = new System.Windows.Forms.GroupBox();
            this.checkBoxWay = new System.Windows.Forms.CheckBox();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.linkLabelID = new System.Windows.Forms.LinkLabel();
            this.comboBoxCoat = new System.Windows.Forms.ComboBox();
            this.labelCoat = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSign = new System.Windows.Forms.Label();
            this.comboBoxSign = new System.Windows.Forms.ComboBox();
            this.groupBoxWay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(9, 76);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(90, 13);
            this.labelLength.TabIndex = 0;
            this.labelLength.Text = "Протяженность:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(197, 232);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Ок";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonMirror
            // 
            this.buttonMirror.Location = new System.Drawing.Point(103, 43);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(80, 24);
            this.buttonMirror.TabIndex = 2;
            this.buttonMirror.Text = "Отразить";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.buttonMirror_Click);
            // 
            // groupBoxWay
            // 
            this.groupBoxWay.Controls.Add(this.checkBoxWay);
            this.groupBoxWay.Controls.Add(this.buttonMirror);
            this.groupBoxWay.Location = new System.Drawing.Point(2, 189);
            this.groupBoxWay.Name = "groupBoxWay";
            this.groupBoxWay.Size = new System.Drawing.Size(189, 73);
            this.groupBoxWay.TabIndex = 3;
            this.groupBoxWay.TabStop = false;
            this.groupBoxWay.Text = "Направление";
            // 
            // checkBoxWay
            // 
            this.checkBoxWay.AutoSize = true;
            this.checkBoxWay.Location = new System.Drawing.Point(10, 19);
            this.checkBoxWay.Name = "checkBoxWay";
            this.checkBoxWay.Size = new System.Drawing.Size(137, 17);
            this.checkBoxWay.TabIndex = 4;
            this.checkBoxWay.Text = "Двусторонняя дорога";
            this.checkBoxWay.UseVisualStyleBackColor = true;
            this.checkBoxWay.CheckedChanged += new System.EventHandler(this.checkBoxWay_CheckedChanged);
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(106, 74);
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(166, 20);
            this.numericUpDownLength.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 48);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Название:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(95, 9);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(90, 13);
            this.labelID.TabIndex = 6;
            this.labelID.Text = "Идентификатор:";
            // 
            // linkLabelID
            // 
            this.linkLabelID.AutoSize = true;
            this.linkLabelID.Location = new System.Drawing.Point(194, 9);
            this.linkLabelID.Name = "linkLabelID";
            this.linkLabelID.Size = new System.Drawing.Size(0, 13);
            this.linkLabelID.TabIndex = 7;
            this.linkLabelID.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // comboBoxCoat
            // 
            this.comboBoxCoat.FormattingEnabled = true;
            this.comboBoxCoat.Location = new System.Drawing.Point(106, 101);
            this.comboBoxCoat.Name = "comboBoxCoat";
            this.comboBoxCoat.Size = new System.Drawing.Size(166, 21);
            this.comboBoxCoat.TabIndex = 8;
            this.comboBoxCoat.Text = "не указано";
            // 
            // labelCoat
            // 
            this.labelCoat.AutoSize = true;
            this.labelCoat.Location = new System.Drawing.Point(12, 104);
            this.labelCoat.Name = "labelCoat";
            this.labelCoat.Size = new System.Drawing.Size(61, 13);
            this.labelCoat.TabIndex = 9;
            this.labelCoat.Text = "Покрытие:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(75, 45);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 20);
            this.textBoxName.TabIndex = 10;
            this.textBoxName.Text = "Введите название улицы...";
            // 
            // labelSign
            // 
            this.labelSign.AutoSize = true;
            this.labelSign.Location = new System.Drawing.Point(12, 131);
            this.labelSign.Name = "labelSign";
            this.labelSign.Size = new System.Drawing.Size(35, 13);
            this.labelSign.TabIndex = 12;
            this.labelSign.Text = "Знак:";
            // 
            // comboBoxSign
            // 
            this.comboBoxSign.FormattingEnabled = true;
            this.comboBoxSign.Location = new System.Drawing.Point(106, 128);
            this.comboBoxSign.Name = "comboBoxSign";
            this.comboBoxSign.Size = new System.Drawing.Size(166, 21);
            this.comboBoxSign.TabIndex = 11;
            this.comboBoxSign.Text = "не указано";
            // 
            // EditEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.Controls.Add(this.labelSign);
            this.Controls.Add(this.comboBoxSign);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelCoat);
            this.Controls.Add(this.comboBoxCoat);
            this.Controls.Add(this.linkLabelID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.groupBoxWay);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelLength);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "EditEdge";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры перегона";
            this.Load += new System.EventHandler(this.EditEdge_Load);
            this.groupBoxWay.ResumeLayout(false);
            this.groupBoxWay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonMirror;
        private System.Windows.Forms.GroupBox groupBoxWay;
        private System.Windows.Forms.CheckBox checkBoxWay;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.LinkLabel linkLabelID;
        private System.Windows.Forms.ComboBox comboBoxCoat;
        private System.Windows.Forms.Label labelCoat;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelSign;
        private System.Windows.Forms.ComboBox comboBoxSign;
    }
}