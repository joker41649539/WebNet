<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PartnerAdd.aspx.cs" Inherits="Partner_PartnerAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合肥普田邀请您加入</title>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="robots" content="noarchive" />
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
    <link rel="shortcut icon" type="image/x-icon" href="/images/ptlogo.png" media="screen" />

</head>
<body>
    <div class="modal fade" id="MSG" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"
                        aria-hidden="true">
                        ×
                    </button>
                    <h4 class="modal-title" id="MSGTitle">提  示
                    </h4>
                </div>
                <div class="modal-body">
                    <h3 class="modal-title" id="ShowMSG">发生了错误！
                    </h3>
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
        <div class="panel panel-body">
            <div class="panel-heading">
                <h3><b>
                    <img src="/images/PTlogo.png" />合肥普田科技有限公司</b></h3>
            </div>
            <hr />
            <h5>协同人员信息申请</h5>
            <div class="row">
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>真实姓名</b></h3>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入您的真实姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <div class="col-sm-9">
                            <asp:RadioButtonList ID="RadioButtonList_Six" RepeatColumns="2" runat="server">
                                <asp:ListItem Selected="True" Value="1"><h3><b>&nbsp;&nbsp;男&nbsp;&nbsp;</b></h3></asp:ListItem>
                                <asp:ListItem Value="0"><h3><b>&nbsp;&nbsp;女&nbsp;&nbsp;</b></h3></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>手机号码</b></h3>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_Tel" runat="server" placeholder="请输入能联系到您的手机号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>身份证号码</b></h3>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_No" runat="server" placeholder="请输入您的身份证号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>身份证头像面</b></h3>
                        <div class="col-sm-9">
                            <input type="file" name="UpImg" id="id-input1" accept="image/*" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>身份证国徽面</b></h3>
                        <div class="col-sm-9">
                            <input type="file" name="UpImg" id="id-input2" accept="image/*" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>生活照</b></h3>
                        <div class="col-sm-9">
                            <input type="file" name="UpImg" id="id-input3" accept="image/*" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h3><b>说明信息</b></h3>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_Remark" runat="server" TextMode="MultiLine" placeholder="如有需要说明的信息，请填写" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>提交申请</b></asp:LinkButton>
        </div>
    </form>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='/assets/js/jquery-2.0.3.min.js'><" + "/script>");
    </script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        jQuery(function ($) {
            //$('#id-input1,#id-input2').ace_file_input({
            $('#id-input1,#id-input2,#id-input3').ace_file_input({
                style: 'well',
                btn_choose: '点击上传图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large',// large | small
                preview_error: function (filename, error_code) {

                }

            }).on('change', function () {
                //alert("修改");
            });
        });
    </script>
</body>
</html>
