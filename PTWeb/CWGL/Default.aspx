﻿<%@ Page Title="财务管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CWGL_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/CWGL/">财务管理</a></li>
            <li class="active">报销单</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>报销单							</h1>
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
               <%-- <li class="pull-right">
                    <a href="/CWGL/ReimbursementAdd.ASPX" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">填报报销单</span>
                        </span>
                    </a>
                </li>--%>
                <li class="active">
                    <a href="/CWGL/?flag=0">
                        <i class="green icon-inbox bigger-130"></i>
                        <span class="bigger-110">待提交</span>
                    </a>
                </li>
                <li>
                    <a href="/CWGL/?flag=2">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">综合部</span>
                    </a>
                </li>
                <li>
                    <a href="/CWGL/?flag=3">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">物资部</span>
                    </a>
                </li>
                <li>
                    <a href="/CWGL/?flag=4">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">工程部</span>
                    </a>
                </li>
                <li>
                    <a href="/CWGL/?flag=5">
                        <i class="pink icon-inbox bigger-130"></i>
                        <span class="bigger-110">待放款</span>
                    </a>
                </li>
                <li>
                    <a href="/CWGL/?flag=6">
                        <i class="pink icon-inbox bigger-130"></i>
                        <span class="bigger-110">待收票</span>
                    </a>
                </li>
                <li>
                    <a href="/CWGL/?flag=1">
                        <i class="red icon-inbox bigger-130"></i>
                        <span class="bigger-110">已完结</span>
                    </a>
                </li>
            </ul>
        </div>
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>报销单                </h4>
                <asp:DropDownList ID="GridView_BXD_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="UserName,ZJE,FLAG,LTIME">报销人</asp:ListItem>
                    <asp:ListItem Value="ZJE">总金额</asp:ListItem>
                    <asp:ListItem Value="FLAG">状态</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_BXD_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_BXD_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_BXD_TJADD_Click" ID="GridView_BXD_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_BXD_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_BXD_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_BXD_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_BXD_LinkButton3" OnClick="GridView_BXD_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_BXD_LinkButton4" OnClick="GridView_BXD_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_BXD" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_BXD_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_BXD_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_BXD_SelectedIndexChanging" OnRowCommand="GridView_BXD_RowCommand">
                        <Columns>
                            <asp:ButtonField DataTextField="UserName" HeaderText="报销人" CommandName="Select" SortExpression="UserName" Text="按钮" />
                            <asp:BoundField DataField="ZJE" SortExpression="ZJE" HeaderText="总金额"></asp:BoundField>
                            <asp:BoundField DataField="FLAG" SortExpression="FLAG" HeaderText="状态"></asp:BoundField>
                            <asp:BoundField DataField="LTIME" SortExpression="LTIME" HeaderText="最后时间"></asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_BXD_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_BXD_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_BXD_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_BXD_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_BXD_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_BXD_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_BXD_LinkButton_Add" runat="server" CommandName="GridView_BXD_ADD"><i class="icon-plus-sign">&nbsp;报销填报</i></asp:LinkButton>
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
        $("#GridView_BXD tr").each(function () {
            var mtd = $(this).children("td:eq(2)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-success\">待提交</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-danger\">已完结</span>");
            }
            else if (mtd.text() == 2) {
                mtd.html(" <span class=\"label label-info\">综合部</span>");
            }
            else if (mtd.text() == 3) {
                mtd.html(" <span class=\"label label-info\">物资部</span>");
            }
            else if (mtd.text() == 4) {
                mtd.html(" <span class=\"label label-info\">工程部</span>");
            }
            else if (mtd.text() == 5) {
                mtd.html(" <span class=\"label label-pink\">待放款</span>");
            }
            else if (mtd.text() == 6) {
                mtd.html(" <span class=\"label label-pink\">待收票</span>");
            }
        });
    </script>

</asp:Content>

