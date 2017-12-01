namespace TProject.Forms
{
    partial class SystemInfoForm
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
            this.systenInfoButton = new System.Windows.Forms.Button();
            this.systenInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // systenInfoButton
            // 
            this.systenInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.systenInfoButton.Location = new System.Drawing.Point(444, 259);
            this.systenInfoButton.Name = "systenInfoButton";
            this.systenInfoButton.Size = new System.Drawing.Size(75, 23);
            this.systenInfoButton.TabIndex = 2;
            this.systenInfoButton.Text = "Ок";
            this.systenInfoButton.UseVisualStyleBackColor = true;
            // 
            // systenInfoRichTextBox
            // 
            this.systenInfoRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.systenInfoRichTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.systenInfoRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.systenInfoRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.systenInfoRichTextBox.Name = "systenInfoRichTextBox";
            this.systenInfoRichTextBox.Size = new System.Drawing.Size(507, 241);
            this.systenInfoRichTextBox.TabIndex = 3;
            this.systenInfoRichTextBox.Text = "";
            // 
            // SystemInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 294);
            this.Controls.Add(this.systenInfoRichTextBox);
            this.Controls.Add(this.systenInfoButton);
            this.Name = "SystemInfoForm";
            this.ShowIcon = false;
            this.Text = "Сведения о системе";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button systenInfoButton;
        private System.Windows.Forms.RichTextBox systenInfoRichTextBox;
    }
}