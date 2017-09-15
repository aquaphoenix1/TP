namespace TProject
{
    partial class VertexInfoControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonExit = new System.Windows.Forms.Button();
            this.checkBoxTrafficLight = new System.Windows.Forms.CheckBox();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(103, 179);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Ок";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrafficLight
            // 
            this.checkBoxTrafficLight.AutoSize = true;
            this.checkBoxTrafficLight.Location = new System.Drawing.Point(9, 34);
            this.checkBoxTrafficLight.Name = "checkBoxTrafficLight";
            this.checkBoxTrafficLight.Size = new System.Drawing.Size(100, 17);
            this.checkBoxTrafficLight.TabIndex = 5;
            this.checkBoxTrafficLight.Text = "Регулируемый";
            this.checkBoxTrafficLight.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 6);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(124, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Перекресток (X = ; Y= )";
            // 
            // VertexInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.checkBoxTrafficLight);
            this.Controls.Add(this.labelName);
            this.Name = "VertexInfoControl";
            this.Size = new System.Drawing.Size(191, 211);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxTrafficLight;
        private System.Windows.Forms.Label labelName;
    }
}
