<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                            <span class="infobox-data-number">考勤签到</span>
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
                            <span class="infobox-data-number">维修报告</span>
                            <a href="/BGGL/GCWXDList.ASPX">
                                <div class="infobox-content">
                                    维修服务单
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-green2">
                        <div class="infobox-icon">
                            <i class="icon-edit"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">布线填报</span>
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
                            <span class="infobox-data-number">安装填报</span>
                            <a href="/GDGL/MyAZGD.ASPX">
                                <div class="infobox-data-number">
                                    <asp:Label ID="Label_MyAZNum" runat="server" Text="0"></asp:Label>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-blue3">
                        <div class="infobox-icon">
                            <i class="icon-edit"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">工作汇报</span>
                            <a href="/GDGL/MyAZGD.ASPX">
                                <div class="infobox-data-number">
                                    <asp:Label ID="Label2" runat="server" Text="填报工作汇报"></asp:Label>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="infobox infobox-pink">
                        <div class="infobox-icon">
                            <i class="icon-coffee"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">费用报销</span>
                            <a href="/CWGL/ReimbursementAdd.aspx">
                                <div class="infobox-content">
                                    <asp:Label ID="Label1" runat="server" Text="我要报销"></asp:Label>
                                </div>
                            </a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

