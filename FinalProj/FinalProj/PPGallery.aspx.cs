using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;

namespace FinalProj
{
    public partial class PPGallery : System.Web.UI.Page
    {
        public List<GPictures> gpList = null;
        public string viewingUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            viewingUserId = Request.QueryString["userId"];
            Users user = (Users)Session["user"];

            if (user != null)
            {
                if (viewingUserId != null) // A user is viewing another's PP
                {
                    btnOpenModal.Visible = false;
                    loadGP(Convert.ToInt32(viewingUserId));
                }
                else
                {
                    loadGP(user.id);
                }
            }
            else
            {
                btnOpenModal.Visible = false;
                loadGP(Convert.ToInt32(viewingUserId));
            }
        }

        protected void btnDisplayPic_Click(object sender, EventArgs e)
        {
            if (fuPic.HasFile)
            {
                var uniqueFileName = string.Format(@"{0}.png", Guid.NewGuid());
                string fileName = Path.Combine(Server.MapPath("~/Img/User"), uniqueFileName);
                fuPic.SaveAs(fileName);
                imgPic.ImageUrl = "/Img/User/" + uniqueFileName;
                Session["tempPic"] = imgPic.ImageUrl;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Users user = (Users)Session["user"];
            var filepath = Session["tempPic"].ToString();
            var caption = tbCaption.Text;
            int gpevent = 1;
            DateTime now = DateTime.Now;
            GPictures gpic = new GPictures(filepath, user.id, caption, gpevent, now);
            gpic.addGP();
            loadGP(user.id);
        }

        public void loadGP(int userId)
        {
            GPictures gp = new GPictures();
            gpList = gp.getAllByUserId(userId);
        }
    }
}