<%@ Page Title="微信支付" Language="C#" MasterPageFile="~/TuanGou/MasterPage.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js" type="text/javascript"></script>--%>
    <script src="/js/lazyloadv3.js" type="text/javascript"></script>
    <input type="hidden" name="name" value="" id="hidBill" runat="server" />
    <script type="text/javascript">
        // 当微信内置浏览器完成内部初始化后会触发WeixinJSBridgeReady事件。
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            //公众号支付
            jQuery('a#getBrandWCPayRequest').click(function (e) {
                WeixinJSBridge.invoke('getBrandWCPayRequest', <%=wx_packageValue %>,
                    function (res) {
                        alert(res.err_msg);
                        if (res.err_msg == "get_brand_wcpay_request:ok") {
                            //alert(res.err_msg);
                            window.location.href ="PayNotifyUrl.aspx?XSDID=<%=XSDValue %>";
                        }
                        // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                        //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
                    });
            });
        }, false)
    </script>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">
                <asp:Label ForeColor="Red" Font-Bold="true" ID="Label_DDH" runat="server" Text="订单号"></asp:Label>
                的送货信息
            </h3>
        </div>
        <div class="panel-body">
            <h4>
                <asp:Label ID="Label_LXR" runat="server" Text="联系人"></asp:Label><br />
                <br />
                <asp:Label ID="Label_LXDH" runat="server" Text="联系电话"></asp:Label><br />
                <br />
                <asp:Label ID="Label_SHDZ" runat="server" Text="送货地址"></asp:Label><br />
                <br />
                <asp:Label ID="Label_Remark" runat="server" Text="备注信息"></asp:Label></h4>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">付款金额
            </h3>
        </div>
        <div class="panel-body">
            <h2>
                <asp:Label ID="Label_ZFJE" runat="server" Text="0.01"></asp:Label>￥</h2>
        </div>
    </div>
    <a id="getBrandWCPayRequest" href="javascript:void(0);" class="btn btn-success btn-lg btn-block">信息确认 立即付款</a>
    <div class="row" style="height: 50px;">
    </div>
</asp:Content>

