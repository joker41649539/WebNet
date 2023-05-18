<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="BankCard.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function checkWeChat() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var input = document.getElementById("id-input0").value;

            if (input.length <= 0) {
                rValue = false;
                dialog = jqueryAlert({ 'content': "请先选择微信收款码。" });
            }
            return rValue;
        }
        function checkPay() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var input = document.getElementById("id-input1").value;

            if (input.length <= 0) {
                rValue = false;
                dialog = jqueryAlert({ 'content': "请先选择支付宝收款码。" });
            }
            return rValue;
        }
        function checkBank() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var BankName = document.getElementById("TextBox1").value;
            var BankStart = document.getElementById("TextBox2").value;
            var BankID = document.getElementById("TextBox3").value;
            var MSG = "";
            var i = 0;
            if (BankName.length <= 0) {
                i++
                rValue = false;
                MSG += i.toString() + "、银行名称必须填写。<br>";
            }
            if (BankStart.length <= 0) {
                i++
                rValue = false;
                MSG += i.toString() + "、银行的开户行必须填写。<br>";
            }
            if (BankID.length <= 0) {
                i++
                rValue = false;
                MSG += i.toString() + "、银行账号必须填写。<br>";
            }
            if (MSG.length > 0) {
                dialog = jqueryAlert({ 'content': MSG.substring(0, MSG.length - 4) });
            }
            return rValue;
        }
    </script>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>微信收款码</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input0" accept="image/*" />
                </div>
                <asp:Image ID="Image_WeChat" class="img-rounded width-100" runat="server" />
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:LinkButton ID="LinkButton_WeChat" OnClientClick="return checkWeChat()" OnClick="LinkButton_WeChat_Click" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;保存(更换)微信收款码</asp:LinkButton>
            <br />
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>支付宝收款码</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input1" accept="image/*" />
                </div>
                <asp:Image ID="Image_Pay" class="img-rounded width-100" runat="server" />
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:LinkButton ID="LinkButton_Pay" OnClientClick="return checkPay()" OnClick="LinkButton_Pay_Click" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;保存(更换)支付宝收款码</asp:LinkButton>
            <br />
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>银行名称</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入银行名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <h3><b>开户行名称</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入您的开户行名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <h3><b>银行卡号</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入您的银行卡号" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:LinkButton ID="LinkButton_Bank" OnClientClick="return checkBank()" OnClick="LinkButton_Bank_Click" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;保存(更新)银行卡号</asp:LinkButton>
            <br />
        </div>
        <br />
    </div>
    <%-- 文件上传样式需要--%>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input0,#id-input1').ace_file_input({
                style: 'well',
                btn_choose: '点击上传图片更换',
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

</asp:Content>

