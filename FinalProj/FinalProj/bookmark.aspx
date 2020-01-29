<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="bookmark.aspx.cs" Inherits="FinalProj.bookmark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media only screen and (max-width:767px) {
            .btn {
                width: 100%;
            }

            .join {
                margin-top: 0.5em;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 91vh;">

        <p class="h1" style="text-align: center; margin-top: 0.5em; font-family: 'Franklin Gothic'; margin-bottom: 0.5em;">BOOKMARKS</p>

        <div class="card mb-3" style="max-width: 840px; margin-left: auto; margin-right: auto;">
            <div class="row no-gutters">
                <div class="col-md-6" style="padding: 3%;">
                    <img src="Img/volunteer.jpeg" class="card-img" />
                </div>
                <div class="col-md-6">
                    <div class="card-body" style="padding: 5%; width: 100%">
                        <h5 class="card-title" style="background-color: #22537C; text-align: center; color: white; font-family: 'Franklin Gothic';">Project Clean Beach</h5>
                        <p class="card-text">
                            <img src="Img/organiser.jpeg" style="border-radius: 100%; width: 40px; height: 40px;" /><span style="padding-left: 10px">organised by <a href="#" style="text-decoration: none;">Kovi Tan</a></span></p>

                        <p class="card-text">Start Date and time: 29/10/19 9:00AM - 10:00AM</p>
                        <p class="card-text">Venue: East Coast Park Service rd 2</p>
                        <button type="button" class="btn btn-danger">REMOVE</button>
                        <button type="button" class="btn btn-warning join">JOIN</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="card mb-3" style="max-width: 840px; margin-left: auto; margin-right: auto;">
            <div class="row no-gutters">
                <div class="col-md-6" style="padding: 3%;">
                    <img src="Img/eventphoto.jpeg" class="card-img" />
                </div>
                <div class="col-md-6">
                    <div class="card-body" style="padding: 4%; width: 100%">
                        <h5 class="card-title" style="background-color: #22537C; text-align: center; color: white; font-family: 'Franklin Gothic';">Purple Parade!</h5>
                        <p class="card-text">
                            <img src="Img/organiser.jpeg" style="border-radius: 100%; width: 40px; height: 40px;" /><span style="padding-left: 10px">organised by <a href="#" style="text-decoration: none;">Kovi Tan</a></span></p>

                        <p class="card-text">Start Date and time: 29/10/19 9:00AM - 10:00AM</p>
                        <p class="card-text">Venue: East Coast Park Service rd 2</p>
                        <button type="button" class="btn btn-danger">REMOVE</button>
                        <button type="button" class="btn btn-warning join">JOIN</button>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
