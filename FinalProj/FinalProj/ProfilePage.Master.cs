using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;

namespace FinalProj
{
    public partial class ProfilePage : System.Web.UI.MasterPage
    {
        public int rating;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null) // A user has signed in
            {
                Users user = (Users)Session["user"];
                lblProfile.Text = user.name;
                lbLogOut.Visible = true;
                lblBookmark.Visible = true;
                lblUserName.Text = user.name;
                if (user.facebook != "") { hlFacebook.NavigateUrl = user.facebook; }
                if (user.instagram != "") { hlInstagram.NavigateUrl = user.instagram; }
                if (user.twitter != "") { hlTwitter.NavigateUrl = user.twitter; }
                hlInstagram.NavigateUrl = user.instagram;
                hlTwitter.NavigateUrl = user.twitter;
                imgDP.ImageUrl = user.DPimage;
                imgBP.ImageUrl = user.BPimage;
                if (user.desc != "") { lblDesc.Text = user.desc; } else { lblDesc.Text = "This user has not added any description."; lblDesc.CssClass += "text-muted font-italic"; }
                rating = user.rating;
            }
            else
            {
                lblProfile.Text = "Sign In";
                lblProfile.NavigateUrl = "/LogIn.aspx";
                lbLogOut.Visible = false;
                lblBookmark.Visible = false;
                Response.Redirect("/homepage.aspx");
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/homepage.aspx");
        }
    }
}