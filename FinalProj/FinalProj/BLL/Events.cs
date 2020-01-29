using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DAL;

namespace FinalProj.BLL
{
    public class Events
    {
        // Define class properties
        public string Title { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int MaxAttendees{ get; set; }
        public string Desc { get; set; }
        public string Pic { get; set; }
        public string Note { get; set; }
        public int Advertisement { get; set; }
		public int User_id { get; set; }


		public Events()
        {

        }
        // Define a constructor to initialize all the properties
        public Events(string eventTitle, string eventVenue, string eventDate , string eventStartTime, string eventEndTime, int eventMaxAttendees, string eventDesc, string eventPic, string eventNote, int eventAdv, int user_id)
        {
            Title = eventTitle;
            Name = eventVenue;
            Date = eventDate;
            StartTime = eventStartTime;
            EndTime = eventEndTime;
            MaxAttendees = eventMaxAttendees;
            Desc = eventDesc;
            Pic = eventPic;
            Note = eventNote;
            Advertisement = eventAdv;
			User_id = user_id;
			
        }

        public int AddEvent()
        {
            eventDao dao = new eventDao();
            int result = dao.Insert(this);
            return result;
        }

        public List<Events> GetAllEventsByEDate(DateTime date)
        {
            eventDao ev = new eventDao();
            return ev.SelectAllByDate(date);
        }

		public string GetAllUserNameByUserId(int userId)
		{
			eventDao ev = new eventDao();
			return ev.SelectUserNameByUserId(userId);
		}
	}
}