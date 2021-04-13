<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="Withdrawal.aspx.cs" Inherits="Fil_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="user-profile row height-auto">
        <div class="col-xs-12 col-sm-3 center">
            <div class="hr hr12 dotted"></div>
            <div class="clearfix">
                <div class="grid2">
                    <span class="bigger-175 blue">
                        <asp:Label ID="Label_Release" runat="server" Text="0"></asp:Label></span>
                    <br />
                    可提现(Fil)
                </div>
                <div class="grid2">
                    <span class="bigger-175 blue">0</span>
                    <br />
                    正在提现(Fil)
                </div>
                <div class="grid2">
                    <span class="bigger-175 blue">0</span>
                    <br />
                    已提现(Fil)
                </div>
                <%--<div class="grid2">
                    <span class="bigger-175 blue"><a href="#">0</a></span>
                    <br />
                    <a href="#">已提现现金(CNY)</a>
                </div>--%>
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
                    <label runat="server" class="green" id="label_DH">待生成</label>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">提币地址</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="请输入钱包地址" class="col-xs-12 col-sm-12"></asp:TextBox>
                    <h5 class="red">请确认您的提币地址。</h5>
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
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注说明</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" TextMode="MultiLine" runat="server" placeholder="如有特别要求，请填写。" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <hr />
        <div class="col-xs-12">
            <h5 class="red">温馨提示：</h5>
            <h5 class="red">您的提币操作一旦完成，对应的资产所有权将由您变更为目标地址所对应的账户所有人享有。不可逆！！！</h5>
            <p>
                <asp:Button ID="Button1" class="btn btn-success btn-block" runat="server" Text="确认提交" />
            </p>
        </div>
    </div>
</asp:Content>

