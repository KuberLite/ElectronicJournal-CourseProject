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
            this.button2 = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.dataGridNote = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(166, 12);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(279, 28);
            this.subjectComboBox.TabIndex = 2;
            this.subjectComboBox.Text = "<Выберите предмет>";
            // 
            // groupComboBox
            // 
            this.groupComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.groupComboBox.Location = new System.Drawing.Point(621, 12);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(186, 28);
            this.groupComboBox.TabIndex = 3;
            this.groupComboBox.Text = "<Выберите группу>";
            // 
            // courseComboBox
            // 
            this.courseComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Items.AddRange(new object[] {
            "1",
            "2 ",
            "3 ",
            "4 ",
            "5 "});
            this.courseComboBox.Location = new System.Drawing.Point(451, 12);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(164, 28);
            this.courseComboBox.TabIndex = 4;
            this.courseComboBox.Text = "<Выберите курс>";
            // 
            // openUserTeacherRoomButton
            // 
            this.openUserTeacherRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.closeButton.Location = new System.Drawing.Point(13, 427);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(138, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Выход";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(13, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Показать данные";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LoadDB_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Location = new System.Drawing.Point(13, 124);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(138, 23);
            this.UpdateButton.TabIndex = 8;
            this.UpdateButton.Text = "Обновить данные";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
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
            this.dataGridNote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellClick);
            this.dataGridNote.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellDoubleClick);
            this.dataGridNote.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellEndEdit);
            this.dataGridNote.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellValueChanged);
            // 
            // MainFormTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 463);
            this.Controls.Add(this.dataGridNote);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.button2);
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

        }

        #endregion
        private System.Windows.Forms.ComboBox subjectComboBox;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Button openUserTeacherRoomButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView dataGridNote;
    }
}

