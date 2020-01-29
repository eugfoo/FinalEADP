<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="AddVoucher.aspx.cs" Inherits="FinalProj.AddVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="AddVoucher.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 86vh">
        <asp:Panel ID="PanelError" Visible="false" CssClass="stuff alert alert-danger" runat="server">
            <asp:Label ID="errmsgTb" runat="server"></asp:Label>
        </asp:Panel>
        <h2 id="title">Add Vouchers (Admin)</h2>
        <div class="container" id="formContainer">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-6">
                    <label for="voucherName">Voucher Name: </label>
                    <asp:TextBox ID="voucherName" CssClass="form-control" placeholder="FoodPanda $15 off" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-6">
                    <label for="voucherAmt">Voucher Amount: </label>
                    <asp:TextBox ID="voucherAmt" CssClass="form-control" placeholder="15" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-6">
                    <label for="voucherName">Voucher Picture: </label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
        </div>
        <asp:Button ID="createBtn" runat="server" Text="Add" OnClick="createBtn_Click"/>
    </div>
</asp:Content>