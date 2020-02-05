using FinalProj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.BLL
{
    public class ThreadReply
    {
        public int ThreadId { get; set; }
        public string PostDate { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }

        public ThreadReply()
        {

        }

        public ThreadReply(int threadId, string postDate, string postContent, int userId)
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

   