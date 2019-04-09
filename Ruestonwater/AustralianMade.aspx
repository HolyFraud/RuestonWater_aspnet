<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="AustralianMade.aspx.cs" Inherits="Ruestonwater.AustralianMade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>100% Australian Made - Rueston Water - Botanical Power Water From Vegetables and Fruits</title>
    <meta http-equiv="X-UA-compatible" content="IE=edge"/>    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black-translucent" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <meta content="$30 Billion Annual Food Exports, Health & Safety, Superior Antioxidants, Largest Organic Farm Land In The World"/>

    <link href="CSS/jquery.fullPage.css" rel="stylesheet" />
    <script src="JS/FullPage/jquery-2.2.0.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.js"></script>
    <link href="CSS/AustralianMade/AustralianMade.css" rel="stylesheet" />

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
                <h2><asp:label id="p1mobiletitle1" clientidmode="static" runat="server" text=""></asp:label></h2><br />
                <p><asp:label id="p1mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>
        <br />
        <div id="mobile_p2" ClientIDMode="Static" runat="server">
            <div id="mobile_p2contaner" class="p2_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p2_mobiletext">
                <h1><asp:label id="p2mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <h2><asp:label id="p2mobiletitle1" clientidmode="static" runat="server" text=""></asp:label></h2><br />
                <p><asp:label id="p2mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>
        <br />
        <div id="mobile_p3" ClientIDMode="Static" runat="server">
            <div id="mobile_p3contaner" class="p3_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p3_mobiletext">
                <h1><asp:label id="p3mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <h2><asp:label id="p3mobiletitle1" clientidmode="static" runat="server" text=""></asp:label></h2><br />
                <p><asp:label id="p3mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>

        <br />
        <div id="mobile_p4" ClientIDMode="Static" runat="server">
            <div id="mobile_p4contaner" class="p4_container" ClientIDMode="Static" runat="server">
                
            </div>
            <div class="p4_mobiletext">
                <h1><asp:label id="p4mobiletitle" clientidmode="static" runat="server" text=""></asp:label></h1>
                <h2><asp:label id="p4mobiletitle1" clientidmode="static" runat="server" text=""></asp:label></h2><br />
                <p><asp:label id="p4mobiletext" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
        </div>

    </div>
    <br /><br />




    <div id="fullpage">
        <div id="p1" runat="server" clientidmode="Static" class="section active">
            <div class="innerleft">
                <h1><asp:label id="p1title" clientidmode="static" runat="server" text=""></asp:label></h1>
                <h2><asp:label id="p1title1" clientidmode="static" runat="server" text=""></asp:label></h2>
            </div>
            <div class="innerright">
                <p>
                    <asp:Label ID="p1text" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                </p>
            </div>
            
        </div>
        <div id="p2" runat="server" clientidmode="Static" class="section">

            <div class="innerleft">
                <h1><asp:label id="p2title" clientidmode="static" runat="server" text=""></asp:label></h1>
            <h2><asp:label id="p2title1" clientidmode="static" runat="server" text=""></asp:label></h2>
            </div>

            <div class="innerright">
                <p><asp:Label ID="p2text" ClientIDMode="Static" runat="server" Text=""></asp:Label></p>
            </div>
            
            
        </div>
        <div id="p3" runat="server" clientidmode="Static" class="section">
            <div class="innerleft">
                <h1><asp:label id="p3title" clientidmode="static" runat="server" text=""></asp:label></h1>
            <h2><asp:label id="p3title1" clientidmode="static" runat="server" text=""></asp:label></h2>
            </div>

            <div class="innerright">
                <p><asp:label id="p3text" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
            
            
        </div>
        <div id="p4" runat="server" clientidmode="Static" class="section">
            <div class="innerleft">
                <h1><asp:label id="p4title" clientidmode="static" runat="server" text=""></asp:label></h1>
            <h2><asp:label id="p4title1" clientidmode="static" runat="server" text=""></asp:label></h2>
            </div>
            <div class="innerright">
                <p><asp:label id="p4text" clientidmode="static" runat="server" text=""></asp:label></p>
            </div>
            
            
        </div>

    </div>

    <script src="JS/faq/bootstrap.min.js"></script>
</asp:Content>

