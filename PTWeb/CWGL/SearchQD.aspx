<%@ Page Title="签到查询" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchQD.aspx.cs" Inherits="CWGL_SearchQD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script charset="utf-8" src="https://map.qq.com/api/js?v=2.exp&key=OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77&libraries=drawing,geometry,autocomplete,convertor"></script>
    <script type="text/javascript">
        ///依据两点间坐标查询 路程和时间
        function init(a1, a2, b1, b2) {
            $.ajax({
                type: 'get',
                url: '/TencentMap/Distance.ashx',
                dataType: 'json',
                contentType: 'application/json',
                data: {
                    From1: a1,
                    From2: a2,
                    To1: b1,
                    To2: b2
                },
                success: function (responseData) {
                    if (responseData) {
                        var Distance = responseData.Distance;
                        // 0 地址 1 标题 2 mapid 3 计划目的 4 手工单号 5 工程名称
                        dialog = jqueryAlert({ 'title': '提示消息', 'content': Distance, 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close(); } } })
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {

                }
            });
            //var a = new qq.maps.LatLng(a1, a2);
            //var b = new qq.maps.LatLng(b1, b2);
            //计算两点间的距离
            //dialog = jqueryAlert({ 'content': '两点直线距离约为：' + (qq.maps.geometry.spherical.computeDistanceBetween(a, b) / 1000).toFixed(2) + ' 千米' })
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active">签到查询</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>签到管理								<small><i class="icon-double-angle-right"></i>&nbsp;签到查询                               </small></h1>
    </div>
    <div class="page-content">
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label9" class="col-sm-1 control-label no-padding-right">姓名：</label>
                <div class="col-sm-10 left">
                    <asp:TextBox ID="TextBox_Name" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label1" class="col-sm-1 control-label no-padding-right">日期：</label>
                <div class="col-sm-1">
                    <asp:TextBox ID="TextBox_STime" ClientIDMode="Static" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker" type="text" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:TextBox ID="TextBox_ETime" ClientIDMode="Static" class="form-control date-picker" type="text" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-7">
                    &nbsp;               
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <div runat="server" id="UpdateImages"></div>
                <%--  <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-mini btn-success" runat="server" OnClick="LinkButton1_Click1"><b>保&nbsp;&nbsp;存</b></asp:LinkButton>--%>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-mini" runat="server" OnClick="LinkButton1_Click"><b>查询</b></asp:LinkButton>
            </div>
        </div>
        <div class="page-content">
            <div id="QDList" runat="server"></div>
        </div>
    </div>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>

    <script type="text/javascript">
        jQuery(function ($) {
            $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });
        });
    </script>
</asp:Content>

