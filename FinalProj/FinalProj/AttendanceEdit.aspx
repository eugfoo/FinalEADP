<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="AttendanceEdit.aspx.cs" Inherits="FinalProj.AttendanceEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="AttendanceEdit.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 86vh">

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
        <script type="text/javascript">

            var userIdChecked = [];
            var userIdUncheck = [];
            var str;

            function myFunction() {
                // Declare variables
                var input, filter, table, tr, td, i, txtValue;
                input = document.getElementById("myInput");
                filter = input.value.toUpperCase();
                table = document.getElementById("attendance");
                tr = table.getElementsByTagName("tr");

                // Loop through all table rows, and hide those who don't match the search query
                for (i = 1; i < tr.length; i++) {
                    td = tr[i].getElementsByTagName("td")[1];
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

            function checkChkBox(checkI) {
                console.log("Checkbox is checked!");
                document.getElementById("ContentPlaceHolder1_CheckBox1").checked = checkI;
            };

            function onClick() {
                userIdChecked = [];

                $('#attendance input[type=checkbox]:checked').each(function () {
                    var row = $(this).closest("tr")[0];
                    str = row.cells[0].innerHTML;
                    str = str.replace(/\s+/g, '');
                    userIdChecked.push(str);
                });

                userIdChecked = JSON.parse("[" + userIdChecked + "]")

                document.getElementById('<%= HiddenField.ClientID%>').value = userIdChecked.join(',');

                //alert(userIdChecked);

                return false;
            };

            function onClick1() {
                userIdUncheck = [];

                $('#attendance input[type=checkbox]:not(:checked)').each(function () {
                    var row = $(this).closest("tr")[0];
                    str = row.cells[0].innerHTML;
                    str = str.replace(/\s+/g, '');
                    userIdUncheck.push(str);
                });

                userIdUncheck = JSON.parse("[" + userIdUncheck + "]")

                document.getElementById('<%= HiddenField1.ClientID%>').value = userIdUncheck.join(',');

                //alert(userIdUncheck);

                return false;
            };


            function progress(timeleft, timetotal, $element) {  // Create function to start timer
                var progressBarWidth = timeleft * $element.width() / timetotal;  // 
                $element.find('div').animate({ width: progressBarWidth }, 500).html(Math.floor(timeleft / 60) + ":" + timeleft % 60);
                if (timeleft > 0) {
                    setTimeout(function () {
                        progress(timeleft - 1, timetotal, $element);
                    }, 1000);
                }
            };

            progress(600, 600, $('#progressBar'));
        </script>

        <div>
            <div>
                <h2 id="title"><%= title %></h2>
            </div>
            <table id="timer">
                <tr>
                    <td id="attendTitle">Time left to edit attendance:</td>
                    <td id="attendTime">0 hours 32 minutes 3 seconds</td>
                </tr>
            </table>
            <div id="progressBar">
                <div class="bar"></div>
            </div>

            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for participant" />

            <table id="attendance">
                <tr>
                    <th style="visibility: hidden">ID</th>
                    <th>Names</th>
                    <th>Dietary Requirements (If any)</th>
                    <th>Are they at your event?</th>
                </tr>
                <% for (int i = 0; i < attendList.Count; i++)
                    { %>
                <tr id="trRepeat">
                    <td style="visibility: hidden">
                        <%= attendUser[i].id %>
                    </td>
                    <td>
                        <%= attendUser[i].name %>
                    </td>
                    <td>
                        <%= diet[i] %>
                    </td>
                    <td>
                        <script type="text/javascript">
                            checkChkBox(<%= check[i].ToString().ToLower() %>);
                        </script>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
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

            <asp:Button ID="Button1" UseSubmitBehavior="true" OnClientClick="onClick();onClick1();" runat="server" OnClick="Button1_Click" Text="Submit" />

            <asp:HiddenField ID="HiddenField" runat="server" Value="5" Visible="true" />
            <asp:HiddenField ID="HiddenField1" runat="server" Value="5" Visible="true" />
        </div>
    </div>
</asp:Content>
