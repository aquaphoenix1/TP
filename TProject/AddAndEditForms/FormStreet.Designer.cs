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
            this.textBoxNameStreet.Location = new System.Drawing.Point(139, 7);
            this.textBoxNameStreet.Name = "textBoxNameStreet";
            this.textBoxNameStreet.Size = new System.Drawing.Size(189, 23);
            this.textBoxNameStreet.TabIndex = 0;
            this.textBoxNameStreet.TextChanged += new System.EventHandler(this.TextBoxNameStreet_TextChanged);
            this.textBoxNameStreet.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxNameStreet_KeyUp);
            // 
            // labelNameStreet
            // 
            this.labelNameStreet.AutoSize = true;
            this.labelNameStreet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelNameStreet.Location = new System.Drawing.Point(14, 10);
            this.labelNameStreet.Name = "labelNameStreet";
            this.labelNameStreet.Size = new System.Drawing.Size(101, 15);
            this.labelNameStreet.TabIndex = 2;
            this.labelNameStreet.Text = "Название улицы:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(241, 37);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(87, 27);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // FormStreet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 74);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelNameStreet);
            this.Controls.Add(this.textBoxNameStreet);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStreet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры улицы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameStreet;
        private System.Windows.Forms.Label labelNameStreet;
        private System.Windows.Forms.Button buttonAccept;
    }
}