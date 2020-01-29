<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="createdEvent.aspx.cs" Inherits="FinalProj.createdEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
		#editEvent {
			padding: 2%;
			width: 20%;
		}

		#attendance {
			padding: 2%;
			width: 30%;
		}

		#deleteEvent {
			padding: 2%;
			width: 20%;
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

		#discussion {
			padding: 2%;
			width: 25%;
		}

		#eventDetails {
			margin: 2em auto;
		}

		@media only screen and (max-width: 990px) {
			#organiserDiv {
				width: 280px;
				margin: 0 auto;
			}

			#editEvent {
				width: 100%;
				height: auto
			}

			#deleteEvent {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#attendance {
				margin-top: 1em;
				width: 100%;
				height: auto
			}

			#discussion {
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
							<i class="fa fa-calendar"></i>&nbsp;<a href="" style="text-decoration: none;">Add to Calendar</a>

						</p>
						<p style="padding-left: 70px;"><i class="fa fa-map-marker-alt"></i>&nbsp;<span>East Coast Park Service Rd</span></p>
						<span>
							<button type="button" id="editEvent" class="btn btn-warning">EDIT</button>
							<button type="button" id="deleteEvent" class="btn btn-danger">DELETE</button>
							<a href="AttendanceSubmitted.aspx">
								<button type="button" id="attendance" class="btn btn-primary">ATTENDANCE</button></a>
							<a href="forumProjectClean.aspx">
								<button type="button" id="discussion" class="btn btn-primary">DISCUSSION</button></a></span>





					</div>
				</div>

				<div class="col-sm-12 col-md-12 col-lg-12">
					<ul class="nav nav-tabs">
						<li class="nav-item">
							<a class="nav-link active" href="#">About</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="#">Attendees</a>
						</li>

					</ul>
				</div>


			</div>
			<div class="row">
				<div class="col-sm-12 col-md-12 col-lg-6" style="margin-top: 2em;">
					This is about a project that is currently held in Singapore
                <br />
					We look to making this thing world wide
                <br />
					<p>
						Things to bring:
                <br />
						- water bottle (important)
                <br />
						- small bag
                <br />
						- yourself
                <br />
					</p>
					<p>
						In this exercise, the idea is to write a paragraph that would be a random passage from a story. An effective paragraph is one that has unity (it isn’t a hodgepodge of things), focus (everything in the paragraph stacks up to the whatever-it-is the paragraph is about), and coherence (the content follows smoothly). For this exercise, the paragraph should be quick to read--say, not be more than 100 words long.
					</p>
					<p>
						Lines of weeds criss-crossed the cracked parking lot of the Seashell Motor Courts. The flaking paint on the buildings had chalked to a pastel pink on walls covered with graffiti. Many of the windows had been smashed out. Where the sign had been, atop rusting steel posts, only the metal outline of a seashell remained.
					</p>
					<p>
						Lines of weeds criss-crossed the cracked parking lot of the Seashell Motor Courts. The flaking paint on the buildings had chalked to a pastel pink on walls covered with graffiti. Many of the windows had been smashed out. Where the sign had been, atop rusting steel posts, only the metal outline of a seashell remained.
					</p>
				</div>
				<div class="col-sm-12 col-md-12 col-lg-6" style="margin-top: 2em;">
					<div id="contactOrganiser">
						<p class="h5">Contact Organiser</p>
						<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" /><span style="padding-left: 10px"><a href="#" style="text-decoration: none;">Kovi Tan</a><br />
							kovitanwk@gmail.com</span>
					</div>

					<p style="margin-top: 1em;" id="remainingSpots" class="h5">Remaining Spot(s) Available:<b style="color: #EC5D5D">&nbsp;10 Spots</b></p>
					<div class="row attendeeGroup" style="margin-top: 3em;">
						<div class="col-sm-12 col-md-12 col-lg-12">
							<p class="h4" style="color: #EC5D5D;">Attendees (9)</p>
						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>
						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
					</div>
					<div class="row attendeeGroup" style="margin-top: 3em;">
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
						<div class="col-3">
							<img src="Img/organiser.jpeg" style="border-radius: 100%; width: 60px; height: 60px;" />
							<p>Kovi Tan</p>

						</div>
					</div>
				</div>

			</div>
		</div>

	</div>
</asp:Content>
