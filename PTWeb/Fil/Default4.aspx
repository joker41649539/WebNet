<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimal-ui" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />

    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <script src="/assets/js/ace-extra.min.js"></script>
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/assets/alert/alert.css" />
    <script src='/assets/alert/alert.js'></script>
    <script src='/assets/alert/shCore.js'></script>

    <script src='/assets/alert/makeSy.js'></script>

    <link rel="shortcut icon" type="image/x-icon" href="/images/lu32.ico" media="screen" />
    <title>Fil-f063628节点情况</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-content">
            <div class="page-header">
                <h1>f063628节点情况
                <small>
                    <i class="icon-double-angle-right"></i>
                    汇总信息
                </small>
                </h1>
            </div>
            <div class="row">
                <div class="space-6"></div>
                <div class="col-sm-7 infobox-container">
                    <div class="infobox infobox-red  ">
                        <div class="infobox-icon">
                            <i class="icon-key"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">369091.01</span>
                            <div class="infobox-content">目前可支配资产(元)</div>
                        </div>
                    </div>
                    <div class="infobox infobox-green  ">
                        <div class="infobox-icon">
                            <i class="icon-credit-card"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">-230098.99</span>
                            <div class="infobox-content">盈亏数据(元)</div>
                        </div>
                    </div>
                    <div class="infobox infobox-blue  ">
                        <div class="infobox-icon">
                            <i class=" icon-bolt"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">1.38</span>
                            <div class="infobox-content">总算力(Tib)</div>
                        </div>
                    </div>
                    <div class="infobox infobox-blue  ">
                        <div class="infobox-icon">
                            <i class="icon-calendar"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">0.864</span>
                            <div class="infobox-content">日增长(Tib)</div>
                        </div>
                    </div>
                    <div class="infobox infobox-blue3  ">
                        <div class="infobox-icon">
                            <i class="icon-coffee"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">6 天</span>
                            <div class="infobox-content">总运行(2020-01-01起)</div>
                        </div>
                    </div>
                    <div class="infobox infobox-red  ">
                        <div class="infobox-icon">
                            <i class="icon-leaf"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">539.35</span>
                            <div class="infobox-content">可用FIL余额</div>
                        </div>
                    </div>
                    <div class="infobox infobox-red  ">
                        <div class="infobox-icon">
                            <i class="icon-credit-card"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">76194.01</span>
                            <div class="infobox-content">FIL市值(估算)(RMB 元)</div>
                        </div>
                    </div>
                    <div class="infobox infobox-blue3  ">
                        <div class="infobox-icon">
                            <i class="icon-desktop"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">163859</span>
                            <div class="infobox-content">硬件投入(元)</div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- 主循环 结束-->
            <div class="row" style="height: 80px;">
            </div>
            <!-- 底部代码 开始-->
            <div runat="server" id="FootBut">
                <ul class="footer-nav text-center">
                    <li><a class="btn btn-app btn-white btn-xs" href="#"><i class="icon-home"></i>汇总信息</a></li>
                    <li><a class="btn btn-app btn-white btn-xs" href="#"><i class="icon-book"></i>明细信息</a></li>
                </ul>
            </div>
            <!-- 底部代码 结束-->
        </div>
    </form>
</body>
</html>
