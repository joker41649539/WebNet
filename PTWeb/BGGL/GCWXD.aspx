<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GCWXD.aspx.cs" Inherits="GDGL_GCWXD" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css" />


    <script src="/assets/js/ace-extra.min.js"></script>


    <link rel="stylesheet" href="/assets/alert/alert.css" />
    <script src='/assets/alert/alert.js'></script>
    <script src='/assets/alert/shCore.js'></script>

    <script src='/assets/alert/makeSy.js'></script>
    <link rel="shortcut icon" type="image/x-icon" href="/images/PTLOGO.png" media="screen" />
    <title>普田公司工程维修单</title>
</head>
<body>
    <form id="form1" runat="server">
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

        <div class="page-content">
            <div class="col-sm-12 align-content-center">
                <hr />
                <h5><a href="/default.aspx">返回首页</a></h5>
                <h1>
                    <asp:Label ID="Label2" runat="server" ClientIDMode="Static" Text="工程维修单"></asp:Label>
                </h1>
                [<asp:Label ID="Label_Flag" runat="server" Text="新凭单"></asp:Label>]
                <asp:HiddenField ID="Hidden_WXRY" runat="server" />
            </div>
            <hr />
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维修单位</label>
                    <div class="col-sm-9">
                        <h5>
                            <asp:Label ID="Label_DW" runat="server" ClientIDMode="Static" Text="合肥普田科技有限公司"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维修单号</label>
                    <div class="col-sm-9">
                        <h5>
                            <asp:Label ID="Label_dh" runat="server" ClientIDMode="Static" Text="GCWXD202004160001"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维修人员</label>
                    <div class="col-sm-9">
                        <h5>
                            <asp:Label ID="Label_WXRY" runat="server" ClientIDMode="Static" Text="陆晓钧"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维修时间</label>
                    <div class="col-sm-9">
                        <h5>
                            <asp:Label ID="Label_wxsj" runat="server" ClientIDMode="Static" Text="2020-04-16 10:06"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">网点名称</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_YH" ClientIDMode="Static" runat="server" placeholder="请输入银行名称" class="col-xs-6 col-sm-6"></asp:TextBox>银行
                        <asp:TextBox ID="TextBox_FLC" ClientIDMode="Static" runat="server" placeholder="请输入支行名称" class="col-xs-6 col-sm-6"></asp:TextBox>分理处/支行
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">故障现象</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_GZ" ClientIDMode="Static" runat="server" placeholder="请输入故障现象" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维修内容</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_WX" ClientIDMode="Static" runat="server" placeholder="请输入维修内容" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维修费用</label>
                    <div class="col-sm-9">
                        <asp:RadioButtonList ID="RadioButtonList_WXFY" runat="server" RepeatColumns="2">
                            <asp:ListItem Value="0">免费</asp:ListItem>
                            <asp:ListItem Value="1">收费</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="TextBox_FY" ClientIDMode="Static" runat="server" placeholder="输入金额" class="col-xs-3 col-sm-3"></asp:TextBox>元维修费
                    </div>
                </div>
            </div>
            <hr />
            <div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <h1>客户意见</h1>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">故障是否已解决</label>
                        <div class="col-sm-9">
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatColumns="2">
                                <asp:ListItem Value="0">是</asp:ListItem>
                                <asp:ListItem Value="1">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">是否完成对其余设备的例行检查</label>
                        <div class="col-sm-9">
                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatColumns="2">
                                <asp:ListItem Value="0">是</asp:ListItem>
                                <asp:ListItem Value="1">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">对于维修人员的工作态度</label>
                        <div class="col-sm-9">
                            <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatColumns="3">
                                <asp:ListItem Value="0">很满意</asp:ListItem>
                                <asp:ListItem Value="1">满意</asp:ListItem>
                                <asp:ListItem Value="2">不满意</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">对于维修结果是否满意</label>
                        <div class="col-sm-9">
                            <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatColumns="3">
                                <asp:ListItem Value="0">很满意</asp:ListItem>
                                <asp:ListItem Value="1">满意</asp:ListItem>
                                <asp:ListItem Value="2">不满意</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_Remark" ClientIDMode="Static" runat="server" placeholder="请输入所需的备注信息" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">客户联系电话</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_LXDH" ClientIDMode="Static" runat="server" placeholder="请输入客户联系电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="container-fluid">
            <div class="row">网点负责人签名</div>
            <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" runat="server" />
            <asp:Image ID="Image_Sign" ClientIDMode="Static" runat="server" />
            <div class="row" runat="server" id="SignDiv">
                <div class="col-sm" style="padding: 10px;">
                    <div id="signature" style="border-style: dashed; border-width: 1px;"></div>
                </div>
            </div>
            <div class="row" runat="server" id="SignBtnDiv">
                <button type="button" class="btn btn-success" data-toggle="modal" id="saveBtn">确认签名</button>
                &nbsp;&nbsp;
                    <button id="clearBtn" type="button" class="btn btn-danger">清除重签</button>
            </div>
        </div>
        <hr />
        <asp:Button ID="Button1" runat="server" Text="保存表单" class="btn btn-success" OnClick="Button1_Click" />
        &nbsp;
        <asp:Button ID="Button2" runat="server" Text="提交表单" class="btn btn-info" OnClick="Button2_Click" />
        &nbsp;
        <asp:Button ID="Button3" runat="server" Text="查看PDF" class="btn btn-warning" OnClick="Button3_Click" />
        &nbsp;
        <asp:Button ID="Button4" runat="server" Text="删除表单" class="btn btn-danger" OnClick="Button4_Click" />
        &nbsp;
        <asp:Button ID="Button5" runat="server" Text="查看图片" class="btn btn-warning" OnClick="Button5_Click" />
        &nbsp;
        <asp:Button ID="Button6" runat="server" Text="查  看" class="btn btn-info" OnClick="Button6_Click"/>
    </form>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.0/js/bootstrap.min.js"></script>
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
                document.getElementById("SignDiv").style.visibility = "visible";//隐藏
            });
            // 保存按钮
            $('#saveBtn').click(function () {
                var dataPair = $('#signature').jSignature('getData', 'image');
                var signatureImage = new Image();
                signatureImage.src = 'data:' + dataPair[0] + ',' + dataPair[1];
                signatureImage.image = dataPair[1];
                document.getElementById("Image_Sign").src = signatureImage.src;
                document.getElementById("HiddenField1").value = signatureImage.src;
                document.getElementById("SignDiv").style.visibility = "hidden";//隐藏
            });
        });
    </script>
</body>
</html>
