using electronic_journal.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
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

        private void GetPulpitForPulpitComboBox()
        {
            DataTable data = new DataTable();
            string query = "select IdPulpit from Faculty inner join Pulpit " +
                           "on Faculty.IdFaculty = Pulpit.Faculty " +
                           "where Faculty.IdFaculty = '" + facultyComboBox.Text + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                pulpitComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetFacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            facultyComboBox.Text = MyResource.selectFaculty;
            string query = "select IdFaculty from Faculty";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
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
            AddNewTeacher();
            ClearWindow();
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

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail(emailTextBox.Text);
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void SendData()
        {
            MailAddress fromMailAddress = new MailAddress("kursachgrahovskiy@mail.ru", "Denis Grahovskiy(admin)");
            MailAddress toMailAddress = new MailAddress(emailTextBox.Text.Trim());

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 587))
            {
                string messageForMail = "Здравствуйте, " + nameTextBox.Text + " Вы зарегистрированы в системе 'Электронный журнал БГТУ'\nДанные для входа в систему:\nВаш логин: " + usernameTextBox.Text + "\nВаш пароль: " + passwordTextBox.Text;
                mailMessage.Subject = "Данные для входа";
                mailMessage.Body = messageForMail;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "49atagaf");

                smtpClient.Send(mailMessage);
            }
        }
    }
}