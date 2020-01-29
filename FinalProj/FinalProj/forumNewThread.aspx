﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="forumNewThread.aspx.cs" Inherits="FinalProj.forumNewThread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 90vh;">
        <div class="container my-3">
            <nav class="breadcrumb">
                <a href="forumPage1.aspx" class="breadcrumb-item">Board index</a>
                <a href="forumCatOverview.aspx" class="breadcrumb-item">Forum Category</a>
                <span class="breadcrumb-item active">Create New Thread</span>
            </nav>
            <div class="row">
                <div class="col-12">
                    <div class="container">
                        <div class="row text-white bg-info mb-3 p-4 rounded">
                            <div class="col-md-9">
                                <h2 class="h4">Create New Thread</h2>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <label for="prefix">Prefix:</label>
                <asp:DropDownList ID="DdlPrefix" runat="server" CssClass="form-control">
                    <asp:ListItem>-- Select --</asp:ListItem>
                    <asp:ListItem>[Discussion]</asp:ListItem>
                    <asp:ListItem>[Info]</asp:ListItem>
                    <asp:ListItem>[News]</asp:ListItem>
                    <asp:ListItem>[Help]</asp:ListItem>
                    <asp:ListItem>[Request]</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="thread">Title</label>
                <asp:TextBox ID="tbTitle" runat="server" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                <label>Upload Image :</label>

                <asp:FileUpload ID="FileImgSave" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                <br />
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="4">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="250px" ImageUrl='<%# Eval("path") %>' Width="283px" BorderWidth="2px"/>
                        <br />
                        <asp:LinkButton ID="LKDelete" runat="server" Style="padding: 8px; margin: 110px; background: red; border: solid 1px #d5e3ed; color: white; font-weight: bold;"
                            CommandArgument='<%# Eval("path") %>' OnCommand="LKDelete_Command">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>
                <br />
            </div>

            <div class="form-group">
                <label for="comment">Content:ent:</label>
                <asp:TextBox ID="tbContent" runat="server" CssClass="form-control" Height="250px" TextMode="MultiLine"></asp:TextBox>
                <asp:HiddenField ID="HFDate" runat="server" />
                <asp:HiddenField ID="HFthreadId" runat="server" />

                <br />
                <%--<textarea class="form-control" id="comment" rows="10" placeholder="Write more about the event..." required></textarea>--%>
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />

            <button type="reset" class="btn btn-danger">Reset</button>
        </div>
    </div>

</asp:Content>
