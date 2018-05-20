using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class EditUserForm : Form, IConnection, IDataGridModes
    {
        private readonly string connectionString;
        string role;
        int count = 0;

        public EditUserForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;

            foreach (var obj in myCombo.Items)
            {
                maxWidth = 580;
            }
            return maxWidth;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            GetfacultyForFacultyCombobox();
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            return sqlDataAdapter;
        }

        private void GetPulpitForPulpitComboBox()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetPulpitForPulpitComboBoxByAdmin", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                pulpitComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetfacultyForFacultyCombobox()
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

        #region DataGridModes
        public void DataGridMode()
        {
            DataGridAligment(dataGridPerson);
            DataGridColumnsSize(dataGridPerson);
            DataGridAllowUserToAddRows(dataGridPerson);
            DataGridReadOnly(dataGridPerson);
            DataGridRowHeadersVisible(dataGridPerson);
            DataGridAllowUserToResize(dataGridPerson);
        }

        public void DataGridColumnsSize(DataGridView dataGridNote)
        {
            dataGridPerson.Columns[0].Width = 100;
            dataGridPerson.Columns[1].Width = 200;
            dataGridPerson.Columns[2].Width = 100;
            dataGridPerson.Columns[3].Width = 100;
            dataGridPerson.Columns[4].Width = 97;
        }

        public void DataGridAligment(DataGridView dataGridNote)
        {
            dataGridNote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridReadOnly(DataGridView dataGridNote)
        {

        }

        public void DataGridAllowUserToAddRows(DataGridView dataGridNote)
        {
            dataGridNote.AllowUserToAddRows = false;
        }

        public void DataGridRowHeadersVisible(DataGridView dataGridNote)
        {
            dataGridNote.RowHeadersVisible = false;
        }

        public void DataGridAllowUserToResize(DataGridView dataGridNote)
        {
            dataGridNote.AllowUserToResizeColumns = false;
            dataGridNote.AllowUserToResizeRows = false;
        }
        #endregion

        #region SelectedIndexChanged
        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (count != 0)
            {
                pulpitComboBox.Items.Clear();
            }
            GetPulpitForPulpitComboBox();
            pulpitComboBox.DropDownWidth = DropDownWidth(pulpitComboBox);
            count++;
            if (role == "Teacher")
            {
                SqlCommand sqlCommand = new SqlCommand("SelectAllTeacherByFaculty", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
                DataTable dataTable = new DataTable();
                SqlDataAdapter(sqlCommand).Fill(dataTable);
                dataGridPerson.DataSource = dataTable;
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand("SelectAllStudentByFaculty", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
                DataTable dataTable = new DataTable();
                SqlDataAdapter(sqlCommand).Fill(dataTable);
                dataGridPerson.DataSource = dataTable;
            }
            DataGridMode();
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRole();
            if (role == "Teacher")
            {
                groupComboBox.Visible = false;
                courseComboBox.Visible = false;
                roleComboBox.Visible = true;
                pulpitComboBox.Visible = true;
                facultyComboBox.Visible = true;
            }
            else
            {
                groupComboBox.Visible = true;
                courseComboBox.Visible = true;
                roleComboBox.Visible = true;
                pulpitComboBox.Visible = false;
                facultyComboBox.Visible = true;
            }
        }

        private void pulpitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SelectAllTeacherByPulpit", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@pulpit", pulpitComboBox.Text);
            DataTable dataTable = new DataTable();
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridPerson.DataSource = dataTable;
            DataGridMode();
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SelectAllSudentByFacultyCourse", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
            DataTable dataTable = new DataTable();
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridPerson.DataSource = dataTable;
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SelectAllSudentByGroupCourseFaculty", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
                sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
                sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
                DataTable dataTable = new DataTable();
                SqlDataAdapter(sqlCommand).Fill(dataTable);
                dataGridPerson.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void dataGridPerson_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (role == "Teacher")
            {
                UpdateTeacherInfo(e.ColumnIndex, e.RowIndex);
            }
            else
            {
                UpdateStudentInfo(e.ColumnIndex, e.RowIndex);
            }
        }

        private void UpdateStudentInfo(int column, int row)
        {
            try
            {
                int numberGroup = 0;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlDataReader dataReader;
                sqlConnection.Open();
                SqlCommand selectGroupId = new SqlCommand("SelectGroupId", sqlConnection);
                selectGroupId.CommandType = CommandType.StoredProcedure;
                selectGroupId.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
                selectGroupId.Parameters.AddWithValue("@group", dataGridPerson["Группа", row].Value);
                selectGroupId.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
                dataReader = selectGroupId.ExecuteReader();
                while (dataReader.Read())
                {
                    numberGroup = Convert.ToInt32(dataReader["IdGroup"]);
                }
                SqlCommand update = new SqlCommand("UpdateStudent", sqlConnection);
                update.CommandType = CommandType.StoredProcedure;
                update.Parameters.AddWithValue("@name", dataGridPerson["ФИО", row].Value.ToString());
                update.Parameters.AddWithValue("@gender", dataGridPerson["Пол", row].Value.ToString());
                update.Parameters.AddWithValue("@birthday", Convert.ToDateTime(dataGridPerson["Дата рождения", row].Value));
                update.Parameters.AddWithValue("@idGroup", numberGroup);
                update.Parameters.AddWithValue("@idPerson", dataGridPerson["ID", row].Value.ToString());
                dataReader.Close();
                dataReader = update.ExecuteReader();
                dataReader.Close();
                dataGridPerson.UpdateCellValue(column, row);
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void UpdateTeacherInfo(int column, int row)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlDataReader dataReader;
                sqlConnection.Open();
                SqlCommand update = new SqlCommand("UpdateTeacher", sqlConnection);
                update.CommandType = CommandType.StoredProcedure;
                update.Parameters.AddWithValue("@name", dataGridPerson["ФИО", row].Value.ToString());
                update.Parameters.AddWithValue("@pulpit", dataGridPerson["Кафедра", row].Value.ToString());
                update.Parameters.AddWithValue("@gender", dataGridPerson["Пол", row].Value.ToString());
                update.Parameters.AddWithValue("@birthday", Convert.ToDateTime(dataGridPerson["Дата рождения", row].Value));
                update.Parameters.AddWithValue("@idPerson", dataGridPerson["ID", row].Value);
                dataReader = update.ExecuteReader();
                dataReader.Close();
                dataGridPerson.UpdateCellValue(column, row);
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}