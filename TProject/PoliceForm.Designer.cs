namespace TProject
{
    partial class PoliceForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxCoefficient = new System.Windows.Forms.TextBox();
            this.textBoxTypePolice = new System.Windows.Forms.TextBox();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.labelTypePolice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(201, 62);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "Применить";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCoefficient.Location = new System.Drawing.Point(154, 34);
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(122, 22);
            this.textBoxCoefficient.TabIndex = 8;
            // 
            // textBoxTypePolice
            // 
            this.textBoxTypePolice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTypePolice.Location = new System.Drawing.Point(154, 6);
            this.textBoxTypePolice.Name = "textBoxTypePolice";
            this.textBoxTypePolice.Size = new System.Drawing.Size(122, 22);
            this.textBoxTypePolice.TabIndex = 7;
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoefficient.Location = new System.Drawing.Point(12, 34);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(101, 16);
            this.labelCoefficient.TabIndex = 6;
            this.labelCoefficient.Text = "Коэффициент";
            // 
            // labelTypePolice
            // 
            this.labelTypePolice.AutoSize = true;
            this.labelTypePolice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTypePolice.Location = new System.Drawing.Point(12, 9);
            this.labelTypePolice.Name = "labelTypePolice";
            this.labelTypePolice.Size = new System.Drawing.Size(128, 16);
            this.labelTypePolice.TabIndex = 5;
            this.labelTypePolice.Text = "Тип полицейского";
            // 
            // PoliceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 91);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxCoefficient);
            this.Controls.Add(this.textBoxTypePolice);
            this.Controls.Add(this.labelCoefficient);
            this.Controls.Add(this.labelTypePolice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PoliceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoliceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxCoefficient;
        private System.Windows.Forms.TextBox textBoxTypePolice;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.Label labelTypePolice;
    }
}