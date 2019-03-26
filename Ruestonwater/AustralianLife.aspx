<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="AustralianLife.aspx.cs" Inherits="Ruestonwater.AustralianLife" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/jquery.fullPage.css" rel="stylesheet" />
    <script src="JS/FullPage/jquery-2.2.0.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.js"></script>

    <link href="CSS/AustralianLife/AustralianLife.css" rel="stylesheet" />


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

</asp:Content>