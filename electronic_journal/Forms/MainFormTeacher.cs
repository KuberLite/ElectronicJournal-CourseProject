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
            SqlCommand sqlCommand = new SqlCommand("GetNameForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPerson", LoginForm.idPerson);
            SqlDataAdapter(sqlCommand).Fill(table);
            nameTeacher = table.Rows[0][0].ToString();
        }

        private void MainFormTeacher_Load(object sender, EventArgs e)
        {
            GetTeacherPulpit();
            GetSubjectForSubjectComboBox();
            SortedEnabled();
            GetName();
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
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
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SortByFirstNoteMainFormTeacher", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@subject", subjectComboBox.Text);
                sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
                sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
                sqlCommand.Parameters.AddWithValue("@noteFirst", note);
                SqlDataAdapter(sqlCommand).Fill(dataTable);
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
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SortBySecondNoteForMainFormTeacher", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@subject", subjectComboBox.Text);
                sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
                sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
                sqlCommand.Parameters.AddWithValue("@noteSecond", note);
                SqlDataAdapter(sqlCommand).Fill(dataTable);
                dataGridNote.DataSource = dataTable;
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SortMethodByAttestationMinus()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SortByAttestationMinusForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@subject", subjectComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
            sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            dataGridNote.DataSource = dataTable;
            DataGridMode();
        }

        private void SortMethodByAttestationPlus()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SortByAttestationPlusForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@subject", subjectComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
            sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
            SqlDataAdapter(sqlCommand).Fill(dataTable);
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
        #endregion

        #region DataGridLoad
        private void LoadDataGrid()
        {
            try
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("LoadProgressInfoForMainFormTeacher", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@subjectId", subjectComboBox.Text);
                sqlCommand.Parameters.AddWithValue("@numberGroup", Convert.ToInt32(groupComboBox.Text));
                sqlCommand.Parameters.AddWithValue("@course", Convert.ToInt32(courseComboBox.Text));
                SqlDataAdapter(sqlCommand).Fill(dataTable);
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
            if (e.RowIndex != -1)
            {
                cell = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
                userRoomStudent = new UserRoomStudent();
                UserRoomStudent_Load();
                userRoomStudent.ShowDialog();
            }
        }

        private string GetTeacherPulpit()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetTeacherPulpitForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPerson", LoginForm.idPerson);
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            return dataTable.Rows[0][0].ToString();
        }

        private void GetSubjectForSubjectComboBox()
        {
            subjectComboBox.Text = MyResource.selectSubject;
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetSubjectForSubjectComboBoxForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@pulpitId", GetTeacherPulpit());
            SqlDataAdapter(sqlCommand).Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                subjectComboBox.Items.Add(dataTable.Rows[i][0].ToString());
            }
        }

        private void GetIdPerson()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetIdPersonForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@namePerson", valueUpdate);
            SqlDataAdapter(sqlCommand).Fill(data);
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
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewCell cellUpdate = (DataGridViewCell)dataGridNote.Rows[e.RowIndex].Cells[0];
                    valueUpdate = cellUpdate.Value.ToString();
                    UpdateNote(e.ColumnIndex, e.RowIndex);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.correctNote, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNote(int column, int row)
        {
            GetIdPerson();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataReader dataReader;
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UpdateNoteForMainFormTeacher", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@noteFirst", Convert.ToInt32(dataGridNote["I Аттестация", row].Value));
            sqlCommand.Parameters.AddWithValue("@noteSecond", Convert.ToInt32(dataGridNote["II Аттестация", row].Value));
            sqlCommand.Parameters.AddWithValue("@subject", subjectComboBox.Text);
            sqlCommand.Parameters.AddWithValue("@idPerson", idPerson);
            dataReader = sqlCommand.ExecuteReader();
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
            sqlCommand.Parameters.AddWithValue("@updateId", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@personName", nameTeacher);
            sqlCommand.Parameters.AddWithValue("@nameTable", subjectComboBox.Text + " " + courseComboBox.Text + " курс " + groupComboBox.Text + " группа");
            sqlCommand.Parameters.AddWithValue("@dateUpdate", DateTime.Now.ToString());
            sqlCommand.ExecuteNonQuery();
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
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("LoadInfoAboutStudentForMainFormTeacher", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@personName", cell.Value.ToString().Trim());
            SqlDataAdapter(sqlCommand).Fill(dataTable);
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
        #endregion

        private void openUserTeacherRoomButton_Click(object sender, EventArgs e)
        {
            UserRoomTeacher userRoomTeacher = new UserRoomTeacher();
            userRoomTeacher.ShowDialog();
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