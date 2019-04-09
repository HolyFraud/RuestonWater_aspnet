<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMasterPage.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Ruestonwater.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>FAQ - Rueston Water - Botanical Power Water From Vegetables and Fruits</title>
    <meta http-equiv="X-UA-compatible" content="IE=edge"/>    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black-translucent" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <meta content="FREQUENTLY ASKED QUESTIONS, What is Botanical Water"/>
    <link href="CSS/faq/faq.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSourceQuestionList" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" 
        SelectCommand="SELECT * FROM [QuestionList] Where RecordState = 1">

    </asp:SqlDataSource>


    <div class="space"></div>
    <div class="container">

        <h2>FREQUENTLY ASKED QUESTIONS</h2>
        <br />
        <div class="panel-group" id="accordion">
            <asp:Repeater ID="QuestionRepeater" runat="server" DataSourceID="SqlDataSourceQuestionList" >
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Eval("QuestionListID") %>">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Eval("QuestionListID") %>">

                                    <%# Eval("QuestionName") %>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse<%# Eval("QuestionListID") %>" class="panel-collapse collapse">
                            <div class="panel-body">

                                <%# Eval("QuestionContent") %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="space"></div>

    <script src="JS/faq/jquery.min.js"></script>
    <script src="JS/faq/bootstrap.min.js"></script>
</asp:Content>
