<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCWXDList.aspx.cs" Inherits="BGGL_GCWXDList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">报告管理</a></li>
            <li class="active"><a href="/BGGL/GCWXDList.ASPX">工程维修单</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>报告管理<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;工程维修单</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a href="/BGGL/GCWXD.ASPX" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">新建工程维修单</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">维修单</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-user"></i>工程维修单                </h4>
                                <asp:DropDownList ID="GridView_WXD_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="WXDH">单号</asp:ListItem>
                                    <asp:ListItem Value="YHMC">银行</asp:ListItem>
                                    <asp:ListItem Value="ZHMC">支行</asp:ListItem>
                                    <asp:ListItem Value="CNAME">维修人</asp:ListItem>
                                    <asp:ListItem Value="FLAG">状态</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_WXD_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_WXD_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_WXD_TJADD_Click" ID="GridView_WXD_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                            <div id="GridView_WXD_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                <asp:Label ID="GridView_WXD_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_WXD_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_WXD_LinkButton3" OnClick="GridView_WXD_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_WXD_LinkButton4" OnClick="GridView_WXD_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main no-padding">
                                    <asp:GridView ID="GridView_WXD" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_WXD_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_WXD_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_WXD_SelectedIndexChanging">
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID" HeaderText="查看" Text="查看PDF" DataNavigateUrlFormatString="/BGGL/WXDPDF.ASPX?ID={0}" ></asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID" HeaderText="单号" SortExpression="WXDH" DataNavigateUrlFormatString="/BGGL/GCWXD.ASPX?ID={0}" DataTextField="WXDH"></asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID" HeaderText="银行" SortExpression="YHMC" DataNavigateUrlFormatString="/BGGL/GCWXD.ASPX?ID={0}" DataTextField="YHMC"></asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID" HeaderText="支行" SortExpression="YHMC" DataNavigateUrlFormatString="/BGGL/GCWXD.ASPX?ID={0}" DataTextField="ZHMC"></asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="ID" HeaderText="维修人" SortExpression="CNAME" DataNavigateUrlFormatString="/BGGL/GCWXD.ASPX?ID={0}" DataTextField="CNAME"></asp:HyperLinkField>
                                            <asp:BoundField DataField="FLAG" SortExpression="FLAG" HeaderText="状态"></asp:BoundField>
                                            <asp:BoundField DataField="CTIME" SortExpression="CTIME" DataFormatString="{0:yyyy-MM-dd}" HeaderText="时间"></asp:BoundField>
                                        </Columns>
                                        <PagerTemplate>
                                            <div>
                                                <ul class="pagination">
                                                    <li>
                                                        <asp:LinkButton ID="GridView_WXD_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_WXD_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="active"><a href="#">
                                                        <asp:Label ID="GridView_WXD_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                        /                                                   
                                                            <asp:Label ID="GridView_WXD_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                    </a></li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_WXD_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_WXD_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
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
                </div>
            </div>
        </div>
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView_WXD tr").each(function () {
            var mtd = $(this).children("td:eq(5)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-success\">待提交</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-danger\">已完成</span>");
            }
            else if (mtd.text() == 9) {
                mtd.html(" <span class=\"label label-purple\">已查看</span>");
            }
        });
    </script>
</asp:Content>

