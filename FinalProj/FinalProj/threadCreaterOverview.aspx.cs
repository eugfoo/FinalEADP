using FinalProj.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProj
{
    public partial class threadCreaterOverview : System.Web.UI.Page
    {
        protected Users currentThreadUser;
        //repeater control replacement
        protected List<Thread> allthreadsList;
        protected List<ThreadReply> allthreadReplies;
        protected Dictionary<int, int> threadIdReplies = new Dictionary<int, int>();
        protected Dictionary<int, string> threadIdUserIdReplies = new Dictionary<int, string>();
        protected Dictionary<int, string> threadIdLastReplyDateT = new Dictionary<int, string>();
        
        Thread thread = new Thread();
        ThreadReply threadReply = new ThreadReply();

        public class Threads
        {
            public int Id { get; set; }
            public string threadPrefix { get; set; }
            public string threadBadgeColor { get; set; }
            public string threadTitle { get; set; }
            public string threadDate { get; set; }
            public string threadImage1 { get; set; }
            public string threadImage2 { get; set; }
            public string threadImage3 { get; set; }
            public string threadImage4 { get; set; }
            public string threadContent { get; set; }
            public int user_id { get; set; }
            public string user_name { get; set; }
            public string lastReplyUserName { get; set; }

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Request.QueryString["userId"];

           

            if (userId != null)
            {
                Users usr = new Users();
                currentThreadUser = usr.GetUserById(int.Parse(userId));
                allthreadsList = thread.getThreadByUserId(int.Parse(userId));


                List<Threads> threadsList = new List<Threads>();

                foreach (Thread thread in allthreadsList)
                {
                    threadsList.Add(
                        new Threads
                        {
                            Id = thread.Id,
                            threadPrefix = thread.Prefix,
                            threadBadgeColor = thread.BadgeColor,
                            threadTitle = thread.Title,
                            threadDate = thread.Date,
                            threadImage1 = thread.ThreadImage1,
                            threadImage2 = thread.ThreadImage2,
                            threadImage3 = thread.ThreadImage3,
                            threadImage4 = thread.ThreadImage4,
                            threadContent = thread.Content,
                            user_id = thread.UserId,
                            user_name = thread.UserName
                        }
                    );


                    threadIdReplies.Add(thread.Id, threadReply.getAllThreadRepliesByThreadId(thread.Id).Count());


                    string lastReplierName = "";
                    string lastReplierDate = "";
                    if (threadReply.getMaxUserReplyIdByThreadId(thread.Id) != null)
                    {
                        lastReplierName = threadReply.getLastPersonReplyByMaxId(threadReply.getMaxUserReplyIdByThreadId(thread.Id).trId).UserName;
                        lastReplierDate = threadReply.getLastPersonReplyByMaxId(threadReply.getMaxUserReplyIdByThreadId(thread.Id).trId).PostDate;
                    }
                    else
                    {
                        lastReplierName = "No Replies";
                        lastReplierDate = "-";
                    }

                    threadIdUserIdReplies.Add(thread.Id, lastReplierName);
                    threadIdLastReplyDateT.Add(thread.Id, lastReplierDate);


                }



                this.rptrThreads.DataSource = threadsList;
                this.rptrThreads.DataBind();

            }


        //string userId = Request.QueryString["userId"];
        //    Thread thread = new Thread();
        //    Users usr = new Users();
        //    rptrThreads.DataSource = thread.getThreadByUserId(int.Parse(userId));
        //    rptrThreads.DataBind();

        //    currentThreadUser = usr.GetUserById(int.Parse(userId));

        }
    }
}