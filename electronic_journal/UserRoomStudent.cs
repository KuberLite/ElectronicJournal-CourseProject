using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace electronic_journal
{
    public partial class UserRoomStudent : Form
    {
        string connectionString;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public UserRoomStudent()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        private void UserRoomTextBoxEnabled()
        {
            fullNameTextBox.Enabled = false;
            groupTextBox.Enabled = false;
            courseTextBox.Enabled = false;
            genderTextBox.Enabled = false;
            professionTextBox.Enabled = false;
            birthdayTextBox.Enabled = false;
        }

        private void UserRoomStudent_Load(object sender, System.EventArgs e)
        {
            UserRoomTextBoxEnabled();
        }
    }
}
