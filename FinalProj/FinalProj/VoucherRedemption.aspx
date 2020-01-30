<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="VoucherRedemption.aspx.cs" Inherits="FinalProj.VoucherRedemption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Voucher.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 100%">
        <h2 id="title">Voucher Redemption</h2>

        <%foreach (var element in vcherList)
                { %>
        <table id="voucherTable">
            
            <tr id="voucherRow">
                <td>
                    <img id="voucherImg" src="/Img/<%=element.VoucherPic %>"/>
                </td>
                <td id="tdRepeat">
                    <p id="voucherName"><%=element.VoucherName %></p>
                    <p id="voucherAmount">$<%=element.VoucherAmount %></p>
                    <input id="redeemBtn" type="button" onclick="location.href='http://localhost:60329/PPPoints.aspx';" value="Redeem" />
                </td>
            </tr>
        </table>
        <% } %>

        <a href="AddVoucher.aspx" id="AddVouchers">Add Vouchers</a>

    </div>
</asp:Content>
