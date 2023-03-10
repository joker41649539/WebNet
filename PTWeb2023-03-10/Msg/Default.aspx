<%@ Page Title="全局公告" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Msg_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li>消息管理</li>
            <li class="active">我的信息</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加信息</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">收到的消息</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">发出的消息</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div id="ContentPlaceHolder1_HtmlGrid" class="infobox-container">
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-group"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">儿童英语一班</span>
                                    <div class="infobox-content"><a href="#">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">陈老师</a>     </div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-group"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">儿童英语一班</span>
                                    <div class="infobox-content"><a href="#">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">陈老师</a>     </div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-group"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">儿童英语一班</span>
                                    <div class="infobox-content"><a href="#">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">陈老师</a>     </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        111
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        测试222
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

