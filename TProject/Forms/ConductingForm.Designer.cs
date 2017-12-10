namespace TProject.Forms
{
    partial class ConductingForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.labelNameMapSave = new System.Windows.Forms.Label();
            this.comboBoxNames = new System.Windows.Forms.ComboBox();
            this.pictureBoxMiniMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiniMap)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(249, 218);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(330, 217);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // textBoxMapName
            // 
            this.textBoxMapName.Location = new System.Drawing.Point(12, 21);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(393, 20);
            this.textBoxMapName.TabIndex = 0;
            // 
            // labelNameMapSave
            // 
            this.labelNameMapSave.AutoSize = true;
            this.labelNameMapSave.Location = new System.Drawing.Point(12, 5);
            this.labelNameMapSave.Name = "labelNameMapSave";
            this.labelNameMapSave.Size = new System.Drawing.Size(227, 13);
            this.labelNameMapSave.TabIndex = 3;
            this.labelNameMapSave.Text = "Введите имя карты перед её сохранением:";
            // 
            // comboBoxNames
            // 
            this.comboBoxNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNames.FormattingEnabled = true;
            this.comboBoxNames.Location = new System.Drawing.Point(12, 21);
            this.comboBoxNames.Name = "comboBoxNames";
            this.comboBoxNames.Size = new System.Drawing.Size(393, 21);
            this.comboBoxNames.TabIndex = 0;
            this.comboBoxNames.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNames_SelectedIndexChanged);
            // 
            // pictureBoxMiniMap
            // 
            this.pictureBoxMiniMap.Location = new System.Drawing.Point(12, 47);
            this.pictureBoxMiniMap.Name = "pictureBoxMiniMap";
            this.pictureBoxMiniMap.Size = new System.Drawing.Size(393, 164);
            this.pictureBoxMiniMap.TabIndex = 4;
            this.pictureBoxMiniMap.TabStop = false;
            // 
            // SaveAs
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(417, 245);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxMiniMap);
            this.Controls.Add(this.comboBoxNames);
            this.Controls.Add(this.labelNameMapSave);
            this.Controls.Add(this.textBoxMapName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveAs";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохранить как...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SaveAs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMiniMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.Label labelNameMapSave;
        private System.Windows.Forms.ComboBox comboBoxNames;
        private System.Windows.Forms.PictureBox pictureBoxMiniMap;
    }
}