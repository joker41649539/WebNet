﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg.aspx.cs" Inherits="Shop_Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimal-ui" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />

    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/assets/alert/alert.css" />

    <script src='/assets/alert/alert.js'></script>
    <script src="/assets/js/ace-extra.min.js"></script>
    <script src='/assets/alert/shCore.js'></script>
    <script src='/assets/alert/makeSy.js'></script>

    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>

    <title>系统登录</title>
    <link rel="shortcut icon" type="image/x-icon" href="/images/ptlogo.png" media="screen" />

</head>
<body class="login-layout">
    <form id="form1" runat="server">
        <script type="text/javascript">
            function Msgcheck() {
                var rValue = false;
                var phone = jQuery("#TextBox_PhoneNo").val();
                var message = "";
                var myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;
                if (phone == '') {
                    message = "手机号码不能为空！";
                } else if (phone.length != 11) {
                    message = "请输入有效的手机号码！";
                } else if (!myreg.test(phone)) {
                    message = "请输入有效的手机号码！";
                } else {
                    rValue = true;
                }
                if (!rValue) {
                    rValue = false;
                    dialog = jqueryAlert({ 'content': message });
                    jQuery("#TextBox_PhoneNo").focus();
                }
                return rValue;
            }
            function Regcheck() {
                var rValue = true;
                var phone = jQuery("#TextBox_PhoneNo").val();
                var message = "";
                var myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;
                if (phone == '') {
                    rValue = false;
                    message = "手机号码不能为空！";
                } else if (phone.length != 11) {
                    rValue = false;
                    message += "<br/>请输入有效的手机号码！";
                } else if (!myreg.test(phone)) {
                    rValue = false;
                    message += "<br/>请输入有效的手机号码！";
                }

                var code = jQuery("#TextBox_Code").val();
                var Pass = jQuery("#TextBox_Password").val();
                var Pass2 = jQuery("#TextBox_Password2").val();

                if (code.length <= 0 || Pass.length <= 0 || Pass2.length <= 0) {
                    message += "<br/>请输入验证码、密码和确认密码！";
                    rValue = false;
                }

                if (Pass != Pass2) {
                    message += "<br/>密码和确认密码不一致！";
                    rValue = false;
                }

                if (message.length > 0) {
                    dialog = jqueryAlert({ 'content': message });
                }
                return rValue;
            }
        </script>
        <asp:HiddenField ID="HiddenField_CodeNo" runat="server" />
        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                                <h1>
                                    <span class="white">系统登录</span>
                                </h1>
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="login-box" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header green lighter bigger">
                                                <i class="icon-group blue"></i>
                                                新用户注册
                                            </h4>

                                            <div class="space-6"></div>
                                            <p>请输入您的注册信息：</p>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="TextBox_PhoneNo" ClientIDMode="Static" class="form-control" placeholder="请输入手机号码" runat="server"></asp:TextBox>
                                                        <i class="icon-user"></i>
                                                    </span>
                                                </label>
                                                <div class="block clearfix">
                                                    <asp:Button ID="Button_SendCode" ClientIDMode="Static" OnClientClick="return Msgcheck()" OnClick="Button_SendCode_Click" CssClass="pull-left btn btn-block" runat="server" Text="发送验证码" />
                                                </div>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="TextBox_Code" ClientIDMode="Static" class="form-control" placeholder="手机验证码" runat="server"></asp:TextBox>
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox type="password" ClientIDMode="Static" ID="TextBox_Password" class="form-control" placeholder="密码" runat="server"></asp:TextBox>
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox type="password" ClientIDMode="Static" ID="TextBox_Password2" class="form-control" placeholder="确认密码" runat="server"></asp:TextBox>
                                                        <i class="icon-retweet"></i>
                                                    </span>
                                                </label>

                                                <%--  <label class="block">
                                                    <input type="checkbox" class="ace" />
                                                    <span class="lbl">&nbsp;我同意
															<a href="#">用户协议</a>
                                                    </span>
                                                </label>--%>

                                                <div class="space-24"></div>

                                                <div class="clearfix">
                                                    <asp:LinkButton ID="LinkButton1" PostBackUrl="/Shop/Login.aspx" class="width-30 pull-left btn" runat="server"><i class="icon-refresh"></i>
                                                        返 回</asp:LinkButton>

                                                    <asp:LinkButton ID="LinkButton_REG" OnClientClick="return Regcheck()" class="width-65 pull-right btn btn-success" runat="server" OnClick="LinkButton_REG_Click">
															注 册<i class="icon-arrow-right icon-on-right"></i>
                                                    </asp:LinkButton>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <!-- /widget-body -->
                                </div>

                                <!-- /signup-box -->
                            </div>
                            <!-- /position-relative -->
                        </div>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>

        </div>
        <!-- /.main-container -->

        <!-- basic scripts -->

        <!--[if !IE]> -->


        <!-- inline scripts related to this page -->

        <script type="text/javascript">
            function show_box(id) {
                jQuery('.widget-box.visible').removeClass('visible');
                jQuery('#' + id).addClass('visible');
            }
        </script>
        <!-- ACE 脚本开始//-->
        <script type="text/javascript">
            window.jQuery || document.write("<script src='/assets/js/jquery-2.0.3.min.js'>" + "<" + "script>");
        </script>
        <script type="text/javascript">
            if ("ontouchend" in document) document.write("<script src='/assets/js/jquery.mobile.custom.min.js'>" + "<" + "script>");
        </script>
        <script src="/assets/js/bootstrap.min.js"></script>
        <script src="/assets/js/typeahead-bs2.min.js"></script>

        <script src="/assets/js/fuelux/data/fuelux.tree-sampledata.js"></script>
        <script src="/assets/js/fuelux/fuelux.tree.min.js"></script>

        <!-- ace scripts -->

        <script src="/assets/js/ace-elements.min.js"></script>
        <script src="/assets/js/ace.min.js"></script>

        <script src="/js/jquery.min.js" type="text/javascript"></script>
        <script src="/js/masonry-docs.min.js"></script>
        <!-- ACE 脚本开始//-->
    </form>

</body>
</html>