<%@ Page Title="" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="TagAdd.aspx.cs" Inherits="Remember_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="page-header">
            <h1>记忆计划								<small><i class="icon-double-angle-right"></i>添加新的标签                                </small></h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标签内容</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="Content" runat="server" placeholder="请输入标签内容" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标签颜色</label>
                    <div class="col-sm-9">
                        <asp:CheckBoxList ID="CheckBoxList1" ClientIDMode="Static" RepeatColumns="3" runat="server">
                            <asp:ListItem class="label label-default" Value="default">&nbsp;default</asp:ListItem>
                            <asp:ListItem class="label label-primary" Value="primary">&nbsp;primary</asp:ListItem>
                            <asp:ListItem class="label label-info" Value="info">&nbsp;info</asp:ListItem>
                            <asp:ListItem class="label label-success" Value="success">&nbsp;success</asp:ListItem>
                            <asp:ListItem class="label label-warning" Value="warning">&nbsp;warning</asp:ListItem>
                            <asp:ListItem class="label label-danger" Value="danger">&nbsp;danger</asp:ListItem>
                            <asp:ListItem class="label label-inverse" Value="inverse">&nbsp;inverse</asp:ListItem>
                            <asp:ListItem class="label label-pink" Value="pink">&nbsp;pink</asp:ListItem>
                            <asp:ListItem class="label label-purple" Value="purple">&nbsp;purple</asp:ListItem>
                            <asp:ListItem class="label label-yellow" Value="yellow">&nbsp;yellow</asp:ListItem>
                            <asp:ListItem class="label label-grey" Value="grey">&nbsp;grey</asp:ListItem>
                            <asp:ListItem class="label label-light" Value="light">&nbsp;light</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <asp:LinkButton UseSubmitBehavior="false" ID="LinkButton1" class="btn btn-info" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
            </div>
        </div>
        <div runat="server" id="PTag" class="btn-toolbar">
        </div>
    </div>
</asp:Content>

