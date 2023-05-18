<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="AddressNew.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function check() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var Contacts = jQuery("#TextBox1").val();
            var phone = jQuery("#TextBox2").val();
            var Address = jQuery("#TextBox3").val();
            var i = 0;
            var message = "";
            var myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;
            if (phone == '') {
                i++;
                rValue = false;
                message += i + "、手机号码不能为空！<br>";
            } else if (phone.length != 11) {
                i++;
                rValue = false;
                message += i + "、请输入有效的手机号码！<br";
            } else if (!myreg.test(phone)) {
                i++;
                rValue = false;
                message += i + "、请输入有效的手机号码！<br";
            }

            if (Contacts.length <= 0 || Address.length <= 0) {
                i++;
                rValue = false;
                message += i + "、联系人和详细地址必须填写！<br";
            }
            if (!rValue) {
                dialog = jqueryAlert({ 'content': message.substring(0, message.length - 4) });
            }
            return rValue;
        }
    </script>
    <div class="row">
        <asp:HiddenField ID="HiddenField_AddressID" runat="server" />
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>收货人</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入收货人" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>联系电话</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入联系电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>详细地址</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入详细地址" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:LinkButton ID="LinkButton1" OnClientClick="return check();" OnClick="LinkButton1_Click" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;确认添加新地址</asp:LinkButton>
            <div class="hr hr8 hr-double"></div>
        </div>
    </div>
</asp:Content>

