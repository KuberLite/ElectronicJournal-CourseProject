using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class ShowDataForm : Form, IConnection, IDataGridModes
    {
        private readonly string connectionString;
        int count = 0, pressCount = 0;
        string role;

        public ShowDataForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ShowDataForm_Load(object sender, EventArgs e)
        {
            EnabledAllFalse();
            GetFaculty();
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

        #region DataGridModes
        public void DataGridAligment(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridAllowUserToAddRows(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
        }

        public void DataGridAllowUserToResize(DataGridView dataGridView)
        {
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
        }

        public void DataGridColumnsSize(DataGridView dataGridView)
        { 
            
        }

        public void DataGridReadOnly(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = true;
        }

        public void DataGridRowHeadersVisible(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
        }

        public void DataGridMode()
        {
            DataGridAligment(dataGridView);
            DataGridAllowUserToAddRows(dataGridView);
            DataGridAllowUserToResize(dataGridView);
            DataGridColumnsSize(dataGridView);
            DataGridReadOnly(dataGridView);
            DataGridRowHeadersVisible(dataGridView);
        }
        #endregion

        private void facultyButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowFacultyByAdmin", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 353;
            dataGridView.Columns[1].Width = 350;
        }

        private void GetFaculty()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetFacultyId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(dataTable.Rows[i][0].ToString());
                facultyForSubjectСomboBox.Items.Add(dataTable.Rows[i][0].ToString());
                facultyUserComboBox.Items.Add(dataTable.Rows[i][0].ToString());
                facultyForProfessionComboBox.Items.Add(dataTable.Rows[i][0].ToString());
            }
        }

        private void pulpitButton_Click(object sender, EventArgs e)
        {
            facultyComboBox.Enabled = true;
        }

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            facultyComboBox.Enabled = false;
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowPulpitByAdmin", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 223;
            dataGridView.Columns[1].Width = 355;
            dataGridView.Columns[2].Width = 125;
        }

        private void GetPulpitForPulpitComboBox()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetPulpitForPulpitComboBox", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyForSubjectСomboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                pulpitForSubjectComboBox.Items.Add(dataTable.Rows[i][0].ToString());
            }
        }

        private void GetPulpitForPulpitComboBoxForUser()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetPulpitForPulpitComboBox", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyUserComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                pulpitUserComboBox.Items.Add(dataTable.Rows[i][0].ToString());
            }
        }

        private void GetSubjectByFaculty()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllSubjectOnFacultyByAdmin", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyForSubjectСomboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            dataGridView.Columns[0].Width = 223;
            dataGridView.Columns[1].Width = 355;
            dataGridView.Columns[2].Width = 125;
        }

        private void GetSubjectByPulpit()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllSubjectOnFacultyAndOnPulpitByAdmin", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyForSubjectСomboBox.Text);
            sqlCommand.Parameters.AddWithValue("@pulpit", pulpitForSubjectComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            dataGridView.Columns[0].Width = 223;
            dataGridView.Columns[1].Width = 355;
            dataGridView.Columns[2].Width = 125;
        }

        private void facultyForSubjectСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (count != 0)
            {
                pulpitForSubjectComboBox.Items.Clear();
            }
            GetPulpitForPulpitComboBox();
            GetSubjectByFaculty();
            DataGridMode();
            count++;
            
        }

        private void subjectButton_Click(object sender, EventArgs e)
        {
            facultyForSubjectСomboBox.Enabled = true;
            pulpitForSubjectComboBox.Enabled = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pulpitForSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubjectByPulpit();
            facultyForSubjectСomboBox.Enabled = false;
            pulpitForSubjectComboBox.Enabled = false;
        }

        private void ShowLoginDataButton_Click(object sender, EventArgs e)
        {
            if (pressCount == 0)
            {
                ConfirmationForm confirmationForm = new ConfirmationForm();
                confirmationForm.Show();
                pressCount++;
            }
            else if(ConfirmationForm.Correctly)
            { 
                ShowDataLogin();
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

        private void ShowAllUser()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllUser", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }

        private void showUserButton_Click(object sender, EventArgs e)
        {
            ShowAllUser();
            roleComboBox.Enabled = true;
            secondNameTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            genderComboBox.Enabled = true;
            courseComboBox.Enabled = true;
            groupComboBox.Enabled = true;
            pulpitUserComboBox.Enabled = true;
            facultyUserComboBox.Enabled = true;
        }

        private void EnabledAllFalse()
        {
            roleComboBox.Enabled = false;
            facultyComboBox.Enabled = false;
            facultyForSubjectСomboBox.Enabled = false;
            pulpitForSubjectComboBox.Enabled = false;
            secondNameTextBox.Enabled = false;
            emailTextBox.Enabled = false;
            genderComboBox.Enabled = false;
            courseComboBox.Enabled = false;
            groupComboBox.Enabled = false;
            pulpitUserComboBox.Enabled = false;
            facultyUserComboBox.Enabled = false;
            facultyForProfessionComboBox.Enabled = false;
        }

        private void secondNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllUserBySecondName", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@name", secondNameTextBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllUserByEmail", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@email", emailTextBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }

        private void secondNameTextBox_Leave(object sender, EventArgs e)
        {
            secondNameTextBox.Clear();
            ShowAllUser();
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            emailTextBox.Clear();
            ShowAllUser();
        }

        private void GetRole()
        {
            if (roleComboBox.Text.Trim() == MyResource.teacher.Trim())
            {
                role = "Teacher";
            }
            else
            {
                role = "Student";
            }
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRole();
            if (role == "Teacher")
            {
                groupComboBox.Enabled = false;
                courseComboBox.Enabled = false;
                roleComboBox.Enabled = true;
                pulpitUserComboBox.Enabled = true;
                facultyUserComboBox.Enabled = true;
            }
            else
            {
                groupComboBox.Enabled = true;
                courseComboBox.Enabled = true;
                roleComboBox.Enabled = true;
                pulpitUserComboBox.Enabled = false;
                facultyUserComboBox.Enabled = true;
            }
        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllUserByGender", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@gender", genderComboBox.Text.Trim());
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }

        private void genderComboBox_Leave(object sender, EventArgs e)
        {
            genderComboBox.Text = MyResource.selectGender;
        }

        private void professionButton_Click(object sender, EventArgs e)
        {
            facultyForProfessionComboBox.Enabled = true;
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllProfession", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 250;
            dataGridView.Columns[3].Width = 250;
        }

        private void facultyForProfessionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowAllProfessionByFaculty", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyForProfessionComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            facultyForProfessionComboBox.Enabled = false;
            DataGridMode();
            dataGridView.Columns[0].Width = 200;
            dataGridView.Columns[1].Width = 250;
            dataGridView.Columns[2].Width = 250;
        }

        public void ShowDataLogin()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("ShowUserLoginData", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 138;
            dataGridView.Columns[1].Width = 191;
            dataGridView.Columns[2].Width = 138;
            dataGridView.Columns[3].Width = 138;
            dataGridView.Columns[4].Width = 98;
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectAllSudentByFacultyCourseOnShowForm", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyUserComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 138;
            dataGridView.Columns[1].Width = 191;
            dataGridView.Columns[2].Width = 58;
            dataGridView.Columns[3].Width = 58;
            dataGridView.Columns[4].Width = 98;
            dataGridView.Columns[5].Width = 158;
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectAllSudentByGroupCourseFacultyOnShowForm", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyUserComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
            sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 138;
            dataGridView.Columns[1].Width = 191;
            dataGridView.Columns[2].Width = 58;
            dataGridView.Columns[3].Width = 58;
            dataGridView.Columns[4].Width = 98;
            dataGridView.Columns[5].Width = 158;
        }

        private void pulpitUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SelectAllTeacherByPulpitOnShowForm", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@pulpit", pulpitUserComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
            dataGridView.Columns[0].Width = 138;
            dataGridView.Columns[1].Width = 191;
            dataGridView.Columns[2].Width = 58;
            dataGridView.Columns[3].Width = 58;
            dataGridView.Columns[4].Width = 98;
            dataGridView.Columns[5].Width = 158;
        }

        private void facultyUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (count != 0)
            {
                pulpitUserComboBox.Items.Clear();
            }
            GetPulpitForPulpitComboBoxForUser();
            count++;
            if (role == "Teacher")
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SelectAllTeacherByFacultyOnShowForm", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@faculty", facultyUserComboBox.Text);
                SqlDataAdapter(sqlCommand).Fill(dataTable);
                dataGridView.DataSource = dataTable;
                dataGridView.Columns[0].Width = 138;
                dataGridView.Columns[1].Width = 191;
                dataGridView.Columns[2].Width = 58;
                dataGridView.Columns[3].Width = 58;
                dataGridView.Columns[4].Width = 98;
                dataGridView.Columns[5].Width = 158;
            }
            else
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SelectAllStudentByFacultyOnShowForm", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@faculty", facultyUserComboBox.Text);
                SqlDataAdapter(sqlCommand).Fill(dataTable);
                dataGridView.DataSource = dataTable;
                DataGridMode();
                dataGridView.Columns[0].Width = 138;
                dataGridView.Columns[1].Width = 191;
                dataGridView.Columns[2].Width = 58;
                dataGridView.Columns[3].Width = 58;
                dataGridView.Columns[4].Width = 98;
                dataGridView.Columns[5].Width = 158;
            }
        }
    }
}