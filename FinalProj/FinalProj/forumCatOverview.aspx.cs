using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProj
{
    public partial class forumCatOverview : System.Web.UI.Page
    {
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 8;

        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ThreadsRptr();
            }

            if (Page.IsPostBack) return;
            BindDataIntoRepeater();

        }


        static DataTable GetDataFromDb()
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
                        return allThreads;
                    }
                }
            }
        }

        private void BindDataIntoRepeater()
        {
            var dt = GetDataFromDb();
            _pgsource.DataSource = dt.DefaultView;
            _pgsource.AllowPaging = true;

            _pgsource.PageSize = _pageSize;
            _pgsource.CurrentPageIndex = CurrentPage;

            ViewState["TotalPages"] = _pgsource.PageCount;

            lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;

            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;
            lbFirst.Enabled = !_pgsource.IsFirstPage;
            lbLast.Enabled = !_pgsource.IsLastPage;
            rptrThreads.DataSource = _pgsource;
            rptrThreads.DataBind();


            HandlePaging();
        }

        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex");
            dt.Columns.Add("PageText");

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;



            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BindDataIntoRepeater();
        }

        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindDataIntoRepeater();
        }

        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater();
        }

        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#8db0c7");
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