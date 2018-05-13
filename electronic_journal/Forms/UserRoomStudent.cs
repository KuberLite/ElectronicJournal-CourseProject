using electronic_journal.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace electronic_journal.Forms
{
    public partial class UserRoomStudent : Form, IConnection
    {
        private readonly string connectionString;
        string imgLoc = "";
        int count = 0;

        public UserRoomStudent()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void UserRoomStudent_Load(object sender, System.EventArgs e)
        {
            UserRoomTextBoxEnabled();
            LoadAllInfo();
        }

        private void LoadAllInfo()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("LoadUserInfoForUserFormStudent", ConnectionSQL());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idPerson", LoginForm.idPerson);
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
                        picture.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        picture.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void TextBoxLoadInfo(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 1)
            {
                fullNameTextBox.Text = dataTable.Rows[0][0].ToString();
                genderTextBox.Text = dataTable.Rows[0][1].ToString();
                groupTextBox.Text = dataTable.Rows[0][2].ToString();
                professionTextBox.Text = dataTable.Rows[0][3].ToString();
                courseTextBox.Text = dataTable.Rows[0][4].ToString();
                birthdayTextBox.Text = dataTable.Rows[0][5].ToString();
            }
        }

        private void UserRoomTextBoxEnabled()
        {
            fullNameTextBox.Enabled = false;
            groupTextBox.Enabled = false;
            courseTextBox.Enabled = false;
            genderTextBox.Enabled = false;
            professionTextBox.Enabled = false;
            birthdayTextBox.Enabled = false;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
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

        private void UserRoomStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (count != 0)
            {
                DialogResult dialogResult = MessageBox.Show(MyResource.saveСhanges, MyResource.personalArea, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    byte[] img = null;
                    FileStream fileStream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    img = binaryReader.ReadBytes((int)fileStream.Length);
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("LoadImage", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@idPerson", LoginForm.idPerson);
                    sqlCommand.Parameters.AddWithValue("@img", img);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteReader();
                    MessageBox.Show(MyResource.updateInformation, MyResource.personalArea, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dialogResult == DialogResult.No) { }
            }
            else
            { this.Hide(); }
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = MyResource.typeImage;
            openFile.Title = MyResource.selectImage;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgLoc = openFile.FileName.ToString();
                picture.ImageLocation = imgLoc;
            }
            count++;
        }
    }
}
