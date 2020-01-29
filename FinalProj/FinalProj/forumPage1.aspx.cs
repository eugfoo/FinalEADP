using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProj
{
    public partial class forumPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ThreadsRptr();
                ConfirmedThreadsRptr();
            }

        }

        private void ThreadsRptr()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand cmd = new SqlCommand("Select TOP 5 * From Threads ORDER BY Id DESC", myConn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable allThreads = new DataTable();
                        sda.Fill(allThreads);
                        rptrThreads.DataSource = allThreads;
                        rptrThreads.DataBind();
                    }
                }
            }
        }

        private void ConfirmedThreadsRptr()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand cmd = new SqlCommand("Select TOP 5 * From tdEvent ORDER BY Id DESC", myConn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable allThreads = new DataTable();
                        sda.Fill(allThreads);
                        rptrConfirmedThreads.DataSource = allThreads;
                        rptrConfirmedThreads.DataBind();
                    }
                }
            }
        }
    }
}