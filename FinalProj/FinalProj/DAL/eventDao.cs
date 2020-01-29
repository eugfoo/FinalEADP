using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace FinalProj.DAL
{
    public class eventDao
    {
        public List<Events> SelectAllByDate(DateTime date)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from tdEvent Where eventDate = @paraDate Order By eventStartTime";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

			da.SelectCommand.Parameters.AddWithValue("@paraDate", date);

			//Step 3 -  Create a DataSet to store the data to be retrieved
			DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Events> evList = new List<Events>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string eventTitle = row["eventTitle"].ToString();
                string eventVenue = row["eventVenue"].ToString();
                string eventDate = row["eventDate"].ToString();
                string eventStartTime = row["eventStartTime"].ToString();
                string eventEndTime = row["eventEndTime"].ToString();
                int eventMaxAttendees = int.Parse(row["eventMaxAttendees"].ToString());
                string eventDesc = row["eventDesc"].ToString();
                string eventPic = row["eventPic"].ToString();
                string eventNote = row["eventNote"].ToString();
                int eventAdv = int.Parse(row["eventAdv"].ToString());
				int user_id = int.Parse(row["user_id"].ToString());
				

				Events obj = new Events(eventTitle, eventVenue, eventDate ,eventStartTime, eventEndTime, eventMaxAttendees, eventDesc, eventPic, eventNote, eventAdv, user_id);
                evList.Add(obj);
            }

            return evList;
        }

        public int Insert(Events ev)
        {
            // Execute NonQuery return an integer value
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "INSERT INTO tdEvent(eventTitle, eventVenue, eventDate, eventStartTime, eventEndTime, eventMaxAttendees, eventDesc, eventPic, eventNote, eventAdv, user_id) " +
                "VALUES (@eventTitle, @eventVenue, @eventDate, @eventStartTime, @eventEndTime, @eventMaxAttendees, @eventDesc, @eventPic, @eventNote, @eventAdv, @user_id)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@eventTitle", ev.Title);
            sqlCmd.Parameters.AddWithValue("@eventVenue", ev.Name);
            sqlCmd.Parameters.AddWithValue("@eventDate", ev.Date);
            sqlCmd.Parameters.AddWithValue("@eventStartTime", ev.StartTime);
            sqlCmd.Parameters.AddWithValue("@eventEndTime", ev.EndTime);
            sqlCmd.Parameters.AddWithValue("@eventMaxAttendees", ev.MaxAttendees);
            sqlCmd.Parameters.AddWithValue("@eventDesc", ev.Desc);
            sqlCmd.Parameters.AddWithValue("@eventPic", ev.Pic);
            sqlCmd.Parameters.AddWithValue("@eventNote", ev.Note);
            sqlCmd.Parameters.AddWithValue("@eventAdv", ev.Advertisement);
			sqlCmd.Parameters.AddWithValue("@user_id", ev.User_id);
			



			// Step 4 Open connection the execute NonQuery of sql command   
			myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

		public string SelectUserNameByUserId(int id)
		{
			string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
			SqlConnection myConn = new SqlConnection(DBConnect);
			string sqlStmt = "Select * from Users where id = @paraUserId";
			SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
			da.SelectCommand.Parameters.AddWithValue("@paraUserId", id);
			DataSet ds = new DataSet();
			da.Fill(ds);

			string user = null;
			int rec_cnt = ds.Tables[0].Rows.Count;
			if (rec_cnt == 1)
			{
				DataRow row = ds.Tables[0].Rows[0];
				user = row["userName"].ToString();
			}
			else
			{
				user = null;
			}

			return user;
		}
	}
}