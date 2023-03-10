<%@ Page Title="系统模块编辑" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Sys_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="MKADD" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>系统模块
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    添加新的模块
                                </small>
                    </h1>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">模块ID</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox8" runat="server" placeholder="请输入模块ID" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">模块名称</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入模块名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">模块指向</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="请输入模块指向，不填默认为'#'" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr-24"></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">ICO图标</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="请输入ICO图标名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr-24"></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">菜单排序</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox4" runat="server" placeholder="请按规则输入菜单排序" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr-24"></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">层数</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox5" runat="server" placeholder="菜单层数" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr-24"></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">菜单显示</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox6" runat="server" placeholder="0为菜单显示，否则不显示" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr-24"></div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-info" OnClick="LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                        &nbsp; &nbsp; 
                        <button type="button" class="btn btn-default"
                            data-dismiss="modal">
                            <i class="icon-remove-sign bigger-110"></i>
                            关  闭
                        </button>

                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">系统管理</a></li>
            <li class="active"><a href="/SYS/">系统模块</a></li>
        </ul>
    </div>
    <div class="vspace-sm"></div>

    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter">
                    <i class="icon-qrcode"></i>
                    系统模块
                </h4>
                <asp:DropDownList ID="DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="MKMC">模块名称</asp:ListItem>
                    <asp:ListItem Value="MKZX">链接地址</asp:ListItem>
                    <asp:ListItem Value="ICO">ICO图标</asp:ListItem>
                    <asp:ListItem Value="JDPX">菜单排序</asp:ListItem>
                    <asp:ListItem Value="CS">菜单层数</asp:ListItem>
                    <asp:ListItem Value="SHOW">菜单显示</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox7" placeholder="条件内容" runat="server"></asp:TextBox>

                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="Unnamed1_Click" ID="TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar">
                    <a href="#" data-action="collapse">
                        <i class="icon-chevron-up"></i>
                    </a>
                </div>
            </div>
            <div id="alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Label ID="Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="LinkButton3" OnClick="LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="LinkButton4" OnClick="LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView1" runat="server"
                                class="table table-striped table-bordered table-hover no-margin-bottom no-border-top"
                                AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False"
                                OnSorting="GridView1_Sorting" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID"></asp:BoundField>
                                    <asp:BoundField DataField="MKMC" SortExpression="MKMC" HeaderText="模块名称"></asp:BoundField>
                                    <asp:BoundField DataField="MKZX" SortExpression="MKZX" HeaderText="链接地址"></asp:BoundField>
                                    <asp:BoundField DataField="ICO" SortExpression="ICO" HeaderText="ICO图标"></asp:BoundField>
                                    <asp:BoundField DataField="JDPX" SortExpression="JDPX" HeaderText="菜单排序"></asp:BoundField>
                                    <asp:BoundField DataField="CS" SortExpression="CS" HeaderText="菜单层数"></asp:BoundField>
                                    <asp:BoundField DataField="SHOW" SortExpression="SHOW" HeaderText="菜单显示"></asp:BoundField>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <div>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                                    CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li class="active">
                                                <a href="#">
                                                    <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                    /
                                                    <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                </a>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                            </li>
                                        </ul>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="LinkButton_Add" runat="server" CommandName="MKADD"><i class="icon-plus-sign">&nbsp;模块添加</i></asp:LinkButton>
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

