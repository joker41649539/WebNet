<%@ Page Title="教育机构" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="JYJG_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">教育机构</a></li>
            <li class="active"><a href="/JYJG/Default.aspx">机构管理</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>教育机构								<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;机构管理                                </small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加机构</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">待审核机构</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">已审核机构</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="widget-box transparent">
                                <div class="widget-header widget-header-flat">
                                    <h4 class="lighter"><i class="icon-user"></i>教育机构                </h4>
                                    <asp:DropDownList ID="GridView_JG_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                        <asp:ListItem Value="JGQC">机构全称</asp:ListItem>
                                        <asp:ListItem Value="JGJC">机构简称</asp:ListItem>
                                        <asp:ListItem Value="LXDH">联系电话</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="GridView_JG_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                        <asp:ListItem Value="=">等于</asp:ListItem>
                                        <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                        <asp:ListItem Value="<>">不等于</asp:ListItem>
                                        <asp:ListItem Value=">">大于</asp:ListItem>
                                        <asp:ListItem Value="<">小于</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="GridView_JG_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_JG_TJADD_Click" ID="GridView_JG_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                    <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                                </div>
                                <div id="GridView_JG_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                    <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                    <asp:Label ID="GridView_JG_Label1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="GridView_JG_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_JG_LinkButton3" OnClick="GridView_JG_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_JG_LinkButton4" OnClick="GridView_JG_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main no-padding">
                                        <asp:GridView ID="GridView_JG" runat="server" ClientIDMode="Static" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_JG_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_JG_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_JG_SelectedIndexChanging" OnRowCancelingEdit="GridView_JG_RowCancelingEdit" OnRowEditing="GridView_JG_RowEditing" OnRowUpdating="GridView_JG_RowUpdating" OnRowCommand="GridView_JG_RowCommand" OnRowDataBound="GridView_JG_RowDataBound" OnRowDeleting="GridView_JG_RowDeleting">
                                            <Columns>
                                                <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                                <asp:BoundField DataField="JGQC" SortExpression="JGQC" HeaderText="机构全称"></asp:BoundField>
                                                <asp:BoundField DataField="JGJC" SortExpression="JGJC" HeaderText="机构简称"></asp:BoundField>
                                                <asp:BoundField DataField="LOGO" SortExpression="LOGO" HeaderText="LOGO"></asp:BoundField>
                                                <asp:BoundField DataField="Flag" SortExpression="Flag" ReadOnly="true" HeaderText="状态"></asp:BoundField>
                                                <asp:BoundField DataField="LXDH" SortExpression="LXDH" HeaderText="联系电话"></asp:BoundField>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="GridView_JG_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-check bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <div>
                                                    <ul class="pagination">
                                                        <li>
                                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                        </li>
                                                        <li class="active"><a href="#">
                                                            <asp:Label ID="GridView_JG_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                            /                                                   
                                                            <asp:Label ID="GridView_JG_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                        </a></li>
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
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
                <div id="sent" class="tab-pane">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="widget-box transparent">
                                <div class="widget-header widget-header-flat">
                                    <h4 class="lighter"><i class="icon-user"></i>教育机构                </h4>
                                    <asp:DropDownList ID="GridView_JG_F_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                        <asp:ListItem Value="JGQC">机构全称</asp:ListItem>
                                        <asp:ListItem Value="JGJC">机构简称</asp:ListItem>
                                        <asp:ListItem Value="LOGO">LOGO</asp:ListItem>
                                        <asp:ListItem Value="LXDH">联系电话</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="GridView_JG_F_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                        <asp:ListItem Value="=">等于</asp:ListItem>
                                        <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                        <asp:ListItem Value="<>">不等于</asp:ListItem>
                                        <asp:ListItem Value=">">大于</asp:ListItem>
                                        <asp:ListItem Value="<">小于</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="GridView_JG_F_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_JG_F_TJADD_Click" ID="GridView_JG_F_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                    <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                                </div>
                                <div id="GridView_JG_F_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                    <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                    <asp:Label ID="GridView_JG_F_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_JG_F_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_JG_F_LinkButton3" OnClick="GridView_JG_F_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_JG_F_LinkButton4" OnClick="GridView_JG_F_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main no-padding">
                                        <asp:GridView ID="GridView_JG_F" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_JG_F_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_JG_F_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_JG_F_SelectedIndexChanging" OnRowCancelingEdit="GridView_JG_F_RowCancelingEdit" OnRowEditing="GridView_JG_F_RowEditing" OnRowUpdating="GridView_JG_F_RowUpdating" OnRowDataBound="GridView_JG_F_RowDataBound" OnRowDeleting="GridView_JG_F_RowDeleting">
                                            <Columns>
                                                <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                                <asp:BoundField DataField="JGQC" SortExpression="JGQC" HeaderText="机构全称"></asp:BoundField>
                                                <asp:BoundField DataField="JGJC" SortExpression="JGJC" HeaderText="机构简称"></asp:BoundField>
                                                <asp:BoundField DataField="LOGO" SortExpression="LOGO" HeaderText="LOGO"></asp:BoundField>
                                                <asp:BoundField DataField="LXDH" SortExpression="LXDH" HeaderText="联系电话"></asp:BoundField>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="GridView_JG_F_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="GridView_JG_F_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="GridView_JG_F_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="GridView_JG_F_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <div>
                                                    <ul class="pagination">
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_F_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_F_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                        </li>
                                                        <li class="active"><a href="#">
                                                            <asp:Label ID="GridView_JG_F_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                            /                                                   
                                        <asp:Label ID="GridView_JG_F_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                        </a></li>
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_F_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="GridView_JG_F_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </PagerTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机构全称</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="GridView_JG_TextBox_JGQC" runat="server" placeholder="请输入机构全称" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机构简称</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="GridView_JG_TextBox_JGJC" runat="server" placeholder="请输入机构简称" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机构简介</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="GridView_JG_TextBox_JGJJ" runat="server" TextMode="MultiLine" placeholder="请输入机构简介" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">LOGO</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="GridView_JG_TextBox_LOGO" runat="server" placeholder="请输入LOGO" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">联系电话</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="GridView_JG_TextBox_LXDH" runat="server" placeholder="请输入联系电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix form-actions">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_JG_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_JG_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                                &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭</button>
                            </div>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
            </div>
        </div>
    </div>

    <script>
        // 字符替换
        $("#GridView_JG tr").each(function () {
            var mtd = $(this).children("td:eq(4)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-danger\">待审核</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-success\">已审核</span>");
            }
            else if (mtd.text() == 2) {
                mtd.html(" <span class=\"label label-warning\">已过期</span>");
            }
        });
    </script>
</asp:Content>

