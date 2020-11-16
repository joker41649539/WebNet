<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyJF.aspx.cs" Inherits="MyJF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a class="active" href="/">首页</a>
            </li>
        </ul>
    </div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="page-header">
                <h1>普田科技								<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;我的积分                                </small></h1>
            </div>
            <div class="infobox infobox-orange">
                <div class="infobox-icon">
                    <i class="icon-bar-chart"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">我的积分</span>
                    <div class="infobox-content">
                        <asp:Label ID="Label_MyJF" runat="server" Text="0"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="widget-header widget-header-flat">
                <asp:DropDownList ID="GridView_WZLLD_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="W_GCGD_FS.LTIME">安装日期</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_WZLLD_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_WZLLD_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_WZLLD_TJADD_Click" ID="GridView_WZLLD_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_WZLLD_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <asp:Label ID="GridView_WZLLD_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_WZLLD_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_WZLLD_LinkButton3" OnClick="GridView_WZLLD_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_WZLLD_LinkButton4" OnClick="GridView_WZLLD_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="hr-10"></div>
            <div runat="server" class="page-content" id="Dtv_HTML">
            </div>
        </div>
    </div>
</asp:Content>

