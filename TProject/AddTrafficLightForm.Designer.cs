namespace TProject
{
    partial class AddTrafficLightForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelRedLightSeconds = new System.Windows.Forms.Label();
            this.textBoxRedSeconds = new System.Windows.Forms.TextBox();
            this.labelGreenLightSeconds = new System.Windows.Forms.Label();
            this.textBoxGreenSeconds = new System.Windows.Forms.TextBox();
            this.richTextBoxStreetName = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(9, 109);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(153, 109);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelRedLightSeconds
            // 
            this.labelRedLightSeconds.AutoSize = true;
            this.labelRedLightSeconds.Location = new System.Drawing.Point(90, 43);
            this.labelRedLightSeconds.Name = "labelRedLightSeconds";
            this.labelRedLightSeconds.Size = new System.Drawing.Size(148, 13);
            this.labelRedLightSeconds.TabIndex = 6;
            this.labelRedLightSeconds.Text = "Время красного светофора";
            // 
            // textBoxRedSeconds
            // 
            this.textBoxRedSeconds.Location = new System.Drawing.Point(12, 40);
            this.textBoxRedSeconds.Name = "textBoxRedSeconds";
            this.textBoxRedSeconds.Size = new System.Drawing.Size(72, 20);
            this.textBoxRedSeconds.TabIndex = 0;
            // 
            // labelGreenLightSeconds
            // 
            this.labelGreenLightSeconds.AutoSize = true;
            this.labelGreenLightSeconds.Location = new System.Drawing.Point(90, 76);
            this.labelGreenLightSeconds.Name = "labelGreenLightSeconds";
            this.labelGreenLightSeconds.Size = new System.Drawing.Size(148, 13);
            this.labelGreenLightSeconds.TabIndex = 5;
            this.labelGreenLightSeconds.Text = "Время зеленого светофора";
            // 
            // textBoxGreenSeconds
            // 
            this.textBoxGreenSeconds.Location = new System.Drawing.Point(12, 73);
            this.textBoxGreenSeconds.Name = "textBoxGreenSeconds";
            this.textBoxGreenSeconds.Size = new System.Drawing.Size(72, 20);
            this.textBoxGreenSeconds.TabIndex = 1;
            // 
            // richTextBoxStreetName
            // 
            this.richTextBoxStreetName.Location = new System.Drawing.Point(12, 3);
            this.richTextBoxStreetName.Name = "richTextBoxStreetName";
            this.richTextBoxStreetName.ReadOnly = true;
            this.richTextBoxStreetName.Size = new System.Drawing.Size(216, 31);
            this.richTextBoxStreetName.TabIndex = 4;
            this.richTextBoxStreetName.Text = "";
            // 
            // AddTrafficLightForm
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(240, 143);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBoxStreetName);
            this.Controls.Add(this.textBoxGreenSeconds);
            this.Controls.Add(this.labelGreenLightSeconds);
            this.Controls.Add(this.textBoxRedSeconds);
            this.Controls.Add(this.labelRedLightSeconds);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Name = "AddTrafficLightForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый светофор";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelRedLightSeconds;
        private System.Windows.Forms.TextBox textBoxRedSeconds;
        private System.Windows.Forms.Label labelGreenLightSeconds;
        private System.Windows.Forms.TextBox textBoxGreenSeconds;
        private System.Windows.Forms.RichTextBox richTextBoxStreetName;
    }
}