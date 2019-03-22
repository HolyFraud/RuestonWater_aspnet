<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Ruestonwater.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Index.css" rel="stylesheet" />
    <script src="JS/jquery.min.js"></script>
    <script src="JS/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSourceHomeSlider" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
        SelectCommand="SELECT FileList.FileListID, FileList.FileName, FileList.RecordState, FileCaptionList.Caption FROM FileList INNER JOIN File_SliderOrderList ON FileList.FileListID = File_SliderOrderList.FileListID INNER JOIN FileCaptionList ON FileList.FileListID = FileCaptionList.FileListID WHERE FileList.RecordState = 1 ORDER BY File_SliderOrderList.SliderOrder"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceIndicator" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
        SelectCommand="SELECT File_SliderOrderList.SliderOrder FROM File_SliderOrderList INNER JOIN FileList ON File_SliderOrderList.FileListID = FileList.FileListID WHERE FileList.RecordState = 1">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceHomeSection_1_img" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
        SelectCommand="SELECT FileList.* FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 2 AND FileList.RecordState = 1">

    </asp:SqlDataSource>
    <div>
        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel" data-interval="5000" data-pause="false">



            <ol class="carousel-indicators">
                <asp:Repeater ID="IndicatorsRepeater" runat="server" DataSourceID="SqlDataSourceIndicator">
                    <ItemTemplate>
                        <li data-target="#carouselExampleControls" data-slide-to="<%#Eval("SliderOrder")%>" class="<%#GetActiveClass(Container.ItemIndex) %>"></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ol>
            <div class="carousel-inner" role="listbox">

                <asp:Repeater ID="ImgRepeater" runat="server" DataSourceID="SqlDataSourceHomeSlider">
                    <ItemTemplate>
                        <div class="item <%#GetActiveClass(Container.ItemIndex) %>">
                            <img src="<%# "/Images/home_slider/" + Eval("FileName") %>" alt="" style="height: 100vh; width: 100vw; object-fit: cover;" />
                            <div class="carousel-caption"><p><%#Eval("Caption") %></p></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <a class="left carousel-control" href="#carouselExampleControls" role="button" data-slide="prev">
                <span class="icon-prev" aria-hidden="true"></span>
        			<span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carouselExampleControls" role="button" data-slide="next">
                <span class="icon-next" aria-hidden="true"></span>
        			<span class="sr-only">Next</span>
            </a>
        </div>
    </div>
    
    <div class="container">
        <div class="row">
            <div  class="col-sm-6 ">
                <asp:Image ID="HomeSection_1_img" runat="server" class="img-fluid"/>
            </div>
            <div class="col-sm-6">
                <br/>
                <br/>
                <br/>
                <h2><asp:Label ID="lbSection_1_Title" runat="server"></asp:Label></h2>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <h2><asp:Label ID="lbSection_1_Subtitle" runat="server"></asp:Label></h2>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <a>
                    <asp:Label ID="lbSection_1_Content" runat="server" ></asp:Label>    
                </a>
                <br/>
                <br/>
                <br/>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div id="Section_2_BG" class="parallax" runat="server">

            <div class="row">
                <div class="parallaxbox">
                    <br />
                    <br />
                    <h2><asp:Label ID="lbSection_2_Title" runat="server"></asp:Label></h2>
                    <br />
                    <h2><asp:Label ID="lbSection_2_Subtitle" runat="server"></asp:Label></h2><br />
                    <a>
                        <asp:Label ID="lbSection_2_Content" runat="server"></asp:Label>
                    </a>
                    <br />
                    <br />
                    <br />

                </div>
            </div>

        </div>
        
    </div>


    <div class="container pt-5 ">
        <div class="row">
            <div class="col-sm-6">
                <asp:Image ID="HomeSection_3_Img" runat="server" class="img-fluid"/>
            </div>
            <div class="col-sm-6">
                <br/>
                <br/>
                <br />
                <h2><asp:Label ID="lbSection_3_Title" runat="server"></asp:Label></h2>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <h2><asp:Label ID="lbSection_3_Subtitle" runat="server"></asp:Label></h2>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <a>
                    <asp:Label ID="lbSection_3_Content" runat="server"></asp:Label>
                </a>
                <br/>
                <br/>
                <br />

            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div id="Section_4_BG" class="parallax2" runat="server">
            <div class="row">
                <div class="parallaxbox">
                    <br />
                    <br />
                    <h2><asp:Label ID="lbSection_4_Title" runat="server"></asp:Label></h2>
                    <br />
                    <a>
                        <asp:Label ID="lbSection_4_Content" runat="server"></asp:Label>
                    </a>
                </div>    
                    
            </div>
                
            
        </div>
    </div>
</asp:Content>
