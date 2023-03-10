<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PartnerRemarkAdd.aspx.cs" Inherits="Partner_PartnerRemarkAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Partner/">协同人员管理</a></li>
        </ul>
    </div>
    <asp:HiddenField ID="HiddenField_UserID" runat="server" />
    <div class="col-xs-12">
        <div class="page-header">
            <h1><a href="/Partner/">协同人员管理</a><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;协同人员信息</small></h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>姓名</b></h3>
                    <div class="col-sm-9">
                        <asp:Label ID="Label_Name" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>说明信息</b></h3>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Remark" runat="server" Height="200px" TextMode="MultiLine" placeholder="如有需要说明的信息，请填写" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-save bigger-110"></i> <b>保存信息</b></asp:LinkButton>
    </div>
</asp:Content>

