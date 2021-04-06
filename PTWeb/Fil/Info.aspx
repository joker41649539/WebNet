<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Fil_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" style="height: 100%">
        <div class="widget-box">
            <div class="widget-header widget-header-flat widget-header-small">
                <h3><img src="/images/Fil.png" width="30px" />
                    FIL值：≈<asp:Label ID="Label_Fil" runat="server" Text="0"></asp:Label>
                    (￥)</h3>
                <h3><img src="/images/Fil.png" width="30px" />
                    总产出：<b><asp:Label ID="Label_SumFil" runat="server" Text="0"></asp:Label></b>
                    (FIL)
                </h3>
                <%-- <h3 class="red"><i class="icon-gift icon-2x red"></i>
                    总价值：326000.00 (RMB)
                </h3>--%>
            </div>

            <div class="widget-body">
                <div class="widget-main">
                    <div id="piechart-placeholder"></div>

                    <div class="hr hr8 hr-double"></div>

                    <div class="clearfix">
                        <div class="grid2">
                            <span class="grey">
                                <%-- <img src="/img/logo.png" width="25px" />--%>
                                <img src="/images/Fil.png" width="25px" />
                                &nbsp; 总算力(T)
                            </span>
                            <br />
                            <h3 class="bigger pull-right">
                                <asp:Label ID="Label_SumPower" runat="server" Text="0"></asp:Label></h3>
                        </div>
                        <div class="grid2">
                            <span class="grey">
                                <i class="icon-heart icon-2x blue"></i>
                                &nbsp; 可提现 (FIL)
                            </span>
                            <br />
                            <h3 class="bigger pull-right">
                                <asp:Label ID="Label_Release" runat="server" Text="0"></asp:Label></h3>
                        </div>

                        <div class="grid2">
                            <span class="grey">
                                <i class="icon-lock icon-2x blue"></i>
                                &nbsp; 锁仓中 (FIL)
                            </span>
                            <br />
                            <h3 class="bigger pull-right">
                                <asp:Label ID="Label_Lock" runat="server" Text="0"></asp:Label></h3>
                        </div>
                        <div class="grid2">
                            <span class="grey">
                                <i class="icon-credit-card icon-2x blue"></i>
                                &nbsp; 提现中 (FIL)
                            </span>
                            <br />
                            <h3 class="bigger pull-right">
                                <asp:Label ID="Label_Withdraw" runat="server" Text="0"></asp:Label></h3>
                        </div>
                    </div>
                </div>
                <!-- /widget-main -->
            </div>
            <!-- /widget-body -->
        </div>
        <asp:GridView ID="GridView_Info" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Info_Sorting" OnSelectedIndexChanging="GridView_Info_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="every_time" SortExpression="every_time" DataFormatString="{0:yyyy-MM-dd}" HeaderText="日 期"></asp:BoundField>
                <asp:BoundField DataField="Release" SortExpression="DayRelease" DataFormatString="{0:0.0000}" ControlStyle-CssClass="pull-right" HeaderText="日产出"></asp:BoundField>
            </Columns>
            <PagerTemplate>
                <div>
                    <ul class="pagination">
                        <li>
                            <asp:LinkButton ID="GridView_Info_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="GridView_Info_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                        </li>
                        <li class="active"><a href="#">
                            <asp:Label ID="GridView_Info_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            /                                                   
                                            <asp:Label ID="GridView_Info_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                        </a></li>
                        <li>
                            <asp:LinkButton ID="GridView_Info_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="GridView_Info_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </PagerTemplate>
        </asp:GridView>
    </div>
    <!-- /widget-box -->
    <%-- <div class="col-xs-12">
            <!-- 时间轴循环开始 //-->
            <div class="timeline-container">
                <!-- 日期循环开始 //-->
                <div class="timeline-label">
                    <span class="label label-primary arrowed-in-right label-lg">
                        <b>2021-01-13</b>
                    </span>
                </div>
                <div class="timeline-items">
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">16:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">陆总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- 日期循环结束 //-->
                <!-- 日期循环开始 //-->
                <div class="timeline-label">
                    <span class="label label-primary arrowed-in-right label-lg">
                        <b>2021-01-13</b>
                    </span>
                </div>
                <div class="timeline-items">
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">16:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">陆总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常不好，重来
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- 日期循环结束 //-->
            </div>
            <!-- 时间轴循环结束 //-->
        </div>
    </div>
    <!-- /span -->--%>
</asp:Content>

