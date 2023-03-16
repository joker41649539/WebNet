<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="New.aspx.cs" Inherits="XMFight_agreement_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">姓名</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ChildName" ClientIDMode="Static" runat="server" placeholder="请输入孩子姓名" class="col-xs-6 col-sm-6"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">出生日期</label>
                <div class="col-sm-9 input-group">
                    <asp:TextBox ID="TextBox_Brithday" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker"></asp:TextBox>
                    <span class="input-group-addon">
                        <i class="icon-calendar bigger-110"></i>
                    </span>
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
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">开始时间</label>
                <div class="col-sm-9 input-group">
                    <asp:TextBox ID="TextBoxSTime" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker"></asp:TextBox>
                    <span class="input-group-addon">
                        <i class="icon-calendar bigger-110"></i>
                    </span>
                </div>
            </div>
        </div>
        <div class="col-xs-12 btn-group">
            <button class="btn btn-sm" onclick="UpdateDate(1);">一个月</button>
            <button class="btn btn-sm" onclick="UpdateDate(3);">三个月</button>
            <button class="btn btn-sm" onclick="UpdateDate(12);">一&nbsp;&nbsp;年</button>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">截止时间</label>
                <div class="col-sm-9 input-group">
                    <asp:TextBox ID="TextBoxETime" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker"></asp:TextBox>
                    <span class="input-group-addon">
                        <i class="icon-calendar bigger-110"></i>
                    </span>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">课时</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ClassCount" ClientIDMode="Static" runat="server" placeholder="请输入课时数" class="col-xs-6 col-sm-6"></asp:TextBox>&nbsp;<h6 class="red">(每课时1.5h)</h6>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">赠送课时</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_FreeCount" ClientIDMode="Static" runat="server" placeholder="请输入赠送课时数" class="col-xs-6 col-sm-6"></asp:TextBox>&nbsp;<h6 class="red">(每课时1.5h)</h6>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注信息</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark" ClientIDMode="Static" runat="server" placeholder="请输入备注信息" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">应收费用</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ZJE" ClientIDMode="Static" runat="server" placeholder="输入应收金额(整数)" class="col-xs-6 col-sm-6"></asp:TextBox>
                </div>
            </div>
        </div>
        <hr />
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
        <hr />
        <div class="container-fluid">
            <h3>
                <br />
                监护人签名</h3>
            <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" runat="server" />
            <asp:Image ID="Image_Sign" ClientIDMode="Static" runat="server" />
            <div class="row" id="SignDiv">
                <div class="col-sm" style="padding: 10px;">
                    <div id="signature" style="border-style: dashed; border-width: 1px;"></div>
                </div>
            </div>
            <div class="btn-group row" runat="server" id="SignBtnDiv">
                <button type="button" class="btn btn-success" data-toggle="modal" id="saveBtn">确认签名</button>
                <button id="clearBtn" type="button" class="btn btn-danger">清除重签</button>
            </div>
        </div>
        <hr />
        <div class="row">
            <p>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Save" class="btn btn-info btn-block" runat="server"><i class="icon-save bigger-110"></i> 保  存</asp:LinkButton>
            </p>
        </div>
        <!-- /span -->
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jSignature/2.1.3/jSignature.min.js"></script>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>

    <script type="text/javascript">
        // 日记计算赋值
        function UpdateDate(MonthNum) {
            var date = new Date(document.getElementById("TextBoxSTime").value);
            date = new Date(date.setMonth(date.getMonth() + MonthNum));
            document.getElementById("TextBoxETime").value = formatDateTime(date);
        };
        function formatDateTime(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            m = m < 10 ? ('0' + m) : m;
            var d = date.getDate();
            d = d < 10 ? ('0' + d) : d;
            var h = date.getHours();
            var minute = date.getMinutes();
            minute = minute < 10 ? ('0' + minute) : minute;
            // return y + '-' + m + '-' + d+' '+h+':'+minute;
            return y + '-' + m + '-' + d
        };

        jQuery(function ($) {
            $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });
        });

        $(document).ready(function () {
            var arguments = {
                width: '100%',
                height: '300px',
                signatureLine: false,
                lineWidth: '2'
            };
            $('#signature').jSignature(arguments);
            // 清除 重签
            $('#clearBtn').click(function () {
                $('#signature').jSignature('reset');
                document.getElementById("Image_Sign").style.display = "none";
                document.getElementById("SignDiv").style.display = "block";//显示
            });
            // 确认按钮
            $('#saveBtn').click(function () {
                var dataPair = $('#signature').jSignature('getData', 'image');
                var signatureImage = new Image();
                signatureImage.src = 'data:' + dataPair[0] + ',' + dataPair[1];
                signatureImage.image = dataPair[1];
                document.getElementById("Image_Sign").style.display = "block";
                document.getElementById("Image_Sign").src = signatureImage.src;
                document.getElementById("HiddenField1").value = signatureImage.src;
                document.getElementById("SignDiv").style.display = "none";//隐藏
            });
        });
    </script>
</asp:Content>

