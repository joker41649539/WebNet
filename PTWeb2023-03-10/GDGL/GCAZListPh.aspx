<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCAZListPh.aspx.cs" Inherits="GCAZListPh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyAZGD.aspx">我的安装工程</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>
            <asp:HyperLink ID="Label_GCMC" runat="server">HyperLink</asp:HyperLink><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;<asp:Label ID="Label_AZWZ" runat="server" Text="Label"></asp:Label></small></h1>
    </div>
    <div class="tabbable">
        <div class="widget-box transparent">
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_List" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_List_Sorting" DataKeyNames="ID"  OnRowCommand="GridView_List_RowCommand" OnRowDeleting="GridView_List_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="SBBH" HeaderText="编号" CommandName="update" SortExpression="编号" Text="按钮" />
                            <asp:BoundField DataField="ZAZ" SortExpression="ZAZ" HeaderText="主装"></asp:BoundField>
                            <asp:BoundField DataField="FAZ" SortExpression="FAZ" HeaderText="辅装"></asp:BoundField>
                            <asp:CommandField EditText="编辑" DeleteText="主装" NewText="辅装" SelectText="取消" ShowDeleteButton="True" ShowHeader="True" ShowInsertButton="True" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
        <!-- /widget-box -->
    </div>

</asp:Content>

