﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;
using System.Text;
using System.Security.Cryptography;

namespace FinalProj
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (tbEmail.Text == "admin@admin")
                {
                    string adminPassHash = ComputeSha256Hash(tbPass.Text);
                    if (adminPassHash == "ca5ce9636699b4bfa0a3801e2c28842638c13f22e04820b586041a425ce665d9") // hashed version of adminPass41111
                    {
                        Session["admin"] = true;
                        Response.Redirect("homepage.aspx");
                    }
                }
                Users user = new Users();
                Users tryingUser = user.GetUserByEmail(tbEmail.Text);
                string passHash = ComputeSha256Hash(tbPass.Text);
                if (tryingUser != null) // user exists
                {
                    if (tryingUser.passHash == passHash)
                    {
                        Session["user"] = tryingUser;
                        Session["id"] = tryingUser.id;
                        Session["Name"] = tryingUser.name;
                        Session["Pic"] = tryingUser.DPimage;
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }

        public string ComputeSha256Hash(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}