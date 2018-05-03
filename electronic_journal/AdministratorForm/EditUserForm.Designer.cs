namespace electronic_journal.AdministratorForm
{
    partial class EditUserForm
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
            this.dataGridPerson = new System.Windows.Forms.DataGridView();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.pulpitComboBox = new System.Windows.Forms.ComboBox();
            this.facultyComboBox = new System.Windows.Forms.ComboBox();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPerson
            // 
            this.dataGridPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPerson.Location = new System.Drawing.Point(188, 12);
            this.dataGridPerson.Name = "dataGridPerson";
            this.dataGridPerson.Size = new System.Drawing.Size(600, 426);
            this.dataGridPerson.TabIndex = 0;
            // 
            // roleComboBox
            // 
            this.roleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roleComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] {
            "Преподаватель ",
            "Студент"});
            this.roleComboBox.Location = new System.Drawing.Point(12, 12);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(170, 36);
            this.roleComboBox.TabIndex = 1;
            this.roleComboBox.Text = "<Роль>";
            this.roleComboBox.SelectedIndexChanged += new System.EventHandler(this.roleComboBox_SelectedIndexChanged);
            // 
            // pulpitComboBox
            // 
            this.pulpitComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pulpitComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pulpitComboBox.FormattingEnabled = true;
            this.pulpitComboBox.Location = new System.Drawing.Point(12, 96);
            this.pulpitComboBox.Name = "pulpitComboBox";
            this.pulpitComboBox.Size = new System.Drawing.Size(170, 36);
            this.pulpitComboBox.TabIndex = 2;
            this.pulpitComboBox.Text = "<Кафедра>";
            this.pulpitComboBox.SelectedIndexChanged += new System.EventHandler(this.pulpitComboBox_SelectedIndexChanged);
            // 
            // facultyComboBox
            // 
            this.facultyComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facultyComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyComboBox.FormattingEnabled = true;
            this.facultyComboBox.Location = new System.Drawing.Point(12, 54);
            this.facultyComboBox.Name = "facultyComboBox";
            this.facultyComboBox.Size = new System.Drawing.Size(170, 36);
            this.facultyComboBox.TabIndex = 3;
            this.facultyComboBox.Text = "<Факультет>";
            this.facultyComboBox.SelectedIndexChanged += new System.EventHandler(this.facultyComboBox_SelectedIndexChanged);
            // 
            // groupComboBox
            // 
            this.groupComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(12, 180);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(170, 36);
            this.groupComboBox.TabIndex = 4;
            this.groupComboBox.Text = "<Группа>";
            // 
            // courseComboBox
            // 
            this.courseComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Location = new System.Drawing.Point(12, 138);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(170, 36);
            this.courseComboBox.TabIndex = 5;
            this.courseComboBox.Text = "<Курс>";
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(12, 407);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(95, 31);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.facultyComboBox);
            this.Controls.Add(this.pulpitComboBox);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.dataGridPerson);
            this.Name = "EditUserForm";
            this.Text = "Администратор: Изменение данных";
            this.Load += new System.EventHandler(this.EditUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPerson;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.ComboBox pulpitComboBox;
        private System.Windows.Forms.ComboBox facultyComboBox;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Button backButton;
    }
}