using System;
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
        string valueUpdate, idPerson, nameTeacher;
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

        private void GetName()
        {
            DataTable table = new DataTable();
            string query = "select [Name] from Person where IdPerson = '" + LoginForm.idPerson + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(table);
            nameTeacher = table.Rows[0][0].ToString();
        }

        private void MainFormTeacher_Load(object sender, EventArgs e)
        {
            GetTeacherPulpit(dataTable);
            GetSubjectForSubjectComboBox();
            SortedEnabled();
            GetName();
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;

            foreach (var obj in myCombo.Items)
            {
                maxWidth = 500;
            }
            return maxWidth;
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

        #region DataGridModes
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
            dataGridNote.EnableHeadersVisualStyles = false;
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
        #endregion

        #region SortedMethod
        private void TextBoxNoteValidating(TextBox textBox)
        {
            if (textBox.Text != "")
            {
                textBox.MaxLength = 2;
                textBox.MaxLength = 2;
                if (Convert.ToInt32(textBox.Text) >= 10)
                {
                    textBox.Text = "10";
                }
            }
        }

        private void SortedEnabled()
        {
            if (dataGridNote.DataSource == null)
            {
                firstNoteTextBox.Enabled = false;
                secondNoteTextBox.Enabled = false;
                plusMinusСomboBox.Enabled = false;
            }
        }

        private void firstNoteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (firstNoteTextBox.Text == "")
            {
                LoadDataGrid();
                TextBoxNoteValidating(firstNoteTextBox);
            }
            else
            {
                SortMethodByFirstNote(Convert.ToInt32(firstNoteTextBox.Text.Trim()));
                TextBoxNoteValidating(firstNoteTextBox);
            }
        }

        private void secondNoteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (secondNoteTextBox.Text == "")
            {
                LoadDataGrid();
                TextBoxNoteValidating(secondNoteTextBox);
            }
            else
            {
                SortMethodBySecondNote(Convert.ToInt32(secondNoteTextBox.Text.Trim()));
                TextBoxNoteValidating(secondNoteTextBox);
            }
        }

        private void SortMethodByFirstNote(int note)
        {
            try
            {
                string query = "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация]," +
                               "case " +
                               "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                               "else '-' " +
                               "end[Допуск] " +
                               "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                               "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                               "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                               "where SubjectName = '" + subjectComboBox.Text.Trim() + "' and Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) +
                               " and NumberGroup = " + Convert.ToInt32(groupComboBox.Text.Trim()) + " " +
                               "and NoteFirst >= '" + note + "'";
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

        private void SortMethodBySecondNote(int note)
        {
            try
            {
                string query = "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация]," +
                               "case " +
                               "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                               "else '-' " +
                               "end[Допуск] " +
                               "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                               "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                               "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                               "where SubjectName = '" + subjectComboBox.Text.Trim() + "' and Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) +
                               " and NumberGroup = " + Convert.ToInt32(groupComboBox.Text.Trim()) + " " +
                               "and NoteSecond >= '" + note + "'";
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
        #endregion

        #region DataGridLoad
        private void LoadDataGrid()
        {
            try
            {
                string query = "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация]," +
                               "case " +
                               "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                               "else '-' " +
                               "end[Допуск] " +
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

        private void dataGridNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cell = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
            userRoomStudent = new UserRoomStudent();
            userRoomStudent.Show();
            UserRoomStudent_Load();
        }

        private void dataGridNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cellUpdate = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
            valueUpdate = cellUpdate.Value.ToString();
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
                subjectComboBox.DropDownWidth = DropDownWidth(subjectComboBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetIdPerson()
        {
            string query = "select IdPerson from Person where [Name] = '" + valueUpdate.Trim() + "'";
            DataTable data = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            idPerson = data.Rows[0][0].ToString();
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
            firstNoteTextBox.Enabled = true;
            secondNoteTextBox.Enabled = true;
            plusMinusСomboBox.Enabled = true;
        }

        private void dataGridNote_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateNote(e.ColumnIndex, e.RowIndex);
        }

        private void UpdateNote(int column, int row)
        {
            GetIdPerson();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataReader dataReader;
            sqlConnection.Open();
            SqlCommand update = new SqlCommand("update Progress set NoteFirst = " + Convert.ToInt32(dataGridNote["I Аттестация", row].Value) + ", NoteSecond = " + dataGridNote["II Аттестация", row].Value + " " +
                                               "where IdStudent = '" + idPerson + "' " +
                                               "and [Subject] = 'ООП'", sqlConnection);
            dataReader = update.ExecuteReader();

            dataReader.Close();
            LoadDataGrid();
            AddTimeTableUpdate();
        }
        #endregion

        private void AddTimeTableUpdate()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("AddTimeUpdate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            GetSqlCommand(sqlCommand);
            sqlCommand.ExecuteNonQuery();
        }

        private void GetSqlCommand(SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@updateId", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@personName", nameTeacher);
            sqlCommand.Parameters.AddWithValue("@nameTable", subjectComboBox.Text + " " + courseComboBox.Text + " курс " + groupComboBox.Text + " группа");
            sqlCommand.Parameters.AddWithValue("@dateUpdate", DateTime.Now.ToString());
        }

        #region StudentProfile
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

        private void SortMethodByAttestationPlus()
        {
            string query = "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация]," +
                           "case " +
                           "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                           "else '-' " +
                           "end[Допуск] " +
                           "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                           "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                           "where SubjectName = '" + subjectComboBox.Text.Trim() + "' and Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) +
                           " and NumberGroup = " + Convert.ToInt32(groupComboBox.Text.Trim()) + " " +
                           "and (Progress.NoteFirst + Progress.NoteSecond)/2 >= 4";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridNote.DataSource = dataTable;
            DataGridMode();
        }

        private void plusMinusСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plusMinusСomboBox.Text == "+")
            {
                SortMethodByAttestationPlus();
            }
            else if (plusMinusСomboBox.Text == "-")
            {
                SortMethodByAttestationMinus();
            }
            else
            {
                LoadDataGrid();
            }
        }

        private void firstNoteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void secondNoteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void SortMethodByAttestationMinus()
        {
            string query = "select [Name][ФИО], [Subject][Дисциплина], NumberGroup[Номер группы], Course[Курс], NoteFirst[I Аттестация], NoteSecond[II Аттестация]," +
                           "case " +
                           "when(Progress.NoteFirst + Progress.NoteSecond) / 2 >= 4 then '+' " +
                           "else '-' " +
                           "end[Допуск] " +
                           "from Person inner join Progress on Person.IdPerson = Progress.IdStudent " +
                           "inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join [Subject] on Progress.[Subject] = [Subject].SubjectId " +
                           "where SubjectName = '" + subjectComboBox.Text.Trim() + "' and Course = " + Convert.ToInt32(courseComboBox.Text.Trim()) +
                           " and NumberGroup = " + Convert.ToInt32(groupComboBox.Text.Trim()) + " " +
                           "and (Progress.NoteFirst + Progress.NoteSecond)/2 < 4";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridNote.DataSource = dataTable;
            DataGridMode();
        }
        #endregion

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

        private void MainFormTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}