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
    public class eventStatusDAO
    {
        public List<EventsStatus> SelectAllByName()
        {
            //Step 1 -  Define a connection to the database
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from db table
            string sqlStmt = "Select * from tdEvent Order By eventDate DESC, eventStartTime";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

			//Step 3 -  Create a DataSet to store the data to be retrieved
			DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<EventsStatus> evStList = new List<EventsStatus>();
            List<EventsStatus> tempList = new List<EventsStatus>();
            var dateList = new List<string>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string eventTitle = row["eventTitle"].ToString();
                string eventVenue = row["eventVenue"].ToString();
                string eventDate = row["eventDate"].ToString();
                string eventStartTime = row["eventStartTime"].ToString();
                string eventEndTime = row["eventEndTime"].ToString();
                string eventDesc = row["eventDesc"].ToString();
                string eventPic = row["eventPic"].ToString();
                EventsStatus obj = new EventsStatus(eventTitle, eventVenue, eventDate ,eventStartTime, eventEndTime, eventDesc, eventPic);
                evStList.Add(obj);
            };

            System.Diagnostics.Debug.WriteLine("This is evStList: " + string.Join(Environment.NewLine, evStList));


            return evStList;
        }
    }
}
