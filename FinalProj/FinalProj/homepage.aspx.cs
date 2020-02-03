using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;

namespace FinalProj
{
	public partial class Corporate : System.Web.UI.Page
	{ 
        protected List<Events> evList;
		protected List<int> attending;
		protected Dictionary<int, string> userList = new Dictionary<int, string>();
        protected Dictionary<int, int> userIdList = new Dictionary<int, int>();
        protected Dictionary<int, int> attendingUsers = new Dictionary<int, int>();
		protected List<Users> participantList = new List<Users>();

		protected void Page_Load(object sender, EventArgs e)
		{
			
			Events ev = new Events();
			DateTime currentDate;

			currentDate = DateTime.Now.Date;
			
			evList = ev.GetAllEventsByEDate(currentDate);

			foreach (Events element in evList)                  // loops through each event list and changes formatting of both time and date
			{
				int index = element.Date.IndexOf(" ");
				element.Date = element.Date.Substring(0, index);
				element.StartTime = element.StartTime.Substring(0, 5);

				if (int.Parse(element.StartTime.Substring(0, 2)) >= 12)
				{

					if(int.Parse(element.StartTime.Substring(0, 2)) == 12)
						element.StartTime = (int.Parse(element.StartTime.Substring(0, 2))).ToString() + ":" + element.StartTime.Substring(3, 2) + " PM";
					else
					element.StartTime = (int.Parse(element.StartTime.Substring(0, 2)) - 12).ToString() + ":" + element.StartTime.Substring(3, 2) + " PM";
				}
				else
				{
					element.StartTime = element.StartTime + " AM";
				}
				userList.Add(element.EventId, ev.GetAllUserNameByUserId(element.User_id));
                userIdList.Add(element.EventId, element.User_id);
                attending = element.getAllParticipants(element.EventId);
				attendingUsers.Add(element.EventId, attending.Count);
				
			}
			if (Session["user"] == null)
			{
				createEvent.Enabled = false;
			}

			


		}
		
		protected void DateClicked(object sender, EventArgs e)
		{
			Events ev = new Events();
			DateTime currentDate;
			currentDate = Convert.ToDateTime(hidingDate.Text);
			evList = ev.GetAllEventsByEDate(currentDate);

			foreach (Events element in evList)                  // loops through each event list and changes formatting of both time and date
			{
				int index = element.Date.IndexOf(" ");
				element.Date = element.Date.Substring(0, index);
				element.StartTime = element.StartTime.Substring(0, 5);

				if (int.Parse(element.StartTime.Substring(0, 2)) >= 12)
				{
					if (int.Parse(element.StartTime.Substring(0, 2)) == 12)
						element.StartTime = (int.Parse(element.StartTime.Substring(0, 2))).ToString() + ":" + element.StartTime.Substring(3, 2) + " PM";
					else
						element.StartTime = (int.Parse(element.StartTime.Substring(0, 2)) - 12).ToString() + ":" + element.StartTime.Substring(3, 2) + " PM";
				
				}
				else
				{
					element.StartTime = element.StartTime + " AM";
				}

				
			}

		}

		protected void createEvent_Click(object sender, EventArgs e)
		{
			Response.Redirect("createEvent.aspx");
		}
	}
}