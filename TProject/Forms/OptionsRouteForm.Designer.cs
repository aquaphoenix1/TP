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
            this.autoLabel = new System.Windows.Forms.Label();
            this.autoComboBox = new System.Windows.Forms.ComboBox();
            this.fuelLabel = new System.Windows.Forms.Label();
            this.driverLabel = new System.Windows.Forms.Label();
            this.critSearchLabel = new System.Windows.Forms.Label();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.critSearchComboBox = new System.Windows.Forms.ComboBox();
            this.fuelComboBox = new System.Windows.Forms.ComboBox();
            this.okRouteButton = new System.Windows.Forms.Button();
            this.routeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelRouteButton
            // 
            this.cancelRouteButton.Location = new System.Drawing.Point(225, 151);
            this.cancelRouteButton.Name = "cancelRouteButton";
            this.cancelRouteButton.Size = new System.Drawing.Size(75, 25);
            this.cancelRouteButton.TabIndex = 11;
            this.cancelRouteButton.Text = "Отмена";
            this.cancelRouteButton.UseVisualStyleBackColor = true;
            // 
            // routeGroupBox
            // 
            this.routeGroupBox.Controls.Add(this.autoLabel);
            this.routeGroupBox.Controls.Add(this.autoComboBox);
            this.routeGroupBox.Controls.Add(this.fuelLabel);
            this.routeGroupBox.Controls.Add(this.driverLabel);
            this.routeGroupBox.Controls.Add(this.critSearchLabel);
            this.routeGroupBox.Controls.Add(this.driverComboBox);
            this.routeGroupBox.Controls.Add(this.critSearchComboBox);
            this.routeGroupBox.Controls.Add(this.fuelComboBox);
            this.routeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.routeGroupBox.Name = "routeGroupBox";
            this.routeGroupBox.Size = new System.Drawing.Size(288, 133);
            this.routeGroupBox.TabIndex = 13;
            this.routeGroupBox.TabStop = false;
            // 
            // autoLabel
            // 
            this.autoLabel.AutoSize = true;
            this.autoLabel.Location = new System.Drawing.Point(6, 50);
            this.autoLabel.Name = "autoLabel";
            this.autoLabel.Size = new System.Drawing.Size(107, 13);
            this.autoLabel.TabIndex = 1;
            this.autoLabel.Text = "Выбор автомобиля:";
            // 
            // autoComboBox
            // 
            this.autoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoComboBox.FormattingEnabled = true;
            this.autoComboBox.Items.AddRange(new object[] {
            "Mitsubishi Lancer"});
            this.autoComboBox.Location = new System.Drawing.Point(151, 47);
            this.autoComboBox.Name = "autoComboBox";
            this.autoComboBox.Size = new System.Drawing.Size(131, 21);
            this.autoComboBox.TabIndex = 6;
            // 
            // fuelLabel
            // 
            this.fuelLabel.AutoSize = true;
            this.fuelLabel.Location = new System.Drawing.Point(6, 81);
            this.fuelLabel.Name = "fuelLabel";
            this.fuelLabel.Size = new System.Drawing.Size(87, 13);
            this.fuelLabel.TabIndex = 2;
            this.fuelLabel.Text = "Выбор топлива:";
            // 
            // driverLabel
            // 
            this.driverLabel.AutoSize = true;
            this.driverLabel.Location = new System.Drawing.Point(6, 16);
            this.driverLabel.Name = "driverLabel";
            this.driverLabel.Size = new System.Drawing.Size(93, 13);
            this.driverLabel.TabIndex = 0;
            this.driverLabel.Text = "Выбор водителя:";
            // 
            // critSearchLabel
            // 
            this.critSearchLabel.AutoSize = true;
            this.critSearchLabel.Location = new System.Drawing.Point(6, 108);
            this.critSearchLabel.Name = "critSearchLabel";
            this.critSearchLabel.Size = new System.Drawing.Size(132, 13);
            this.critSearchLabel.TabIndex = 3;
            this.critSearchLabel.Text = "Выбор критерия поиска:";
            // 
            // driverComboBox
            // 
            this.driverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverComboBox.FormattingEnabled = true;
            this.driverComboBox.Items.AddRange(new object[] {
            "Нарушитель"});
            this.driverComboBox.Location = new System.Drawing.Point(151, 13);
            this.driverComboBox.Name = "driverComboBox";
            this.driverComboBox.Size = new System.Drawing.Size(131, 21);
            this.driverComboBox.TabIndex = 4;
            // 
            // critSearchComboBox
            // 
            this.critSearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.critSearchComboBox.FormattingEnabled = true;
            this.critSearchComboBox.Items.AddRange(new object[] {
            "Время"});
            this.critSearchComboBox.Location = new System.Drawing.Point(151, 105);
            this.critSearchComboBox.Name = "critSearchComboBox";
            this.critSearchComboBox.Size = new System.Drawing.Size(131, 21);
            this.critSearchComboBox.TabIndex = 7;
            // 
            // fuelComboBox
            // 
            this.fuelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fuelComboBox.FormattingEnabled = true;
            this.fuelComboBox.Items.AddRange(new object[] {
            " Premium (АИ-98)"});
            this.fuelComboBox.Location = new System.Drawing.Point(151, 78);
            this.fuelComboBox.Name = "fuelComboBox";
            this.fuelComboBox.Size = new System.Drawing.Size(131, 21);
            this.fuelComboBox.TabIndex = 5;
            // 
            // okRouteButton
            // 
            this.okRouteButton.Location = new System.Drawing.Point(144, 151);
            this.okRouteButton.Name = "okRouteButton";
            this.okRouteButton.Size = new System.Drawing.Size(75, 25);
            this.okRouteButton.TabIndex = 12;
            this.okRouteButton.Text = "Ок";
            this.okRouteButton.UseVisualStyleBackColor = true;
            // 
            // optionsRouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 186);
            this.Controls.Add(this.cancelRouteButton);
            this.Controls.Add(this.routeGroupBox);
            this.Controls.Add(this.okRouteButton);
            this.MaximumSize = new System.Drawing.Size(327, 225);
            this.Name = "optionsRouteForm";
            this.Text = "Параметры маршрута";
            this.routeGroupBox.ResumeLayout(false);
            this.routeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelRouteButton;
        private System.Windows.Forms.GroupBox routeGroupBox;
        private System.Windows.Forms.Label autoLabel;
        private System.Windows.Forms.ComboBox autoComboBox;
        private System.Windows.Forms.Label fuelLabel;
        private System.Windows.Forms.Label driverLabel;
        private System.Windows.Forms.Label critSearchLabel;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.ComboBox critSearchComboBox;
        private System.Windows.Forms.ComboBox fuelComboBox;
        private System.Windows.Forms.Button okRouteButton;
    }
}