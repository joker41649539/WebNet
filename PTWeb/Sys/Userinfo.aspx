<%@ Page Title="系统用户管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Userinfo.aspx.cs" Inherits="Sys_Userinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">系统管理</a></li>
            <li class="active"><a href="/SYS/Userinfo.aspx">用户管理</a></li>
        </ul>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="MKADD" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>用户信息
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    添加新的用户
                                </small>
                    </h1>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">登录名</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入登录名" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">中文名</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="请输入中文名" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr-24"></div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">密码</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" placeholder="请输入登录密码" class="col-xs-12 col-sm-12"></asp:TextBox>
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
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter">
                    <i class="icon-user"></i>
                    用户信息
                </h4>
                <asp:DropDownList ID="DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="LOGINNAME">登录名</asp:ListItem>
                    <asp:ListItem Value="CNAME">姓名</asp:ListItem>
                    <asp:ListItem Value="PASSWORD">密码</asp:ListItem>
                    <asp:ListItem Value="FLAG">在用标志</asp:ListItem>
                    <asp:ListItem Value="CTIME">创建时间</asp:ListItem>
                    <asp:ListItem Value="LTIME">最后登录时间</asp:ListItem>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView1" runat="server"
                        class="table table-striped table-bordered table-hover no-margin-bottom no-border-top"
                        AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False"
                        OnSorting="GridView1_Sorting" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="LOGINNAME" SortExpression="LOGINNAME" HeaderText="登录名"></asp:BoundField>
                            <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="姓名"></asp:BoundField>
                            <asp:BoundField DataField="XB" SortExpression="XB" HeaderText="性别"></asp:BoundField>
                            <asp:BoundField DataField="SSDW" SortExpression="SSDW" HeaderText="默认机构"></asp:BoundField>
                            <asp:BoundField DataField="SSDZ" SortExpression="SSDZ" HeaderText="默认班级"></asp:BoundField>
                            <asp:BoundField DataField="ZW" SortExpression="ZW" HeaderText="职务"></asp:BoundField>
                            <asp:BoundField DataField="ZJHM" SortExpression="ZJHM" HeaderText="证件号码"></asp:BoundField>
                            <asp:BoundField DataField="PASSWORD" SortExpression="PASSWORD" HeaderText="密码"></asp:BoundField>
                            <asp:BoundField DataField="FLAG" SortExpression="FLAG" HeaderText="在用标志"></asp:BoundField>
                            <asp:BoundField DataField="CTIME" ReadOnly="true" SortExpression="CTIME" HeaderText="创建时间"></asp:BoundField>
                            <asp:BoundField DataField="LTIME" ReadOnly="true" SortExpression="LTIME" HeaderText="最后登录时间"></asp:BoundField>
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
                                        <asp:LinkButton ID="LinkButton_Add" runat="server" CommandName="MKADD"><i class="icon-plus-sign">&nbsp;用户添加</i></asp:LinkButton>
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

    <div class="modal fade" id="GridView_qxz_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>权限组								<small><i class="icon-double-angle-right"></i>添加新的权限组                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">组名称</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_qxz_TextBox_ZMC" runat="server" placeholder="请输入组名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">状态</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_qxz_TextBox_FLAG" runat="server" placeholder="请输入状态" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="GridView_qxz_LinkButton1" class="btn btn-info" OnClick="GridView_qxz_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-group"></i>权限组                </h4>
                <asp:DropDownList ID="GridView_qxz_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="ZMC">组名称</asp:ListItem>
                    <asp:ListItem Value="FLAG">状态</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_qxz_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_qxz_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_qxz_TJADD_Click" ID="GridView_qxz_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_qxz_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_qxz_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_qxz_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_qxz_LinkButton3" OnClick="GridView_qxz_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_qxz_LinkButton4" OnClick="GridView_qxz_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <asp:UpdatePanel ID="GridView_qxz_UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_qxz" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="true" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_qxz_Sorting" PageSize="1000" OnPageIndexChanging="GridView_qxz_PageIndexChanging" DataKeyNames="ID" OnRowCancelingEdit="GridView_qxz_RowCancelingEdit" OnRowEditing="GridView_qxz_RowEditing" OnRowUpdating="GridView_qxz_RowUpdating" OnRowCommand="GridView_qxz_RowCommand" OnRowDataBound="GridView_qxz_RowDataBound" OnRowDeleting="GridView_qxz_RowDeleting" OnSelectedIndexChanged="GridView_qxz_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:TemplateField HeaderText="组名称" SortExpression="ZMC">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ZMC") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" Checked='<%# Eval("ICHECK") %>' Text='<%# Eval("ZMC") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FLAG" SortExpression="FLAG" HeaderText="状态"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="GridView_qxz_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_qxz_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="GridView_qxz_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_qxz_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_qxz_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_qxz_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_qxz_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                                <asp:Label ID="GridView_qxz_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_qxz_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_qxz_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="GridView_qxz_Save"><i class="icon-save">&nbsp;保  存</i></asp:LinkButton>
                                        <asp:LinkButton ID="GridView_qxz_LinkButton_Add" runat="server" CommandName="GridView_qxz_ADD"><i class="icon-plus-sign">&nbsp;权限组添加</i></asp:LinkButton>
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
    

    <div class="col-sm-6">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-list"></i>功能模块</h4>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <!-- 引导菜单加载 开始 //-->
                    <div id="sidebar" runat="server" />
                    <!-- 引导菜单加载 结束 //-->
                </div>
                <ul class="pagination">
                    <li>
                        <asp:LinkButton ID="LinkButton_Save" runat="server" OnClick="LinkButton_Save_Click"><i class="icon-save">&nbsp;保  存</i></asp:LinkButton>
                    </li>
                </ul>

            </div>
        </div>
        <!-- /widget-box -->
    </div>
</asp:Content>

