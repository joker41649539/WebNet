﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>普田科技</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="robots" content="noarchive" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimal-ui" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="shortcut icon" type="image/x-icon" href="/images/ptlogo.png" media="screen" />

    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/alert/alert.css" />

    <link rel="stylesheet" href="/assets/css/datepicker.css" />
    <link rel="stylesheet" href="/assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="/assets/css/daterangepicker.css" />
    <%--///////////////////////////////////--%>

    <%--//////////////////////////////////--%>

    <script src='/assets/alert/alert.js'></script>

    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>
</head>
<body>
    <script type="text/javascript">
        //$.ajax({
        //    type: 'get',
        //    url: '/TencentMap/PrivateMap.ashx',
        //    dataType: 'json',
        //    contentType: 'application/json',
        //    data: {
        //        longitude: 117.30343,
        //        latitude: 31.853798
        //    },
        //    success: function (responseData) {
        //        if (responseData) {
        //            var address = responseData.address;
        //            // 0 地址 1 标题 2 mapid 3 计划目的 4 手工单号 5 工程名称
        //            const arr1 = address.split(';');
        //            if (arr1.length > 2) {
        //                alert(arr1[2] + "||" + address);
        //            }
        //            else {
        //                alert(arr1[0]);
        //            }
        //        }
        //    },
        //    error: function (XMLHttpRequest, textStatus, errorThrown) {

        //    }
        //});

        jQuery(function ($) {
            $('#id-input').ace_file_input({
                style: 'well',
                btn_choose: '请点击拍照',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large'
            }).on('change', function () {
                CreateInput();
            });
        });

        function OpenSelect() {
            //jQuery(function ($) {
            $("#YesOrNo").modal('show');
            //  dialog = jqueryAlert({ 'title': '提示消息', 'content': '您确定吗？', 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close();}, '取消': function () { dialog.destroy(); dialog.close(); } } });

            return false
            // });
        };

        var i = 0;// 用于计算ID
        function CreateInput() {
            var input = document.createElement("input");
            var MaxCount = 5; // 最大数量
            i++
            input.type = "file";
            input.capture = "camera";// 照相机
            input.accept = "image/*";// 文件类型
            input.name = "AddImg";
            input.id = "id-input" + i;
            document.getElementById("showText").appendChild(input);
            jQuery(function ($) {
                $('#' + input.id + '').ace_file_input({
                    style: 'well',
                    btn_choose: '请点击拍照',
                    btn_change: null,
                    no_icon: 'icon-cloud-upload',
                    droppable: true,
                    thumbnail: 'large'
                }).on('change', function () {
                    if (i < MaxCount - 1) { //达到最大数量后不添加
                        CreateInput();//图片选择后，自动添加
                    }
                });
            });
        }
    </script>

    <div class="modal fade" id="Select" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="control-group">
                    <div class="checkbox">
                        <label>
                            <input name="form-field-checkbox" type="checkbox" class="ace" />
                            <span class="lbl">choice 1</span>
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input name="form-field-checkbox" type="checkbox" class="ace" />
                            <span class="lbl">choice 2</span>
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input name="form-field-checkbox" class="ace ace-checkbox-2" type="checkbox" />
                            <span class="lbl">choice 3</span>
                        </label>
                    </div>
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
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="profile-info-value">
            <div id="ContentPlaceHolder1_RadioBM" class="control-group">
                <div class="radio">
                    <label>
                        <input name="radioBM" value="19;合肥协同" type="radio" class="ace" /><span class="lbl">&nbsp;合肥协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="radioBM" value="20;六安协同" type="radio" class="ace" /><span class="lbl">&nbsp;六安协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="21;芜湖协同" type="radio" class="ace" /><span class="lbl">&nbsp;芜湖协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="22;安庆协同" type="radio" class="ace" /><span class="lbl">&nbsp;安庆协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="23;马鞍山协同" type="radio" class="ace" /><span class="lbl">&nbsp;马鞍山协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="24;安庆宿松协同" type="radio" class="ace" checked="checked" /><span class="lbl">&nbsp;安庆宿松协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="25;安庆桐城协同" type="radio" class="ace" /><span class="lbl">&nbsp;安庆桐城协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="27;六安舒城协同" type="radio" class="ace" /><span class="lbl">&nbsp;六安舒城协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="28;六安金寨协同" type="radio" class="ace" /><span class="lbl">&nbsp;六安金寨协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="29;安庆池州协同" type="radio" class="ace" /><span class="lbl">&nbsp;安庆池州协同</span>
                    </label>
                </div>
                <div class="radio">
                    <label>
                        <input name="radioBM" value="30;测试部门1" type="radio" class="ace" /><span class="lbl">&nbsp;测试部门1</span>
                    </label>
                </div>
            </div>
        </div>
        <div class="page-content">
            <div class="input-group">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入视频网址" class="form-control search-query"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:LinkButton ID="LinkButton2" class="btn btn-purple btn-sm" OnClick="LinkButton2_Click" runat="server">保存<i class="icon-save icon-on-right bigger-110"></i></asp:LinkButton>
                </span>
            </div>
        </div>
        <div class="widget-body">
            <div class="widget-main" id="showText">
                <input name="AddImg" capture="camera" accept="image/*" type="file" id="id-input" />
            </div>
        </div>
        <hr />
        <div class="">
            <asp:LinkButton UseSubmitBehavior="false" ClientIDMode="Static" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>提交申请</b></asp:LinkButton>
        </div>
        <div class="col-xs-9">
            <div class="input-group">
                <asp:TextBox ID="TextBoxSTime" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker"></asp:TextBox>
                <span class="input-group-addon">
                    <i class="icon-calendar bigger-110"></i>
                </span>
            </div>
        </div>
        <input name="Text1" type="text" />
        <input name="Text1" type="text" />
        <div class="row">

            <asp:LinkButton ID="LinkButton3" OnClientClick="return OpenSelect()" runat="server"><i class="icon-off"></i>
                                        点击选择</asp:LinkButton>
        </div>
        <input class="form-control" data-date-format="yyyy-mm-dd" type="text" name="date-range-picker" id="id-date-range-picker-1" />
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
        <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Button" />
        <div id="Div_Temp" runat="server"></div>
        <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>
        <script src="/assets/js/date-time/bootstrap-timepicker.min.js"></script>
        <script src="/assets/js/date-time/moment.min.js"></script>
        <script src="/assets/js/date-time/daterangepicker.min.js"></script>

        <!-- ace scripts -->

        <script src="/assets/js/ace-elements.min.js"></script>
        <script src="/assets/js/ace.min.js"></script>

        <script type="text/javascript">
            jQuery(function ($) {
                $('input[name=date-range-picker]').daterangepicker().prev().on(ace.click_event, function () {
                    $(this).next().focus();
                });
                $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                    $(this).prev().focus();
                });

                $(".chosen-select").chosen();

            });
        </script>
    </form>

</body>
</html>
