<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="YZSQ.aspx.cs" Inherits="SQGL_YZSQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">授权管理</a></li>
            <li class="active"><a href="/SQGL/YZSQ.ASPX">印章授权</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>授权管理<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;印章授权</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加印章授权</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">已授权</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">待授权</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-user"></i>印章授权                </h4>
                                <asp:DropDownList ID="GridView_YZ_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="STitle">标题</asp:ListItem>
                                    <asp:ListItem Value="iflag">状态</asp:ListItem>
                                    <asp:ListItem Value="CNAME">申请人</asp:ListItem>
                                    <asp:ListItem Value="CTIME">申请时间</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_YZ_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_YZ_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_YZ_TJADD_Click" ID="GridView_YZ_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                            <div id="GridView_YZ_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                <asp:Label ID="GridView_YZ_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_YZ_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_YZ_LinkButton3" OnClick="GridView_YZ_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_YZ_LinkButton4" OnClick="GridView_YZ_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main no-padding">
                                    <asp:GridView ID="GridView_YZ" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_YZ_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_YZ_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_YZ_SelectedIndexChanging" OnRowCommand="GridView_YZ_RowCommand" OnRowDataBound="GridView_YZ_RowDataBound" OnRowDeleting="GridView_YZ_RowDeleting">
                                        <Columns>
                                            <asp:ButtonField DataTextField="STitle" HeaderText="标题" CommandName="Select" SortExpression="STitle" />
                                            <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="申请人"></asp:BoundField>
                                            <asp:BoundField DataField="CTIME" SortExpression="CTIME" DataFormatString="{0:yyyy-MM-dd}" HeaderText="申请时间"></asp:BoundField>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    &nbsp;<asp:LinkButton ID="GridView_YZ_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <div>
                                                <ul class="pagination">
                                                    <li>
                                                        <asp:LinkButton ID="GridView_YZ_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_YZ_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="active"><a href="#">
                                                        <asp:Label ID="GridView_YZ_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                        /                                                   
                                                            <asp:Label ID="GridView_YZ_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                    </a></li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_YZ_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_YZ_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
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
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        待授权
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="page-content">
                            <div class="page-header">
                                <h1>印章授权								<small><i class="icon-double-angle-right"></i>添加新的印章授权                                </small></h1>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标题</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="GridView_YZ_TextBox_cTitle" runat="server" placeholder="请输入标题" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">申请说明</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="GridView_YZ_TextBox_SQSM" runat="server" TextMode="MultiLine" placeholder="请输入申请说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix form-actions">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_YZ_LinkButton1" class="btn btn-info" OnClick="GridView_YZ_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                                    &nbsp; &nbsp;                        
                                            <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭                         </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

