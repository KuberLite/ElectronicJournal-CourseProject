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
            this.showUserButton = new System.Windows.Forms.Button();
            this.secondNameTextBox = new System.Windows.Forms.TextBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.facultyUserComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pulpitUserComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 30);
            this.label2.TabIndex = 10;
            this.label2.Text = "Фамилия:";
            // 
            // showUserButton
            // 
            this.showUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showUserButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showUserButton.Location = new System.Drawing.Point(97, 12);
            this.showUserButton.Name = "showUserButton";
            this.showUserButton.Size = new System.Drawing.Size(145, 33);
            this.showUserButton.TabIndex = 11;
            this.showUserButton.Text = "Пользователи";
            this.showUserButton.UseVisualStyleBackColor = true;
            this.showUserButton.Click += new System.EventHandler(this.showUserButton_Click);
            // 
            // secondNameTextBox
            // 
            this.secondNameTextBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondNameTextBox.Location = new System.Drawing.Point(133, 88);
            this.secondNameTextBox.Name = "secondNameTextBox";
            this.secondNameTextBox.Size = new System.Drawing.Size(109, 28);
            this.secondNameTextBox.TabIndex = 12;
            this.secondNameTextBox.TextChanged += new System.EventHandler(this.secondNameTextBox_TextChanged);
            this.secondNameTextBox.Leave += new System.EventHandler(this.secondNameTextBox_Leave);
            // 
            // genderComboBox
            // 
            this.genderComboBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "м",
            "ж"});
            this.genderComboBox.Location = new System.Drawing.Point(133, 157);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(109, 31);
            this.genderComboBox.TabIndex = 17;
            this.genderComboBox.Text = "<Пол>";
            this.genderComboBox.SelectedIndexChanged += new System.EventHandler(this.genderComboBox_SelectedIndexChanged);
            this.genderComboBox.Leave += new System.EventHandler(this.genderComboBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(52, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 18;
            this.label3.Text = "email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextBox.Location = new System.Drawing.Point(133, 122);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(109, 28);
            this.emailTextBox.TabIndex = 19;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            this.emailTextBox.Leave += new System.EventHandler(this.emailTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(66, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "Пол:";
            // 
            // roleComboBox
            // 
            this.roleComboBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] {
            "Студент",
            "Преподаватель"});
            this.roleComboBox.Location = new System.Drawing.Point(97, 51);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(145, 31);
            this.roleComboBox.TabIndex = 21;
            this.roleComboBox.Text = "<Роль>";
            this.roleComboBox.SelectedIndexChanged += new System.EventHandler(this.roleComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 30);
            this.label5.TabIndex = 22;
            this.label5.Text = "Роль:";
            // 
            // groupComboBox
            // 
            this.groupComboBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.groupComboBox.Location = new System.Drawing.Point(133, 231);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(109, 31);
            this.groupComboBox.TabIndex = 23;
            this.groupComboBox.Text = "<Группа>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(35, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 30);
            this.label6.TabIndex = 24;
            this.label6.Text = "Группа:";
            // 
            // facultyUserComboBox
            // 
            this.facultyUserComboBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyUserComboBox.FormattingEnabled = true;
            this.facultyUserComboBox.Location = new System.Drawing.Point(133, 268);
            this.facultyUserComboBox.Name = "facultyUserComboBox";
            this.facultyUserComboBox.Size = new System.Drawing.Size(109, 31);
            this.facultyUserComboBox.TabIndex = 25;
            this.facultyUserComboBox.Text = "<Факультет>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(23, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 30);
            this.label7.TabIndex = 26;
            this.label7.Text = "Кафедра:";
            // 
            // courseComboBox
            // 
            this.courseComboBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.courseComboBox.Location = new System.Drawing.Point(133, 194);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(109, 31);
            this.courseComboBox.TabIndex = 27;
            this.courseComboBox.Text = "<Курс>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(60, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 30);
            this.label8.TabIndex = 28;
            this.label8.Text = "Курс:";
            // 
            // pulpitUserComboBox
            // 
            this.pulpitUserComboBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pulpitUserComboBox.FormattingEnabled = true;
            this.pulpitUserComboBox.Location = new System.Drawing.Point(133, 305);
            this.pulpitUserComboBox.Name = "pulpitUserComboBox";
            this.pulpitUserComboBox.Size = new System.Drawing.Size(109, 31);
            this.pulpitUserComboBox.TabIndex = 29;
            this.pulpitUserComboBox.Text = "<Кафедра>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(2, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 30);
            this.label9.TabIndex = 30;
            this.label9.Text = "Факультет:";
            // 
            // ShowDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(966, 579);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pulpitUserComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.facultyUserComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.secondNameTextBox);
            this.Controls.Add(this.showUserButton);
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
        private System.Windows.Forms.Button showUserButton;
        private System.Windows.Forms.TextBox secondNameTextBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox facultyUserComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox pulpitUserComboBox;
        private System.Windows.Forms.Label label9;
    }
}