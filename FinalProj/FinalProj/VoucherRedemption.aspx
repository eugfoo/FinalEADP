<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="VoucherRedemption.aspx.cs" Inherits="FinalProj.VoucherRedemption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Voucher.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 250vh">
        <h2 id="title">Voucher Redemption</h2>

        <table id="voucherTable">
            <%foreach (var element in vcherList)
                { %>
            <tr id="voucherRow">
                <td>
                    <img id="voucherImg" src="<%=element.VoucherPic %>"/>
                </td>
                <td>
                    <p id="voucherName"><%=element.VoucherName %></p>
                    <p id="voucherAmount"><%=element.VoucherAmount %></p>
                    <button>Redeem</button>
                </td>
            </tr>
            <% } %>
        </table>
        
        <div id="divButton">
            <a href="AddVoucher.aspx" id="AddVouchers">Add Vouchers</a>
        </div>
    </div>
</asp:Content>
