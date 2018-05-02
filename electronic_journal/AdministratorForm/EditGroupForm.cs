using electronic_journal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace electronic_journal.AdministratorForm
{
    public partial class EditGroupForm : Form, IConnection, IDataGridModes
    {
        DataTable dataForUpdate;
        SqlDataAdapter dataAdapterForUpdate;
        private readonly string connectionString;
        string querySubject;

        public EditGroupForm()
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

        public void DataGridMode()
        {
            DataGridAligment(dataGridView);
            DataGridAllowUserToAddRows(dataGridView);
            DataGridColumnsSize(dataGridView);
            DataGridAllowUserToResize(dataGridView);
            DataGridReadOnly(dataGridView);
            DataGridRowHeadersVisible(dataGridView);
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sql = new SqlConnection(connectionString);
            return sql;
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

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return dataAdapter;
        }

        private void GetSubjectForUpdate()
        {
            dataForUpdate = new DataTable();
            querySubject = "select SubjectId[ID Предмета], Pulpit[Кафедра], SubjectName[Название предмета] from [Subject] inner join Pulpit " +
                           "on [Subject].Pulpit = Pulpit.IdPulpit inner join Faculty " +
                           "on Pulpit.Faculty = Faculty.IdFaculty where Faculty.IdFaculty = '" + facultyComboBox.Text + "'";
            dataAdapterForUpdate = new SqlDataAdapter(querySubject, ConnectionSQL());
            dataAdapterForUpdate.Fill(dataForUpdate);
            dataGridView.DataSource = dataForUpdate;
        }

        private void GetPulpitForPulpitComboBox()
        {
            DataTable data = new DataTable();
            string query = "select PulpitName from Faculty inner join Pulpit " +
                           "on Faculty.IdFaculty = Pulpit.Faculty " +
                           "where Faculty.IdFaculty = '" + facultyComboBox.Text + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                pulpitComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void GetfacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            facultyComboBox.Text = MyResource.selectFaculty;
            string query = "select IdFaculty from Faculty";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (count != 0)
            {
                pulpitComboBox.Items.Clear();
            }
            GetPulpitForPulpitComboBox();
            pulpitComboBox.DropDownWidth = DropDownWidth(pulpitComboBox);
            count++;
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void pulpitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetSubjectForUpdate();
                DataGridMode();
            }
            catch (Exception)
            {
                MessageBox.Show(MyResource.checkInformation, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataForUpdate = new DataTable();
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapterForUpdate);
            dataAdapterForUpdate.Update(dataForUpdate);
        }
    }
}