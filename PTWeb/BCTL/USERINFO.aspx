<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="USERINFO.aspx.cs" Inherits="BCTL_USERINFO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">博彩套利</a>
            </li>
            <li class="active"><a href="/BCTL/USERINFO.aspx">用户信息</a></li>
        </ul>
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>用户信息                </h4>
                <asp:DropDownList ID="GridView_USER_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="JQMC">机器名称</asp:ListItem>
                    <asp:ListItem Value="JQM">机器码</asp:ListItem>
                    <asp:ListItem Value="ENDTIME">到期时间</asp:ListItem>
                    <asp:ListItem Value="LTIME">最后登录时间</asp:ListItem>
                    <asp:ListItem Value="USERS">所属用户</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_USER_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="NOT LIKE">不包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_USER_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_USER_TJADD_Click" ID="GridView_USER_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="LinkButton_YQ" OnClick="LinkButton_YQ_Click"><i class="icon-time">&nbsp;全部延期</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_USER_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_USER_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_USER_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_USER_LinkButton3" OnClick="GridView_USER_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_USER_LinkButton4" OnClick="GridView_USER_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_USER" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_USER_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_USER_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_USER_SelectedIndexChanging" OnRowDataBound="GridView_USER_RowDataBound" OnRowDeleting="GridView_USER_RowDeleting" OnRowUpdating="GridView_USER_RowUpdating">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="JQMC" SortExpression="JQMC" HeaderText="机器名称"></asp:BoundField>
                            <asp:BoundField DataField="JQM" SortExpression="JQM" HeaderText="机器码"></asp:BoundField>
                            <asp:BoundField DataField="ENDTIME" SortExpression="ENDTIME" HeaderText="到期时间"></asp:BoundField>
                            <asp:BoundField DataField="LTIME" SortExpression="LTIME" HeaderText="最后登录时间"></asp:BoundField>
                            <asp:BoundField DataField="USERS" SortExpression="USERS" HeaderText="所属用户"></asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="LinkButton_Start" runat="server" CausesValidation="False" CommandName="Update" Text="&lt;i class='icon-time bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="GridView_USER_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_USER_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_USER_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_USER_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_USER_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_USER_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_USER_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
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

