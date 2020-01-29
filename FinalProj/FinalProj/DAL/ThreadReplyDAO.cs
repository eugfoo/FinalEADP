using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProj.DAL
{
    public class ThreadReplyDAO
    {
        public int Insert(ThreadReply threadReply)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO ThreadReplies (threadId, postDate, postContent, user_id)" +
                "VALUES (@paraThreadId, @paraPostDate, @paraPostContent, @paraUserId)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraThreadId", threadReply.ThreadId);
            sqlCmd.Parameters.AddWithValue("@paraPostDate", threadReply.PostDate);
            sqlCmd.Parameters.AddWithValue("@paraPostContent", threadReply.PostContent);
            sqlCmd.Parameters.AddWithValue("@paraUserId", threadReply.UserId);
        
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }
    }
}