<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="WeChat_Tesp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上传照片</label>
                                    <asp:FileUpload ID="FileUpload_TP" class="chenck_upload left" runat="server" ClientIDMode="Static" onchange="changesrc(this.id)" />
                                    <img id="upImg" src=" " />
                                    <%--                                    <input id="Text1" type="text" readonly="readonly" />
                                    <button type="button" class="btn btn-primary " onclick="FileUpload_TP.click()"><i class="icon-plus-sign bigger-150"></i></button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function selected(obj) {
            var str = "carpoolpic";
            str = str + obj.value;
            var imgSrc = document.getElementById(str).value;
            if (imgSrc == "" || imgSrc == null) {
                alert("此项没有图片");
                obj.checked = false;
            }
            changesrc(str);
        }

        var flag = true;
        function changesrc(sender) {
            if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {
                var imgSrc = document.getElementById(sender).value;
                var t = document.getElementById(sender);
                if (imgSrc == "") {
                    flag = false;
                    return false;
                }
                if (/(.*?)\.jpg$/.test(imgSrc.toLowerCase()) == false) {
                    document.getElementById(sender).value = "";
                    alert("只能选择jpg格式!");
                    flag = false;
                    return false;
                } else {
                    var imgs = document.createElement("img");
                    imgs.src = imgSrc;

                    if (imgs.fileSize > 50 * 1024) {
                        alert("图片大小不能超过 50 KB!");
                        flag = false;
                        return false;
                    }
                    flag = true;
                }
                document.getElementById("upImg").src = window.URL.createObjectURL(t.files[0]);
            } else {
                document.getElementById(sender).select();
                var imgSrc = document.selection.createRange().text;
                if (imgSrc == "") {
                    flag = false;
                    return false;
                }
                if (/(.*?)\.jpg$/.test(imgSrc.toLowerCase()) == false) {
                    document.getElementById(sender).value = "";
                    alert("只能选择jpg格式!");
                    flag = false;
                    return false;
                } else {
                    var imgs = document.createElement("img");
                    imgs.src = imgSrc;
                    flag = true;
                }
                document.getElementById("upImg").src = imgSrc;
            }
        }

        function checkpic() {
            var raFlag = false;
            var obj = document.getElementsByName("select");
            for (var i = 0; i < obj.length; i++) {
                if (obj[i].checked) {
                    raFlag = true;
                    break;
                } else {
                    raFlag = false;
                }
            }
            if (raFlag == false && flag == true) {
                alert("请选择最新的照片");
            }
            var subFlag = false;
            subFlage = flag && raFlag;
            flag = false;
            return subFlage;
        }
    </script>
</asp:Content>

