using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.BLL;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace FinalProj
{
    public partial class AddVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            Voucher vcher = new Voucher();
            string errmsg = "";
            PanelError.Visible = false;
            int num = -1;

            if (voucherName.Text == "")
            {   
                errmsg = errmsg + "Voucher Name cannot be empty! <br>";
                voucherName.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                voucherName.BorderColor = System.Drawing.Color.LightGray;
            }

            if (voucherAmt.Text == "" || !int.TryParse(voucherAmt.Text, out num))
            {
                errmsg = errmsg + "Voucher Amount must be an integer and cannot be empty! <br>";
                voucherAmt.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                voucherAmt.BorderColor = System.Drawing.Color.LightGray;
            }

            if (FileUpload1.HasFile == false)
            {
                errmsg = errmsg + "Select an image for voucher! <br>";
            }
            

            if (errmsg != "")
            {
                errmsgTb.Text = errmsg;
                PanelError.Visible = true;
            }
            
            else
            {
                string vcherName = voucherName.Text.ToString();
                string vcherAmt = voucherAmt.Text.ToString();
                string file = "";

                if (FileUpload1.HasFile)
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Img/" + filename));
                    file = filename;
                    
                }
               

                vcher = new Voucher(vcherName, vcherAmt, file);
                int result = vcher.AddVoucher();
                Response.Redirect("VoucherRedemption.aspx");
            } 
        }
    }
}
