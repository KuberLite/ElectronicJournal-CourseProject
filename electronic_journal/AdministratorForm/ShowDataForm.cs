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
            VisibleAllFalse();
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

        #region GetInformationInForms
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
            LoadDataGridWithOneValue("ShowAllSubjectOnFacultyByAdmin", ConnectionSQL(), "@faculty", facultyForSubjectСomboBox.Text);
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

        private void GetFaculty()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetFacultyId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(dataTable.Rows[i][0].ToString());
                facultyForSubjectСomboBox.Items.Add(dataTable.Rows[i][0].ToString());
                facultyUserComboBox.Items.Add(dataTable.Rows[i][0].ToString());
                facultyForProfessionComboBox.Items.Add(dataTable.Rows[i][0].ToString());
            }
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
        #endregion
        
        private void LoadDataGrid(string nameProcedure, SqlConnection sqlConnection)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(nameProcedure, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
        }

        private void LoadDataGridWithOneValue(string nameProcedure, SqlConnection sqlConnection, string nameValue, string value)
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(nameProcedure, sqlConnection);
            sqlCommand.Parameters.AddWithValue(nameValue, value);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridView.DataSource = dataTable;
            DataGridMode();
        }

        #region ButtonClick
        private void subjectButton_Click(object sender, EventArgs e)
        {
            SubjectFormsAllVisibleTrue();
            UserLabelAllVisibleFalse();
            UserFormsAllVisibleFalse();
            PulpitFormsAllVisibleFalse();
            ProfessionFormsAllVisibleFalse();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showUserButton_Click(object sender, EventArgs e)
        {
            ShowAllUser();
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            roleComboBox.Visible = true;
            secondNameTextBox.Visible = true;
            emailTextBox.Visible = true;
            genderComboBox.Visible = true;            
            PulpitFormsAllVisibleFalse();
            ProfessionFormsAllVisibleFalse();
            SubjectFormsAllVisibleFalse();
        }

        private void professionButton_Click(object sender, EventArgs e)
        {
            ProfessionFormsAllVisibleTrue();
            UserLabelAllVisibleFalse();
            UserFormsAllVisibleFalse();
            PulpitFormsAllVisibleFalse();
            SubjectFormsAllVisibleFalse();
            LoadDataGrid("ShowAllProfession", ConnectionSQL());
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 250;
            dataGridView.Columns[3].Width = 250;
        }

        private void ShowLoginDataButton_Click(object sender, EventArgs e)
        {
            VisibleAllFalse();
            if (pressCount == 0)
            {
                ConfirmationForm confirmationForm = new ConfirmationForm();
                confirmationForm.ShowDialog();
                pressCount++;
                UserFormsAllVisibleFalse();
            }
            else if (ConfirmationForm.Correctly)
            {
                ShowDataLogin();
                pressCount = 0;
                ConfirmationForm.Correctly = false;
            }
            else
            {
                UserFormsAllVisibleFalse();
                pressCount = 0;
            }
        }

        private void pulpitButton_Click(object sender, EventArgs e)
        {
            PulpitFormsAllVisibleTrue();
            UserFormsAllVisibleFalse();
            UserLabelAllVisibleFalse();
            ProfessionFormsAllVisibleFalse();
            SubjectFormsAllVisibleFalse();
        }

        private void facultyButton_Click(object sender, EventArgs e)
        {
            LoadDataGrid("ShowFacultyByAdmin", ConnectionSQL());
            dataGridView.Columns[0].Width = 353;
            dataGridView.Columns[1].Width = 350;
            UserLabelAllVisibleFalse();
            UserFormsAllVisibleFalse();
            PulpitFormsAllVisibleFalse();
            ProfessionFormsAllVisibleFalse();
            SubjectFormsAllVisibleFalse();
        }
        #endregion

        #region SelectedIndexChanged
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

        private void pulpitForSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubjectByPulpit();
            PulpitFormsAllVisibleFalse();
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRole();
            if (role == "Teacher")
            {
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                groupComboBox.Visible = false;
                courseComboBox.Visible = false;
                roleComboBox.Visible = true;
                pulpitUserComboBox.Visible = true;
                facultyUserComboBox.Visible = true;
            }
            else
            {
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = true;
                label9.Visible = true;
                groupComboBox.Visible = true;
                courseComboBox.Visible = true;
                roleComboBox.Visible = true;
                pulpitUserComboBox.Visible = false;
                facultyUserComboBox.Visible = true;
            }
        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridWithOneValue("ShowAllUserByGender", ConnectionSQL(), "@gender", genderComboBox.Text.Trim());
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }

        private void facultyForProfessionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridWithOneValue("ShowAllProfessionByFaculty", ConnectionSQL(), "@faculty", facultyForProfessionComboBox.Text);
            ProfessionFormsAllVisibleFalse();
            dataGridView.Columns[0].Width = 200;
            dataGridView.Columns[1].Width = 250;
            dataGridView.Columns[2].Width = 250;
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
            try
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
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pulpitUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridWithOneValue("SelectAllTeacherByPulpitOnShowForm", ConnectionSQL(), "@pulpit", pulpitUserComboBox.Text);
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
                LoadDataGridWithOneValue("SelectAllTeacherByFacultyOnShowForm", ConnectionSQL(), "@faculty", facultyUserComboBox.Text);
                dataGridView.Columns[0].Width = 138;
                dataGridView.Columns[1].Width = 191;
                dataGridView.Columns[2].Width = 58;
                dataGridView.Columns[3].Width = 58;
                dataGridView.Columns[4].Width = 98;
                dataGridView.Columns[5].Width = 158;
            }
            else
            {
                LoadDataGridWithOneValue("SelectAllStudentByFacultyOnShowForm", ConnectionSQL(), "@faculty", facultyUserComboBox.Text);
                dataGridView.Columns[0].Width = 138;
                dataGridView.Columns[1].Width = 191;
                dataGridView.Columns[2].Width = 58;
                dataGridView.Columns[3].Width = 58;
                dataGridView.Columns[4].Width = 98;
                dataGridView.Columns[5].Width = 158;
            }
        }

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridWithOneValue("ShowPulpitByAdmin", ConnectionSQL(), "@faculty", facultyComboBox.Text);
            PulpitFormsAllVisibleFalse();
            dataGridView.Columns[0].Width = 223;
            dataGridView.Columns[1].Width = 355;
            dataGridView.Columns[2].Width = 125;
        }
        #endregion

        #region TextChanged
        private void secondNameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridWithOneValue("ShowAllUserBySecondName", ConnectionSQL(), "@name", secondNameTextBox.Text);
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
            LoadDataGridWithOneValue("ShowAllUserByEmail", ConnectionSQL(), "@email", emailTextBox.Text);
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }
        #endregion

        #region Visible
        private void UserFormsAllVisibleFalse()
        {
            roleComboBox.Visible = false;
            secondNameTextBox.Visible = false;
            emailTextBox.Visible = false;
            genderComboBox.Visible = false;
            courseComboBox.Visible = false;
            groupComboBox.Visible = false;
            pulpitUserComboBox.Visible = false;
            facultyUserComboBox.Visible = false;
        }

        private void UserFormsAllVisibleTrue()
        {
            roleComboBox.Visible = true;
            secondNameTextBox.Visible = true;
            emailTextBox.Visible = true;
            genderComboBox.Visible = true;
            courseComboBox.Visible = true;
            groupComboBox.Visible = true;
            pulpitUserComboBox.Visible = true;
            facultyUserComboBox.Visible = true;
        }

        private void UserLabelAllVisibleTrue()
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
        }

        private void UserLabelAllVisibleFalse()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }

        private void PulpitFormsAllVisibleTrue()
        {
            facultyComboBox.Visible = true;
        }

        private void PulpitFormsAllVisibleFalse()
        {
            facultyComboBox.Visible = false;
        }

        private void SubjectFormsAllVisibleTrue()
        {
            facultyForSubjectСomboBox.Visible = true;
            pulpitForSubjectComboBox.Visible = true;
        }

        private void SubjectFormsAllVisibleFalse()
        {
            facultyForSubjectСomboBox.Visible = false;
            pulpitForSubjectComboBox.Visible = false;
        }

        private void ProfessionFormsAllVisibleTrue()
        {
            facultyForProfessionComboBox.Visible = true;
        }

        private void ProfessionFormsAllVisibleFalse()
        {
            facultyForProfessionComboBox.Visible = false;
        }

        private void VisibleAllFalse()
        {
            UserFormsAllVisibleFalse();
            UserLabelAllVisibleFalse();
            PulpitFormsAllVisibleFalse();
            SubjectFormsAllVisibleFalse();
            ProfessionFormsAllVisibleFalse();
        }
        #endregion

        #region Leave
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

        private void genderComboBox_Leave(object sender, EventArgs e)
        {
            genderComboBox.Text = MyResource.selectGender;
        }
        #endregion
        
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
            LoadDataGrid("ShowAllUser", ConnectionSQL());
            dataGridView.Columns[0].Width = 98;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 60;
            dataGridView.Columns[4].Width = 50;
            dataGridView.Columns[5].Width = 98;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 98;
        }

        public void ShowDataLogin()
        {
            LoadDataGrid("ShowUserLoginData", ConnectionSQL());
            dataGridView.Columns[0].Width = 138;
            dataGridView.Columns[1].Width = 191;
            dataGridView.Columns[2].Width = 138;
            dataGridView.Columns[3].Width = 138;
            dataGridView.Columns[4].Width = 98;
        }
    }
}