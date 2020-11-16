<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TTYY.aspx.cs" Inherits="School_TTYY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>跳跳英语</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <script src="/assets/js/ace-extra.min.js"></script>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <link rel="shortcut icon" type="image/x-icon" href="/images/ttyy.png" media="screen" />
</head>
<body>
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "//hm.baidu.com/hm.js?7761b0dc093a95abff4ffd0dcdd9a116";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>
    <div class="modal fade" id="MSG" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"
                        aria-hidden="true">
                        ×
                    </button>
                    <h4 class="modal-title" id="MSGTitle">提  示
                    </h4>
                </div>
                <div class="modal-body">
                    <h3 class="modal-title" id="ShowMSG">发生了错误！
                    </h3>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default"
                        data-dismiss="modal">
                        确&nbsp;&nbsp;定
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <form id="form1" runat="server">
        <div class="navbar navbar-default" id="navbar">
            <script type="text/javascript">
                try { ace.settings.check('navbar', 'fixed') } catch (e) { }
            </script>
            <div class="navbar-container" id="navbar-container">
                <div class="navbar-header pull-left">
                    <a href="#" class="navbar-brand">
                        <small>
                            <img src="/images/ttyy.png" width="30px" />
                            跳跳英语
                            <b>
                                <asp:Label ID="Label_Data" runat="server" Text="2017-09-11 星期二"></asp:Label>
                            </b>
                        </small>
                    </a>
                </div>
            </div>
            <!-- /.container -->
        </div>
        <div class="main-container" id="main-container">
            <script type="text/javascript">
                try { ace.settings.check('main-container', 'fixed') } catch (e) { }
            </script>
            <div class="main-container-inner">
                <a class="menu-toggler" id="menu-toggler" href="#">
                    <span class="menu-text"></span>
                </a>
                <!-- 引导菜单加载 开始 //-->
                <div id="sidebar" class="sidebar">
                    <div class="sidebar-shortcuts" id="sidebar-shortcuts">
                        <div class="sidebar-shortcuts-large" id="sidebar-shortcuts-large">
                            <button class="btn btn-success"><i class="icon-signal"></i></button>
                            <button class="btn btn-info"><i class="icon-tags"></i></button>
                            <button class="btn btn-warning"><i class="icon-group"></i></button>
                            <button class="btn btn-danger"><i class="icon-cogs"></i></button>
                        </div>
                        <div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini"><span class="btn btn-success"></span><span class="btn btn-info"></span><span class="btn btn-warning"></span><span class="btn btn-danger"></span></div>
                    </div>
                    <ul class="nav nav-list">
                        <li class="active"><a class="dropdown-toggle" href="#">
                            <img src="/images/luLogo.png" width="25px" /><span class="menu-text">&nbsp;版本信息</span> <b class="arrow icon-angle-down"></b></a>
                            <ul class="submenu">
                                <li><a class="dropdown-toggle" target="_blank" href="#"><i class="icon-coffee"></i><span class="menu-text">&copy; 合肥星期陆</span>  </a></li>
                                <li><a class="dropdown-toggle" href="#"><i class="icon-male"></i><span class="menu-text">陆晓钧</span>  </a></li>
                                <li><a class="dropdown-toggle" href="tel://18019961118"><i class="icon-phone"></i><span class="menu-text">18019961118</span>  </a></li>
                            </ul>
                        </li>
                    </ul>
                    <div class="sidebar-collapse" id="sidebar-collapse"><i class="icon-double-angle-left" data-icon1="icon-double-angle-left" data-icon2="icon-double-angle-right"></i></div>
                    <script type="text/javascript"> try { ace.settings.check('sidebar', 'collapsed') } catch (e) { }</script>
                </div>
                <!-- 引导菜单加载 结束 //-->
                <div class="main-content">
                    <!-- 加载主体内容 开始 //-->
                    <div class="breadcrumbs col-xs-12" id="breadcrumbs">
                        <ul class="breadcrumb">
                            <li class="active">
                                <i class="icon-home home-icon"></i>
                                <a href="/School/Default.aspx">首页</a>
                            </li>
                        </ul>
                    </div>
                    <!-- 公告开始 //-->
                    <div runat="server" id="GGInfo" visible="false"></div>
                    <!-- 公告结束 //-->

                    <!-- 家庭作业开始 //-->
                    <div class="col-xs-12">
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-book"></i>家庭作业</h4>
                                <asp:TextBox ID="TextBox_Time" class="input" runat="server" Width="100px"></asp:TextBox>
                                <asp:Button ID="Button1" class="btn btn-sm btn-info" runat="server" Text="查 看" OnClick="Button1_Click" />
                                <script type='text/javascript'>$(function () { $('#TextBox_Time').datepicker(); });</script>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                        </div>
                        <div runat="server" id="ZuoYeInfo" visible="false"></div>
                        <!-- 家庭作业结束 //-->
                    </div>
                </div>
            </div>
        </div>
        <!-- /.main-container-inner -->
        <div>
            <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
                <i class="icon-double-angle-up icon-only bigger-110"></i>
            </a>
        </div>
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

        <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
        <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
        <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
        <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>

        <script type="text/javascript">
            function MesgLogin() {
                var rValue = true;
                // alert("aaa");
                $('#Login').modal('show');
                return rValue;

            }
            jQuery(function ($) {
                $('#tree1').ace_tree({
                    dataSource: treeDataSource,
                    // multiSelect: true,
                    loadingHTML: '<div class="tree-loading"><i class="icon-refresh icon-spin blue"></i></div>',
                    'open-icon': 'icon-minus',
                    'close-icon': 'icon-plus',
                    'selectable': false,
                    //'selected-icon': 'icon-ok',
                    //'unselected-icon': 'icon-remove'
                });
            });
        </script>
    </form>
</body>
</html>
