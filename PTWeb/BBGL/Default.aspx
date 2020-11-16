<%@ Page Title="报表管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BBGL_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">统计报表</a></li>
            <li class="active"><a href="/BBGL/Default.aspx">报表管理</a></li>
        </ul>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="GridView_Report_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>报表列表								<small><i class="icon-double-angle-right"></i>添加新的报表列表                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报表名称</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_TextBox_CNAME" runat="server" placeholder="请输入报表名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报表文件名</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_TextBox_CFILENAME" runat="server" placeholder="请输入报表文件名" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报表类型</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_TextBox_NCLASS" runat="server" placeholder="请输入报表类型" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">显示否</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_TextBox_ISHOW" runat="server" placeholder="请输入显示否" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">排序</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_TextBox_IPX" runat="server" placeholder="请输入排序" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="GridView_Report_LinkButton1" class="btn btn-info" OnClick="GridView_Report_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                        &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭                         </button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-bar-chart"></i>报表列表</h4>
                <asp:DropDownList ID="GridView_Report_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="CNAME">报表名称</asp:ListItem>
                    <asp:ListItem Value="CFILENAME">报表文件名</asp:ListItem>
                    <asp:ListItem Value="NCLASS">报表类型</asp:ListItem>
                    <asp:ListItem Value="ISHOW">显示否</asp:ListItem>
                    <asp:ListItem Value="IPX">排序</asp:ListItem>
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
                            <asp:GridView ID="GridView_Report" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Report_Sorting" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Report_PageIndexChanging" DataKeyNames="ID" OnRowCancelingEdit="GridView_Report_RowCancelingEdit" OnRowEditing="GridView_Report_RowEditing" OnRowUpdating="GridView_Report_RowUpdating" OnRowCommand="GridView_Report_RowCommand" OnRowDataBound="GridView_Report_RowDataBound" OnRowDeleting="GridView_Report_RowDeleting" OnSelectedIndexChanged="GridView_Report_SelectedIndexChanged">
                                <Columns>
                                    <asp:ButtonField HeaderText="选 择" CommandName="Select" Text="选 择" />
                                    <asp:HyperLinkField DataNavigateUrlFormatString="BBSHOW.ASPX?ID={0}" HeaderText="查 看" Text="查 看" DataNavigateUrlFields="ID" />
                                    <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="报表名称"></asp:BoundField>
                                    <asp:BoundField DataField="CFILENAME" SortExpression="CFILENAME" HeaderText="报表文件名"></asp:BoundField>
                                    <asp:BoundField DataField="NCLASS" SortExpression="NCLASS" HeaderText="报表类型"></asp:BoundField>
                                    <asp:BoundField DataField="ISHOW" SortExpression="ISHOW" HeaderText="显示否"></asp:BoundField>
                                    <asp:BoundField DataField="IPX" SortExpression="IPX" HeaderText="排序"></asp:BoundField>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="GridView_Report_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="GridView_Report_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="GridView_Report_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="GridView_Report_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_LinkButton_Add" runat="server" CommandName="GridView_Report_ADD"><i class="icon-plus-sign">&nbsp;报表列表添加</i></asp:LinkButton>
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

    <div class="modal fade" id="GridView_Report_ZB_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>报表条件								<small><i class="icon-double-angle-right"></i>添加新的报表条件                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">中文名</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_ZB_TextBox_CNAME" runat="server" placeholder="请输入中文名" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">英文名</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_ZB_TextBox_CENAME" runat="server" placeholder="请输入英文名" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">显示否</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_ZB_TextBox_ISHOW" runat="server" placeholder="请输入显示否" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">排序</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Report_ZB_TextBox_IPX" runat="server" placeholder="请输入排序" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="GridView_Report_ZB_LinkButton1" class="btn btn-info" OnClick="GridView_Report_ZB_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                        &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭                         </button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-6">
        <div class="widget-box transparent">
            <asp:UpdatePanel ID="GridView_Report_ZB_UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Report_ZB" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Report_ZB_Sorting" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Report_ZB_PageIndexChanging" DataKeyNames="ID" OnRowCancelingEdit="GridView_Report_ZB_RowCancelingEdit" OnRowEditing="GridView_Report_ZB_RowEditing" OnRowUpdating="GridView_Report_ZB_RowUpdating" OnRowCommand="GridView_Report_ZB_RowCommand" OnRowDataBound="GridView_Report_ZB_RowDataBound" OnRowDeleting="GridView_Report_ZB_RowDeleting" OnSelectedIndexChanging="GridView_Report_ZB_SelectedIndexChanging">
                                <Columns>
                                    <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                    <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="中文名"></asp:BoundField>
                                    <asp:BoundField DataField="CENAME" SortExpression="CENAME" HeaderText="英文名"></asp:BoundField>
                                    <asp:BoundField DataField="ISHOW" SortExpression="ISHOW" HeaderText="显示否"></asp:BoundField>
                                    <asp:BoundField DataField="IPX" SortExpression="IPX" HeaderText="排序"></asp:BoundField>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="GridView_Report_ZB_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="GridView_Report_ZB_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="GridView_Report_ZB_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="GridView_Report_ZB_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <div>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_ZB_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_ZB_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li class="active"><a href="#">
                                                <asp:Label ID="GridView_Report_ZB_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                /                                                   
                                                <asp:Label ID="GridView_Report_ZB_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                            </a></li>
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_ZB_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_ZB_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                            </li>
                                        </ul>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView_Report_ZB_LinkButton_Add" runat="server" CommandName="GridView_Report_ZB_ADD"><i class="icon-plus-sign">&nbsp;报表条件添加</i></asp:LinkButton>
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

    <div class="col-sm-6">
        <div class="widget-box transparent">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" AllowPaging="True" AllowSorting="True" OnSorting="GridView_Report_ZB_Sorting" DataKeyNames="ID" OnRowCancelingEdit="GridView_Report_ZB_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="权限组名称" SortExpression="ZMC">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" Checked='<%# Eval("ICHECK") %>' Text='<%# Eval("ZMC") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <div>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView1_Save" runat="server" CommandName="GridView1_Save"><i class="icon-save">&nbsp;保  存</i></asp:LinkButton>
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

