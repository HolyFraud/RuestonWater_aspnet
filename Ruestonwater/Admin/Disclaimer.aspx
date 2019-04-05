<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Disclaimer.aspx.cs" Inherits="Ruestonwater.Admin.Disclaimer" %>
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
    <asp:SqlDataSource ID="SqlDataSourceDisclaimerParagraph" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" 
        SelectCommand="SELECT * FROM [DisclaimerList]"
        DeleteCommand="Update DisclaimerList Set RecordState = 0 Where DisclaimerListID = @DisclaimerListID"
        UpdateCommand="UPDATE DisclaimerList SET DisclaimerContent = @DisclaimerContent, RecordState = @RecordState WHERE (DisclaimerListID = @DisclaimerListID)">
        <DeleteParameters>
            <asp:Parameter Name="DisclaimerListID" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="DisclaimerContent" />
            <asp:Parameter Name="DisclaimerListID" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <div class="screen">

        <h1>Disclaimer Page<asp:Button ID="PreviewBtn" CssClass="btnleft" runat="server" Text="Preview" OnClick="PreviewBtn_Click" /></h1>
        <br />
        <br />
        <hr />
        <h2>Disclaimer Content</h2>
        <h3>Add New Disclaimer Paragraph</h3>
        <asp:TextBox ID="tbParagraph" runat="server" TextMode="MultiLine" style="width:800px; height:150px;"></asp:TextBox><br />
        <asp:Button ID="addbtn" runat="server" Text="Confirm" OnClick="addbtn_Click"/>
        <br />
        <br />
        <hr />

        <asp:GridView ID="GridViewDisclaimerContent" runat="server"
            AutoGenerateColumns="False" 
            DataSourceID="SqlDataSourceDisclaimerParagraph"
            DataKeyNames="DisclaimerListID"
            HeaderStyle-Height="30px"
            HeaderStyle-Width="500px"
            CellPadding="3" 
            CellSpacing="2" >
            <Columns>
                <asp:BoundField DataField="DisclaimerListID" HeaderText="DisclaimerListID" InsertVisible="False" ReadOnly="True" SortExpression="DisclaimerListID" Visible="false"/>
                
                <asp:TemplateField HeaderStyle-Width="500px" ItemStyle-Width="500px">
                    <HeaderTemplate>
                        <asp:Label ID="tb2" runat="server"  Text="Disclaimer Paragraph" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="tb1" runat="server"  Text='<%# Eval("DisclaimerContent") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tb" runat="server" Rows="4" TextMode="MultiLine" Style="Width:540px;" Height="100px" Text='<%# Bind("DisclaimerContent") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="RecordState" HeaderText="RecordState" SortExpression="RecordState" />
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server"
                            OnClientClick="return confirm('Are you sure you?');"
                            CommandName="Delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>