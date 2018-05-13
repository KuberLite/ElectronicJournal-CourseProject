namespace electronic_journal.AdministratorForm
{
    partial class ShowDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDataForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.facultyButton = new System.Windows.Forms.Button();
            this.pulpitButton = new System.Windows.Forms.Button();
            this.facultyComboBox = new System.Windows.Forms.ComboBox();
            this.subjectButton = new System.Windows.Forms.Button();
            this.facultyForSubjectСomboBox = new System.Windows.Forms.ComboBox();
            this.pulpitForSubjectComboBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.ShowLoginDataButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.secondNameTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(248, 157);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(706, 410);
            this.dataGridView.TabIndex = 0;
            // 
            // facultyButton
            // 
            this.facultyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facultyButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyButton.Location = new System.Drawing.Point(248, 12);
            this.facultyButton.Name = "facultyButton";
            this.facultyButton.Size = new System.Drawing.Size(122, 33);
            this.facultyButton.TabIndex = 1;
            this.facultyButton.Text = "Факультеты";
            this.facultyButton.UseVisualStyleBackColor = true;
            this.facultyButton.Click += new System.EventHandler(this.facultyButton_Click);
            // 
            // pulpitButton
            // 
            this.pulpitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pulpitButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pulpitButton.Location = new System.Drawing.Point(376, 12);
            this.pulpitButton.Name = "pulpitButton";
            this.pulpitButton.Size = new System.Drawing.Size(161, 33);
            this.pulpitButton.TabIndex = 2;
            this.pulpitButton.Text = "Кафедры";
            this.pulpitButton.UseVisualStyleBackColor = true;
            this.pulpitButton.Click += new System.EventHandler(this.pulpitButton_Click);
            // 
            // facultyComboBox
            // 
            this.facultyComboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyComboBox.FormattingEnabled = true;
            this.facultyComboBox.Location = new System.Drawing.Point(377, 51);
            this.facultyComboBox.Name = "facultyComboBox";
            this.facultyComboBox.Size = new System.Drawing.Size(160, 38);
            this.facultyComboBox.TabIndex = 3;
            this.facultyComboBox.Text = "<Факультет>";
            this.facultyComboBox.SelectedIndexChanged += new System.EventHandler(this.facultyComboBox_SelectedIndexChanged);
            // 
            // subjectButton
            // 
            this.subjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subjectButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectButton.Location = new System.Drawing.Point(543, 12);
            this.subjectButton.Name = "subjectButton";
            this.subjectButton.Size = new System.Drawing.Size(161, 33);
            this.subjectButton.TabIndex = 4;
            this.subjectButton.Text = "Предметы";
            this.subjectButton.UseVisualStyleBackColor = true;
            this.subjectButton.Click += new System.EventHandler(this.subjectButton_Click);
            // 
            // facultyForSubjectСomboBox
            // 
            this.facultyForSubjectСomboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyForSubjectСomboBox.FormattingEnabled = true;
            this.facultyForSubjectСomboBox.Location = new System.Drawing.Point(544, 51);
            this.facultyForSubjectСomboBox.Name = "facultyForSubjectСomboBox";
            this.facultyForSubjectСomboBox.Size = new System.Drawing.Size(160, 38);
            this.facultyForSubjectСomboBox.TabIndex = 5;
            this.facultyForSubjectСomboBox.Text = "<Факультет>";
            this.facultyForSubjectСomboBox.SelectedIndexChanged += new System.EventHandler(this.facultyForSubjectСomboBox_SelectedIndexChanged);
            // 
            // pulpitForSubjectComboBox
            // 
            this.pulpitForSubjectComboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pulpitForSubjectComboBox.FormattingEnabled = true;
            this.pulpitForSubjectComboBox.Location = new System.Drawing.Point(544, 95);
            this.pulpitForSubjectComboBox.Name = "pulpitForSubjectComboBox";
            this.pulpitForSubjectComboBox.Size = new System.Drawing.Size(160, 38);
            this.pulpitForSubjectComboBox.TabIndex = 6;
            this.pulpitForSubjectComboBox.Text = "<Кафедра>";
            this.pulpitForSubjectComboBox.SelectedIndexChanged += new System.EventHandler(this.pulpitForSubjectComboBox_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(12, 534);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(105, 33);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ShowLoginDataButton
            // 
            this.ShowLoginDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowLoginDataButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowLoginDataButton.Location = new System.Drawing.Point(12, 471);
            this.ShowLoginDataButton.Name = "ShowLoginDataButton";
            this.ShowLoginDataButton.Size = new System.Drawing.Size(230, 57);
            this.ShowLoginDataButton.TabIndex = 8;
            this.ShowLoginDataButton.Text = "Просмотр учётных записей";
            this.ShowLoginDataButton.UseVisualStyleBackColor = true;
            this.ShowLoginDataButton.Click += new System.EventHandler(this.ShowLoginDataButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Поиск";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 30);
            this.label2.TabIndex = 10;
            this.label2.Text = "Фамилия:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(97, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "Пользователи";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // secondNameTextBox
            // 
            this.secondNameTextBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondNameTextBox.Location = new System.Drawing.Point(133, 51);
            this.secondNameTextBox.Name = "secondNameTextBox";
            this.secondNameTextBox.Size = new System.Drawing.Size(100, 28);
            this.secondNameTextBox.TabIndex = 12;
            this.secondNameTextBox.TextChanged += new System.EventHandler(this.secondNameTextBox_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(133, 81);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 28);
            this.textBox3.TabIndex = 16;
            // 
            // ShowDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(966, 579);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.secondNameTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowLoginDataButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.pulpitForSubjectComboBox);
            this.Controls.Add(this.facultyForSubjectСomboBox);
            this.Controls.Add(this.subjectButton);
            this.Controls.Add(this.facultyComboBox);
            this.Controls.Add(this.pulpitButton);
            this.Controls.Add(this.facultyButton);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(982, 618);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(982, 618);
            this.Name = "ShowDataForm";
            this.Text = "Администратор: Просмотр данных";
            this.Load += new System.EventHandler(this.ShowDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button facultyButton;
        private System.Windows.Forms.Button pulpitButton;
        private System.Windows.Forms.ComboBox facultyComboBox;
        private System.Windows.Forms.Button subjectButton;
        private System.Windows.Forms.ComboBox facultyForSubjectСomboBox;
        private System.Windows.Forms.ComboBox pulpitForSubjectComboBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button ShowLoginDataButton;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox secondNameTextBox;
        private System.Windows.Forms.TextBox textBox3;
    }
}