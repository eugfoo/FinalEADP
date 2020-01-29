using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProj.DAL
{
    public class ThreadDAO
    {
        public int Insert(Thread thread)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Threads (threadPrefix, threadBadgeColor, threadTitle, threadDate, threadImage1, threadImage2, " +
                "threadImage3, threadImage4, threadContent, user_id, user_name)" +
                "VALUES (@paraThreadPrefix, @paraThreadBadgeColor, @paraThreadTitle, @paraThreadDate, @paraThreadImage1, " +
                "@paraThreadImage2, @paraThreadImage3, @paraThreadImage4, @paraThreadContent, @paraUserId, @paraUserName)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraThreadPrefix", thread.Prefix);
            sqlCmd.Parameters.AddWithValue("@paraThreadBadgeColor", thread.BadgeColor);
            sqlCmd.Parameters.AddWithValue("@paraThreadTitle", thread.Title);
            sqlCmd.Parameters.AddWithValue("@paraThreadDate", thread.Date);
            sqlCmd.Parameters.AddWithValue("@paraThreadImage1", thread.ThreadImage1);
            sqlCmd.Parameters.AddWithValue("@paraThreadImage2", thread.ThreadImage2);
            sqlCmd.Parameters.AddWithValue("@paraThreadImage3", thread.ThreadImage3);
            sqlCmd.Parameters.AddWithValue("@paraThreadImage4", thread.ThreadImage4);
            sqlCmd.Parameters.AddWithValue("@paraThreadContent", thread.Content);
            sqlCmd.Parameters.AddWithValue("@paraUserId", thread.UserId);
            sqlCmd.Parameters.AddWithValue("@paraUserName", thread.UserName);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int Update(int id, Thread thread)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();
           
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
      

            string sqlStmt = "UPDATE Threads SET threadPrefix = @paraThreadPrefix, threadBadgeColor = @paraThreadBadgeColor, threadTitle = @paraThreadTitle, " +
                "threadDate = @paraThreadDate, threadContent = @paraThreadContent, " +
                "user_id = @paraUserId, user_name = @paraUserName WHERE Id = @parathreadId";

            


            sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraThreadPrefix", thread.Prefix);
            sqlCmd.Parameters.AddWithValue("@paraThreadBadgeColor", thread.BadgeColor);
            sqlCmd.Parameters.AddWithValue("@paraThreadTitle", thread.Title);
            sqlCmd.Parameters.AddWithValue("@paraThreadDate", thread.Date);
            sqlCmd.Parameters.AddWithValue("@paraThreadContent", thread.Content);
            sqlCmd.Parameters.AddWithValue("@paraUserId", thread.UserId);
            sqlCmd.Parameters.AddWithValue("@paraUserName", thread.UserName);
            sqlCmd.Parameters.AddWithValue("@parathreadId", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}