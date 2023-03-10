<%@ Page Title="通用代码" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TYDM.aspx.cs" Inherits="Sys_TYDM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">系统设置</a></li>
            <li class="active"><a href="/SYS/TYDM.aspx">通用代码</a></li>
        </ul>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="GridView_TYDM_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>通用代码								<small><i class="icon-double-angle-right"></i>添加新的通用代码                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">代码名称</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_TYDM_TextBox_CTYDMC" runat="server" placeholder="请输入代码名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">代码值</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_TYDM_TextBox_CTYDMZ" runat="server" placeholder="请输入代码值" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">代码类别</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_TYDM_TextBox_ITYDMLB" runat="server" placeholder="请输入代码类别" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="GridView_TYDM_LinkButton1" class="btn btn-info" OnClick="GridView_TYDM_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                <h4 class="lighter"><i class="icon-gears"></i>通用代码                </h4>
                <asp:DropDownList ID="GridView_TYDM_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="CTYDMC">代码名称</asp:ListItem>
                    <asp:ListItem Value="CTYDMZ">代码值</asp:ListItem>
                    <asp:ListItem Value="ITYDMLB">代码类别</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_TYDM_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_TYDM_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_TYDM_TJADD_Click" ID="GridView_TYDM_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_TYDM_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_TYDM_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_TYDM_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_TYDM_LinkButton3" OnClick="GridView_TYDM_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_TYDM_LinkButton4" OnClick="GridView_TYDM_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <asp:UpdatePanel ID="GridView_TYDM_UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_TYDM" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_TYDM_Sorting" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_TYDM_PageIndexChanging" DataKeyNames="ID" OnRowCancelingEdit="GridView_TYDM_RowCancelingEdit" OnRowEditing="GridView_TYDM_RowEditing" OnRowUpdating="GridView_TYDM_RowUpdating" OnRowCommand="GridView_TYDM_RowCommand" OnRowDataBound="GridView_TYDM_RowDataBound" OnRowDeleting="GridView_TYDM_RowDeleting" OnSelectedIndexChanging="GridView_TYDM_SelectedIndexChanging">
                                <Columns>
                                    <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                    <asp:BoundField DataField="CTYDMC" SortExpression="CTYDMC" HeaderText="代码名称"></asp:BoundField>
                                    <asp:BoundField DataField="CTYDMZ" SortExpression="CTYDMZ" HeaderText="代码值"></asp:BoundField>
                                    <asp:BoundField DataField="ITYDMLB" SortExpression="ITYDMLB" HeaderText="代码类别"></asp:BoundField>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="GridView_TYDM_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="GridView_TYDM_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="GridView_TYDM_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="GridView_TYDM_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <div>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView_TYDM_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView_TYDM_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li class="active"><a href="#">
                                                <asp:Label ID="GridView_TYDM_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                /                                                   
                                                <asp:Label ID="GridView_TYDM_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                            </a></li>
                                            <li>
                                                <asp:LinkButton ID="GridView_TYDM_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView_TYDM_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                            </li>
                                        </ul>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView_TYDM_LinkButton_Add" runat="server" CommandName="GridView_TYDM_ADD"><i class="icon-plus-sign">&nbsp;通用代码添加</i></asp:LinkButton>
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

