﻿using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProj
{
    public partial class eventFeedback : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) // A user has signed in
            {
                Response.Redirect("/homepage.aspx");
            }

            int queriedEventId = Convert.ToInt32(Request.QueryString["eventId"]);
            Events events = new Events();

            Events selectedEvent = events.getEventDetails(queriedEventId);
            LblEventTitle.Text = selectedEvent.Title;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Feedback feedback = new Feedback();
                Events events = new Events();

                string errorMsg = string.Empty;
                int eventId = Convert.ToInt32(Request.QueryString["eventId"]);
                int userId = events.getEventDetails(eventId).User_id;
                string Q1Ratings = Q1Rating.CurrentRating.ToString();
                string Q2Ratings = Q2Rating.CurrentRating.ToString();
                string Q3Ratings = Q3Rating.CurrentRating.ToString();
                string Q4Ratings = Q4Rating.CurrentRating.ToString();
                int avgRating = 96;
                string FeedbackContent = tbFeedbackContent.Text;

                if (Q1Rating.CurrentRating.ToString() == "0")
                {
                    errorMsg += "Not all questions are rated ,";

                }
                else if (Q2Rating.CurrentRating.ToString() == "0")
                {
                    errorMsg += "Not all questions are rated ,";
                }
                else if (Q3Rating.CurrentRating.ToString() == "0")
                {
                    errorMsg += "Not all questions are rated ,";
                }
                else if (Q4Rating.CurrentRating.ToString() == "0")
                {
                    errorMsg += "Not all questions are rated ,";
                }


                //avgRating = (Int32.Parse("Q1Ratings") + Int32.Parse("Q2Ratings") + Int32.Parse("Q3Ratings") + Int32.Parse("Q4Ratings")) / 4;

                avgRating = (Convert.ToInt32(Q1Ratings) + Convert.ToInt32(Q2Ratings) + Convert.ToInt32(Q3Ratings) + Convert.ToInt32(Q4Ratings)) / 4;


                if (string.IsNullOrEmpty(tbFeedbackContent.Text))
                {
                    errorMsg += "Review field is empty";
                    tbFeedbackContent.Focus();
                }





                if (!string.IsNullOrEmpty(errorMsg))
                {
                    throw new Exception(errorMsg.TrimEnd(','));
                }
                else
                {
                    feedback = new Feedback(eventId, userId, avgRating, FeedbackContent, 1);

                    int result = feedback.createFeedback();

                    if (result == 1)
                    {
                        string script = "setTimeout(function() { swal ({ title: 'wow!', text: 'message!', type: 'success', confirmButtonText: 'OK'}, function(isConfirm) { if (isConfirm) { window.location.href = 'forumCatOverview.aspx'; } }); }, 1000);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                    }


                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "<script>swal('Error!', '" + ex.Message + "!', 'error')</script>");

            }

        }
    }
}