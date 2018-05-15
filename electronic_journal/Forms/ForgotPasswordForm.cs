using electronic_journal.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace electronic_journal.Forms
{
    public partial class ForgotPasswordForm : Form, IConnection
    {
        private readonly string connectionString;
        string pass = "";

        List<string> listEmail;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        private void GetAllEmail()
        {
            DataTable dataTable = new DataTable(); 
            SqlCommand sqlCommand = new SqlCommand("SelectAllEmail", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            listEmail = new List<string>();
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                listEmail.Add(dataTable.Rows[i][0].ToString());
            }
        }

        private string GetIdByEmail()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetIdByEmail", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@email", emailTextBox.Text.Trim());
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            string id = dataTable.Rows[0][0].ToString();
            return id;
        }

        private string GetNameById()
        { 
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetNameById", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", GetIdByEmail());
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            string name = dataTable.Rows[0][0].ToString();
            return name;
        }

        private bool TestEmail()
        {
            bool test = true;
            foreach (string email in listEmail)
            {
                if (emailTextBox.Text == email)
                {
                    test = true;
                    break;
                }
                else test = false;
            }
            return test;
        }

        private void GetRandomPassword()
        {
            string ch = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            Random random = new Random();
            char[] pwd = new char[10];
            for (int i = 0; i < pwd.Length; i++)
                pwd[i] = ch[random.Next(ch.Length)];
            pass = new string(pwd);
        }

        private void SendData()
        {
            MailAddress fromMailAddress = new MailAddress(MyResource.mail, MyResource.NameSenderAdmin);
            MailAddress toMailAddress = new MailAddress(emailTextBox.Text.Trim());

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient(MyResource.host, 587))
            {
                string messageForMail = "Здравствуйте, " + GetNameById() + ". Обновлены данные для входа в 'Электронный журнал БГТУ'\n\nВаш новый пароль: " + pass;
                mailMessage.Subject = MyResource.newPass;
                mailMessage.Body = messageForMail;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, MyResource.passwordMail);

                smtpClient.Send(mailMessage);
            }
        }


        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void UpdatePassword()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UpdatePassword", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", GetIdByEmail());
            sqlCommand.Parameters.AddWithValue("@passHash", Hash(pass));
            sqlCommand.ExecuteReader();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (IsConnectedToInternet())
            {
                if (TestEmail()) {
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("AddRequest", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    sqlCommand.Parameters.AddWithValue("@email", emailTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@time", DateTime.Now.ToString());
                    sqlCommand.ExecuteReader();
                    MessageBox.Show(MyResource.requestSend, MyResource.correctEmail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetRandomPassword();
                    SendData();
                    UpdatePassword();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(MyResource.wrongEmail, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(MyResource.InternetConnectionLost, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            GetAllEmail();
        }
    }
}
