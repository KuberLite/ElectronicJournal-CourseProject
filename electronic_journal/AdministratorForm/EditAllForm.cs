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
            EditSubjectForm editGroupForm = new EditSubjectForm();
            editGroupForm.ShowDialog();
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm();
            editUserForm.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddPulpitButton_Click(object sender, EventArgs e)
        {
            AddNewPulpitForm pulpitForm = new AddNewPulpitForm();
            pulpitForm.ShowDialog();
        }

        private void addTeacherButton_Click(object sender, EventArgs e)
        {
            AddNewTeacherForm addNewTeacher = new AddNewTeacherForm();
            addNewTeacher.ShowDialog();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AddNewStudentForm studentForm = new AddNewStudentForm();
            studentForm.ShowDialog();
        }
    }
}
