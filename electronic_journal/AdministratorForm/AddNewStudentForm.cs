using electronic_journal.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            facultyComboBox.Text = MyResource.selectFaculty;
            string query = "select IdFaculty from Faculty";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetGroupForGroupComboBox()
        {
            DataTable data = new DataTable();
            string query = "select numberGroup from Groups inner join Faculty " +
                           "on Groups.Faculty = Faculty.IdFaculty " +
                           "where Faculty.IdFaculty = '" + facultyComboBox.Text.Trim() + "' and Groups.Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) + "";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                groupComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(IsConnectedToInternet() == true)
            {
                AddNewStudent();
                SendData();
                MessageBox.Show(MyResource.SendMessage, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearWindow();
                MessageBox.Show(MyResource.UpdateDB, MyResource.update, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("StudentAdd", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                GetSqlCommand(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show(MyResource.correctlyAdd, MyResource.addStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void ValidateEmail(string email)
        {
            if (IsValidEmailAddress(email)) errorProvider.SetError(emailTextBox, "OK");
            else errorProvider.SetError(emailTextBox, "Not Valid Email");
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail(emailTextBox.Text);
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
                string messageForMail = "Здравствуйте, " + nameTextBox.Text + ", Вы зарегистрированы в системе 'Электронный журнал БГТУ'\nДанные для входа в систему:\nВаш логин: " + usernameTextBox.Text + "\nВаш пароль: " + passwordTextBox.Text;
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
            string query = "select IdGroup from Groups inner join Faculty " +
                           "on Groups.Faculty = Faculty.IdFaculty " +
                           "where Faculty.IdFaculty = '" + facultyComboBox.Text.Trim() + "' and Groups.Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) + " " +
                           "and Groups.NumberGroup  = " + Convert.ToInt32(groupComboBox.Text.Trim()) + "";
            SqlDataAdapter(query, ConnectionSQL()).Fill(tableData);
            groupId = tableData.Rows[0][0].ToString();
        }
    }
}
