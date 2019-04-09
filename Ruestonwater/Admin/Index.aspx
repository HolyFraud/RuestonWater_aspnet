<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Ruestonwater.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1, h2, h3 {
            color: #023668;
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
        textarea{
            width:330px;
            height:160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
            SelectCommand="SELECT * FROM [FileList]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceHomeSlider" runat="server"
            ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
            SelectCommand="SELECT FileList.* FROM FileList INNER JOIN File_SectionList ON FileList.FileListID = File_SectionList.FileListID WHERE FileList.RecordState = 1 And File_SectionList.SectionListID = 1"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceHomeSliderOrder" runat="server"
            ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
            SelectCommand="SELECT FileList.FileListID FROM FileList INNER JOIN File_SectionList ON FileList.FileListID = File_SectionList.FileListID WHERE FileList.RecordState = 1 And File_SectionList.SectionListID = 1">

        </asp:SqlDataSource>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        
        
        <div>
            <h3>Home Page<asp:Button ID="PreviewBtn" runat="server" Text="Preview" CssClass="btnleft" OnClick="PreviewBtn_Click" /></h3>
            <div id="HomeSlider" class="sectionborder" runat="server">
                <h3>Home Slider Section</h3>
                <hr />
                <h5>Add New Slider Images</h5>
                <asp:FileUpload ID="HomeSliderImageUpload" runat="server" />
                <asp:Button ID="HomeSliderUploadBtn" runat="server" Text="Upload" CssClass="btnleft" OnClick="HomeSliderUploadBtn_Click" /><br />
                <br />
                <asp:Label ID="LabelUploadState" runat="server" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="false"></asp:Label><br />
                <hr />
                <h5>Edit Home Slider Images</h5>
                <asp:DropDownList ID="ddlHomeSliderImg" runat="server"
                    DataSourceID="SqlDataSourceHomeSlider" DataTextField="FileName" DataValueField="FileListID"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlHomeSliderImg_SelectedIndexChanged">
                </asp:DropDownList>
                
                <asp:Button ID="HomeSliderDelete" runat="server" CssClass="btnleft" Text="Delete" OnClick="HomeSliderDelete_Click" />
                <br />
                <br />
                <asp:Image ID="PreviewImg" runat="server" CssClass="previewimg"  />
                <br />
                <asp:Label ID="lbFileOrder" runat="server" Text="Images Order: "></asp:Label>
                <asp:DropDownList ID="ddlFileOrder" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <br />
                
                Caption On Slider Image:
                        <asp:TextBox ID="tbCaption" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                <br />
                <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" OnClick="HomeSliderConfirmBtn_Click"/><br />
                <asp:Label ID="lbConfirmMsg" runat="server" Text="Update Successfully" Visible="false"></asp:Label>
                <asp:Label ID="lbEditMsg" runat="server" Text="Edit Successfully" Visible="false"></asp:Label>
                <br /><br />
                <hr />
                <h3>Home Page Secion</h3>
                <br />
                <hr />
                Please Choose Which Home Section You Want to Edit: 
                <asp:DropDownList ID="ddlHomeSectionNumber" runat="server">
                    <asp:ListItem Selected="True" Value="2">Home Section 1</asp:ListItem>
                    <asp:ListItem Value="3">Home Section 2</asp:ListItem>
                    <asp:ListItem Value="4">Home Section 3</asp:ListItem>
                    <asp:ListItem Value="5">Home Section 4</asp:ListItem>
                </asp:DropDownList><br />
                <asp:Label ID="LabelUploadState1" runat="server" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="false"></asp:Label>
                <br />
                <br />
                <hr />
                <h5>Edit Secion Img</h5>
                <asp:FileUpload ID="HomeSectionImg" runat="server" />
                <asp:Button ID="HomeSectionUploadBtn" runat="server" Text="Upload" CssClass="btnleft" OnClick="HomeSectionUploadBtn_Click"/>
                <br />
                <br />
                <hr />
                <h5>Edit Section Content</h5>

                Main Title: 
                <asp:TextBox ID="tbTitleLv1" runat="server" TextMode="MultiLine"></asp:TextBox><br />

                Sub Title:
                <asp:TextBox ID="tbTitleLv2" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                Lv.3 Title (If It Has Lv.3 Title):
                <asp:TextBox ID="tbTitleLv3" runat="server" TextMode="MultiLine" placeholder="If it has...!"></asp:TextBox><br />
                Main Content:
                <asp:TextBox ID="tbContent" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                <br />
                <asp:Button ID="HomeSectionConfirmBtn" runat="server" Text="Confirm" OnClick="HomeSectionConfirmBtn_Click"/>
                <br />
                <br />
                <hr />

                
            </div>
        </div>

</asp:Content>