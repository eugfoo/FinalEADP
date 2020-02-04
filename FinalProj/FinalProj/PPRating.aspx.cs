using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;
using System.Collections;
using System.Data;

namespace FinalProj
{
    public partial class PPRating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = (Users)Session["user"];
            if (user != null)
            {
                if (!Page.IsPostBack)
                {
                    ddlEvents.DataSource = CreateDataSource(user.id);
                    ddlEvents.DataTextField = "EventTextField";
                    ddlEvents.DataValueField = "EventValueField";
                    ddlEvents.DataBind();
                    ddlEvents.SelectedIndex = 0;
                }
            }
            else
            {
                Response.Redirect("homepage.aspx");
            }
            
        }

        protected void ddlEvents_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ICollection CreateDataSource(int userId)
        {
            List<Events> ev = new Events().GetAllEventsCreatedByUser(userId);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EventTextField", typeof(String)));
            dt.Columns.Add(new DataColumn("EventValueField", typeof(int)));

            for (int i = 0; i < ev.Count; i++)
            {
                dt.Rows.Add(CreateRow(ev[i].Title, ev[i].EventId, dt));
            }

            DataView dv = new DataView(dt);
            return dv;

        }

        DataRow CreateRow(String Text, int Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr[0] = Text;
            dr[1] = Value;

            return dr;

        }
    }
}