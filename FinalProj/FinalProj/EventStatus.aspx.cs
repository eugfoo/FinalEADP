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
        protected List<EventsStatus> evStList;

        protected void Page_Load(object sender, EventArgs e)
        {
            EventsStatus evSt = new EventsStatus();

            evStList = evSt.GetAllEventsByName();

            foreach (EventsStatus element in evStList)
            {
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
            }
            
        }
    }
}