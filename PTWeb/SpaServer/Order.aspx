<%@ Page Title="" Language="C#" MasterPageFile="~/SpaServer/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="SpaServer_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="tabbable">
            <ul class="nav nav-tabs" id="myTab3">
                <li class="active">
                    <a data-toggle="tab" href="#home3">
                        <i class="pink icon-dashboard bigger-110"></i>
                        待接单
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#dropdown13">
                        <i class="blue icon-coffee bigger-110"></i>
                        待服务
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#profile3">
                        <i class="blue icon-check bigger-110"></i>
                        完成
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="home3" class="tab-pane in active">
                    <div class="well row">
                        <div class="col-xs-4">
                            <span class="profile-picture">
                                <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                            </span>
                        </div>
                        <div class="col-xs-8">
                            <h4><a href="#" class="left"><b>王菲</b></a></h4>
                            <p>
                                <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                    <asp:LinkButton ID="LinkButton2" CssClass="btn btn-xs btn-success pull-right" runat="server">立即取消</asp:LinkButton>
                            </p>
                        </div>
                    </div>
                    <div class="well row">
                        <div class="col-xs-4">
                            <span class="profile-picture">
                                <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                            </span>
                        </div>
                        <div class="col-xs-8">
                            <h4><a href="#" class="left"><b>王菲</b></a></h4>
                            <p>
                                <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-xs btn-success pull-right" runat="server">立即取消</asp:LinkButton>
                            </p>
                        </div>
                    </div>
                </div>
                <div id="profile3" class="tab-pane">
                    <div class="well row">
                        <div class="col-xs-4">
                            <span class="profile-picture">
                                <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                            </span>
                        </div>
                        <div class="col-xs-8">
                            <h4><a href="#" class="left"><b>刘若英</b></a></h4>
                            <p>
                                <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                            </p>
                            <asp:LinkButton ID="LinkButton3" CssClass="btn btn-xs btn-success pull-right" runat="server">立即评价</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div id="dropdown13" class="tab-pane">
                    <div class="well row">
                        <div class="col-xs-4">
                            <span class="profile-picture">
                                <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                            </span>
                        </div>
                        <div class="col-xs-8">
                            <h4><a href="#" class="left"><b>刘亦菲</b></a></h4>
                            <p>
                                <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                            </p>
                        </div>
                    </div>
                    <div class="well row">
                        <div class="col-xs-4">
                            <span class="profile-picture">
                                <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                            </span>
                        </div>
                        <div class="col-xs-8">
                            <h4><a href="#" class="left"><b>刘亦菲</b></a></h4>
                            <p>
                                <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                            </p>
                        </div>
                    </div>
                    <div class="well row">
                        <div class="col-xs-4">
                            <span class="profile-picture">
                                <img class="editable img-responsive img-rounded" width="100%" src="/images/User01.png" />
                            </span>
                        </div>
                        <div class="col-xs-8">
                            <h4><a href="#" class="left"><b>刘亦菲</b></a></h4>
                            <p>
                                <i class="icon-gift"></i>&nbsp;16&nbsp;
                    <i class="icon-heart"></i>&nbsp;36
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div height="90px">&nbsp;</div>
</asp:Content>

