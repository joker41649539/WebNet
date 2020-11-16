<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyGDAZWZ.aspx.cs" Inherits="GDGL_MyGDAZWZ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyAZGD.aspx">我的安装工程</a></li>
        </ul>
    </div>
    <div class="page-header">
        <h1>
            <asp:Label ID="Label_GCMC" runat="server" Text="Label"></asp:Label></h1>
    </div>
    <div runat="server" class="page-content" id="Dtv_HTML"></div>
</asp:Content>

