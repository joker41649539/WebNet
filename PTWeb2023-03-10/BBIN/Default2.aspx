<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="BBIN_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            模拟倍数：<asp:TextBox ID="TextBox1" runat="server">1</asp:TextBox><br />
            开始日期：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            截止日期：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <asp:CheckBox ID="CheckBox1" runat="server" />&nbsp;&nbsp; 加倍下注
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
        <asp:TextBox ID="TextBox_Remark" runat="server" Height="300px" TextMode="MultiLine" Width="600px"></asp:TextBox>
    </form>
</body>
</html>
