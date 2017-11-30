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
            this.textBoxValueFine = new System.Windows.Forms.TextBox();
            this.textBoxNameFine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(173, 67);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 11;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValue.Location = new System.Drawing.Point(12, 37);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(105, 16);
            this.labelValue.TabIndex = 10;
            this.labelValue.Text = "Сумма штрафа";
            // 
            // textBoxValueFine
            // 
            this.textBoxValueFine.Location = new System.Drawing.Point(123, 37);
            this.textBoxValueFine.Name = "textBoxValueFine";
            this.textBoxValueFine.Size = new System.Drawing.Size(125, 20);
            this.textBoxValueFine.TabIndex = 9;
            // 
            // textBoxNameFine
            // 
            this.textBoxNameFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameFine.Location = new System.Drawing.Point(124, 9);
            this.textBoxNameFine.Name = "textBoxNameFine";
            this.textBoxNameFine.Size = new System.Drawing.Size(125, 22);
            this.textBoxNameFine.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(74, 16);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Название";
            // 
            // FineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 96);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.textBoxValueFine);
            this.Controls.Add(this.textBoxNameFine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FineForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValueFine;
        private System.Windows.Forms.TextBox textBoxNameFine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelName;
    }
}