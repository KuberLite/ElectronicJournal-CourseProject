namespace electronic_journal
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridNote = new System.Windows.Forms.DataGridView();
            this.userRoomButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
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
            this.userRoomButton.Location = new System.Drawing.Point(12, 48);
            this.userRoomButton.Name = "userRoomButton";
            this.userRoomButton.Size = new System.Drawing.Size(106, 42);
            this.userRoomButton.TabIndex = 3;
            this.userRoomButton.Text = "Личный кабинет";
            this.userRoomButton.UseVisualStyleBackColor = true;
            this.userRoomButton.Click += new System.EventHandler(this.userRoomButton_Click);
            // 
            // MainFormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.userRoomButton);
            this.Controls.Add(this.dataGridNote);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(706, 489);
            this.MinimumSize = new System.Drawing.Size(706, 489);
            this.Name = "MainFormStudent";
            this.Text = "Журнал: Студент";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormStudent_FormClosed);
            this.Load += new System.EventHandler(this.MainFormStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridNote;
        private System.Windows.Forms.Button userRoomButton;
    }
}