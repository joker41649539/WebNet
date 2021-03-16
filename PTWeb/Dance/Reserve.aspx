﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dance/MasterPage.master" AutoEventWireup="true" CodeFile="Reserve.aspx.cs" Inherits="Dance_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="widget-box ">
                <div class="widget-header red">
                    <h4 class="lighter smaller">
                        <i class="icon-calendar red"></i>
                        预约中
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <div class="dialogs">
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>

                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">2021-03-14 14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- /widget-main -->
                </div>
                <hr />
                <p>
                    <asp:Button ID="Button1" runat="server" class="btn btn-danger btn-block" Text="确定预约" />
                </p>
                <!-- /widget-body -->
            </div>
        </div>
    </div>
</asp:Content>
