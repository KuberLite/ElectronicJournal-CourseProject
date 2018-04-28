using System;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Windows.Forms;

namespace electronic_journal
{
    public partial class MainFormTeacher : Form, IConnection, IDataGridModes
    {
        string connectionString;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public void DataGridMode()
        {
            DataGridAligment();
            DataGridColumnsSize();
            DataGridReadOnly();
            DataGridAllowUserToAddRows();
            DataGridRowHeadersVisible();
            DataGridAllowUserToResize();
        }

        public void DataGridColumnsSize()
        {
            dataGridNote.Columns[0].Width = 250;
            dataGridNote.Columns[1].Width = 80;
            dataGridNote.Columns[2].Width = 50;
            dataGridNote.Columns[3].Width = 50;
            dataGridNote.Columns[4].Width = 50;
            dataGridNote.Columns[5].Width = 50;
        }

        public void DataGridAligment()
        {
            dataGridNote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridReadOnly()
        {
            dataGridNote.Columns[0].ReadOnly = true;
            dataGridNote.Columns[1].ReadOnly = true;
            dataGridNote.Columns[2].ReadOnly = true;
            dataGridNote.Columns[3].ReadOnly = true;
            dataGridNote.Columns[5].ReadOnly = true;
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

        public MainFormTeacher()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            GetTeacherPulpit(dataTable);
            GetSubjectForSubjectComboBox();
        }

        private string GetTeacherPulpit(DataTable dataTable)
        {
            dataTable = new DataTable();
            SqlDataAdapter("select Pulpit from Person where IdPerson = '" + LoginForm.idPerson + "'", ConnectionSQL()).Fill(dataTable);
            return dataTable.Rows[0][0].ToString();
        }

        private void GetSubjectForSubjectComboBox()
        {
            try
            {
                subjectComboBox.Text = MyResource.selectSubject;
                dataTable = new DataTable();
                SqlDataAdapter("select SubjectName from Subject inner join Pulpit on Subject.Pulpit = Pulpit.IdPulpit where Pulpit.IdPulpit = N'" + GetTeacherPulpit(dataTable).Trim() + "'", ConnectionSQL()).Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    subjectComboBox.Items.Add(dataTable.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        private void openUserTeacherRoomButton_Click(object sender, EventArgs e)
        {
            UserRoomTeacher userRoomTeacher = new UserRoomTeacher();
            userRoomTeacher.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Close();
            loginForm.Show();
        }

        private void LoadDataGrid()
        {
            string query= "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], Note[Оценка]," +
                           "case " +
                           "when Progress.Note >= 4 then '+' " + 
                           "else '-' " + 
                           "end[Зачёт] " +
                           "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                           "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                           "where SubjectName = '" + subjectComboBox.Text.Trim() + "' and Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) + "" +
                           " and NumberGroup = " + Convert.ToInt32(groupComboBox.Text.Trim()) + "";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dataGridNote.DataSource = bindingSource;
            sqlDataAdapter.Update(dataTable);
        }

        private void LoadDB_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            DataGridMode();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Table = new DataTable();
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(Table);
                MessageBox.Show(MyResource.updateInformation, MyResource.update, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainFormTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
