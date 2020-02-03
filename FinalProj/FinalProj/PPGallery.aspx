<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPGallery.aspx.cs" ClientIDMode="Static" Inherits="FinalProj.PPGallery" %>

<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .modal-img {
            width: 500px;
            margin: auto;
        }
    </style>
    <script>
        function openModal() {
            $('#uploadPicture').modal('show');
            console.log("openModal works")
        };

        $(document).ready(function () {
            $("#fuPic").change(function (e) {
                console.log("This whole thing works")
                $("#btnDisplayPic").click();
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <% if (gpList == null)
        { %>
    <div id="noPic" runat="server" style="padding-top: 250px;" class="text-center mx-0">
        <p style="font-size: 20px;" class="font-italic text-muted">Looks like you don't have any pictures uploaded :(</p>
        <button id="openModal" runat="server" style="width: 50px; height: 50px;" type="button" class="btn btn-success" data-toggle="modal" data-target="#uploadPicture">
            <i style="font-size: 20px;" class="fas fa-plus"></i>
        </button>
    </div>
    <% }
        else
        { %>

    <div class="row mt-5">
        <button id="btnOpenModal" runat="server" style="width: 50px; height: 50px;" type="button" class="btn btn-success" data-toggle="modal" data-target="#uploadPicture">
            <i style="font-size: 20px;" class="fas fa-plus"></i>
        </button>

        <%for (int i = 0; i < gpList.Count; i++)
            {%>
        <img src="<%Response.Write(gpList[i].filepath);%>" style="width: 100px; height: 100px;" class="img text-left" />
        <%} %>
    </div>
    <%  } %>

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
                        <asp:Image Style="width: 466px; height: 466px;" CssClass="bg-secondary img text-center" ID="imgPic" runat="server" />
                        <div class="form-control">
                            <asp:FileUpload ID="fuPic" runat="server" accept=".png,.jpg,.jpeg" CssClass="fileUpload" />
                            <asp:Button Style="display: none;" ID="btnDisplayPic" runat="server" Text="Display" OnClick="btnDisplayPic_Click" CausesValidation="False" UseSubmitBehavior="False" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox type="text" PlaceHolder="Add a caption" CssClass="form-control" ID="tbCaption" runat="server" CausesValidation="True"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control" ID="ddlEvents" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnUpload" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnUpload_Click" CausesValidation="False" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
