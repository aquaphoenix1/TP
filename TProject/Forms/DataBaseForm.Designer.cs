namespace TProject
{
    partial class dataBaseForm
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
            this.changeTableGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteEntryButton = new System.Windows.Forms.Button();
            this.addEntryButton = new System.Windows.Forms.Button();
            this.changeEntryButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cloeae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseGroupBox = new System.Windows.Forms.GroupBox();
            this.okDatabaseButton = new System.Windows.Forms.Button();
            this.choicelTableLabel2 = new System.Windows.Forms.Label();
            this.choicelTableLabel1 = new System.Windows.Forms.Label();
            this.changeTableComboBox = new System.Windows.Forms.ComboBox();
            this.changeTableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.databaseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // changeTableGroupBox
            // 
            this.changeTableGroupBox.Controls.Add(this.deleteEntryButton);
            this.changeTableGroupBox.Controls.Add(this.addEntryButton);
            this.changeTableGroupBox.Controls.Add(this.changeEntryButton);
            this.changeTableGroupBox.Location = new System.Drawing.Point(387, 91);
            this.changeTableGroupBox.Name = "changeTableGroupBox";
            this.changeTableGroupBox.Size = new System.Drawing.Size(171, 102);
            this.changeTableGroupBox.TabIndex = 9;
            this.changeTableGroupBox.TabStop = false;
            this.changeTableGroupBox.Text = "Редактирование записей";
            // 
            // deleteEntryButton
            // 
            this.deleteEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteEntryButton.AutoSize = true;
            this.deleteEntryButton.Location = new System.Drawing.Point(9, 71);
            this.deleteEntryButton.Name = "deleteEntryButton";
            this.deleteEntryButton.Size = new System.Drawing.Size(154, 23);
            this.deleteEntryButton.TabIndex = 2;
            this.deleteEntryButton.Text = "Удалить";
            this.deleteEntryButton.UseVisualStyleBackColor = true;
            // 
            // addEntryButton
            // 
            this.addEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addEntryButton.AutoSize = true;
            this.addEntryButton.Location = new System.Drawing.Point(9, 13);
            this.addEntryButton.Name = "addEntryButton";
            this.addEntryButton.Size = new System.Drawing.Size(154, 23);
            this.addEntryButton.TabIndex = 0;
            this.addEntryButton.Text = "Добавить";
            this.addEntryButton.UseVisualStyleBackColor = true;
            // 
            // changeEntryButton
            // 
            this.changeEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeEntryButton.AutoSize = true;
            this.changeEntryButton.Location = new System.Drawing.Point(9, 42);
            this.changeEntryButton.Name = "changeEntryButton";
            this.changeEntryButton.Size = new System.Drawing.Size(154, 23);
            this.changeEntryButton.TabIndex = 1;
            this.changeEntryButton.Text = "Редактировать";
            this.changeEntryButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Cloeae,
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(369, 349);
            this.dataGridView.TabIndex = 8;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Cloeae
            // 
            this.Cloeae.HeaderText = "";
            this.Cloeae.Name = "Cloeae";
            // 
            // Column1
            // 
            this.Column1.HeaderText = " ";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = " ";
            this.Column2.Name = "Column2";
            // 
            // databaseGroupBox
            // 
            this.databaseGroupBox.Controls.Add(this.okDatabaseButton);
            this.databaseGroupBox.Controls.Add(this.choicelTableLabel2);
            this.databaseGroupBox.Controls.Add(this.choicelTableLabel1);
            this.databaseGroupBox.Controls.Add(this.changeTableComboBox);
            this.databaseGroupBox.Location = new System.Drawing.Point(387, 0);
            this.databaseGroupBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.databaseGroupBox.Name = "databaseGroupBox";
            this.databaseGroupBox.Size = new System.Drawing.Size(177, 361);
            this.databaseGroupBox.TabIndex = 7;
            this.databaseGroupBox.TabStop = false;
            // 
            // okDatabaseButton
            // 
            this.okDatabaseButton.Location = new System.Drawing.Point(88, 326);
            this.okDatabaseButton.Name = "okDatabaseButton";
            this.okDatabaseButton.Size = new System.Drawing.Size(75, 23);
            this.okDatabaseButton.TabIndex = 6;
            this.okDatabaseButton.Text = "Ок";
            this.okDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // choicelTableLabel2
            // 
            this.choicelTableLabel2.AutoSize = true;
            this.choicelTableLabel2.Location = new System.Drawing.Point(6, 38);
            this.choicelTableLabel2.Name = "choicelTableLabel2";
            this.choicelTableLabel2.Size = new System.Drawing.Size(147, 13);
            this.choicelTableLabel2.TabIndex = 5;
            this.choicelTableLabel2.Text = "редактирования из списка:";
            // 
            // choicelTableLabel1
            // 
            this.choicelTableLabel1.AutoSize = true;
            this.choicelTableLabel1.Location = new System.Drawing.Point(6, 25);
            this.choicelTableLabel1.Name = "choicelTableLabel1";
            this.choicelTableLabel1.Size = new System.Drawing.Size(121, 13);
            this.choicelTableLabel1.TabIndex = 4;
            this.choicelTableLabel1.Text = "Выберите таблицу для";
            // 
            // changeTableComboBox
            // 
            this.changeTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.changeTableComboBox.FormattingEnabled = true;
            this.changeTableComboBox.Items.AddRange(new object[] {
            "Выбранная таблица"});
            this.changeTableComboBox.Location = new System.Drawing.Point(6, 54);
            this.changeTableComboBox.Name = "changeTableComboBox";
            this.changeTableComboBox.Size = new System.Drawing.Size(157, 21);
            this.changeTableComboBox.TabIndex = 3;
            // 
            // dataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 373);
            this.Controls.Add(this.changeTableGroupBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.databaseGroupBox);
            this.Name = "dataBaseForm";
            this.Text = "Работа с базой данных";
            this.changeTableGroupBox.ResumeLayout(false);
            this.changeTableGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.databaseGroupBox.ResumeLayout(false);
            this.databaseGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox changeTableGroupBox;
        private System.Windows.Forms.Button deleteEntryButton;
        private System.Windows.Forms.Button addEntryButton;
        private System.Windows.Forms.Button changeEntryButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cloeae;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox databaseGroupBox;
        private System.Windows.Forms.Button okDatabaseButton;
        private System.Windows.Forms.Label choicelTableLabel2;
        private System.Windows.Forms.Label choicelTableLabel1;
        private System.Windows.Forms.ComboBox changeTableComboBox;
    }
}