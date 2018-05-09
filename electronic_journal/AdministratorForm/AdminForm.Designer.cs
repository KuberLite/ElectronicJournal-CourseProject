namespace electronic_journal.AdministratorForm
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.resultDataGrid = new System.Windows.Forms.DataGridView();
            this.progressButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.addTeacherButton = new System.Windows.Forms.Button();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.addPulpitButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.Location = new System.Drawing.Point(133, 63);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.Size = new System.Drawing.Size(655, 375);
            this.resultDataGrid.TabIndex = 0;
            // 
            // progressButton
            // 
            this.progressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.progressButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressButton.Location = new System.Drawing.Point(133, 4);
            this.progressButton.Name = "progressButton";
            this.progressButton.Size = new System.Drawing.Size(129, 53);
            this.progressButton.TabIndex = 1;
            this.progressButton.Text = "Успеваемость";
            this.progressButton.UseVisualStyleBackColor = true;
            this.progressButton.Click += new System.EventHandler(this.progressButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateButton.Location = new System.Drawing.Point(268, 4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(129, 53);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Внести изменения";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // addTeacherButton
            // 
            this.addTeacherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeacherButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTeacherButton.Location = new System.Drawing.Point(403, 4);
            this.addTeacherButton.Name = "addTeacherButton";
            this.addTeacherButton.Size = new System.Drawing.Size(129, 53);
            this.addTeacherButton.TabIndex = 3;
            this.addTeacherButton.Text = "Добавить преподавателя";
            this.addTeacherButton.UseVisualStyleBackColor = true;
            this.addTeacherButton.Click += new System.EventHandler(this.addTeacherButton_Click);
            // 
            // addStudentButton
            // 
            this.addStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStudentButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addStudentButton.Location = new System.Drawing.Point(538, 4);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(129, 53);
            this.addStudentButton.TabIndex = 4;
            this.addStudentButton.Text = "Добавить студента";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // addPulpitButton
            // 
            this.addPulpitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPulpitButton.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPulpitButton.Location = new System.Drawing.Point(673, 4);
            this.addPulpitButton.Name = "addPulpitButton";
            this.addPulpitButton.Size = new System.Drawing.Size(115, 53);
            this.addPulpitButton.TabIndex = 5;
            this.addPulpitButton.Text = "Добавить кафедру";
            this.addPulpitButton.UseVisualStyleBackColor = true;
            this.addPulpitButton.Click += new System.EventHandler(this.addPulpitButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 406);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(115, 32);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.background4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.addPulpitButton);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.addTeacherButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.progressButton);
            this.Controls.Add(this.resultDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.Text = "Журнал: Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultDataGrid;
        private System.Windows.Forms.Button progressButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button addTeacherButton;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Button addPulpitButton;
        private System.Windows.Forms.Button exitButton;
    }
}