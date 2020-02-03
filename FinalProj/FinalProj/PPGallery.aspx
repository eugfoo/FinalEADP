<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPGallery.aspx.cs" ClientIDMode="Static" Inherits="FinalProj.PPGallery" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="FinalProj.BLL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .modal-img {
            width: 500px;
            margin: auto;
        }

        .fas:hover {
            cursor: pointer;
        }

        .fas {
            transform: translateY(4%);
        }

        .gpic {
            padding: 5px;
            margin: 5px;
            border: 1px solid lightgray;
            transition: box-shadow 0.2s;
        }

            .gpic:hover {
                box-shadow: 5px 5px 5px #aaaaaa;
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
        {
            if (viewingUserId == null)
            {
    %>
    <div id="noPic" runat="server" style="padding-top: 250px;" class="text-center mx-0">
        <p style="font-size: 20px;" class="font-italic text-muted">Looks like you don't have any pictures uploaded :(</p>
        <button id="openModal" runat="server" style="width: 50px; height: 50px;" type="button" class="btn btn-success" data-toggle="modal" data-target="#uploadPicture">
            <i style="font-size: 20px;" class="fas fa-plus"></i>
        </button>
    </div>
    <%      }
        else
        { %>
    <div id="noPicViewing" runat="server" style="padding-top: 250px;" class="text-center mx-0">
        <p style="font-size: 20px;" class="font-italic text-muted">Looks like this user hasn't uploaded anything yet :(</p>
    </div>
    <%}
        }
        else
        { %>
    <br />
    <div class="container">
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row ">
            <%if (viewingUserId == null)
                { %>
            <div style="width: 100%; border-bottom: 1px solid lightgray;" class="row mx-0 mb-2 pb-2">
                <div class="col-md-12">
                    <span class="ml-1">
                        <a id="btnOpen" runat="server" style="float: right; width: 25px; height: 25px;" class="" data-toggle="modal" data-target="#uploadPicture">
                            <i style="font-size: 25px;" class="text-success fas fa-plus-square"></i>
                        </a>
                        <button id="btnOpenModal" runat="server" style="display: none; width: 25px; height: 25px;" type="button" class="btn btn-success" data-toggle="modal" data-target="#uploadPicture">
                            <i class="fas fa-plus-square"></i>
                        </button>
                    </span>
                </div>
            </div>
            <%} %>

            <%
                Events ev = new Events();
                string evTitle = "Nowhere";
                for (int i = 0; i < gpList.Count; i++)
                {
                    var temp = ev.getEventDetails(gpList[i].gpevent);
                    if (temp != null)
                    {
                        evTitle = temp.Title;
                    }
            %>
            <div class="gpic">
                <a data-fancybox="gallery"
                    data-caption="&lt;b&gt;<%=gpList[i].caption%>&lt;/b&gt;<br />&lt;span class=&quot;text-danger&quot;&gt;@<%=evTitle%>&lt;/span&gt;"
                    href="<%Response.Write(gpList[i].filepath);%>">
                    <img src="<%Response.Write(gpList[i].filepath);%>" style="width: 200px; height: 200px;" class="img text-left" />
                </a>
            </div>
            <%} %>
        </div>
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
