<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBootstrap.Master" AutoEventWireup="true" CodeBehind="forumPost.aspx.cs" Inherits="FinalProj.forumPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .author-col {
            min-width: 12em;
        }

        .post-col {
            min-width: 20em;
        }

        .auto-style1 {
            max-width: 100%;
            height: 245px;
            width: 213px;
        }

        .auto-style3 {
            width: 233px;
        }

        .auto-style4 {
            min-width: 12em;
            width: 233px;
        }
    </style>
    <div class="container my-3">
        <nav class="breadcrumb">
            <a href="forumPage1.aspx" class="breadcrumb-item">Board index</a>
            <a href="forumCatOverview.aspx" class="breadcrumb-item">Forum Category</a>
            <span class="breadcrumb-item active">
                <asp:Label ID="LblPrefix" runat="server"></asp:Label>
                <asp:Label ID="LblTitleBreadcrumb" runat="server"></asp:Label></span>
        </nav>
        <div class="row">
            <div class="col-12">

                <div class="container">
                    <div class="row text-white bg-info mb-0 p-4 rounded-top">
                        <div class="col-md-9">
                            <h2 class="h4">
                                <asp:Label ID="LblTitleBig" runat="server"></asp:Label></h2>
                        </div>

                    </div>
                </div>
                <table class="table table-striped table-bordered table-responsive-lg">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col" class="auto-style3"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td class="auto-style4 table-secondary">
                                <div><a href="#0"><strong>GandyHaley</strong></a></div>
                            </td>
                            <td class="post-col d-lg-flex justify-content-lg-between table-secondary" style="height: 60px;">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <span class="font-weight-bold">Post subject:</span>
                                            <asp:Label ID="LblTitle" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-4">
                                            <span class="font-weight-bold">Posted:</span>
                                            <asp:Label ID="LblPostDate" runat="server" Text="02 Apr 2019"></asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div>
                                </div>
                                <div></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="max-width: 100px;" class="auto-style3">
                                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Donald_Trump_official_portrait.jpg/1200px-Donald_Trump_official_portrait.jpg" class="auto-style1" />

                                <div><span class="font-weight-bold">Joined: </span>02 Apr 2019, 23:59</div>
                                <div><span class="font-weight-bold">Posts:</span>123</div>
                            </td>
                            <td>
                                <asp:ListView ID="LVImages" runat="server">
                                    <ItemTemplate>
                                        <div class="container ml-4">
                                            <div class="row">
                                                <div class="col">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Img/"+ Eval("threadImage1") %>' Height="246px" Width="329px" onerror="this.style.display='none';" />
                                                </div>
                                                <div class="col">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/Img/"+ Eval("threadImage2") %>' Height="246px" Width="329px" onerror="this.style.display='none';" />
                                                </div>
                                            </div>
                                            <div class="row mt-3">
                                                <div class="col">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl='<%# "~/Img/"+ Eval("threadImage3") %>' Height="246px" Width="329px" onerror="this.style.display='none';" />
                                                </div>
                                                <div class="col">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Img/"+ Eval("threadImage4") %>' Height="246px" Width="329px" onerror="this.style.display='none';" />
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:ListView>


                                <br />
                                <asp:Label ID="LblContent" runat="server"></asp:Label>


                                <br />

                                <br />
                                <br />
                                <br />

                                &nbsp;&nbsp;<br />
                                <br />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Button ID="btnGoBack" runat="server" CssClass="btn btn-danger float-right" Text="Back" OnClick="btnGoBack_Click" />
                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary float-right mr-1" Text="Edit" OnClick="btnEdit_Click" />



                <asp:ScriptManager ID="MainScriptManager" runat="server" />



                <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
                    <ContentTemplate>

                        <asp:Repeater ID="rptrComments" runat="server">
                            <HeaderTemplate>
                                <br>
                                <br />
                                <br />
                                <table class="table table-striped table-bordered">

                                    <%--<thead class="thead-light">
                                        <tr>
                                            <th scope="col" class="auto-style3"></th>
                                            <th scope="col"></th>
                                        </tr>
                                    </thead>--%>
                                    <tbody>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td class="auto-style4 table-active">
                                        <div><a href="#0"><strong>GandyHaley</strong></a></div>
                                    </td>
                                    <td class="post-col d-lg-flex justify-content-lg-between table-active">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-md-8">
                                                    <span class="font-weight-bold">Post subject:</span>
                                                    <asp:Label ID="LblTitle" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <span class="font-weight-bold">Posted:</span>
                                                    <asp:Label ID="LblPostDate" runat="server"><%# Eval("postDate") %></asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="max-width: 100px;" class="auto-style3">
                                        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Donald_Trump_official_portrait.jpg/1200px-Donald_Trump_official_portrait.jpg" class="auto-style1" />

                                        <div><span class="font-weight-bold">Joined: </span>02 Apr 2019, 23:59</div>
                                        <div><span class="font-weight-bold">Posts:</span>123</div>
                                    </td>
                                    <td>
                                        <asp:Label ID="LblContent" runat="server"><%# Eval("postContent") %></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>

                            <FooterTemplate>
                                </tbody>
                                    </table>
                            </FooterTemplate>

                        </asp:Repeater>

                        <div style="margin-top: 20px;">

                            <table style="width: 485px; float: right;">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lbFirst"
                                            Style="padding: 8px; margin: 2px; background: #6b91ab; border: solid 1px #d5e3ed; color: white; font-weight: bold"
                                            runat="server" OnClick="lbFirst_Click">First</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbPrevious" runat="server"
                                            Style="padding: 8px; margin: 2px; background: #6b91ab; border: solid 1px #d5e3ed; color: white; font-weight: bold"
                                            OnClick="lbPrevious_Click">Previous</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:DataList ID="rptPaging" runat="server"
                                            OnItemCommand="rptPaging_ItemCommand"
                                            OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbPaging" runat="server"
                                                    CommandArgument='<%# Eval("PageIndex") %>'
                                                    CommandName="newPage"
                                                    Text='<%# Eval("PageText") %> ' Width="20px">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbNext" runat="server"
                                            Style="padding: 8px; margin: 2px; background: #6b91ab; border: solid 1px #d5e3ed; color: white; font-weight: bold"
                                            OnClick="lbNext_Click">Next</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbLast" runat="server"
                                            Style="padding: 8px; margin: 2px; background: #6b91ab; border: solid 1px #d5e3ed; color: white; font-weight: bold"
                                            OnClick="lbLast_Click">Last</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpage" runat="server" Text="" Style="background: #6b91ab; padding: 10px; color: white"></asp:Label>
                                    </td>
                                </tr>
                            </table>



                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>







                <style>
                    .threadBox {
                        background-color: #A9A9A9;
                    }
                </style>
            </div>
        </div>

        <div class="form-group">
            <label for="comment">Reply to this post:</label>
            <asp:TextBox ID="tbReplyContent" runat="server" CssClass="form-control" Height="250px" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="LblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <asp:Button ID="btnReply" runat="server" Text="Reply" CssClass="btn btn-primary" OnClick="btnReply_Click" />
        <button type="reset" class="btn btn-danger">Clear</button>


        <asp:HiddenField ID="HFthreadId" runat="server" />


        <asp:HiddenField ID="HFDate" runat="server" />

        <%--<thead class="thead-light">
                                        <tr>
                                            <th scope="col" class="auto-style3"></th>
                                            <th scope="col"></th>
                                        </tr>
                                    </thead>--%>
    </div>




</asp:Content>
