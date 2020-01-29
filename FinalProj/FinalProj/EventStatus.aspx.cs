using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;

namespace FinalProj
{
    public partial class EventStatus : System.Web.UI.Page
    {
        protected List<EventsStatus> evStListTemp;
        protected List<EventsStatus> evStList = new List<EventsStatus>();
        public int eventCount = 0;
        public List<string> complete = new List<string>();
        int forCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            EventsStatus evSt = new EventsStatus();
            Users usr = new Users();

            if (Session["user"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            else
            {
                evStListTemp = evSt.GetAllEventsByName();

                for (int i = 0; i < evStListTemp.Count; i++)
                {
                    if (evStListTemp[i].Organiser == Session["id"].ToString())
                    {
                        evStList.Add(evStListTemp[i]);
                        eventCount += 1;
                    }
                }

                foreach (EventsStatus element in evStList)
                {

                    int index = element.Date.IndexOf(" ");
                    element.Date = element.Date.Substring(0, index);
                    element.StartTime = element.StartTime.Substring(0, 5);
                    element.EndTime = element.EndTime.Substring(0, 5);
                    DateTime dt1 = DateTime.Parse(element.Date + " " + element.EndTime);
                    DateTime dt2 = DateTime.Now;

                    if (dt1.Date < dt2.Date)
                    {
                        complete.Add("Completed");
                    }
                    else
                    {
                        complete.Add("Incomplete");
                    }

                    if (int.Parse(element.StartTime.Substring(0, 2)) >= 12)
                    {
                        element.StartTime = (int.Parse(element.StartTime.Substring(0, 2)) - 12).ToString() + ":" + element.StartTime.Substring(3, 2) + " PM";
                    }
                    else
                    {
                        element.StartTime = element.StartTime + " AM";
                    }

                    if (int.Parse(element.EndTime.Substring(0, 2)) >= 12)
                    {
                        element.EndTime = (int.Parse(element.EndTime.Substring(0, 2)) - 12).ToString() + ":" + element.EndTime.Substring(3, 2) + " PM";
                    }
                    else
                    {
                        element.EndTime = element.EndTime + " AM";
                    }

                    forCount += 1;
                }
            }
        }
    }
}