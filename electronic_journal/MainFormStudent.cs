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
            GetSubject();
            subjectComboBoxStudent.Text = MyResource.selectSubject;
            subjectComboBoxStudent.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadInfo()
        {
            string query = "select SubjectName[Дисциплина], Note[Оценка], " +
                           "case " +
                           "when Progress.Note >= 4 then '+' " +
                           "else '-' " +
                           "end[Зачёт] " +
                           "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                           "inner join[Subject] on Progress.[Subject] = [Subject].SubjectId where [Subject].SubjectName = '" + subjectComboBoxStudent.Text.Trim() + "' and Person.IdPerson = '" + LoginForm.idPerson + "'";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridNote.DataSource = dataTable;
            DataGridMode();
        }

        private void subjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInfo();
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }

        private void GetSubject()
        {
            try
            {
                dataTable = new DataTable();
                string query = "select SubjectName from Person inner join Progress on Person.IdPerson = Progress.IdStudent inner join [Subject] on Progress.[Subject] = [Subject].SubjectId where Person.IdPerson = '" + LoginForm.idPerson + "'";
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                MessageBox.Show(LoginForm.idPerson.ToString());
                MessageBox.Show(dataTable.Rows.Count.ToString());
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    subjectComboBoxStudent.Items.Add(dataTable.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataGridInfo()
        {
            string query = "select [Subject][Дисциплина], Note[Оценка]," +
                           "case " +
                           "when Progress.Note >= 4 then '+' " + 
                           "else '-' " + 
                           "end[Зачёт] " +
                           "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                           "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                           "where SubjectName = '" + subjectComboBoxStudent.Text.Trim();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            sqlDataAdapter.Fill(dataTable);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dataGridNote.DataSource = bindingSource;
            sqlDataAdapter.Update(dataTable);
            DataGridReadOnly();
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
        }

        public void DataGridAligment()
        {
            dataGridNote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridColumnsSize()
        {
            dataGridNote.Columns[0].Width = 250;
        }

        public void DataGridReadOnly()
        {
            dataGridNote.ReadOnly = true;
        }

        public void DataGridAllowUserToAddRows()
        {
            dataGridNote.AllowUserToAddRows = false;
        }
    }
}
