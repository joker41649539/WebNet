<%@ Page Title="签到查询" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchQD.aspx.cs" Inherits="CWGL_SearchQD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script charset="utf-8" src="https://map.qq.com/api/js?v=2.exp&key=OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77&libraries=drawing,geometry,autocomplete,convertor"></script>
    <script type="text/javascript">
        function init(a1, a2, b1, b2) {
            var a = new qq.maps.LatLng(a1, a2);
            var b = new qq.maps.LatLng(b1, b2);
            //计算两点间的距离
            alert("两点直线距离约为：" + (qq.maps.geometry.spherical.computeDistanceBetween(a, b) / 1000).toFixed(2) + " 千米");
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
                <label runat="server" id="Label9" class="col-sm-1 control-label no-padding-right">报销人：</label>
                <div class="col-sm-10 left">
                    <asp:TextBox ID="TextBox_Name" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label1" class="col-sm-1 control-label no-padding-right">日期：</label>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextBox_STime" ClientIDMode="Static" class="form-control date-picker" type="text" data-date-format="yyyy-MM-dd" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextBox_ETime" ClientIDMode="Static" class="form-control date-picker" type="text" data-date-format="yyyy-MM-dd" runat="server"></asp:TextBox>
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
</asp:Content>

