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

        DataTable dataTable;

        public LoginForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void RoleEqualsTeacher()
        {
            GetIdPerson();
            MainFormTeacher mainFormTeacher = new MainFormTeacher();
            mainFormTeacher.Show();
            this.Hide();
        }

        private void RoleEqualsStudent()
        {
            GetIdPerson();
            MainFormStudent mainFormStudent = new MainFormStudent();
            mainFormStudent.Show();
            this.Hide();
        }

        private void RoleEqualsAdmin()
        {
            GetIdPerson();
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }

        private void OpenMainWindowByRole(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 1)
            {
                if (dataTable.Rows[0][0].ToString() == "Teacher")
                {
                    RoleEqualsTeacher();
                }
                else if (dataTable.Rows[0][0].ToString() == "Student")
                {
                    RoleEqualsStudent();
                }
                else
                {
                    RoleEqualsAdmin();
                }
            }
            else
            {
                MessageBox.Show(MyResource.wrongPass, MyResource.entry, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetRoleForLogin()
        {
            dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("LoginIn", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@login", login_textBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@pass", Hash(password_textBox.Text.Trim()));
            loginName = login_textBox.Text;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            GetRoleForLogin();
            OpenMainWindowByRole(dataTable);
        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        #region Connection to DataBase
        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
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

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }
    }
}