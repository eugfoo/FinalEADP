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
        protected List<Notifications> notiList;
        public List<string> eventName = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            Notifications noti = new Notifications();

            if (Convert.ToBoolean(Session["admin"])) // An admin has signed in
            {
                liAdmin.Visible = true;
            }
            else
            {
                if (Session["user"] != null) // A user has signed in
                {
                    Users user = (Users)Session["user"];
                    if (user.isOrg.Trim() == "True")
                    {
                        norgItems.Visible = false;
                    }
                    lblProfile.Text = user.name;
                    liLogOut.Visible = true;
                    lblBookmark.Visible = true;

                    notiList = noti.GetEventsEnded();

                    if (notiList.Count != 0)
                    {
                        foreach (var element in notiList)
                        {
                            if (element.User_id == user.id)
                            {
                                eventName.Add(element.EventName);
                            }
                        }
                    }
                }
                else
                {
                    ddCaret.Visible = false;
                    ddMenu.Visible = false;
                    lblProfile.Text = "Sign In";
                    lblProfile.NavigateUrl = "/LogIn.aspx";
                    liLogOut.Visible = false;
                    lblBookmark.Visible = false;
                }
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
    }
}