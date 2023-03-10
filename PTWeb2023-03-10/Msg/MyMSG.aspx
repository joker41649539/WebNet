<%@ Page Title="我的消息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyMSG.aspx.cs" Inherits="Msg_MyMSG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li>消息管理</li>
            <li class="active">我的消息</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加消息</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">收到的消息</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">发出的消息</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="vspace-sm"></div>
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-inbox"></i>已收到的消息</h4>
                                <asp:DropDownList ID="GridView_MSG_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="CTITLE">标题</asp:ListItem>
                                    <asp:ListItem Value="CNAME">发送人</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_MSG_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_MSG_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_MSG_TJADD_Click" ID="GridView_MSG_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                            <div id="GridView_MSG_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                <asp:Label ID="GridView_MSG_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_MSG_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_MSG_LinkButton3" OnClick="GridView_MSG_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_MSG_LinkButton4" OnClick="GridView_MSG_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main no-padding">
                                    <asp:GridView ID="GridView_MSG" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_MSG_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_MSG_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_MSG_SelectedIndexChanging">
                                        <Columns>
                                            <asp:HyperLinkField SortExpression="cTitle" DataTextField="cTitle" HeaderText="标题" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/MSG/MSGINFO.aspx?ID={0}" />
                                            <asp:BoundField DataField="YYD" SortExpression="YYD" HeaderText="已阅读"></asp:BoundField>
                                            <asp:BoundField DataField="ZYD" SortExpression="ZYD" HeaderText="总人数"></asp:BoundField>
                                            <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="发送人"></asp:BoundField>
                                            <asp:BoundField DataField="CTIME" SortExpression="CTIME" HeaderText="时间"></asp:BoundField>
                                        </Columns>
                                        <PagerTemplate>
                                            <div>
                                                <ul class="pagination">
                                                    <li>
                                                        <asp:LinkButton ID="GridView_MSG_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_MSG_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="active"><a href="#">
                                                        <asp:Label ID="GridView_MSG_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                        /                                                   
                                                            <asp:Label ID="GridView_MSG_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                    </a></li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_MSG_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_MSG_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </PagerTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                            <!-- /widget-box -->
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        <div class="vspace-sm"></div>
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-location-arrow"></i>已发出的消息                </h4>
                                <asp:DropDownList ID="GridView_FXX_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="cTitle">标题</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_FXX_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_FXX_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_FXX_TJADD_Click" ID="GridView_FXX_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                            <div id="GridView_FXX_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                <asp:Label ID="GridView_FXX_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_FXX_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_FXX_LinkButton3" OnClick="GridView_FXX_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_FXX_LinkButton4" OnClick="GridView_FXX_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main no-padding">
                                    <asp:GridView ID="GridView_FXX" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_FXX_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_FXX_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_FXX_SelectedIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="cTitle" SortExpression="cTitle" HeaderText="标题"></asp:BoundField>
                                            <asp:BoundField DataField="YYD" SortExpression="YYD" HeaderText="已阅读"></asp:BoundField>
                                            <asp:BoundField DataField="ZYD" SortExpression="ZYD" HeaderText="总人数"></asp:BoundField>
                                            <asp:BoundField DataField="CTIME" SortExpression="CTIME" HeaderText="时间"></asp:BoundField>
                                        </Columns>
                                        <PagerTemplate>
                                            <div>
                                                <ul class="pagination">
                                                    <li>
                                                        <asp:LinkButton ID="GridView_FXX_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_FXX_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="active"><a href="#">
                                                        <asp:Label ID="GridView_FXX_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                        /                                                   
                                                            <asp:Label ID="GridView_FXX_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                    </a></li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_FXX_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_FXX_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </PagerTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                            <!-- /widget-box -->
                        </div>
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">发送对象</label>
                                    <div class="col-sm-9">
                                        <asp:CheckBox ID="CheckBox_AllMsg" runat="server" />
                                        <asp:Label ID="Label1" runat="server" Text="全部对象"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">消息标题</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_Title" runat="server" placeholder="请输入消息标题" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">消息内容</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_Content" runat="server" placeholder="请输入消息内容" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>

