<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPGallery.aspx.cs" Inherits="FinalProj.PPGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .modal-img {
            width: 500px;
            margin: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <%--<ul class="list-group" style="border-bottom: 1px solid rgba(0,0,0,.125); display: flex; flex-direction: row;">
        <li class="list-inline-item">
            <button type="button" class="btn" data-toggle="modal" data-target="#uploadPicture">Upload</button>
        </li>
    </ul>--%>
    <div id="noPic" runat="server" style="padding-top:250px;" class="text-center mx-0">
        <p style="font-size: 20px;" class="font-italic text-muted">Looks like you don't have any pictures uploaded :(</p>
        <button style="width:50px; height:50px;" type="button" class="btn btn-success" data-toggle="modal" data-target="#uploadPicture">
           <i style="font-size:20px;" class="fas fa-plus"></i>
        </button>
    </div>
    <div class="modal fade" id="uploadPicture" tabindex="-1" role="dialog" aria-labelledby="uploadPictureLabel" aria-hidden="true">
        <div class="modal-dialog modal-img" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="uploadPictureLabel">Upload a picture</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="text-center form-group">
                        <asp:Image Style="width: 466px; height: 466px;" CssClass="bg-secondary img text-center" ID="imgPic" runat="server"/>
                        <div class="form-control">
                            <asp:FileUpload ID="fuPic" runat="server" accept=".png,.jpg,.jpeg" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox type="text" PlaceHolder="Add a caption" CssClass="form-control" ID="tbName" runat="server" CausesValidation="True"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control" ID="ddlEvents" runat="server"></asp:DropDownList>
                        <%--<select id="inputState" class="form-control">
                            <option selected>Link Event</option>
                            <option>...</option>
                        </select>--%>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-success">Upload</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
