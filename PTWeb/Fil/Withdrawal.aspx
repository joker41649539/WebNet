<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="Withdrawal.aspx.cs" Inherits="Fil_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hr hr12 dotted"></div>
    <div class="profile-contact-info">
        <div class="profile-contact-links align-left">
            <a class="btn btn-link" href="#">
                <i class="icon-leaf bigger-120 pink"></i>
                f16obnrgqx7iidpikwwajzoero4dbgg52pbq2gini
            </a>

            <a class="btn btn-link" href="#">
                <i class="icon-comments bigger-120 green"></i>
                招商银行 陆晓钧
            </a>

            <a class="btn btn-link" href="#">
                <i class="icon-globe bigger-125 blue"></i>
                4392 2583 1101 4700
            </a>
        </div>
    </div>
    <div class="user-profile row height-auto">
        <div class="col-xs-12 col-sm-3 center">
            <div class="hr hr12 dotted"></div>
            <div class="clearfix">
                <div class="grid2">
                    <span class="bigger-175 blue">
                        <asp:Label ID="Label_Release" runat="server" Text="0"></asp:Label></span>
                    <br />
                    可提现
                </div>
                <div class="grid2">
                    <span class="bigger-175 blue">12</span>
                    <br />
                    正在提现
                </div>
            </div>
            <div class="hr hr16 dotted"></div>
        </div>
    </div>
    <div class="user-profile row height-auto">
        <div class="page-header">
            <h1>提现申请</h1>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">单据编号</label>
                <div class="col-sm-9">
                        <label runat="server" class="green" id="label_DH">TXD2021-02-24-0002</label>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">提取数量</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入提现数量" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">提取方式</label>
                <div class="col-sm-9">
                    <asp:RadioButtonList ID="RadioButtonList1" RepeatColumns="2" runat="server">
                        <asp:ListItem Selected="True">&nbsp;FIL&nbsp;</asp:ListItem>
                        <asp:ListItem>&nbsp;RMB(单价以实际交易金额为准)&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

