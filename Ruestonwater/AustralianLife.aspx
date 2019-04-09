<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="AustralianLife.aspx.cs" Inherits="Ruestonwater.AustralianLife" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Australian Lifestyle - Rueston Water - Botanical Power Water From Vegetables and Fruits</title>
    <meta http-equiv="X-UA-compatible" content="IE=edge"/>    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black-translucent" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <meta content="Resource Heritage and Society Legacy, Harmony Between Human and Nature, Advocating of Sports and Exercise, The Love for Organic Products" name="keywords"/>
    

    <link href="CSS/jquery.fullPage.css" rel="stylesheet" />
    <script src="JS/FullPage/jquery-2.2.0.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.js"></script>

    <link href="CSS/AustralianLife/AustralianLife.css" rel="stylesheet" />


    <script>
        $(document).ready(function () {
            if ($(window).width() < 768) {
                $.fn.fullpage.destroy('all');
            }
            else {
                $('#fullpage').fullpage({
                    anchors: ['firstPage', 'secondPage', 'thirdPage', 'forthPage'],
                    navigation: true,
                    navigationPosition: 'right',
                    css3: true,
                    scrollingSpeed: 1000,
                    autoScrolling: true
                });
            }

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mobilecontainer">
        <div id="mobile_p1" runat="server" ClientIDMode="Static">
            <div id="mobile_p1contaner" class="p1_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p1_mobiletext" ClientIDMode="Static" runat="server">
                <h1><asp:label id="p1mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <p><asp:label id="p1mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>
        <br />
        <div id="mobile_p2" ClientIDMode="Static" runat="server">
            <div id="mobile_p2contaner" class="p2_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p2_mobiletext">
                <h1><asp:label id="p2mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <p><asp:label id="p2mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>
        <br />
        <div id="mobile_p3" ClientIDMode="Static" runat="server">
            <div id="mobile_p3contaner" class="p3_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p3_mobiletext">
                <h1><asp:label id="p3mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <p><asp:label id="p3mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>

        <br />
        <div id="mobile_p4" ClientIDMode="Static" runat="server">
            <div id="mobile_p4contaner" class="p4_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p4_mobiletext">
                <h1><asp:label id="p4mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <div class="separator  transparent   " style="margin-top: 30px;margin-bottom: 0px;"></div>
                <p><asp:label id="p4mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>

    </div>
    <br /><br />



    <div id="fullpage">
        <div id="p1" runat="server" ClientIDMode="Static" class="section active">
            <h1><asp:label id="p1title" clientidmode="static" runat="server" text=""></asp:label></h1>
            <p><asp:Label ID="p1text" ClientIDMode="Static" runat="server" Text=""></asp:Label></p>
        </div>
        <div id="p2" runat="server" ClientIDMode="Static" class="section">
            <h1><asp:Label ID="p2title" ClientIDMode="Static" runat="server" Text=""></asp:Label></h1>
            <p><asp:Label ID="p2text" ClientIDMode="Static" runat="server" Text=""></asp:Label></p>
        </div>
        <div id="p3" runat="server" ClientIDMode="Static" class="section">
            <h1><asp:Label ID="p3title" ClientIDMode="Static" runat="server" Text=""></asp:Label></h1>
            <p><asp:Label ID="p3text" ClientIDMode="Static" runat="server" Text=""></asp:Label></p>
        </div>
        <div id="p4" runat="server" ClientIDMode="Static" class="section">
            <h1><asp:Label ID="p4title" ClientIDMode="Static" runat="server" Text=""></asp:Label></h1>
            <p>
                <asp:Label ID="p4text" ClientIDMode="Static" runat="server" Text=""></asp:Label>
            </p>
        </div>

    </div>

    <script src="JS/faq/bootstrap.min.js"></script>

</asp:Content>