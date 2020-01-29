<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="eventDetailsTabTwo.aspx.cs" Inherits="FinalProj.eventDetailsTabTwo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
		#joinEvent {
			padding: 2%;
			width: 20%;
		}

		#bookmarkEvent {
			padding: 2%;
			width: 30%;
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

		#eventDetails {
			margin: 2em auto;
		}

		#discussion {
			padding: 2%;
			width: 25%;
		}

		@media only screen and (max-width: 990px) {
			#organiserDiv {
				width: 280px;
				margin: 0 auto;
			}

			#discussion {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#joinEvent {
				width: 100%;
				height: auto
			}

			#bookmarkEvent {
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
			<div class="row">
				<div class="col-sm-12 col-md-12 col-lg-6" id="eventPhoto">
					<img id="eventPic" src="Img/eventphoto.jpeg" />
				</div>
				<div class="col-sm-12 col-md-12 col-lg-6" id="eventDetails">
					<p class="h1" id="eventName">Project Beach Cleaning</p>
					<div id="organiserDiv">
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px">organised by <a href="#" style="text-decoration: none;">Kovi Tan</a></span>

						<p style="padding-left: 70px;">
							<i class="fa fa-clock"></i>&nbsp;<span>Monday, October 21 2019<br />
								2.00PM - 4.00PM</span>
							<br />
							<i class="fa fa-calendar"></i>&nbsp;<a href="#" style="text-decoration: none;">Add to Calendar</a>

						</p>
						<p style="padding-left: 70px;"><i class="fa fa-map-marker-alt"></i>&nbsp;<span>East Coast Park Service Rd</span></p>
						<span>
							<button type="button" id="joinEvent" class="btn btn-warning">JOIN</button>
							<button type="button" id="bookmarkEvent" class="btn btn-primary">BOOKMARK+</button>
							<a href="forumProjectClean.aspx">
								<button type="button" id="discussion" class="btn btn-primary">DISCUSSION</button></a></span>

					</div>
				</div>

				<div class="col-sm-12 col-md-12 col-lg-12">
					<ul class="nav nav-tabs">
						<li class="nav-item">
							<a class="nav-link" href="/eventDetailsTabOne.aspx">About</a>
						</li>
						<li class="nav-item">
							<a class="nav-link active" href="/eventDetailsTabTwo.aspx">Attendees</a>
						</li>

					</ul>
				</div>
			</div>
			<div class="row">
				<div style="width: 50%; margin-top: 3em; margin-right: auto; margin-left: auto;">
					<p class="h3">All Attendees</p>
					<form>
						<div class="p-1 bg-light rounded rounded-pill shadow-sm">
							<div class="input-group">
								<input type="search" placeholder="What're you searching for?" aria-describedby="button-addon1" class="form-control border-0 bg-light">
								<div class="input-group-append">
									<button id="button-addon1" type="submit" class="btn btn-link text-primary"><i class="fa fa-search"></i></button>
								</div>
							</div>
						</div>
					</form>
					<div style="margin-top: 2em; margin-bottom: 2em;">
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>
						<p></p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>

						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
						<p>
							<hr />
						</p>

						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a></span>
					</div>
				</div>
			</div>
		</div>

	</div>
</asp:Content>
