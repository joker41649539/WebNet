<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tags.aspx.cs" Inherits="Partner_Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function check() {// 数据提交检测
            var rValue = true;
            var TagName = document.getElementById("TextBox_TagName").value;
            var TagPX = document.getElementById("TextBox_PX").value;
            var addressID = $("input[name='ctl00$ContentPlaceHolder1$RadioButtonList1']:checked").val();
            var i = 0;
            var MsgContent = "";

            if (TagName.length <= 0) {
                i++;
                rValue = false;
                MsgContent = i.toString() + "、标签名称必须填写。<br/>";
            }
            if (TagPX.length > 0) {
                if (isNaN(TagPX)) {
                    i++;
                    rValue = false;
                    MsgContent += i.toString() + "、标签排序必须是数字。<br/>";
                }
            }
            if (addressID == undefined) {
                i++;
                rValue = false;
                MsgContent += i.toString() + "、必须选择一个标签样式。<br/>";
            }

            if (MsgContent.length > 0) {
                dialog = jqueryAlert({ 'content': MsgContent });
                rValue = false;
            }
            return rValue;
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Partner/">协同人员管理</a></li>
        </ul>
    </div>
    <asp:HiddenField ID="HiddenField_department" runat="server" />
    <div class="col-xs-12">
        <div class="page-header">
            <h1><a href="/Partner/Tags.aspx">标签管理</a><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;标签管理</small></h1>
        </div>
        <div class="profile-contact-info left" runat="server" id="Div_Tags">
            <a href="#" class="label">Default</a>
            <a href="#" class="label label-success">Success</a>
            <a href="#" class="label label-warning">Warning</a>
            <a href="#" class="label label-danger">Danger</a>
            <a href="#" class="label label-info">Info</a>
            <a href="#" class="label label-inverse">Inverse</a>
        </div>
        <hr />
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>标签名称</b></h3>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_TagName" ClientIDMode="Static" runat="server" placeholder="请输入标签名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>标签排序</b></h3>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_PX" runat="server" ClientIDMode="Static" placeholder="请输入标签排序，数字越大越前" class="col-xs-12 col-sm-12"></asp:TextBox>
                        <h7>标签排序，数字越大越前，默认为100</h7>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>标签样式</b></h3>
                    <div class="col-sm-9">
                        <asp:RadioButtonList ID="RadioButtonList1" ClientIDMode="Static" runat="server">
                            <asp:ListItem Value="default">&nbsp;<span class="label label-default">&nbsp;Default</span></asp:ListItem>
                            <asp:ListItem Value="success">&nbsp;<span class="label label-success">&nbsp;success</span></asp:ListItem>
                            <asp:ListItem Value="info">&nbsp;<span class="label label-info">&nbsp;Info</span></asp:ListItem>
                            <asp:ListItem Value="warning">&nbsp;<span class="label label-warning">&nbsp;Warning</span></asp:ListItem>
                            <asp:ListItem Value="danger">&nbsp;<span class="label label-danger">&nbsp;Danger</span></asp:ListItem>
                            <asp:ListItem Value="inverse">&nbsp;<span class="label label-inverse">&nbsp;Inverse</span></asp:ListItem>
                            <asp:ListItem Value="pink">&nbsp;<span class="label label-pink">&nbsp;Pink</span></asp:ListItem>
                            <asp:ListItem Value="purple">&nbsp;<span class="label label-purple">&nbsp;Purple</span></asp:ListItem>
                            <asp:ListItem Value="yellow">&nbsp;<span class="label label-yellow">&nbsp;Yellow</span></asp:ListItem>
                            <asp:ListItem Value="grey">&nbsp;<span class="label label-grey">&nbsp;Grey</span></asp:ListItem>
                            <asp:ListItem Value="light">&nbsp;<span class="label label-light">&nbsp;Light</span></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="return check();" OnClick="LinkButton1_Click" ID="LinkButton1" class="btn btn-info btn-block" runat="server"><i class="icon-save bigger-110"></i> <b>保存信息</b></asp:LinkButton>
    </div>
</asp:Content>

