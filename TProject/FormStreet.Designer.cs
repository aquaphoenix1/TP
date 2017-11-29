namespace TProject
{
    partial class FormStreet
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
            this.textBoxNameStreet = new System.Windows.Forms.TextBox();
            this.labelNameStreet = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNameStreet
            // 
            this.textBoxNameStreet.Location = new System.Drawing.Point(109, 6);
            this.textBoxNameStreet.Name = "textBoxNameStreet";
            this.textBoxNameStreet.Size = new System.Drawing.Size(163, 20);
            this.textBoxNameStreet.TabIndex = 0;
            // 
            // labelNameStreet
            // 
            this.labelNameStreet.AutoSize = true;
            this.labelNameStreet.Location = new System.Drawing.Point(12, 9);
            this.labelNameStreet.Name = "labelNameStreet";
            this.labelNameStreet.Size = new System.Drawing.Size(91, 13);
            this.labelNameStreet.TabIndex = 1;
            this.labelNameStreet.Text = "Название улицы";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(197, 32);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // FormStreet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 64);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelNameStreet);
            this.Controls.Add(this.textBoxNameStreet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStreet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStreet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameStreet;
        private System.Windows.Forms.Label labelNameStreet;
        private System.Windows.Forms.Button buttonAccept;
    }
}