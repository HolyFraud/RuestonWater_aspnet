<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ruestonwater.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Platform</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <asp:TextBox ID="tbaccount" runat="server" placeholder="Enter Account" Width="200px" Height="20px"></asp:TextBox><br /><br />
            <asp:TextBox ID="tbpassword" runat="server" TextMode="Password" placeholder="Enter Password" Width="200px" Height="20px"></asp:TextBox><br /><br />
            <asp:Button ID="loginbtn" runat="server" Text="Login" OnClick="loginbtn_Click"/>
            <asp:Label ID="lblogin" runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
