<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QDSearch.aspx.cs" Inherits="YGGL_QDGL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li>员工管理</li>
            <li class="active"><a href="/YGGL/QDSearch.ASPX">签到查询</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-search bigger-130"></i>
                        <span class="bigger-110">签到查询</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="row">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-search"></i>查询条件</h4>
                                <asp:DropDownList ID="GridView_MSG_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="W_KQ.Ctime">日期</asp:ListItem>
                                    <asp:ListItem Value="CNAME">姓名</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_MSG_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_MSG_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_MSG_TJADD" OnClick="GridView_MSG_TJADD_Click"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div id="GridView_FXX_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                    <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                    <asp:Label ID="GridView_MSG_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_MSG_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_FXX_LinkButton3" OnClick="GridView_FXX_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_FXX_LinkButton4" OnClick="GridView_FXX_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="hr-10"></div>
                            <div id="QDList" runat="server" class="timeline-container">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

