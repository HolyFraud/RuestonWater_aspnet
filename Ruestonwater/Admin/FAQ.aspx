<%@ Page Title="" Language="C#" validateRequest="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Ruestonwater.Admin.FAQ" %>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>"
        SelectCommand="SELECT * FROM QuestionList"
        DeleteCommand="Update QuestionList Set RecordState = 0 Where QuestionListID = @QuestionListID"
        UpdateCommand="UPDATE QuestionList SET QuestionName = @QuestionName, QuestionContent = @QuestionContent, RecordState = @RecordState WHERE (QuestionListID = @QuestionListID)">
        <DeleteParameters>
            <asp:Parameter Name="QuestionListID" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="QuestionName" />
            <asp:Parameter Name="QuestionContent" />
            <asp:Parameter Name="QuestionListID" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <div style="width: 1000px;">

        <h1>FAQ Page<asp:Button ID="Button1" runat="server" Text="Preview" CssClass="btnleft" OnClick="Button1_Click"/></h1>
        <br />
        <hr /><br />
        <h2>Add New Questions And Answers</h2>
        
        <asp:TextBox ID="tbQuestionName" runat="server" placeholder="Input Question Name" Width="200px" Height="30px"></asp:TextBox><br /><br />
        
        <asp:TextBox ID="tbAnswer" TextMode="MultiLine" placeholder="Input Answer" Width="200px" Height="100px" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Return Line" OnClick="Button2_Click"/>
        <asp:Button ID="Insert" runat="server" Text="Insert" CssClass="btnleft" OnClick="Insert_Click"/><br /><br />
        <hr /><br />
        <asp:GridView ID="GridViewQuestion" runat="server"
            DataSourceID="SqlDataSource1"
            AutoGenerateColumns="False"
            DataKeyNames="QuestionListID" 
            CellPadding="3" 
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" 
            HeaderStyle-Height="30px"
            HeaderStyle-Width="500px">
            <Columns>
                <asp:BoundField DataField="QuestionListID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="QuestionListID"></asp:BoundField>
                <asp:BoundField DataField="QuestionName" HeaderText="Question_Name" SortExpression="QuestionName"></asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Question_Content
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("QuestionContent") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Rows="4" TextMode="MultiLine" Style="Width:540px;" Text='<%# Eval("QuestionContent") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="RecordState" HeaderText="Activate_State" SortExpression="RecordState"></asp:CheckBoxField>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server"
                            OnClientClick="return confirm('Are you sure you?');"
                            CommandName="Delete">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>

    </div>

</asp:Content>
