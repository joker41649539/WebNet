using System;

using System.Collections;

using System.Data;

using System.Data.OleDb;

using System.Text;

using System.IO;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.HtmlControls;

/// <summary>
/// CreatGoodsHtml 的摘要说明
/// </summary>
public class CreatGoodsHtml
{
    public CreatGoodsHtml()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region//定义模版页

    public static string CreatIndexHtml()
    {
        string str = string.Empty;
        str += "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html;\" /><meta name=\"keywords\" /><meta name=\"description\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1, user-scalable=no, minimal-ui\" /><meta name=\"format-detection\" content=\"telephone=no\" /><meta name=\"apple-mobile-web-app-capable\" content=\"yes\" /><meta name=\"apple-mobile-web-app-status-bar-style\" content=\"black\" /><link rel=\"stylesheet\" href=\"/assets/css/bootstrap.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/font-awesome.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/ace.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/ace-rtl.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/ace-skins.min.css\" /><link rel=\"stylesheet\" href=\"/css/style.css\" /><link rel=\"stylesheet\" href=\"/assets/alert/alert.css\" />\r\n";
        str += "<script src='/assets/alert/alert.js'></script>";
        str += "<script src='/assets/js/ace-extra.min.js'></script>";
        str += "<script src='/assets/alert/shCore.js'></script>";
        str += "<script src='/assets/alert/makeSy.js'></script>";
        str += "<script src='/assets/js/jquery-2.0.3.min.js'></script>";
        str += "<script src='/assets/js/ace-elements.min.js'></script>";
        str += "<script src='/assets/js/bootstrap.min.js'></script>";
        str += "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"/images/XMFightLogo.ico\" media=\"screen\" />";
        str += "<title>秒杀时刻</title></head>";
        str += "<body>";
        str += "<style type=\"text/css\">.box {width: 49.5%;}</style>";
        str += "<form method=\"post\" id=\"form1\">";
        str += "<img src=\"/images/SpaBaner01.png\" class=\"img-rounded\" width=\"100%\" />";
        str += "<div class=\"row page-content\">";
        str += "<div id=\"masonry\" class=\"container-fluid list\">";
        str += "@GoodsList";/// Goods列表
        str += "</div>";
        str += "<script src=\"/js/masonry-docs.min.js\"></script>";
        str += "<script>";
        str += "  $(\"#masonry\").resize(function () {";
        str += "  var $grid = $('#masonry');";
        str += "  $grid.masonry();";
        str += "});";
        str += "$(function () {";
        str += "  var $container = $('#masonry');";
        str += "  $container.imagesLoaded(function () {\r\n";
        str += "  $container.masonry({";
        str += "    itemSelector: '.box',";
        str += "    gutter: 0,";
        str += "     isAnimated: true,";
        str += "   percentPosition: true";
        str += "});});});";

        str += "@ShowTime";//"ShowTime(\"show\", \"2023-05-10 23:00\");";//时间循环

        str += " function ShowTime(DivID, Time) {";
        str += "  var show = document.getElementById(DivID).getElementsByTagName(\"span\");";
        str += "   setInterval(function () {";
        str += "   var timeing = new Date();";
        str += "   var time = new Date(Time);";
        str += "   var num = time.getTime() - timeing.getTime();";
        str += "   if (num <= 0) {";
        str += "    show[0].innerHTML = 0;";
        str += "    show[1].innerHTML = 0;";
        str += "    show[2].innerHTML = 0;";
        str += "   }else {";
        str += "   var hour = parseInt(num / (60 * 60 * 1000));";
        str += "    num = num % (60 * 60 * 1000);";
        str += "    var minute = parseInt(num / (60 * 1000));";
        str += "    num = num % (60 * 1000);";
        str += "   var seconde = parseInt(num / 1000);";
        str += "   show[0].innerHTML = hour;show[1].innerHTML = minute;show[2].innerHTML = seconde;}}, 100)}";
        str += "</script>";
        str += "<div class=\"col-xs-12\"><div class=\"hr hr8 hr-double\"></div><img src=\"/images/Server.png\" class=\"img-rounded\" width=\"100%\" /> </div>";
        str += " </div><div class=\"row\" style=\"height: 60px;\">&nbsp;</div>";
        str += "<div id=\"FootBut\" style=\"height: auto;\">";
        str += " <ul class=\"footer-nav2 text-center\">";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/Html/index.html\"><i class=\"icon-home\"></i>首页</a></li>";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/Order.aspx\"><i class=\"icon-calendar\"></i>订单</a></li>";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/QA.aspx\"><i class=\"icon-comments-alt\"></i>问答</a></li>";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/My.aspx\"><i class=\"icon-user\"></i>我的</a></li>";
        str += "</ul>";
        str += "</div>";
        str += "</form></body></html>"; return str;
    }

    public static string SiteGoodsHtml()
    {

        string str = "";//模版页html代码

        str += "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html;\" /><meta name=\"keywords\" /><meta name=\"description\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1, user-scalable=no, minimal-ui\" /><meta name=\"format-detection\" content=\"telephone=no\" /><meta name=\"apple-mobile-web-app-capable\" content=\"yes\" /><meta name=\"apple-mobile-web-app-status-bar-style\" content=\"black\" /><link rel=\"stylesheet\" href=\"/assets/css/bootstrap.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/font-awesome.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/ace.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/ace-rtl.min.css\" /><link rel=\"stylesheet\" href=\"/assets/css/ace-skins.min.css\" /><link rel=\"stylesheet\" href=\"/css/style.css\" /><link rel=\"stylesheet\" href=\"/assets/alert/alert.css\" />\r\n";
        str += "<script src='/assets/alert/alert.js'></script>";
        str += "<script src='/assets/js/ace-extra.min.js'></script>";
        str += "<script src='/assets/alert/shCore.js'></script>";
        str += "<script src='/assets/alert/makeSy.js'></script>";
        str += "<script src='/assets/js/jquery-2.0.3.min.js'></script>";
        str += "<script src='/assets/js/ace-elements.min.js'></script>";
        str += "<script src='/assets/js/bootstrap.min.js'></script>";
        str += "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"/images/XMFightLogo.ico\" media=\"screen\" />";
        str += "<title>@Title</title></head>";//标题
        str += "<body>";
        str += "<form method=\"post\" id=\"form1\">";

        str += "<script>";
        str += " var url = window.location.href;";
        str += " url = url.substring(url.lastIndexOf('tml/') + 4);";
        str += " var strcookie = document.cookie;";
        str += " var rValue = false;";
        str += " var UserNo = strcookie.substring(strcookie.lastIndexOf(\"PhoneNo=\") + 8, strcookie.lastIndexOf(\"PhoneNo=\") + 19);";
        str += " var GoldCount = strcookie.substring(strcookie.lastIndexOf(\"GoldCount=\") + 10, strcookie.length);if (Number(GoldCount) >= 0) { if (GoldCount < Math.ceil(@Price * @Gas)) { dialog = jqueryAlert({ 'content': '<i class=\"icon-warning-sign icon-3x red\"></i><br>您的金豆不够支付该商品，请先充值。<br>预计需要：' + Math.ceil(@Price * @Gas) }) } } ;";
        str += " var myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\\d{8})$/;";
        str += " if (!myreg.test(UserNo)) {";
        str += "    dialog = jqueryAlert({ 'title': '提 示', 'content': \"您还未登录<br>请先登录。\", 'modal': true, 'buttons': { '确定': function () { location.href = \"/Shop/Login.aspx\"; } } })";
        str += " }";
        str += " const socket = new WebSocket('@Server');";///服务器 ws://127.0.0.1:8090/ws
        str += " var BConnect = false;";
        str += "  socket.addEventListener('open', (event) => {BConnect = true;});";
        str += "  socket.onerror = function (e) {BConnect = false;};";
        str += "  socket.addEventListener('message', (event) => {";
        str += "    if (event.data == \"ok\") {";
        str += "      dialog = jqueryAlert({ 'title': '提 示', 'content': \"恭喜，抢购成功。<br>请在一小时内付款。\", 'modal': true, 'buttons': { '确定': function () { location.href = \"/Shop/BankCardByUser.aspx?id=\" + url; } } })";
        str += "    }";
        str += "    else {";
        str += "      dialog = jqueryAlert({ 'content': event.data });";
        str += "    }});";
        str += " function sendMessage() {";
        str += "   if (BConnect) {const message = UserNo + \",\" + url;socket.send(message);}";
        str += "   else {dialog = jqueryAlert({ 'content': \"连接服务器出错。<br/>请稍后刷新重试。\" });}";
        str += "}";
        str += "</script>";

        str += "<img src=\"/images/SpaBaner01.png\" class=\"img-rounded\" width=\"100%\" />";
        str += "<div class=\"row page-content\">";
        str += "<div class=\"center\"><img src=\"/Shop/img/@BigImg\" class=\"img-rounded\" width=\"100%\" /></div>";//商品大图
        str += "<div class=\"alert alert-success\"><h1><b>限时抢购</b></h1><h5 id=\"show\">距离开始还有：  <span></span>小时<span></span>分<span></span>秒</h5>";
        str += "<a class=\"btn btn-danger btn-block\" onclick=\"sendMessage();\" ID=\"LinkButton1\" href=\"#\"><i class=\"icon-shopping-cart\"></i>&nbsp;<b>立即抢购</b></a></div>";
        str += "<div class=\"well\">";
        str += " <div class=\"clearfix\">";
        str += "  <h1 class=\"red\"><b>￥<span>@Price</span></b></h1>";//单价
        str += " </div>";
        str += "  <h1>@Title</h1>";//标题
        str += " <p class=\"lead\">@Introduction</p>";//文字介绍
        str += "</div>";
        str += "<div class=\"hr hr8 hr-double\"></div>";
        str += "<div> <p class=\"lead pull-right\">@Introduction</p>";//文字介绍
        str += "@Content";//图片信息
        str += "</div>";
        str += "<script>";
        str += "ShowTime(\"show\", \"@STime\");";//开始时间
        str += " function ShowTime(DivID, Time) {";
        str += "  var show = document.getElementById(DivID).getElementsByTagName(\"span\");";
        str += "   setInterval(function () {";
        str += "   var timeing = new Date();";
        str += "   var time = new Date(Time);";
        str += "   var num = time.getTime() - timeing.getTime();";
        str += "   if (num <= 0) {";
        str += "    show[0].innerHTML = 0;";
        str += "    show[1].innerHTML = 0;";
        str += "    show[2].innerHTML = 0;";
        str += "$(\"#LinkButton1\").removeAttr(\"disabled\");";
        str += "   }else {";
        str += "   var hour = parseInt(num / (60 * 60 * 1000));";
        str += "    num = num % (60 * 60 * 1000);";
        str += "    var minute = parseInt(num / (60 * 1000));";
        str += "    num = num % (60 * 1000);";
        str += "   var seconde = parseInt(num / 1000);";
        str += "   show[0].innerHTML = hour;show[1].innerHTML = minute;show[2].innerHTML = seconde; $(\"#LinkButton1\").attr(\"disabled\", \"true\");}}, 100)}";
        str += "</script>";
        str += "<div class=\"col-xs-12\"><div class=\"hr hr8 hr-double\"></div><img src=\"/images/Server.png\" class=\"img-rounded\" width=\"100%\" /> </div>";
        str += " </div><div class=\"row\" style=\"height: 60px;\">&nbsp;</div>";
        str += "<div id=\"FootBut\" style=\"height: auto;\">";
        str += " <ul class=\"footer-nav2 text-center\">";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/Html/index.html\"><i class=\"icon-home\"></i>首页</a></li>";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/Order.aspx\"><i class=\"icon-calendar\"></i>订单</a></li>";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/QA.aspx\"><i class=\"icon-comments-alt\"></i>问答</a></li>";
        str += " <li class=\"width-100\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/Shop/My.aspx\"><i class=\"icon-user\"></i>我的</a></li>";
        str += "</ul>";
        str += "</div>";
        str += "</form></body></html>";
        return str;

    }

    #endregion
    public static string WriteIndex(string GoodsList, string ShowTime)
    {
        string path = HttpContext.Current.Server.MapPath(".") + "/html/";//文件输出目录

        Encoding code = Encoding.GetEncoding("gb2312");

        StreamWriter sw = null;

        string str = CreatIndexHtml();//读取模版页面html代码

        string htmlfilename = "Index.html";//静态文件名

        // 替换内容

        str = str.Replace("@GoodsList", GoodsList);
        str = str.Replace("@ShowTime", ShowTime);

        // 写文件

        try
        {

            sw = new StreamWriter(path + htmlfilename, false, code);

            sw.Write(str);

            sw.Flush();
        }

        catch (Exception ex)
        {

            HttpContext.Current.Response.Write(ex.Message);

            HttpContext.Current.Response.End();

        }

        finally
        {

            sw.Close();

        }

        string rValue = htmlfilename;
        return rValue;

    }

    /// <summary>
    /// 根据模板代码生成静态页面
    /// </summary>
    /// <param name="strID"></param>
    /// <param name="strTitle"></param>
    /// <param name="strBigImg"></param>
    /// <param name="strPrice"></param>
    /// <param name="strIntroduction"></param>
    /// <param name="strContent"></param>
    /// <param name="strSTime"></param>
    /// <returns></returns>
    public static string WriteFile(int strID, string strTitle, string strBigImg, string strPrice, string strIntroduction, string strContent, string strSTime, string strServer, string strGas)
    {

        string path = HttpContext.Current.Server.MapPath(".") + "/html/";//文件输出目录

        Encoding code = Encoding.GetEncoding("gb2312");

        StreamWriter sw = null;

        string str = SiteGoodsHtml();//读取模版页面html代码

        string htmlfilename = DateTime.Now.ToString("yyyyMMddHHmmss") + strID + ".html";//静态文件名
                                                                                        //   string htmlfilename = "TT.html";//静态文件名

        // 替换内容

        str = str.Replace("@Title", strTitle);
        str = str.Replace("@BigImg", strBigImg);
        str = str.Replace("@Price", strPrice);
        str = str.Replace("@Introduction", strIntroduction);
        str = str.Replace("@Content", strContent);
        str = str.Replace("@STime", strSTime);
        str = str.Replace("@Server", strServer);
        str = str.Replace("@Gas", strGas);

        // 写文件

        try
        {

            sw = new StreamWriter(path + htmlfilename, false, code);

            sw.Write(str);

            sw.Flush();
        }

        catch (Exception ex)
        {

            HttpContext.Current.Response.Write(ex.Message);

            HttpContext.Current.Response.End();

        }

        finally
        {

            sw.Close();

        }

        string rValue = htmlfilename;
        return rValue;

    }

}