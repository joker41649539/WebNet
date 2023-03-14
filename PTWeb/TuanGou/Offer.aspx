<%@ Page Title="微信支付" Language="C#" MasterPageFile="~/TuanGou/MasterPage.master" AutoEventWireup="true" CodeFile="Offer.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://res.wx.qq.com/open/js/jweixin-1.4.0.js" type="text/javascript"></script>
    <script type="text/javascript">

        wx.ready(function () {      //需在用户可能点击分享按钮前就先调用
            wx.updateTimelineShareData({
                title: '特惠抢购信息', // 分享标题
                link: 'http://ptweb.x76.com.cn/Tuangou/ReturnURL.html', // 分享链接，该链接域名或路径必须与当前页面对应的公众号 JS 安全域名一致
                imgUrl: '/images/XMFightLogo.jpg', // 分享图标
                success: function () {
                    // 设置成功
                }
            })
        });
        // 当微信内置浏览器完成内部初始化后会触发WeixinJSBridgeReady事件。
        document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
            //公众号支付
            jQuery('a#getBrandWCPayRequest').click(function (e) {
                WeixinJSBridge.invoke('getBrandWCPayRequest', <%=wx_packageValue %>,
                    function (res) {
                        // alert(res.err_msg);
                        if (res.err_msg == "get_brand_wcpay_request:ok") {
                            window.location.href ="PayNotifyUrl.aspx?OfferID=<%=OfferID%>&XSDID=<%=XSDValue %>";
                        }
                    });
            });
        }, false)
    </script>
    <div class="panel panel-default">
        <asp:Image ID="Image1" Width="100%" CssClass="img-rounded" runat="server" />
    </div>
    <h5>距离活动结束还有：<br />
    </h5>
    <h1 id="show" class="red center" clientidmode="Static" runat="server">
        <span></span>天<span></span>小时<span></span>分<span></span>秒</h1>
    <a id="getBrandWCPayRequest" href="javascript:void(0);" class="btn btn-success btn-lg btn-block">￥&nbsp;<asp:Label ID="Label1" runat="server" Text="299"></asp:Label>&nbsp;&nbsp;立即抢购</a>
    <div class="row center">
        <audio autoplay="autoplay" loop="loop" controls="controls">
            <source src="http://music.163.com/song/media/outer/url?id=1934251776.mp3"
                type="audio/mpeg">
        </audio>
    </div>
    <script>
        var show = document.getElementById("show").getElementsByTagName("span");
        setInterval(function () {
            var timeing = new Date();
            var time = new Date("<%=getNewDate%>");
            var num = time.getTime() - timeing.getTime();
            if (num <= 0) {
                show[0].innerHTML = 0;
                show[1].innerHTML = 0;
                show[2].innerHTML = 0;
                show[3].innerHTML = 0;
                document.getElementById("getBrandWCPayRequest").textContent = "活动已结束 下次请早";
                document.getElementById("getBrandWCPayRequest").href = "#";
            }
            else {
                var day = parseInt(num / (24 * 60 * 60 * 1000));
                num = num % (24 * 60 * 60 * 1000);
                var hour = parseInt(num / (60 * 60 * 1000));
                num = num % (60 * 60 * 1000);
                var minute = parseInt(num / (60 * 1000));
                num = num % (60 * 1000);
                var seconde = parseInt(num / 1000);

                show[0].innerHTML = day;
                show[1].innerHTML = hour;
                show[2].innerHTML = minute;
                show[3].innerHTML = seconde;
            }
        }, 100)
    </script>

</asp:Content>

