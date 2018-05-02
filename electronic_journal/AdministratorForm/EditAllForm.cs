using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
