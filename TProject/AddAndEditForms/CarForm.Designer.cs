namespace TProject
{
    partial class CarForm
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
            this.comboBoxIDFuel = new System.Windows.Forms.ComboBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelConsumption = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIDFuel = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.textBoxConsumption = new System.Windows.Forms.MaskedTextBox();
            this.textBoxSpeed = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // comboBoxIDFuel
            // 
            this.comboBoxIDFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDFuel.FormattingEnabled = true;
            this.comboBoxIDFuel.Location = new System.Drawing.Point(147, 38);
            this.comboBoxIDFuel.Name = "comboBoxIDFuel";
            this.comboBoxIDFuel.Size = new System.Drawing.Size(161, 23);
            this.comboBoxIDFuel.TabIndex = 16;
            this.comboBoxIDFuel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBoxIDFuel_KeyUp);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccept.Location = new System.Drawing.Point(213, 141);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(100, 27);
            this.buttonAccept.TabIndex = 15;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // labelConsumption
            // 
            this.labelConsumption.AutoSize = true;
            this.labelConsumption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelConsumption.Location = new System.Drawing.Point(14, 75);
            this.labelConsumption.Name = "labelConsumption";
            this.labelConsumption.Size = new System.Drawing.Size(95, 15);
            this.labelConsumption.TabIndex = 14;
            this.labelConsumption.Text = "Расход топлива:";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxModel.Location = new System.Drawing.Point(147, 6);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(161, 23);
            this.textBoxModel.TabIndex = 12;
            this.textBoxModel.TextChanged += new System.EventHandler(this.TextBoxModel_TextChanged);
            this.textBoxModel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxModel_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 11;
            // 
            // labelIDFuel
            // 
            this.labelIDFuel.AutoSize = true;
            this.labelIDFuel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelIDFuel.Location = new System.Drawing.Point(14, 39);
            this.labelIDFuel.Name = "labelIDFuel";
            this.labelIDFuel.Size = new System.Drawing.Size(58, 15);
            this.labelIDFuel.TabIndex = 10;
            this.labelIDFuel.Text = "Топливо:";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelModel.Location = new System.Drawing.Point(14, 9);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(53, 15);
            this.labelModel.TabIndex = 9;
            this.labelModel.Text = "Модель:";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelSpeed.Location = new System.Drawing.Point(12, 112);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(62, 15);
            this.labelSpeed.TabIndex = 17;
            this.labelSpeed.Text = "Скорость:";
            // 
            // textBoxConsumption
            // 
            this.textBoxConsumption.Location = new System.Drawing.Point(147, 75);
            this.textBoxConsumption.Mask = "00.0";
            this.textBoxConsumption.Name = "textBoxConsumption";
            this.textBoxConsumption.Size = new System.Drawing.Size(161, 23);
            this.textBoxConsumption.TabIndex = 19;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(147, 106);
            this.textBoxSpeed.Mask = "000";
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(161, 23);
            this.textBoxSpeed.TabIndex = 20;
            // 
            // CarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 175);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.textBoxConsumption);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.comboBoxIDFuel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelConsumption);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelIDFuel);
            this.Controls.Add(this.labelModel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры автомобиля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxIDFuel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelConsumption;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIDFuel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.MaskedTextBox textBoxConsumption;
        private System.Windows.Forms.MaskedTextBox textBoxSpeed;
    }
}