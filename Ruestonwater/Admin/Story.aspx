<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Story.aspx.cs" Inherits="Ruestonwater.Admin.Story" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         h1, h2, h3 {
            color: #023668;
        }

         .screen{
             height:100vh;
         }

        .left {
            position: absolute;
            top:0;
            width: 50%;
            left: 0;
        }

        .right {
            position: absolute;
            top:20px;
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

    <div class="screen">

        <h1>Story Page<asp:Button ID="PreviewBtn" CssClass="btnleft" runat="server" Text="Preview" OnClick="PreviewBtn_Click"/>
        </h1>
        <br /><br /><hr />
        <h2>Story Content</h2>
        <h3>1st Paragraph:</h3>
        <asp:TextBox ID="tbp1" runat="server" TextMode="MultiLine" style="width:800px; height:80px;"></asp:TextBox><br />
        <asp:Button ID="p1btn" runat="server" Text="Confirm" OnClick="p1btn_Click"/>
        <h3>2nd Paragraph:</h3>
        <asp:TextBox ID="tbp2" runat="server" TextMode="MultiLine" style="width:800px; height:80px;"></asp:TextBox><br />
        <asp:Button ID="p2btn" runat="server" Text="Confirm" OnClick="p2btn_Click"/>
        <h3>3rd Paragraph:</h3>
        <asp:TextBox ID="tbp3" runat="server" TextMode="MultiLine" style="width:800px; height:80px;"></asp:TextBox><br />
        <asp:Button ID="p3btn" runat="server" Text="Confirm" OnClick="p3btn_Click"/>
        <h3>4th Paragraph:</h3>
        <asp:TextBox ID="tbp4" runat="server" TextMode="MultiLine" style="width:800px; height:80px;" ></asp:TextBox><br />
        <asp:Button ID="p4btn" runat="server" Text="Confirm" OnClick="p4btn_Click"/>
        <h3>5th Paragraph:</h3>
        <asp:TextBox ID="tbp5" runat="server" TextMode="MultiLine" style="width:800px; height:80px;"></asp:TextBox><br />
        <asp:Button ID="p5btn" runat="server" Text="Confirm" OnClick="p5btn_Click"/>
        <br /><br /><hr />
        <h2>Background Images</h2>
        <h3>1st Image Preview</h3>
        <asp:Image ID="Image1" runat="server" Style="max-height:100px;"/><br /><br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Upload" CssClass="btnleft" OnClick="Button1_Click"/><br />
        <asp:Label ID="LabelUploadState1" runat="server" Text="Label" Visible ="false"></asp:Label>
        <h3>2nd Image Preview</h3>
        <asp:Image ID="Image2" runat="server" Style="max-height:100px;"/><br /><br />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:Button ID="Button2" runat="server" Text="Upload" CssClass="btnleft" OnClick="Button2_Click"/><br />
        <asp:Label ID="LabelUploadState2" runat="server" Text="Label" Visible ="false"></asp:Label>
        <h3>3rd Image Preview</h3>
        <asp:Image ID="Image3" runat="server" Style="max-height:100px;"/><br /><br />
        <asp:FileUpload ID="FileUpload3" runat="server" />
        <asp:Button ID="Button3" runat="server" Text="Upload" CssClass="btnleft" OnClick="Button3_Click"/>
        <asp:Label ID="LabelUploadState3" runat="server" Text="Label" Visible ="false"></asp:Label>
        <br /><br /><br /><br /><br />
    </div>


</asp:Content>
