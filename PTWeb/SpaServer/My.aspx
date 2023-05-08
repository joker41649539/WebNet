<%@ Page Title="" Language="C#" MasterPageFile="~/SpaServer/MasterPage.master" AutoEventWireup="true" CodeFile="My.aspx.cs" Inherits="SpaServer_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="widget-body">

        <div class="hr hr8 hr-double"></div>

        <div class="clearfix">
            <div class="grid2">
                <span class="grey">
                    <i class=" icon-credit-card icon-2x blue"></i>
                    &nbsp; 余额
                </span>
                <h4 class="bigger pull-right">10000</h4>
            </div>

            <div class="grid2">
                <span class="grey">
                    <i class="icon-briefcase icon-2x purple"></i>
                    &nbsp; 优惠券
                </span>
                <h4 class="bigger pull-right">0</h4>
            </div>
        </div>
    </div>
    <div class="hr hr8 hr-double"></div>
    <div class="col-xs-12 center">
        <div class="label label-info label-xlg arrowed-in arrowed-in-right" style="width: 95%">
            <div class="inline position-relative">
                <a href="#" class="user-title-label dropdown-toggle" data-toggle="dropdown">
                    <i class="icon-globe white middle"></i>
                    <span class="white">蜀山区尚泽国际写字楼(百乐门广场西)</span>
                </a>
            </div>
        </div>
        <div class="hr hr8 hr-double"></div>
        <p>
            <button class="btn btn-danger btn-block">停止接单</button>
        </p>
        <p>
            <a href="https://apis.map.qq.com/tools/locpicker?search=1&type=0&backurl=https://ptweb.x76.com.cn/SpaServer/Position.aspx&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX&referer=myapp" class="btn btn-app btn-info">
                <i class="icon-globe bigger-230"></i>
                更改位置
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-group bigger-230"></i>
                分销推广
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-comments bigger-230"></i>
                邀请好友
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-coffee bigger-230"></i>
                服务入驻
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-comment-alt bigger-230"></i>
                意见反馈
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-headphones bigger-230"></i>
                联系客服
            </a>
        </p>
    </div>
</asp:Content>

