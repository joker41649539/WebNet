<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="Withdrawal.aspx.cs" Inherits="Fil_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hr hr12 dotted"></div>
    <div class="profile-contact-info">
        <div class="profile-contact-links align-left">
            <a class="btn btn-link" href="#">
                <i class="icon-leaf bigger-120 pink"></i>
                安徽黑瞳信息科技有限责任公司
            </a>

            <a class="btn btn-link" href="#">
                <i class="icon-comments bigger-120 green"></i>
                18019961118
            </a>

            <a class="btn btn-link" href="#">
                <i class="icon-globe bigger-125 blue"></i>
                合肥市财富广场2006室
            </a>
        </div>
    </div>
    <div class="user-profile row height-auto">
        <div class="col-xs-12 col-sm-3 center">
            <div class="hr hr12 dotted"></div>
            <div class="clearfix">
                <div class="grid2">
                    <span class="bigger-175 blue">5</span>
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
            <h1>我要提现								<small><i class="icon-double-angle-right"></i>&nbsp;添写提现申请                                </small></h1>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">手工编号</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_SGBH" runat="server" placeholder="请输入手工编号" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

