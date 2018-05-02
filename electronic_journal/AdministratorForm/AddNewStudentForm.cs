﻿using electronic_journal.Interfaces;
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
    public partial class AddNewStudentForm : Form, IConnection
    {
        private readonly string connectionString;

        public AddNewStudentForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sql = new SqlConnection(connectionString);
            return sql;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return dataAdapter;
        }

        private void GetFacultyForFacultyCombobox()
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

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroupForGroupComboBox();
            MessageBox.Show("123");
        }

        private void GetGroupForGroupComboBox()
        {
            DataTable data = new DataTable();
            string query = "select IdGroup from Groups inner join Faculty " +
                           "on Groups.Faculty = Faculty.IdFaculty " +
                           "where Faculty.IdFaculty = '" + facultyComboBox.Text.Trim() + "'";
            SqlDataAdapter(query, ConnectionSQL()).Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                groupComboBox.Items.Add(data.Rows[i][0].ToString());
            }
        }

        private void AddNewStudentForm_Load(object sender, EventArgs e)
        {
            GetFacultyForFacultyCombobox();
            groupComboBox.Text = MyResource.selectGroup;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewStudent();
            ClearWindow();
        }

        private void ClearWindow()
        {
            nameTextBox.Clear();
            facultyComboBox.Text = MyResource.selectFaculty;
            groupComboBox.Text = MyResource.selectProfession;
            genderComboBox.Text = MyResource.selectGender;
            birthdayDateTimePicker.Text = DateTime.Now.ToLongDateString();
            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void AddNewStudent()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("StudentAdd", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                GetSqlCommand(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show(MyResource.correctlyAdd, MyResource.addStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetSqlCommand(SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@IdGroup", groupComboBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Gender", genderComboBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(birthdayDateTimePicker.Text));
            sqlCommand.Parameters.AddWithValue("@PersonId", Guid.NewGuid().ToString());
            sqlCommand.Parameters.AddWithValue("@Username", usernameTextBox.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@PasswordHash", Hash(passwordTextBox.Text.Trim()));
        }

        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
