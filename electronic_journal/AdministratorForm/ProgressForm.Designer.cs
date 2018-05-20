namespace electronic_journal.AdministratorForm
{
    partial class ProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            this.dataGridProgress = new System.Windows.Forms.DataGridView();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.numberGroupComboBox = new System.Windows.Forms.ComboBox();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.facultyComboBox = new System.Windows.Forms.ComboBox();
            this.plusMinusСomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.secondNoteTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstNoteTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProgress
            // 
            this.dataGridProgress.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProgress.Location = new System.Drawing.Point(191, 12);
            this.dataGridProgress.Name = "dataGridProgress";
            this.dataGridProgress.Size = new System.Drawing.Size(597, 426);
            this.dataGridProgress.TabIndex = 0;
            this.dataGridProgress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellClick);
            this.dataGridProgress.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridNote_CellDoubleClick);
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(12, 56);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(173, 38);
            this.subjectComboBox.TabIndex = 1;
            // 
            // numberGroupComboBox
            // 
            this.numberGroupComboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberGroupComboBox.FormattingEnabled = true;
            this.numberGroupComboBox.Items.AddRange(new object[] {
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
            this.numberGroupComboBox.Location = new System.Drawing.Point(12, 144);
            this.numberGroupComboBox.Name = "numberGroupComboBox";
            this.numberGroupComboBox.Size = new System.Drawing.Size(173, 38);
            this.numberGroupComboBox.TabIndex = 2;
            this.numberGroupComboBox.Text = "<Группа>";
            this.numberGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.numberGroupComboBox_SelectedIndexChanged);
            // 
            // courseComboBox
            // 
            this.courseComboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.courseComboBox.Location = new System.Drawing.Point(12, 100);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(173, 38);
            this.courseComboBox.TabIndex = 3;
            this.courseComboBox.Text = "<Курс>";
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(12, 408);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 30);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // facultyComboBox
            // 
            this.facultyComboBox.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.facultyComboBox.FormattingEnabled = true;
            this.facultyComboBox.Location = new System.Drawing.Point(12, 12);
            this.facultyComboBox.Name = "facultyComboBox";
            this.facultyComboBox.Size = new System.Drawing.Size(173, 38);
            this.facultyComboBox.TabIndex = 6;
            this.facultyComboBox.SelectedIndexChanged += new System.EventHandler(this.facultyComboBox_SelectedIndexChanged);
            // 
            // plusMinusСomboBox
            // 
            this.plusMinusСomboBox.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusMinusСomboBox.FormattingEnabled = true;
            this.plusMinusСomboBox.Items.AddRange(new object[] {
            "+/-",
            "+",
            "-"});
            this.plusMinusСomboBox.Location = new System.Drawing.Point(90, 285);
            this.plusMinusСomboBox.Name = "plusMinusСomboBox";
            this.plusMinusСomboBox.Size = new System.Drawing.Size(87, 27);
            this.plusMinusСomboBox.TabIndex = 24;
            this.plusMinusСomboBox.Text = "+/-";
            this.plusMinusСomboBox.SelectedIndexChanged += new System.EventHandler(this.plusMinusСomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(12, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Допуск";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(38, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "СОРТИРОВКА";
            // 
            // secondNoteTextBox
            // 
            this.secondNoteTextBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondNoteTextBox.Location = new System.Drawing.Point(148, 248);
            this.secondNoteTextBox.Name = "secondNoteTextBox";
            this.secondNoteTextBox.Size = new System.Drawing.Size(29, 31);
            this.secondNoteTextBox.TabIndex = 21;
            this.secondNoteTextBox.TextChanged += new System.EventHandler(this.secondNoteTextBox_TextChanged);
            this.secondNoteTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "II Аттестация >=";
            // 
            // firstNoteTextBox
            // 
            this.firstNoteTextBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNoteTextBox.Location = new System.Drawing.Point(148, 211);
            this.firstNoteTextBox.Name = "firstNoteTextBox";
            this.firstNoteTextBox.Size = new System.Drawing.Size(29, 31);
            this.firstNoteTextBox.TabIndex = 19;
            this.firstNoteTextBox.TextChanged += new System.EventHandler(this.firstNoteTextBox_TextChanged);
            this.firstNoteTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "I Аттестация >=";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plusMinusСomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondNoteTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstNoteTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.facultyComboBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.numberGroupComboBox);
            this.Controls.Add(this.subjectComboBox);
            this.Controls.Add(this.dataGridProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgressForm";
            this.Text = "Администратор: Успеваемость";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProgress;
        private System.Windows.Forms.ComboBox subjectComboBox;
        private System.Windows.Forms.ComboBox numberGroupComboBox;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox facultyComboBox;
        private System.Windows.Forms.ComboBox plusMinusСomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secondNoteTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstNoteTextBox;
        private System.Windows.Forms.Label label1;
    }
}