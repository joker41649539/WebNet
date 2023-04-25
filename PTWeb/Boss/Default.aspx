<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Boss_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="/assets/css/datepicker.css" />
    <link rel="stylesheet" href="/assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="/assets/css/daterangepicker.css" />
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Boss/">Boss界面</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <h3 class="header smaller lighter green">&nbsp;<i class="icon-desktop"></i>&nbsp;&nbsp;快捷功能</h3>
        <p>
            <asp:LinkButton ID="LinkButton3" PostBackUrl="/Boss/Boss.aspx" class="btn btn-app btn-primary" runat="server"><i class="icon-home bigger-230"></i>
                    主&nbsp;&nbsp;页</asp:LinkButton>
            <a href="/CWGL/SearchQD.aspx" class="btn btn-app btn-info">
                <i class="icon-globe bigger-230"></i>
                签到情况
            </a>
            <a href="/GDGL/" class="btn btn-app btn-info">
                <i class="icon-legal bigger-230"></i>
                工程信息
            </a>
            <a href="/Partner/" class="btn btn-app btn-pink ">
                <i class="icon-group bigger-230"></i>
                协同人员
            </a>
            <a href="/CWGL/" class="btn btn-app btn-pink ">
                <i class="icon-coffee bigger-230"></i>
                报销情况
            </a>
            <a href="/BGGL/GCWXDList.ASPX" class="btn btn-app btn-success">
                <i class="icon-book bigger-230"></i>
                维&nbsp;保&nbsp;单
            </a>
            <a href="/GDGL/" class="btn btn-app btn-info">
                <i class="icon-legal bigger-230"></i>
                等待施工
            </a>
            <a href="/GDGL/" class="btn btn-app btn-success">
                <i class="icon-legal bigger-230"></i>
                正在施工
            </a>
            <a href="/GDGL/" class="btn btn-app btn-danger">
                <i class="icon-legal bigger-230"></i>
                暂停施工
            </a>
            <a href="/GDGL/" class="btn btn-app btn-info">
                <i class="icon-legal bigger-230"></i>
                完成施工
            </a>
            <a href="/GDGL/" class="btn btn-app btn-info">
                <i class="icon-legal bigger-230"></i>
                未验收
            </a>
            <a href="/BUG/" class="btn btn-app btn-warning">
                <i class="icon-cogs bigger-230"></i>
                故障反馈
            </a>
        </p>
    </div>

    <div class="col-sm-12">
        <div class="col-sm-6">
            <h3 class="header smaller lighter blue"><i class="icon-bar-chart"></i>&nbsp;人员信息</h3>
            <div class="input-group">
                <asp:TextBox ID="TextBox_SETime" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
            </div>
            <div class="space-10"></div>
            <div class="page-content">
                <!--人员启用 开始 //-->
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Partner" AllowSorting="True" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID">
                        <Columns>
                            <asp:HyperLinkField DataTextField="CName" HeaderText="姓名" SortExpression="CName" />
                            <asp:HyperLinkField DataTextField="QD" HeaderText="最后签到" SortExpression="QD" />
                            <asp:HyperLinkField DataTextField="YesDayBXFS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="布线分数" SortExpression="YesDayBXFS" />
                            <asp:HyperLinkField DataTextField="AZJF" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="安装分数" SortExpression="AZJF" />
                            <asp:HyperLinkField DataTextField="YesDayWXFS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="维保分数" SortExpression="YesDayWXFS" />
                            <asp:HyperLinkField DataTextField="SumFS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="总分" SortExpression="SumFS" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!--人员启用 结束 //-->
            </div>
        </div>
        <div class="col-sm-6">
            <h3 class="header smaller lighter blue"><i class="icon-bar-chart"></i>&nbsp;人员信息1</h3>
            <div class="input-group">
                <asp:TextBox ID="TextBox1" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
                <asp:LinkButton ID="LinkButton2" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
            </div>
            <div class="space-10"></div>
            <div class="page-content">
                <!--人员启用 开始 //-->
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView1" AllowSorting="True" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID">
                        <Columns>
                            <asp:HyperLinkField DataTextField="CName" HeaderText="姓名" SortExpression="CName" />
                            <asp:HyperLinkField DataTextField="QD" HeaderText="最后签到" SortExpression="QD" />
                            <asp:HyperLinkField DataTextField="YesDayBXFS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="布线分数" SortExpression="YesDayBXFS" />
                            <asp:HyperLinkField DataTextField="AZJF" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="安装分数" SortExpression="AZJF" />
                            <asp:HyperLinkField DataTextField="YesDayWXFS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="维保分数" SortExpression="YesDayWXFS" />
                            <asp:HyperLinkField DataTextField="SumFS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="总分" SortExpression="SumFS" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!--人员启用 结束 //-->
            </div>
        </div>

    </div>
</asp:Content>

