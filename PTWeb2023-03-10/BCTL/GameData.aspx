<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GameData.aspx.cs" Inherits="BCTL_GameData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">博彩套利</a>
            </li>
            <li class="active"><a href="/BCTL/GameData.aspx">游戏数据</a></li>
        </ul>
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>游戏数据                </h4>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Game_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Game_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Game_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Game_LinkButton3" OnClick="GridView_Game_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Game_LinkButton4" OnClick="GridView_Game_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Game" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="false" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Game_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Game_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Game_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="JQName" SortExpression="JQName" HeaderText="机器名称"></asp:BoundField>
                            <asp:BoundField DataField="TMYE" SortExpression="TMYE" HeaderText="台面余额"></asp:BoundField>
                            <asp:BoundField DataField="Lose" SortExpression="Lose" HeaderText="爆"></asp:BoundField>
                            <asp:BoundField DataField="YJYL" SortExpression="YJYL" HeaderText="预计盈利"></asp:BoundField>
                            <asp:BoundField DataField="YS" SortExpression="YS" HeaderText="用时"></asp:BoundField>
                            <asp:BoundField DataField="DML" SortExpression="DML" HeaderText="打码量"></asp:BoundField>
                            <asp:BoundField DataField="LTIME" SortExpression="LTIME" HeaderText="时间"></asp:BoundField>
                            <asp:BoundField DataField="ISave" SortExpression="ISave" HeaderText="状态"></asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Game_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Game_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_Game_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_Game_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Game_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Game_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView_Game tr").each(function () {
            var mtd = $(this).children("td:eq(7)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-danger\">已结束</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-danger\">已结束</span>");
            }
            else if (mtd.text() == 2) {
                mtd.html(" <span class=\"label label-success\">进行中</span>");
            }
        });
    </script>
</asp:Content>

