<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">测试模块</a></li>
            <li class="active"><a href="#">测试界面</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>测试模块<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;测试界面</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加信息</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">信息一</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">信息二</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div id="ContentPlaceHolder1_HtmlGrid" class="infobox-container">
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-group"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">儿童英语一班</span>
                                    <div class="infobox-content"><a href="#">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">陈老师</a>     </div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-group"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">儿童英语一班</span>
                                    <div class="infobox-content"><a href="#">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">陈老师</a>     </div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-group"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">儿童英语一班</span>
                                    <div class="infobox-content"><a href="#">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">陈老师</a>     </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        111
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-sm" style="padding: 10px;">
                                    <div id="signature" style="border-style: dashed; border-width: 1px;"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <button type="button" class="btn btn-success btn-block" data-toggle="modal"
                                        data-target="#saveConfirmModel">
                                        保存</button>
                                </div>
                                <div class="col-sm">
                                    <button id="clearBtn" type="button" class="btn btn-danger btn-block">清除</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
   <%-- <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.0/js/bootstrap.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jSignature/2.1.3/jSignature.min.js"></script>
    <script>
        $(document).ready(function () {
            var arguments = {
                width: '100%',
                height: '300px',
                signatureLine: false,
                lineWidth: '5'
            };
            $('#signature').jSignature(arguments);
            // 清除按钮
            $('#clearBtn').click(function () {
                $('#signature').jSignature('reset');
            });
            // 保存按钮
            $('#save').click(function () {
                var dataPair = $('#signature').jSignature('getData', 'image');
                var signatureImage = new Image();
                signatureImage.src = 'data:' + dataPair[0] + ',' + dataPair[1];
                signatureImage.image = dataPair[1];

                //$.ajax({
                //    url: '/saveSignature.ashx',
                //    contentType: 'application/json; charset=utf-8',
                //    data: {
                //        signatureData: signatureImage.image
                //    },
                //    type: 'post',
                //    cache: false,
                //    success: function (result) {
                //        if (result) {
                //            if (result.status === 200) {
                //                alert('上传成功');
                //            } else {
                //                alert(result.message);
                //            }
                //        }
                //    }
                //});
            });
        });
    </script>

</asp:Content>


