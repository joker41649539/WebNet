<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/ACEDEMO/">模板管理</a></li>
            <li class="active"><a href="/ACEDEMO/Default.aspx">基础代码</a></li>
            <li><a href="/ACEDEMO/GridView.aspx">GridView代码</a></li>
        </ul>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />



</asp:Content>
