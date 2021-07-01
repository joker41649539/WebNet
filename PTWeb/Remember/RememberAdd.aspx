<%@ Page Title="添加新的记忆计划" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="RememberAdd.aspx.cs" Inherits="RememberAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="page-header">
            <h1>记忆计划								<small><i class="icon-double-angle-right"></i>添加新的记忆计划                                </small></h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">记忆内容</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="GridView_Remember_TextBox_nContent" Height="200px" runat="server" placeholder="请输入记忆内容" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注信息</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="GridView_Remember_TextBox_nRemark" runat="server" placeholder="请输入备注信息" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <asp:LinkButton UseSubmitBehavior="false" ID="GridView_Remember_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_Remember_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" ID="LinkButton_Del" class="btn btn-danger" runat="server" OnClick="LinkButton_Del_Click"><i class="icon-trash bigger-110"></i> 删  除</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

