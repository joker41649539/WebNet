<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyGDBXWZ.aspx.cs" Inherits="GDGL_MyGDBXWZ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
        </ul>
    </div>
    <div class="page-header">
        <h1>
            <asp:Label ID="Label_GCMC" runat="server" Text="Label"></asp:Label></h1>
    </div>
    <div runat="server" class="page-content" id="Dtv_HTML"></div>
</asp:Content>

