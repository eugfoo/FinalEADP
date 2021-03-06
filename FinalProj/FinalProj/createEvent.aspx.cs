﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;


namespace FinalProj
{
    public partial class Personal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) // A user has signed in
            {
                Response.Redirect("/homepage.aspx");
            }

        }



        protected void changetoDefaultBorder()
        {
            eventTitle.BorderColor = System.Drawing.Color.LightGray;
            eventAddress.BorderColor = System.Drawing.Color.LightGray;
            eventDate.BorderColor = System.Drawing.Color.LightGray;
            startTime.BorderColor = System.Drawing.Color.LightGray;
            endTime.BorderColor = System.Drawing.Color.LightGray;
            maxAttend.BorderColor = System.Drawing.Color.LightGray;
            FileUploadControl.BackColor = System.Drawing.Color.White;
            desc.BorderColor = System.Drawing.Color.LightGray;

        }
        protected void createBtn_Click(object sender, EventArgs e)
        {
            changetoDefaultBorder();

            Events ev = new Events();
            string errmsg = "";
            PanelError.Visible = false;

            if (eventTitle.Text.ToString() == "")
            {
                errmsg = "Title cannot be empty! <br>";
                eventTitle.BorderColor = System.Drawing.Color.Red;

            }
            if (eventAddress.Text.ToString() == "")
            {
                errmsg += "Address cannot be empty! <br>";
                eventAddress.BorderColor = System.Drawing.Color.Red;
            }
            if (eventDate.Text.ToString() == "")
            {
                errmsg += "Date cannot be empty! <br>";
                eventDate.BorderColor = System.Drawing.Color.Red;
            }
            if (eventDate.Text.ToString() != "")
            {
                string date = eventDate.Text.ToString();
                DateTime dt = Convert.ToDateTime(date);
                if (dt < DateTime.Now.Date)
                {
                    errmsg += "Please enter a valid date <br>";
                    eventDate.BorderColor = System.Drawing.Color.Red;
                }

            }
            if (startTime.Text.ToString() == "")
            {
                errmsg += "StartTime cannot be empty! <br>";
                startTime.BorderColor = System.Drawing.Color.Red;
            }
            if (endTime.Text.ToString() == "")
            {
                errmsg += "EndTime cannot be empty! <br>";
                endTime.BorderColor = System.Drawing.Color.Red;
            }
            if (startTime.Text.ToString() != "" && endTime.Text.ToString() != "")
            {
                string startTimeNumber = "";
                string endTimeNumber = "";
                string eventStartTime = startTime.Text.ToString();
                string eventEndTime = endTime.Text.ToString();
                string startFrontdigits = eventStartTime.Substring(0, 2);
                string endFrontdigits = eventEndTime.Substring(0, 2);
                string startBackdigits = eventStartTime.Substring(3, 2);
                string endBackdigits = eventEndTime.Substring(3, 2);
                startTimeNumber = startFrontdigits + startBackdigits;
                endTimeNumber = endFrontdigits + endBackdigits;

                if (int.Parse(startTimeNumber) > int.Parse(endTimeNumber))
                {
                    errmsg += "Please ensure that you entered a valid Start & End Time <br>";
                    startTime.BorderColor = System.Drawing.Color.Red;
                    endTime.BorderColor = System.Drawing.Color.Red;
                }

                if ((int.Parse(endTimeNumber) - int.Parse(startTimeNumber)) < 100)
                {
                    errmsg += "Duration must be 1 hour bare minimum";
                    startTime.BorderColor = System.Drawing.Color.Red;
                    endTime.BorderColor = System.Drawing.Color.Red;
                }
            }

            if (DateTime.Parse(eventDate.Text.ToString() + " " + startTime.Text.ToString()) <= DateTime.Now)
            {
                errmsg += "Please ensure that you entered a valid Start Time";
                startTime.BorderColor = System.Drawing.Color.Red;
            }
            if (maxAttend.Text.ToString() == "")
            {
                errmsg += "Maximum number of attendees cannot be empty! <br>";
                maxAttend.BorderColor = System.Drawing.Color.Red;
            }
            if (desc.Text.ToString() == "")
            {
                errmsg += "Description cannot be empty! <br>";
                desc.BorderColor = System.Drawing.Color.Red;
            }

            if (desc.Text.ToString() != "")
            {
                int enterCount = 0, index = 0;

                while (index < desc.Text.Length)
                {
                    // check if current char is part of a word
                    if (desc.Text[index] == '\r' && desc.Text[index + 1] == '\n')
                        enterCount++;
                    index++;
                }
                if (desc.Text.Length > 3000 + enterCount)
                {
                    errmsg += "Character Limit in Description Exceeded! <br>";
                    desc.BorderColor = System.Drawing.Color.Red;
                }
            }

            if (errmsg != "")
            {
                errmsgTb.Text = errmsg;
                PanelError.Visible = true;

            }
            else
            {
                Users user = (Users)Session["user"];
                string eventStartTime = startTime.Text.ToString();
                string eventEndTime = endTime.Text.ToString();
                string title = eventTitle.Text.ToString();
                string venue = eventAddress.Text.ToString();
                string date = eventDate.Text.ToString();
                int maxAttendees = int.Parse(maxAttend.Text.ToString());
                string description = desc.Text.ToString();
                string picture = "";
                string note = noteText.Text.ToString();
                int user_id = user.id;

                Thread thread = new Thread();
                DateTime now = DateTime.Now;
                string andyDate = now.ToString("g");

        
				
                if (FileUploadControl.HasFile)
                {
					

                    string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/Img/" + filename));
                    picture = filename;
                    picChosen.Text = filename;

                }
                else if (FileUploadControl.HasFile == false)
                {

                    string filename = "defaultPic.jpg";
                    picture = filename;

                }

                int rating = 0;

                ev = new Events(1, title, venue, date, eventStartTime, eventEndTime, maxAttendees, description, picture, note, rating, user_id);
                int result = ev.AddEvent();

                int createdEventId = ev.getMaxEventId();
                thread = new Thread(createdEventId, "[EVENT]", "success", title, andyDate, picture,
                    description, user_id, user.name);

                
                int resultThread = thread.createThreadForEvent();
                Response.Redirect("/eventDetails.aspx");
            }
        }

		protected void testBtn_Click(object sender, EventArgs e)
		{
			eventTitle.Text = "Project Eco";
			eventAddress.Text = "Tampines Mall";
			eventDate.Text = "2020-02-10";
			startTime.Text = "09:00";
			endTime.Text = "10:00";
			maxAttend.Text = "20";
			desc.Text = "This is a short description";
			noteText.Text = "Be ecofriendly";
		}
	}
}