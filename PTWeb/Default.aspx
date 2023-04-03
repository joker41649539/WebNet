<%@ Page Title="主页面" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DefaultPH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script charset="utf-8" src="https://map.qq.com/api/js?v=2.exp&key=OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77&libraries=drawing,geometry,autocomplete,convertor"></script>
    <script src="/js/jweixin-1.6.0.js"></script>
    <script type="text/javascript">
        function PleaseWaite() {
            var temp = document.getElementById("demo").innerHTML;

            if (temp == "等待地理位置获取") {
                // alert("地理位置获取失败，请等待，或者重新打开。");
                dialog = jqueryAlert({ 'content': '地理位置获取失败，请稍后，或者重新打开。' });
                return false;
            }
        }
        function OpenMap(iJD, iWD) {
            wx.openLocation({
                latitude: iJD,
                longitude: iWD,
                name: '我在这里',
                address: '这在哪',// document.getElementById("TextBox_WZ").value,
                scale: 14
            });
        }
        wx.config({
            beta: true,
            debug: false,
            appId: '<%=this.appId%>',
            timestamp: '<%=this.timeStamp%>',
            nonceStr: '<%=this.nonceStr%>',
            signature: '<%=this.signature%>',
            jsApiList: [
                'checkJsApi',
                'openLocation',
                'getLocation',
            ]
        });
        wx.ready(function () {
            wx.checkJsApi({
                jsApiList: [
                    'getLocation'
                ],
                success: function (res) {
                    if (res.checkResult.getLocation == false) {
                        alert('你的微信版本太低，不支持微信JS接口，请升级到最新的微信版本！');
                        return;
                    }
                }
            });
            wx.getLocation({
                type: "gcj02",
                success: function (res) {
                    $.ajax({
                        type: 'get',
                        url: '/TencentMap/PrivateMap.ashx',
                        dataType: 'json',
                        contentType: 'application/json',
                        data: {
                            longitude: res.longitude,
                            latitude: res.latitude
                        },
                        success: function (responseData) {
                            if (responseData) {
                                var address = responseData.address;
                                // 0 地址 1 标题 2 mapid 3 计划目的 4 手工单号 5 工程名称
                                const arr1 = address.split(';');

                                document.getElementById("Hidden_WZ").value = responseData.address;
                                document.getElementById("Hidden_Name").value = responseData.name;
                                document.getElementById("Hidden_Screen").value = "[" + screen.width + "]*[" + screen.height + "]";
                                document.getElementById("Hidden_JD").value = res.longitude; // 精度赋值
                                document.getElementById("Hidden_WD").value = res.latitude; // 维度赋值

                                document.getElementById("demo").innerHTML = arr1[0] + ";" + arr1[1]; //+ "[" + responseData.innerHTML + "]";
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.readyState + XMLHttpRequest.status + XMLHttpRequest.responseText);
                        }
                    });
                },
                fail: function (err) {
                    //  alert('用户地理位置获取错误。' + err);
                },
                cancel: function (res) {
                    dialog = jqueryAlert({ 'content': '用户拒绝授权获取地理位置。' });
                    //  alert('用户拒绝授权获取地理位置');
                }
            });
        });
    </script>
    <asp:HiddenField ID="Hidden_WZ" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_Name" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_Screen" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_JD" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_WD" ClientIDMode="Static" runat="server" />
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a class="active" href="/Default.aspx">首页</a>
            </li>
        </ul>
    </div>
    <div class="row">
        <div class="col-xs-6">
            <h3 class="header smaller lighter green">
                <i class="icon-bullhorn"></i>
                快速菜单
            </h3>
            <div class="infobox infobox-blue2" runat="server" id="DivGCWXD">
                <div class="infobox-icon">
                    <i class="icon-book"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">维修报告</span>
                    <a href="/BGGL/GCWXDList.ASPX">
                        <div class="infobox-content">
                            维修服务单
                        </div>
                    </a>
                </div>
            </div>
            <div class="infobox infobox-green2" runat="server" id="DivBX">
                <div class="infobox-icon">
                    <i class="icon-edit"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">布线填报</span>
                    <a href="/GDGL/MyBXGD.ASPX">
                        <div class="infobox-content">
                            <asp:Label ID="Label_MyBXNum" runat="server" Text="[0] 条布线工程"></asp:Label>
                        </div>
                    </a>
                </div>
            </div>
            <div class="infobox infobox-red" runat="server" id="DivAZ">
                <div class="infobox-icon">
                    <i class="icon-edit"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">安装填报</span>
                    <a href="/GDGL/MyAZGD.ASPX">
                        <div class="infobox-content">
                            <asp:Label ID="Label_MyAZNum" runat="server" Text="[0] 条安装工程"></asp:Label>
                        </div>
                    </a>
                </div>
            </div>
            <div class="infobox infobox-blue3" runat="server" id="Div_WorkPlan">
                <div class="infobox-icon">
                    <i class="icon-briefcase"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">工作计划</span>
                    <a href="/GDGL/WorkPlan.aspx">
                        <div class="infobox-content">
                            <asp:Label ID="Label2" runat="server" Text="填报工作计划"></asp:Label>
                        </div>
                    </a>
                </div>
            </div>
            <div class="infobox infobox-pink">
                <div class="infobox-icon">
                    <i class="icon-coffee"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">费用报销</span>
                    <a href="/CWGL/ReimbursementAdd.aspx">
                        <div class="infobox-content">
                            <asp:Label ID="Label1" runat="server" Text="我要报销"></asp:Label>
                        </div>
                    </a>
                </div>
            </div>
            <div class="infobox infobox-grey">
                <div class="infobox-icon">
                    <i class="icon-envelope"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">系统问题反馈</span>
                    <a href="/Bug/">
                        <div class="infobox-content">
                            <asp:Label ID="Label3" runat="server" Text="我要反馈系统问题"></asp:Label>
                        </div>
                    </a>
                </div>
            </div>
        </div>

        <div class="col-xs-6">
            <div class="col-sm-6">
                <div class="widget-box">
                    <div class="widget-header widget-header-flat widget-header-small">
                        <h5>
                            <i class="icon-signal"></i>
                            积分信息
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main">
                            <div id="piechart-placeholder"></div>
                            <div class="clearfix">
                                <div class="grid1">
                                    <span class="grey">
                                        <i class="icon-calendar blue"></i>
                                        &nbsp;本月：<asp:Label ID="Label_Month" runat="server" Text="0"></asp:Label>
                                    </span>
                                </div>

                                <div class="grid1">
                                    <span class="grey">
                                        <i class="icon-bar-chart purple"></i>
                                        &nbsp;本周：<asp:Label ID="Label_Week" runat="server" Text="0"></asp:Label>
                                    </span>
                                </div>
                                <div class="grid1">
                                    <span class="success">
                                        <i class="icon-flag success"></i>
                                        &nbsp;昨日：<asp:Label ID="Label_YesDay" runat="server" Text="0"></asp:Label>
                                    </span>
                                </div>
                                <div class="grid1">
                                    <span class="grey">
                                        <i class="icon-legal red"></i>
                                        &nbsp;今日：<asp:Label ID="Label_Day" runat="server" Text="0"></asp:Label>
                                    </span>
                                </div>
                                <%--<div class="grid1">
                                    <span class="grey">
                                        <i class="icon-signal green"></i>
                                        &nbsp; 排名：4
                                    </span>
                                </div>--%>
                            </div>
                        </div>
                        <!-- /widget-main -->
                    </div>
                    <!-- /widget-body -->
                </div>
                <!-- /widget-box -->
            </div>
            <!-- /span -->
            <%--<asp:RadioButtonList RepeatColumns="4" ID="RadioButtonList1" runat="server">
                <asp:ListItem>上班</asp:ListItem>
                <asp:ListItem>下班</asp:ListItem>
                <asp:ListItem>维修开始</asp:ListItem>
                <asp:ListItem>维修结束</asp:ListItem>
                <asp:ListItem>施工</asp:ListItem>
                <asp:ListItem>离场</asp:ListItem>
                <asp:ListItem>出差</asp:ListItem>
                <asp:ListItem>到达</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Button1" class="btn btn-danger btn-block" OnClientClick="return PleaseWaite()" runat="server" Text="快速签到" OnClick="Button1_Click" />
            --%>  <%--            <asp:Button ID="Button2" class="btn btn-danger btn-block" runat="server" Text="快速签到" OnClick="Button2_Click" />--%>
            <div class="alert alert-success" id="alertClass">
                <b>
                    <p id="demo">等待地理位置获取</p>
                </b>
            </div>
            <div runat="server" id="Div_QDLastData" />
            <a href='/WeChat/QDSearch.aspx' class="btn btn-default btn-block">我要签到</a>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1><i class="icon-bullhorn"></i>工作计划</h1>
        </div>
        <asp:GridView ID="GridView_WorkPlan" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID,WID" >
            <Columns>
                <asp:BoundField DataField="NRemark" SortExpression="NRemark" HeaderText="说明"></asp:BoundField>
                <asp:BoundField DataField="GCDD" SortExpression="GCDD" HeaderText="地点"></asp:BoundField>
                <asp:BoundField DataField="LTime" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" SortExpression="lt" HeaderText="日期"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

