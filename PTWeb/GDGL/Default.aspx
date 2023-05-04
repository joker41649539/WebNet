<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="GDGL_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li>工单管理</li>
            <li class="active"><a href="/GDGL/">工程工单</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>工单管理<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;工程工单</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a href="/GDGL/GCGDAdd.ASPX" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-legal bigger-130"></i>
                            <span class="bigger-110">新建工程工单</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-legal bigger-130"></i>
                        <span class="bigger-110">所有工程</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Table0">
                        <i class="red icon-legal bigger-130"></i>
                        <span class="bigger-110">等待施工</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Table2">
                        <i class="blue icon-legal bigger-130"></i>
                        <span class="bigger-110">暂停施工</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Table3">
                        <i class="green icon-legal bigger-130"></i>
                        <span class="bigger-110">正在施工</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Table4">
                        <i class="blue icon-legal bigger-130"></i>
                        <span class="bigger-110">完成施工</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Table5">
                        <i class="blue icon-legal bigger-130"></i>
                        <span class="bigger-110">未验收</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#Table1">
                        <i class="blue icon-legal bigger-130"></i>
                        <span class="bigger-110">完整工程</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="widget-header widget-header-flat">
                        <h4 class="lighter"><i class="icon-user"></i>工程工单                </h4>
                        <asp:DropDownList ID="GridView1_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                            <asp:ListItem Value="GCDD">工程地点</asp:ListItem>
                            <asp:ListItem Value="GCMC">工程名称</asp:ListItem>
                            <asp:ListItem Value="SGDH">手工单号</asp:ListItem>
                            <asp:ListItem Value="JFFZR">甲方负责人</asp:ListItem>
                            <asp:ListItem Value="FZRDH">甲方电话</asp:ListItem>
                            <asp:ListItem Value="ZDRID">乙方负责人</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="GridView1_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                            <asp:ListItem Value="LIKE">包含</asp:ListItem>
                            <asp:ListItem Value="=">等于</asp:ListItem>
                            <asp:ListItem Value="<>">不等于</asp:ListItem>
                            <asp:ListItem Value=">">大于</asp:ListItem>
                            <asp:ListItem Value="<">小于</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="GridView1_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                        <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView1_TJADD_Click" ID="GridView1_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                        <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                    </div>
                    <div id="GridView1_alerts_tj" runat="server" class="alert alert-success" visible="false">
                        <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                        <asp:Label ID="GridView1_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView1_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView1_LinkButton3" OnClick="GridView1_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                        <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView1_LinkButton4" OnClick="GridView1_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
<%--                                    <asp:BoundField DataField="JFFZR" SortExpression="JFFZR" HeaderText="甲方负责人"></asp:BoundField>
                                    <asp:BoundField DataField="JFDH" SortExpression="FZRDH" HeaderText="甲方电话"></asp:BoundField>
                                    <asp:BoundField DataField="CNAME" SortExpression="ZDRID" HeaderText="乙方负责人"></asp:BoundField>--%>
                                    <asp:BoundField DataField="SumFs" SortExpression="SumFs" HeaderText="状态"></asp:BoundField>
                                </Columns>
                                <PagerTemplate>
                                    <div>
                                        <ul class="pagination">
                                            <li>
                                                <asp:LinkButton ID="GridView1_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView1_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                            </li>
                                            <li class="active"><a href="#">
                                                <asp:Label ID="GridView1_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                /                                                   
                                                    <asp:Label ID="GridView1_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                            </a></li>
                                            <li>
                                                <asp:LinkButton ID="GridView1_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="GridView1_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </PagerTemplate>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
                <div id="Table0" class="tab-pane">
                    <div class="page-content">
                        <!--暂停施工 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_GC0" OnSelectedIndexChanging="GridView_GC0_SelectedIndexChanging" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_GC0_PageIndexChanging" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--等待施工 //-->
                    </div>
                </div>
                <div id="Table2" class="tab-pane">
                    <div class="page-content">
                        <!--暂停施工 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_GC2" OnSelectedIndexChanging="GridView_GC2_SelectedIndexChanging" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_GC2_PageIndexChanging" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--等待施工 //-->
                    </div>
                </div>
                <div id="Table3" class="tab-pane">
                    <div class="page-content">
                        <!--暂停施工 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_GC3" OnSelectedIndexChanging="GridView_GC3_SelectedIndexChanging" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_GC3_PageIndexChanging" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--等待施工 //-->
                    </div>
                </div>
                <div id="Table4" class="tab-pane">
                    <div class="page-content">
                        <!--暂停施工 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_GC4" OnSelectedIndexChanging="GridView_GC4_SelectedIndexChanging" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_GC4_PageIndexChanging" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--等待施工 //-->
                    </div>
                </div>
                <div id="Table5" class="tab-pane">
                    <div class="page-content">
                        <!--暂停施工 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_GC5" OnSelectedIndexChanging="GridView_GC5_SelectedIndexChanging" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_GC5_PageIndexChanging" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--等待施工 //-->
                    </div>
                </div>
                <div id="Table1" class="tab-pane">
                    <div class="page-content">
                        <!--暂停施工 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_GC1" OnSelectedIndexChanging="GridView_GC1_SelectedIndexChanging" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_GC1_PageIndexChanging" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" ClientIDMode="Static">
                                <Columns>
                                    <asp:ButtonField HeaderText="分配权限" CommandName="Select" SortExpression="ID" Text="分配权限" />
                                    <asp:BoundField DataField="Selected" SortExpression="Selected" HeaderText="工程人数"></asp:BoundField>
                                    <asp:HyperLinkField DataTextField="SGDH" HeaderText="手工单号" SortExpression="SGDH" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:HyperLinkField DataTextField="GCDD" HeaderText="工程地点" SortExpression="GCDD" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCGDAdd.ASPX?ID={0}" />
                                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--等待施工 //-->
                    </div>
                </div>
                <div id="Div1" runat="server" class="alert alert-success" visible="false">
                    <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                    <h5>预计工期：<asp:TextBox ID="TextBox2" Width="50px" runat="server"></asp:TextBox>
                        &nbsp;天&nbsp;&nbsp;<asp:LinkButton runat="server" OnClick="LinkButton2_Click" class="btn btn-white btn-sm" ID="LinkButton2"><i class="icon-save">&nbsp;保 存</i></asp:LinkButton></h5>
                    <h2>布线人员选择：</h2>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="10">
                        <asp:ListItem Value="1">人员1</asp:ListItem>
                        <asp:ListItem Value="2">人员2</asp:ListItem>
                        <asp:ListItem Value="3">人员3</asp:ListItem>
                    </asp:CheckBoxList>
                    <hr />
                    <h2>安装人员选择：</h2>
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatColumns="10">
                        <asp:ListItem Value="1">人员1</asp:ListItem>
                        <asp:ListItem Value="2">人员2</asp:ListItem>
                        <asp:ListItem Value="3">人员3</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="LinkButton1" OnClick="LinkButton1_Click"><i class="icon-save">&nbsp;保 存</i></asp:LinkButton>
                    <h2>负责人：</h2>
                    <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatColumns="10" runat="server">
                        <asp:ListItem>人员1</asp:ListItem>
                        <asp:ListItem>人员2</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

