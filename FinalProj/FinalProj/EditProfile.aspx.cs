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
        public string DPfilepath = "";
        public string BPfilepath = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null) // A user has signed in
            {
                Users user = (Users)Session["user"];
                if (user.DPimage != null)
                {
                    imgDP.ImageUrl = user.DPimage;
                }
                if (user.BPimage != null)
                {
                    imgBP.ImageUrl = user.BPimage;
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
            if (DPfilepath != "")
            {
                user.UpdateDPByID(user.id, DPfilepath);
            }
            if (BPfilepath != "")
            {
                user.UpdateDescByID(user.id, BPfilepath);
            }

            Response.Redirect("/EventStatus.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EventStatus.aspx");
        }

        protected void btnUploadDP_Click(object sender, EventArgs e)
        {
            if (fuDP.HasFile)
            {
                var uniqueFileName = string.Format(@"{0}.png", Guid.NewGuid());
                string fileName = Path.Combine(Server.MapPath("~/Img/User"), uniqueFileName);
                fuDP.SaveAs(fileName);
                imgDP.ImageUrl = "~/Img/User/" + uniqueFileName;
                DPfilepath = "~/Img/User/" + uniqueFileName;
            }
            
        }

        protected void btnUploadBP_Click(object sender, EventArgs e)
        {
            if (fuBP.HasFile)
            {
                var uniqueFileName = string.Format(@"{0}.png", Guid.NewGuid());
                string fileName = Path.Combine(Server.MapPath("~/Img/User"), uniqueFileName);
                fuBP.SaveAs(fileName);
                imgBP.ImageUrl = "~/Img/User/" + uniqueFileName;
                BPfilepath = "~/Img/User/" + uniqueFileName;
            }

        }

    }
}