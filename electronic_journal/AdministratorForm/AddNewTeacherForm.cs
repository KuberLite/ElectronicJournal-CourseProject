﻿using electronic_journal.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class AddNewTeacherForm : Form, IConnection
    {
        private readonly string connectionString;

        public AddNewTeacherForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sql = new SqlConnection(connectionString);
            return sql;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return dataAdapter;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            return sqlDataAdapter;
        }

        private void GetPulpitForPulpitComboBox()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetPulpitForPulpitComboBox", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                pulpitComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetFacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            facultyComboBox.Text = MyResource.selectFaculty;
            SqlCommand sqlCommand = new SqlCommand("GetFacultyId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPulpitForPulpitComboBox();
        }

        private void AddNewTeacherForm_Load(object sender, EventArgs e)
        {
            GetFacultyForFacultyCombobox();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsConnectedToInternet())
            {
                AddNewTeacher();
                SendData();
                MessageBox.Show(MyResource.SendMessage, MyResource.dataForLogin, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearWindow();
            }
            else
            {
                MessageBox.Show(MyResource.InternetConnectionLost, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ClearWindow()
        {
            nameTextBox.Clear();
            facultyComboBox.Text = MyResource.selectFaculty;
            pulpitComboBox.Text = MyResource.selectPulpit;
            genderComboBox.Text = MyResource.selectGender;
            birthdayDateTimePicker.Text = DateTime.Now.ToLongDateString();
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void AddNewTeacher()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("TeacherAdd", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                GetSqlCommand(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Регистрация прошла успешно", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetSqlCommand(SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Pulpit", pulpitComboBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Gender", genderComboBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(birthdayDateTimePicker.Text));
            sqlCommand.Parameters.AddWithValue("@PersonId", Guid.NewGuid().ToString());
            sqlCommand.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@PasswordHash", Hash(passwordTextBox.Text.Trim()));
            sqlCommand.Parameters.AddWithValue("@Email", emailTextBox.Text.Trim());
        }

        public bool IsValidEmailAddress(string email)
        {
            try
            {
                MailAddress ma = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValidateEmail(string email)
        {
            if (IsValidEmailAddress(email)) errorProviderOk.SetError(emailTextBox, "OK");
            else errorProviderWrong.SetError(emailTextBox, "Not Valid Email");
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void SendData()
        {
            MailAddress fromMailAddress = new MailAddress(MyResource.mail, MyResource.NameSenderAdmin);
            MailAddress toMailAddress = new MailAddress(emailTextBox.Text.Trim());

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient(MyResource.host, 587))
            {
                string messageForMail = "Здравствуйте, " + nameTextBox.Text + " Вы зарегистрированы в системе 'Электронный журнал БГТУ'\nДанные для входа в систему:\nВаш логин: " + usernameTextBox.Text + "\nВаш пароль: " + passwordTextBox.Text;
                mailMessage.Subject = MyResource.dataForLogin;
                mailMessage.Body = messageForMail;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, MyResource.passwordMail);

                smtpClient.Send(mailMessage);
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailTextBox.Text != "")
            {
                ValidateEmail(emailTextBox.Text);
            }
        }
    }
}