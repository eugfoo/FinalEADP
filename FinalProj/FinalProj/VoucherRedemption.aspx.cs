using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FinalProj.BLL;

namespace FinalProj
{
    public partial class VoucherRedemption : System.Web.UI.Page
    {
        protected List<Voucher> vcherList;
        protected List<Voucher> vchers;
        public int points = 0;
        public List<decimal> pointCost = new List<decimal>();
        protected VoucherRedeemed vouchers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            else
            {
                if (Request.QueryString["voucherId"] == null) {
                    Voucher vcher = new Voucher();
                    vcherList = vcher.GetAllVouchersByName();
                    Users user = (Users)Session["user"];
                    points = user.points;
                }
                else
                {
                    Users user = (Users)Session["user"];
                    points = user.points;
                    Voucher vcher = new Voucher();
                    vcherList = vcher.GetAllVouchersByName();
                    VoucherRedeemed voucher = new VoucherRedeemed();
                    vchers = vcher.GetVoucherById(Request.QueryString["voucherId"]);

                    if (vchers != null)
                    {
                        foreach (var element in vchers)
                        {
                            if (points >= int.Parse(element.VoucherPoints))
                            {
                                voucher.VoucherAmount = element.VoucherAmount;
                                voucher.VoucherName = element.VoucherName;
                                voucher.VoucherPic = element.VoucherPic;
                                voucher.UserId = user.id.ToString();

                                voucher = new VoucherRedeemed(voucher.VoucherName, voucher.VoucherAmount, voucher.VoucherPic, voucher.UserId);
                                int result = voucher.AddVoucher();

                                user.points = user.points - int.Parse(element.VoucherPoints);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AlertBad();", true);
                            }
                            
                        }
                    }

                    
                }
            }
        }
    }
}
