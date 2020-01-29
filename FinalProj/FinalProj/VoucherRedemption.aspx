<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="VoucherRedemption.aspx.cs" Inherits="FinalProj.VoucherRedemption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Voucher.css" />
    <script>
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 86vh">
        <h2 id="title">Voucher Redemption</h2>
        <div class="container">
            <%foreach (var element in vcherList)
                { %>
            <div class="row">
                <img id="voucherImg" src="<%=element.VoucherPic %>" />
                <p id="voucherName"><%=element.VoucherName %></p>
                <p id="voucherAmount"><%=element.VoucherAmount %></p>
            </div>
            <% } %>
        </div>
        
        <div id="divButton">
            <a href="AddVoucher.aspx" id="AddVouchers">Add Vouchers</a>
        </div>
    </div>
</asp:Content>
