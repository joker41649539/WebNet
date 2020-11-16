﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                <h1>普田科技								<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;汇总数据                                </small></h1>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding infobox-container" runat="server" id="Dtv_HTML">
                    <div class="infobox infobox-green" runat="server" id="Div1">
                        <div class="infobox-icon">
                            <i class="icon-edit"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">签到管理</span>
                            <a href="/WeChat/WorkKQ.ASPX">
                                <div class="infobox-content">
                                    我要签到
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-blue2" runat="server" id="DivGCWXD">
                        <div class="infobox-icon">
                            <i class="icon-edit"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">报告管理</span>
                            <a href="/BGGL/GCWXDList.ASPX">
                                <div class="infobox-content">
                                    工程维修单
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-orange">
                        <div class="infobox-icon">
                            <i class="icon-bar-chart"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">我的积分</span>
                            <a href="/MyJF.aspx">
                                <div class="infobox-content">
                                    <asp:Label ID="Label_MyJF" runat="server" Text="0"></asp:Label>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-green2">
                        <div class="infobox-icon">
                            <i class="icon-edit"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">我的布线工程</span>
                            <a href="/GDGL/MyBXGD.ASPX">
                                <div class="infobox-data-number">
                                    <asp:Label ID="Label_MyBXNum" runat="server" Text="0"></asp:Label>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-red">
                        <div class="infobox-icon">
                            <i class="icon-edit"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">我的安装工程</span>
                            <a href="/GDGL/MyAZGD.ASPX">
                                <div class="infobox-data-number">
                                    <asp:Label ID="Label_MyAZNum" runat="server" Text="0"></asp:Label>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

