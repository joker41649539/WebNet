<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoldRecords.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>开始日期</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_DataS" runat="server" placeholder="请输入开始日期" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>截止日期</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_DataE" runat="server" placeholder="请输入截止日期" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <br />
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-success btn-block" runat="server"><i class="icon-search"></i>&nbsp;查询</asp:LinkButton>
        </div>
    </div>
    <div class="col-xs-12">
        <asp:GridView DataKeyNames="ID" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView_Goods" ClientIDMode="Static" runat="server">
            <Columns>
                <asp:BoundField DataField="UserNO" HeaderText="用户"></asp:BoundField>
                <%--                <asp:BoundField DataField="HolderID" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="卖家"></asp:BoundField>--%>
                <asp:BoundField DataField="Bance" HeaderText="数量"></asp:BoundField>
                <asp:BoundField DataField="Operator" HeaderText="操作"></asp:BoundField>
                <asp:BoundField DataField="Event" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="状态"></asp:BoundField>
                <asp:BoundField DataField="CTime" DataFormatString="{0:MM-dd HH:mm}" HeaderText="时间"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <h5>合计：<asp:Label ID="Label_Sum" runat="server" Text="0.00"></asp:Label></h5>
    </div>
</asp:Content>

