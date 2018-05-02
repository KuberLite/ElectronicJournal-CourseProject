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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridProgress
            // 
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
            this.numberGroupComboBox.Location = new System.Drawing.Point(12, 100);
            this.numberGroupComboBox.Name = "numberGroupComboBox";
            this.numberGroupComboBox.Size = new System.Drawing.Size(173, 38);
            this.numberGroupComboBox.TabIndex = 2;
            this.numberGroupComboBox.Text = "<Группа>";
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
            this.courseComboBox.Location = new System.Drawing.Point(12, 144);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(173, 38);
            this.courseComboBox.TabIndex = 3;
            this.courseComboBox.Text = "<Курс>";
            this.courseComboBox.SelectedIndexChanged += new System.EventHandler(this.courseComboBox_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 414);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
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
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridProgress;
        private System.Windows.Forms.ComboBox subjectComboBox;
        private System.Windows.Forms.ComboBox numberGroupComboBox;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox facultyComboBox;
    }
}