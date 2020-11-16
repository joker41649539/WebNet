<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="School_Default2" %>

<!DOCTYPE html>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>合肥少儿艺术学校
    </title>
    <meta name="keywords" />
    <meta name="description" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <script src="/assets/js/ace-extra.min.js"></script>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <link rel="shortcut icon" type="image/x-icon" href="/images/ant2.png" media="screen" />
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
    <form method="post" action="./Default.aspx" id="form1">
        <div class="aspNetHidden">
            <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="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" />
        </div>

        <div class="navbar navbar-default" id="navbar">
            <script type="text/javascript">
                try { ace.settings.check('navbar', 'fixed') } catch (e) { }
            </script>
            <div class="navbar-container" id="navbar-container">
                <div class="navbar-header pull-left">
                    <a href="#" class="navbar-brand">
                        <small>
                            <img src="/images/ant2.png" width="30px" />
                            蚂蚁中队
                            <b>
                                <span id="Label_Data">2017年9月5日 星期二</span>
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
                        <li class="active">
                            <a class="dropdown-toggle" href="#">
                                <img src="/images/luLogo.png" width="25px" /><span class="menu-text">&nbsp;版本信息</span> <b class="arrow icon-angle-down"></b>
                            </a>
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
                    <div class="col-xs-12">
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-bullhorn"></i>通知公告</h4>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <div class="dialogs">
                                    <div class="itemdiv dialogdiv">
                                        <div class="user">
                                            <img alt="Alexa's Avatar" src="/images/ant2.png" />
                                        </div>
                                        <div class="body">
                                            <div class="time"><i class="icon-time"></i><span class="grey">2017/9/5 15:04:46</span>          </div>
                                            <div class="name"><span class="label label-info arrowed arrowed-in-right">通知公告</span>          </div>
                                            <div class="text">普通公告          </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- 公告结束 //-->
                    <!-- 家庭作业开始 //-->
                    <div class="col-xs-12">
                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-book"></i>家庭作业</h4>
                                <input name="TextBox_Time" type="text" value="2017-09-05" id="TextBox_Time" class="input" style="width: 100px;" />
                                <input type="submit" name="Button1" value="查 看" id="Button1" class="btn btn-sm btn-info" />
                                <script type='text/javascript'>$(function () { $('#TextBox_Time').datepicker(); });</script>
                                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <div class="dialogs">
                                    <div class="itemdiv dialogdiv">
                                        <div class="user">
                                            <img alt="Alexa's Avatar" src="/images/yuwen.png" />
                                        </div>
                                        <div class="body">
                                            <div class="time"><i class="icon-time"></i><span class="grey">2017/9/5 15:04:54</span>          </div>
                                            <div class="name"><span class="label label-info arrowed arrowed-in-right">语文作业</span>          </div>
                                            <div class="text">语文作业          </div>
                                        </div>
                                    </div>
                                    <div class="itemdiv dialogdiv">
                                        <div class="user">
                                            <img alt="Alexa's Avatar" src="/images/shuxue.png" />
                                        </div>
                                        <div class="body">
                                            <div class="time"><i class="icon-time"></i><span class="grey">2017/9/5 15:05:00</span>          </div>
                                            <div class="name"><span class="label label-info arrowed arrowed-in-right">数学作业</span>          </div>
                                            <div class="text">数学作业          </div>
                                        </div>
                                    </div>
                                    <div class="itemdiv dialogdiv">
                                        <div class="user">
                                            <img alt="Alexa's Avatar" src="/images/yingyu.png" />
                                        </div>
                                        <div class="body">
                                            <div class="time"><i class="icon-time"></i><span class="grey">2017/9/5 15:05:09</span>          </div>
                                            <div class="name"><span class="label label-info arrowed arrowed-in-right">英语作业</span>          </div>
                                            <div class="text">英语作业          </div>
                                        </div>
                                    </div>
                                    <div class="itemdiv dialogdiv">
                                        <div class="user">
                                            <img alt="Alexa's Avatar" src="/images/qita.png" />
                                        </div>
                                        <div class="body">
                                            <div class="time"><i class="icon-time"></i><span class="grey">2017/9/5 15:05:16</span>          </div>
                                            <div class="name"><span class="label label-info arrowed arrowed-in-right">其它作业</span>          </div>
                                            <div class="text">其它作业          </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- 家庭作业结束 //-->
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

        <div class="aspNetHidden">

            <input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="EE0A3F11" />
            <input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="99eSSQltUJBrVO/z2NnBCuw5mM32125oOXU+k+yZz/oqrnZCIQhRU8+aSHgAcR/9a/2R5EPxy3/HrBkRDlaB7/h4X1ofbjt+XnKowyuPgpXY21pXRiq8BAb+UJIRNVZwjxrXSOxdV91qcI1J6pAWeQ==" />
        </div>
    </form>

    <!-- Visual Studio Browser Link -->
    <script type="application/json" id="__browserLink_initializationData">
        {"appName":"Chrome","requestId":"406b71f234f341568481ae675c66eace"}
    </script>
    <script type="text/javascript" src="http://localhost:61662/cc8d50b2d01c4a22a1cea027d4832d68/browserLink" async="async"></script>
    <!-- End Browser Link -->

</body>
</html>

