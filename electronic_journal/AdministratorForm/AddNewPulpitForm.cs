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
    public partial class AddNewPulpitForm : Form, IConnection
    {
        private readonly string connectionString;

        public AddNewPulpitForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void AddNewPulpitForm_Load(object sender, EventArgs e)
        {
            GetfacultyForFacultyCombobox();
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionSQL());
            return adapter;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            return sqlDataAdapter;
        }

        private void GetfacultyForFacultyCombobox()
        {
            DataTable data = new DataTable();
            facultyComboBox.Text = MyResource.selectFaculty;
            SqlCommand sqlCommand = new SqlCommand("GetFacultyId", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter(sqlCommand).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                facultyComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void AddNewPulpitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPulpit();
        }

        private void AddPulpit()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("AddNewPulpit", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@pulpitName", namePulpitTextBox.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@pulpit", miniNameTextBox.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@faculty", facultyComboBox.Text.Trim());
                sqlCommand.ExecuteReader();
                MessageBox.Show(MyResource.correctlyAdd, MyResource.addStudent);
                this.Hide();
            }
            catch
            {
                MessageBox.Show(MyResource.errorPulpit, MyResource.error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
