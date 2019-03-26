<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="AustralianMade.aspx.cs" Inherits="Ruestonwater.AustralianMade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/jquery.fullPage.css" rel="stylesheet" />
    <script src="JS/FullPage/jquery-2.2.0.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.js"></script>
    <link href="CSS/AustralianMade/AustralianMade.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $('#fullpage').fullpage({
                anchors: ['firstPage', 'secondPage', 'thirdPage', 'forthPage'],
                navigation: true,
                navigationPosition: 'right',
                css3: true,
                scrollingSpeed: 1000,
                autoScrolling: true
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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


</asp:Content>

