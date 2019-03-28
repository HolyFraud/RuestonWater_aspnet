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
    public partial class AustralianMade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayAllContent();
        }

        private void DisplayAllContent()
        {
            DisplayImage(1);
            DisplayImage(2);
            DisplayImage(3);
            DisplayImage(4);

            DisplayParticularText(1, 23, p1title);
            DisplayParticularText(2, 23, p1title1);
            DisplayParticularText(4, 23, p1text);
            DisplayParticularText(1, 24, p2title);
            DisplayParticularText(2, 24, p2title1);
            DisplayParticularText(4, 24, p2text);
            DisplayParticularText(1, 25, p3title);
            DisplayParticularText(2, 25, p3title1);
            DisplayParticularText(4, 25, p3text);
            DisplayParticularText(1, 26, p4title);
            DisplayParticularText(2, 26, p4title1);
            DisplayParticularText(4, 26, p4text);

            DisplayParticularText(1, 23, p1mobiletitle);
            DisplayParticularText(2, 23, p1mobiletitle1);
            DisplayParticularText(4, 23, p1mobiletext);
            DisplayParticularText(1, 24, p2mobiletitle);
            DisplayParticularText(2, 24, p2mobiletitle1);
            DisplayParticularText(4, 24, p2mobiletext);
            DisplayParticularText(1, 25, p3mobiletitle);
            DisplayParticularText(2, 25, p3mobiletitle1);
            DisplayParticularText(4, 25, p3mobiletext);
            DisplayParticularText(1, 26, p4mobiletitle);
            DisplayParticularText(2, 26, p4mobiletitle1);
            DisplayParticularText(4, 26, p4mobiletext);
        }

        private void DisplayParticularText(int ContentItemListID, int SectionListID, Label label)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();

            string query = "Select ContentDesc From ContentList Where ContentItemListID = " + ContentItemListID + " And SectionListID = " + SectionListID;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label.Text = reader[0].ToString();
            }
            reader.Close();
            sqlConnection.Close();

        }

        private void DisplayImage(int order)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (order == 1)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 23 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p1.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                    mobile_p1contaner.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                }
                reader.Close();
                sqlConnection.Close();
            }
            if (order == 2)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 24 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p2.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                    mobile_p2contaner.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                }
                reader.Close();
                sqlConnection.Close();
            }
            if (order == 3)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 25 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p3.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                    mobile_p3contaner.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                }
                reader.Close();
                sqlConnection.Close();
            }
            if (order == 4)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 26 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p4.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                    mobile_p4contaner.Attributes.Add("style", "background-image:url(/Images/AustralianMade/" + FileName + ")");
                }
                reader.Close();
                sqlConnection.Close();
            }
        }
    }
}