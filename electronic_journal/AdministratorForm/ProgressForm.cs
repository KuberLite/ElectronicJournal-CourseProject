using electronic_journal.Forms;
using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class ProgressForm : Form, IConnection, IDataGridModes
    {
        DataGridViewCell cell;
        UserRoomStudent userRoomStudent;
        DataTable dataTable;
        private readonly string connectionString;
        string valueUpdate;
        int count = 0;

        public ProgressForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            subjectComboBox.Text = MyResource.selectSubject;
            GetfacultyForFacultyCombobox();
            SortedEnabled();
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter data = new SqlDataAdapter(query, ConnectionSQL());
            return data;
        }

        #region DataGridModes
        public void DataGridMode()
        {
            DataGridAligment(dataGridProgress);
            DataGridAllowUserToAddRows(dataGridProgress);
            DataGridColumnsSize(dataGridProgress);
            DataGridAllowUserToResize(dataGridProgress);
            DataGridReadOnly(dataGridProgress);
            DataGridRowHeadersVisible(dataGridProgress);
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
            dataGridProgress.Columns[0].Width = 210;
            dataGridProgress.Columns[1].Width = 80;
            dataGridProgress.Columns[2].Width = 50;
            dataGridProgress.Columns[3].Width = 45;
            dataGridProgress.Columns[4].Width = 75;
            dataGridProgress.Columns[5].Width = 75;
            dataGridProgress.Columns[6].Width = 58;
        }

        public void DataGridReadOnly(DataGridView dataGridView)
        {
            dataGridProgress.ReadOnly = true;
        }

        public void DataGridRowHeadersVisible(DataGridView dataGridView)
        {
            dataGridProgress.RowHeadersVisible = false;

        }
        #endregion

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;

            foreach (var obj in myCombo.Items)
            {
                maxWidth = 580;
            }
            return maxWidth;
        }

        private void GetSubjectForSubjectComboBox()
        {
            DataTable data = new DataTable();
            string query = "select SubjectName from [Subject] inner join Pulpit " +
                           "on [Subject].Pulpit = Pulpit.IdPulpit inner join Faculty " +
                           "on Pulpit.Faculty = Faculty.IdFaculty where Faculty.IdFaculty = '" + facultyComboBox.Text + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                subjectComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetfacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            facultyComboBox.Text = MyResource.selectFaculty;
            string query = "select IdFaculty from Faculty";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for(int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetProgressFromFaculty()
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
                               " and NumberGroup = " + Convert.ToInt32(numberGroupComboBox.Text.Trim()) + "";
                DataTable dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridProgress.DataSource = dataTable;
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
                               " and NumberGroup = " + Convert.ToInt32(numberGroupComboBox.Text.Trim()) + "";
                DataTable dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridProgress.DataSource = dataTable;
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (count != 0)
            {
                subjectComboBox.Items.Clear();
            }
            GetSubjectForSubjectComboBox();
            subjectComboBox.DropDownWidth = DropDownWidth(subjectComboBox);
            count++;
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
            firstNoteTextBox.Enabled = true;
            secondNoteTextBox.Enabled = true;
            plusMinusСomboBox.Enabled = true;
        }

        #region UserProfile

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
            DataTable dataTable = new DataTable();
            string query = "select [Name], Gender, NumberGroup, ProfessionName, Course, Birthday, Photo " +
                           "from Person inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join Profession on Groups.Profession = Profession.IdProfession " +
                           "where Person.[Name] = '" + cell.Value.ToString().Trim() + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            TextBoxLoadInfo(dataTable);
            LoadImage(dataTable);
        }

        private void UserRoomStudent_Load()
        {
            UserRoomTextBoxEnabled();
            LoadAllInfo();
            userRoomStudent.loadImageButton.Visible = false;
            userRoomStudent.Height = 290;
        }
        #endregion

        private void dataGridNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cellUpdate = (DataGridViewCell)dataGridProgress.Rows[e.RowIndex].Cells[0];
            valueUpdate = cellUpdate.Value.ToString();
        }

        private void dataGridNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cell = (DataGridViewCell)dataGridProgress.Rows[e.RowIndex].Cells[0];
            userRoomStudent = new UserRoomStudent();
            userRoomStudent.Show();
            UserRoomStudent_Load();
        }

        #region SortedMethods
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
                               " and NumberGroup = " + Convert.ToInt32(numberGroupComboBox.Text.Trim()) + " " +
                               "and NoteFirst >= '" + note + "'";
                dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridProgress.DataSource = dataTable;
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
                               " and NumberGroup = " + Convert.ToInt32(numberGroupComboBox.Text.Trim()) + " " +
                               "and NoteSecond >= '" + note + "'";
                dataTable = new DataTable();
                SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
                dataGridProgress.DataSource = dataTable;
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                           " and NumberGroup = " + Convert.ToInt32(numberGroupComboBox.Text.Trim()) + " " +
                           "and (Progress.NoteFirst + Progress.NoteSecond)/2 >= 4";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridProgress.DataSource = dataTable;
            DataGridMode();
        }

        private void NoteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
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
                           " and NumberGroup = " + Convert.ToInt32(numberGroupComboBox.Text.Trim()) + " " +
                           "and (Progress.NoteFirst + Progress.NoteSecond)/2 < 4";
            dataTable = new DataTable();
            SqlDataAdapter(query, ConnectionSQL()).Fill(dataTable);
            dataGridProgress.DataSource = dataTable;
            DataGridMode();
        }

        private void SortedEnabled()
        {
            if (dataGridProgress.DataSource == null)
            {
                firstNoteTextBox.Enabled = false;
                secondNoteTextBox.Enabled = false;
                plusMinusСomboBox.Enabled = false;
            }
        }

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
        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}