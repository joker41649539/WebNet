<%@ Page Title="GeidView代码生成" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GridView.aspx.cs" Inherits="GridView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/ACEDEMO/">模板管理</a></li>
            <li class="active"><a href="/ACEDEMO/Default.aspx">基础代码</a></li>
            <li><a href="/ACEDEMO/GridView.aspx">GridView代码</a></li>
        </ul>
    </div>

    <div>
        <div class="page-content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">GridView名</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox1" Text="GridView1" runat="server" placeholder="GridView名" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">中文注释</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="请输入中文注释" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">数据库表名</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="请输入数据库表名" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">字段英文</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox4" runat="server" placeholder="请输入字段英文，“;”分隔。" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">字段中文</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox5" runat="server" placeholder="请输入字段中文，“;”分隔。" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">功能选择</label>
                        <div class="col-sm-9">
                            <asp:CheckBox ID="CheckBox1" Text="无刷新" runat="server" />
                            <asp:CheckBox ID="CheckBox2" Text="添 加" runat="server" />
                            <asp:CheckBox ID="CheckBox3" Text="修 改" runat="server" />
                            <asp:CheckBox ID="CheckBox4" Text="删 除" runat="server" />
                            <asp:CheckBox ID="CheckBox5" Text="查询、分页" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1"></label>
                        <div class="col-sm-9">
                            <asp:LinkButton ID="LinkButton1" class="btn btn-info" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> 生成代码</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <script type="text/javascript">
        function copyUrl2() {
            var Url2 = document.getElementById("strCode");
            Url2.select(); // 选择对象 
            document.execCommand("Copy"); // 执行浏览器复制命令 
            alert("已复制好，可贴粘。");
        }
    </script>
    <div class="page-content">
        <%--        <textarea id="biao1">--%>
        <!-- Code加载 开始 //-->
        <div id="strCode" runat="server" />
        <%--                </textarea>--%>
        <%-- <input type="button" onclick="copyUrl2()" value="点击复制代码" />--%>
    </div>
    <!-- Code加载 结束 //-->
</asp:Content>
