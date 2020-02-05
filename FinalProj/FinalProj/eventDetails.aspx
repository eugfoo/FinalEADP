﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="eventDetails.aspx.cs" Inherits="FinalProj.Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	<style>
		#ContentPlaceHolder1_joinEvent {
			padding: 2%;
			width: 20%;
		}
		#ContentPlaceHolder1_fullAttendance {
			padding: 2%;
			width: 35%;
		}

		#ContentPlaceHolder1_panelError {
			text-align: center;
		}

		#ContentPlaceHolder1_panelSuccess {
			text-align: center;
		}

		#ContentPlaceHolder1_leaveEvent {
			padding: 2%;
			width: 20%;
		}

		#ContentPlaceHolder1_bookmarkEvent {
			padding: 2%;
			width: 30%;
		}

		#ContentPlaceHolder1_bookmarked {
			padding: 2%;
			width: 30%;
		}

		#ContentPlaceHolder1_editEvent {
			padding: 2%;
			width: 20%;
		}

		#ContentPlaceHolder1_attendance {
			padding: 2%;
			width: 30%;
		}

		#ContentPlaceHolder1_deleteEvent {
			padding: 2%;
			width: 20%;
		}


		#ContentPlaceHolder1_discussion {
			padding: 2%;
			width: 25%;
		}

		#ContentPlaceHolder1_discussion2 {
			padding: 2%;
			width: 25%;
		}

		#eventName {
			text-align: center;
			padding: 0.5%;
			width: 100%;
			color: white;
			margin-right: auto;
			background-color: #CB0000;
		}

		#eventPhoto {
			text-align: center;
		}

		#eventPic {
			width: 100%;
			height: auto;
			border-radius: 5%;
			margin: 2em auto;
		}

		.participants {
			list-style: none;
			margin: auto;
		}

		.participantsListed {
			margin-bottom: 1px;
			border-bottom: 1px solid black;
		}

		#eventDetails {
			margin: 2em auto;
		}

		@media only screen and (max-width: 990px) {
			#ContentPlaceHolder1_editEvent {
				width: 100%;
				height: auto
			}
			#ContentPlaceHolder1_fullAttendance {
				width: 100%;
				height: auto
			}

			#ContentPlaceHolder1_deleteEvent {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#ContentPlaceHolder1_attendace {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#organiserDiv {
				width: 280px;
				margin: 0 auto;
			}

			#ContentPlaceHolder1_joinEvent {
				width: 100%;
				height: auto
			}

			#ContentPlaceHolder1_leaveEvent {
				width: 100%;
				height: auto
			}

			#ContentPlaceHolder1_bookmarkEvent {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#ContentPlaceHolder1_discussion {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#ContentPlaceHolder1_discussion2 {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#contactOrganiser {
				text-align: center;
				width: 280px;
				margin: 0 auto;
			}

			.attendeeGroup {
				text-align: center;
			}

			#remainingSpots {
				text-align: center;
			}
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="min-height: 91vh;">

		<div class="container">

			<br />
			<asp:Panel ID="panelSuccess" Visible="false" runat="server" CssClass="alert alert-dismissable alert-success">
				<asp:Label ID="lb_success" runat="server"></asp:Label>
			</asp:Panel>
			<asp:Panel ID="panelError" Visible="false" runat="server" CssClass="alert alert-dismissable alert-danger">
				<asp:Label ID="lb_error" runat="server"></asp:Label>
			</asp:Panel>
			<div class="row">
				<div class="col-sm-12 col-md-12 col-lg-6" id="eventPhoto">
					<img id="eventPic" src="Img/<% = eventDetail.Pic %>" />
				</div>
				<div class="col-sm-12 col-md-12 col-lg-6" id="eventDetails">
					<p class="h1" id="eventName"><%=eventDetail.Title %></p>
					<div id="organiserDiv">
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px">organised by <a href="#" style="text-decoration: none;"><%=userName %></a></span>

						<p style="padding-left: 70px;">
							<i class="fa fa-clock"></i>&nbsp;<span><%= eventDetail.Date%><br />
								<%= eventDetail.StartTime %> - <%= eventDetail.EndTime %></span>
							<br />
							<i class="fa fa-calendar"></i>&nbsp;<a href="#" style="text-decoration: none;">Add to Calendar</a>
						</p>

						<p style="padding-left: 70px;"><i class="fa fa-map-marker-alt"></i>&nbsp;<span><%= eventDetail.Venue %></span></p>

						<span>
							<% if (userId == null || userId != eventDetail.User_id)
								{
							%>
							<%FinalProj.BLL.Users user = (FinalProj.BLL.Users)Session["user"];
								bool btnCreated = false;
								if (user != null)
								{
									foreach (var participant in participantList)
									{
										if (participant.id == user.id)
										{
											btnCreated = true;%>
							<asp:Button ID="leaveEvent" CssClass="btn btn-danger" runat="server" Text="LEAVE"   OnClick="leaveEvent_Click" />
							<%}
									}
								}
								if (btnCreated == false)
								{
									if (participantList.Count != eventDetail.MaxAttendees)
									{%>
							<asp:Button ID="joinEvent" CssClass="btn btn-warning" runat="server" Text="JOIN" OnClick="joinEvent_Click" />
							<%}
								else
								{ %>
							<asp:Button ID="fullAttendance" CssClass="btn btn-secondary" runat="server" Text="MAX CAPACITY" Enabled="False" />
							<%}
								}
								if (bookmark == false)
								{%>

							<asp:Button ID="bookmarkEvent" CssClass="btn btn-primary" runat="server" Text="BOOKMARK+" OnClick="bookmarkEvent_Click" />
							<%}
								else
								{%>
							<asp:Button ID="bookmarked" CssClass="btn btn-success" runat="server" Text="BOOKMARKED" OnClick="unbookmarkEvent_Click" />
							<%} %>
							<asp:Button ID="discussion" CssClass="btn btn-primary" runat="server" Text="DISCUSSION" />
							<%}
								else
								{%>

							<asp:Button ID="editEvent" CssClass="btn btn-warning" runat="server" Text="EDIT" />

							<asp:Button ID="deleteEvent" CssClass="btn btn-danger" runat="server" Text="DELETE" OnClick="deleteEvent_Click" />
							<asp:Button ID="attendance" class="btn btn-primary" runat="server" Text="ATTENDANCE" />

							<asp:Button ID="discussion2" class="btn btn-primary" runat="server" Text="DISCUSSION" />
						</span>
						<%  
							}%>
					</div>
				</div>

				<div class="col-sm-12 col-md-12 col-lg-12">
					<ul class="nav nav-tabs">
						<li class="nav-item">
							<a class="nav-link active" href="#tab1" id="tab1Link" onclick="toggleTab1()">About</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="#tab2" id="tab2Link" onclick="toggleTab2()">Attendees</a>
						</li>

					</ul>
				</div>


			</div>
			<div id="tab1" class="row">
				<div class="col-sm-12 col-md-12 col-lg-6" style="margin-top: 2em;">
					<%= eventDetail.Desc %>
				</div>
				<div class="col-sm-12 col-md-12 col-lg-6" style="margin-top: 2em;">
					<div id="contactOrganiser">
						<p class="h5">Contact Organiser</p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;"><%=userName %></a><br />
							kovitanwk@gmail.com</span>
					</div>

					<p style="margin-top: 1em;" id="remainingSpots" class="h5">Remaining Spot(s) Available:<b style="color: #EC5D5D">&nbsp; <%= eventDetail.MaxAttendees - participantList.Count %> spots left</b></p>
					<div class="row attendeeGroup" style="margin-top: 3em;">
						<div class="col-sm-12 col-md-12 col-lg-12">
							<p class="h4" style="color: #EC5D5D;">Attendees (<%=participantList.Count %>)</p>
						</div>

						<% 
							for (int i = 0; i < participantList.Count; i++)
							{
								if (i == 4)
									break;
								{ %>

						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p><%= participantList[i].name %></p>
						</div>

						<%}
							}%>
					</div>
					<div class="row attendeeGroup" style="margin-top: 3em;">
						<%  
							for (int i = 4; i < participantList.Count; i++)
							{

								if (i == 8)
									break;
								{ %>

						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p><%= participantList[i].name %></p>
						</div>

						<%}
							}%>
					</div>
				</div>

			</div>

			<div id="tab2" style="display: none;" class="row">
				<div style="width: 50%; margin-top: 3em; margin-right: auto; margin-left: auto;">
					<p class="h3">All Attendees</p>

					<div class="p-1 bg-light rounded rounded-pill shadow-sm">
						<div class="input-group">
							<input type="search" placeholder="What're you searching for?" id="mySearchParticipants" onkeyup="mySearchParticipant();" aria-describedby="button-addon1" class="form-control border-1 bg-light">
							<div class="input-group-append">
								<button id="button-addon1" type="submit" class="btn btn-link border-1 text-primary"><i class="fa fa-search"></i></button>
							</div>
						</div>
					</div>

					<div style="margin-top: 2em; margin-bottom: 2em;">
						<ul class="participants" id="myUL">
							<% foreach (var participant in participantList)
								{ %>

							<li class="participantsListed">
								<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;"><%=participant.name %></a></span></li>

							<hr />
							<%} %>
						</ul>
					</div>
				</div>
			</div>
		</div>

	</div>
	<script> 
		function mySearchParticipant() {
			var input, filter, ul, li, a, i, txtValue;
			input = document.getElementById("mySearchParticipants");
			filter = input.value.toUpperCase();
			ul = document.getElementById("myUL");
			li = ul.getElementsByTagName("li");
			for (i = 0; i < li.length; i++) {
				a = li[i].getElementsByTagName("span")[0];
				txtValue = a.innerText;
				if (txtValue.toUpperCase().indexOf(filter) > -1) {
					li[i].style.display = "";
				} else {
					li[i].style.display = "none";
				}
			}
		}

		function toggleTab1() {
			document.getElementById("tab1").removeAttribute("style");
			document.getElementById("tab2").style.display = "none";
			document.getElementById("tab1Link").className = "nav-link active";
			document.getElementById("tab2Link").className = "nav-link";
		}

		function toggleTab2() {
			document.getElementById("tab2").removeAttribute("style");
			document.getElementById("tab1").style.display = "none";
			document.getElementById("tab2Link").className = "nav-link active";
			document.getElementById("tab1Link").className = "nav-link";
		}


	</script>
</asp:Content>