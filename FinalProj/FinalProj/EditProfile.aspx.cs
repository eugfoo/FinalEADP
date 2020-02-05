using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using FinalProj.BLL;


namespace FinalProj
{
    public partial class EditProfile : System.Web.UI.Page
    {
        public string linkFB = "https://www.facebook.com/";
        public string linkInst = "https://www.instagram.com/";
        public string linkTwit = "https://www.twitter.com/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null) // A user has signed in
            {
                Users user = (Users)Session["user"];
                if (user.DPimage != "")
                {
                    if (Session["tempDP"] != null)
                    {
                        imgDP.ImageUrl = Session["tempDP"].ToString();
                    }
                    else
                    {
                        imgDP.ImageUrl = user.DPimage;
                    }
                }
                if (user.BPimage != "")
                {
                    if (Session["tempBP"] != null)
                    {
                        imgBP.ImageUrl = Session["tempBP"].ToString();
                    }
                    else
                    {
                        imgBP.ImageUrl = user.BPimage;
                    }
                }
            }
            else
            {
                Response.Redirect("/homepage.aspx");
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Users user = (Users)Session["user"];
            if (tbName.Text != "")
            {
                user.UpdateNameByID(user.id, tbName.Text);
            }
            if (tbDesc.Text != "")
            {
                user.UpdateDescByID(user.id, tbDesc.Text);
            }
            if (tbFacebook.Text != "")
            {
                user.UpdateFacebookByID(user.id, linkFB + tbFacebook.Text);
            }
            if (tbInstagram.Text != "")
            {
                user.UpdateInstagramByID(user.id, linkInst + tbInstagram.Text);
            }
            if (tbTwitter.Text != "")
            {
                user.UpdateTwitterByID(user.id, linkTwit + tbTwitter.Text);
            }
            if (Session["tempDP"] != null)
            {
                user.UpdateDPByID(user.id, Session["tempDP"].ToString());
            }
            if (Session["tempBP"] != null)
            {
                user.UpdateBPByID(user.id, Session["tempBP"].ToString());
            }
            Session["tempDP"] = null;
            Session["tempBP"] = null;
            Session["user"] = user.GetUserByEmail(user.email);
            Response.Redirect("/EventStatus.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["tempDP"] = null;
            Session["tempBP"] = null;
            Response.Redirect("/EventStatus.aspx");
        }

        protected void btnUploadDP_Click(object sender, EventArgs e)
        {
            if (fuDP.HasFile)
            {
                var uniqueFileName = string.Format(@"{0}.png", Guid.NewGuid());
                string fileName = Path.Combine(Server.MapPath("/Img/User"), uniqueFileName);
                fuDP.SaveAs(fileName);
                imgDP.ImageUrl = "/Img/User/" + uniqueFileName;
                Session["tempDP"] = imgDP.ImageUrl;
            }
        }

        protected void btnUploadBP_Click(object sender, EventArgs e)
        {
            if (fuBP.HasFile)
            {
                var uniqueFileName = string.Format(@"{0}.png", Guid.NewGuid());
                string fileName = Path.Combine(Server.MapPath("/Img/User"), uniqueFileName);
                fuBP.SaveAs(fileName);
                imgBP.ImageUrl = "/Img/User/" + uniqueFileName;
                Session["tempBP"] = imgBP.ImageUrl;
            }
        }
    }
}