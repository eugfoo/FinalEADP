using FinalProj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.BLL
{
    public class Feedback
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int AvgRating { get; set; }
        public string UserReview { get; set; }
        public int FeedbackDone { get; set; }


        public Feedback() { }

        public Feedback(int eventId, int userId, int avgRating, string userReview, int feedbackDone)
        {
            EventId = eventId;
            UserId = userId;
            AvgRating = avgRating;
            UserReview = userReview;
            FeedbackDone = feedbackDone;
        }

        public int createFeedback()
        {
            FeedbackDAO dao = new FeedbackDAO();
            int result = dao.Insert(this);
            return result;
        }

    }

}