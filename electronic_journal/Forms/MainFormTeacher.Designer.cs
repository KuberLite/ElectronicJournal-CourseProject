namespace electronic_journal.Forms
{
    partial class MainFormTeacher
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormTeacher));
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.openUserTeacherRoomButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.dataGridNote = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNoteTextBox = new System.Windows.Forms.TextBox();
            this.secondNoteTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.plusMinusСomboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subjectComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(166, 4);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(279, 36);
            this.subjectComboBox.TabIndex = 2;
            this.subjectComboBox.Text = "<Предмет>";
            // 
            // groupComboBox
            // 
            this.groupComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Items.AddRange(new object[] {
            "1 ",
            "2 ",
            "3 ",
            "4 ",
            "5 ",
            "6 ",
            "7 ",
            "8 ",
            "9 ",
            "10 "});
            this.groupComboBox.Location = new System.Drawing.Point(621, 4);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(186, 36);
            this.groupComboBox.TabIndex = 3;
            this.groupComboBox.Text = "<Группа>";
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged);
            // 
            // courseComboBox
            // 
            this.courseComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseComboBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Items.AddRange(new object[] {
            "1",
            "2 ",
            "3 ",
            "4 ",
            "5 "});
            this.courseComboBox.Location = new System.Drawing.Point(451, 4);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(164, 36);
            this.courseComboBox.TabIndex = 4;
            this.courseComboBox.Text = "<Курс>";
            // 
            // openUserTeacherRoomButton
            // 
            this.openUserTeacherRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openUserTeacherRoomButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openUserTeacherRoomButton.Location = new System.Drawing.Point(12, 46);
            this.openUserTeacherRoomButton.Name = "openUserTeacherRoomButton";
            this.openUserTeacherRoomButton.Size = new System.Drawing.Size(139, 43);
            this.openUserTeacherRoomButton.TabIndex = 5;
            this.openUserTeacherRoomButton.Text = "Личный кабинет";
            this.openUserTeacherRoomButton.UseVisualStyleBackColor = true;
            this.openUserTeacherRoomButton.Click += new System.EventHandler(this.openUserTeacherRoomButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(13, 423);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(138, 27);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Выход";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dataGridNote
            // 
            this.dataGridNote.BackgroundColor = System.Drawing.Color.Aqua;
            this.dataGridNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNote.Location = new System.Drawing.Point(166, 46);
            this.dataGridNote.MultiSelect = false;
            this.dataGridNote.Name = "dataGridNote";
            this.dataGridNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridNote.Size = new System.Drawing.Size(641, 404);
            this.dataGridNote.TabIndex = 9;
            this.dataGridNote.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellDoubleClick);
            this.dataGridNote.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "I Аттестация >=";
            // 
            // firstNoteTextBox
            // 
            this.firstNoteTextBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNoteTextBox.Location = new System.Drawing.Point(130, 132);
            this.firstNoteTextBox.Name = "firstNoteTextBox";
            this.firstNoteTextBox.Size = new System.Drawing.Size(29, 31);
            this.firstNoteTextBox.TabIndex = 12;
            this.firstNoteTextBox.TextChanged += new System.EventHandler(this.firstNoteTextBox_TextChanged);
            this.firstNoteTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNoteTextBox_KeyPress);
            // 
            // secondNoteTextBox
            // 
            this.secondNoteTextBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondNoteTextBox.Location = new System.Drawing.Point(130, 169);
            this.secondNoteTextBox.Name = "secondNoteTextBox";
            this.secondNoteTextBox.Size = new System.Drawing.Size(29, 31);
            this.secondNoteTextBox.TabIndex = 14;
            this.secondNoteTextBox.TextChanged += new System.EventHandler(this.secondNoteTextBox_TextChanged);
            this.secondNoteTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.secondNoteTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "II Аттестация >=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "СОРТИРОВКА";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Допуск";
            // 
            // plusMinusСomboBox
            // 
            this.plusMinusСomboBox.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusMinusСomboBox.FormattingEnabled = true;
            this.plusMinusСomboBox.Items.AddRange(new object[] {
            "+/-",
            "+",
            "-"});
            this.plusMinusСomboBox.Location = new System.Drawing.Point(72, 206);
            this.plusMinusСomboBox.Name = "plusMinusСomboBox";
            this.plusMinusСomboBox.Size = new System.Drawing.Size(87, 27);
            this.plusMinusСomboBox.TabIndex = 17;
            this.plusMinusСomboBox.Text = "+/-";
            this.plusMinusСomboBox.SelectedIndexChanged += new System.EventHandler(this.plusMinusСomboBox_SelectedIndexChanged);
            // 
            // MainFormTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 463);
            this.Controls.Add(this.plusMinusСomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondNoteTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstNoteTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridNote);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.openUserTeacherRoomButton);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.subjectComboBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormTeacher";
            this.Text = "Журнал: Преподаватель";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormTeacher_FormClosed);
            this.Load += new System.EventHandler(this.MainFormTeacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox subjectComboBox;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Button openUserTeacherRoomButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView dataGridNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNoteTextBox;
        private System.Windows.Forms.TextBox secondNoteTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox plusMinusСomboBox;
    }
}

