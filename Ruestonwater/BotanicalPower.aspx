<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="BotanicalPower.aspx.cs" Inherits="Ruestonwater.BotanicalPower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Botanical Power - Rueston Water - Botanical Power Water From Vegetables and Fruits</title>
    <meta http-equiv="X-UA-compatible" content="IE=edge"/>    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black-translucent" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <meta name="keywords" content="Absolute Purification, Gift From Nature, Sustainability, Vegan Friendly"/>
    <link href="CSS/jquery.fullPage.css" rel="stylesheet" />
    <script src="JS/FullPage/jquery-2.2.0.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.min.js"></script>
    <script src="JS/FullPage/jquery.fullPage.js"></script>
    
    <link href="CSS/BotanicalPower/BotanicalPower.css" rel="stylesheet" />
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
        <div id="p1" ClientIDMode="Static" class="section active" runat="server">
            <div id="main">
                <asp:Image ID="p1_bottle" ClientIDMode="Static" runat="server" />
                
                <div id="p1_text">
                    <h1>
                       <asp:label id="p1title" clientidmode="static" runat="server" text=""></asp:label>
                    </h1><br /><br />
                    <p>
                       <asp:Label ID="p1text" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                    </p>
                </div>
            </div>

        </div>
        <div id="p2" ClientIDMode="Static" class="section" runat="server">
            <div id="p2_text">
                <h1><asp:Label ID="p2title" ClientIDMode="Static" runat="server" Text=""></asp:Label></h1><br /><br />
                <p>
                    <asp:Label ID="p2text" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                </p>
            </div>
            
        </div>
        <div id="p3" ClientIDMode="Static" class="section" runat="server">
            <div id="p3_text">
                <h1><asp:Label ID="p3title" ClientIDMode="Static" runat="server" Text=""></asp:Label></h1><br /><br />
                <p><asp:Label ID="p3text" ClientIDMode="Static" runat="server" Text=""></asp:Label></p>
            </div>

        </div>
        <div id="p4" ClientIDMode="Static" class="section" runat="server">
            <div id="p4_text">
                <h1><asp:Label ID="p4title" ClientIDMode="Static" runat="server" Text=""></asp:Label></h1><br /><br />
                <p>
                    <asp:Label ID="p4text" ClientIDMode="Static" runat="server" Text=""></asp:Label>
                </p>
            </div>
        </div>
    </div>

    <script src="JS/faq/bootstrap.min.js"></script>
</asp:Content>
