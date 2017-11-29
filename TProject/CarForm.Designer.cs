namespace TProject
{
    partial class CarForm
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
            this.comboBoxIDFuel = new System.Windows.Forms.ComboBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelConsumption = new System.Windows.Forms.Label();
            this.textBoxConsumption = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIDFuel = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxIDFuel
            // 
            this.comboBoxIDFuel.FormattingEnabled = true;
            this.comboBoxIDFuel.Location = new System.Drawing.Point(130, 34);
            this.comboBoxIDFuel.Name = "comboBoxIDFuel";
            this.comboBoxIDFuel.Size = new System.Drawing.Size(137, 21);
            this.comboBoxIDFuel.TabIndex = 16;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(183, 94);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(86, 23);
            this.buttonAccept.TabIndex = 15;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // labelConsumption
            // 
            this.labelConsumption.AutoSize = true;
            this.labelConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConsumption.Location = new System.Drawing.Point(12, 65);
            this.labelConsumption.Name = "labelConsumption";
            this.labelConsumption.Size = new System.Drawing.Size(112, 16);
            this.labelConsumption.TabIndex = 14;
            this.labelConsumption.Text = "Расход топлива";
            // 
            // textBoxConsumption
            // 
            this.textBoxConsumption.Location = new System.Drawing.Point(130, 64);
            this.textBoxConsumption.Name = "textBoxConsumption";
            this.textBoxConsumption.Size = new System.Drawing.Size(137, 20);
            this.textBoxConsumption.TabIndex = 13;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxModel.Location = new System.Drawing.Point(130, 6);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(139, 22);
            this.textBoxModel.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 11;
            // 
            // labelIDFuel
            // 
            this.labelIDFuel.AutoSize = true;
            this.labelIDFuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIDFuel.Location = new System.Drawing.Point(12, 35);
            this.labelIDFuel.Name = "labelIDFuel";
            this.labelIDFuel.Size = new System.Drawing.Size(77, 16);
            this.labelIDFuel.TabIndex = 10;
            this.labelIDFuel.Text = "Id топлива";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelModel.Location = new System.Drawing.Point(12, 9);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(58, 16);
            this.labelModel.TabIndex = 9;
            this.labelModel.Text = "Модель";
            // 
            // CarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 123);
            this.Controls.Add(this.comboBoxIDFuel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelConsumption);
            this.Controls.Add(this.textBoxConsumption);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelIDFuel);
            this.Controls.Add(this.labelModel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxIDFuel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label labelConsumption;
        private System.Windows.Forms.TextBox textBoxConsumption;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIDFuel;
        private System.Windows.Forms.Label labelModel;
    }
}