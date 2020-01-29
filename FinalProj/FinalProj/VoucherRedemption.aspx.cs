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

        protected void Page_Load(object sender, EventArgs e)
        {
            Voucher vcher = new Voucher();
            vcherList = vcher.GetAllVouchersByName();

        }

    }
}
