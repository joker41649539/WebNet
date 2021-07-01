<%@ Page Title="" Language="C#" MasterPageFile="~/Ropot/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Ropot_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>BBGame
                <small>
                    <i class="icon-double-angle-right"></i>
                    即时游戏信息
                </small>
        </h1>
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>游戏信息                </h4>
                <asp:DropDownList ID="GridView_Info_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="ComputerName">电脑名称</asp:ListItem>
                    <asp:ListItem Value="Remark">备注信息</asp:ListItem>
                    <asp:ListItem Value="Balance">余额</asp:ListItem>
                    <asp:ListItem Value="LTime">更新时间</asp:ListItem>
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
                    <asp:GridView ID="GridView_Info" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView_Info_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Info_Sorting" OnSelectedIndexChanging="GridView_Info_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ComputerName" SortExpression="ComputerName" HeaderText="电脑名称"></asp:BoundField>
                            <asp:BoundField DataField="Remark" SortExpression="Remark" HeaderText="备注信息"></asp:BoundField>
                            <asp:BoundField DataField="Balance" SortExpression="Balance" HeaderText="余额"></asp:BoundField>
                            <asp:BoundField DataField="LTime" SortExpression="LTime" HeaderText="更新时间"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
</asp:Content>

