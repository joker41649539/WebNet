<%@ Page Title="" Language="C#" MasterPageFile="~/SpaServer/MasterPage.master" AutoEventWireup="true" CodeFile="Technician.aspx.cs" Inherits="SpaServer_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="input-group">
            <asp:TextBox ID="TextBox_SETime" placeholder="请输入您想查询的技师姓名" ClientIDMode="Static" class="form-control" name="date-range-picker" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
        </div>
    </div>
    <div class="col-xs-12">
        <h5 class="header lighter red"><i class="icon-group"></i>&nbsp;技&nbsp;师</h5>
        <div class="well row">
            <div class="col-xs-4">
                <span class="profile-picture">
                    <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                </span>
            </div>
            <div class="col-xs-8">
                <h4><a href="#" class="left"><b>陆晓钧</b></a>
                    <span class="label label-warning right pull-right">8.0 分</span>
                    <a href="#"><i class="icon-globe"></i>&nbsp;1.8&nbsp;km</a></h4>
                <p>已服务：&nbsp;162&nbsp; 单</p>
                <p>
                    <i class="icon-gift"></i>&nbsp;16
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
                <h4><a href="#" class="left"><b>陆晓钧</b></a>
                    <span class="label label-warning right pull-right">8.0 分</span>
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
                <h4><a href="#" class="left"><b>陆晓钧</b></a>
                    <span class="label label-warning right pull-right">8.0 分</span>
                    <a href="#"><i class="icon-globe"></i>&nbsp;1.8&nbsp;km</a></h4>
                <p>已服务：&nbsp;162&nbsp; 单</p>
                <p>
                    <i class="icon-gift"></i>&nbsp;16
                    <asp:LinkButton ID="LinkButton4" CssClass="btn btn-xs btn-success pull-right" runat="server"><i class="icon-heart-empty"></i>&nbsp;立即预约</asp:LinkButton>
                </p>
            </div>
        </div>
    </div>

</asp:Content>

