using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruestonwater
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BindHomeSection_1_Img();
            DisplayHomeSection1Elements();
            BindHomeSection_2_Img();
            DisplayHomeSection2Element();
            BindHomeSection_3_Img();
            DisplayHomeSection3Element();
            BindHomeSection_4_Img();
            DisplayHomeSection4Element();
        }


        protected string GetActiveClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        /*---------------------------Display Title And Content------------------------------------------------*/
        private void DisplayTitle(int SectionNumber, Label label)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT ContentList.ContentDesc FROM ContentList INNER JOIN ContentItemList ON ContentList.ContentItemListID = ContentItemList.ContentItemListID INNER JOIN SectionList ON ContentList.SectionListID = SectionList.SectionListID WHERE ContentItemList.ContentItemListID = 1 AND ContentList.SectionListID = " + SectionNumber;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label.Text = reader[0].ToString();
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void DisplaySubTitle(int SectionNumber, Label label)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT ContentList.ContentDesc FROM ContentList INNER JOIN ContentItemList ON ContentList.ContentItemListID = ContentItemList.ContentItemListID INNER JOIN SectionList ON ContentList.SectionListID = SectionList.SectionListID WHERE ContentItemList.ContentItemListID = 2 AND ContentList.SectionListID = " + SectionNumber;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label.Text = reader[0].ToString();
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void DisplayContent(int SectionNumber, Label label)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT ContentList.ContentDesc FROM ContentList INNER JOIN ContentItemList ON ContentList.ContentItemListID = ContentItemList.ContentItemListID INNER JOIN SectionList ON ContentList.SectionListID = SectionList.SectionListID WHERE ContentItemList.ContentItemListID = 4 AND ContentList.SectionListID = " + SectionNumber;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label.Text = reader[0].ToString();
            }
            reader.Close();
            sqlConnection.Close();
        }


        /*----------------------------------------------------Home section 1----------------------------------------------------*/
        private void BindHomeSection_1_Img()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 2 AND FileList.RecordState = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string FileName = reader[0].ToString();
                HomeSection_1_img.ImageUrl = "/Images/" + FileName;

            }
            sqlConnection.Close();
        }



        private void DisplayHomeSection1Elements()
        {
            DisplayTitle(2, lbSection_1_Title);
            DisplaySubTitle(2, lbSection_1_Subtitle);
            DisplayContent(2, lbSection_1_Content);
        }

        /*----------------------------------------------------Home section 2----------------------------------------------------*/

        private void BindHomeSection_2_Img()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 3 AND FileList.RecordState = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string FileName = reader[0].ToString();
                Section_2_BG.Attributes.Add("style", "background-image:url(/Images/" + FileName + ")");

            }
            reader.Close();
            sqlConnection.Close();
        }

        private void DisplayHomeSection2Element()
        {
            DisplayTitle(3, lbSection_2_Title);
            DisplaySubTitle(3, lbSection_2_Subtitle);
            DisplayContent(3, lbSection_2_Content);
        }

        /*-----------------------------------------------------Home Section 3----------------------------------------------------------*/
        private void BindHomeSection_3_Img()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 4 AND FileList.RecordState = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string FileName = reader[0].ToString();
                HomeSection_3_Img.ImageUrl = "/Images/" + FileName;
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void DisplayHomeSection3Element()
        {
            DisplayTitle(4, lbSection_3_Title);
            DisplaySubTitle(4, lbSection_3_Subtitle);
            DisplayContent(4, lbSection_3_Content);
        }



        /*------------------------------------------------------------Home Section 4----------------------------------------------------------*/
        private void BindHomeSection_4_Img()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 5 AND FileList.RecordState = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string FileName = reader[0].ToString();
                Section_4_BG.Attributes.Add("style", "background-image:url(/Images/" + FileName + ")");
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void DisplayHomeSection4Element()
        {
            DisplayTitle(5, lbSection_4_Title);
            DisplayContent(5, lbSection_4_Content);
        }
    }
}