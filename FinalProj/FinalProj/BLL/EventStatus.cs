using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DAL;

namespace FinalProj.BLL
{
    public class EventsStatus
    {
        // Define class properties
        public string Title { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Desc { get; set; }
        public string Pic { get; set; }

        public EventsStatus()
        {

        }
        // Define a constructor to initialize all the properties
        public EventsStatus(string eventTitle, string eventVenue, string eventDate, string eventStartTime, string eventEndTime, string eventDesc, string eventPic)
        {
            Title = eventTitle;
            Name = eventVenue;
            Date = eventDate;
            StartTime = eventStartTime;
            EndTime = eventEndTime;
            Desc = eventDesc;
            Pic = eventPic;
        }

        public List<EventsStatus> GetAllEventsByName()
        {
            eventStatusDAO evst = new eventStatusDAO();
            return evst.SelectAllByName();
        }

    }
}