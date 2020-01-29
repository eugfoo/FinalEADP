using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DAL;

namespace FinalProj.BLL
{
    public class Users
    {
        public int id { get; set; }
        public string email { get; set; }
        public string passHash { get; set; }
        public string name { get; set; }
        public string DPimage { get; set; }
        public string BPimage { get; set; }
        public string desc { get; set; }
        public string participate { get; set; }
        public int rating { get; set; }
        public string isOrg { get; set; }
        public int points { get; set; }
        public int verified { get; set; }
        public DateTime regDate { get; set; }


        public Users(){}

        public Users(string uEmail, string uName, string uIsOrg, string uPassHash, DateTime uRegDate)
        {
            name = uName;
            email = uEmail;
            isOrg = uIsOrg;
            passHash = uPassHash;
            regDate = uRegDate;
        }

        public Users(int uId, string uEmail, string uPassHash, string uName, string uDPImage, string uBPImage,
            string uDesc, int uRating, string uIsOrg, int uPoints, string uParticipate, int uVerified, DateTime uRegDate)
        {
            id = uId;
            email = uEmail;
            passHash = uPassHash;
            name = uName;
            DPimage = uDPImage;
            BPimage = uBPImage;
            desc = uDesc;
            rating = uRating;
            isOrg = uIsOrg;
            points = uPoints;
            participate = uParticipate;
            verified = uVerified;
            regDate = uRegDate;
        }

        public int AddUser()
        {
            userDAO user = new userDAO();
            int result = user.Insert(this);
            return result;
        }

        public Users GetUserByEmail(string email)
        {
            userDAO user = new userDAO();
            return user.SelectByEmail(email);
        }

        public int UpdateNameByID(int id, string name)
        {
            userDAO user = new userDAO();
            return user.UpdateName(id, name);
        }

        public int UpdateDescByID(int id, string desc)
        {
            userDAO user = new userDAO();
            return user.UpdateDesc(id, desc);
        }

        public int UpdateDPByID(int id, string DP)
        {
            userDAO user = new userDAO();
            return user.UpdateDP(id, DP);
        }

        public int UpdateBPByID(int id, string BP)
        {
            userDAO user = new userDAO();
            return user.UpdateBP(id, BP);
        }
    }
}