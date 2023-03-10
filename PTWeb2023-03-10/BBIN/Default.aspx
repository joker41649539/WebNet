<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BBIN_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>游戏数据                </h4>
                <asp:DropDownList ID="GridView_Game_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="JQName">机器名称</asp:ListItem>
                    <asp:ListItem Value="TMYE">台面余额</asp:ListItem>
                    <asp:ListItem Value="YJYL">预计盈利</asp:ListItem>
                    <asp:ListItem Value="YS">用时</asp:ListItem>
                    <asp:ListItem Value="DML">打码量</asp:ListItem>
                    <asp:ListItem Value="LTIME">时间</asp:ListItem>
                    <asp:ListItem Value="ISave">保存</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Game_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Game_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Game_TJADD_Click" ID="GridView_Game_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
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
                    <asp:GridView ID="GridView_Game" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Game_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Game_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Game_SelectedIndexChanging">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="JQName" SortExpression="JQName" HeaderText="机器名称"></asp:BoundField>
                            <asp:BoundField DataField="TMYE" SortExpression="TMYE" HeaderText="台面余额"></asp:BoundField>
                            <asp:BoundField DataField="YJYL" SortExpression="YJYL" HeaderText="预计盈利"></asp:BoundField>
                            <asp:BoundField DataField="YS" SortExpression="YS" HeaderText="用时"></asp:BoundField>
                            <asp:BoundField DataField="DML" SortExpression="DML" HeaderText="打码量"></asp:BoundField>
                            <asp:BoundField DataField="LTIME" SortExpression="LTIME" HeaderText="时间"></asp:BoundField>
                            <asp:BoundField DataField="ISave" SortExpression="ISave" HeaderText="保存"></asp:BoundField>
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
</asp:Content>

