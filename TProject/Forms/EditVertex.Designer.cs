namespace TProject
{
    partial class EditVertex
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
            this.okEditCrossroadButton = new System.Windows.Forms.Button();
            this.cancelEditCrossroadButton = new System.Windows.Forms.Button();
            this.crossroadGroupBox = new System.Windows.Forms.GroupBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.timeGreenLightComboBox = new System.Windows.Forms.MaskedTextBox();
            this.timeRedLightComboBox = new System.Windows.Forms.MaskedTextBox();
            this.timeGreenLightLabel = new System.Windows.Forms.Label();
            this.timeRedLightLabel = new System.Windows.Forms.Label();
            this.trafficlightCheckBox = new System.Windows.Forms.CheckBox();
            this.crossroadGroupBox.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // okEditCrossroadButton
            // 
            this.okEditCrossroadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okEditCrossroadButton.Location = new System.Drawing.Point(143, 135);
            this.okEditCrossroadButton.Name = "okEditCrossroadButton";
            this.okEditCrossroadButton.Size = new System.Drawing.Size(75, 25);
            this.okEditCrossroadButton.TabIndex = 3;
            this.okEditCrossroadButton.Text = "Ок";
            this.okEditCrossroadButton.UseVisualStyleBackColor = true;
            this.okEditCrossroadButton.Click += new System.EventHandler(this.OkEditCrossroadButton_Click);
            // 
            // cancelEditCrossroadButton
            // 
            this.cancelEditCrossroadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEditCrossroadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelEditCrossroadButton.Location = new System.Drawing.Point(224, 135);
            this.cancelEditCrossroadButton.Name = "cancelEditCrossroadButton";
            this.cancelEditCrossroadButton.Size = new System.Drawing.Size(75, 25);
            this.cancelEditCrossroadButton.TabIndex = 4;
            this.cancelEditCrossroadButton.Text = "Отмена";
            this.cancelEditCrossroadButton.UseVisualStyleBackColor = true;
            this.cancelEditCrossroadButton.Click += new System.EventHandler(this.CancelEditCrossroadButton_Click);
            // 
            // crossroadGroupBox
            // 
            this.crossroadGroupBox.Controls.Add(this.panelContainer);
            this.crossroadGroupBox.Controls.Add(this.trafficlightCheckBox);
            this.crossroadGroupBox.Location = new System.Drawing.Point(12, 12);
            this.crossroadGroupBox.Name = "crossroadGroupBox";
            this.crossroadGroupBox.Size = new System.Drawing.Size(287, 118);
            this.crossroadGroupBox.TabIndex = 5;
            this.crossroadGroupBox.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.timeGreenLightComboBox);
            this.panelContainer.Controls.Add(this.timeRedLightComboBox);
            this.panelContainer.Controls.Add(this.timeGreenLightLabel);
            this.panelContainer.Controls.Add(this.timeRedLightLabel);
            this.panelContainer.Location = new System.Drawing.Point(6, 19);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(275, 93);
            this.panelContainer.TabIndex = 5;
            // 
            // timeGreenLightComboBox
            // 
            this.timeGreenLightComboBox.Location = new System.Drawing.Point(196, 25);
            this.timeGreenLightComboBox.Mask = "000";
            this.timeGreenLightComboBox.Name = "timeGreenLightComboBox";
            this.timeGreenLightComboBox.Size = new System.Drawing.Size(76, 20);
            this.timeGreenLightComboBox.TabIndex = 1;
            // 
            // timeRedLightComboBox
            // 
            this.timeRedLightComboBox.Location = new System.Drawing.Point(196, 59);
            this.timeRedLightComboBox.Mask = "000";
            this.timeRedLightComboBox.Name = "timeRedLightComboBox";
            this.timeRedLightComboBox.Size = new System.Drawing.Size(76, 20);
            this.timeRedLightComboBox.TabIndex = 2;
            // 
            // timeGreenLightLabel
            // 
            this.timeGreenLightLabel.AutoSize = true;
            this.timeGreenLightLabel.Location = new System.Drawing.Point(1, 25);
            this.timeGreenLightLabel.Name = "timeGreenLightLabel";
            this.timeGreenLightLabel.Size = new System.Drawing.Size(189, 13);
            this.timeGreenLightLabel.TabIndex = 6;
            this.timeGreenLightLabel.Text = "Светофорная фаза зеленого света:";
            // 
            // timeRedLightLabel
            // 
            this.timeRedLightLabel.AutoSize = true;
            this.timeRedLightLabel.Location = new System.Drawing.Point(1, 62);
            this.timeRedLightLabel.Name = "timeRedLightLabel";
            this.timeRedLightLabel.Size = new System.Drawing.Size(189, 13);
            this.timeRedLightLabel.TabIndex = 7;
            this.timeRedLightLabel.Text = "Светофорная фаза красного света:";
            // 
            // trafficlightCheckBox
            // 
            this.trafficlightCheckBox.AutoSize = true;
            this.trafficlightCheckBox.Location = new System.Drawing.Point(6, 0);
            this.trafficlightCheckBox.Name = "trafficlightCheckBox";
            this.trafficlightCheckBox.Size = new System.Drawing.Size(127, 17);
            this.trafficlightCheckBox.TabIndex = 0;
            this.trafficlightCheckBox.Text = "Наличие светофора";
            this.trafficlightCheckBox.UseVisualStyleBackColor = true;
            this.trafficlightCheckBox.CheckedChanged += new System.EventHandler(this.TrafficlightCheckBox_CheckedChanged);
            // 
            // EditVertex
            // 
            this.AcceptButton = this.okEditCrossroadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelEditCrossroadButton;
            this.ClientSize = new System.Drawing.Size(311, 172);
            this.ControlBox = false;
            this.Controls.Add(this.okEditCrossroadButton);
            this.Controls.Add(this.cancelEditCrossroadButton);
            this.Controls.Add(this.crossroadGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(327, 211);
            this.MinimizeBox = false;
            this.Name = "EditVertex";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры перекрестка";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditVertex_Load);
            this.crossroadGroupBox.ResumeLayout(false);
            this.crossroadGroupBox.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okEditCrossroadButton;
        private System.Windows.Forms.Button cancelEditCrossroadButton;
        private System.Windows.Forms.GroupBox crossroadGroupBox;
        private System.Windows.Forms.Label timeRedLightLabel;
        private System.Windows.Forms.Label timeGreenLightLabel;
        private System.Windows.Forms.CheckBox trafficlightCheckBox;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.MaskedTextBox timeGreenLightComboBox;
        private System.Windows.Forms.MaskedTextBox timeRedLightComboBox;
    }
}