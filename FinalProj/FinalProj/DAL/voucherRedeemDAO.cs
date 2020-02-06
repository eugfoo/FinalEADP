<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.BLL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FinalProj.DAL
{
    public class voucherRedeemDAO
    {
        public List<VoucherRedeemed> SelectAllByName()
        {
            //Step 1 -  Define a connection to the database
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from db table
            string sqlStmt = "Select * from VoucherRedeemed Order By VoucherName DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<VoucherRedeemed> voucherList = new List<VoucherRedeemed>();
            List<VoucherRedeemed> tempList = new List<VoucherRedeemed>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string voucherName = row["VoucherName"].ToString();
                string voucherAmt = row["VoucherAmount"].ToString();
                string voucherPic = row["VoucherPic"].ToString();
                string userId = row["UserId"].ToString();
                VoucherRedeemed obj = new VoucherRedeemed(voucherName, voucherAmt, voucherPic, userId);
                voucherList.Add(obj);
            };

            return voucherList;
        }

        public int Insert(VoucherRedeemed vcher)
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
            string sqlStmt = "INSERT INTO VoucherRedeemed(VoucherName, VoucherAmount, VoucherPic, UserId) " +
                             "VALUES (@voucherName, @voucherAmt, @voucherPic, @userId)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@voucherName", vcher.VoucherName);
            sqlCmd.Parameters.AddWithValue("@voucherAmt", vcher.VoucherAmount);
            sqlCmd.Parameters.AddWithValue("@voucherPic", vcher.VoucherPic);
            sqlCmd.Parameters.AddWithValue("@userId", vcher.UserId);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.BLL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FinalProj.DAL
{
    public class voucherRedeemDAO
    {
        public List<VoucherRedeemed> SelectAllByName()
        {
            //Step 1 -  Define a connection to the database
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from db table
            string sqlStmt = "Select * from VoucherRedeemed Order By VoucherName DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<VoucherRedeemed> voucherList = new List<VoucherRedeemed>();
            List<VoucherRedeemed> tempList = new List<VoucherRedeemed>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string voucherName = row["VoucherName"].ToString();
                string voucherAmt = row["VoucherAmount"].ToString();
                string voucherPic = row["VoucherPic"].ToString();
                string userId = row["UserId"].ToString();
                VoucherRedeemed obj = new VoucherRedeemed(voucherName, voucherAmt, voucherPic, userId);
                voucherList.Add(obj);
            };

            return voucherList;
        }

        public int Insert(VoucherRedeemed vcher)
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
            string sqlStmt = "INSERT INTO VoucherRedeemed(VoucherName, VoucherAmount, VoucherPic, UserId) " +
                             "VALUES (@voucherName, @voucherAmt, @voucherPic, @userId)";
            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@voucherName", vcher.VoucherName);
            sqlCmd.Parameters.AddWithValue("@voucherAmt", vcher.VoucherAmount);
            sqlCmd.Parameters.AddWithValue("@voucherPic", vcher.VoucherPic);
            sqlCmd.Parameters.AddWithValue("@userId", vcher.UserId);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
    }
>>>>>>> Stashed changes
}