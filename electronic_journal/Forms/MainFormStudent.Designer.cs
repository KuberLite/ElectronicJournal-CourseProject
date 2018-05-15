namespace electronic_journal.Forms
{
    partial class MainFormStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormStudent));
            this.dataGridNote = new System.Windows.Forms.DataGridView();
            this.userRoomButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridNote
            // 
            this.dataGridNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNote.Location = new System.Drawing.Point(125, 12);
            this.dataGridNote.Name = "dataGridNote";
            this.dataGridNote.Size = new System.Drawing.Size(553, 426);
            this.dataGridNote.TabIndex = 1;
            // 
            // userRoomButton
            // 
            this.userRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userRoomButton.Location = new System.Drawing.Point(12, 48);
            this.userRoomButton.Name = "userRoomButton";
            this.userRoomButton.Size = new System.Drawing.Size(106, 42);
            this.userRoomButton.TabIndex = 3;
            this.userRoomButton.Text = "Личный кабинет";
            this.userRoomButton.UseVisualStyleBackColor = true;
            this.userRoomButton.Click += new System.EventHandler(this.userRoomButton_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MainFormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userRoomButton);
            this.Controls.Add(this.dataGridNote);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(706, 489);
            this.MinimumSize = new System.Drawing.Size(706, 489);
            this.Name = "MainFormStudent";
            this.Text = "Журнал: Студент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormStudent_FormClosing);
            this.Load += new System.EventHandler(this.MainFormStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridNote;
        private System.Windows.Forms.Button userRoomButton;
        private System.Windows.Forms.Button button1;
    }
}