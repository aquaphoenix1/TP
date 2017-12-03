namespace TProject
{
    partial class CoatingForm
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
            this.textBoxTypeCoating = new System.Windows.Forms.TextBox();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxCoefficient = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccept.Location = new System.Drawing.Point(225, 75);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(101, 27);
            this.buttonAccept.TabIndex = 14;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            this.buttonAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ButtonAccept_KeyUp);
            // 
            // textBoxTypeCoating
            // 
            this.textBoxTypeCoating.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxTypeCoating.Location = new System.Drawing.Point(175, 10);
            this.textBoxTypeCoating.Name = "textBoxTypeCoating";
            this.textBoxTypeCoating.Size = new System.Drawing.Size(151, 23);
            this.textBoxTypeCoating.TabIndex = 12;
            this.textBoxTypeCoating.TextChanged += new System.EventHandler(this.TextBoxTypeCoating_TextChanged);
            this.textBoxTypeCoating.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxTypeCoating_KeyUp);
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCoefficient.Location = new System.Drawing.Point(13, 47);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(157, 15);
            this.labelCoefficient.TabIndex = 11;
            this.labelCoefficient.Text = "Коэффициент скольжения:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelType.Location = new System.Drawing.Point(14, 13);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(88, 15);
            this.labelType.TabIndex = 10;
            this.labelType.Text = "Тип покрытия:";
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Location = new System.Drawing.Point(174, 39);
            this.textBoxCoefficient.Mask = "0.0";
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(151, 23);
            this.textBoxCoefficient.TabIndex = 0;
            // 
            // CoatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 107);
            this.Controls.Add(this.textBoxCoefficient);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxTypeCoating);
            this.Controls.Add(this.labelCoefficient);
            this.Controls.Add(this.labelType);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoatingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры покрытия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxTypeCoating;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.MaskedTextBox textBoxCoefficient;
    }
}