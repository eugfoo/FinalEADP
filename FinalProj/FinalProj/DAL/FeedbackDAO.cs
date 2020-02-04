using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProj.DAL
{
    public class FeedbackDAO
    {
        public int Insert(Feedback feedback)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Feedback (eventId, userId, avgRating, userReview, feedbackDone)" +
                 "VALUES (@paraEventId, @paraUserId, @paraAvgRating, @paraUserReview, @paraFeedbackDone)";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEventId", feedback.EventId);
            sqlCmd.Parameters.AddWithValue("@paraUserId", feedback.UserId);
            sqlCmd.Parameters.AddWithValue("@paraAvgRating", feedback.AvgRating);
            sqlCmd.Parameters.AddWithValue("@paraUserReview", feedback.UserReview);
            sqlCmd.Parameters.AddWithValue("@paraFeedbackDone", feedback.FeedbackDone);
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}