namespace TProject.Forms
{
    partial class FirstForm
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
            this.firstChoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.createNewButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.firstChoiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstChoiceGroupBox
            // 
            this.firstChoiceGroupBox.Controls.Add(this.createNewButton);
            this.firstChoiceGroupBox.Controls.Add(this.openButton);
            this.firstChoiceGroupBox.Location = new System.Drawing.Point(12, 12);
            this.firstChoiceGroupBox.Name = "firstChoiceGroupBox";
            this.firstChoiceGroupBox.Size = new System.Drawing.Size(260, 157);
            this.firstChoiceGroupBox.TabIndex = 1;
            this.firstChoiceGroupBox.TabStop = false;
            // 
            // createNewButton
            // 
            this.createNewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createNewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.createNewButton.Location = new System.Drawing.Point(3, 16);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(254, 70);
            this.createNewButton.TabIndex = 2;
            this.createNewButton.Text = "Создать новую";
            this.createNewButton.UseVisualStyleBackColor = true;
            // 
            // openButton
            // 
            this.openButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.openButton.Location = new System.Drawing.Point(3, 94);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(254, 60);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Открыть существующую";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 180);
            this.Controls.Add(this.firstChoiceGroupBox);
            this.Name = "FirstForm";
            this.Text = "Выберети действие";
            this.firstChoiceGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox firstChoiceGroupBox;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.Button openButton;
    }
}