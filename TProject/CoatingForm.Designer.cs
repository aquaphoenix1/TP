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
            this.textBoxCoefficient = new System.Windows.Forms.TextBox();
            this.textBoxTypeCoating = new System.Windows.Forms.TextBox();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccept.Location = new System.Drawing.Point(239, 65);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(87, 23);
            this.buttonAccept.TabIndex = 14;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCoefficient.Location = new System.Drawing.Point(196, 37);
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(130, 22);
            this.textBoxCoefficient.TabIndex = 13;
            // 
            // textBoxTypeCoating
            // 
            this.textBoxTypeCoating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTypeCoating.Location = new System.Drawing.Point(196, 9);
            this.textBoxTypeCoating.Name = "textBoxTypeCoating";
            this.textBoxTypeCoating.Size = new System.Drawing.Size(130, 22);
            this.textBoxTypeCoating.TabIndex = 12;
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoefficient.Location = new System.Drawing.Point(12, 40);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(181, 16);
            this.labelCoefficient.TabIndex = 11;
            this.labelCoefficient.Text = "Коэффициент скольжения";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.Location = new System.Drawing.Point(12, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(98, 16);
            this.labelType.TabIndex = 10;
            this.labelType.Text = "Тип покрытия";
            // 
            // CoatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 93);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxCoefficient);
            this.Controls.Add(this.textBoxTypeCoating);
            this.Controls.Add(this.labelCoefficient);
            this.Controls.Add(this.labelType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoatingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxCoefficient;
        private System.Windows.Forms.TextBox textBoxTypeCoating;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.Label labelType;
    }
}