using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProj
{
    public partial class threadCreaterOverview : System.Web.UI.Page
    {
        protected Users currentThreadUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Request.QueryString["userId"];
            Thread thread = new Thread();
            Users usr = new Users();
            rptrThreads.DataSource = thread.getThreadByUserId(int.Parse(userId));
            rptrThreads.DataBind();

            currentThreadUser = usr.GetUserById(int.Parse(userId));

        }
    }
}