using System;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class EditAllForm : Form
    {
        public EditAllForm()    
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void editGroupButton_Click(object sender, EventArgs e)
        {
            EditGroupForm editGroupForm = new EditGroupForm();
            editGroupForm.Show();
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm();
            editUserForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
