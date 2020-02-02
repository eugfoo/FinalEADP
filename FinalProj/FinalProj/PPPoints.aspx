<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPPoints.aspx.cs" Inherits="FinalProj.PPPoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br>
    <div class="container">
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row text-center">
            <p class="" style="width: 100%; font-size: 20px; margin-bottom: 0px">
                Points:
                    <asp:Label ID="lblPoints" ForeColor="DarkCyan" runat="server"></asp:Label>P
            </p>
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
