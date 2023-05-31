using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Xml;
using Newtonsoft.Json;
using Encoder = System.Drawing.Imaging.Encoder;

/// <summary>
/// PageBaseShop 的摘要说明
/// </summary>
public class PageBaseShop : System.Web.UI.Page
{
    public static string DefaultConStr = "Data Source=223.244.20.182;Initial Catalog=Rapid;User Id=joker24;Password=joK12141649539!";

    public static OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    public PageBaseShop()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 依据权限ID和用户ID判断是否有此功能权限。有返回TURE，反之返回FALSE;
    /// </summary>
    /// <param name="WebID">页面ID</param>
    /// <param name="PhoneNo">用户ID</param>
    /// <returns></returns>
    public bool QXBool(int WebID, string PhoneNo)
    {
        bool rValue = false;
        string strSQL = "Select * from Shop_Module where PhoneNo='" + PhoneNo + "' and ModuleID=" + WebID.ToString() + "";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                rValue = true;
            }
        }
        return rValue;
    }

    /// <summary>
    /// 当前用户
    /// </summary>
    public string DefaultUser
    {
        get
        {
            string rValue = string.Empty;

            try
            {
                rValue = Request.Cookies["Shop"]["PhoneNo"];
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({ 'title': '提 示', 'content': '您还未登陆。<br/>请先登陆！', 'modal': true, 'buttons': { '确定': function () { location.href=\"/Shop/Login.aspx\"; } } })</script>");
            }

            return rValue;
        }
    }
    public bool IsInt(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*$");
    }

    /// <summary>
    /// 写入Cookie 判断是否填写过信息
    /// </summary>
    public void ResponseCokie(string PhonNo, bool BankMsg, bool AddressMsg, double GoldCount)
    {
        Response.Cookies["Shop"]["PhoneNo"] = PhonNo;
        Response.Cookies["Shop"]["BankMsg"] = BankMsg.ToString();
        Response.Cookies["Shop"]["AddressMsg"] = AddressMsg.ToString();
        Response.Cookies["Shop"]["GoldCount"] = GoldCount.ToString();
    }

    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">提示消息</param>
    public void MessageBox(string sMessage)
    {
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。

        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({'content': '" + sTemp + "'})</script>");

    }
    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">提示消息</param>
    public void MessageBox(string sKey, string sMessage)
    {
        if (sKey == "")
        {
            sKey = "提示信息";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。

        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () {dialog.destroy();dialog.close();} } })</script>");
    }

    /// <summary>
    /// 模态框消息提示，并跳转页面
    /// </summary>
    /// <param name="sKey">提示窗口标题</param>
    /// <param name="sMessage">消息内容</param>
    /// <param name="sURL">提示后跳转页面</param>
    public void MessageBox(string sKey, string sMessage, string sURL)
    {
        if (sKey == "")
        {
            sKey = "提示信息";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () { location.href=\"" + sURL + "\"; } } })</script>");
    }

    /// <summary>
    /// 模态框消息提示，并跳转页面
    /// </summary>
    /// <param name="UpdatePanel">无刷新PANEL名</param>
    /// <param name="sKey">提示窗口标题</param>
    /// <param name="sMessage">消息内容</param>
    /// <param name="sURL">提示后跳转页面</param>
    public void MessageBox(Control UpdatePanel, string sKey, string sMessage, string sURL)
    {
        if (sKey == "")
        {
            sKey = "提示信息";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。

        ScriptManager.RegisterClientScriptBlock(UpdatePanel, this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        ScriptManager.RegisterStartupScript(UpdatePanel, this.GetType(), "sKey", "$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '" + sURL + "', 0);})});", true);

    }

    /// <summary>
    /// 上传图片信息
    /// </summary>
    public string UploadTPs(HttpPostedFile fileName, int sn, string Prefix)
    {
        string SavePath = "Shop/Img";// 图片保存路径  ，无需/  ~/KQImage/
        Prefix = Prefix + sn;// 新文件名前缀
        string strTemp = string.Empty;// = "测试一下";/// 水印文字

        string name = fileName.FileName;//获取文件名称

        if (name.Length > 0)
        {
            int i = fileName.ContentLength;   //得到上传文件大小

            int index = name.LastIndexOf(".");

            string lastName = name.Substring(index, name.Length - index);//文件后缀

            string newname = Prefix + DateTime.Now.ToString("yyyyMMddHHmmssfff") + lastName;//新文件名
                                                                                            //  string newname = "12345" + lastName;
            string path = Server.MapPath("~/" + SavePath + "/" + newname);

            string URLpath = Server.MapPath("\\" + SavePath + "\\" + newname);

            if (System.IO.File.Exists(URLpath))
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    if (i < 1048576)
                    {
                        fileName.SaveAs(path);//保存到服务器上	 小于1M的图片不进行压缩处理
                    }
                    else
                    { /// 大于1M的图片文件压缩后上传
                        ystp(fileName, "~/" + SavePath + "/" + newname);
                    }

                    if (strTemp.Length > 0)
                    {
                        string imageName = "SY" + newname;
                        //添加水印
                        System.Drawing.Image imgSrc = AddText(@URLpath, "50,50", "300, 100", strTemp);

                        string newpath = Server.MapPath(@"/" + SavePath + "/" + imageName);
                        imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //释放水印图片
                        ///// 水印成功后，删除原图片
                        if (File.Exists(URLpath)) { File.Delete(URLpath); }
                        return imageName;
                    }
                    else
                    {
                        return newname;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox("", "服务器正忙，请稍后再试！" + ex.ToString());
                    return string.Empty;
                }

            }
        }
        return string.Empty;
    }

    /// <summary>
    /// 图片添加文字
    /// </summary>
    /// <param name="imgPath">图片路径</param>
    /// <param name="locationLeftTop">左顶坐标</param>
    /// <param name="locationRightBottom"></param>
    /// <param name="text"></param>
    /// <param name="fontName"></param>
    /// <returns></returns>
    public static Bitmap AddText(string imgPath, string locationLeftTop, string locationRightBottom, string text, string fontName = "宋体")
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile(imgPath);
        ///旋转图片
        OrientationImage(img);
        int width = img.Width;
        int height = img.Height;
        Bitmap bmp = new Bitmap(width, height);
        Graphics graph = Graphics.FromImage(bmp);

        // 计算文字区域
        // 左上角
        string[] location = locationLeftTop.Split(',');
        float x1 = float.Parse(location[0]);
        float y1 = float.Parse(location[1]);
        x1 = float.Parse(Math.Round(Convert.ToDouble(width / 50), 0).ToString());
        y1 = float.Parse(Math.Round(Convert.ToDouble(height / 50), 0).ToString());
        // 右下角
        location = locationRightBottom.Split(',');
        float x2 = float.Parse(location[0]);
        float y2 = float.Parse(location[1]);

        x2 = float.Parse(Math.Round(Convert.ToDouble(width / 2), 0).ToString());
        y2 = float.Parse(Math.Round(Convert.ToDouble(height / 10), 0).ToString());

        // 区域宽高
        float fontWidth = x2 - x1;
        float fontHeight = y2 - y1;

        float fontSize = fontHeight;  // 初次估计先用文字区域高度作为文字字体大小，后面再做调整，单位为px

        Font font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
        SizeF sf = graph.MeasureString(text, font);

        int times = 0;

        // 调整字体大小以适应文字区域
        if (sf.Width > fontWidth)
        {
            while (sf.Width > fontWidth)
            {
                fontSize -= 0.1f;
                font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
                sf = graph.MeasureString(text, font);

                times++;
            }

            Console.WriteLine("一开始估计大了，最终字体大小为{0}，循环了{1}次", font.ToString(), times);
        }
        else if (sf.Width < fontWidth)
        {
            while (sf.Width < fontWidth)
            {
                fontSize += 0.1f;
                font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
                sf = graph.MeasureString(text, font);

                times++;
            }

            Console.WriteLine("一开始估计小了，最终字体大小为{0}，循环了{1}次", font.ToString(), times);
        }

        graph.DrawImage(img, 0, 0, width, height);
        graph.DrawString(text, font, new SolidBrush(Color.Red), x1, y1);

        graph.Dispose();
        img.Dispose();

        return bmp;
    }
    /// <summary>
    /// 压缩图片
    /// </summary>
    /// <param name="filePath">要压缩的图片的路径</param>
    /// <param name="filePath_ystp">压缩后的图片的路径</param>
    public void ystp(HttpPostedFile uploadFile, string newFileFullName)
    {
        //Bitmap
        Bitmap bmp = null;

        //ImageCoderInfo 
        ImageCodecInfo ici = null;

        //Encoder
        Encoder ecd = null;

        //EncoderParameter
        EncoderParameter ept = null;

        //EncoderParameters
        EncoderParameters eptS = null;

        try
        {
            bmp = new Bitmap(uploadFile.InputStream);

            ici = this.getImageCoderInfo("image/jpeg");

            ecd = Encoder.Quality;

            eptS = new EncoderParameters(1);

            ept = new EncoderParameter(ecd, 20L);

            eptS.Param[0] = ept;

            bmp.Save(@Server.MapPath(newFileFullName), ici, eptS);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            bmp.Dispose();

            ept.Dispose();

            eptS.Dispose();
        }
    }
    /// <summary>
    /// 旋转图片到正确位置
    /// </summary>
    /// <param name="image"></param>
    public static void OrientationImage(System.Drawing.Image image)
    {
        if (Array.IndexOf(image.PropertyIdList, 274) > -1)
        {
            var orientation = (int)image.GetPropertyItem(274).Value[0];
            switch (orientation)
            {
                case 1:
                    // No rotation required.
                    break;
                case 2:
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 3:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 4:
                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                case 5:
                    image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 7:
                    image.RotateFlip(RotateFlipType.Rotate270FlipX);
                    break;
                case 8:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
            image.RemovePropertyItem(274);
        }
    }

    /// <summary>
    /// 获取图片编码类型信息
    /// </summary>
    /// <param name="coderType">编码类型</param>
    /// <returns>ImageCodecInfo</returns>
    private ImageCodecInfo getImageCoderInfo(string coderType)
    {
        ImageCodecInfo[] iciS = ImageCodecInfo.GetImageEncoders();

        ImageCodecInfo retIci = null;

        foreach (ImageCodecInfo ici in iciS)
        {
            if (ici.MimeType.Equals(coderType))
                retIci = ici;
        }

        return retIci;
    }

    /// <summary>
    /// 获取IP地址
    /// </summary>
    /// <returns></returns>
    public string GetIPToString()
    {
        string rValue = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            // Encoding = System.Text.Encoding.UTF32
        })
        {
            //
            string url = "http://whois.pconline.com.cn/ipJson.jsp";
            var data = client.DownloadString(url);
            rValue = data.Substring(39, data.Length - 7 - 39);
            Rootobject rt = JsonConvert.DeserializeObject<Rootobject>(rValue);
            rValue = "IP:" + rt.ip + " 位置:" + rt.addr;
        }
        return rValue;
    }

    /// <summary>
    /// 生成带二维码的专属推广图片
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string Draw(string strPhoneNo, string eCodeUrl)
    {
        //背景图片
        string path = Server.MapPath(@"/Shop/Img/NullEcode.png");
        //string eCodeUrl = Server.MapPath(@"/Shop/Img/Ecode.png");
        System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);

        //处理二维码图片大小 240*240px
        System.Drawing.Image qrCodeImage = ReduceImage(eCodeUrl, 500, 500);

        //处理头像图片大小 100*100px
        // System.Drawing.Image titleImage = ReduceImage(strHeadImageUrl, 50, 50);
        using (Graphics g = Graphics.FromImage(imgSrc))
        {
            //画专属推广二维码
            g.DrawImage(qrCodeImage, new Rectangle(130,//X坐标
            280,//y坐标
            qrCodeImage.Width,
            qrCodeImage.Height),
            0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel);

            //画头像
            // g.DrawImage(titleImage, 240 / 2 - 25, 240 / 2 - 25, titleImage.Width, titleImage.Height);
        }
        string imageName = strPhoneNo + "Code.jpg";
        string newpath = Server.MapPath(@"/Shop/Img/" + imageName);
        imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        return imageName;
    }
    /// <summary>
    /// 缩小/放大图片
    /// </summary>
    /// <param name="url">图片网络地址</param>
    /// <param name="toWidth">缩小/放大宽度</param>
    /// <param name="toHeight">缩小/放大高度</param>
    /// <returns></returns>
    public System.Drawing.Image ReduceImage(string url, int toWidth, int toHeight)
    {
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream responseStream = response.GetResponseStream();

        System.Drawing.Image originalImage = System.Drawing.Image.FromStream(responseStream);
        if (toWidth <= 0 && toHeight <= 0)
        {
            return originalImage;
        }
        else if (toWidth > 0 && toHeight > 0)
        {
            if (originalImage.Width < toWidth && originalImage.Height < toHeight)
                return originalImage;
        }
        else if (toWidth <= 0 && toHeight > 0)
        {
            if (originalImage.Height < toHeight)
                return originalImage;
            toWidth = originalImage.Width * toHeight / originalImage.Height;
        }
        else if (toHeight <= 0 && toWidth > 0)
        {
            if (originalImage.Width < toWidth)
                return originalImage;
            toHeight = originalImage.Height * toWidth / originalImage.Width;
        }
        System.Drawing.Image toBitmap = new Bitmap(toWidth, toHeight);
        using (Graphics g = Graphics.FromImage(toBitmap))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(originalImage,
                        new Rectangle(0, 0, toWidth, toHeight),
                        new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                        GraphicsUnit.Pixel);
            originalImage.Dispose();
            return toBitmap;
        }
    }
    public class Rootobject
    {
        public string ip { get; set; }
        public string pro { get; set; }
        public string proCode { get; set; }
        public string city { get; set; }
        public string cityCode { get; set; }
        public string region { get; set; }
        public string regionCode { get; set; }
        public string addr { get; set; }
        public string regionNames { get; set; }
        public string err { get; set; }
    }

}
