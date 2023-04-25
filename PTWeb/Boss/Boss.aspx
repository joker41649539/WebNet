<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Boss.aspx.cs" Inherits="Boss_Boss" %>

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
        <h3 class="header smaller lighter green">快捷功能</h3>
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
    <div class="space-12"></div>
    <div class="col-sm-6 ">
        <h3 class="header smaller lighter blue"><i class="icon-bar-chart"></i>&nbsp;人员信息</h3>
        <p></p>
        <div class="input-group">
            <asp:TextBox ID="TextBox_SETime" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
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
    <div class="col-sm-6 content">
        <h3 class="header smaller lighter blue"><i class="icon-bar-chart"></i>&nbsp;工程信息</h3>
        <p></p>
        <div class="input-group">
            <asp:TextBox ID="TextBox_SETime2" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton2" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
        </div>
        <div class="space-10"></div>
        <div class="page-content">
            <!--人员启用 开始 //-->
            <div class="widget-main no-padding">
                <asp:GridView ID="GridView_GC" AllowSorting="True" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False">
                    <Columns>
                        <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="CName" />
                        <asp:HyperLinkField DataTextField="GCMC" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="工程名称" SortExpression="CName" />
                        <asp:HyperLinkField DataTextField="Times" HeaderText="最后时间" SortExpression="CName" />
                        <asp:HyperLinkField DataTextField="YJGS" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="工程分数" SortExpression="CName" />
                        <asp:TemplateField HeaderText="工程进度" SortExpression="ipercent">
                            <ItemTemplate>
                                <div class="progress" data-percent="<%# Eval("ipercent") %>%">
                                    <div class="progress-bar progress-bar-success" style='width: <%# Eval("ipercent") %>%;'></div>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="250px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <!--人员启用 结束 //-->
        </div>
    </div>
   <%-- <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <script src="/assets/js/date-time/bootstrap-timepicker.min.js"></script>
    <script src="/assets/js/date-time/moment.min.js"></script>
    <script src="/assets/js/date-time/daterangepicker.min.js"></script>
    <script>	
        $('input[id=TextBox_SETime]').daterangepicker().prev().on(ace.click_event, function () {
            $(this).next().focus();
        });
    </script>--%>
</asp:Content>

