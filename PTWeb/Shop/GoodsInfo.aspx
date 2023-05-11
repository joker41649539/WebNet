<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsInfo.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="center">
        <img src="/img/01.jpg" class="img-rounded" width="100%" />
    </div>
    <div class="alert alert-success">
        <h1><b>限时拍卖</b></h1>
        <h5 id="show" clientidmode="Static" runat="server">距离结束还剩：  <span></span>小时<span></span>分<span></span>秒</h5>
    </div>
    <div class="well">
        <h1>(会员专场)网页滚动图片元素动画特效</h1>
        <p class="lead">
            CSS3网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效 - 站长素材
        </p>
        <div class="clearfix">
            <h1 class="red"><b>￥<span>168</span></b>
            </h1>
        </div>
    </div>
    <asp:LinkButton ID="LinkButton1" class="btn btn-danger btn-block" OnClick="LinkButton1_Click" runat="server"><i class="icon-shopping-cart"></i>&nbsp;<b>立即抢购</b></asp:LinkButton>

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
    <div class="hr hr8 hr-double"></div>
    <script>
        ShowTime("show", "2023-06-10 23:00");
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
                }
            }, 100)
        }
    </script>
</asp:Content>

