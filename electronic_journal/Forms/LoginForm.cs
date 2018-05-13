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

        public static string loginName { get; set; }

        private readonly string connectionString;

        public LoginForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("LoginIn", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@login", login_textBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@pass", UnHash(password_textBox.Text.Trim()));
            DataTable dataTable = new DataTable();
            loginName = login_textBox.Text;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
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
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }
        #endregion

        private void GetIdPerson()
        {
            SqlCommand sqlCommand = new SqlCommand("GetIdPersonByUsernameForLoginForm", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@username", login_textBox.Text);
            DataTable dataTable = new DataTable();
            SqlDataAdapter(sqlCommand).Fill(dataTable);
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

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            return sqlDataAdapter;
        }
    }
}
