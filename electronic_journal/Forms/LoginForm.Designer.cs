namespace electronic_journal
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label_entry = new System.Windows.Forms.Label();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.btnEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_entry
            // 
            this.label_entry.AutoSize = true;
            this.label_entry.BackColor = System.Drawing.Color.Transparent;
            this.label_entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_entry.Location = new System.Drawing.Point(107, 53);
            this.label_entry.Name = "label_entry";
            this.label_entry.Size = new System.Drawing.Size(97, 37);
            this.label_entry.TabIndex = 0;
            this.label_entry.Text = "Вход:";
            // 
            // login_textBox
            // 
            this.login_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_textBox.Location = new System.Drawing.Point(114, 93);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(194, 29);
            this.login_textBox.TabIndex = 1;
            this.login_textBox.Text = "admin";
            this.login_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEntry_KeyDown);
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_textBox.Location = new System.Drawing.Point(114, 141);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(194, 29);
            this.password_textBox.TabIndex = 2;
            this.password_textBox.Text = "admin";
            this.password_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEntry_KeyDown);
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.BackColor = System.Drawing.Color.Transparent;
            this.login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(53, 99);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(59, 20);
            this.login_label.TabIndex = 3;
            this.login_label.Text = "Логин:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.BackColor = System.Drawing.Color.Transparent;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(37, 147);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(71, 20);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль:";
            // 
            // btnEntry
            // 
            this.btnEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntry.Location = new System.Drawing.Point(114, 176);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(194, 23);
            this.btnEntry.TabIndex = 5;
            this.btnEntry.Text = "Войти";
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click_1);
            this.btnEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEntry_KeyDown);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::electronic_journal.MyResource.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(360, 265);
            this.Controls.Add(this.btnEntry);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.login_textBox);
            this.Controls.Add(this.label_entry);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(376, 304);
            this.MinimumSize = new System.Drawing.Size(376, 304);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_entry;
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button btnEntry;
    }
}