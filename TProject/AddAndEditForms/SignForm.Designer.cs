namespace TProject
{
    partial class SignForm
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
            this.textBoxValueSign = new System.Windows.Forms.TextBox();
            this.textBoxTypeSign = new System.Windows.Forms.TextBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(133, 61);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(86, 29);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // textBoxValueSign
            // 
            this.textBoxValueSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxValueSign.Location = new System.Drawing.Point(115, 33);
            this.textBoxValueSign.Name = "textBoxValueSign";
            this.textBoxValueSign.Size = new System.Drawing.Size(100, 22);
            this.textBoxValueSign.TabIndex = 8;
            // 
            // textBoxTypeSign
            // 
            this.textBoxTypeSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTypeSign.Location = new System.Drawing.Point(115, 9);
            this.textBoxTypeSign.Name = "textBoxTypeSign";
            this.textBoxTypeSign.Size = new System.Drawing.Size(100, 22);
            this.textBoxTypeSign.TabIndex = 7;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValue.Location = new System.Drawing.Point(12, 36);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(73, 16);
            this.labelValue.TabIndex = 6;
            this.labelValue.Text = "Величина";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.Location = new System.Drawing.Point(12, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(36, 16);
            this.labelType.TabIndex = 5;
            this.labelType.Text = "Тип ";
            // 
            // SignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 96);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxValueSign);
            this.Controls.Add(this.textBoxTypeSign);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelType);
            this.Name = "SignForm";
            this.Text = "SignForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxValueSign;
        private System.Windows.Forms.TextBox textBoxTypeSign;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelType;
    }
}