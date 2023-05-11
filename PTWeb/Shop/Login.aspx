<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
    <form id="form1" runat="server" defaultbutton="LinkButton1">
        <script type="text/javascript">
            function Logcheck() {
                var rValue = true;
                var phone = jQuery("#TextBox_UserName").val();
                var Pass = jQuery("#TextBox_Password").val();
                var message = "";
                var myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;
                if (phone == '' || Pass == '') {
                    rValue = false;
                    message = "手机号码和密码不能为空！";
                } else if (phone.length != 11) {
                    rValue = false;
                    message = "请输入有效的手机号码！";
                } else if (!myreg.test(phone)) {
                    rValue = false;
                    message = "请输入有效的手机号码！";
                }

                if (!rValue) {
                    rValue = false;
                    dialog = jqueryAlert({ 'content': message });
                    jQuery("#TextBox_UserName").focus();
                }
                return rValue;
            }
        </script>
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
                                            <h4 class="header blue lighter bigger">
                                                <i class="icon-user"></i>
                                                请输入您的账号密码
                                            </h4>

                                            <div class="space-6"></div>

                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="TextBox_UserName" ClientIDMode="Static" class="form-control" placeholder="请输入您手机号码" runat="server"></asp:TextBox>
                                                        <i class="icon-user"></i>
                                                    </span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="TextBox_Password" ClientIDMode="Static" class="form-control" placeholder="请输入您的密码" type="password" runat="server"></asp:TextBox>
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>

                                                <div class="space"></div>

                                                <div class="clearfix">
                                                    <label class="inline">
                                                        <%--<input type="checkbox" class="ace" />
                                                        <span class="lbl">&nbsp;记住我</span>--%>
                                                    </label>
                                                    <asp:LinkButton ID="LinkButton1" OnClientClick="return Logcheck();" class="width-35 pull-right btn btn-sm btn-primary" runat="server" OnClick="LinkButton1_Click"><i class="icon-key"></i>
															登  录</asp:LinkButton>
                                                </div>

                                                <div class="space-4"></div>
                                            </fieldset>
                                        </div>
                                        <!-- /widget-main -->

                                        <div class="toolbar clearfix">
                                            <div>
                                                <a href="#" onclick="show_box('forgot-box'); return false;" class="forgot-password-link">
                                                    <i class="icon-arrow-left"></i>
                                                    忘记密码
                                                </a>
                                            </div>

                                            <div>
                                                <a href="/Shop/Reg.aspx" class="user-signup-link">用户注册
													<i class="icon-arrow-right"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /widget-body -->
                                </div>
                                <!-- /login-box -->

                                <div id="forgot-box" class="forgot-box widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header red lighter bigger">
                                                <i class="icon-key"></i>
                                                密码找回
                                            </h4>

                                            <div class="space-6"></div>
                                            <p>
                                                请输入您的邮箱地址
                                            </p>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input type="email" class="form-control" placeholder="Email" />
                                                        <i class="icon-envelope"></i>
                                                    </span>
                                                </label>

                                                <div class="clearfix">
                                                    <asp:LinkButton ID="LinkButton2" class="width-35 pull-right btn btn-sm btn-danger" runat="server" OnClick="LinkButton2_Click">
                                                        <i class="icon-lightbulb"></i>
															确  定</asp:LinkButton>
                                                </div>

                                            </fieldset>
                                        </div>
                                        <div class="toolbar center">
                                            <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">返回用户登录
												<i class="icon-arrow-right"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <!-- /widget-body -->
                                </div>
                                <!-- /forgot-box -->

                                <div id="signup-box" class="signup-box widget-box no-border">
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
                                                    <asp:Button ID="Button_SendCode" ClientIDMode="Static" OnClientClick="return Regcheck()" OnClick="Button_SendCode_Click" class="pull-left btn btn-block" runat="server" Text="发送验证码" />
                                                </div>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="TextBox_Code" class="form-control" placeholder="手机验证码" runat="server"></asp:TextBox>
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input type="password" class="form-control" placeholder="密码" />
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input type="password" class="form-control" placeholder="确认密码" />
                                                        <i class="icon-retweet"></i>
                                                    </span>
                                                </label>

                                                <label class="block">
                                                    <input type="checkbox" class="ace" />
                                                    <span class="lbl">&nbsp;我同意
															<a href="#">用户协议</a>
                                                    </span>
                                                </label>

                                                <div class="space-24"></div>

                                                <div class="clearfix">
                                                    <button type="reset" class="width-30 pull-left btn">
                                                        <i class="icon-refresh"></i>
                                                        重 置
                                                    </button>

                                                    <asp:LinkButton ID="LinkButton_REG" class="width-65 pull-right btn btn-success" runat="server" OnClick="LinkButton_REG_Click">
															注 册<i class="icon-arrow-right icon-on-right"></i>
                                                    </asp:LinkButton>
                                                </div>
                                            </fieldset>
                                        </div>

                                        <div class="toolbar center">
                                            <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">
                                                <i class="icon-arrow-left"></i>
                                                返回用户登录
                                            </a>
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
