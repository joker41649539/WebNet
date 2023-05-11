<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="My.aspx.cs" Inherits="SpaServer_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="widget-body">
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid3">
                <span class="grey bigger">
                    <i class=" icon-credit-card icon-2x blue"></i>
                    &nbsp; 积分
                </span>
                <h4 class="bigger pull-right">100.00</h4>
            </div>

            <div class="grid3">
                <span class="grey">
                    <i class="icon-briefcase icon-2x orange"></i>
                    &nbsp; 金豆
                </span>
                <h4 class="bigger pull-right">50000.00</h4>
            </div>
            <div class="grid3">
                <span class="grey">
                    <i class="icon-briefcase icon-2x purple"></i>
                    &nbsp; 卡卷
                </span>
                <h4 class="bigger pull-right">0.000</h4>
            </div>
        </div>
    </div>
    <div class="hr hr8 hr-double"></div>
    <div class="col-xs-12 center">
        <p>
            <a href="#" class="btn btn-app btn-warning">
                <i class="icon-credit-card bigger-230"></i>
                佣金中心
            </a>
            <a href="#" class="btn btn-app btn-success">
                <i class="icon-globe bigger-230"></i>
                收货地址
            </a>
            <a href="#" class="btn btn-app btn-danger">
                <i class="icon-check bigger-230"></i>
                签到
            </a>
            <a href="#" class="btn btn-app btn-pink">
                <i class="icon-facetime-video bigger-230"></i>
                新人教程
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-comments bigger-230"></i>
                邀请好友
            </a>
            <a href="#" class="btn btn-app">
                <i class="icon-gift bigger-230"></i>
                提交藏品
            </a>
            <a href="#" class="btn btn-app btn-purple">
                <i class="icon-headphones bigger-230"></i>
                联系客服
            </a>
            <a href="#" class="btn btn-app btn-info">
                <i class="icon-cogs bigger-230"></i>
                个人设置
            </a>
            <a href="/Shop/GoodsAdd.aspx" class="btn btn-app btn-inverse">
                <i class="icon-gift bigger-230"></i>
                藏品添加
            </a>
            <a href="#" class="btn btn-app btn-inverse">
                <i class="icon-briefcase bigger-230"></i>
                金豆充值
            </a>
            <a href="/Shop/UserList.aspx" class="btn btn-app btn-inverse">
                <i class="icon-group bigger-230"></i>
                会员管理
            </a>
            <a href="/Shop/SysSet.aspx" class="btn btn-app btn-inverse">
                <i class="icon-cogs bigger-230"></i>
                系统设置
            </a>
        </p>
    </div>
</asp:Content>

