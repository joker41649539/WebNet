<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DelJFList.aspx.cs" Inherits="GDGL_DelJFList" %>

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
            <h1>工单管理<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;积分删除信息列表</small></h1>
        </div>
        <div class="widget-main no-padding">
            <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="GCMC" SortExpression="GCMC" HeaderText="工程名称"></asp:BoundField>
                    <asp:BoundField DataField="AZWZ" SortExpression="AZWZ" HeaderText="安装位置"></asp:BoundField>
                    <asp:BoundField DataField="SBMC" SortExpression="SBMC" HeaderText="设备名称"></asp:BoundField>
                    <asp:BoundField DataField="DelMan" SortExpression="DelMan" HeaderText="被删除"></asp:BoundField>
                    <asp:BoundField DataField="FS" SortExpression="FS" HeaderText="删除比例"></asp:BoundField>
                    <asp:BoundField DataField="Operator" SortExpression="Operator" HeaderText="删除人"></asp:BoundField>
                    <asp:BoundField DataField="CTime" SortExpression="CTime" HeaderText="删除日期"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

