<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="EventStatus.aspx.cs" Inherits="FinalProj.EventStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" type="text/css" href="EventStatus.css" />
    <script>

        function searchFunction() {
            // Declare variables
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("searchEventName");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
                td = tr[i].querySelector("td > h3");
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div style="height: 100%">
        <div>
            <h1 id="title">Events Status</h1>
        </div>
        <table id="totalStats">
            <tr>
                <td>Events Participated:</td>
                <td id="totalParticipate">1</td>
                <td></td>
                <td>Events Completed:</td>
                <td id="totalComplete">1</td>
                <td></td>
                <td>Events Created:</td>
                <td id="totalCreate">0</td>
        </table>

        <div class="container">
            <div class="row" id="row2">
                <div class="col-sm-12 col-md-4 col-lg-4">
                    <input type="search" onkeyup="searchFunction()" id="searchEventName" placeholder="Search for events" aria-describedby="button-addon1" class="form-control border-1 bg-light" />
                </div>

                <div id="divRadioList" class="col-sm-12 col-md-4 col-lg-4">
                    <asp:RadioButtonList ID="radioButtonList" runat="server" CssClass="text" RepeatColumns="4" RepeatDirection="Vertical">
                        <asp:ListItem Selected="True" Value="create">Show Created</asp:ListItem>
                        <asp:ListItem Value="participate">Show Participated</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-sm-12 col-md-4 col-lg-4">
                    <asp:DropDownList ID="ddlAlphabet" runat="server" Width="150px">
                        <asp:ListItem>A-Z</asp:ListItem>
                        <asp:ListItem>Earliest-Latest</asp:ListItem>
                    </asp:DropDownList><br />
                    Sort Alphabetically or by Date
                </div>
            </div>
        </div>

        <div style="overflow-x: auto;">
            <h1 id="msg">No available events, join or create one!</h1>
            <table class="center" id="myTable">
                <% foreach (var element in evStList)
                    { %>
                <tr id="rowRepeat">
                    <td>
                        <img id="eventdp" src="<%= element.Pic %>" />
                    </td>
                    <td id="tableTD">
                        <h3 class="title"><%= element.Title %><br />
                        </h3>
                        <div id="containerItems">

                            <table id="innerTable">
                                <tr>
                                    <td class="alignRight">
                                        <p>Organised by: </p>
                                    </td>
                                    <td>
                                        <img id="dp" src="picture.jpg" />
                                        <p id="organiser">Kovi Tan</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="alignRight">
                                        <p id="txtDate">Start date and time: </p>
                                        <br />
                                    </td>
                                    <td>
                                        <p id="dateTime"><%= element.Date %>, <%= element.StartTime %> to <%= element.EndTime %></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="alignRight">
                                        <p id="txtStatus">Status: </p>
                                        <br />
                                    </td>
                                    <td>
                                        <p id="status">Complete</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
    </div>
</asp:Content>
