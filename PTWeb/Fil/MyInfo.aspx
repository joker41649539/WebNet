<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="MyInfo.aspx.cs" Inherits="Fil_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="user-profile-1" class="user-profile row height-auto">
        <div class="col-xs-12 col-sm-3 center">
            <div class="hr hr12 dotted"></div>
            <div class="clearfix">
                <div class="grid2">
                    <span class="bigger-175 blue">
                        <asp:Label ID="Label_ComputerCount" runat="server" Text="0"></asp:Label></span>
                    <br />
                    主机数量
                </div>
                <div class="grid2">
                    <span class="bigger-175 blue">
                        <asp:Label ID="Label_SumPower" runat="server" Text="0"></asp:Label></span>
                    <br />
                    累计算力
                </div>
            </div>
            <div class="hr hr16 dotted"></div>
        </div>
    </div>
    <div runat="server" id="Div_ComputerInfo">
        <div class="well">
            <div class="widget-main">
                <div class="clearfix">
                    <div class="grid2">
                        <span class="grey">
                            <%-- <img src="/img/logo.png" width="25px" />--%>
                            <i class="icon-facebook-sign icon-2x blue"></i>
                            &nbsp; 算力值（T）
                        </span>
                        <br>
                        <h3 class="bigger pull-right">14</h3>
                    </div>

                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-heart icon-2x red"></i>
                            &nbsp; 总产出（FIL）
                        </span>
                        <br>
                        <h3 class="bigger pull-right">2001.1234</h3>
                    </div>

                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-lock icon-2x red"></i>
                            &nbsp; 锁仓中（FIL）
                        </span>
                        <br>
                        <h3 class="bigger pull-right">15.1234</h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-credit-card icon-2x red"></i>
                            &nbsp; 已释放（FIL）
                        </span>
                        <br>
                        <h3 class="bigger pull-right">10</h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-calendar icon-2x green"></i>
                            &nbsp; 生效日期
                        </span>
                        <br>
                        <h3 class="bigger pull-right">2021-02-01</h3>
                    </div>
                    <div class="grid2">
                        <span class="grey">
                            <i class="icon-calendar icon-2x green"></i>
                            &nbsp; 截止日期
                        </span>
                        <br>
                        <h3 class="bigger pull-right">永久</h3>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="well">
            <div class="clearfix">
                <div class="grid2">
                    <span class="grey">
                        <%-- <img src="/img/logo.png" width="25px" />--%>
                        <i class="icon-facebook-sign icon-2x blue"></i>
                        &nbsp; 算力值（T）
                    </span>
                    <br>
                    <h3 class="bigger pull-right">1</h3>
                </div>

                <div class="grid2">
                    <span class="grey">
                        <i class="icon-heart icon-2x red"></i>
                        &nbsp; 总产出（FIL）
                    </span>
                    <br>
                    <h3 class="bigger pull-right">2001.1234</h3>
                </div>

                <div class="grid2">
                    <span class="grey">
                        <i class="icon-lock icon-2x red"></i>
                        &nbsp; 锁仓中（FIL）
                    </span>
                    <br>
                    <h3 class="bigger pull-right">15.1234</h3>
                </div>
                <div class="grid2">
                    <span class="grey">
                        <i class="icon-credit-card icon-2x red"></i>
                        &nbsp; 已释放（FIL）
                    </span>
                    <br>
                    <h3 class="bigger pull-right">10</h3>
                </div>
                <div class="grid2">
                    <span class="grey">
                        <i class="icon-calendar icon-2x green"></i>
                        &nbsp; 生效日期
                    </span>
                    <br>
                    <h3 class="bigger pull-right">2021-02-01</h3>
                </div>
                <div class="grid2">
                    <span class="grey">
                        <i class="icon-calendar icon-2x green"></i>
                        &nbsp; 截止日期
                    </span>
                    <br>
                    <h3 class="bigger pull-right">2024-02-01</h3>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

