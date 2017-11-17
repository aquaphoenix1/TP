﻿namespace TProject
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
            this.timeRedLightLabel = new System.Windows.Forms.Label();
            this.timeGreenLightLabel = new System.Windows.Forms.Label();
            this.timeRedLightComboBox = new System.Windows.Forms.ComboBox();
            this.timeGreenLightComboBox = new System.Windows.Forms.ComboBox();
            this.trafficlightCheckBox = new System.Windows.Forms.CheckBox();
            this.crossroadGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okEditCrossroadButton
            // 
            this.okEditCrossroadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okEditCrossroadButton.Location = new System.Drawing.Point(143, 135);
            this.okEditCrossroadButton.Name = "okEditCrossroadButton";
            this.okEditCrossroadButton.Size = new System.Drawing.Size(75, 25);
            this.okEditCrossroadButton.TabIndex = 5;
            this.okEditCrossroadButton.Text = "Ок";
            this.okEditCrossroadButton.UseVisualStyleBackColor = true;
            this.okEditCrossroadButton.Click += new System.EventHandler(this.okEditCrossroadButton_Click);
            // 
            // cancelEditCrossroadButton
            // 
            this.cancelEditCrossroadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEditCrossroadButton.Location = new System.Drawing.Point(224, 135);
            this.cancelEditCrossroadButton.Name = "cancelEditCrossroadButton";
            this.cancelEditCrossroadButton.Size = new System.Drawing.Size(75, 25);
            this.cancelEditCrossroadButton.TabIndex = 4;
            this.cancelEditCrossroadButton.Text = "Отмена";
            this.cancelEditCrossroadButton.UseVisualStyleBackColor = true;
            // 
            // crossroadGroupBox
            // 
            this.crossroadGroupBox.Controls.Add(this.timeRedLightLabel);
            this.crossroadGroupBox.Controls.Add(this.timeGreenLightLabel);
            this.crossroadGroupBox.Controls.Add(this.timeRedLightComboBox);
            this.crossroadGroupBox.Controls.Add(this.timeGreenLightComboBox);
            this.crossroadGroupBox.Controls.Add(this.trafficlightCheckBox);
            this.crossroadGroupBox.Location = new System.Drawing.Point(12, 12);
            this.crossroadGroupBox.Name = "crossroadGroupBox";
            this.crossroadGroupBox.Size = new System.Drawing.Size(287, 118);
            this.crossroadGroupBox.TabIndex = 3;
            this.crossroadGroupBox.TabStop = false;
            // 
            // timeRedLightLabel
            // 
            this.timeRedLightLabel.AutoSize = true;
            this.timeRedLightLabel.Location = new System.Drawing.Point(6, 79);
            this.timeRedLightLabel.Name = "timeRedLightLabel";
            this.timeRedLightLabel.Size = new System.Drawing.Size(189, 13);
            this.timeRedLightLabel.TabIndex = 4;
            this.timeRedLightLabel.Text = "Светофорная фаза красного света:";
            // 
            // timeGreenLightLabel
            // 
            this.timeGreenLightLabel.AutoSize = true;
            this.timeGreenLightLabel.Location = new System.Drawing.Point(6, 35);
            this.timeGreenLightLabel.Name = "timeGreenLightLabel";
            this.timeGreenLightLabel.Size = new System.Drawing.Size(189, 13);
            this.timeGreenLightLabel.TabIndex = 3;
            this.timeGreenLightLabel.Text = "Светофорная фаза зеленого света:";
            // 
            // timeRedLightComboBox
            // 
            this.timeRedLightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeRedLightComboBox.FormattingEnabled = true;
            this.timeRedLightComboBox.Items.AddRange(new object[] {
            "20"});
            this.timeRedLightComboBox.Location = new System.Drawing.Point(201, 76);
            this.timeRedLightComboBox.Name = "timeRedLightComboBox";
            this.timeRedLightComboBox.Size = new System.Drawing.Size(77, 21);
            this.timeRedLightComboBox.TabIndex = 2;
            // 
            // timeGreenLightComboBox
            // 
            this.timeGreenLightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeGreenLightComboBox.FormattingEnabled = true;
            this.timeGreenLightComboBox.Items.AddRange(new object[] {
            "10"});
            this.timeGreenLightComboBox.Location = new System.Drawing.Point(201, 32);
            this.timeGreenLightComboBox.Name = "timeGreenLightComboBox";
            this.timeGreenLightComboBox.Size = new System.Drawing.Size(77, 21);
            this.timeGreenLightComboBox.TabIndex = 1;
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
            // 
            // EditVertex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 172);
            this.ControlBox = false;
            this.Controls.Add(this.okEditCrossroadButton);
            this.Controls.Add(this.cancelEditCrossroadButton);
            this.Controls.Add(this.crossroadGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(327, 211);
            this.MinimizeBox = false;
            this.Name = "EditVertex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры перекрестка";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditVertex_Load);
            this.crossroadGroupBox.ResumeLayout(false);
            this.crossroadGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okEditCrossroadButton;
        private System.Windows.Forms.Button cancelEditCrossroadButton;
        private System.Windows.Forms.GroupBox crossroadGroupBox;
        private System.Windows.Forms.Label timeRedLightLabel;
        private System.Windows.Forms.Label timeGreenLightLabel;
        private System.Windows.Forms.ComboBox timeRedLightComboBox;
        private System.Windows.Forms.ComboBox timeGreenLightComboBox;
        private System.Windows.Forms.CheckBox trafficlightCheckBox;
    }
}