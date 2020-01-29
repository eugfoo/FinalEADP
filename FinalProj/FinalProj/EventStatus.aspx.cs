using System;
using System.Collections.Generic;
using System.Globalization;
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
                        evStListTemp[i].OrganiserPic = Session["Pic"].ToString();
                        evStListTemp[i].Organiser = Session["Name"].ToString();
                        evStList.Add(evStListTemp[i]);
                        eventCount += 1;
                    }
                }


                foreach (EventsStatus element in evStList)
                {
                    element.NumCompleted = eventCount;

                    int index = element.Date.IndexOf(" ");
                    

                    element.Date = element.Date.Substring(0, index);
                    element.StartTime = element.StartTime.Substring(0, 5);
                    element.EndTime = element.EndTime.Substring(0, 5);
                    

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

                    string date = element.Date + " " + element.EndTime;
                    DateTime dt1 = DateTime.Parse(date);
                    DateTime dt2 = DateTime.Now;

                    int result = DateTime.Compare(dt1, dt2);

                    if (result < 0 || result == 0)
                        element.Completed = "Complete";

                    forCount += 1;
                }
            }
        }
    }
}