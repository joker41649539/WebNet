<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="Agent.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>手机号码</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_PhoneNo" ClientIDMode="Static" runat="server" placeholder="请输入手机号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="space-10"></div>
                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-block btn-success" runat="server"><i class="icon-search"></i>&nbsp;代理信息查询</asp:LinkButton>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="space-10"></div>
            <asp:GridView class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField="PhoneNo" HeaderText="电话"></asp:BoundField>
                    <asp:BoundField DataField="Levels" HeaderText="级别"></asp:BoundField>
                    <asp:BoundField DataField="CTime" DataFormatString="{0: yyyy-MM-dd HH:mm}" HeaderText="时间"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

