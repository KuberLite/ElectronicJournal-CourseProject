using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace electronic_journal
{
    public partial class UserRoomTeacher : Form, IConnection
    {
        string connectionString;

        string imgLoc = "";

        int count = 0;

        public UserRoomTeacher()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            TextBoxEnabled();
            LoadAllInfo();
        }

        private void LoadAllInfo()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter("select [Name], Gender, Pulpit, Birthday, Photo from Person where IdPerson = '" + LoginForm.idPerson + "'", ConnectionSQL()).Fill(dataTable);
            TextBoxLoadInfo(dataTable);
            LoadImage(dataTable);
            
        }

        private void LoadImage(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 1)
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
                        string UpdateQuery = "update Person set Photo = @img where IdPerson = '" + LoginForm.idPerson + "'";
                        SqlConnection sql = new SqlConnection(connectionString);
                        sql.Open();
                        SqlCommand sqlCommand = new SqlCommand(UpdateQuery, sql);
                        sqlCommand.Parameters.Add(new SqlParameter("@img", img));
                        sqlCommand.ExecuteNonQuery();
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
            { this.Close(); }
        }

    }
}
