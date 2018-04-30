using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using electronic_journal.Forms;
using electronic_journal.DAL.Interfaces;
using electronic_journal.DAL.Repositories;
using electronic_journal.DAL.Models;

namespace electronic_journal
{ 
    public partial class LoginForm : Form, IConnection
    {
        private readonly IUnitOfWork _database;

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

            _database = UnitOfWork.GetInstance();
        }

        private void btnEntry_Click_1(object sender, EventArgs e)
        {
            User user = _database.UserManager.SignIn(login_textBox.Text.Trim(), password_textBox.Text);
            if (user == null) {
                MessageBox.Show(MyResource.wrongPass, MyResource.entry, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_database.UserManager.IsInRole(user.Id, "Teacher"))
            {
                //GetIdPerson();
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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
