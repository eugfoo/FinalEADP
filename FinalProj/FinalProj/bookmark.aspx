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
		#ContentPlaceHolder1_panelError {
		text-align: center;
		}

		#ContentPlaceHolder1_panelSuccess {
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
			</div>

		<p class="h1" style="text-align: center; margin-top: 0.5em; font-family: 'Franklin Gothic'; margin-bottom: 0.5em;">BOOKMARKS</p>

		<% foreach (var bookmarkedEvent in eventsUserBookmarked)
			{ %>
		<div class="card mb-3" style="max-width: 840px; margin-left: auto; margin-right: auto;">
			<div class="row no-gutters">
				<div class="col-md-6" style="padding: 3%;">
					<img src="Img/<%=bookmarkedEvent.Pic %>" class="card-img" />
				</div>
				<div class="col-md-6">
					<div class="card-body" style="padding: 5%; width: 100%">
						<h5 class="card-title" style="background-color: #22537C; text-align: center; color: white; font-family: 'Franklin Gothic';"><%=bookmarkedEvent.Title %></h5>
						<p class="card-text">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 40px; height: 40px;" /><span style="padding-left: 10px">organised by <a href="#" style="text-decoration: none;"><%=bookmarkedEvent.User_id %></a></span>
						</p>

						<p class="card-text">Start Date and time: <%=bookmarkedEvent.Date %>, <%=bookmarkedEvent.StartTime %>-<%=bookmarkedEvent.EndTime %></p>
						<p class="card-text">Venue: <%=bookmarkedEvent.Venue %></p>

						<%--<asp:Button ID="removeBMBtn" CssClass="btn btn-danger removeBMBtn" runat="server" Text="REMOVE" OnClick="removeBMBtn_Click" />
						 <asp:Button ID="joinBtn" CssClass="btn btn-warning join" runat="server" Text="JOIN" />--%>
						<a class="btn btn-danger removeBMBtn" href="/RemoveBookmark.aspx?eventId=<%=bookmarkedEvent.EventId %>">REMOVE</a>
						<% if (checkJoinStatus[bookmarkedEvent.EventId] == true)
							{ %>
						<a class="btn btn-danger leaveBtn" href="/RemoveEventFromBookmark.aspx?eventId=<%=bookmarkedEvent.EventId %>">LEAVE</a>
						<%}
							else
							{ %><a class="btn btn-warning join" href="/JoinEventFromBookmark.aspx?eventId=<%=bookmarkedEvent.EventId %>">JOIN</a>
						<%} %>
					</div>
				</div>
			</div>
		</div>
		<%} %>
	</div>
</asp:Content>
