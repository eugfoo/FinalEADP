<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="threadCreaterOverview.aspx.cs" Inherits="FinalProj.threadCreaterOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card card-body bg-light">
            <center>
        <a href="#aboutModal" data-toggle="modal" data-target="#myModal"><img src="<%=currentThreadUser.DPimage%>" name="aboutme" width="140" height="140" class="img-circle"></a>
        <h3><%=currentThreadUser.name%></h3>
        <em>click my face for more</em>
		</center>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                        <h4 class="modal-title" id="myModalLabel">More About <%=currentThreadUser.name%></h4>
                    </div>
                    <div class="modal-body">
                        <center>
                    <img src="<%=currentThreadUser.DPimage%>" name="aboutme" width="140" height="140" border="0" class="img-circle"></a>
                    <h3 class="media-heading"><%=currentThreadUser.name%></h3>
                    <span><strong>Skills: </strong></span>
                        <span class="label label-warning">HTML5/CSS</span>
                        <span class="label label-info">Adobe CS 5.5</span>
                        <span class="label label-info">Microsoft Office</span>
                        <span class="label label-success">Windows XP, Vista, 7</span>
                    </center>
                        <hr>
                        <center>
                    <p class="text-left"><strong>Bio: </strong><br>
                        <%=currentThreadUser.desc%></p>
                    <br>
                    </center>
                    </div>
                    <div class="modal-footer">
                        <center>
                    <button type="button" class="btn btn-default" data-dismiss="modal">I've heard enough about Joe</button>
                    </center>
                    </div>
                </div>
            </div>
        </div>


        <asp:Repeater ID="rptrThreads" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-responsive-lg">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col" class="topic-col">Topic</th>
                            <th scope="col" class="created-col">Created</th>
                            <th scope="col" style="min-width: 6em;">Replies/Views</th>
                            <th scope="col" class="last-post-col">Last Post</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <h3 class="h6"><span class="badge badge-<%# Eval("threadBadgeColor") %>"><%# Eval("threadPrefix") %></span> <a href="forumPost.aspx?threadid=<%# Eval("Id") %>"><%# Eval("threadTitle") %></a></h3>
                        <div class="small">
                            Started by: <%# Eval("user_name") %>
                        </div>
                    </td>

                    <td>
                        <div>by <a href="#0"><%# Eval("user_name") %></a></div>
                        <div><%# Eval("threadDate") %></div>
                    </td>
                    <td>
                        <div>5 replies</div>
                        <div>169 Views</div>
                    </td>
                    <td>
                        <div>by <a href="#0">KoviTan</a></div>
                        <div>05 Apr 2017, 20:07</div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
