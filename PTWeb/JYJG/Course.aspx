<%@ Page Title="课程设置" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="JYJG_Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">教育机构</a></li>
            <li class="active"><a href="#">课程设置</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>教育机构<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;课程设置</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加课程</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">正在开课</span>
                    </a>
                </li>
                <%--<li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">暂未开课</span>
                    </a>
                </li>--%>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <!-- 正在开课 开始 //-->
                    <div class="page-content">
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-user"></i>开设课程                </h4>
                                <asp:DropDownList ID="GridView_KC_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="JGJC">机构名称</asp:ListItem>
                                    <asp:ListItem Value="KCMC">课程名称</asp:ListItem>
                                    <asp:ListItem Value="LJKS">累计课时</asp:ListItem>
                                    <asp:ListItem Value="BJ">开设班级</asp:ListItem>
                                    <asp:ListItem Value="FLAG">状态</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_KC_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_KC_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_KC_TJADD_Click" ID="GridView_KC_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                            <div id="GridView_KC_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                <asp:Label ID="GridView_KC_Label1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="GridView_KC_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_KC_LinkButton3" OnClick="GridView_KC_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_KC_LinkButton4" OnClick="GridView_KC_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main no-padding">
                                    <asp:GridView ID="GridView_KC" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_KC_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_KC_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_KC_SelectedIndexChanging" OnRowCancelingEdit="GridView_KC_RowCancelingEdit" OnRowEditing="GridView_KC_RowEditing" OnRowUpdating="GridView_KC_RowUpdating" OnRowDataBound="GridView_KC_RowDataBound" OnRowDeleting="GridView_KC_RowDeleting">
                                        <Columns>
                                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                            <asp:BoundField DataField="JGJC" SortExpression="JGJC" HeaderText="机构名称"></asp:BoundField>
                                            <asp:BoundField DataField="KCMC" SortExpression="KCMC" HeaderText="课程名称"></asp:BoundField>
                                            <asp:BoundField DataField="LJKS" SortExpression="LJKS" HeaderText="累计课时"></asp:BoundField>
                                            <asp:BoundField DataField="BJ" SortExpression="BJ" HeaderText="开设班级"></asp:BoundField>
                                            <asp:BoundField DataField="FLAG" SortExpression="FLAG" ReadOnly="true" HeaderText="状态"></asp:BoundField>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="GridView_KC_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <div>
                                                <ul class="pagination">
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_KC_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="active"><a href="#">
                                                        <asp:Label ID="GridView_KC_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                        /                                                   
                                                        <asp:Label ID="GridView_KC_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                    </a></li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_KC_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="GridView_KC_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </PagerTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- 正在开课 结束//-->
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        测试111
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">所属机构</label>
                                    <div class="col-sm-9">
                                        <div class="page-header">
                                            <h1>
                                                <asp:Label ID="Label_JGJC" runat="server" class="col-xs-12 col-sm-12" Text="机构简称"></asp:Label>
                                                <asp:Label ID="Label_JGID" runat="server" Text="0" Visible="false"></asp:Label>
                                            </h1>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">课程名称</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_KCMC" runat="server" placeholder="请输入课程名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">累计课时</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_LJKS" runat="server" placeholder="请输入累计课时(数字),如输入0或不输入则无课时限制" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">课程简介</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_KCJJ" runat="server" TextMode="MultiLine" placeholder="请输入课程简介" class="col-xs-12 col-sm-12"></asp:TextBox>
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

