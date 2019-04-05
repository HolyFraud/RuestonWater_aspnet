using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruestonwater.Admin
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (1 != Convert.ToInt32(Session["ManagerActive"]))
            {
                Response.Redirect("/Admin/Login.aspx");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FAQ.aspx");
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            string questionname = tbQuestionName.Text;
            questionname = questionname.Replace("'", "''");
            string answer = tbAnswer.Text;
            answer = answer.Replace("'", "''");
            Util.ExecuteQuery("Insert Into QuestionList values('" + questionname + "', '" + answer + "', 1)");
            GridViewQuestion.DataBind();
            tbQuestionName.Text = "";
            tbAnswer.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tbAnswer.Text = tbAnswer.Text + "<br />";
        }
    }
}