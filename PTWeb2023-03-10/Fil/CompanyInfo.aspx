<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyInfo.aspx.cs" Inherits="Fil_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="widget-box">
        <div class="widget-body">
            <div class="widget-main">
                <div id="piechart-placeholder"></div>

                <div class="hr hr8 hr-double"></div>

                <div class="clearfix">
                    <div class="grid2">
                        <span class="grey">
                            <img src="/images/Fil.png" width="25px" />
                            &nbsp; 公司总算力(T)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label_SumPower" runat="server" Text="130"></asp:Label></h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <img src="/images/Fil.png" width="25px" />
                            &nbsp; 自持算力(T)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label_Release" runat="server" Text="100"></asp:Label></h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <img src="/images/Fil.png" width="25px" />
                            &nbsp; 已售算力(T)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label3" runat="server" Text="130"></asp:Label></h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <img src="/images/Fil.png" width="25px" />
                            &nbsp; 待生效算力(T)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label4" runat="server" Text="100"></asp:Label></h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-heart icon-2x blue"></i>
                            &nbsp; 节点可用余额(Fil)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label2" runat="server" Text="500"></asp:Label></h3>
                    </div>

                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-lock icon-2x blue"></i>
                            &nbsp; 售出可提现(Fil)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label_Lock" runat="server" Text="300"></asp:Label></h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-credit-card icon-2x blue"></i>
                            &nbsp; 公司锁仓(Fil)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label_Withdraw" runat="server" Text="20"></asp:Label></h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-credit-card icon-2x blue"></i>
                            &nbsp; 售出锁仓(Fil)
                        </span>
                        <br />
                        <h3 class="bigger pull-right">
                            <asp:Label ID="Label1" runat="server" Text="200"></asp:Label></h3>
                    </div>
                </div>
            </div>
            <!-- /widget-main -->
        </div>
        <!-- /widget-body -->
    </div>
</asp:Content>

