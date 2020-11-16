<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KQ.aspx.cs" Inherits="WeChat_KQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://res.wx.qq.com/open/js/jweixin-1.6.0.js"></script>
    <script type="text/javascript">
        wx.config({
            beta: true,
            debug: true,
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
                    document.getElementById("TextBox_WD").value = res.longitude;
                    document.getElementById("TextBox_JD").value = res.latitude;

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
                                // alert(responseData.address);
                                document.getElementById("TextBox_WZ").value = responseData.address;
                                //wx.openLocation({
                                //    latitude: res.latitude,
                                //    longitude: res.longitude,
                                //    name: '我在这',
                                //    address: responseData.address,
                                //    scale: 14
                                //});
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(XMLHttpRequest.readyState + XMLHttpRequest.status + XMLHttpRequest.responseText);
                        }
                    });
                },
                cancel: function (res) {
                    alert('用户拒绝授权获取地理位置');
                }
            });
            //  地理位置接口   //alert(JSON.stringify(res));
            //  查看地理位置
            document.querySelector('#openLocation').onclick = function () {
                wx.openLocation({
                    latitude: document.getElementById("TextBox_JD").value,
                    longitude: document.getElementById("TextBox_WD").value,
                    name: '我在这里',
                    address: document.getElementById("TextBox_WZ").value,
                    scale: 14
                });
            };
        });
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">微信相关</a></li>
            <li class="active"><a href="/WeChat/KQ.aspx">签到打卡</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">

        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">我要签到</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">我的签到</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">姓名</label>
                                    <div class="col-sm-9">
                                        <h1>
                                            <asp:Label ID="Label_XM" runat="server" ClientIDMode="Static" Text="姓名"></asp:Label>
                                        </h1>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">我的坐标</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_JD" runat="server" ClientIDMode="Static" Enabled="true" onfocus="this.blur()" placeholder="请等待坐标获取" class="col-xs-3 col-sm-3"></asp:TextBox>
                                        <asp:TextBox ID="TextBox_WD" runat="server" ClientIDMode="Static" Enabled="true" onfocus="this.blur()" placeholder="请等待坐标获取" class="col-xs-3 col-sm-3"></asp:TextBox>
                                        <button class="btn btn_primary" id="openLocation">查看地图</button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">我的位置</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_WZ" ClientIDMode="Static" runat="server" Enabled="true" onfocus="this.blur()" placeholder="请等待位置获取" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注信息</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_Remark" ClientIDMode="Static" runat="server" TextMode="MultiLine" placeholder="请填写您的备注信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片1</label>
                                    <div class="col-sm-9" id="preview1">
                                        <asp:FileUpload ID="FileUpload_TP" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image1" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片2</label>
                                    <div class="col-sm-9" id="preview2">
                                        <asp:FileUpload ID="FileUpload_TP2" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image2" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片3</label>
                                    <div class="col-sm-9" id="preview3">
                                        <asp:FileUpload ID="FileUpload_TP3" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image3" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片4</label>
                                    <div class="col-sm-9" id="preview4">
                                        <asp:FileUpload ID="FileUpload_TP4" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image4" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片5</label>
                                    <div class="col-sm-9" id="preview5">
                                        <asp:FileUpload ID="FileUpload_TP5" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image5" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片6</label>
                                    <div class="col-sm-9" id="preview6">
                                        <asp:FileUpload ID="FileUpload_TP6" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image6" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片7</label>
                                    <div class="col-sm-9" id="preview7">
                                        <asp:FileUpload ID="FileUpload_TP7" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image7" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片8</label>
                                    <div class="col-sm-9" id="preview8">
                                        <asp:FileUpload ID="FileUpload_TP8" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image8" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片9</label>
                                    <div class="col-sm-9" id="preview9">
                                        <asp:FileUpload ID="FileUpload_TP9" runat="server" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                                        <asp:Image ID="Image9" ClientIDMode="Static" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix form-actions">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_JG_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_JG_LinkButton1_Click"><i class="icon-ok bigger-110"></i>签到打卡</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        <%--<div class="row">
                            <div class="widget-header widget-header-flat">
                                <h4 class="lighter"><i class="icon-inbox"></i>查询条件</h4>
                                <asp:DropDownList ID="GridView_MSG_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="W_KQ.Ctime">日期</asp:ListItem>
                                    <asp:ListItem Value="CNAME">姓名</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="GridView_MSG_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                                    <asp:ListItem Value=">">大于</asp:ListItem>
                                    <asp:ListItem Value="<">小于</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="GridView_MSG_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_MSG_TJADD" OnClick="GridView_MSG_TJADD_Click"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                                <div id="GridView_FXX_alerts_tj" runat="server" class="alert alert-success" visible="false">
                                    <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                                    <asp:Label ID="GridView_MSG_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_MSG_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_FXX_LinkButton3" OnClick="GridView_FXX_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                                    <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_FXX_LinkButton4" OnClick="GridView_FXX_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
                                </div>
                            </div>--%>
                        <div class="hr-10"></div>
                        <div id="QDList" runat="server" class="timeline-container">
                            <%--<div class="timeline-container">
                                <div class="timeline-label">
                                    <span class="label label-primary arrowed-in-right label-lg">
                                        <b>2020-03-22</b>
                                    </span>
                                </div>
                                <div class="timeline-items">
                                    <div class="timeline-item clearfix">
                                        <div class="timeline-info">
                                            <span class="label label-info label-sm">08:00</span>
                                        </div>
                                        <div class="widget-box transparent">
                                            <div class="widget-header widget-header-small">
                                                <span class="widget-toolbar">
                                                    合肥瑶海区明皇路
                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>
                                                </span>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <img src="/KQImage/SY20200322102824930.jpg" />
                                                    <img src="/KQImage/SY20200322102824930.jpg" />
                                                    我在这里签到上班
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.timeline-container -->
                                    <div class="timeline-item clearfix">
                                        <div class="timeline-info">
                                            <span class="label label-info label-sm">18:00</span>
                                        </div>
                                        <div class="widget-box transparent">
                                            <div class="widget-header widget-header-small">
                                                <span class="widget-toolbar">
                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>
                                                </span>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    我在这里签到下班
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.timeline-container -->
                            <div class="timeline-container">
                                <div class="timeline-label">
                                    <span class="label label-primary arrowed-in-right label-lg">
                                        <b>2020-03-21</b>
                                    </span>
                                </div>
                                <div class="timeline-items">
                                    <div class="timeline-item clearfix">
                                        <div class="timeline-info">
                                            <span class="label label-info label-sm">08:00</span>
                                        </div>
                                        <div class="widget-box transparent">
                                            <div class="widget-header widget-header-small">
                                                <span class="widget-toolbar">
                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>
                                                </span>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    我在这里签到上班
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.timeline-container -->
                                    <div class="timeline-item clearfix">
                                        <div class="timeline-info">
                                            <span class="label label-info label-sm">18:00</span>
                                        </div>
                                        <div class="widget-box transparent">
                                            <div class="widget-header widget-header-small">
                                                <span class="widget-toolbar">
                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>
                                                </span>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    我在这里签到上班
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.timeline-container -->--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var eleFile = document.querySelector('#FileUpload_TP');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image1.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP2');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image2.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP3');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image3.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP4');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image4.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP5');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image5.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP6');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image6.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP7');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image7.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP8');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image8.src = newUrl;
                };
            }
        });
        var eleFile = document.querySelector('#FileUpload_TP9');
        eleFile.addEventListener('change', function () {
            var file = this.files[0];
            // 确认选择的文件是图片                
            if (file.type.indexOf("image") == 0) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    // 图片base64化
                    var newUrl = this.result;
                    Image9.src = newUrl;
                };
            }
        });

    </script>
</asp:Content>

