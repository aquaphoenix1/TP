namespace TProject
{
    partial class OptionsRouteForm
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
            this.cancelRouteButton = new System.Windows.Forms.Button();
            this.routeGroupBox = new System.Windows.Forms.GroupBox();
            this.driverLabel = new System.Windows.Forms.Label();
            this.critSearchLabel = new System.Windows.Forms.Label();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.critSearchComboBox = new System.Windows.Forms.ComboBox();
            this.okRouteButton = new System.Windows.Forms.Button();
            this.routeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelRouteButton
            // 
            this.cancelRouteButton.Location = new System.Drawing.Point(224, 87);
            this.cancelRouteButton.Name = "cancelRouteButton";
            this.cancelRouteButton.Size = new System.Drawing.Size(75, 25);
            this.cancelRouteButton.TabIndex = 3;
            this.cancelRouteButton.Text = "Отмена";
            this.cancelRouteButton.UseVisualStyleBackColor = true;
            this.cancelRouteButton.Click += new System.EventHandler(this.CancelRouteButton_Click);
            // 
            // routeGroupBox
            // 
            this.routeGroupBox.Controls.Add(this.driverLabel);
            this.routeGroupBox.Controls.Add(this.critSearchLabel);
            this.routeGroupBox.Controls.Add(this.driverComboBox);
            this.routeGroupBox.Controls.Add(this.critSearchComboBox);
            this.routeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.routeGroupBox.Name = "routeGroupBox";
            this.routeGroupBox.Size = new System.Drawing.Size(288, 69);
            this.routeGroupBox.TabIndex = 6;
            this.routeGroupBox.TabStop = false;
            // 
            // driverLabel
            // 
            this.driverLabel.AutoSize = true;
            this.driverLabel.Location = new System.Drawing.Point(6, 16);
            this.driverLabel.Name = "driverLabel";
            this.driverLabel.Size = new System.Drawing.Size(93, 13);
            this.driverLabel.TabIndex = 4;
            this.driverLabel.Text = "Выбор водителя:";
            // 
            // critSearchLabel
            // 
            this.critSearchLabel.AutoSize = true;
            this.critSearchLabel.Location = new System.Drawing.Point(6, 43);
            this.critSearchLabel.Name = "critSearchLabel";
            this.critSearchLabel.Size = new System.Drawing.Size(132, 13);
            this.critSearchLabel.TabIndex = 5;
            this.critSearchLabel.Text = "Выбор критерия поиска:";
            // 
            // driverComboBox
            // 
            this.driverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverComboBox.FormattingEnabled = true;
            this.driverComboBox.Location = new System.Drawing.Point(151, 13);
            this.driverComboBox.Name = "driverComboBox";
            this.driverComboBox.Size = new System.Drawing.Size(131, 21);
            this.driverComboBox.TabIndex = 0;
            // 
            // critSearchComboBox
            // 
            this.critSearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.critSearchComboBox.FormattingEnabled = true;
            this.critSearchComboBox.Items.AddRange(new object[] {
            "Время",
            "Стоимость",
            "Длина"});
            this.critSearchComboBox.Location = new System.Drawing.Point(151, 40);
            this.critSearchComboBox.Name = "critSearchComboBox";
            this.critSearchComboBox.Size = new System.Drawing.Size(131, 21);
            this.critSearchComboBox.TabIndex = 1;
            // 
            // okRouteButton
            // 
            this.okRouteButton.Location = new System.Drawing.Point(146, 87);
            this.okRouteButton.Name = "okRouteButton";
            this.okRouteButton.Size = new System.Drawing.Size(75, 25);
            this.okRouteButton.TabIndex = 2;
            this.okRouteButton.Text = "Ок";
            this.okRouteButton.UseVisualStyleBackColor = true;
            this.okRouteButton.Click += new System.EventHandler(this.OkRouteButton_Click);
            // 
            // OptionsRouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 116);
            this.ControlBox = false;
            this.Controls.Add(this.cancelRouteButton);
            this.Controls.Add(this.routeGroupBox);
            this.Controls.Add(this.okRouteButton);
            this.MaximumSize = new System.Drawing.Size(327, 225);
            this.Name = "OptionsRouteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры маршрута";
            this.routeGroupBox.ResumeLayout(false);
            this.routeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelRouteButton;
        private System.Windows.Forms.GroupBox routeGroupBox;
        private System.Windows.Forms.Label driverLabel;
        private System.Windows.Forms.Label critSearchLabel;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.ComboBox critSearchComboBox;
        private System.Windows.Forms.Button okRouteButton;
    }
}