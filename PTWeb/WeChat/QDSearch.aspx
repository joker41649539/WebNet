<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QDSearch.aspx.cs" Inherits="WeChat_QDSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/jweixin-1.6.0.js"></script>
    <script type="text/javascript">
        var i = 0;// 用于计算ID
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
                        url: 'map.ashx',
                        dataType: 'json',
                        contentType: 'application/json',
                        data: {
                            longitude: res.longitude,
                            latitude: res.latitude
                        },
                        success: function (responseData) {
                            if (responseData) {

                                document.getElementById("Hidden_WZ").value = responseData.address;
                                document.getElementById("Hidden_Name").value = responseData.name;
                                document.getElementById("Hidden_Screen").value = "[" + screen.width + "]*[" + screen.height + "]";
                                document.getElementById("Hidden_JD").value = res.longitude; // 精度赋值
                                document.getElementById("Hidden_WD").value = res.latitude; // 维度赋值

                                document.getElementById("demo").innerHTML = responseData.address; //+ "[" + responseData.innerHTML + "]";
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

        function init(a1, a2, b1, b2) {
            var a = new qq.maps.LatLng(a1, a2);
            var b = new qq.maps.LatLng(b1, b2);
            //计算两点间的距离
            dialog = jqueryAlert({ 'title': '提示信息', 'content': '两点直线距离约为：' + (qq.maps.geometry.spherical.computeDistanceBetween(a, b) / 1000).toFixed(2) + ' 千米', 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close(); } } })
        }

        function CreateInput() { ///创建图片上传框
            var input = document.createElement("input");
            var MaxCount = 5; // 最大数量
            i++
            input.type = "file";
            input.capture = "camera";// 照相机
            input.accept = "image/*";// 文件类型
            input.name = "AddImg";
            input.id = "id-input" + i;
            document.getElementById("showUpImg").appendChild(input);
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
        function PleaseWaite() {
            var temp = document.getElementById("demo").innerHTML;

            if (temp == "等待地理位置获取") {
                dialog = jqueryAlert({ 'content': '地理位置获取失败，请等待，或者重新打开。' });
                // alert("地理位置获取失败，请等待，或者重新打开。");
                return false;
            }
        }
    </script>
    <script charset="utf-8" src="https://map.qq.com/api/js?v=2.exp&key=OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77&libraries=drawing,geometry,autocomplete,convertor"></script>

    <asp:HiddenField ID="Hidden_WZ" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_Name" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_Screen" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_JD" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="Hidden_WD" ClientIDMode="Static" runat="server" />
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/WeChat/QDSearch.aspx">签到记录</a></li>
        </ul>
    </div>

    <div class="page-content">
        <div class="page-header">
            <h1>签到记录<small><i class="icon-double-angle-right"></i>&nbsp;<a href="/WeChat/QDSearch.aspx">添加详细签到</a>                                </small></h1>
        </div>
        <div class="alert alert-info content">
            <h5><b>签到说明：</b></h5>
            <h6>&nbsp;&nbsp;&nbsp;&nbsp;签到分为<b>[快速签到]</b>和<b>[详细签到]</b>两种。</h6>
            <h5><b>快速签到</b></h5>
            <h6>&nbsp;&nbsp;&nbsp;&nbsp;用于日常签到。</h6>
            <h6>&nbsp;&nbsp;&nbsp;&nbsp;快速签到分为 <b>上班-下班；维修开始-维修结束；施工-离场；出差-到达；</b> 8项快捷分类。</h6>
            <h6>&nbsp;&nbsp;&nbsp;&nbsp;当签到类别选择 <b>维修开始、施工、出差</b>并完成签到后，下一次的签到系统会默认对应上 <b>维修结束、离场、到达</b>；直接点击快速签到即可完成签到任务。</h6>
            <h5><b>详细签到</b></h5>
            <h6>&nbsp;&nbsp;&nbsp;&nbsp;当您需要<b>上传照片</b>，或者备注<b>说明信息</b>的时候需要用到。</h6>
        </div>
        <div class="row">
            <div class="alert alert-success" id="alertClass">
                <b>
                    <p id="demo">等待地理位置获取</p>
                </b>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">目的地</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_MDD" runat="server" placeholder="请输入目的地" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">详细说明</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Remark" TextMode="MultiLine" runat="server" placeholder="请输入详细说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片</label>
                    <div class="col-sm-9" id="showUpImg">
                        <input type="file" name="UpImg" id="id-input" capture="camera" accept="image/*" />
                    </div>

                    <%--<div class="col-sm-9" id="preview1">
                        <input type="file" name="UpImg" capture="camera" value="拍照" accept="image/*" />
                        <input id="AddImg" type="button" class="btn btn-info" value="+" onclick="add()" />
                        <input type="file" name="UpImg" capture="camera" value="拍照" id="id-input1" accept="image/*" />
                        <asp:FileUpload ID="FileUpload_TP" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                        <asp:Image ID="Image1" Width="100px" ClientIDMode="Static" runat="server" />
                    </div>--%>
                </div>
            </div>
            <div class="col-xs-12" runat="server" id="WellList" />
        </div>
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="return PleaseWaite(); this.setAttribute('disabled', 'disabled')" ID="GridView_Bug_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_Bug_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 签 到</asp:LinkButton>
            </div>
        </div>
        <div class="page-content">
            <div id="QDList" runat="server" class="timeline-container"></div>
        </div>
    </div>
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input').ace_file_input({
                style: 'well',
                btn_choose: '点击上传图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large',// large | small
                preview_error: function (filename, error_code) {

                }
            }).on('change', function () {
                CreateInput();
            });
        });
    </script>
</asp:Content>
