﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SpaServer/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SpaServer_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .MaxImage {
            max-width: 100px;
        }
        /*圆角边框*/
        img.round1 {
            border: 2px solid white;
            border-radius: 5px;
        }
    </style>
    <div class="col-xs-12">
        <div class="input-group">
            <asp:TextBox ID="TextBox_SETime" placeholder="请输入您想查询的技师姓名" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
        </div>
    </div>
    <div class="col-xs-12">
        <h5 class="header red"><i class="icon-group"></i>&nbsp;推&nbsp;荐</h5>
        <div class="well row">
            <div class="col-xs-4">
                <span class="profile-picture">
                    <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                </span>
            </div>
            <div class="col-xs-8">
                <h4><a href="#" class="left"><b>王菲</b></a>
                    <span class="label label-warning right pull-right">8.0</span>
                    <a href="#"><i class="icon-globe"></i>&nbsp;<asp:Label ID="Label_Distance" runat="server" Text="0"></asp:Label>&nbsp;km</a></h4>
                <p>已服务：&nbsp;162&nbsp; 单</p>
                <p>
                    <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                    <asp:LinkButton ID="LinkButton2" CssClass="btn btn-xs btn-success pull-right" runat="server"><i class="icon-heart-empty"></i>&nbsp;立即预约</asp:LinkButton>
                </p>
            </div>
        </div>
        <div class="well row">
            <div class="col-xs-4">
                <span class="profile-picture">
                    <img class="img-responsive img-rounded" width="100%" alt="Alex Doe's avatar" src="/images/User02.png" />
                </span>
            </div>
            <div class="col-xs-8">
                <h4><a href="#" class="left"><b>刘若英</b></a>
                    <span class="label label-warning right pull-right">8.0</span>
                    <a href="#"><i class="icon-globe"></i>&nbsp;1.8&nbsp;km</a></h4>
                <p>已服务：&nbsp;162&nbsp; 单</p>
                <p>
                    <i class="icon-gift"></i>&nbsp;16
                    <asp:LinkButton ID="LinkButton3" CssClass="btn btn-xs btn-success pull-right" runat="server"><i class="icon-heart-empty"></i>&nbsp;立即预约</asp:LinkButton>
                </p>
            </div>
        </div>
        <div class="well row">
            <div class="col-xs-4">
                <span class="profile-picture">
                    <img class="pull-left editable img-responsive img-rounded" width="100%" alt="Alex Doe's avatar" src="/images/User03.jpg" />
                </span>
            </div>
            <div class="col-xs-8">
                <h4><a href="#" class="left"><b>姚程</b></a>
                    <span class="label label-warning right pull-right">8.0</span>
                    <a href="#"><i class="icon-globe"></i>&nbsp;1.8&nbsp;km</a></h4>
                <p>已服务：&nbsp;162&nbsp; 单</p>
                <p>
                    <i class="icon-gift"></i>&nbsp;16
                    <asp:LinkButton ID="LinkButton4" CssClass="btn btn-xs btn-success pull-right" runat="server"><i class="icon-heart-empty"></i>&nbsp;立即预约</asp:LinkButton>
                </p>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <h5 class="header lighter green"><i class="icon-coffee"></i>&nbsp;推荐服务</h5>
        <div class="well row">
            <div class="col-xs-4">
                <span class="profile-picture">
                    <img class="editable img-responsive" width="100%" src="/images/server01.jpg" />
                </span>
            </div>
            <div class="col-xs-8">
                <h4><a href="#"><b>古法推拿</b></a>
                    <span class="label label-warning right pull-right"><i class="icon-group"></i>&nbsp;1567&nbsp;人已预约</span></h4>
                <p><span class="label label-danger">60 分钟</span></p>
                <p>
                    <span class="red bolder bigger-180">￥298</span>&nbsp;<span style="text-decoration: line-through">498</span>
                    <asp:LinkButton ID="LinkButton5" CssClass="btn btn-xs btn-success pull-right" runat="server"><i class="icon-heart-empty"></i>&nbsp;立即预约</asp:LinkButton>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
