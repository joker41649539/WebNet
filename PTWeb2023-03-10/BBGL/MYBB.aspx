<%@ Page Title="我的报表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MYBB.aspx.cs" Inherits="BBGL_MYBB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">统计报表</a></li>
            <li class="active"><a href="/BBGL/Mybb.aspx">我的报表</a></li>
        </ul>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-bar-chart"></i>报表列表</h4>
                <asp:DropDownList ID="GridView_Report_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="CNAME">报表名称</asp:ListItem>
                    <asp:ListItem Value="NCLASS">报表类型</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Report_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Report_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Report_TJADD_Click" ID="GridView_Report_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Report_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Report_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Report_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Report_LinkButton3" OnClick="GridView_Report_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Report_LinkButton4" OnClick="GridView_Report_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <asp:UpdatePanel ID="GridView_Report_UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Report" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Report_Sorting" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Report_PageIndexChanging" DataKeyNames="ID">
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFormatString="BBSHOW.ASPX?ID={0}" HeaderText="查 看" Text="查 看" DataNavigateUrlFields="ID" />
                                    <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="报表名称"></asp:BoundField>
                                    <asp:BoundField DataField="NCLASS" SortExpression="NCLASS" HeaderText="报表类型"></asp:BoundField>
                                </Columns>
                                <PagerTemplate>
                                    <div>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li class="active"><a href="#">
                                                <asp:Label ID="GridView_Report_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                /                                                   
                                                <asp:Label ID="GridView_Report_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                            </a></li>
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </PagerTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- /widget-box -->
    </div>
</asp:Content>

