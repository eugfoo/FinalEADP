using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DAL;

namespace FinalProj.BLL
{
    public class Voucher
    {
        // Define class properties
        public string VoucherName { get; set; }
        public string VoucherPic { get; set; }
        public string VoucherAmount { get; set; }

        public Voucher()
        {

        }

        // Define a constructor to initialize all properties
        public Voucher(string voucherName, string voucherAmount, string voucherPic)
        {
            VoucherName = voucherName;
            VoucherPic = voucherPic;
            VoucherAmount = voucherAmount;
        }

        public int AddVoucher()
        {
            voucherDAO dao = new voucherDAO();
            int result = dao.Insert(this);
            return result;
        }

        public List<Voucher> GetAllVouchersByName()
        {
            voucherDAO voucher = new voucherDAO();
            return voucher.SelectAllByName();
        }
    }
}