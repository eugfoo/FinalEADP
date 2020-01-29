using FinalProj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.BLL
{
    public class Thread
    {
        public string Prefix { get; set; }
        public string BadgeColor { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string ThreadImage1 { get; set; }
        public string ThreadImage2 { get; set; }
        public string ThreadImage3 { get; set; }
        public string ThreadImage4 { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public Thread()
        {

        }

        public Thread(string threadPrefix, string threadBadgeColor, string threadTitle, string threadDate
            , string Image1, string Image2, string Image3, string Image4
            , string threadContent
            , string userId, string userName)
        {
            Prefix = threadPrefix;
            BadgeColor = threadBadgeColor;
            Title = threadTitle;
            Date = threadDate;
            ThreadImage1 = Image1;
            ThreadImage2 = Image2;
            ThreadImage3 = Image3;
            ThreadImage4 = Image4;
            Content = threadContent;
            UserId = userId;
            UserName = userName;
        }

        public int CreateThread()
        {
            ThreadDAO dao = new ThreadDAO();
            int result = dao.Insert(this);
            return result;
        }

        public int UpdateThread(int id)
        {
            ThreadDAO dao = new ThreadDAO();
            int result = dao.Update(id, this);
            return result;
        }

        public Thread GetThreadByThreadId(string threadId)
        {
            ThreadDAO thread = new ThreadDAO();
            return thread.GetThreadByThreadId(threadId);
        }

        public int getMaxThreadId()
        {
            ThreadDAO dao = new ThreadDAO();
            int result = dao.queryCreatedThreadId();
            return result;
        }


    }


}