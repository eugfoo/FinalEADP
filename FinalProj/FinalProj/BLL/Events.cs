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
		public int EventId { get; set; }
		public string Title { get; set; }
		public string Venue { get; set; }
		public string Date { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public int MaxAttendees { get; set; }
		public string Desc { get; set; }
		public string Pic { get; set; }
		public string Note { get; set; }
		public int AverageRating { get; set; }
		public int User_id { get; set; }


		public Events()
		{

		}
		// Define a constructor to initialize all the properties
		public Events(int eventId, string eventTitle, string eventVenue, string eventDate, string eventStartTime, string eventEndTime, int eventMaxAttendees, string eventDesc, string eventPic, string eventNote, int avgRating, int user_id)
		{
			EventId = eventId;
			Title = eventTitle;
			Venue = eventVenue;
			Date = eventDate;
			StartTime = eventStartTime;
			EndTime = eventEndTime;
			MaxAttendees = eventMaxAttendees;
			Desc = eventDesc;
			Pic = eventPic;
			Note = eventNote;
			User_id = user_id;
			AverageRating = avgRating;

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

		public Events getEventDetails(int eventId)
		{
			eventDao ev = new eventDao();
			return ev.getEventDetails(eventId);
		}

		public List<int> getAllParticipants(int eventId)
		{
			eventDao ev = new eventDao();

			return ev.SelectAllParticipants(eventId);
		}

		public int AddParticipant(int userId, int eventId, string userName)
		{
			eventDao dao = new eventDao();
			int result = dao.InsertParticipant(userId, eventId, userName);
			return result;
		}

		public int RemoveParticipant(int userId, int eventId)
		{
			eventDao dao = new eventDao();
			int result = dao.DeleteParticipant(userId, eventId);
			return result;
		}


        public List<Events> GetAllAttendingEventsByUserId(int UserId) // i am using for ppgallery -azim
        {
            eventDao ev = new eventDao();
            return ev.SelectAllAttendingEventsByUserId(UserId);

        }

        public List<Events> GetAllEventsCreatedByUser(int UserId) // i am using for pprating -azim
        {
            eventDao ev = new eventDao();
            return ev.SelectAllEventsCreatedByUser(UserId);

        }

        public List<Events> GetAllBookedmarkedEventsById(int UserId)
		{
			eventDao ev = new eventDao();
			return ev.SelectAllBookmarkedEvents(UserId);

		}

		public bool VerifyIfEventIsBookmarked(int UserId, int eventId)
		{
			eventDao ev = new eventDao();
			return ev.CheckIfEventIsBookedmarked(UserId, eventId);

		}

		public bool VerifyIfUserIsAttendingEvent(int UserId, int eventId)
		{
			eventDao ev = new eventDao();
			return ev.CheckIfAttending(UserId, eventId);

		}

		public int findBookmark(int userId, int eventId)
		{
			eventDao dao = new eventDao();
			int result = dao.insertBookmarkEvent(userId, eventId);
			return result;
		}

		public int removeBookmark(int userId, int eventId)
		{
			eventDao dao = new eventDao();
			int result = dao.DeleteBookmark(userId, eventId);
			return result;
		}

		public int removeEvent(int eventId)
		{
			eventDao dao = new eventDao();
			int result = dao.DeleteEvent(eventId);
			return result;
		}

        public int updateAvgRatingByEventId(int eventId, int avgRating)
        {
            eventDao dao = new eventDao();
            return dao.updateAvgRatingByEventId(eventId, avgRating);
        }



    }
}