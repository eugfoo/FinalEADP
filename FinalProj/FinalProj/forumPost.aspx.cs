using FinalProj.BLL;
using System;
using System.Collections;
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
    public partial class forumPost : System.Web.UI.Page
    {
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 3;

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
            string threadId = Request.QueryString["threadid"];

            if (threadId != null)
            {
                Thread thread = new Thread();
                Thread currentThread = thread.GetThreadByThreadId(threadId);

                LblTitle.Text = currentThread.Title;
                LblTitleBig.Text = currentThread.Title;
                LblTitleBreadcrumb.Text = currentThread.Title;
                LblPostDate.Text = currentThread.Date;
                LblContent.Text = currentThread.Content;
                LblPrefix.Text = currentThread.Prefix;
                HFthreadId.Value = threadId;
            }

            if (Page.IsPostBack) return;
            BindDataIntoRepeater();

            if (!IsPostBack)
            {
                getImages(HFthreadId.Value);

            }

        }



        private void getImages(string threadId)
        {
            DataTable allImages = new DataTable();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            myConn.Open();
            string sqlCmd = "Select * From Threads WHERE Id = @paraThreadId";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd, myConn);
            sqlDa.SelectCommand.Parameters.AddWithValue("@paraThreadId", threadId);
            sqlDa.Fill(allImages);
            LVImages.DataSource = allImages;
            LVImages.DataBind();
            myConn.Close();

        }

        static DataTable GetDataFromDb(string threadId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            DataTable allComments = new DataTable();

            myConn.Open();
            string sqlCmd = "Select * From ThreadReplies WHERE threadId = @paraThreadId";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd, myConn);
            sqlDa.SelectCommand.Parameters.AddWithValue("@paraThreadId", threadId);
            sqlDa.Fill(allComments);
            myConn.Close();
            return allComments;
        }

        private void BindDataIntoRepeater()
        {
            var dt = GetDataFromDb(HFthreadId.Value);
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
            rptrComments.DataSource = _pgsource;
            rptrComments.DataBind();


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



        protected void btnReply_Click(object sender, EventArgs e)
        {
            ThreadReply threadReply = new ThreadReply();

            if (String.IsNullOrEmpty(tbReplyContent.Text))
            {
                LblMsg.Text = "Please write something in the reply! <br/>";
                LblMsg.ForeColor = Color.Red;
            }
            else
            {
                DateTime now = DateTime.Now;
                HFDate.Value = now.ToString("g");
                DateTime mDate = Convert.ToDateTime(HFDate.Value);

                threadReply = new ThreadReply(HFthreadId.Value, HFDate.Value, tbReplyContent.Text, "1");
                int result = threadReply.ReplyThread();
                if (result == 1)
                {
                    Response.Redirect("forumPost.aspx?threadid=" + HFthreadId.Value);
                }


            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Session["LblPrefix"] = LblPrefix.Text;
            Session["LblTitle"] = LblTitle.Text;
            Session["LblContent"] = LblContent.Text;
            Session["threadId"] = HFthreadId.Value;
            Response.Redirect("editForumPost.aspx?threadid=" + HFthreadId.Value);
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("forumCatOverview.aspx");

        }

    }

}



//private void GetComments(string threadId)
//{
//    DataTable allComments = new DataTable();

//    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
//    SqlConnection myConn = new SqlConnection(DBConnect);

//    myConn.Open();
//    string sqlCmd = "Select * From ThreadReplies WHERE threadId = @paraThreadId";
//    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd, myConn);
//    sqlDa.SelectCommand.Parameters.AddWithValue("@paraThreadId", threadId);
//    sqlDa.Fill(allComments);
//    myConn.Close();

//    PagedDataSource pdsData = new PagedDataSource();

//    DataView dv = new DataView(allComments);
//    pdsData.DataSource = dv;
//    pdsData.AllowPaging = true;
//    pdsData.PageSize = iPageSize;

//    if (ViewState["PageNumber"] != null)
//        pdsData.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
//    else
//        pdsData.CurrentPageIndex = 0;

//    if(pdsData.PageCount > 1)
//    {
//        Repeater1.Visible = true;
//        ArrayList allPages = new ArrayList();
//        for (int i = 1; i <= pdsData.PageCount; i++)
//            allPages.Add((i).ToString());
//        //allPages.RemoveAt(allPages.Count - 1);
//        Repeater1.DataSource = allPages;
//        Repeater1.DataBind();
//    }
//    else
//    {
//        Repeater1.Visible = false;
//    }
//    rptrComments.DataSource = pdsData;
//    rptrComments.DataBind();
//}

//protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
//{
//    ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument);
//    GetComments(HFthreadId.Value);
//    //string url = e.CommandArgument.ToString();
//    //Response.Redirect("forumPost.aspx?threadid=" + HFthreadId.Value + "/" + url);
//}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//private void RepliesRptr(string threadId)
//{
//    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
//    SqlConnection myConn = new SqlConnection(DBConnect);

//    string sqlStmt = "Select * From ThreadReplies WHERE threadId = @paraThreadId";

//    using (SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn))
//    {
//        da.SelectCommand.Parameters.AddWithValue("@paraThreadId", threadId);
//        DataTable allThreads = new DataTable();
//        da.Fill(allThreads);
//        rptrComments.DataSource = allThreads;
//        rptrComments.DataBind();
//    }

//using (SqlConnection myConn = new SqlConnection(DBConnect))
//{
//    using (SqlCommand cmd = new SqlCommand("Select * From ThreadReplies WHERE threadId= ORDER BY Id", myConn))
//    {
//        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//        {
//            DataTable allThreads = new DataTable();
//            sda.Fill(allThreads);
//            rptrComments.DataSource = allThreads;
//            rptrComments.DataBind();
//        }
//    }
//}
