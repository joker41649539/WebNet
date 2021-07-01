<%@ Page Title="" Language="C#" MasterPageFile="~/Ropot/MasterPage.master" AutoEventWireup="true" CodeFile="ComputerInfo.aspx.cs" Inherits="Ropot_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>BBGame
                <small>
                    <i class="icon-double-angle-right"></i>
                    电脑开通信息
                </small>
        </h1>
    </div>
    <div class="modal fade" id="GridView_Info_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>游戏信息								<small><i class="icon-double-angle-right"></i>添加新的游戏信息                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">电脑名称</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Info_TextBox_JQMC" runat="server" placeholder="请输入电脑名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">到期时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Info_TextBox_EndTime" runat="server" placeholder="请输入到期时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">登陆时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Info_TextBox_LTime" runat="server" placeholder="请输入登陆时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_Info_LinkButton1" class="btn btn-info" OnClick="GridView_Info_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                <h4 class="lighter"><i class="icon-user"></i>游戏信息                </h4>
                <asp:DropDownList ID="GridView_Info_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="JQMC">电脑名称</asp:ListItem>
                    <asp:ListItem Value="EndTime">到期时间</asp:ListItem>
                    <asp:ListItem Value="LTime">登陆时间</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Info_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Info_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Info_TJADD_Click" ID="GridView_Info_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Info_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Info_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Info_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Info_LinkButton3" OnClick="GridView_Info_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Info_LinkButton4" OnClick="GridView_Info_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Info" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_Info_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Info_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Info_SelectedIndexChanging" OnRowCancelingEdit="GridView_Info_RowCancelingEdit" OnRowEditing="GridView_Info_RowEditing" OnRowUpdating="GridView_Info_RowUpdating" OnRowCommand="GridView_Info_RowCommand" OnRowDataBound="GridView_Info_RowDataBound" OnRowDeleting="GridView_Info_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="JQMC" ReadOnly="true" SortExpression="JQMC" HeaderText="电脑名称"></asp:BoundField>
                            <asp:BoundField DataField="EndTime" SortExpression="EndTime" HeaderText="到期时间"></asp:BoundField>
                            <asp:BoundField DataField="LTime" ReadOnly="true" SortExpression="LTime" HeaderText="登陆时间"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="GridView_Info_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Info_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="GridView_Info_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Info_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
</asp:Content>

