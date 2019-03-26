<%@ Page Title="" Language="C#" validateRequest="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AustralianLife.aspx.cs" Inherits="Ruestonwater.Admin.AustralianLife" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1, h2, h3 {
            color: #023668;
        }

        .screen {
            height: 100vh;
        }

        .left {
            position: absolute;
            top: 0;
            width: 50%;
            left: 0;
        }

        .right {
            position: absolute;
            top: 20px;
            width: 50%;
            right: 0;
        }

        .btnleft {
            margin-left: 50px;
        }

        .sectionborder {
            padding: 30px;
            border-color: #023668;
            border-style: solid;
            border-width: 1px;
        }

        .previewimg {
            max-width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h2>Australian LifeStyle Page<asp:Button ID="preview" runat="server" Text="Preview" CssClass="btnleft" OnClick="preview_Click" /></h2>
        <hr />
        <h3>Section 1</h3>
        <div>
            <h4>BackGround Image:</h4>
            <asp:Image ID="p1bg" runat="server" Style="max-height: 100px;" /><br />
            <asp:FileUpload ID="p1bgupload" runat="server" />
            <asp:Button ID="p1bguploadbtn" runat="server" Text="Upload" CssClass="btnleft" OnClick="p1bguploadbtn_Click" /><br />
            <asp:Label ID="p1uploadstate" runat="server" Text="Label" Visible="false"></asp:Label>


            <h4>Section 1 Text</h4>
            <asp:TextBox ID="tbp1title" runat="server" Width="400px" Height="30px"></asp:TextBox><br />
            <br />

            <asp:TextBox ID="tbp1content" TextMode="MultiLine" runat="server" Width="400px" Height="100px"></asp:TextBox><br />
            <br />
            <asp:Button ID="return" runat="server" Text="return line" OnClick="return_Click" />
            <asp:Button ID="confirm" runat="server" Text="Confirm" CssClass="btnleft" OnClick="confirm_Click" />
        
        </div>
        <br /><hr /><br />
        <h3>Section 2</h3>
        <div>
            <h4>BackGround Image:</h4>
            <asp:Image ID="p2bg" runat="server" Style="max-height: 100px;"/><br />
            <asp:FileUpload ID="p2bgupload" runat="server" />
            <asp:Button ID="p2bguploadbtn" runat="server" Text="Upload" CssClass="btnleft" OnClick="p2bguploadbtn_Click"/><br />
            <asp:Label ID="p2bguploadstate" runat="server" Text="Label" Visible="false"></asp:Label>
            
            <h4>Section 2 Text</h4>
            <asp:TextBox ID="tbp2title" runat="server" Width="400px" Height="30px" ></asp:TextBox><br /><br />

            <asp:TextBox ID="tbp2content" TextMode="MultiLine" runat="server" Width="400px" Height="100px" ></asp:TextBox><br />
            <br />
            <asp:Button ID="p2returnlinebtn" runat="server" Text="return line" OnClick="p2returnlinebtn_Click"/>
            <asp:Button ID="p2confirmbtn" runat="server" Text="Confirm" CssClass="btnleft" OnClick="p2confirmbtn_Click"/>
        </div>
        <br /><hr /><br />
        <h3>Section 3</h3>
        <div>
            <h4>BackGround Image:</h4>
            <asp:Image ID="p3bg" runat="server" Style="max-height: 100px;"/><br />
            <asp:FileUpload ID="p3bgupload" runat="server" />
            <asp:Button ID="p3bguploadbtn" runat="server" Text="Upload" CssClass="btnleft" OnClick="p3bguploadbtn_Click"/><br />
            <asp:Label ID="p3bguploadstate" runat="server" Text="Label" Visible="false"></asp:Label>
            
            <h4>Section 3 Text</h4>
            <asp:TextBox ID="tbp3title" runat="server" Width="400px" Height="30px" ></asp:TextBox><br /><br />

            <asp:TextBox ID="tbp3content" TextMode="MultiLine" runat="server" Width="400px" Height="100px" ></asp:TextBox><br />
            <br />
            <asp:Button ID="p3returnlinebtn" runat="server" Text="return line" OnClick="p3returnlinebtn_Click"/>
            <asp:Button ID="p3confirmbtn" runat="server" Text="Confirm" CssClass="btnleft" OnClick="p3confirmbtn_Click"/>
        </div>
        <br /><hr /><br />
        <h3>Section 4</h3>
        <div>
            <h4>BackGround Image:</h4>
            <asp:Image ID="p4bg" runat="server" Style="max-height: 100px;"/><br />
            <asp:FileUpload ID="p4bgupload" runat="server" />
            <asp:Button ID="p4bguploadbtn" runat="server" Text="Upload" CssClass="btnleft" OnClick="p4bguploadbtn_Click"/><br />
            <asp:Label ID="p4bguploadstate" runat="server" Text="Label" Visible="false"></asp:Label>
            
            <h4>Section 4 Text</h4>
            <asp:TextBox ID="tbp4title" runat="server" Width="400px" Height="30px" ></asp:TextBox><br /><br />

            <asp:TextBox ID="tbp4content" TextMode="MultiLine" runat="server" Width="400px" Height="100px" ></asp:TextBox><br />
            <br />
            <asp:Button ID="p4returnlinebtn" runat="server" Text="return line" OnClick="p4returnlinebtn_Click"/>
            <asp:Button ID="p4confirmbtn" runat="server" Text="Confirm" CssClass="btnleft" OnClick="p4confirmbtn_Click"/>
        </div>
    </div>


</asp:Content>
