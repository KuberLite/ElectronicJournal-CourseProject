using System;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using electronic_journal.Helpers;
using electronic_journal.Singleton;
using electronic_journal.DAL.Interfaces;
using electronic_journal.DAL.Repositories;

namespace electronic_journal
{
    public partial class MainFormTeacher : Form, IConnection, IDataGridModes
    {
        private readonly string connectionString;

        private readonly IUnitOfWork _database;

        private Database database;
        private UpdateHelper<string> updateHelper;

        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        DataGridViewCell cell;
        UserRoomStudent userRoomStudent;

        public MainFormTeacher()
        {
            InitializeComponent();
            database = Database.GetInstance();
            _database = UnitOfWork.GetInstance();
            updateHelper = new UpdateHelper<string>("Person", "idPerson", "Name");
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Id\n" + _database.UserManager.CurrentUser.Id.ToString() +
                            "\nUsername\n" + _database.UserManager.CurrentUser.Username.ToString() + 
                            "\nPasswordHash\n" + _database.UserManager.CurrentUser.PasswordHash.ToString());
            //GetTeacherPulpit(dataTable);
            //GetSubjectForSubjectComboBox();
        }

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
            dataGridNote.Columns[4].Width = 75;
            dataGridNote.Columns[5].Width = 75;
            dataGridNote.Columns[6].Width = 58;
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
            dataGridNote.Columns[6].ReadOnly = true;
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
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void LoadDataGrid()
        {
            try
            {
                string query = "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация]," +
                               "case " +
                               "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                               "else 'н.а.' " +
                               "end[Принято] " +
                               "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                               "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                               "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                               "where SubjectName = '" + subjectComboBox.Text.Trim() + "' and Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) +
                               " and NumberGroup = " + Convert.ToInt32(groupComboBox.Text.Trim()) + "";
                dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridNote.DataSource = dataTable;
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDB_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void MainFormTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cell = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
            userRoomStudent = new UserRoomStudent();
            userRoomStudent.Show();
            UserRoomStudent_Load();
            
        }

        private void UserRoomStudent_Load()
        {
            UserRoomTextBoxEnabled();
            LoadAllInfo();
            userRoomStudent.loadImageButton.Visible = false;
            userRoomStudent.Height = 290;
        }

        private void UserRoomTextBoxEnabled()
        {
            userRoomStudent.fullNameTextBox.Enabled = false;
            userRoomStudent.groupTextBox.Enabled = false;
            userRoomStudent.courseTextBox.Enabled = false;
            userRoomStudent.genderTextBox.Enabled = false;
            userRoomStudent.professionTextBox.Enabled = false;
            userRoomStudent.birthdayTextBox.Enabled = false;
        }

        private void LoadAllInfo()
        {
            dataTable = new DataTable();
            string query = "select [Name], Gender, NumberGroup, ProfessionName, Course, Birthday, Photo " +
                           "from Person inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join Profession on Groups.Profession = Profession.IdProfession " +
                           "where Person.[Name] = '" + cell.Value.ToString().Trim() + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            TextBoxLoadInfo(dataTable);
            LoadImage(dataTable);
        }

        private void LoadImage(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 1)
            {
                if (dataTable.Rows[0][6] != DBNull.Value)
                {
                    byte[] img = (byte[])(dataTable.Rows[0][6]);
                    if (img == null)
                    {
                        userRoomStudent.picture.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        userRoomStudent.picture.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void TextBoxLoadInfo(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 1)
            {
                userRoomStudent.fullNameTextBox.Text = dataTable.Rows[0][0].ToString();
                userRoomStudent.genderTextBox.Text = dataTable.Rows[0][1].ToString();
                userRoomStudent.groupTextBox.Text = dataTable.Rows[0][2].ToString();
                userRoomStudent.professionTextBox.Text = dataTable.Rows[0][3].ToString();
                userRoomStudent.courseTextBox.Text = dataTable.Rows[0][4].ToString();
                userRoomStudent.birthdayTextBox.Text = dataTable.Rows[0][5].ToString();
            }
        }

        private void dataGridNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cellToUpdate = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
            var valueHeader = cellToUpdate.Value.ToString();
            updateHelper.AddValue(valueHeader);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            List<string> keys = updateHelper.GetCellsIds();
            foreach (var key in keys)
            {
                string query = GenerateUpdateQuery(key);
                ExecuteUpdateQuery(query);
            }
            MessageBox.Show(MyResource.updateInformation, "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateUpdateQuery(string key)
        {
            return "update [Progress] "
                + "set [NoteFirst] = @NoteFirst, [NoteSecond] = @NoteSecond "
                + "where [IdStudent] = '" + key + "' "
                + "and [Subject] = '" + "ООП" + "' ";
        }

        private void ExecuteUpdateQuery(string query)
        {
            SqlConnection connection = database.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand(query, connection);//5-6
            adapter.UpdateCommand.Parameters.Add("@NoteFirst", SqlDbType.Int).SourceColumn = "I Аттестация";
            adapter.UpdateCommand.Parameters.Add("@NoteSecond", SqlDbType.Int).SourceColumn = "II Аттестация";
            adapter.Update(dataTable);
        }
    }
}
