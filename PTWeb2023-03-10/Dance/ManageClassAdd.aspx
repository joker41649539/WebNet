<%@ Page Title="" Language="C#" MasterPageFile="~/Dance/MasterPage.master" AutoEventWireup="true" CodeFile="ManageClassAdd.aspx.cs" Inherits="Dance_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>课程管理								<small><i class="icon-double-angle-right"></i>&nbsp;增加课程                               </small></h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label17" class="col-sm-3 control-label no-padding-right" for="form-field-1">学校：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_School" ClientIDMode="Static" runat="server" placeholder="请输入学校序号（0或1）" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label2" class="col-sm-3 control-label no-padding-right" for="form-field-1">排序：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入排序（1、2、3、4、5、6、7）" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label3" class="col-sm-3 control-label no-padding-right" for="form-field-1">课程名称：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入课程名称" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label4" class="col-sm-3 control-label no-padding-right" for="form-field-1">任课老师：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" placeholder="请输入任课老师" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label5" class="col-sm-3 control-label no-padding-right" for="form-field-1">上课时间：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" placeholder="请输入上课时间(14:00:00)" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label6" class="col-sm-3 control-label no-padding-right" for="form-field-1">下课时间：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox6" ClientIDMode="Static" runat="server" placeholder="请输入下课时间(15:00:00)" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="btn-group">
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Next" class="btn btn-success" runat="server" OnClick="LinkButton_Next_Click"><i class="icon-ok bigger-110"></i> 提  交</asp:LinkButton>
    </div>

</asp:Content>

