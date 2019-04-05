<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="Story.aspx.cs" Inherits="Ruestonwater.Story" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Story - Rueston Water - Botanical Power Water From Vegetables and Fruits</title>
    <meta http-equiv="X-UA-compatible" content="IE=edge" />
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black-translucent" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    
    <link href="CSS/Stroy/Stroy.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="space"></div>
    <div class="container text-center">
        <h1>Our Story</h1>
        <br />
        <div class="content-text">
            <div class="content-img" runat="server" id="bg1">
            </div>

            <p>
                <asp:Label ClientIDMode="Static" ID="p1" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ClientIDMode="Static" ID="p2" runat="server" Text=""></asp:Label>

            </p>
            <div class="content-img2" runat="server" id="bg2">
            </div>
            <p>
                <asp:Label ClientIDMode="Static" ID="p3" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ClientIDMode="Static" ID="p4" runat="server" Text=""></asp:Label>

            </p>
            <p>
                <asp:Label ClientIDMode="Static" ID="p5" runat="server" Text=""></asp:Label>

            </p>
            <div class="content-img3" runat="server" id="bg3">
            </div>
        </div>
    </div>
    <div class="space"></div>

    <script src="JS/faq/jquery.min.js"></script>
    <script src="JS/faq/bootstrap.min.js"></script>
</asp:Content>
