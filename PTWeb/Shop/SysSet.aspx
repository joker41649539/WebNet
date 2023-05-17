<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="SysSet.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>金豆手续费</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入金豆的手续费比如0.05为5%" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>回购时长</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入多少秒后自动回购" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>回购账号设置</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入用于回购的账号(用';'隔开)" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>每日增长幅度</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" placeholder="请输入每日增长幅度(0.05为5%)" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>抢购开始时间</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" placeholder="请输入每日开抢时间(9:00)" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <br />
        <asp:HyperLink ID="HyperLink2" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;确认系统设置</asp:HyperLink>
        <br />
    </div>
</asp:Content>

