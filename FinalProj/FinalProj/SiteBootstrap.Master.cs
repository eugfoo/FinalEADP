using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;

namespace FinalProj
{
    public partial class SiteBootstrap : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null) // A user has signed in
            {
                Users user = (Users)Session["user"];
                lblProfile.Text = user.name;
                lblLogOut.Visible = true;
                lblBookmark.Visible = true;
            }
            else
            {
                lblProfile.Text = "Sign In";
                lblProfile.NavigateUrl = "/LogIn.aspx";
                lblLogOut.Visible = false;
                lblBookmark.Visible = false;
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/homepage.aspx");
        }
    }
}