using FinalProj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.BLL
{
    public class ThreadReply
    {
        public string ThreadId { get; set; }
        public string PostDate { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }

        public ThreadReply()
        {

        }

        public ThreadReply(string threadId, string postDate, string postContent, string userId)
        {
            ThreadId = threadId;
            PostDate = postDate;
            PostContent = postContent;
            UserId = userId;
        }

        public int ReplyThread()
        {
            ThreadReplyDAO dao = new ThreadReplyDAO();
            int result = dao.Insert(this);
            return result;
        }
    }
}

   