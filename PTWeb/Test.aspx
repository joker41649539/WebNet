<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div >
                <iframe src="https://v.douyin.com/jUNd4J9/" frameborder="0" allowfullscreen></iframe>
            </div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
