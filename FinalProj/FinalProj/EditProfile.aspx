<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="FinalProj.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-5 row" style="">
        <div style="max-width: 600px; margin: auto; margin-top: 3rem;" class="p-0 card col-6">
            <div class="card-header text-center">
                Edit Profile
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="formGroupExampleInput">Background Picture</label>
                    <%--<asp:RequiredFieldValidator CssClass="vError" ID="RequiredFieldValidator1" runat="server" ControlToValidate="" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    <br />
                    <asp:Image ID="imgBP" CssClass="card-img-top" Style="max-height: 100px; max-width: 1100px; min-height: 100px; min-width: 150px;" runat="server" />
                    <div class="form-control">
                        <asp:FileUpload CssClass="col-md-8" ID="fuBP" runat="server" accept=".png,.jpg,.jpeg" />
                        <asp:Button ID="btnUploadBP" runat="server" Text="Upload" OnClick="btnUploadBP_Click" UseSubmitBehavior="False" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="formGroupExampleInput">Display Picture</label>
                    <%--<asp:RequiredFieldValidator CssClass="vError" ID="RequiredFieldValidator4" runat="server" ControlToValidate="" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    <br />
                    <asp:Image ID="imgDP" CssClass="card-img-top" Style="max-width: 100px; max-height: 100px; min-height: 100px; min-width: 100px;" runat="server" />
                    <div class="form-control">
                        <asp:FileUpload CssClass="col-md-8" ID="fuDP" runat="server" accept=".png,.jpg,.jpeg" />
                        <asp:Button ID="btnUploadDP" runat="server" Text="Upload" OnClick="btnUploadDP_Click" UseSubmitBehavior="False" />
                    </div>
                </div>
                <div class="dropdown-divider"></div>
                <div class="form-group">
                    <label for="formGroupExampleInput2">Name</label>
                    <asp:RequiredFieldValidator CssClass="vError" ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbName" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox type="text" CssClass="form-control" ID="tbName" runat="server" CausesValidation="True"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="formGroupExampleInput2">Description</label>
                    <asp:RequiredFieldValidator CssClass="vError" ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDesc" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:TextBox type="text" CssClass="form-control" ID="tbDesc" runat="server" CausesValidation="True"></asp:TextBox>
                </div>
                <div class="dropdown-divider"></div>
                <div class="form-group">
                    <label>Dietary Requirements:</label>
                    <asp:DropDownList ID="ddlDiet" runat="server">
                        <asp:ListItem Selected="True" Value="none">None</asp:ListItem>
                        <asp:ListItem Value="halal">Halal</asp:ListItem>
                        <asp:ListItem Value="vegetarian">Vegatarian</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="exampleFormControlTextarea1">If your option is not in the list, please specify:</label>
                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                </div>
                <div class="align-bottom" style="text-align: right;">
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger mr-3" Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" UseSubmitBehavior="False" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </div>
        <div style="max-width: 600px; margin: auto; margin-top: 3rem;" class="p-0 card col-6">
            <div class="card-header text-center">
                Social Media
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="formGroupExampleInput2">Connect your Social Media</label>
                    <%--<asp:RequiredFieldValidator CssClass="vError" ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox4" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    <div class="input-group mb-2">
                        <div style="min-width:140px;"class="input-group-prepend">
                            <div style="min-width:inherit;" class="input-group-text">facebook.com/</div>
                        </div>
                        <asp:TextBox type="text" CssClass="form-control" ID="TextBox4" runat="server" CausesValidation="False"></asp:TextBox>
                    </div>
                    <div class="input-group mb-2">
                        <div style="min-width:140px;"class="input-group-prepend">
                            <div style="min-width:inherit;" class="input-group-text">instagram.com/</div>
                        </div>
                        <asp:TextBox type="text" CssClass="form-control" ID="TextBox1" runat="server" CausesValidation="False"></asp:TextBox>
                    </div>
                    <div class="input-group mb-2">
                        <div style="min-width:140px;"class="input-group-prepend">
                            <div style="min-width:inherit;" class="input-group-text">twitter.com/</div>
                        </div>
                        <asp:TextBox type="text" CssClass="form-control" ID="TextBox2" runat="server" CausesValidation="False"></asp:TextBox>
                    </div>
                </div>
                <%--<div class="align-bottom" style="text-align: right;">
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger mr-3" Text="Cancel" UseSubmitBehavior="False" OnClick="btnCancel_Click" />
                    <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Text="Update" UseSubmitBehavior="False" OnClick="btnUpdate_Click" />
                </div>--%>
            </div>
        </div>

    </div>
</asp:Content>
