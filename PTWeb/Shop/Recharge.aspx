<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="Recharge.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function check() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var phone = jQuery("#TextBox_PhoneNo").val();
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

            if (!rValue) {
                dialog = jqueryAlert({ 'content': message.substring(0, message.length - 4) });
            }
            return rValue;
        }
    </script>
    <div class="row">
        <asp:HiddenField ID="HiddenField_PhoneNo" runat="server" />
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>手机号码</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_PhoneNo" ClientIDMode="Static" runat="server" placeholder="请输入手机号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <hr />
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" OnClientClick="return check();" CssClass="btn btn-block btn-success" runat="server"><i class="icon-search"></i>&nbsp;信息查询</asp:LinkButton>
        </div>
        <div class="col-xs-12">
            <div class="hr hr8 hr-double"></div>
            <div class="clearfix">
                <div class="grid3">
                    <span class="grey bigger">
                        <i class=" icon-briefcase icon-2x orange"></i>
                        &nbsp; 当前金豆
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label1" runat="server" Text="0.00"></asp:Label></h4>
                </div>

                <div class="grid3">
                    <span class="grey">
                        <i class="icon-briefcase icon-2x green"></i>
                        &nbsp; 累计充值
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label2" runat="server" Text="0.00"></asp:Label>
                    </h4>
                </div>
                <div class="grid3">
                    <span class="grey">
                        <i class="icon-briefcase icon-2x red"></i>
                        &nbsp; 累计消耗
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label3" runat="server" Text="0.00"></asp:Label>
                    </h4>
                </div>
            </div>
            <div class="hr hr8 hr-double"></div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>充值数量</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_GoldCount" ClientIDMode="Static" runat="server" placeholder="请输入您要充值的数量" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <hr />
            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" CssClass="btn btn-block btn-danger" runat="server"><i class="icon-briefcase"></i>&nbsp;确认充值</asp:LinkButton>
        </div>
        <div class="col-xs-12">
            <asp:GridView class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField="Bance" HeaderText="数量"></asp:BoundField>
                    <asp:BoundField DataField="Event" HeaderText="事件"></asp:BoundField>
                    <asp:BoundField DataField="Operator" HeaderText="操作"></asp:BoundField>
                    <asp:BoundField DataField="CTime" DataFormatString="{0: yyyy-MM-dd HH:mm}" HeaderText="时间"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

