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
    public partial class BotanicalPower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayAllContent();
        }

        private void DisplayImage(int order)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (order == 1)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 15 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p1.Attributes.Add("style", "background-image:url(/Images/BotanicalPower/" + FileName + ")");
                }
                reader.Close();
                sqlConnection.Close();
            }
            if (order == 2)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 16 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p2.Attributes.Add("style", "background-image:url(/Images/BotanicalPower/" + FileName + ")");
                }
                reader.Close();
                sqlConnection.Close();
            }
            if (order == 3)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 17 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p3.Attributes.Add("style", "background-image:url(/Images/BotanicalPower/" + FileName + ")");

                }
                reader.Close();
                sqlConnection.Close();
            }
            if (order == 4)
            {
                string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 18 AND FileList.RecordState = 1";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string FileName = reader[0].ToString();
                    p4.Attributes.Add("style", "background-image:url(/Images/BotanicalPower/" + FileName + ")");

                }
                reader.Close();
                sqlConnection.Close();
            }
        }

        private void DisplaySection1Image()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 27 AND FileList.RecordState = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string FileName = reader[0].ToString();
                p1_bottle.ImageUrl = "/Images/BotanicalPower/" + FileName;
            }
            reader.Close();
            sqlConnection.Close();
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

        private void DisplayAllContent()
        {
            DisplayImage(1);
            DisplayImage(2);
            DisplayImage(3);
            DisplayImage(4);
            DisplaySection1Image();
            DisplayParticularText(1, 15, p1title);
            DisplayParticularText(4, 15, p1text);
            DisplayParticularText(1, 16, p2title);
            DisplayParticularText(4, 16, p2text);
            DisplayParticularText(1, 17, p3title);
            DisplayParticularText(4, 17, p3text);
            DisplayParticularText(1, 18, p4title);
            DisplayParticularText(4, 18, p4text);
        }
    }
}