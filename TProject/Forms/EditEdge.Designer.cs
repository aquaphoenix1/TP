﻿namespace TProject
{
    partial class EditEdge
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
            this.signGroupBox = new System.Windows.Forms.GroupBox();
            this.signMaxSpeedLabel = new System.Windows.Forms.Label();
            this.signMaxSpeedCheckBox = new System.Windows.Forms.CheckBox();
            this.signOneWayCheckBox = new System.Windows.Forms.CheckBox();
            this.signMaxSpeedKindabel = new System.Windows.Forms.Label();
            this.signMaxSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.signOneWayLabel = new System.Windows.Forms.Label();
            this.streetGroupBox = new System.Windows.Forms.GroupBox();
            this.coatingLabel = new System.Windows.Forms.Label();
            this.nameStreetComboBox = new System.Windows.Forms.ComboBox();
            this.coatingComboBox = new System.Windows.Forms.ComboBox();
            this.nameStreetLabel = new System.Windows.Forms.Label();
            this.okEditEgdeButton = new System.Windows.Forms.Button();
            this.cancelEditEgdeButton = new System.Windows.Forms.Button();
            this.policemanGroupBox = new System.Windows.Forms.GroupBox();
            this.policemanCheckBox = new System.Windows.Forms.CheckBox();
            this.policemanLabel = new System.Windows.Forms.Label();
            this.policemanComboBox = new System.Windows.Forms.ComboBox();
            this.signGroupBox.SuspendLayout();
            this.streetGroupBox.SuspendLayout();
            this.policemanGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // signGroupBox
            // 
            this.signGroupBox.Controls.Add(this.signMaxSpeedLabel);
            this.signGroupBox.Controls.Add(this.signMaxSpeedCheckBox);
            this.signGroupBox.Controls.Add(this.signOneWayCheckBox);
            this.signGroupBox.Controls.Add(this.signMaxSpeedKindabel);
            this.signGroupBox.Controls.Add(this.signMaxSpeedComboBox);
            this.signGroupBox.Controls.Add(this.signOneWayLabel);
            this.signGroupBox.Location = new System.Drawing.Point(12, 167);
            this.signGroupBox.Name = "signGroupBox";
            this.signGroupBox.Size = new System.Drawing.Size(354, 91);
            this.signGroupBox.TabIndex = 16;
            this.signGroupBox.TabStop = false;
            // 
            // signMaxSpeedLabel
            // 
            this.signMaxSpeedLabel.AutoSize = true;
            this.signMaxSpeedLabel.Location = new System.Drawing.Point(4, 41);
            this.signMaxSpeedLabel.Name = "signMaxSpeedLabel";
            this.signMaxSpeedLabel.Size = new System.Drawing.Size(294, 13);
            this.signMaxSpeedLabel.TabIndex = 13;
            this.signMaxSpeedLabel.Text = "Наличие знака \"Ограничение максимальной скорости\":";
            // 
            // signMaxSpeedCheckBox
            // 
            this.signMaxSpeedCheckBox.AutoSize = true;
            this.signMaxSpeedCheckBox.Location = new System.Drawing.Point(333, 41);
            this.signMaxSpeedCheckBox.Name = "signMaxSpeedCheckBox";
            this.signMaxSpeedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.signMaxSpeedCheckBox.TabIndex = 5;
            this.signMaxSpeedCheckBox.UseVisualStyleBackColor = true;
            this.signMaxSpeedCheckBox.CheckedChanged += new System.EventHandler(this.SignMaxSpeedCheckBox_CheckedChanged);
            // 
            // signOneWayCheckBox
            // 
            this.signOneWayCheckBox.AutoSize = true;
            this.signOneWayCheckBox.Location = new System.Drawing.Point(333, 16);
            this.signOneWayCheckBox.Name = "signOneWayCheckBox";
            this.signOneWayCheckBox.Size = new System.Drawing.Size(15, 14);
            this.signOneWayCheckBox.TabIndex = 4;
            this.signOneWayCheckBox.UseVisualStyleBackColor = true;
            // 
            // signMaxSpeedKindabel
            // 
            this.signMaxSpeedKindabel.AutoSize = true;
            this.signMaxSpeedKindabel.Location = new System.Drawing.Point(4, 66);
            this.signMaxSpeedKindabel.Name = "signMaxSpeedKindabel";
            this.signMaxSpeedKindabel.Size = new System.Drawing.Size(205, 13);
            this.signMaxSpeedKindabel.TabIndex = 14;
            this.signMaxSpeedKindabel.Text = "Ограничение максимальной скорости:";
            // 
            // signMaxSpeedComboBox
            // 
            this.signMaxSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.signMaxSpeedComboBox.FormattingEnabled = true;
            this.signMaxSpeedComboBox.Location = new System.Drawing.Point(279, 63);
            this.signMaxSpeedComboBox.Name = "signMaxSpeedComboBox";
            this.signMaxSpeedComboBox.Size = new System.Drawing.Size(66, 21);
            this.signMaxSpeedComboBox.TabIndex = 6;
            // 
            // signOneWayLabel
            // 
            this.signOneWayLabel.AutoSize = true;
            this.signOneWayLabel.Location = new System.Drawing.Point(4, 16);
            this.signOneWayLabel.Name = "signOneWayLabel";
            this.signOneWayLabel.Size = new System.Drawing.Size(231, 13);
            this.signOneWayLabel.TabIndex = 12;
            this.signOneWayLabel.Text = "Наличие знака \"Одностороннее движение\":";
            // 
            // streetGroupBox
            // 
            this.streetGroupBox.Controls.Add(this.coatingLabel);
            this.streetGroupBox.Controls.Add(this.nameStreetComboBox);
            this.streetGroupBox.Controls.Add(this.coatingComboBox);
            this.streetGroupBox.Controls.Add(this.nameStreetLabel);
            this.streetGroupBox.Location = new System.Drawing.Point(12, 12);
            this.streetGroupBox.Name = "streetGroupBox";
            this.streetGroupBox.Size = new System.Drawing.Size(354, 82);
            this.streetGroupBox.TabIndex = 15;
            this.streetGroupBox.TabStop = false;
            // 
            // coatingLabel
            // 
            this.coatingLabel.AutoSize = true;
            this.coatingLabel.Location = new System.Drawing.Point(13, 50);
            this.coatingLabel.Name = "coatingLabel";
            this.coatingLabel.Size = new System.Drawing.Size(139, 13);
            this.coatingLabel.TabIndex = 10;
            this.coatingLabel.Text = "Тип дорожного покрытия:";
            // 
            // nameStreetComboBox
            // 
            this.nameStreetComboBox.CausesValidation = false;
            this.nameStreetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameStreetComboBox.FormattingEnabled = true;
            this.nameStreetComboBox.Location = new System.Drawing.Point(160, 13);
            this.nameStreetComboBox.Name = "nameStreetComboBox";
            this.nameStreetComboBox.Size = new System.Drawing.Size(185, 21);
            this.nameStreetComboBox.TabIndex = 0;
            // 
            // coatingComboBox
            // 
            this.coatingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coatingComboBox.FormattingEnabled = true;
            this.coatingComboBox.Location = new System.Drawing.Point(160, 47);
            this.coatingComboBox.Name = "coatingComboBox";
            this.coatingComboBox.Size = new System.Drawing.Size(185, 21);
            this.coatingComboBox.TabIndex = 1;
            // 
            // nameStreetLabel
            // 
            this.nameStreetLabel.AutoSize = true;
            this.nameStreetLabel.Location = new System.Drawing.Point(13, 16);
            this.nameStreetLabel.Name = "nameStreetLabel";
            this.nameStreetLabel.Size = new System.Drawing.Size(94, 13);
            this.nameStreetLabel.TabIndex = 9;
            this.nameStreetLabel.Text = "Название улицы:";
            // 
            // okEditEgdeButton
            // 
            this.okEditEgdeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okEditEgdeButton.Location = new System.Drawing.Point(212, 267);
            this.okEditEgdeButton.Name = "okEditEgdeButton";
            this.okEditEgdeButton.Size = new System.Drawing.Size(75, 25);
            this.okEditEgdeButton.TabIndex = 7;
            this.okEditEgdeButton.Text = "Ок";
            this.okEditEgdeButton.UseVisualStyleBackColor = true;
            this.okEditEgdeButton.Click += new System.EventHandler(this.OkEditEgdeButton_Click);
            // 
            // cancelEditEgdeButton
            // 
            this.cancelEditEgdeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEditEgdeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelEditEgdeButton.Location = new System.Drawing.Point(293, 267);
            this.cancelEditEgdeButton.Name = "cancelEditEgdeButton";
            this.cancelEditEgdeButton.Size = new System.Drawing.Size(75, 25);
            this.cancelEditEgdeButton.TabIndex = 8;
            this.cancelEditEgdeButton.Text = "Отмена";
            this.cancelEditEgdeButton.UseVisualStyleBackColor = true;
            this.cancelEditEgdeButton.Click += new System.EventHandler(this.CancelEditEgdeButton_Click);
            // 
            // policemanGroupBox
            // 
            this.policemanGroupBox.Controls.Add(this.policemanCheckBox);
            this.policemanGroupBox.Controls.Add(this.policemanLabel);
            this.policemanGroupBox.Controls.Add(this.policemanComboBox);
            this.policemanGroupBox.Location = new System.Drawing.Point(12, 100);
            this.policemanGroupBox.Name = "policemanGroupBox";
            this.policemanGroupBox.Size = new System.Drawing.Size(354, 61);
            this.policemanGroupBox.TabIndex = 16;
            this.policemanGroupBox.TabStop = false;
            // 
            // policemanCheckBox
            // 
            this.policemanCheckBox.AutoSize = true;
            this.policemanCheckBox.Location = new System.Drawing.Point(9, 0);
            this.policemanCheckBox.Name = "policemanCheckBox";
            this.policemanCheckBox.Size = new System.Drawing.Size(143, 17);
            this.policemanCheckBox.TabIndex = 2;
            this.policemanCheckBox.Text = "Наличие полицейского";
            this.policemanCheckBox.UseVisualStyleBackColor = true;
            this.policemanCheckBox.CheckedChanged += new System.EventHandler(this.PolicemanCheckBox_CheckedChanged);
            // 
            // policemanLabel
            // 
            this.policemanLabel.AutoSize = true;
            this.policemanLabel.Location = new System.Drawing.Point(6, 27);
            this.policemanLabel.Name = "policemanLabel";
            this.policemanLabel.Size = new System.Drawing.Size(78, 13);
            this.policemanLabel.TabIndex = 11;
            this.policemanLabel.Text = "Полицейский:";
            // 
            // policemanComboBox
            // 
            this.policemanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.policemanComboBox.FormattingEnabled = true;
            this.policemanComboBox.Location = new System.Drawing.Point(160, 24);
            this.policemanComboBox.Name = "policemanComboBox";
            this.policemanComboBox.Size = new System.Drawing.Size(185, 21);
            this.policemanComboBox.TabIndex = 3;
            // 
            // EditEdge
            // 
            this.AcceptButton = this.okEditEgdeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelEditEgdeButton;
            this.ClientSize = new System.Drawing.Size(380, 301);
            this.ControlBox = false;
            this.Controls.Add(this.signGroupBox);
            this.Controls.Add(this.streetGroupBox);
            this.Controls.Add(this.okEditEgdeButton);
            this.Controls.Add(this.cancelEditEgdeButton);
            this.Controls.Add(this.policemanGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(396, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "EditEdge";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры перегона";
            this.signGroupBox.ResumeLayout(false);
            this.signGroupBox.PerformLayout();
            this.streetGroupBox.ResumeLayout(false);
            this.streetGroupBox.PerformLayout();
            this.policemanGroupBox.ResumeLayout(false);
            this.policemanGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox signGroupBox;
        private System.Windows.Forms.Label signMaxSpeedLabel;
        private System.Windows.Forms.CheckBox signMaxSpeedCheckBox;
        private System.Windows.Forms.CheckBox signOneWayCheckBox;
        private System.Windows.Forms.Label signMaxSpeedKindabel;
        private System.Windows.Forms.ComboBox signMaxSpeedComboBox;
        private System.Windows.Forms.Label signOneWayLabel;
        private System.Windows.Forms.GroupBox streetGroupBox;
        private System.Windows.Forms.Label coatingLabel;
        private System.Windows.Forms.ComboBox nameStreetComboBox;
        private System.Windows.Forms.ComboBox coatingComboBox;
        private System.Windows.Forms.Label nameStreetLabel;
        private System.Windows.Forms.Button okEditEgdeButton;
        private System.Windows.Forms.Button cancelEditEgdeButton;
        private System.Windows.Forms.GroupBox policemanGroupBox;
        private System.Windows.Forms.CheckBox policemanCheckBox;
        private System.Windows.Forms.Label policemanLabel;
        private System.Windows.Forms.ComboBox policemanComboBox;
    }
}