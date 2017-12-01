namespace TProject.Forms
{
    partial class ModifyTableForm
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
            this.cancelModifyTableButton = new System.Windows.Forms.Button();
            this.okModifyTableButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelModifyTableButton
            // 
            this.cancelModifyTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelModifyTableButton.Location = new System.Drawing.Point(201, 236);
            this.cancelModifyTableButton.Name = "cancelModifyTableButton";
            this.cancelModifyTableButton.Size = new System.Drawing.Size(75, 23);
            this.cancelModifyTableButton.TabIndex = 12;
            this.cancelModifyTableButton.Tag = "";
            this.cancelModifyTableButton.Text = "Отмена";
            this.cancelModifyTableButton.UseVisualStyleBackColor = true;
            // 
            // okModifyTableButton
            // 
            this.okModifyTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okModifyTableButton.Location = new System.Drawing.Point(120, 236);
            this.okModifyTableButton.Name = "okModifyTableButton";
            this.okModifyTableButton.Size = new System.Drawing.Size(75, 23);
            this.okModifyTableButton.TabIndex = 11;
            this.okModifyTableButton.Text = "Ок";
            this.okModifyTableButton.UseVisualStyleBackColor = true;
            // 
            // ModifyTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 271);
            this.Controls.Add(this.cancelModifyTableButton);
            this.Controls.Add(this.okModifyTableButton);
            this.Name = "ModifyTableForm";
            this.ShowIcon = false;
            this.Text = "Добавление записи";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelModifyTableButton;
        private System.Windows.Forms.Button okModifyTableButton;
    }
}