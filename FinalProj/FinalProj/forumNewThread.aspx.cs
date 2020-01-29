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
    public partial class forumNewThread : System.Web.UI.Page
    {
        public string threadImage = "";
        List<string> uploadedImgNames = new List<string>();

        List<string> imagesNames
        {
            get
            {
                return (List<string>)Session["imgName"];
            }
            set { Session["imgName"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (imagesNames == null)
            {
                imagesNames = new List<string>();
            }

            DirectoryInfo d = new DirectoryInfo(MapPath("~/Img/"));
            FileInfo[] r = d.GetFiles();

            foreach (var imgName in imagesNames)
            {
                for (int i = 0; i < r.Length; i++)
                {
                    if (imgName == r[i].Name)
                    {
                        uploadedImgNames.Add(imgName);
                    }

                }

            }
        }

        private void show_data()
        {
            DirectoryInfo d = new DirectoryInfo(MapPath("~/Img/"));
            FileInfo[] r = d.GetFiles();

            DataTable dt = new DataTable();
            dt.Columns.Add("path");


            foreach (var imgName in imagesNames)
            {
                DataRow row = dt.NewRow();

                for (int i = 0; i < r.Length; i++)
                {
                    if (imgName == r[i].Name)
                    {
                        uploadedImgNames.Add(imgName);

                        row["path"] = "~/Img/" + uploadedImgNames.Last();
                        dt.Rows.Add(row);
                    }

                }
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();



        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileImgSave.HasFile)
            {
                string filename = Path.GetFileName(FileImgSave.PostedFile.FileName);

                if (uploadedImgNames.Contains(filename))
                {
                    LblMsg.Text = "fk off";
                }
                else
                {
                    if (DataList1.Items.Count < 4)
                    {
                        FileImgSave.SaveAs(Server.MapPath("~/Img/" + filename));
                        threadImage = filename;
                        imagesNames.Add(filename);

                        show_data();
                    }
                    else
                    {
                        LblMsg.Text = "sorry no more pictures for you bitch!";
                    }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread();
            string firstImage = "";
            string secondImage = "";
            string thirdImage = "";
            string fourthImage = "";

            //string threadImage = "";

            //if (FileImgSave.HasFile)
            //{
            //    string filename = Path.GetFileName(FileImgSave.PostedFile.FileName);
            //    FileImgSave.SaveAs(Server.MapPath("~/Img/" + filename));
            //    threadImage = filename;
            //}


            if (ValidateInput())
            {


                DateTime now = DateTime.Now;
                HFDate.Value = now.ToString("g");
                DateTime mDate = Convert.ToDateTime(HFDate.Value);



                if (uploadedImgNames.Count == 1)
                {
                    firstImage = uploadedImgNames[0];
                }
                else if (uploadedImgNames.Count == 2)
                {
                    firstImage = uploadedImgNames[0];
                    secondImage = uploadedImgNames[1];
                }
                else if (uploadedImgNames.Count == 3)
                {
                    firstImage = uploadedImgNames[0];
                    secondImage = uploadedImgNames[1];
                    thirdImage = uploadedImgNames[2];
                }
                else if (uploadedImgNames.Count == 4)
                {
                    firstImage = uploadedImgNames[0];
                    secondImage = uploadedImgNames[1];
                    thirdImage = uploadedImgNames[2];
                    fourthImage = uploadedImgNames[3];
                }






                thread = new Thread(DdlPrefix.Text, BadgeColorIdentifier(), tbTitle.Text, HFDate.Value,
                    firstImage, secondImage, thirdImage, fourthImage,
                    tbContent.Text, "1", "Gundy");

                int result = thread.CreateThread();

                if (result == 1)
                {
                    queryCreatedThreadId();
                    Response.Redirect("forumPost.aspx?threadid=" + HFthreadId.Value);
                }
            }

        }


        protected void LKDelete_Command(object sender, CommandEventArgs e)
        {
            File.Delete(MapPath(e.CommandArgument.ToString()));
            imagesNames.Remove(e.CommandArgument.ToString());
            uploadedImgNames.Remove(e.CommandArgument.ToString());

            show_data();
        }
    }
}