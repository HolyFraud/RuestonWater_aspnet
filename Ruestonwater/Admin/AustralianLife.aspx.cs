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
    public partial class AustralianLife : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayImage();
                DisplayText();
            }
        }

        private void DisplayImage()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query1 = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 19";
            string query2 = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 20";
            string query3 = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 21";
            string query4 = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 22";

            SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                string filename = reader1[0].ToString();
                p1bg.ImageUrl = "/Images/AustralianLife/" + filename;

            }
            reader1.Close();

            SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                string filename = reader2[0].ToString();
                p2bg.ImageUrl = "/Images/AustralianLife/" + filename;
            }
            reader2.Close();

            SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            if (reader3.Read())
            {
                string filename = reader3[0].ToString();
                p3bg.ImageUrl = "/Images/AustralianLife/" + filename;
            }
            reader3.Close();

            SqlCommand cmd4 = new SqlCommand(query4, sqlConnection);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            if (reader4.Read())
            {
                string filename = reader4[0].ToString();
                p4bg.ImageUrl = "/Images/AustralianLife/" + filename;
            }
            reader4.Close();
            sqlConnection.Close();
        }

        private void DisplayParticularText(int ContentItemListID, int SectionListID, TextBox txt)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();

            string query = "Select ContentDesc From ContentList Where ContentItemListID = " + ContentItemListID + " And SectionListID = " + SectionListID;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt.Text = reader[0].ToString();
            }
            reader.Close();
            sqlConnection.Close();

        }

        private void DisplayText()
        {
            DisplayParticularText(1, 19, tbp1title);
            DisplayParticularText(4, 19, tbp1content);
            DisplayParticularText(1, 20, tbp2title);
            DisplayParticularText(4, 20, tbp2content);
            DisplayParticularText(1, 21, tbp3title);
            DisplayParticularText(4, 21, tbp3content);
            DisplayParticularText(1, 22, tbp4title);
            DisplayParticularText(4, 22, tbp4content);
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
            string path = Server.MapPath("~/Images/AustralianLife/" + filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }


        private string FormatString(string txt)
        {
            return txt.Replace("'", "''");
        }

        protected void preview_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AustralianLife.aspx");
        }

        /*---------------------------------------------------p1------------------------------------------------------------------------*/

        protected void p1bguploadbtn_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(19);
            if (p1bgupload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(p1bgupload.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 19;
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
                            p1uploadstate.Visible = true;
                            p1uploadstate.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            p1bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                            p1uploadstate.Visible = true;
                            p1uploadstate.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        p1bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 19 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        p1uploadstate.Visible = true;
                        p1uploadstate.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    p1uploadstate.Visible = true;
                    p1uploadstate.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                p1uploadstate.Visible = true;
                p1uploadstate.Text = "Have to Choose a file";
            }
        }

        protected void return_Click(object sender, EventArgs e)
        {
            tbp1content.Text = tbp1content.Text + "<br />";
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            string query = "update ContentList Set ContentDesc = '" + FormatString(tbp1title.Text) + "' Where ContentItemListID = 1 and SectionListID = 19";
            string query1 = "update ContentList Set ContentDesc = '" + FormatString(tbp1content.Text) + "' Where ContentItemListID = 4 and SectionListID = 19";
            Util.ExecuteQuery(query);
            Util.ExecuteQuery(query1);
        }


        /*---------------------------------------------------p2------------------------------------------------------------------------*/



        protected void p2bguploadbtn_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(20);
            if (p2bgupload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(p2bgupload.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 20;
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
                            p2bguploadstate.Visible = true;
                            p2bguploadstate.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            p2bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                            p2bguploadstate.Visible = true;
                            p2bguploadstate.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        p2bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 20 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        p2bguploadstate.Visible = true;
                        p2bguploadstate.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    p2bguploadstate.Visible = true;
                    p2bguploadstate.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                p2bguploadstate.Visible = true;
                p2bguploadstate.Text = "Have to Choose a file";
            }
        }

        protected void p2returnlinebtn_Click(object sender, EventArgs e)
        {
            tbp2content.Text = tbp2content.Text + "<br />";
        }

        protected void p2confirmbtn_Click(object sender, EventArgs e)
        {
            string query = "update ContentList Set ContentDesc = '" + FormatString(tbp2title.Text) + "' Where ContentItemListID = 1 and SectionListID = 20";
            string query1 = "update ContentList Set ContentDesc = '" + FormatString(tbp2content.Text) + "' Where ContentItemListID = 4 and SectionListID = 20";
            Util.ExecuteQuery(query);
            Util.ExecuteQuery(query1);
        }



        /*---------------------------------------------------p3------------------------------------------------------------------------*/



        protected void p3bguploadbtn_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(21);
            if (p3bgupload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(p3bgupload.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 21;
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
                            p3bguploadstate.Visible = true;
                            p3bguploadstate.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            p3bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                            p3bguploadstate.Visible = true;
                            p3bguploadstate.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        p3bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 21 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        p3bguploadstate.Visible = true;
                        p3bguploadstate.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    p3bguploadstate.Visible = true;
                    p3bguploadstate.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                p3bguploadstate.Visible = true;
                p3bguploadstate.Text = "Have to Choose a file";
            }
        }

        protected void p3returnlinebtn_Click(object sender, EventArgs e)
        {
            tbp3content.Text = tbp3content.Text + "<br />";
        }

        protected void p3confirmbtn_Click(object sender, EventArgs e)
        {
            string query = "update ContentList Set ContentDesc = '" + FormatString(tbp3title.Text) + "' Where ContentItemListID = 1 and SectionListID = 21";
            string query1 = "update ContentList Set ContentDesc = '" + FormatString(tbp3content.Text) + "' Where ContentItemListID = 4 and SectionListID = 21";
            Util.ExecuteQuery(query);
            Util.ExecuteQuery(query1);
        }

        /*---------------------------------------------------p3------------------------------------------------------------------------*/

        protected void p4bguploadbtn_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage(22);
            if (p4bgupload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(p4bgupload.FileName);
                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + 22;
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
                            p4bguploadstate.Visible = true;
                            p4bguploadstate.Text = "This Image Name Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            p4bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                            p4bguploadstate.Visible = true;
                            p4bguploadstate.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        p4bgupload.SaveAs(Server.MapPath("~/Images/AustralianLife/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + 22 + "')");

                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/

                        p4bguploadstate.Visible = true;
                        p4bguploadstate.Text = "Upload status: File uploaded!";
                    }

                }
                catch (Exception ex)
                {
                    p4bguploadstate.Visible = true;
                    p4bguploadstate.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                p4bguploadstate.Visible = true;
                p4bguploadstate.Text = "Have to Choose a file";
            }
        }

        protected void p4returnlinebtn_Click(object sender, EventArgs e)
        {
            tbp4content.Text = tbp4content.Text + "<br />";
        }

        protected void p4confirmbtn_Click(object sender, EventArgs e)
        {
            string query = "update ContentList Set ContentDesc = '" + FormatString(tbp4title.Text) + "' Where ContentItemListID = 1 and SectionListID = 22";
            string query1 = "update ContentList Set ContentDesc = '" + FormatString(tbp4content.Text) + "' Where ContentItemListID = 4 and SectionListID = 22";
            Util.ExecuteQuery(query);
            Util.ExecuteQuery(query1);
        }
    }
}