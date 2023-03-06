<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MSGINFO.aspx.cs" Inherits="Msg_MSGINFO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/MSG/MYMSG.ASPX">消息管理</a></li>
            <li class="active">
                我的信息
            </li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>
                <asp:Label ID="Label_Title" runat="server" Text="信息标题"></asp:Label>
                <small>
                    <i class="icon-double-angle-right"></i>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </small>
            </h1>
        </div>
        <div class="row">
            <div class="col-xs-12" id="DivContent" runat="server">
            </div>
        </div>
    </div>

</asp:Content>

