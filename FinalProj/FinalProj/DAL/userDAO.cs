using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.BLL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinalProj.DAL
{
    public class userDAO
    {
        public int Insert(Users user)
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
            string sqlStmt = "INSERT INTO Users(userEmail, userName, userPasswordHash, userIsOrg, userRegDate) " +
                "VALUES (@userEmail, @userName, @userPasswordHash, @userIsOrg, @userRegDate)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@userEmail", user.email);
            sqlCmd.Parameters.AddWithValue("@userName", user.name);
            sqlCmd.Parameters.AddWithValue("@userPasswordHash", user.passHash);
            sqlCmd.Parameters.AddWithValue("@userIsOrg", user.isOrg);
            sqlCmd.Parameters.AddWithValue("@userRegDate", user.regDate);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();
            return result;
        }

        public Users SelectByEmail(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select * from Users where userEmail = @email";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@email", email);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Users user = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int Uid = Convert.ToInt32(row["Id"]);
                string Uemail = row["userEmail"].ToString();
                string UpassHash = row["userPasswordHash"].ToString();
                string Uname = row["userName"].ToString();
                string UDPimage = row["userDPImage"].ToString();
                string UBPimage = row["userBPImage"].ToString();
                string Udesc = row["userDesc"].ToString();
                int Urating = Convert.ToInt32(row["userRating"]);
                string UisOrg = row["userIsOrg"].ToString();
                int Upoints = Convert.ToInt32(row["userPoints"]);
                string Uparticipate = row["userParticipated"].ToString();
                int Uverified = Convert.ToInt32(row["userIsVerified"]);
                DateTime UregDate = Convert.ToDateTime(row["userRegDate"]);
                user = new Users(Uid, Uemail, UpassHash, Uname, UDPimage, UBPimage, Udesc, Urating, UisOrg, Upoints, Uparticipate, Uverified, UregDate);
            }
            else
            {
                user = null;
            }

            return user;
        }

        public int UpdateName(int id, string name)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "UPDATE Users SET userName = @paraName where id = @paraId";
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int UpdateDesc(int id, string desc)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "UPDATE Users SET userDesc = @paraDesc where id = @paraId";
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraDesc", desc);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int UpdateDP(int id, string filepath)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "UPDATE Users SET userDPImage = @paraDP where id = @paraId";
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraDP", filepath);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int UpdateBP(int id, string filepath)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "UPDATE Users SET userBPImage = @paraBP where id = @paraId";
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraBP", filepath);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }
    }
}