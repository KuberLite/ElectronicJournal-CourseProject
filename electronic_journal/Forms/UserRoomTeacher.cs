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
    public partial class UserRoomTeacher : Form, IConnection
    {
        string connectionString;

        string imgLoc = "";

        int count = 0;

        public UserRoomTeacher()
        {
            InitializeComponent();
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            TextBoxEnabled();
            LoadAllInfo();
        }

        private void LoadAllInfo()
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("LoadUserInfoForUserFormTeacher", ConnectionSQL());
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
                if (dataTable.Rows[0][4] != DBNull.Value)
                {
                    byte[] img = (byte[])(dataTable.Rows[0][4]);
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
                textBox1.Text = dataTable.Rows[0][0].ToString();
                textBox2.Text = dataTable.Rows[0][2].ToString();
                textBox3.Text = dataTable.Rows[0][1].ToString();
                textBox4.Text = dataTable.Rows[0][3].ToString();
            }
        }

        private void TextBoxEnabled()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        public SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, ConnectionSQL());
            return sqlDataAdapter;
        }

        public SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
            return sqlData;
        }

        public SqlConnection ConnectionSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        private void LoadImageButtton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = MyResource.typeImage;
                openFile.Title = MyResource.selectImage;
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = openFile.FileName.ToString();
                    picture.ImageLocation = imgLoc;
                }
                count++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserRoomTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (count != 0)
            {
                DialogResult dialogResult = MessageBox.Show(MyResource.saveСhanges, MyResource.personalArea, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (dialogResult == DialogResult.No) { }
            }
            else
            { this.Hide(); }
        }
    }
}
