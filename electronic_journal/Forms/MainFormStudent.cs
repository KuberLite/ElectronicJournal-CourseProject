using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace electronic_journal.Forms
{
    public partial class MainFormStudent : Form, IConnection, IDataGridModes
    {
        public string connectionString;
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;
        
        public MainFormStudent()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void MainFormStudent_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            string query = "select SubjectName[Дисциплина], NoteFirst[I Аттестация], NoteSecond[II Аттестация], round((Progress.NoteFirst + Progress.NoteSecond) / 2, 2)[Среднее], " +
                           "case " + 
                           "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                           "else 'н.а.' " + 
                           "end[Принято] " +
                           "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                           "inner join[Subject] on Progress.[Subject] = [Subject].SubjectId where Person.IdPerson = '" + LoginForm.idPerson + "'";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridNote.DataSource = dataTable;
            DataGridMode();
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection  sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        private void userRoomButton_Click(object sender, EventArgs e)
        {
            UserRoomStudent userRoomStudent = new UserRoomStudent();
            userRoomStudent.Show();
        }

        private void MainFormStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void DataGridMode()
        {
            DataGridColumnsSize(dataGridNote);
            DataGridAligment(dataGridNote);
            DataGridReadOnly(dataGridNote);
            DataGridAllowUserToAddRows(dataGridNote);
            DataGridRowHeadersVisible(dataGridNote);
            DataGridAllowUserToResize(dataGridNote);
        }

        public void DataGridAligment(DataGridView dataGridNote)
        {
            dataGridNote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridColumnsSize(DataGridView dataGridNote)
        {
            dataGridNote.Columns[0].Width = 300;
            dataGridNote.Columns[1].Width = 70;
            dataGridNote.Columns[2].Width = 70;
            dataGridNote.Columns[3].Width = 55;
            dataGridNote.Columns[4].Width = 55;
        }

        public void DataGridReadOnly(DataGridView dataGridNote)
        {
            dataGridNote.ReadOnly = true;
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
            dataGridNote.AllowUserToResizeRows = false; ;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
