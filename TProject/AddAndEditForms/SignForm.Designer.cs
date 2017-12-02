namespace TProject
{
    partial class SignForm
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
            this.textBoxTypeSign = new System.Windows.Forms.TextBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxValueSign = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxValueSign)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(343, 58);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(86, 29);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // textBoxTypeSign
            // 
            this.textBoxTypeSign.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxTypeSign.Location = new System.Drawing.Point(240, 6);
            this.textBoxTypeSign.Name = "textBoxTypeSign";
            this.textBoxTypeSign.Size = new System.Drawing.Size(189, 23);
            this.textBoxTypeSign.TabIndex = 7;
            this.textBoxTypeSign.TextChanged += new System.EventHandler(this.TextBoxTypeSign_TextChanged);
            this.textBoxTypeSign.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxTypeSign_KeyUp);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelValue.Location = new System.Drawing.Point(12, 33);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(223, 15);
            this.labelValue.TabIndex = 6;
            this.labelValue.Text = "Максимальная разрешенная скорость:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelType.Location = new System.Drawing.Point(12, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(31, 15);
            this.labelType.TabIndex = 5;
            this.labelType.Text = "Тип:";
            // 
            // textBoxValueSign
            // 
            this.textBoxValueSign.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxValueSign.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.textBoxValueSign.Location = new System.Drawing.Point(240, 32);
            this.textBoxValueSign.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.textBoxValueSign.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.textBoxValueSign.Name = "textBoxValueSign";
            this.textBoxValueSign.Size = new System.Drawing.Size(189, 23);
            this.textBoxValueSign.TabIndex = 10;
            this.textBoxValueSign.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.textBoxValueSign.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxValueSign_KeyUp);
            // 
            // SignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 94);
            this.Controls.Add(this.textBoxValueSign);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxTypeSign);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignForm";
            this.ShowIcon = false;
            this.Text = "Параметры здорожного знака";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxValueSign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxTypeSign;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.NumericUpDown textBoxValueSign;
    }
}