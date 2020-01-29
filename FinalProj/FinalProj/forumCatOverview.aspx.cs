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
    public partial class forumCatOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ThreadsRptr();
            }

        }

        private void ThreadsRptr()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From Threads ORDER BY Id DESC", myConn))
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

        private DataSet GetData()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Threads", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }




        }
    }
}