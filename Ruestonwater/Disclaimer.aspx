<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="Disclaimer.aspx.cs" Inherits="Ruestonwater.Disclaimer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Disclaimer - Rueston Water - Botanical Power Water From Vegetables and Fruits</title>
    <meta http-equiv="X-UA-compatible" content="IE=edge" />
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black-translucent" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <link href="CSS/Disclaimer.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSourceDisclaimerContent" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" 
        SelectCommand="SELECT * FROM DisclaimerList Where RecordState = 1"></asp:SqlDataSource>
    <div class="space"></div>
    <div class="container text-center" style="min-height: 731.812px;">

        <h1>Disclaimer</h1>
        <br />
        <div class="content-text">
            <asp:Repeater ID="RepeaterDisclaimer" runat="server" DataSourceID="SqlDataSourceDisclaimerContent">
                <ItemTemplate>
                    <p>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("DisclaimerContent") %>'></asp:Label>
                    </p><br />
                </ItemTemplate>
            </asp:Repeater>
            
        </div>

    </div>

</asp:Content>
