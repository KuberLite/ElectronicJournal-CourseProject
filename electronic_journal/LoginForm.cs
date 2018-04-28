using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace electronic_journal
{ 
    public partial class LoginForm : Form, IConnection
    { 
        public static string str { get; set; }

        public static string idPerson { get; set; }

        string connectionString;
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;

        public LoginForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void btnEntry_Click_1(object sender, EventArgs e)
        {
            string loginQuery = "select RoleName from Roles " +
                                "inner join UserRoles on Roles.IdRole = UserRoles.RoleId " +
                                "inner join [User] on UserRoles.UserId = [User].Id where Username ='" +
                                login_textBox.Text.Trim() + "' and PasswordHash = '" + password_textBox.Text.Trim() + "'";
            dataTable = new DataTable();
            SqlDataAdapter(loginQuery, ConnectionSQL()).Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                if (dataTable.Rows[0][0].ToString() == "Teacher")
                {
                    GetIdPerson();
                    MainFormTeacher mainFormTeacher = new MainFormTeacher();
                    mainFormTeacher.Show();
                    this.Hide();
                }
                else
                {
                    GetIdPerson();
                    MainFormStudent mainFormStudent = new MainFormStudent();
                    mainFormStudent.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(MyResource.wrongPass, MyResource.entry, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void GetIdPerson()
        {
            string query = "select IdPerson from Person inner join [User] on Person.IdPerson = [User].Id where Username = '" + login_textBox.Text.Trim() + "'";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                idPerson = dataTable.Rows[0][0].ToString();
            }
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }

        private void btnEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntry_Click_1(sender, e);
            }
        }
    }
}
