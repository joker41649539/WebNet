<%@ Page Title="" Language="C#" MasterPageFile="~/AllSchool/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AllSchool_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jSignature/2.1.3/jSignature.min.js"></script>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>

    <script type="text/javascript">
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

