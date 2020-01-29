<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPPoints.aspx.cs" Inherits="FinalProj.PPPoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <ul class="list-group" style="border-bottom: 1px solid rgba(0,0,0,.125); display: flex; flex-direction: row;">
        <li class="list-inline-item"><a class="btn bg-light text-dark" href="/VoucherRedemption.aspx">Redeem Vouchers</a></li>
    </ul>
    <br>
    <div class="container">
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row ">
            <div style="width: 100%;" class="row mx-0">
                <p style="margin-bottom: 0px">Points: <span style="color: darkcyan">25</span>P</p>
            </div>
        </div>
        <br>
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row ">
            <div style="width: 100%; border-bottom: 1px solid lightgray;" class="row mx-0 pb-2">
                Redeemed Vouchers 
            </div>
            <table class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th scope="col">Voucher Name</th>
                        <th scope="col">Quantity</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">Food Panda S$17 Coupon</th>
                        <td>6</td>
                    </tr>
                    <tr>
                        <th scope="row">Best Buys S$10 Coupon</th>
                        <td>2</td>
                    </tr>
                    <tr>
                        <th scope="row">Grav S$6 Coupon</th>
                        <td>4</td>
                    </tr>
                    <tr>
                        <th scope="row">Food S$1 Coupon</th>
                        <td>1</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
