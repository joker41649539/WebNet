<%@ Page Title="ACE ICO展示" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ICO.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- 设置导航内容 开始 //-->
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">系统设置</a></li>
            <li><a href="/AceDemo/">ACE模板</a></li>
            <li class="active">ACE ICO展示</li>
        </ul>
    </div>
    <!-- 设置导航内容 结束 //-->

    <div id="ICOSHOW" class="col-sm-12 infobox-container" runat="server" />

</asp:Content>

