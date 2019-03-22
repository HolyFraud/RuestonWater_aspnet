using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruestonwater
{
    public partial class Story : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                p1.Text = GetStoryContent(1);
                p2.Text = GetStoryContent(2);
                p3.Text = GetStoryContent(3);
                p4.Text = GetStoryContent(4);
                p5.Text = GetStoryContent(5);
                DisplayBackground1();
                DisplayBackground2();
                DisplayBackground3();
            }
        }

        private string GetStoryContent(int StoryOrder)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "Select StoryContent From StoryList Where RecordState = 1 And StoryOrder = " + StoryOrder;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return reader[0].ToString();
            reader.Close();
            sqlConnection.Close();
            return "";
        }

        private void DisplayBackground1()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 12";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string filename = reader[0].ToString();
                bg1.Attributes.Add("style", "background-image:url(/Images/" + filename + ")");
                //Image1.ImageUrl = "/Images/" + filename;
            }
            reader.Close();
            sqlConnection.Close();
        }

        private void DisplayBackground2()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 13";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string filename = reader[0].ToString();
                bg2.Attributes.Add("style", "background-image:url(/Images/" + filename + ")");
            }
            reader.Close();
            sqlConnection.Close();
        }
        private void DisplayBackground3()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 14";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string filename = reader[0].ToString();
                bg3.Attributes.Add("style", "background-image:url(/Images/" + filename + ")");
            }
            reader.Close();
            sqlConnection.Close();
        }
        
    }
}