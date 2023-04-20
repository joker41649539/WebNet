<%@ Page Title="" Language="C#" MasterPageFile="~/TuanGou/MasterPage.master" AutoEventWireup="true" CodeFile="OfferAdd.aspx.cs" Inherits="TuanGou_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="/assets/css/datepicker.css" />
    <link rel="stylesheet" href="/assets/css/bootstrap-timepicker.css" />
    <link rel="stylesheet" href="/assets/css/daterangepicker.css" />
    <script type="text/javascript">
        function check() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var vTitle = document.getElementById("TextBox1").value;
            var vXFJE = document.getElementById("TextBox_XFJE").value;
            var vTime = document.getElementById("TextBox_SETime").value;
            var Msg;
            if (vTitle.length <= 0) {
                rValue = false;
                Msg = "标题必须填写。<br/>";
            }
            if (vXFJE.length <= 0) {
                rValue = false;
                Msg += "消费金额必须填写为 > 0 的数字。<br/>";
            }
            if (vTime.length != 23) {
                rValue = false;
                Msg += "起止日期填写错误，请检查。";
            }
            if (Msg.length > 0) {
                dialog = jqueryAlert({ 'content': Msg });
            }
            return rValue;
        }
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

        var i = 0;// 用于计算ID
        function CreateInput() {
            var input = document.createElement("input");
            var MaxCount = 5; // 最大数量
            i++
            input.type = "file";
            // input.capture = "camera";// 照相机
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
    <div class="center">
        <div class="page-content" style="height: auto;">
            <span class="profile-picture">
                <img id="ContentPlaceHolder1_Image_User" class="editable img-responsive" src="/images/XMFightLogo.jpg" style="max-width: 150px" />
            </span>
            <div class="space-4"></div>
            <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                <div class="inline position-relative">
                    <a href="#" class="user-title-label dropdown-toggle">
                        <i class="icon-circle light-green middle"></i>
                        <span id="ContentPlaceHolder1_Label_Name" class="white">旭铭搏击</span>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class="row page-content height-auto">
        <div class="page-header">
            <h5>团购信息录入</h5>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标题</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入标题信息 " class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">金额</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_XFJE" ClientIDMode="Static" runat="server" placeholder="请输入消费金额" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">起止时间</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_SETime" ClientIDMode="Static" runat="server" placeholder="请输入起止时间 " class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label7" class="col-sm-3 control-label no-padding-right" for="form-field-1">上传图片：</label>
                <div class="col-sm-9 widget-main" id="showText">
                    <input name="AddImg" accept="image/*" type="file" id="id-input" />
                </div>
            </div>
        </div>
        <hr />
        <div class="col-xs-12 page-header">
            <p>
                <asp:LinkButton ID="LinkButton1" OnClientClick="return check();" class="btn btn-info " runat="server" OnClick="LinkButton1_Click"><i class="icon-save bigger-110"></i> 保存数据</asp:LinkButton>
            </p>
        </div>
    </div>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <script src="/assets/js/date-time/bootstrap-timepicker.min.js"></script>
    <script src="/assets/js/date-time/moment.min.js"></script>
    <script src="/assets/js/date-time/daterangepicker.min.js"></script>
    <script>	
        $('input[id=TextBox_SETime]').daterangepicker().prev().on(ace.click_event, function () {
            $(this).next().focus();
        });
    </script>

</asp:Content>

