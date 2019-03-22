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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshDropDownList();
            }
        }


        protected void HomeSliderUploadBtn_Click(object sender, EventArgs e)
        {

            if (HomeSliderImageUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(HomeSliderImageUpload.FileName);
                    string query = "Insert Into FileList(FileName) Values('" + filename + "') Select SCOPE_IDENTITY()";
                    string query2 = "Select count(*) From FileList Where FileName = '" + filename + "'";
                    string query3 = "Select count(*) From FileList Where FileName = '" + filename + "' And RecordState = 1";
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(query2, sqlConnection);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand(query3, sqlConnection);
                        int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        if (count1 > 0)
                        {
                            LabelUploadState.Visible = true;
                            LabelUploadState.Text = "This Image Has Been Exist..!";
                        }
                        else
                        {
                            Util.ExecuteQuery("Update FileList Set RecordState = 1 Where FileName = '" + filename + "'");
                            HomeSliderImageUpload.SaveAs(Server.MapPath("~/Images/home_slider/") + filename);
                            LabelUploadState.Visible = true;
                            LabelUploadState.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        HomeSliderImageUpload.SaveAs(Server.MapPath("~/Images/home_slider/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        string query1 = "Select SectionListID From SectionList Where SectionName = 'Home_Slider'";
                        SqlCommand cmd3 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        reader3.Read();
                        string SectionListID = reader3[0].ToString();
                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + SectionListID + "')");
                        Util.ExecuteQuery("Insert into FileCaptionList (FileListID) Values('" + FileListID + "')");
                        Util.ExecuteQuery("Insert into File_SliderOrderList (FileListID) Values('" + FileListID + "')");
                        reader3.Close();
                        sqlConnection.Close();
                        /*---------------------------------End Store file name into database-----------------------------------*/
                        LabelUploadState.Visible = true;
                        LabelUploadState.Text = "Upload status: File uploaded!";

                    }
                    RefreshDropDownList();
                }
                catch (Exception ex)
                {
                    LabelUploadState.Visible = true;
                    LabelUploadState.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                LabelUploadState.Visible = true;
                LabelUploadState.Text = "Failed";
            }
        }

        protected void ddlHomeSliderImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FileName = ddlHomeSliderImg.SelectedItem.Text;
            PreviewImg.ImageUrl = "~/Images/home_slider/" + FileName;

        }


        protected void HomeSliderDelete_Click(object sender, EventArgs e)
        {
            string FileName = ddlHomeSliderImg.SelectedItem.Text;
            string path = Server.MapPath("~/Images/home_slider/" + FileName);
            string query = "Update FileList Set RecordState = 0 Where FileListID = " + ddlHomeSliderImg.SelectedValue;
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {

                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                file.Delete();
                sqlConnection.Close();
            }
            RefreshDropDownList();
        }

        private void CountSliders()
        {
            ddlFileOrder.Items.Clear();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT count(*) FROM File_SliderOrderList INNER JOIN FileList ON File_SliderOrderList.FileListID = FileList.FileListID WHERE FileList.RecordState = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            sqlConnection.Close();
            int value = 1;
            while (value < count)
            {
                ddlFileOrder.Items.Add(value.ToString());
                value++;
            }

        }

        private void RefreshDropDownList()
        {
            ddlHomeSliderImg.DataBind();
            ddlFileOrder.DataBind();
            CountSliders();
        }

        private void CancelOrderNumber()
        {
            ddlFileOrder.Items.Clear();
        }


        protected void PreviewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/index.aspx");
        }

        protected void HomeSliderConfirmBtn_Click(object sender, EventArgs e)
        {
            if (ddlFileOrder.SelectedIndex == -1 || ddlHomeSliderImg.SelectedIndex == -1)
            {
                lbConfirmMsg.Text = "Failed, Please Choose One First";
                lbConfirmMsg.Visible = true;
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
                sqlConnection.Open();
                int sliderorder = Convert.ToInt32(ddlFileOrder.SelectedItem.Value) - 1;
                string txt = tbCaption.Text;
                string FileListID = ddlHomeSliderImg.SelectedValue;
                string query = "Update FileCaptionList Set Caption = '" + txt + "' Where FileListID = " + FileListID;
                string query1 = "update file_sliderorderlist set sliderorder = " + sliderorder + "where FileListID = " + FileListID;
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();
                lbConfirmMsg.Visible = true;
            }

        }

        private void AutoDeleteExistImage()
        {
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE FileList.RecordState = 1 AND File_SectionList.SectionListID = " + ddlHomeSectionNumber.SelectedValue;
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
            string path = Server.MapPath("~/Images/home_section/" + filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        protected void HomeSectionUploadBtn_Click(object sender, EventArgs e)
        {
            AutoDeleteExistImage();
            if (HomeSectionImg.HasFile)
            {

                try
                {
                    string filename = Path.GetFileName(HomeSectionImg.FileName);

                    string query = "update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = " + ddlHomeSectionNumber.SelectedValue;
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
                            HomeSliderImageUpload.SaveAs(Server.MapPath("~/Images/home_section/") + filename);
                            LabelUploadState1.Visible = true;
                            LabelUploadState1.Text = "Upload status: File uploaded!";
                        }

                    }
                    else
                    {
                        HomeSectionImg.SaveAs(Server.MapPath("~/Images/home_section/") + filename);
                        /*---------------------------------Start Store file name into database-----------------------------------*/

                        SqlCommand cmd2 = new SqlCommand(query1, sqlConnection);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        int FileListID = Convert.ToInt32(reader2[0]);
                        reader2.Close();

                        Util.ExecuteQuery("Insert into File_SectionList Values('" + FileListID + "','" + ddlHomeSectionNumber.SelectedValue + "')");

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
                LabelUploadState1.Text = "Failed";
            }
        }

        private string Content(TextBox tbControl)
        {
            /*----------------------confirm all single quote in content are going to be double quote-------------*/
            string content = tbControl.Text;
            content = content.Replace("'", "''");
            return content;
        }

        protected void HomeSectionConfirmBtn_Click(object sender, EventArgs e)
        {
            string Title_Lv1 = Content(tbTitleLv1);
            string Title_Lv2 = Content(tbTitleLv2);
            string Title_Lv3 = Content(tbTitleLv3);
            string content = Content(tbContent);
            string HomeSectionNumber = ddlHomeSectionNumber.SelectedValue;

            if (null != Title_Lv1 && !string.IsNullOrEmpty(Title_Lv1))
            {
                string DeleteQuery = "Delete From ContentList Where ContentItemListID = 1 And SectionListID = " + HomeSectionNumber;
                string InsertQuery = "Insert Into ContentList Values(1, " + HomeSectionNumber + ", '" + Title_Lv1 + "')";
                Util.ExecuteQuery(DeleteQuery);
                Util.ExecuteQuery(InsertQuery);
            }
            if (null != Title_Lv2 && !string.IsNullOrEmpty(Title_Lv2))
            {
                string DeleteQuery = "Delete From ContentList Where ContentItemListID = 2 And SectionListID = " + HomeSectionNumber;
                string InsertQuery = "Insert Into ContentList Values(2, " + HomeSectionNumber + ", '" + Title_Lv2 + "')";
                Util.ExecuteQuery(DeleteQuery);
                Util.ExecuteQuery(InsertQuery);
            }
            if (null != Title_Lv3 && !string.IsNullOrEmpty(Title_Lv3))
            {
                string DeleteQuery = "Delete From ContentList Where ContentItemListID = 2 And SectionListID = " + HomeSectionNumber;
                string InsertQuery = "Insert Into ContentList Values(3, " + HomeSectionNumber + ", '" + Title_Lv3 + "')";
                Util.ExecuteQuery(DeleteQuery);
                Util.ExecuteQuery(InsertQuery);
            }
            if (null != content && !string.IsNullOrEmpty(content))
            {
                string DeleteQuery = "Delete From ContentList Where ContentItemListID = 4 And SectionListID = " + HomeSectionNumber;
                string InsertQuery = "Insert Into ContentList Values(4, " + HomeSectionNumber + ", '" + content + "')";
                Util.ExecuteQuery(DeleteQuery);
                Util.ExecuteQuery(InsertQuery);
            }
        }
    }
}