<%@ Page Title="Boey信息添加" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddBoey.aspx.cs" Inherits="School_AddBoey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li class="active"><a href="/School/AddBoey.aspx">Boey信息添加</a></li>
        </ul>
    </div>
    <div class="modal fade" id="GridView_Boey_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>Boey信息								<small><i class="icon-double-angle-right"></i>添加新的Boey信息                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">图片类别</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Boey_TextBox_Class" runat="server" placeholder="请输入图片类别" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">图片地址</label>
                            <div class="col-sm-9">
                                <asp:FileUpload ID="FileUpload_TP" ClientIDMode="Static" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">说明</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Boey_TextBox_Remark" runat="server" placeholder="请输入说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_Boey_LinkButton1" class="btn btn-info" OnClick="GridView_Boey_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                <h4 class="lighter"><i class="icon-user"></i>Boey信息                </h4>
                <asp:DropDownList ID="GridView_Boey_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="Class">图片类别</asp:ListItem>
                    <asp:ListItem Value="ImgUrl">图片地址</asp:ListItem>
                    <asp:ListItem Value="Remark">说明</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Boey_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Boey_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Boey_TJADD_Click" ID="GridView_Boey_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Boey_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Boey_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Boey_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Boey_LinkButton3" OnClick="GridView_Boey_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Boey_LinkButton4" OnClick="GridView_Boey_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Boey" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Boey_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Boey_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Boey_SelectedIndexChanging" OnRowCancelingEdit="GridView_Boey_RowCancelingEdit" OnRowEditing="GridView_Boey_RowEditing" OnRowUpdating="GridView_Boey_RowUpdating" OnRowCommand="GridView_Boey_RowCommand" OnRowDataBound="GridView_Boey_RowDataBound" OnRowDeleting="GridView_Boey_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="Class" SortExpression="Class" HeaderText="图片类别"></asp:BoundField>
                            <asp:BoundField DataField="ImgUrl" SortExpression="ImgUrl" HeaderText="图片地址"></asp:BoundField>
                            <asp:BoundField DataField="Remark" SortExpression="Remark" HeaderText="说明"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="GridView_Boey_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Boey_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="GridView_Boey_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Boey_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Boey_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Boey_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_Boey_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_Boey_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Boey_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Boey_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Boey_LinkButton_Add" runat="server" CommandName="GridView_Boey_ADD"><i class="icon-plus-sign">&nbsp;Boey信息添加</i></asp:LinkButton>
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

