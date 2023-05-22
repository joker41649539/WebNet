<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsInfo.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        // 创建 WebSocket 连接
        const socket = new WebSocket('ws://127.0.0.1:8090/ws');
        var BConnect = false;
        // 监听连接事件
        socket.addEventListener('open', (event) => {
            BConnect = true;
            //         console.log('Connected to server');
        });
        socket.onerror = function (e) {
            BConnect = false;
           // dialog = jqueryAlert({ 'content': "连接服务器出错。请稍后再试。" });
        }//连接出错
        var Msg = "";
        // 监听接收消息事件
        socket.addEventListener('message', (event) => {
            if (event.data == "ok") {
                alert("抢购成功。");
                window.location.replace("/Shop/BankCardByUser.aspx?id=202305221436521")
                // dialog = jqueryAlert({ 'title': '提示', 'content': "抢购成功。", 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close(); } } });
                // return;
            }
            else {
                alert("抢购失败，下次请早。");
                // dialog = jqueryAlert({ 'title': '提示', 'content': "抢购失败，下次请早。", 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close(); } } });
                // return;
            }
            //const messages = document.getElementById('messages');
            //const li = document.createElement('li');
            //li.textContent = event.data;
            //messages.appendChild(li);
        });

        // 发送消息
        function sendMessage() {
            // const input = document.getElementById('messageInput');
            //   const message = input.value;
            if (BConnect) {
                const message = "18019961118,2023052214474010.html";
                socket.send(message);
            }
            else {
                alert("连接服务器出错。\r\n请稍后再试。");
            }
        }
    </script>

    <%-- <script>
        function check() {
            $("#LinkButton1").attr('Text', '等待数据操作');
           // $("#LinkButton1").attr("disabled", "true");// 按钮禁用
            return false;
        }
    </script>--%>
    <div class="center">
        <img src="/img/01.jpg" class="img-rounded" width="100%" />
    </div>
    <div class="alert alert-success">
        <h1><b>限时抢购</b></h1>
        <h5 id="show" clientidmode="Static" runat="server">距离结束还剩：  <span></span>小时<span></span>分<span></span>秒</h5>
        <%--        <asp:Button ID="LinkButton1" ClientIDMode="Static" OnClientClick="return check()" class="btn btn-danger btn-block" OnClick="LinkButton1_Click" runat="server" Text="Button" />--%>
        <asp:LinkButton ID="LinkButton1" ClientIDMode="Static" OnClientClick="sendMessage();" class="btn btn-danger btn-block" runat="server"><i class="icon-shopping-cart"></i>&nbsp;<b>立即抢购</b></asp:LinkButton>
    </div>
    <div class="well">
        <div class="clearfix">
            <h1 class="red"><b>￥<span>168</span></b>
            </h1>
        </div>
        <h1>(会员专场)网页滚动图片元素动画特效</h1>
        <p class="lead">
            CSS3网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效 - 站长素材
        </p>
    </div>

    <div class="hr hr8 hr-double"></div>
    <div>
        <p class="lead pull-right">
            CSS3网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效 - 站长素材
        </p>
        <img src="/img/01.jpg" class="img-rounded" width="100%" />
        <img src="/img/02.jpg" class="img-rounded" width="100%" />
        <img src="/img/03.jpg" class="img-rounded" width="100%" />
        <img src="/img/04.jpg" class="img-rounded" width="100%" />
        <img src="/img/05.jpg" class="img-rounded" width="100%" />
        <img src="/img/06.jpg" class="img-rounded" width="100%" />
    </div>
    <script>
        ShowTime("show", "2023-05-22 09:01");
        function ShowTime(DivID, Time) {
            var show = document.getElementById(DivID).getElementsByTagName("span");
            setInterval(function () {
                var timeing = new Date();
                var time = new Date(Time);
                var num = time.getTime() - timeing.getTime();
                if (num <= 0) {
                    show[0].innerHTML = 0;
                    show[1].innerHTML = 0;
                    show[2].innerHTML = 0;
                    $("#LinkButton1").removeAttr("disabled");// 按钮启用
                }
                else {
                    var hour = parseInt(num / (60 * 60 * 1000));
                    num = num % (60 * 60 * 1000);
                    var minute = parseInt(num / (60 * 1000));
                    num = num % (60 * 1000);
                    var seconde = parseInt(num / 1000);

                    show[0].innerHTML = hour;
                    show[1].innerHTML = minute;
                    show[2].innerHTML = seconde;
                    $("#LinkButton1").attr("disabled", "true");// 按钮禁用
                }
            }, 100)
        }
    </script>
</asp:Content>

