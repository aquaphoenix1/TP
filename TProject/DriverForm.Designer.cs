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
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(142, 71);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(100, 23);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // comboBoxIDAuto
            // 
            this.comboBoxIDAuto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxIDAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxIDAuto.FormattingEnabled = true;
            this.comboBoxIDAuto.Location = new System.Drawing.Point(121, 41);
            this.comboBoxIDAuto.Name = "comboBoxIDAuto";
            this.comboBoxIDAuto.Size = new System.Drawing.Size(121, 24);
            this.comboBoxIDAuto.TabIndex = 7;
            // 
            // labelIDAuto
            // 
            this.labelIDAuto.AutoSize = true;
            this.labelIDAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIDAuto.Location = new System.Drawing.Point(12, 44);
            this.labelIDAuto.Name = "labelIDAuto";
            this.labelIDAuto.Size = new System.Drawing.Size(103, 16);
            this.labelIDAuto.TabIndex = 6;
            this.labelIDAuto.Text = "ID автомобиля";
            // 
            // checkBoxIsIntruder
            // 
            this.checkBoxIsIntruder.AutoSize = true;
            this.checkBoxIsIntruder.Location = new System.Drawing.Point(15, 21);
            this.checkBoxIsIntruder.Name = "checkBoxIsIntruder";
            this.checkBoxIsIntruder.Size = new System.Drawing.Size(94, 17);
            this.checkBoxIsIntruder.TabIndex = 10;
            this.checkBoxIsIntruder.Text = "Нарушитель?";
            this.checkBoxIsIntruder.UseVisualStyleBackColor = true;
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 101);
            this.Controls.Add(this.checkBoxIsIntruder);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.comboBoxIDAuto);
            this.Controls.Add(this.labelIDAuto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriverForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ComboBox comboBoxIDAuto;
        private System.Windows.Forms.Label labelIDAuto;
        private System.Windows.Forms.CheckBox checkBoxIsIntruder;
    }
}