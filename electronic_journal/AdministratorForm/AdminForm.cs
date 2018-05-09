using electronic_journal.Forms;
using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class AdminForm : Form, IConnection, IDataGridModes
    {
        private readonly string connectionString;

        public AdminForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(query, ConnectionSQL());
            return sqlData;
        }

        public void DataGridMode()
        {
            DataGridAligment(resultDataGrid);
            DataGridAllowUserToAddRows(resultDataGrid);
            DataGridAllowUserToResize(resultDataGrid);
            DataGridColumnsSize(resultDataGrid);
            DataGridReadOnly(resultDataGrid);
            DataGridRowHeadersVisible(resultDataGrid);
        }

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
            resultDataGrid.Columns[0].Width = 200;
            resultDataGrid.Columns[1].Width = 350;
            resultDataGrid.Columns[2].Width = 102;
        }

        public void DataGridReadOnly(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = true;
        }

        public void DataGridRowHeadersVisible(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void progressButton_Click(object sender, EventArgs e)
        {
            ProgressForm progress = new ProgressForm();
            progress.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            EditAllForm editAllForm = new EditAllForm();
            editAllForm.Show();
        }

        private void addTeacherButton_Click(object sender, EventArgs e)
        {
            AddNewTeacherForm addNewTeacher = new AddNewTeacherForm();
            addNewTeacher.Show();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AddNewStudentForm studentForm = new AddNewStudentForm();
            studentForm.Show();
        }

        private void addPulpitButton_Click(object sender, EventArgs e)
        {
            AddNewPulpitForm pulpitForm = new AddNewPulpitForm();
            pulpitForm.Show();
        }

        private void LoadDataGrid()
        {
            string query = "select PersonName[Имя преподавателя], NameTable[Таблица], DateUpdate[Дата обновления] from TimeUpdate";
            DataTable dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            resultDataGrid.DataSource = dataTable;
            DataGridMode();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}