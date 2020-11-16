<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="YanWo_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>陆氏燕窝溯源系统</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="Menu.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <script src="/assets/js/ace-extra.min.js"></script>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <link rel="shortcut icon" type="/image/x-icon" href="/images/lu32.ico" media="screen" />
</head>
<body>
    <form id="form1" runat="server" style="background: #ffffff">
        <div class="navbar navbar-default" id="navbar">
            <script type="text/javascript">
                try { ace.settings.check('navbar', 'fixed') } catch (e) { }
            </script>
            <div class="navbar-container" id="navbar-container">
                <div class="navbar-header pull-left">
                    <a href="#" class="navbar-brand">
                        <small>
                            <img src="/images/luLogoY.png" width="23px" />
                            <b>陆氏大马燕窝溯源
                            </b>
                        </small>
                    </a>
                </div>
            </div>
        </div>
        <div>
            <div class="widget-box transparent">
                <div class="widget-header widget-header-flat">
                    <h4 class="lighter">
                        <i class="icon-star orange"></i>
                        产品信息
                    </h4>

                    <div class="widget-toolbar">
                        <a href="#" data-action="collapse">
                            <i class="icon-chevron-up"></i>
                        </a>
                    </div>
                </div>

                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td>
                                        <img class="img-rounded" src="/images/yanwo.jpg" /></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;产品名称：
                                   <b class="green">白燕盏</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;产地：
                                   <b class="green">马来西亚</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;采窝日期：
                                  <b class="green">2017-02-01</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工日期：
                                  <b class="green">2017-03-01</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工地点：
                                  <b class="green">马来西亚</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工方式：
                                  <b class="green">半干挑</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;质保日期：
                                  <b class="red">2020-02-28</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;重量：
                                  <b class="red">7.6 克</b></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <!-- /widget-main -->
                </div>
                <!-- /widget-body -->
            </div>
            <!-- /widget-box -->
            <div class="widget-box transparent">
                <div class="widget-header widget-header-flat">
                    <h4 class="lighter">
                        <i class="icon-star orange"></i>
                        加工厂信息
                    </h4>

                    <div class="widget-toolbar">
                        <a href="#" data-action="collapse">
                            <i class="icon-chevron-up"></i>
                        </a>
                    </div>
                </div>

                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工厂名称：
                                   <b class="green">皇冠燕窝加工厂</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工厂地址：
                                   <b class="green">马来西亚礁赖皇冠城</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;联系电话：
                                  <b class="green">0063XXXXXXXX</b></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <!-- /widget-main -->
                </div>
                <!-- /widget-body -->
            </div>
            <!-- /widget-box -->
        </div>

        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter">
                    <i class="icon-star orange"></i>
                    经销商信息
                </h4>

                <div class="widget-toolbar">
                    <a href="#" data-action="collapse">
                        <i class="icon-chevron-up"></i>
                    </a>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main no-padding">
                    <table class="table table-bordered table-striped">
                        <tbody>
                            <tr>
                                <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;经销商名称：
                                   <b class="green">合肥星期陆电子商务有限公司</b></td>
                            </tr>
                            <tr>
                                <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工厂地址：
                                   <b class="green">安徽省合肥市</b></td>
                            </tr>
                            <tr>
                                <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;联系电话：
                                  <b class="green">18019961118</b></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <!-- /widget-main -->
            </div>
            <!-- /widget-body -->
        </div>
        <!-- /widget-box -->
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter">
                    <i class="icon-star orange"></i>
                    物流信息
                </h4>

                <div class="widget-toolbar">
                    <a href="#" data-action="collapse">
                        <i class="icon-chevron-up"></i>
                    </a>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main no-padding">
                    <table class="table table-bordered table-striped">
                        <tbody>
                            <tr>
                                <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;经销商名称：
                                   <b class="green">合肥星期陆电子商务有限公司</b></td>
                            </tr>
                            <tr>
                                <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;加工厂地址：
                                   <b class="green">安徽省合肥市</b></td>
                            </tr>
                            <tr>
                                <td>&nbsp;<i class="icon-caret-right blue"></i>&nbsp;联系电话：
                                  <b class="green">18019961118</b></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <!-- /widget-main -->
            </div>
            <br />
            <br />
            <br />
            <!-- /widget-body -->
        </div>
        <!-- /widget-box -->

        <nav class="navbar navbar-fixed-bottom" role="toolbar">
            <div class="btn-toolbar" role="toolbar">
                <div class="btn-group row">
                    <button type="button" class="btn btn-lg">按钮 7</button>
                    <button type="button" class="btn btn-default  btn-lg">按钮 8</button>
                    <button type="button" class="btn btn-default  btn-lg">按钮 9</button>
                </div>
            </div>
        </nav>

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
    </form>
</body>
</html>
