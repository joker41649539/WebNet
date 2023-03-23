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
    <div class="space-6"></div>
    <div class="col-sm-12 infobox-container left">
        <div class="infobox infobox-green">
            <div class="infobox-icon">
                <i class="icon-legal"></i>
            </div>
            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_ZZSG" runat="server" Text="0"></asp:Label></span>
                <div class="infobox-content">正在施工工程</div>
            </div>
        </div>
        <div class="infobox infobox-pink  ">
            <div class="infobox-icon">
                <i class="icon-coffee"></i>
            </div>
            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_DDSG" runat="server" Text="0"></asp:Label></span>
                <div class="infobox-content">等待施工工程</div>
            </div>
        </div>
        <div class="infobox infobox-blue  ">
            <div class="infobox-icon">
                <i class="icon-bar-chart"></i>
            </div>
            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_YesteDayJF" runat="server" Text="0"></asp:Label></span>
                <div class="infobox-content">昨日累计积分</div>
            </div>
        </div>
        <%-- <div class="infobox infobox-red">
            <div class="infobox-icon">
                <i class="icon-warning-sign"></i>
            </div>
            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_YesYCJF" runat="server" Text="0"></asp:Label></span>
                <div class="infobox-content">昨日积分异常</div>
            </div>
        </div>--%>
        <div class="infobox infobox-orange">
            <div class="infobox-icon">
                <i class="icon-globe"></i>
            </div>
            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_YesQD" runat="server" Text="0"></asp:Label></span>
                <div class="infobox-content">昨日签到次数</div>
            </div>
        </div>
        <%-- <div class="infobox infobox-orange2">
            <div class="infobox-icon">
                <i class="icon-warning-sign"></i>
            </div>
            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_YesQDYC" runat="server" Text="0"></asp:Label></span>
                <div class="infobox-content">昨日签到异常</div>
            </div>
        </div>--%>
    </div>
    <div class="space-6"></div>
    <div class="col-sm-8 content">
        <h3 class="header smaller lighter blue"><i class="icon-legal"></i>&nbsp;工程情况</h3>
        <p></p>
        <asp:GridView ID="GridView_GCInfo" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView_GCInfo_PageIndexChanging" OnSorting="GridView_GCInfo_Sorting" AllowSorting="True" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" runat="server">
            <Columns>
                <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                <asp:HyperLinkField DataTextField="GCMC" HeaderText="工程名称" SortExpression="GCMC" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                <asp:HyperLinkField DataTextField="CName" HeaderText="施工人员" SortExpression="CName" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                <asp:TemplateField HeaderText="施工进度" SortExpression="ipercent">
                    <ItemTemplate>
                        <div class="progress" data-percent="<%# Eval("ipercent") %>%">
                            <div class="progress-bar progress-bar-success" style='width:<%# Eval("ipercent") %>%;'></div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="250px"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-sm-4 content">
        <h3 class="header smaller lighter blue"><i class="icon-bar-chart"></i>&nbsp;积分情况</h3>
        <p></p>
        <div class="input-group">
            <asp:TextBox ID="TextBox_SETime" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
        </div>
        <div class="space-10"></div>
        <asp:GridView ID="GridView_JF" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView_JF_PageIndexChanging" OnSorting="GridView_JF_Sorting" AllowSorting="True" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" runat="server">
            <Columns>
                <asp:HyperLinkField DataTextField="CName" HeaderText="姓名" SortExpression="CName" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="#?ID={0}" />
                <asp:HyperLinkField DataTextField="YesDayBXFS" HeaderText="布线分数" SortExpression="YesDayBXFS" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="#?ID={0}" />
                <asp:HyperLinkField DataTextField="AZJF" HeaderText="安装分数" SortExpression="AZJF" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="#?ID={0}" />
                <asp:HyperLinkField DataTextField="YesDayWXFS" HeaderText="维保分数" SortExpression="YesDayWXFS" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="#?ID={0}" />
                <asp:HyperLinkField DataTextField="SumFS" HeaderText="总分" SortExpression="SumFS" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="#?ID={0}" />
            </Columns>
        </asp:GridView>
    </div>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <script src="/assets/js/date-time/bootstrap-timepicker.min.js"></script>
    <script src="/assets/js/date-time/moment.min.js"></script>
    <script src="/assets/js/date-time/daterangepicker.min.js"></script>
    <script>	
        $('input[id=TextBox_SETime]').daterangepicker().prev().on(ace.click_event, function () {
            $(this).next().focus();
        });
    </script>
</asp:Content>

