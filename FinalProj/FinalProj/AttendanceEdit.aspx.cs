using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;

namespace FinalProj
{
    public partial class AttendanceEdit : System.Web.UI.Page
    {
        protected List<Attendance> attendList;
        protected List<Users> attendUser = new List<Users>();
        public List<string> diet = new List<string>();
        public List<string> attending = new List<string>();
        public string title;
        public int participant = 0;
        public int participantHere = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["user"] == null || Session["eventTitle"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            else
            {
                Attendance attend = new Attendance();
                Users user = new Users();
                title = Session["eventTitle"].ToString();

                int id = int.Parse(Session["eventId"].ToString());
                attendList = attend.GetAttendanceEvent(id);
                for (int i = 0; i < attendList.Count; i++)
                {
                    // Total number of participants
                    participant += 1;

                    int userId = int.Parse(attendList[i].UserId.ToString());
                    attendUser.Add(user.GetUserById(userId)); // Get user's name and diet

                    if (attendUser[i].diet == "")
                    {
                        diet.Add("Unspecified");
                    }
                    else
                    {
                        diet.Add(user.GetUserById(userId).diet);
                    }

                    if (attendList[i].Attend == 0)
                    {
                        attending.Add("No");
                    }
                    else if (attendList[i].Attend == 1)
                    {
                        attending.Add("Yes");
                    }

                    // Count number of participants here already
                    if (int.Parse(attendList[i].Attend.ToString()) == 1)
                    {
                        participantHere += 1;
                    }

                }
            }
        }
    }
}