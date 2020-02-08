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
        public string viewingUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            viewingUserId = Request.QueryString["userId"];

            if (viewingUserId != null) // A user is viewing another's PP
            {
                if (Session["user"] == null) // User is not signed in
                {
                    ddCaret.Visible = false;
                    ddMenu.Visible = false;
                    lblProfile.Text = "Sign In";
                    lblProfile.NavigateUrl = "/LogIn.aspx";
                    liLogOut.Visible = false;
                    lblBookmark.Visible = false;
                }
                else
                {
                    Users user1 = (Users)Session["user"];
                    user1.UpdateRatingByID(user1.id);
                    if (user1.isOrg.Trim() == "True")
                    {
                        norgItems.Visible = false;
                    }
                    lblProfile.Text = user1.name;
                    liLogOut.Visible = true;
                    lblBookmark.Visible = true;
                }
                linkPPPoints.Visible = false;
                Users user = new Users();
                user.UpdateRatingByID(Convert.ToInt32(viewingUserId));
                var viewingUser = user.GetUserById(Convert.ToInt32(viewingUserId));
                initializePPFields(viewingUser);
            }
            else if (Session["user"] != null) // A user is viewing their own PP
            {
                Users user = (Users)Session["user"];
                if (user.isOrg.Trim() == "True")
                {
                    norgItems.Visible = false;
                }
                initializePPFields(user);
                linkPPPoints.Visible = true;
                lblProfile.Text = user.name;
                liLogOut.Visible = true;
                lblBookmark.Visible = true;
            }
            else
            {
                ddCaret.Visible = false;
                ddMenu.Visible = false;
                lblProfile.Text = "Sign In";
                lblProfile.NavigateUrl = "/LogIn.aspx";
                liLogOut.Visible = false;
                lblBookmark.Visible = false;
                Response.Redirect("homepage.aspx");
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/homepage.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Users user = (Users)Session["user"];
            user.VerifyOrgById(user.id);
        }

        public void initializePPFields(Users userI)
        {
            if (userI == null)
            {
                Response.Redirect("homepage.aspx");
            }
            else
            {
                userI.UpdateRatingByID(userI.id);
                Users user = userI.GetUserById(userI.id);
                Session["user"] = user;

                EventsStatus events = new EventsStatus();
                var eventList = events.GetAllEventsByName();
                int eventCount = 0;

                for (int i = 0; i < eventList.Count; i++)
                {
                    if (eventList[i].Organiser == user.id.ToString())
                    {
                        eventCount++;
                    }
                }

                if (user.verified == 1)
                {
                    bluetick.Visible = true;
                }

                if (eventCount == 0)
                {
                    lblEventCount.Visible = false;
                }
                else
                {
                    lblEventCount.Text = "(" + eventCount.ToString() + ")";
                }

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
        }
    }
}