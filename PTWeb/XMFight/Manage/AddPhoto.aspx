<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="AddPhoto.aspx.cs" Inherits="XMFight_Manage_AddPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row page-content height-auto">
        <div class="page-header">
            <h5>学员风采录入</h5>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label7" class="col-sm-3 control-label no-padding-right" for="form-field-1">上传图片：</label>
                <div class="col-sm-9">
                    <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label1" class="col-sm-3 control-label no-padding-right" for="form-field-1">优先值：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Top" runat="server" placeholder="请输入数字，越大越优先" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注说明</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark" runat="server" placeholder="请输入备注信息 " class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <hr />
        <div class="col-xs-12 page-header">
            <p>
                <asp:LinkButton ID="LinkButton1" class="btn btn-info " runat="server" OnClick="LinkButton1_Click"><i class="icon-save bigger-110"></i> 保存数据</asp:LinkButton>

                <asp:LinkButton ID="LinkButton2" class="btn btn-danger " runat="server" OnClick="LinkButton2_Click"><i class="icon-trash bigger-110"></i> 数据删除</asp:LinkButton>
            </p>
        </div>
    </div>

</asp:Content>

