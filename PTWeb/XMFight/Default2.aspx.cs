using Stimulsoft.Report.Components.ShapeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;
using Image = System.Drawing.Image;

public partial class XMFight_Default2 : PageBaseXMFight
{
    //public partial class HTMLEncodeGridView : BaseCode { protected void Page_Load(object sender, EventArgs e) { } }
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// 生成场景二维码 按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //QRCodeHandler.
        string strImgUrl = QRImage("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FRemember%2F?id=121&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect", "");

        Image1.ImageUrl = "/images/" + DrawImage("ooUML6EsI6okXuBBhZ-_l4ur204Y", 1, "http://www.putian.ink/BxImages/SY20230213075334950.jpg", strImgUrl);
    }

    /// <summary>
    /// 生成带二维码的专属推广图片
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string DrawImage(string strOPENID, int strID, string strHeadImageUrl, string strImageUrl)
    {
        //背景图片
        //       string path = Server.MapPath(@"/TuiGuang/White.png");
        string path = Server.MapPath(@"/images/TT.png");

        //string path = "http://www.putian.ink/BxImages/SY20230213075334950.jpg";

        System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);
        int CodeSize = 240;// 二维码大小
        int HeadImgSize = 50;// 头像大小

        int CodeImgX = imgSrc.Width / 2 + CodeSize / 4 + 70;/// 二维码X坐标
        int CodeImgY = imgSrc.Height - CodeSize - 50;/// 二维码Y坐标

        //处理二维码图片大小 240*240px
        System.Drawing.Image qrCodeImage = ReduceImage(strImageUrl, CodeSize, CodeSize);

        //处理头像图片大小 100*100px
        System.Drawing.Image titleImage = ReduceImage(strHeadImageUrl, HeadImgSize, HeadImgSize);

        using (Graphics g = Graphics.FromImage(imgSrc))
        {
            //画专属推广二维码
            g.DrawImage(qrCodeImage, new Rectangle(CodeImgX,
            CodeImgY,
            qrCodeImage.Width,
            qrCodeImage.Height),
            0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel);

            //画头像
            g.DrawImage(titleImage, CodeImgX + HeadImgSize, CodeImgY + HeadImgSize, titleImage.Width, titleImage.Height);

            // Font font = new Font("宋体", 30, FontStyle.Bold);

            // g.DrawString(user.nickname, font, new SolidBrush(Color.Red), 110, 10);
        }
        string imageName = strOPENID + ".jpg";
        string newpath = Server.MapPath(@"/images/" + imageName);
        imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        return imageName;
    }


    /// <summary>
    /// 返回二维码图片地址
    /// </summary>
    /// <param name="sCode">需要生成二维码的代码</param>
    /// <param name="sImageFile">生成文件的文件名，可不填写。必须有后缀</param>
    /// <returns>返回二维码图片地址</returns>
    public string QRImage(string sCode, string sImageFile)
    {
        string rValue = string.Empty;

        if (sImageFile == "")
        {
            sImageFile = "myCode1.jpg";
        }

        string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"/images/";    //文件目录
        string qrString = sCode;                         //二维码字符串
        string logoFilePath = string.Empty;                 //Logo路径50*50
        string filePath = path + sImageFile;             //二维码文件名

        CreateQRCode(qrString, "Byte", 2, 0, "H", filePath, false, logoFilePath);   //生成

        rValue = path + sImageFile;

        return rValue;
    }

    /// <summary>  
    /// 创建二维码  使用   ThoughtWorks.QRCode.dll   版本：1.0.2774.19990
    /// </summary>  
    /// <param name="QRString">二维码字符串</param>  
    /// <param name="QRCodeEncodeMode">二维码编码(Byte、AlphaNumeric、Numeric)</param>  
    /// <param name="QRCodeScale">二维码尺寸(Version为0时，1：26x26，每加1宽和高各加25</param>  
    /// <param name="QRCodeVersion">二维码密集度0-40</param>  
    /// <param name="QRCodeErrorCorrect">二维码纠错能力(L：7% M：15% Q：25% H：30%)</param>  
    /// <param name="filePath">保存路径</param>  
    /// <param name="hasLogo">是否有logo(logo尺寸50x50，QRCodeScale>=5，QRCodeErrorCorrect为H级)</param>  
    /// <param name="logoFilePath">logo路径</param>  
    /// <returns></returns>  
    public bool CreateQRCode(string QRString, string QRCodeEncodeMode, short QRCodeScale, int QRCodeVersion, string QRCodeErrorCorrect, string filePath, bool hasLogo, string logoFilePath)
    {
        bool result = true;

        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

        switch (QRCodeEncodeMode)
        {
            case "Byte":
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                break;
            case "AlphaNumeric":
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                break;
            case "Numeric":
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                break;
            default:
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                break;
        }

        qrCodeEncoder.QRCodeScale = QRCodeScale;
        qrCodeEncoder.QRCodeVersion = QRCodeVersion;

        switch (QRCodeErrorCorrect)
        {
            case "L":
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                break;
            case "M":
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                break;
            case "Q":
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                break;
            case "H":
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                break;
            default:
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                break;
        }

        try
        {
            Image image = qrCodeEncoder.Encode(QRString, System.Text.Encoding.UTF8);
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            fs.Close();

            if (hasLogo)
            {
                Image copyImage = System.Drawing.Image.FromFile(logoFilePath);
                Graphics g = Graphics.FromImage(image);
                int x = image.Width / 2 - copyImage.Width / 2;
                int y = image.Height / 2 - copyImage.Height / 2;
                g.DrawImage(copyImage, new Rectangle(x, y, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                g.Dispose();

                image.Save(filePath);
                copyImage.Dispose();
            }
            image.Dispose();

        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }
    /// 临时二维码请求
    /// http请求方式: POST URL: https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=TOKEN 
    /// POST数据格式：json POST数据例子：
    /// {"expire_seconds": 604800, "action_name": "QR_SCENE", "action_info": {"scene": {"scene_id": 123}}} 
    /// http请求方式: POST URL: https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=TOKEN 
    /// 或者也可以使用以下 POST 数据创建字符串形式的二维码参数：
    /// {"expire_seconds": 604800, "action_name": "QR_STR_SCENE", "action_info": {"scene": {"scene_str": "test"}}}


}