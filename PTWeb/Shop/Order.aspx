﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="SpaServer_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="widget-body">
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid3">
                <span class="grey bigger">
                    <i class=" icon-credit-card icon-2x blue"></i>
                    &nbsp; 累计订单
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label_Sum" runat="server" Text="0.00"></asp:Label>
                </h4>
            </div>

            <div class="grid3">
                <span class="grey">
                    <i class="icon-briefcase icon-2x orange"></i>
                    &nbsp; 我的金豆
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label_GoldCount" runat="server" Text="0.000"></asp:Label>
                </h4>
            </div>
            <div class="grid3">
                <span class="grey">
                    <i class="icon-briefcase icon-2x purple"></i>
                    &nbsp; 我的利润
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label_LR" runat="server" Text="0.00"></asp:Label>
                </h4>
            </div>
        </div>
    </div>

    <div class="col-xs-12">
        <h3 class="header smaller lighter red"><i class="icon-credit-card"></i>&nbsp;我待付款</h3>
    </div>
    <div class="col-xs-12 page-content" runat="server" id="Well0">
        <div class="well">
            <%--<h5>202305171547</h5>
            <h5>传世古玉</h5>
            <h3 class="red">￥1500</h3>
            <p class="btn-group pull-right">
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-sm" OnClick="LinkButton1_Click" runat="server"><i class="icon-ok"></i>&nbsp;付款确认</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-sm btn-danger" PostBackUrl="/Shop/BankCardByUser.aspx" runat="server"><i class="icon-credit-card"></i>&nbsp;收款信息</asp:LinkButton>
            </p>
            &nbsp;--%>
        </div>
    </div>
    <div class="col-xs-12">
        <h3 class="header smaller lighter green"><i class="icon-credit-card"></i>&nbsp;待卖家确认</h3>
    </div>
    <div class="col-xs-12 page-content" runat="server" id="Well2">
        <div class="well">
            <%--<h5>202305171547<br />
                传世古玉<br />
                ￥1500</h5>
            <p class="btn-group pull-right">
                <asp:LinkButton ID="LinkButton3" CssClass="btn btn-sm" OnClick="LinkButton3_Click" runat="server"><i class="icon-ok"></i>&nbsp;收款确认</asp:LinkButton>
            </p>
            &nbsp;--%>
        </div>
    </div>
        <div class="col-xs-12">
        <h3 class="header smaller lighter pink"><i class="icon-credit-card"></i>&nbsp;我卖出的</h3>
    </div>
    <div class="col-xs-12 page-content" runat="server" id="Div_My">
        <div class="well">
            <%--<h5>202305171547<br />
                传世古玉<br />
                ￥1500</h5>
            <p class="btn-group pull-right">
                <asp:LinkButton ID="LinkButton3" CssClass="btn btn-sm" OnClick="LinkButton3_Click" runat="server"><i class="icon-ok"></i>&nbsp;收款确认</asp:LinkButton>
            </p>
            &nbsp;--%>
        </div>
    </div>

    <div class="col-xs-12">
        <h3 class="header smaller lighter blue"><i class="icon-credit-card"></i>&nbsp;已完成订单</h3>
    </div>
    <div class="col-xs-12 page-content" runat="server" id="Well1">
        <%--<div class="well">
            <h5>202305171547<br />
                传世古玉<br />
                ￥1500</h5>
        </div>
        <div class="well">
            <h5>202305171947<br />
                传世玉手镯<br />
                ￥2500</h5>
        </div>--%>
    </div>
</asp:Content>

