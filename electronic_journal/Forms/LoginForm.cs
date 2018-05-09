using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using electronic_journal.Interfaces;
using electronic_journal.AdministratorForm;

namespace electronic_journal.Forms
{ 
    public partial class LoginForm : Form, IConnection
    { 
        public static string str { get; set; }

        public static string idPerson { get; set; }

        private readonly string connectionString;
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;

        public LoginForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            string loginQuery = "select RoleName from Roles " +
                                "inner join UserRoles on Roles.IdRole = UserRoles.RoleId " +
                                "inner join [User] on UserRoles.UserId = [User].Id where Username ='" +
                                login_textBox.Text.Trim() + "' and PasswordHash = '" + UnHash(password_textBox.Text.Trim()) + "'";
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
                else if (dataTable.Rows[0][0].ToString() == "Student")
                {
                    GetIdPerson();
                    MainFormStudent mainFormStudent = new MainFormStudent();
                    mainFormStudent.Show();
                    this.Hide();
                }
                else
                {
                    GetIdPerson();
                    AdminForm admin = new AdminForm();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(MyResource.wrongPass, MyResource.entry, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region HashPassword
        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private string UnHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
        #endregion

        #region Connection to DataBase
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
        #endregion

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

        private void btnEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntry_Click(sender, e);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
