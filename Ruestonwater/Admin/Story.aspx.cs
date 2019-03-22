using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruestonwater.Admin
{
    public partial class Story : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayImage();
            if (!IsPostBack)
            {
                Display();

            }
        }

        protected void PreviewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Story.aspx");
        }

        private string DisplayPara(int paraorder)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "Select StoryContent From StoryList Where RecordState = 1 And StoryOrder = " + paraorder;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return reader[0].ToString();
            reader.Close();
            sqlConnection.Close();
            return null;
        }

        private void DisplayImage()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 12";
            string query1 = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 13";
            string query2 = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 14";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string filename = reader[0].ToString();
                Image1.ImageUrl = "/Images/" + filename;

            }
            reader.Close();
            SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                string filename = reader1[0].ToString();
                Image2.ImageUrl = "/Images/" + filename;

            }
            reader1.Close();
            SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                string filename = reader2[0].ToString();
                Image3.ImageUrl = "/Images/" + filename;

            }
            reader2.Close();
            sqlConnection.Close();
        }

        private void Display()
        {
            tbp1.Text = DisplayPara(1);
            tbp2.Text = DisplayPara(2);
            tbp3.Text = DisplayPara(3);
            tbp4.Text = DisplayPara(4);
            tbp5.Text = DisplayPara(5);
        }

        protected void p1btn_Click(object sender, EventArgs e)
        {
            string p1txt = tbp1.Text;
            p1txt = p1txt.Replace("'", "''");
            Util.ExecuteQuery("Update StoryList Set StoryContent = '" + p1txt + "' Where StoryOrder = 1");
        }

        protected void p2btn_Click(object sender, EventArgs e)
        {
            string p2txt = tbp2.Text;
            p2txt = p2txt.Replace("'", "''");
            Util.ExecuteQuery("Update StoryList Set StoryContent = '" + p2txt + "' Where StoryOrder = 2");
        }

        protected void p3btn_Click(object sender, EventArgs e)
        {
            string p3txt = tbp3.Text;
            p3txt = p3txt.Replace("'", "''");
            Util.ExecuteQuery("Update StoryList Set StoryContent = '" + p3txt + "' Where StoryOrder = 3");
        }

        protected void p4btn_Click(object sender, EventArgs e)
        {
            string p4txt = tbp4.Text;
            p4txt = p4txt.Replace("'", "''");
            Util.ExecuteQuery("Update StoryList Set StoryContent = '" + p4txt + "' Where StoryOrder = 4");
        }

        protected void p5btn_Click(object sender, EventArgs e)
        {
            string p5txt = tbp5.Text;
            p5txt = p5txt.Replace("'", "''");
            Util.ExecuteQuery("Update StoryList Set StoryContent = '" + p5txt + "' Where StoryOrder = 5");
        }

        private void AutoDeleteExistImage(int section)
        {
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE FileList.RecordState = 1 AND File_SectionList.SectionListID = " + section;
            string filename = "";
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                filename = reader[0].ToString();
            }
            reader.Close();
            sqlConnection.Close();
            string path = Server.MapPath("~/Images/" + filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(12);
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 12;
                    string query1 = "Insert Into FileList(filename) Values('" + filename + "') Select SCOPE_IDENTITY()";
                    string query2 = "Select count(*) From FileList Where FileName = '" + filename + "'";
                    string query3 = "Select count(*) From FileList Where FileName = '" + filename + "' And RecordState = 1";
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmdClear = new SqlCommand(query, sqlConnection);
                    cmdClear.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand(query2, sqlConnection);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(query3, sqlConnection);
                        int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        if (count1 > 0)
                        {
                            LabelUploadState1.Visible = true;
                            LabelUploadState1.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            FileUpload1.SaveAs(Server.MapPath("~/Images/") + filename);
                            LabelUploadState1.Visible = true;
                            LabelUploadState1.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Images/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 12 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        LabelUploadState1.Visible = true;
                        LabelUploadState1.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    LabelUploadState1.Visible = true;
                    LabelUploadState1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                LabelUploadState1.Visible = true;
                LabelUploadState1.Text = "Have to Choose a file";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(13);
            if (FileUpload2.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload2.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 13;
                    string query1 = "Insert Into FileList(filename) Values('" + filename + "') Select SCOPE_IDENTITY()";
                    string query2 = "Select count(*) From FileList Where FileName = '" + filename + "'";
                    string query3 = "Select count(*) From FileList Where FileName = '" + filename + "' And RecordState = 1";
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmdClear = new SqlCommand(query, sqlConnection);
                    cmdClear.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand(query2, sqlConnection);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(query3, sqlConnection);
                        int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        if (count1 > 0)
                        {
                            LabelUploadState2.Visible = true;
                            LabelUploadState2.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            FileUpload2.SaveAs(Server.MapPath("~/Images/") + filename);
                            LabelUploadState2.Visible = true;
                            LabelUploadState2.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        FileUpload2.SaveAs(Server.MapPath("~/Images/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 13 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        LabelUploadState2.Visible = true;
                        LabelUploadState2.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    LabelUploadState2.Visible = true;
                    LabelUploadState2.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                LabelUploadState2.Visible = true;
                LabelUploadState2.Text = "Have to Choose a file";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(14);
            if (FileUpload3.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload3.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 14;
                    string query1 = "Insert Into FileList(filename) Values('" + filename + "') Select SCOPE_IDENTITY()";
                    string query2 = "Select count(*) From FileList Where FileName = '" + filename + "'";
                    string query3 = "Select count(*) From FileList Where FileName = '" + filename + "' And RecordState = 1";
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmdClear = new SqlCommand(query, sqlConnection);
                    cmdClear.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand(query2, sqlConnection);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(query3, sqlConnection);
                        int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        if (count1 > 0)
                        {
                            LabelUploadState3.Visible = true;
                            LabelUploadState3.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            FileUpload3.SaveAs(Server.MapPath("~/Images/") + filename);
                            LabelUploadState3.Visible = true;
                            LabelUploadState3.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        FileUpload3.SaveAs(Server.MapPath("~/Images/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 14 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        LabelUploadState3.Visible = true;
                        LabelUploadState3.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    LabelUploadState3.Visible = true;
                    LabelUploadState3.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                LabelUploadState3.Visible = true;
                LabelUploadState3.Text = "Have to Choose a file";
            }
        }
    }
}