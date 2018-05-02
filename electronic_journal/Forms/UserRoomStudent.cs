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
        string connectionString;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
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
            dataTable = new DataTable();
            string query = "select [Name], Gender, NumberGroup, ProfessionName, Course, Birthday, Photo " +
                           "from Person inner join Groups on Person.IdGroup = Groups.IdGroup " +
                           "inner join Profession on Groups.Profession = Profession.IdProfession " +
                           "where Person.IdPerson = '" + LoginForm.idPerson + "'";
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
            sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
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
                    string UpdateQuery = "update Person set Photo = @img where IdPerson = '" + LoginForm.idPerson + "'";
                    SqlConnection sql = new SqlConnection(connectionString);
                    sql.Open();
                    SqlCommand sqlCommand = new SqlCommand(UpdateQuery, sql);
                    sqlCommand.Parameters.Add(new SqlParameter("@img", img));
                    sqlCommand.ExecuteNonQuery();
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
