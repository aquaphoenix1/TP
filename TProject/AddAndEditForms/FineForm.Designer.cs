using TProject.AddAndEditForms;

namespace TProject
{
    partial class FineForm
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
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxNameFine = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxValueFine = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(202, 73);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(89, 27);
            this.buttonAccept.TabIndex = 11;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelValue.Location = new System.Drawing.Point(14, 39);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(95, 15);
            this.labelValue.TabIndex = 10;
            this.labelValue.Text = "Сумма штрафа:";
            // 
            // textBoxNameFine
            // 
            this.textBoxNameFine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxNameFine.Location = new System.Drawing.Point(143, 10);
            this.textBoxNameFine.Name = "textBoxNameFine";
            this.textBoxNameFine.Size = new System.Drawing.Size(145, 23);
            this.textBoxNameFine.TabIndex = 8;
            this.textBoxNameFine.TextChanged += new System.EventHandler(this.TextBoxNameFine_TextChanged);
            this.textBoxNameFine.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxNameFine_KeyUp);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelName.Location = new System.Drawing.Point(14, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(62, 15);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Название:";
            // 
            // textBoxValueFine
            // 
            this.textBoxValueFine.Location = new System.Drawing.Point(143, 40);
            this.textBoxValueFine.Mask = "00000.00";
            this.textBoxValueFine.Name = "textBoxValueFine";
            this.textBoxValueFine.Size = new System.Drawing.Size(143, 23);
            this.textBoxValueFine.TabIndex = 12;
            // 
            // FineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 111);
            this.Controls.Add(this.textBoxValueFine);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.textBoxNameFine);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FineForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры штрафа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxNameFine;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.MaskedTextBox textBoxValueFine;
    }
}