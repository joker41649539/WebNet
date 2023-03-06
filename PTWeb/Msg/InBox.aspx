<%@ Page Title="收件箱" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InBox.aspx.cs" Inherits="Msg_InBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">消息管理</a></li>
            <li class="active"><a href="/MSG/InBox.aspx">收到的消息</a></li>
        </ul>
    </div>
    <div class="page-content">
        <div class="row">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="tabbable">
                            <ul id="inbox-tabs" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                                <li class="li-new-mail pull-right">
                                    <a data-toggle="tab" href="#write" data-target="write" class="btn-new-mail">
                                        <span class="btn bt1n-small btn-purple no-border">
                                            <i class=" icon-envelope bigger-130"></i>
                                            <span class="bigger-110">写 信 息</span>
                                        </span>
                                    </a>
                                </li>
                                <li class="active">
                                    <a data-toggle="tab" href="#inbox" data-target="inbox">
                                        <i class="blue icon-inbox bigger-130"></i>
                                        <span class="bigger-110">收到的消息</span>
                                    </a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#sent" data-target="sent">
                                        <i class="orange icon-location-arrow bigger-130 "></i>
                                        <span class="bigger-110">发出的消息</span>
                                    </a>
                                </li>
                            </ul>
                            <div class="tab-content">
                                <div id="inbox" class="tab-pane in active">
                                    <p>Raw denim you probably haven't heard of them jean shorts Austin.</p>
                                </div>
                                <div id="write" class="tab-pane">
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                </div>
                                <div id="sent" class="tab-pane">
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

