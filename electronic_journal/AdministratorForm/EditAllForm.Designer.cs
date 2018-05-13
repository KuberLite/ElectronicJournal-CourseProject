namespace electronic_journal.AdministratorForm
{
    partial class EditAllForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAllForm));
            this.editGroupButton = new System.Windows.Forms.Button();
            this.editUserButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.AddPulpitButton = new System.Windows.Forms.Button();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.addTeacherButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editGroupButton
            // 
            this.editGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editGroupButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editGroupButton.Location = new System.Drawing.Point(12, 12);
            this.editGroupButton.Name = "editGroupButton";
            this.editGroupButton.Size = new System.Drawing.Size(115, 59);
            this.editGroupButton.TabIndex = 0;
            this.editGroupButton.Text = "Изменить предметы";
            this.editGroupButton.UseVisualStyleBackColor = true;
            this.editGroupButton.Click += new System.EventHandler(this.editGroupButton_Click);
            // 
            // editUserButton
            // 
            this.editUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editUserButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editUserButton.Location = new System.Drawing.Point(133, 12);
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(115, 59);
            this.editUserButton.TabIndex = 1;
            this.editUserButton.Text = "Изменить пользователя";
            this.editUserButton.UseVisualStyleBackColor = true;
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(12, 183);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(115, 31);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // AddPulpitButton
            // 
            this.AddPulpitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPulpitButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPulpitButton.Location = new System.Drawing.Point(254, 12);
            this.AddPulpitButton.Name = "AddPulpitButton";
            this.AddPulpitButton.Size = new System.Drawing.Size(115, 59);
            this.AddPulpitButton.TabIndex = 4;
            this.AddPulpitButton.Text = "Добавить кафедру";
            this.AddPulpitButton.UseVisualStyleBackColor = true;
            this.AddPulpitButton.Click += new System.EventHandler(this.AddPulpitButton_Click);
            // 
            // addStudentButton
            // 
            this.addStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudentButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addStudentButton.Location = new System.Drawing.Point(12, 77);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(115, 59);
            this.addStudentButton.TabIndex = 5;
            this.addStudentButton.Text = "Добавить студента";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // addTeacherButton
            // 
            this.addTeacherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacherButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTeacherButton.Location = new System.Drawing.Point(375, 12);
            this.addTeacherButton.Name = "addTeacherButton";
            this.addTeacherButton.Size = new System.Drawing.Size(115, 59);
            this.addTeacherButton.TabIndex = 6;
            this.addTeacherButton.Text = "Добавить преподавателя";
            this.addTeacherButton.UseVisualStyleBackColor = true;
            this.addTeacherButton.Click += new System.EventHandler(this.addTeacherButton_Click);
            // 
            // EditAllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(502, 226);
            this.Controls.Add(this.addTeacherButton);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.AddPulpitButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.editUserButton);
            this.Controls.Add(this.editGroupButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditAllForm";
            this.Text = "Администратор: Внести изменения";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editGroupButton;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button AddPulpitButton;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Button addTeacherButton;
    }
}