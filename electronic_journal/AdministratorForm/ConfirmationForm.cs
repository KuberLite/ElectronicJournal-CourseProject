using electronic_journal.Forms;
using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class ConfirmationForm : Form, IConnection
    {
        private readonly string connectionString;
        public static bool Correctly { get; set; }

        public ConfirmationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            loginTexBox.Text = LoginForm.loginName;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("LoginIn", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@login", loginTexBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@pass", UnHash(passwordTextBox.Text.Trim()));
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                Correctly = true;
                this.Hide();
                MessageBox.Show(MyResource.pressAgain, MyResource.good, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(MyResource.passOff, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Clear();
            }            
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
    }
}
