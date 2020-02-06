<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPPoints.aspx.cs" Inherits="FinalProj.PPPoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br>
    <div class="container">
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row text-center">
            <p class="" style="width: 100%; font-size: 20px; margin-bottom: 0px">
                Points:
                    <asp:Label ID="lblPoints" ForeColor="DarkCyan" runat="server"></asp:Label>
            </p>
        </div>
        <br>
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row ">
            <div style=" width: 100%; border-bottom: 1px solid lightgray;" class="row mx-0 pb-2">
                <div style="font-size: 20px;" class="col-md-4 col-sm-7">
                    Redeemed Vouchers 
                </div>
                <div class="text-right col-md-8 col-sm-5">
                    <asp:LinkButton href="/VoucherRedemption.aspx" CssClass="btn btn-success" ID="lbRedeem" runat="server">Redeem <i class="fas fa-arrow-right"></i></asp:LinkButton>
                </div>
            </div>
            <% if (vRedList.Count > 0)
                {
                    %>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th scope="col">Voucher Name</th>
                        <th scope="col">Quantity</th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0; i < vRedList.Count; i++)
                                          {
                            %>
                    <tr>
                        <th scope="row"><%=vRedList[i].VoucherName%></th>
                        <td><%=vRedList[i].VoucherAmount %></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <% }
            else
            { %>
            <div style="font-size:16px;" class="m-3 font-italic text-muted text-center row">
                <div class="col-12">
                    No vouchers have been redeemed.
                </div>
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
