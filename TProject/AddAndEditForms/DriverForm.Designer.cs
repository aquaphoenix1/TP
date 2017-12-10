namespace TProject
{
    partial class DriverForm
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.comboBoxIDAuto = new System.Windows.Forms.ComboBox();
            this.labelIDAuto = new System.Windows.Forms.Label();
            this.checkBoxIsIntruder = new System.Windows.Forms.CheckBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelFIO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccept.Location = new System.Drawing.Point(145, 87);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(117, 27);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // comboBoxIDAuto
            // 
            this.comboBoxIDAuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDAuto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxIDAuto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxIDAuto.FormattingEnabled = true;
            this.comboBoxIDAuto.Location = new System.Drawing.Point(122, 35);
            this.comboBoxIDAuto.Name = "comboBoxIDAuto";
            this.comboBoxIDAuto.Size = new System.Drawing.Size(140, 23);
            this.comboBoxIDAuto.TabIndex = 1;
            this.comboBoxIDAuto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBoxIDAuto_KeyUp);
            // 
            // labelIDAuto
            // 
            this.labelIDAuto.AutoSize = true;
            this.labelIDAuto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelIDAuto.Location = new System.Drawing.Point(6, 38);
            this.labelIDAuto.Name = "labelIDAuto";
            this.labelIDAuto.Size = new System.Drawing.Size(79, 15);
            this.labelIDAuto.TabIndex = 5;
            this.labelIDAuto.Text = "Автомобиль:";
            // 
            // checkBoxIsIntruder
            // 
            this.checkBoxIsIntruder.AutoSize = true;
            this.checkBoxIsIntruder.Location = new System.Drawing.Point(9, 66);
            this.checkBoxIsIntruder.Name = "checkBoxIsIntruder";
            this.checkBoxIsIntruder.Size = new System.Drawing.Size(96, 19);
            this.checkBoxIsIntruder.TabIndex = 2;
            this.checkBoxIsIntruder.Text = "Нарушитель";
            this.checkBoxIsIntruder.UseVisualStyleBackColor = true;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(122, 6);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(140, 23);
            this.textBoxFIO.TabIndex = 0;
            this.textBoxFIO.TextChanged += new System.EventHandler(this.TextBoxFIO_TextChanged);
            this.textBoxFIO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxFIO_KeyUp);
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFIO.Location = new System.Drawing.Point(6, 9);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(37, 15);
            this.labelFIO.TabIndex = 4;
            this.labelFIO.Text = "ФИО:";
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 126);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.checkBoxIsIntruder);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.comboBoxIDAuto);
            this.Controls.Add(this.labelIDAuto);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры автомобилиста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ComboBox comboBoxIDAuto;
        private System.Windows.Forms.Label labelIDAuto;
        private System.Windows.Forms.CheckBox checkBoxIsIntruder;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelFIO;
    }
}