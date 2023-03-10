<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BugEdit.aspx.cs" Inherits="Bug_BugEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Bug/">Bug处理</a></li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>Bug处理<small><i class="icon-double-angle-right"></i>&nbsp;Bug信息                                </small></h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标题</label>
                    <div class="col-sm-9">
                        <asp:Label ID="Label_ID" runat="server" Text="ID"></asp:Label>.<asp:TextBox ID="TextBox_Title" runat="server" placeholder="请输入标题" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">紧急程度</label>
                    <div class="col-sm-9">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3">
                            <asp:ListItem Value="0" Selected="True">&nbsp;一般&nbsp;</asp:ListItem>
                            <asp:ListItem Value="1">&nbsp;着急&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">&nbsp;加急&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">提交人</label>
                    <div class="col-sm-9">
                        <asp:Label ID="Label_CreatUserName" runat="server" Text="提交人"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">处理状态</label>
                    <div class="col-sm-9">
                        <asp:Label ID="Label_Worker" runat="server" Text="处理状态"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">描述</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Remark" TextMode="MultiLine" runat="server" placeholder="请尽量详细填写BUG描述" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Save" class="btn btn-info" runat="server" OnClick="GridView_Bug_LinkButton1_Click"><i class="icon-save bigger-110"></i> 保  存</asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Start" class="btn btn-warning" runat="server" OnClick="LinkButton1_Click"><i class="icon-desktop bigger-110"></i> 开始处理</asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Finsh" class="btn btn-danger" runat="server" OnClick="LinkButton_Finsh_Click"><i class="icon-ok bigger-110"></i> 完 成</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

