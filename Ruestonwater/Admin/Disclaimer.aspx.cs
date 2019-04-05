using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruestonwater.Admin
{
    public partial class Disclaimer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["ManagerActive"]) != 1)
            {
                Response.Redirect("/Admin/Login.aspx");

            }
        }

        protected void PreviewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Disclaimer.aspx");
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            string Paragraph = tbParagraph.Text;
            Paragraph = Paragraph.Replace("'", "''");
            Util.ExecuteQuery("Insert Into DisclaimerList(DisclaimerContent) Values('" + Paragraph + "')");
            GridViewDisclaimerContent.DataBind();
        }
    }
}