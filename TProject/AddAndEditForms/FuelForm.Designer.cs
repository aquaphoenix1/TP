namespace TProject
{
    partial class FuelForm
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
            this.textBoxNameFuel = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelNameFuel = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(220, 72);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(97, 27);
            this.buttonAccept.TabIndex = 19;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // textBoxNameFuel
            // 
            this.textBoxNameFuel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxNameFuel.Location = new System.Drawing.Point(175, 7);
            this.textBoxNameFuel.Name = "textBoxNameFuel";
            this.textBoxNameFuel.Size = new System.Drawing.Size(142, 23);
            this.textBoxNameFuel.TabIndex = 17;
            this.textBoxNameFuel.TextChanged += new System.EventHandler(this.TextBoxNameFuel_TextChanged);
            this.textBoxNameFuel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxNameFuel_KeyUp);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelPrice.Location = new System.Drawing.Point(14, 39);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(38, 15);
            this.labelPrice.TabIndex = 16;
            this.labelPrice.Text = "Цена:";
            // 
            // labelNameFuel
            // 
            this.labelNameFuel.AutoSize = true;
            this.labelNameFuel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelNameFuel.Location = new System.Drawing.Point(14, 10);
            this.labelNameFuel.Name = "labelNameFuel";
            this.labelNameFuel.Size = new System.Drawing.Size(110, 15);
            this.labelNameFuel.TabIndex = 15;
            this.labelNameFuel.Text = "Название топлива:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.DecimalPlaces = 2;
            this.textBoxPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPrice.Location = new System.Drawing.Point(175, 39);
            this.textBoxPrice.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(142, 23);
            this.textBoxPrice.TabIndex = 20;
            this.textBoxPrice.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.textBoxPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxPrice_KeyUp);
            // 
            // FuelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 104);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxNameFuel);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelNameFuel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FuelForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры топлива";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxNameFuel;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelNameFuel;
        private System.Windows.Forms.NumericUpDown textBoxPrice;
    }
}