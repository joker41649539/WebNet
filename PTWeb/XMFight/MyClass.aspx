<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="MyClass.aspx.cs" Inherits="XMFight_MyClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="btn-group" runat="server" id="Div_Students">
       <%-- <a href="#" class="btn btn-sm btn-primary">陆博文</a>
        <a href="#" class="btn btn-sm btn-pink">陆博语</a>--%>
    </div>
    <div class="row">
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid4">
                <span class="green">
                    <i class="icon-twitter-sign icon-2x green"></i>
                    &nbsp; 剩余
                </span>
                <h4 class="bigger pull-right">85 次</h4>
            </div>
            <div class="grid4">
                <span class="grey">
                    <i class="icon-twitter-sign icon-2x grey"></i>
                    &nbsp; 请假
                </span>
                <h4 class="bigger pull-right">0 次</h4>
            </div>
            <div class="grid4">
                <span class="red">
                    <i class="icon-twitter-sign icon-2x red"></i>
                    &nbsp; 旷课
                </span>
                <h4 class="bigger pull-right">0 次</h4>
            </div>
            <div class="grid4">
                <span class="red">
                    <i class="icon-twitter-sign icon-2x red"></i>
                    &nbsp; 储备金
                </span>
                <h4 class="bigger pull-right">100 元</h4>
            </div>
        </div>
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid2">
                <span class="blue">
                    <i class="icon-twitter-sign icon-2x blue"></i>
                    &nbsp; 每周六
                </span>
                <h4 class="bigger pull-right">10:00 - 11:30</h4>
            </div>
            <div class="grid2">
                <span class="blue">
                    <i class="icon-twitter-sign icon-2x blue"></i>
                    &nbsp; 每周日
                </span>
                <h4 class="bigger pull-right">10:00 - 11:30</h4>
            </div>
        </div>
        <%--<div class="grid3">
            <span class="grey">
                <i class="icon-pinterest-sign icon-2x red"></i>
                &nbsp; pins
            </span>
            <h4 class="bigger pull-right">1,050</h4>
        </div>--%>
    </div>
    <h3>课程安排</h3>
    <hr />
    <div class="row">
        <div runat="server" id="Div_PhotoList"></div>
    </div>
    <hr />
</asp:Content>

