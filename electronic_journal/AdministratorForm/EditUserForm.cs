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
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;
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

        private void GetPulpitForPulpitComboBox()
        {
            DataTable data = new DataTable();
            string query = "select PulpitName from Faculty inner join Pulpit " +
                           "on Faculty.IdFaculty = Pulpit.Faculty " +
                           "where Faculty.IdFaculty = '" + facultyComboBox.Text + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                pulpitComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetfacultyForFacultyCombobox()
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

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
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
            dataGridPerson.Columns[0].ReadOnly = true;
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
                string query = "select IdPerson[ID], [Name][ФИО], Pulpit[Кафедра], Gender[Пол], Birthday[Дата рождения] " +
                           "from Person inner join Pulpit on Person.Pulpit = Pulpit.IdPulpit " +
                           "where Pulpit.Faculty = '" + facultyComboBox.Text.Trim() + "'";
                dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridPerson.DataSource = dataTable;
            }
            else
            {
                string query = "select IdPerson[ID], [Name] [ФИО], NumberGroup[Группа], Gender[Пол], Birthday[Дата рождения] " +
                               "from Person inner join Groups on Person.IdGroup = Groups.IdGroup " +
                               "inner join Faculty on Groups.Faculty = Faculty.IdFaculty " +
                               "where Faculty.IdFaculty = '" + facultyComboBox.Text.Trim() + "'";

                dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridPerson.DataSource = dataTable;
            }
            DataGridMode();
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRole();
            if (role == "Teacher")
            {
                groupComboBox.Enabled = false;
                courseComboBox.Enabled = false;
                roleComboBox.Enabled = true;
                pulpitComboBox.Enabled = true;
                facultyComboBox.Enabled = true;
            }
            else
            {
                groupComboBox.Enabled = true;
                courseComboBox.Enabled = true;
                roleComboBox.Enabled = true;
                pulpitComboBox.Enabled = false;
                facultyComboBox.Enabled = true;
            }
        }

        private void pulpitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select IdPerson[ID], [Name][ФИО], Pulpit[Кафедра], Gender[Пол], Birthday[Дата рождения] " +
                           "from Person inner join Pulpit on Person.Pulpit = Pulpit.IdPulpit " +
                           "where Pulpit.PulpitName = '" + pulpitComboBox.Text.Trim() + "'";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridPerson.DataSource = dataTable;
            DataGridMode();
        }

        private void dataGridPerson_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateStudentInfo(e.ColumnIndex, e.RowIndex);
        }

        private void UpdateStudentInfo(int column, int row)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataReader dataReader;
            sqlConnection.Open();
            SqlCommand update = new SqlCommand("UPDATE Person SET [Name] = '" + dataGridPerson["ФИО", row].Value.ToString() + "', " +
                                               "Pulpit = '" + dataGridPerson["Кафедра", row].Value.ToString() + "', " +
                                               "Gender = '" + dataGridPerson["Пол", row].Value.ToString() + "', " +
                                               "Birthday = '" + Convert.ToDateTime(dataGridPerson["Дата рождения", row].Value) + "' " +
                                               "WHERE IdPerson = '" + dataGridPerson["ID", row].Value + "'", sqlConnection);
            dataReader = update.ExecuteReader();
            dataReader.Close();
            dataGridPerson.UpdateCellValue(column, row);
        }
    }
}
