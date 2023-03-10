<%@ Page Title="报销单退回" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReturnMSG.aspx.cs" Inherits="CWGL_ReturnMSG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/CWGL/">财务管理</a></li>
            <li class="active">报销单</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>报销单								<small><i class="icon-double-angle-right"></i>&nbsp;单据退回                               </small></h1>
    </div>
    <div class="page-content">
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="LabelRadioText" class="col-sm-3 control-label no-padding-right" for="form-field-1">退回原因：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ReturnMSG" TextMode="MultiLine" runat="server" placeholder="请输入退回原因" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="col-xs-12">
            <div class="form-group">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton3" class="btn btn-mini" runat="server" OnClick="LinkButton3_Click"><b>确定退回</b></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

