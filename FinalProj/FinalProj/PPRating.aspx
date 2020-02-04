<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="PPRating.aspx.cs" Inherits="FinalProj.PPRating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .fdback-link {
            text-decoration: none !important;
            transition: text-shadow 0.2s;
        }

            .fdback-link:hover {
                text-decoration: none !important;
            }

        .fdback-rating {
            font-size: 20px;
            color: yellow;
        }

        .fdback-desc {
            font-size: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <br />
        <div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row ">
            <div style="width: 100%; border-bottom: 1px solid lightgray;" class="row mx-0 pb-2">
                <div style="font-size: 20px;" class="col-md-6">
                    Feedback
                </div>
                
                <div class="text-right col-md-6">
                    <asp:DropDownList AutoPostBack="True" ID="ddlEvents" OnSelectedIndexChanged="ddlEvents_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="dropdown-divider"></div>

            <!-- Feedback Card -->
            <div style="width: 100%;" class="row mt-2 mx-0 mb-2">
                <div class="col-md-4">
                    <div style="position: absolute; top: 50%; -ms-transform: translateY(-50%); transform: translateY(-50%);"
                        class="">
                        <img style="border-radius: 100%; width: 60px; height: 60px;" src="/Img/organiser.jpeg" class="img img-thumbnail" />
                        <a href="#" class="fdback-link text-dark ml-2"><b>Enthusiastic Nitwit</b></a>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="row">
                        <div class="fdback-rating">
                            <span><i class="text-warning fa fa-star"></i></span>
                            <span><i class="text-warning fa fa-star"></i></span>
                            <span><i class="text-warning fa fa-star"></i></span>
                            <span><i class="text-warning fa fa-star"></i></span>
                            <span><i class="text-warning far fa-star"></i></span>
                        </div>

                    </div>
                    <div class="row">
                        <div class="fdback-desc">
                            Extremely pleasurable evening I had with this young lady, Jason Smith. Though her name implies her gender to be that of a man,
                            I can assure you, the only thing manly about her is her cock. Everything else about her is as feminine as can be.
                        </div>
                    </div>
                </div>
            </div>
            <!-- Feedback Card -->

        </div>
        <br />

        <!-- Recommendation Card -->
        <%--<div style="border: 1px solid lightgray; border-radius: 15px; padding: 10px;" class="row ">
            <div style="width: 100%; border-bottom: 1px solid lightgray;" class="row mx-0 pb-2">
                <div class="col-md-6">
                    Recommendations
                    <button class="btn btn-warning">Request</button>
                </div>
            </div>
            <div style="padding: 10px; width: 100%; background-color: lightcoral;" class="row mx-0 mb-2">
                <div class="col-md-4">
                    <img src="" class="img img-thumbnail" />Cove E
                </div>
                <div class="col-md-8">
                    <div class="row">
                        Three to the one from the one to the three
                    </div>
                </div>
            </div>
            <div style="padding: 10px; width: 100%; background-color: lightcoral;" class="row mx-0 mb-2">
                <div class="col-md-4">
                    <img src="" class="img img-thumbnail" />Cove E
                </div>
                <div class="col-md-8">
                    <div class="row">
                        Three to the one from the one to the three
                    </div>
                </div>
            </div>
            <div style="padding: 10px; width: 100%; background-color: lightcoral;" class="row mx-0 mb-2">
                <div class="col-md-4">
                    <img src="" class="img img-thumbnail" />Cove E
                </div>
                <div class="col-md-8">
                    <div class="row">
                        Three to the one from the one to the three
                    </div>
                </div>
            </div>
            <div style="padding: 10px; width: 100%; background-color: lightcoral;" class="row mx-0 mb-2">
                <div class="col-md-4">
                    <img src="" class="img img-thumbnail" />Cove E
                </div>
                <div class="col-md-8">
                    <div class="row">
                        Three to the one from the one to the three
                    </div>
                </div>
            </div>
        </div>--%>
        <!-- Recommendation Card -->

    </div>
</asp:Content>
