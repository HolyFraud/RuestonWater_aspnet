using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruestonwater.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            string query = "select count(*) from ManagerList where UserName = '" + tbaccount.Text + "' And Password = '" + tbpassword.Text + "' And LastLogin = GETDATE()";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int count = Convert.ToInt32(reader[0]);
                if (count == 1)
                {
                    Session["ManagerActive"] = 1;
                    lblogin.Visible = true;
                    lblogin.Text = "Login Successfully...!";
                    Response.Redirect("/Admin/Index.aspx");
                }
                else
                {
                    Session.Remove("ManagerActive");
                    lblogin.Visible = true;
                    lblogin.Text = "Login failed, Plz try again...!";
                }
            }
        }
    }
}