<%@ Page Title="" Language="C#" MasterPageFile="~/Dance/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Dance_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="space-6"></div>
        <div class="col-sm-7 infobox-container">
            <div class="infobox infobox-red  ">
                <div class="infobox-icon">
                    <i class="icon-heart"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">
                        <a href="?School=0">
                            <asp:Label ID="Label_YE" runat="server" Text="美生店"></asp:Label></a></span>
                    <a href="?School=0">
                        <div class="infobox-content">(美生滨江花月二期南山书店二楼)</div>
                    </a>
                </div>
            </div>
            <div class="infobox infobox-green  ">
                <div class="infobox-icon">
                    <i class="icon-heart"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">
                        <a href="?School=1">
                            <asp:Label ID="Label_YL" runat="server" Text="金中环店"></asp:Label></a></span>
                    <a href="?School=1">
                        <div class="infobox-content">(金中环C座1201-1202)</div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12" runat="server" id="ClassList">
            <div class="widget-box ">
                <div class="widget-header red">
                    <h4 class="lighter smaller">
                        <i class="icon-calendar red"></i>
                        2021-03-14 星期日
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
                                        <span class="green">14:00-15:00</span>
                                    </div>
                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="text">
                                        <a href="/Dance/Reserve.aspx" class="btn btn-minier btn-info">
                                            <i class="icon-calendar"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>
                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">14:00-15:00</span>
                                    </div>
                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>
                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>
                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">14:00-15:00</span>
                                    </div>
                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>
                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="widget-box ">
                <div class="widget-header">
                    <h4 class="lighter smaller">
                        <i class="icon-comment"></i>
                        2021-03-15 星期一
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
                                        <span class="green">14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>

                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>

                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <!-- /widget-main -->
                </div>
                <!-- /widget-body -->
            </div>

            <div class="widget-box ">
                <div class="widget-header">
                    <h4 class="lighter smaller">
                        <i class="icon-comment blue"></i>
                        2021-03-16 星期二
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
                                        <span class="green">14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>

                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>

                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">14:00-15:00</span>
                                    </div>

                                    <div class="name">
                                        <a href="#">戈老师</a>
                                    </div>
                                    <div class="text">正位哈地 (5/10)</div>

                                    <div class="tools">
                                        <a href="#" class="btn btn-minier btn-info">
                                            <i class="icon-only icon-share-alt"></i>我要预约
                                        </a>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <!-- /widget-main -->
                </div>
                <!-- /widget-body -->
            </div>
        </div>

    </div>
</asp:Content>

