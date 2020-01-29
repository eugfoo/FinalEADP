using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProj
{

    public partial class editForumPost : System.Web.UI.Page
    {
        public string threadImage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["threadid"] != null)
                {
                    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                    string myQuery = "Select * From Threads where Id=" + Request.QueryString["threadid"].ToString();
                    SqlConnection myConn = new SqlConnection(DBConnect);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myQuery;
                    cmd.Connection = myConn;

                    cmd.Parameters.AddWithValue("@ThreadId", Request.QueryString["threadid"]);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Session["LblPrefix"].ToString() == "[Discussion]")
                        {
                            DdlPrefix.SelectedIndex = 1;
                        }
                        if (Session["LblPrefix"].ToString() == "[Info]")
                        {
                            DdlPrefix.SelectedIndex = 2;
                        }
                        if (Session["LblPrefix"].ToString() == "[News]")
                        {
                            DdlPrefix.SelectedIndex = 3;
                        }
                        if (Session["LblPrefix"].ToString() == "[Help]")
                        {
                            DdlPrefix.SelectedIndex = 4;
                        }
                        if (Session["LblPrefix"].ToString() == "[Request]")
                        {
                            DdlPrefix.SelectedIndex = 1;
                        }

                        tbTitle.Text = ds.Tables[0].Rows[0]["threadTitle"].ToString();
                        tbContent.Text = ds.Tables[0].Rows[0]["threadContent"].ToString();
                        //LblTitleBreadcrumb.Text = ds.Tables[0].Rows[0]["threadTitle"].ToString();
                        //LblPostDate.Text = ds.Tables[0].Rows[0]["threadDate"].ToString();
                        //LblPrefix.Text = ds.Tables[0].Rows[0]["threadPrefix"].ToString();




                        HFthreadId.Value = ds.Tables[0].Rows[0]["Id"].ToString();


                        if (ds.Tables[0].Rows[0]["threadImage1"].ToString() == "")
                        {
                            Image1.Style.Add("display", "none");

                        }
                        else
                        {
                            Image1.ImageUrl = "~/Img/" + ds.Tables[0].Rows[0]["threadImage1"].ToString();
                            Image1.Style.Add("display", "block");
                        }

                        if (ds.Tables[0].Rows[0]["threadImage2"].ToString() == "")
                        {
                            Image2.Style.Add("display", "none");

                        }
                        else
                        {
                            Image2.ImageUrl = "~/Img/" + ds.Tables[0].Rows[0]["threadImage2"].ToString();
                            Image2.Style.Add("display", "block");
                        }

                        if (ds.Tables[0].Rows[0]["threadImage3"].ToString() == "")
                        {
                            Image3.Style.Add("display", "none");

                        }
                        else
                        {
                            Image3.ImageUrl = "~/Img/" + ds.Tables[0].Rows[0]["threadImage3"].ToString();
                            Image3.Style.Add("display", "block");
                        }

                        if (ds.Tables[0].Rows[0]["threadImage4"].ToString() == "")
                        {
                            Image4.Style.Add("display", "none");

                        }
                        else
                        {
                            Image4.ImageUrl = "~/Img/" + ds.Tables[0].Rows[0]["threadImage4"].ToString();
                            Image4.Style.Add("display", "block");
                        }


                    }
                    myConn.Close();



                }

            }
        }

        private bool ValidateInput()
        {
            LblMsg.Text = String.Empty;

            if (DdlPrefix.SelectedIndex == 0)
            {
                LblMsg.Text += "Please Select a Prefix! <br/>";
                LblMsg.ForeColor = Color.Red;
            }

            if (tbTitle.Text == "")
            {
                LblMsg.Text += "Title is required! <br/>";
                LblMsg.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(tbContent.Text))
            {
                LblMsg.Text += "Please fill in the content! <br/>";
                LblMsg.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(LblMsg.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void queryCreatedThreadId()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            myConn.Open();
            SqlCommand cmd = new SqlCommand("Select Max(Id) From Threads", myConn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            myConn.Close();

            HFthreadId.Value = i.ToString();
        }

        private string BadgeColorIdentifier()
        {
            string badgeColorClass = "";
            if (DdlPrefix.SelectedIndex == 1)
            {
                badgeColorClass = "warning";
            }
            else if (DdlPrefix.SelectedIndex == 2)
            {
                badgeColorClass = "info";
            }
            else if (DdlPrefix.SelectedIndex == 3)
            {
                badgeColorClass = "primary";
            }
            else if (DdlPrefix.SelectedIndex == 4)
            {
                badgeColorClass = "danger";
            }
            else if (DdlPrefix.SelectedIndex == 5)
            {
                badgeColorClass = "secondary";
            }

            return badgeColorClass;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread();
            string firstImage = "";
            string secondImage = "";
            string thirdImage = "";
            string fourthImage = "";

            if (ValidateInput())
            {

                DateTime now = DateTime.Now;
                HFDate.Value = now.ToString("g");
                DateTime mDate = Convert.ToDateTime(HFDate.Value);


                thread = new Thread(DdlPrefix.Text, BadgeColorIdentifier(), tbTitle.Text, HFDate.Value,
                    firstImage, secondImage, thirdImage, fourthImage,
                    tbContent.Text, "1", "Gundy");

                int result = thread.UpdateThread(Convert.ToInt32(HFthreadId.Value));

                if (result == 1)
                {
                    //queryCreatedThreadId();
                    Response.Redirect("forumPost.aspx?threadid=" + HFthreadId.Value);
                }
            }
        }
    }

}