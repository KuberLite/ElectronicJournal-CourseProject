﻿using electronic_journal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class AddNewStudentForm : Form, IConnection
    {
        private readonly string connectionString;
        string groupId;
        List<string> listEmail;

        public AddNewStudentForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddNewStudentForm_Load(object sender, EventArgs e)
        {
            GetFacultyForFacultyCombobox();
            GetAllEmail();
            groupComboBox.Text = MyResource.selectGroup;
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

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        } 

        private void GetFacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetFacultyId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetGroupForGroupComboBox()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetGroupForGroupComboBox", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));            
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                groupComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsConnectedToInternet() == true)
            {
                if (nameTextBox.Text != "" && facultyComboBox.Text != MyResource.selectFaculty && courseComboBox.Text != MyResource.selectedCourse && groupComboBox.Text != MyResource.selectGroup && usernameTextBox.Text != "" && passwordTextBox.Text != "" && IsValidEmailAddress(emailTextBox.Text) && genderComboBox.Text != MyResource.selectGender)
                {
                    if (!TestEmail())
                    {
                        AddNewStudent();
                        SendData();
                        MessageBox.Show(MyResource.SendMessage, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearWindow();
                    }
                    else
                    {
                        MessageBox.Show(MyResource.haveEmail, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(MyResource.checkAllForms, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(MyResource.InternetConnectionLost, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearWindow()
        {
            nameTextBox.Clear();
            facultyComboBox.Text = MyResource.selectFaculty;
            groupComboBox.Text = MyResource.selectProfession;
            genderComboBox.Text = MyResource.selectGender;
            birthdayDateTimePicker.Text = DateTime.Now.ToLongDateString();
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void AddNewStudent()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("StudentAdd", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            GetSqlCommand(sqlCommand);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show(MyResource.correctlyAdd, MyResource.addStudent);
        }

        private void GetSqlCommand(SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@IdGroup", groupId);
            sqlCommand.Parameters.AddWithValue("@Gender", genderComboBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(birthdayDateTimePicker.Text));
            sqlCommand.Parameters.AddWithValue("@PersonId", Guid.NewGuid().ToString());
            sqlCommand.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@PasswordHash", Hash(passwordTextBox.Text.Trim()));
            sqlCommand.Parameters.AddWithValue("@email", emailTextBox.Text.Trim());
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

        private void SetErrorProvider(ErrorProvider provider, Icon icon, Control control, string message)
        {
            provider.Icon = icon;
            provider.SetError(control, message);
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

        private void GetAllEmail()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectAllEmail", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            listEmail = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                listEmail.Add(dataTable.Rows[i][0].ToString());
            }
        }

        private void ValidateEmail(string email)
        {
            if (IsValidEmailAddress(email)) SetErrorProvider(errorProvider, MyResource.Ok, emailTextBox, MyResource.correctEmail);
            else SetErrorProvider(errorProvider, MyResource.WrongCross, emailTextBox, MyResource.error);
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void SendData()
        {
            MailAddress fromMailAddress = new MailAddress(MyResource.mail, MyResource.NameSenderAdmin);
            MailAddress toMailAddress = new MailAddress(emailTextBox.Text.Trim());

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient(MyResource.host, 587))
            {
                string messageForMail = "Здравствуйте, " + nameTextBox.Text + ", Вы зарегистрированы в системе " +
                                        "'Электронный журнал БГТУ'\nДанные для входа в систему:\nВаш логин: " +
                                        usernameTextBox.Text + "\nВаш пароль: " + passwordTextBox.Text;
                mailMessage.Subject = MyResource.dataForLogin;
                mailMessage.Body = messageForMail;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, MyResource.passwordMail);

                smtpClient.Send(mailMessage);
            }
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroupForGroupComboBox();
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tableData = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectGroupId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text.Trim()));
            sqlCommand.Parameters.AddWithValue("@group", Convert.ToInt32(groupComboBox.Text.Trim()));
            SqlDataAdapter(sqlCommand).Fill(tableData);
            groupId = tableData.Rows[0][0].ToString();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailTextBox.Text != "")
            {
                ValidateEmail(emailTextBox.Text);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Clear();
            passwordTextBox.Text = GetRandomPassword();
        }

        private string GetRandomPassword()
        {
            string ch = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            Random random = new Random();
            char[] pwd = new char[10];
            for (int i = 0; i < pwd.Length; i++)
                pwd[i] = ch[random.Next(ch.Length)];
            return new string(pwd);
        }
    }
}
