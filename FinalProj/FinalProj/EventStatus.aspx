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

        function sortTable() {
            var table, rows, switching, i, x, y, shouldSwitch;
            table = document.getElementById("myTable");
            switching = true;
            /* Make a loop that will continue until no switching has been done: */
            while (switching) {
                // Start by saying: no switching is done:
                switching = false;
                rows = table.rows;
                /* Loop through all table rows (except the first, which contains table headers): */
                for (i = 1; i < (rows.length - 1); i++) {
                    // Start by saying there should be no switching:
                    shouldSwitch = false;
                    /* Get the two elements you want to compare, one from current row and one from the next: */
                    x = rows[i].getElementsByTagName("TD")[0];
                    y = rows[i + 1].getElementsByTagName("TD")[0];
                    // Check if the two rows should switch place:
                    if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        // If so, mark as a switch and break the loop:
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    /* If a switch has been marked, make the switch and mark that a switch has been done: */
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div style="height: 100%">
        <div>
            <h1 id="title">Event Overview</h1>
        </div>
        <table id="totalStats">
            <tr>
                <td>Total Events:</td>
                <td id="totalComplete"><%= eventCount %></td>
                <td></td>
                <td>Events Create:</td>
                <td id="totalCreate"><%= eventCount %></td>
                <td></td>
                <td>Events Participate:</td>
                <td id="totalParticipate">0</td>
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
                    <asp:DropDownList ID="ddlAlphabet" runat="server" Width="150px" onchange="sortTable();">
                        <asp:ListItem>Earliest-Latest</asp:ListItem>
                        <asp:ListItem>A-Z</asp:ListItem>
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
                        <img id="eventdp" src="/Img/<%= element.Pic %>" />
                    </td>
                    <td id="tableTD">
                        <h3 class="title"><%= element.Title %></h3>
                        <br />
                        <div id="containerItems">

                            <table id="innerTable">
                                <tr>
                                    <td class="alignRight">
                                        <p>Organised by: </p>
                                    </td>
                                    <td>
                                        <img id="dp" src="<%= element.OrganiserPic %>" />
                                        <p id="organiser"><%= element.Organiser %></p>
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
                                        <p id="status"><%= element.Completed %></p>
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
    <script>
        if (document.getElementById("status").innerText == "Incomplete") {
            document.getElementById("status").style.color = "red";
        }
        else if (document.getElementById("status").innerText == "Complete"){
            document.getElementById("status").style.color = "green";
        }

        if (<%= eventCount%> > 0) {
            document.getElementById("msg").style.visibility = "hidden";
        }
    </script>
</asp:Content>
