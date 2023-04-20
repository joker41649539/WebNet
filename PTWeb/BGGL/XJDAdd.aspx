<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XJDAdd.aspx.cs" Inherits="BGGL_XJDAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="robots" content="noarchive" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimal-ui" />

    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/assets/alert/alert.css" />
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />

    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="/assets/css/ace.min.css" />

    <script src='/assets/alert/alert.js'></script>
    <script src="/assets/js/ace-extra.min.js"></script>
    <script src='/assets/alert/shCore.js'></script>
    <script src='/assets/alert/makeSy.js'></script>

    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/x-icon" href="/images/ptlogo.png" media="screen" />

    <title>普田公司工程维修单</title>
</head>
<body>
    <script type="text/javascript">
        function onCheck() {
            var rValue = true;
            var i = 0;
            var ErrMsg = "";
            if (document.getElementById('TextBox_KHDW').value.length <= 0) {
                i++;
                ErrMsg += i + "、请输入客户单位名称或电话。<br/>";
            }

            if (document.getElementsByName('Checkbox0')[0].checked == false && document.getElementById('TextBox2').value.length <= 0) {
                i++;
                ErrMsg += i + "、图像不清晰，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox1')[0].checked == false && document.getElementById('TextBox3').value.length <= 0) {
                i++;
                ErrMsg += i + "、取景不合理，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox2')[0].checked == false && document.getElementById('TextBox4').value.length <= 0) {
                i++;
                ErrMsg += i + "、射灯不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox3')[0].checked == false && document.getElementById('TextBox5').value.length <= 0) {
                i++;
                ErrMsg += i + "、声光报警不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox4')[0].checked == false && document.getElementById('TextBox6').value.length <= 0) {
                i++;
                ErrMsg += i + "、柜员对讲不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox5')[0].checked == false && document.getElementById('TextBox7').value.length <= 0) {
                i++;
                ErrMsg += i + "、门磁状态及联动不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox6')[0].checked == false && document.getElementById('TextBox8').value.length <= 0) {
                i++;
                ErrMsg += i + "、门禁系统状态不正常，请填写情况说明。<br/>";
            }
            ////
            if (document.getElementsByName('Checkbox7')[0].checked == false && document.getElementById('TextBox9').value.length <= 0) {
                i++;
                ErrMsg += i + "、主机运行状态不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox8')[0].checked == false && document.getElementById('TextBox10').value.length <= 0) {
                i++;
                ErrMsg += i + "、机柜内线路标识不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox9')[0].checked == false && document.getElementById('TextBox11').value.length <= 0) {
                i++;
                ErrMsg += i + "、机柜内设备固定不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox10')[0].checked == false && document.getElementById('TextBox12').value.length <= 0) {
                i++;
                ErrMsg += i + "、机柜内设备除尘不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox11')[0].checked == false && document.getElementById('TextBox13').value.length <= 0) {
                i++;
                ErrMsg += i + "、报警及110联动不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox12')[0].checked == false && document.getElementById('TextBox14').value.length <= 0) {
                i++;
                ErrMsg += i + "、录像回放声音不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox13')[0].checked == false && document.getElementById('TextBox15').value.length <= 0) {
                i++;
                ErrMsg += i + "、硬盘工作状态检测及数量不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox14')[0].checked == false && document.getElementById('TextBox16').value.length <= 0) {
                i++;
                ErrMsg += i + "、录像保存时间不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox15')[0].checked == false && document.getElementById('TextBox17').value.length <= 0) {
                i++;
                ErrMsg += i + "、主机录像设置不正常，请填写情况说明。<br/>";
            }
            if (document.getElementsByName('Checkbox16')[0].checked == false && document.getElementById('TextBox18').value.length <= 0) {
                i++;
                ErrMsg += i + "、英安特报警(一对一测试核对信息)不正常，请填写情况说明。<br/>";
            }


            if (document.getElementById('TextBox_Remark').value.length <= 0) {
                i++;
                ErrMsg += i + "、巡检结论及故障处理结果必须填写。<br/>";
            }

            if (ErrMsg.length > 0) {
                dialog = jqueryAlert({ 'content': ErrMsg });
                rValue = false;
            }

            return rValue;
        }

    </script>
    <form id="form1" runat="server">
        <div class="page-content">
            <div class="col-sm-12 align-content-center">
                <hr />
                <h5><a href="/default.aspx">返回首页</a></h5>
                <h2>
                    <asp:Label ID="Label2" runat="server" ClientIDMode="Static" Text="监控、报警系统巡检服务卡"></asp:Label>
                </h2>
                [<asp:Label ID="Label_Flag" runat="server" Text="新凭单"></asp:Label>]
            </div>
            <hr />
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">巡检编号</label>
                    <div class="col-sm-9">
                        <h5>
                            <asp:Label ID="Label_dh" runat="server" ClientIDMode="Static" Text="SFXJ202004160001"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">巡检公司</label>
                    <div class="col-sm-9">
                        <h5>
                            <asp:Label ID="Label_DW" runat="server" ClientIDMode="Static" Text="合肥普田科技有限公司"></asp:Label>
                        </h5>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">客户单位(电话)</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_KHDW" ClientIDMode="Static" runat="server" placeholder="请输入客户单位名称或电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">维保人员(电话)</label>
                    <div class="col-sm-9">
                        <asp:Label ID="Label_WBName" runat="server" Text="维保人员"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">服务时间</label>
                    <div class="col-sm-9">
                        <asp:Label ID="Label_ServerTime" runat="server" Text="2023-04-12"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h4>巡检内容</h4>
                    <hr />
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h5>前端设备</h5>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">图像是否清晰</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox0" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">取景是否合理</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox1" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">射灯状态</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox2" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">声光报警是否正常</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox3" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">柜员对讲是否正常</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox4" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox6" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">门磁状态及联动</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox5" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox7" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">门禁系统状态</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox6" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox8" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h5>后端设备</h5>
                </div>
            </div>
            <hr />
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">主机运行状态检测</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox7" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox9" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机柜内线路标识情况</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox8" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox10" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机柜内设备固定</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox9" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox11" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机柜内设备除尘</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox10" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox12" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报警及110联动检测</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox11" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox13" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">录像回放声音</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox12" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox14" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">硬盘工作状态检测及数量</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox13" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox15" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">录像保存时间</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox14" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox16" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">主机录像设置</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox15" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox17" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">英安特报警(一对一测试核对信息)</label>
                    <div class="col-sm-9">
                        <label>
                            <input name="Check_SW" id="Checkbox16" runat="server" onchange="sum();" class="ace ace-switch ace-switch-6" type="checkbox" />
                            <span class="lbl"></span>
                        </label>
                        <asp:TextBox ID="TextBox18" ClientIDMode="Static" runat="server" placeholder="其它情况请填写"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">客户评价</label>
                    <div class="col-sm-9">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3" CssClass="ace">
                            <asp:ListItem Selected="True" Value="0">&nbsp;满意&nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">&nbsp;一般&nbsp;</asp:ListItem>
                            <asp:ListItem Value="1">&nbsp;不满意&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">巡检结论及故障处理结果：</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Remark" Width="100%" Height="80px" ClientIDMode="Static" runat="server" TextMode="MultiLine" placeholder="请填写巡检结论及故障处理结果"></asp:TextBox>
                    </div>
                </div>
            </div>
            <hr />
            <div class="container-fluid">
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">银行网点签名</label>
                        <div class="col-sm-9">
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
                    </div>
                </div>
            </div>
            <hr />
            <div class="btn-group">
                <asp:Button ID="Button1" runat="server" Text="保 存" class="btn btn-success" data-toggle="button" />
                <asp:Button ID="Button2" runat="server" Text="提 交" OnClientClick="return onCheck()" class="btn btn-info" data-toggle="button" />
                <%-- <asp:Button ID="Button3" runat="server" Text="查看PDF" class="btn btn-warning" />
                <asp:Button ID="Button4" runat="server" Text="删除表单" class="btn btn-danger" />
                <asp:Button ID="Button5" runat="server" Text="查看图片" class="btn btn-warning" />
                <asp:Button ID="Button6" runat="server" Text="查  看" class="btn btn-info" />--%>
            </div>
        </div>
        <div>
            <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
                <i class="icon-double-angle-up icon-only bigger-110"></i>
            </a>
        </div>
    </form>
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
