﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="images_Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="File1" runat="server" type="file" />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

    </form>
</body>
</html>
