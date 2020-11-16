<%@ Page Title="记忆数据添加" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Remember_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a class="active" href="/">首页</a>
            </li>
            <li>
                <a href="/Remember/">记忆模块</a>
            </li>
            <li>
                <a href="#">记忆数据添加</a>
            </li>
        </ul>
    </div>
    <div class="modal fade" id="GridView_Remember_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>记忆训练								<small><i class="icon-double-angle-right"></i>添加新的记忆训练                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">分组号</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Remember_TextBox_iGroup" runat="server" placeholder="请输入分组号" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">记忆内容</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Remember_TextBox_nContent" runat="server" placeholder="请输入记忆内容" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注信息</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Remember_TextBox_nRemark" runat="server" placeholder="请输入备注信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">记忆时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Remember_TextBox_tRememberTime" runat="server" placeholder="请输入记忆时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">用户ID</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Remember_TextBox_iUserID" runat="server" placeholder="请输入用户ID" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_Remember_LinkButton1" class="btn btn-info" OnClick="GridView_Remember_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                <h4 class="lighter"><i class="icon-user"></i>记忆训练                </h4>
                <asp:DropDownList ID="GridView_Remember_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="iGroup">分组号</asp:ListItem>
                    <asp:ListItem Value="nContent">记忆内容</asp:ListItem>
                    <asp:ListItem Value="nRemark">备注信息</asp:ListItem>
                    <asp:ListItem Value="tRememberTime">记忆时间</asp:ListItem>
                    <asp:ListItem Value="iUserID">用户ID</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Remember_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Remember_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Remember_TJADD_Click" ID="GridView_Remember_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Remember_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Remember_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Remember_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Remember_LinkButton3" OnClick="GridView_Remember_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Remember_LinkButton4" OnClick="GridView_Remember_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Remember" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Remember_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Remember_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Remember_SelectedIndexChanging" OnRowCancelingEdit="GridView_Remember_RowCancelingEdit" OnRowEditing="GridView_Remember_RowEditing" OnRowUpdating="GridView_Remember_RowUpdating" OnRowCommand="GridView_Remember_RowCommand" OnRowDataBound="GridView_Remember_RowDataBound" OnRowDeleting="GridView_Remember_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="iGroup" SortExpression="iGroup" HeaderText="分组号"></asp:BoundField>
                            <asp:BoundField DataField="nContent" SortExpression="nContent" HeaderText="记忆内容"></asp:BoundField>
                            <asp:BoundField DataField="nRemark" SortExpression="nRemark" HeaderText="备注信息"></asp:BoundField>
                            <asp:BoundField DataField="tRememberTime" SortExpression="tRememberTime" HeaderText="记忆时间"></asp:BoundField>
                            <asp:BoundField DataField="iUserID" SortExpression="iUserID" HeaderText="用户ID"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="GridView_Remember_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Remember_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="GridView_Remember_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Remember_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Remember_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Remember_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_Remember_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_Remember_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Remember_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Remember_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Remember_LinkButton_Add" runat="server" CommandName="GridView_Remember_ADD"><i class="icon-plus-sign">&nbsp;记忆训练添加</i></asp:LinkButton>
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

