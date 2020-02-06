<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DAL;

namespace FinalProj.BLL
{
    public class VoucherRedeemed
    {
        // Define class properties
        public string VoucherName { get; set; }
        public string VoucherPic { get; set; }
        public string VoucherAmount { get; set; }
        public string UserId { get; set; }

        public VoucherRedeemed()
        {

        }

        // Define a constructor to initialize all properties
        public VoucherRedeemed(string voucherName, string voucherAmount, string voucherPic, string userId)
        {
            VoucherName = voucherName;
            VoucherPic = voucherPic;
            VoucherAmount = voucherAmount;
            UserId = userId;
        }

        public List<VoucherRedeemed> GetAllVouchersByName()
        {
            voucherRedeemDAO voucher = new voucherRedeemDAO();
            return voucher.SelectAllByName();
        }

        public int AddVoucher()
        {
            voucherRedeemDAO dao = new voucherRedeemDAO();
            int result = dao.Insert(this);
            return result;
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DAL;

namespace FinalProj.BLL
{
    public class VoucherRedeemed
    {
        // Define class properties
        public string VoucherName { get; set; }
        public string VoucherPic { get; set; }
        public string VoucherAmount { get; set; }
        public string UserId { get; set; }

        public VoucherRedeemed()
        {

        }

        // Define a constructor to initialize all properties
        public VoucherRedeemed(string voucherName, string voucherAmount, string voucherPic, string userId)
        {
            VoucherName = voucherName;
            VoucherPic = voucherPic;
            VoucherAmount = voucherAmount;
            UserId = userId;
        }

        public List<VoucherRedeemed> GetAllVouchersByName()
        {
            voucherRedeemDAO voucher = new voucherRedeemDAO();
            return voucher.SelectAllByName();
        }

        public int AddVoucher()
        {
            voucherRedeemDAO dao = new voucherRedeemDAO();
            int result = dao.Insert(this);
            return result;
        }
    }
>>>>>>> Stashed changes
}