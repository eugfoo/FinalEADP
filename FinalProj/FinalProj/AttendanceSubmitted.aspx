<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="AttendanceSubmitted.aspx.cs" Inherits="FinalProj.AttendanceSubmitted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="AttendanceSubmitted.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 86vh">
        <div>
            <div>
                <h2 id="title"><%= title %></h2>
            </div>
            <table id="timer">
                <tr>
                    <td id="attendTitle">Time left to edit attendance:</td>
                    <td id="attendTime">0 hours 32 minutes 3 seconds</td>
                </tr>
                <tr id="timerRow">
                    <td class="greenBar"></td>
                    <td class="emptyBar"></td>
                </tr>
            </table>

            <table id="attendance">
                <tr>
                    <th>Names</th>
                    <th>Dietary Requirements (If any)</th>
                    <th>Are they at your event?</th>
                </tr>
                <% for (int i = 0; i < attendList.Count; i++)
                    { %>
                <tr>
                    <td>
                        <%= attendUser[i].name %>
                    </td>
                    <td>
                        <%= diet[i] %>
                    </td>
                    <td>
                        <%= attending[i] %>
                    </td>
                </tr>

                <% } %>
            </table>

            <div class="container">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <p id="totalPart">Total Participants: </p>
                        <p id="totalPartNum"><%= participant %></p>
                        <p id="currentPart">Current Participants: </p>
                        <p id="currentPartNum"><%= participantHere %></p>
                    </div>
                </div>
            </div>

            <a href="/AttendanceEdit.aspx" id="btnEdit" class="btn btn-danger">Edit</a>
        </div>
    </div>
</asp:Content>
