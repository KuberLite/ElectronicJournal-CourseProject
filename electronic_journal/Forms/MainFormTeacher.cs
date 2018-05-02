﻿using System;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using electronic_journal.Interfaces;

namespace electronic_journal.Forms
{
    public partial class MainFormTeacher : Form, IConnection, IDataGridModes
    {
        string valueUpdate, idPerson;
        private readonly string connectionString;

        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        DataGridViewCell cell;
        UserRoomStudent userRoomStudent;

        public MainFormTeacher()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void DataGridMode()
        {
            DataGridAligment(dataGridNote);
            DataGridColumnsSize(dataGridNote);
            DataGridReadOnly(dataGridNote);
            DataGridAllowUserToAddRows(dataGridNote);
            DataGridRowHeadersVisible(dataGridNote);
            DataGridAllowUserToResize(dataGridNote);
        }

        public void DataGridColumnsSize(DataGridView dataGridNote)
        {
            dataGridNote.Columns[0].Width = 250;
            dataGridNote.Columns[1].Width = 80;
            dataGridNote.Columns[2].Width = 50;
            dataGridNote.Columns[3].Width = 50;
            dataGridNote.Columns[4].Width = 75;
            dataGridNote.Columns[5].Width = 75;
            dataGridNote.Columns[6].Width = 58;
        }

        public void DataGridAligment(DataGridView dataGridNote)
        {
            dataGridNote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void DataGridReadOnly(DataGridView dataGridNote)
        {
            dataGridNote.Columns[0].ReadOnly = true;
            dataGridNote.Columns[1].ReadOnly = true;
            dataGridNote.Columns[2].ReadOnly = true;
            dataGridNote.Columns[3].ReadOnly = true;
            dataGridNote.Columns[6].ReadOnly = true;
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

        private void MainFormTeacher_Load(object sender, EventArgs e)
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
            DataGridViewCell cellUpdate = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
            valueUpdate = cellUpdate.Value.ToString();
        }

        private void GetUpdate()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                GetIdPerson();
                MessageBox.Show(idPerson);
                string queryUpdate = "update Progress set NoteFirst = @NoteFirst, NoteSecond = @NoteSecond " +
                                     "where IdStudent = '" + idPerson + "' " +
                                     "and [Subject] = 'ООП'";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = new SqlCommand(queryUpdate, conn);//5-6
                adapter.UpdateCommand.Parameters.Add("@NoteFirst", SqlDbType.Int).SourceColumn = "I Аттестация";
                adapter.UpdateCommand.Parameters.Add("@NoteSecond", SqlDbType.Int).SourceColumn = "II Аттестация";
                adapter.Update(dataTable);
                MessageBox.Show(MyResource.updateInformation, MyResource.update, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }            
        }

        private void GetIdPerson()
        {
            string query = "select IdPerson from Person where [Name] = '" + valueUpdate.Trim() + "'";
            DataTable data = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            idPerson = data.Rows[0][0].ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            GetUpdate();            
        }

        private void dataGridNote_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridNote_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridNote.EndEdit();
            GetUpdate();
        }

        private void MainFormTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
