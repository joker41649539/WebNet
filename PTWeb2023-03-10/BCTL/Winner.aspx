<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Winner.aspx.cs" Inherits="BCTL_Winner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">博彩套利</a>
            </li>
            <li class="active"><a href="/BCTL/Winner.aspx">盈利数据</a></li>
        </ul>
    </div>
    <div class="modal fade" id="GridView_Winner_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>盈利记录								<small><i class="icon-double-angle-right"></i>添加新的盈利记录                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">账号</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox_CardNo" runat="server" placeholder="请输入账号号码" class="col-xs-12 col-sm-12">1</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">存款金额</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Winner_TextBox_CKJE" runat="server" placeholder="请输入存款金额" class="col-xs-12 col-sm-12">1000</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">取款金额</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Winner_TextBox_QKJE" runat="server" placeholder="请输入取款金额" class="col-xs-12 col-sm-12">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">打码量</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Winner_TextBox_DML" runat="server" placeholder="请输入打码量" class="col-xs-12 col-sm-12">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">特别号金额</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Winner_TextBox_TBHJE" runat="server" placeholder="请输入特别号金额" class="col-xs-12 col-sm-12">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">反水比例</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Winner_TextBox_FSBL" runat="server" placeholder="请输入反水比例" class="col-xs-12 col-sm-12">1.2</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">日期</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Winner_TextBox_RQ" ClientIDMode="Static" runat="server" placeholder="请输入日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_Winner_LinkButton1" class="btn btn-info" OnClick="GridView_Winner_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                <h4 class="lighter"><i class="icon-save"></i>盈利记录                </h4>
                <asp:DropDownList ID="GridView_Winner_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="CKJE">存款金额</asp:ListItem>
                    <asp:ListItem Value="QKJE">取款金额</asp:ListItem>
                    <asp:ListItem Value="DML">打码量</asp:ListItem>
                    <asp:ListItem Value="TBHJE">特别号金额</asp:ListItem>
                    <asp:ListItem Value="FSBL">反水比例</asp:ListItem>
                    <asp:ListItem Value="RQ">日期</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Winner_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Winner_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Winner_TJADD_Click" ID="GridView_Winner_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Winner_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Winner_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Winner_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Winner_LinkButton3" OnClick="GridView_Winner_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Winner_LinkButton4" OnClick="GridView_Winner_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Winner" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Winner_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Winner_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Winner_SelectedIndexChanging" OnRowCommand="GridView_Winner_RowCommand" OnRowDataBound="GridView_Winner_RowDataBound" OnRowDeleting="GridView_Winner_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="CKJE" SortExpression="CKJE" HeaderText="存款金额"></asp:BoundField>
                            <asp:BoundField DataField="QKJE" SortExpression="QKJE" HeaderText="取款金额"></asp:BoundField>
                            <asp:BoundField DataField="DML" SortExpression="DML" HeaderText="打码量"></asp:BoundField>
                            <asp:BoundField DataField="TBHJE" SortExpression="TBHJE" HeaderText="特别号金额"></asp:BoundField>
                            <asp:BoundField DataField="FSBL" SortExpression="FSBL" HeaderText="反水比例"></asp:BoundField>
                            <asp:BoundField DataField="RQ" SortExpression="RQ" HeaderText="日期"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="GridView_Winner_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Winner_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Winner_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_Winner_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_Winner_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Winner_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Winner_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Winner_LinkButton_Add" runat="server" CommandName="GridView_Winner_ADD"><i class="icon-plus-sign">&nbsp;盈利记录添加</i></asp:LinkButton>
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
    <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>
    <script type='text/javascript'>$(function () { $('#GridView_Winner_TextBox_RQ').datepicker(); });</script>
</asp:Content>

