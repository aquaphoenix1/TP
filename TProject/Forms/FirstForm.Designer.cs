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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.removeButton = new System.Windows.Forms.Button();
            this.createNewButton = new System.Windows.Forms.Button();
            this.firstChoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.openButton = new System.Windows.Forms.Button();
            this.firstChoiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPEG|*.JPG|JPEG|*.JPEG";
            // 
            // removeButton
            // 
            this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.removeButton.Location = new System.Drawing.Point(3, 146);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(254, 60);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Удалить карты";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // createNewButton
            // 
            this.createNewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createNewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.createNewButton.Location = new System.Drawing.Point(3, 16);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(254, 70);
            this.createNewButton.TabIndex = 0;
            this.createNewButton.Text = "Создать новую";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += new System.EventHandler(this.CreateNewButton_Click);
            // 
            // firstChoiceGroupBox
            // 
            this.firstChoiceGroupBox.Controls.Add(this.openButton);
            this.firstChoiceGroupBox.Controls.Add(this.createNewButton);
            this.firstChoiceGroupBox.Controls.Add(this.removeButton);
            this.firstChoiceGroupBox.Location = new System.Drawing.Point(12, 12);
            this.firstChoiceGroupBox.Name = "firstChoiceGroupBox";
            this.firstChoiceGroupBox.Size = new System.Drawing.Size(260, 209);
            this.firstChoiceGroupBox.TabIndex = 3;
            this.firstChoiceGroupBox.TabStop = false;
            // 
            // openButton
            // 
            this.openButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.openButton.Location = new System.Drawing.Point(3, 86);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(254, 60);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Открыть существующую";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.firstChoiceGroupBox);
            this.Name = "FirstForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите действие";
            this.firstChoiceGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.GroupBox firstChoiceGroupBox;
        private System.Windows.Forms.Button openButton;
    }
}