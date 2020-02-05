<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="VoucherRedemption.aspx.cs" Inherits="FinalProj.VoucherRedemption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Voucher.css" />

    <script type="text/javascript">
        function btnClick() {
            var uri = window.location.toString();
            if (uri.indexOf("?") > 0) {
                var clean_uri = uri.substring(0, uri.indexOf("?"));
                window.history.replaceState({}, document.title, clean_uri);
            }
            
        }

        function AlertBad() {
            document.getElementById("redirected").innerText = "Too little points!";
            document.getElementById("redirect").style.visibility = "visible";
        }

        function AlertOkay() {
            document.getElementById("redirect").style.visibility = "visible";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 100%">
        <h2 id="title">Voucher Redemption</h2>
        <div id="pointDiv">
            <h3>Your points: </h3>
            <h3 id="numPoints"><%=points %></h3>
        </div>

        <div id="redirect" style="visibility:hidden;">
            <h1 id="redirected">Successfully redeemed your voucher!</h1>
            <button id="btnOk" onclick="btnClick(), window.location.reload()">Okay</button>
        </div>

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
                    <a id="btnRedeem" href="/VoucherRedemption.aspx?voucherId=<%=element.VoucherId %>" class="btn btn-primary">Costs: <%= element.VoucherPoints %>&rarr;</a>
                </td>
            </tr>
        </table>
        <% } %>

        <a href="AddVoucher.aspx" id="AddVouchers">Add Vouchers</a>

    </div>
</asp:Content>
