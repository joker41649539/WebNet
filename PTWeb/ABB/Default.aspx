<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ABB_Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经销商查询</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/bootstrap/css/account.css" rel="stylesheet" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/plugins/toastr/toastr.min.css" rel="stylesheet" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/plugins/icheck/skins/all.css" rel="stylesheet" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/SHABBcss/custom.css" rel="stylesheet" />
    <link href="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/ladda/ladda.min.css" rel="stylesheet" />
    <script src="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Scripts/jquery/jQuery-2.1.4.min.js"></script>
    <script src="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Scripts/bootstrap/bootstrap.js"></script>
</head>

<body ng-app="abb" ng-controller="abbCtrl" class="ng-scope">
    <div id="topDiv" class="topDiv">
        <div class="logoDiv">
            <img src="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/images/ABB_Logo.jpg">
        </div>
        <div class="navDiv">
            <a class="dropdown-toggle" data-toggle="dropdown" onclick="javascript:void(0);" aria-expanded="false">
                <img src="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Content/images/line4.png">
            </a>
            <ul class="dropdown-menu" role="menu">
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/">产品系列</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/utilization">行业应用</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/introduce">公司介绍</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/center/sample">样本下载</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/center/manual/">安装手册</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/center/certificate">认证证书</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/center/cases/">成功案例</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/aftersales">防伪验证</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/aftersales/repairOrder/">报修</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/aftersales/orderRequire/">报修进度查询</a></li>
                <li class="bb"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/aftersales/userdata/">个人信息</a></li>
                <li class="bbs"><a href="https://rmmgwxdev.chinacloudsites.cn/motor/contact">联系我们</a></li>
            </ul>
        </div>
    </div>
    <div class="topDivBG"></div>
    <div class="redBarDiv"></div>
    <div class="titleDiv">
        <p id="titlep" class="hyzhj">经销商查询</p>
    </div>
    <script type="text/javascript">
        $('#topDiv').on('touchmove', function () { return false });

        function back() {
            window.history.back();
        }

        function showTab(id) {
            for (var key in tabs) {
                $('#' + tabs[key]).attr('class', 'tabTitle grayBottom col-xs-4');
                $('#' + tabs[key] + 'Content').css('display', 'none');
            }
            $('#' + id).attr('class', 'tabTitle redBottom col-xs-4');
            $('#' + id + 'Content').css('display', 'block');
        }

        function showTab2(id) {
            for (var key in tabs) {
                $('#' + tabs[key]).attr('class', 'hyxjhj tabGrayFont');
                $('#' + tabs[key]).css('color', '#878787');
                $('#' + tabs[key] + 'Content').css('display', 'none');
            }
            $('#' + id).attr('class', 'hyxjhj redBottom tabBlackFont');
            $('#' + id).css('color', '#000');
            $('#' + id + 'Content').css('display', 'block');

        }

        function initTopDiv() {
            var width = $(window).width();
            if (width > 600) {
                var left = (width - 600) / 2
                $('.topDiv').css({ "left": left + "px" });
            }
            else {
                $('.topDiv').css({ "left": "0px" });
            }
        }
    </script>
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="email=no" name="format-detection" />
    <style type="text/css">
        .clear {
            clear: both;
        }

        .showDiv {
            margin: 25px 25px 0px 25px;
            position: relative;
        }

        .inputDiv {
            margin: 100px auto;
            height: 40px;
            line-height: 40px;
        }

        .inputDiv2 {
            margin: -90px auto;
            height: 40px;
            line-height: 40px;
        }

        .inputItem {
            width: 100%;
            font-size: 5vw;
            color: #000;
            padding-left: 10px;
        }

        .clear {
            clear: both;
        }

        .hyzhj {
            font-family: 'Arial','hyzhj','Microsoft YaHei','SimHei' !important;
        }

        .hyxjhj {
            font-family: 'Arial','hyxjhj','Microsoft YaHei','SimHei' !important;
        }

        .topDiv {
            position: fixed;
            z-index: 9999;
            top: 0px;
            left: 0px;
            width: 100%;
            height: 60px;
            background-color: #ffffff;
        }

        .topDivBG {
            position: fixed;
            z-index: 9998;
            top: 0px;
            left: 0px;
            width: 100%;
            height: 60px;
            background-color: #ffffff;
        }

        .navDiv {
            position: absolute;
            top: 25px;
            left: 25px;
        }

            .navDiv img {
                width: 30px;
                height: 25px;
            }

            .navDiv .bb {
                border-bottom: 1px solid #cdcdcd;
                text-align: center;
            }

        .lh {
            height: 30px;
            line-height: 30px;
        }

        .bbs {
            text-align: center;
        }

        .logoDiv {
            position: absolute;
            top: 25px;
            right: 25px;
        }

            .logoDiv img {
                height: 25px;
            }

        .redBarDiv {
            margin-top: 50px;
            margin-left: 25px;
            width: 25px;
            height: 25px;
            border-bottom: 4px solid red;
        }

        .titleDiv {
            margin-top: 25px;
            margin-left: 25px;
            margin-right: 25px;
            height: 25px;
            line-height: 25px;
        }

            .titleDiv p {
                font-size: 26px;
                font-weight: 500;
                color: #000;
            }

        .subtitleDiv {
            margin: 25px 25px 0 25px;
        }

            .subtitleDiv p {
                font-size: 23px;
                font-weight: 300;
                color: #333;
                line-height: 26px;
            }

        .contentDiv {
            margin: 25px;
            position: relative;
        }
    </style>

    <script src="https://rmmgwxdev.chinacloudsites.cn/channelpartnerquery/Scripts/motor/angular.min.js"></script>
    <form id="form1" runat="server">

        <div class="clear"></div>
        <div class="showDiv" runat ="server" id="ShowDiv">
            <div class="inputDiv" style="width: 80%">
                <input type="text" id="txtWhere" class="inputItem hyxjhj ng-valid ng-touched ng-dirty ng-valid-parse ng-empty" style="font-family: 'Arial','hyxjhj','Microsoft YaHei','SimHei'" placeholder="输入经销商全称" ng-model="serialnum">
                <br />
                <br />
                <p id="subtitlepreslut" class="hyxjhj" style="word-break: break-all; font-size: 20px"></p>
                <p id="subtitlep" class="hyxjhj" style="word-break: break-all; font-size: 20px"></p>
            </div>
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div class="clear"></div>
        <div class="submitDiv" ng-click="test()">
            <div style="margin: 250px auto; width: 200px; height: 40px; line-height: 40px; background-color: #A0A0A0; text-align: center;">
                <span style="color: #fff; font-size: 20px" class="hyxjhj" runat="server" id="Btn">查&nbsp;询</span>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
    <script type="text/javascript">

        var app = angular.module("abb", []);
        app.config(function ($httpProvider) {
            $httpProvider.defaults.transformRequest = function (obj) {
                var str = [];
                for (var p in obj) {
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                }
                return str.join("&");
            };
            $httpProvider.defaults.headers.post = {
                'Content-Type': 'application/x-www-form-urlencoded'
            }

        });
        app.controller("abbCtrl", ['$scope', '$http', function ($scope, $http) {
            $scope.serialnum = '';
            $scope.test = function () {
                if ($("#txtWhere").val() == "") {
                    $("#subtitlep").text("请输入经销商名称！！！");
                    return;
                }

                self.location = "?strFilter=" + $("#txtWhere").val();

            }
        }]);

    </script>
</body>
</html>
