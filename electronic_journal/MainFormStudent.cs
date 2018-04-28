using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace electronic_journal
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

        private void MainFormStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void DataGridMode()
        {
            DataGridColumnsSize();
            DataGridAligment();
            DataGridReadOnly();
            DataGridAllowUserToAddRows();
            DataGridRowHeadersVisible();
            DataGridAllowUserToResize();
        }

        public void DataGridAligment()
        {
            dataGridNote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridColumnsSize()
        {
            dataGridNote.Columns[0].Width = 300;
            dataGridNote.Columns[1].Width = 70;
            dataGridNote.Columns[2].Width = 70;
            dataGridNote.Columns[3].Width = 55;
            dataGridNote.Columns[4].Width = 55;
        }

        public void DataGridReadOnly()
        {
            dataGridNote.ReadOnly = true;
        }

        public void DataGridAllowUserToAddRows()
        {
            dataGridNote.AllowUserToAddRows = false;
        }

        public void DataGridRowHeadersVisible()
        {
            dataGridNote.RowHeadersVisible = false;
        }

        public void DataGridAllowUserToResize()
        {
            dataGridNote.AllowUserToResizeColumns = false;
            dataGridNote.AllowUserToResizeRows = false; ;
        }
    }
}
