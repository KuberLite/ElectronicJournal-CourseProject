using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class EditSubjectForm : Form, IConnection, IDataGridModes
    {
        private readonly string connectionString;
        string valueUpdate;
        int count = 0;

        public EditSubjectForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            facultyComboBox.Text = MyResource.selectFaculty;
            pulpitComboBox.Text = MyResource.selectPulpit;
            GetfacultyForFacultyCombobox();
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;

            foreach (var obj in myCombo.Items)
            {
                maxWidth = 580;
            }
            return maxWidth;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sql = new SqlConnection(connectionString);
            return sql;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            return sqlDataAdapter;
        }

        #region DataGridModes
        public void DataGridMode()
        {
            DataGridAligment(dataGridView);
            DataGridAllowUserToAddRows(dataGridView);
            DataGridColumnsSize(dataGridView);
            DataGridAllowUserToResize(dataGridView);
            DataGridReadOnly(dataGridView);
            DataGridRowHeadersVisible(dataGridView);
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
            dataGridView.Columns[0].Width = 60;
            dataGridView.Columns[1].Width = 60;
            dataGridView.Columns[2].Width = 436;
        }

        public void DataGridReadOnly(DataGridView dataGridView)
        {
            dataGridView.ReadOnly = false;
        }

        public void DataGridRowHeadersVisible(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;
        }
        #endregion

        private void GetSubjectForUpdate()
        {
            DataTable dataForUpdate = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetSubjectForUpdate", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(dataForUpdate);
            dataGridView.DataSource = dataForUpdate;
        }

        private void GetPulpitForPulpitComboBox()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetPulpitForPulpitComboBoxByAdmin", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                pulpitComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetfacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("GetFacultyId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (count != 0)
            {
                pulpitComboBox.Items.Clear();
            }
            GetPulpitForPulpitComboBox();
            pulpitComboBox.DropDownWidth = DropDownWidth(pulpitComboBox);
            count++;
        }

        private void pulpitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dataForUpdate = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SelectSubjectByFacultyAndPulpit", ConnectionSQL());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text);
                sqlCommand.Parameters.AddWithValue("@pulpit", pulpitComboBox.Text);
                SqlDataAdapter(sqlCommand).Fill(dataForUpdate);
                dataGridView.DataSource = dataForUpdate;
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cellUpdate = (DataGridViewCell)dataGridView.Rows[e.RowIndex].Cells[0];
            valueUpdate = cellUpdate.Value.ToString();
            UpdateGroup(e.ColumnIndex, e.RowIndex);
        }

        private void UpdateGroup(int column, int row)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlDataReader dataReader;
                sqlConnection.Open();
                //"update Subject set SubjectName = '" + dataGridView["Название предмета", row].Value + "', Pulpit = '" + dataGridView["Кафедра", row].Value + "'" +  "where SubjectId = '" + valueUpdate + "'"
                SqlCommand update = new SqlCommand("UpdateGroup", sqlConnection);
                update.CommandType = CommandType.StoredProcedure;
                update.Parameters.AddWithValue("@subjectName", dataGridView["Название предмета", row].Value);
                update.Parameters.AddWithValue("@pulpit", dataGridView["Кафедра", row].Value);
                update.Parameters.AddWithValue("@subjectId", valueUpdate);
                dataReader = update.ExecuteReader();
                dataReader.Close();
                GetSubjectForUpdate();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}