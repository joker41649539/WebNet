using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;
using Image = System.Drawing.Image;

public partial class Shop_Default2 : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        string strImgUrl = string.Empty;
        if (DefaultUser != null)
        {
            string strSQL = "Select * from Shop_UserInfo where PhoneNo='" + DefaultUser + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    strImgUrl = OP_Mode.Dtv[0]["ECode"].ToString();
                }
            }
        }
        if (strImgUrl.Length > 0)
        {
            Image1.ImageUrl = "/Shop/Img/" + strImgUrl;
            LinkButton1.Visible=false;
        }
        else
        {
            LinkButton1.Visible = true;
            Image1.ImageUrl = "/Shop/Img/Ecode.png";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string SavePath = "Shop/Img";// 图片保存路径  ，无需/  ~/KQImage/

        string strURL = "http://" + HttpContext.Current.Request.Url.Authority.ToString() + "/Shop/Img/" + QRImage("http://223.244.20.182:800/Shop/Reg.aspx?Parent=" + DefaultUser, DefaultUser + ".jpg");

        string strImgUrl = Draw(DefaultUser + "code", strURL);

        Image1.ImageUrl = "/Shop/Img/" + strImgUrl;

        if (strImgUrl.Length > 0)
        {
            string strSQL = "Update Shop_UserInfo set ECode='" + strImgUrl + "' where PhoneNo='" + DefaultUser + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("","您的专属二维码已经生成。<br/>您可将此码转发给您的朋友进行注册。");
            }
        }
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

        string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"/Shop/Img/";    //文件目录
        string qrString = sCode;                         //二维码字符串
        string logoFilePath = string.Empty;                 //Logo路径50*50
        string filePath = path + sImageFile;             //二维码文件名

        CreateQRCode(qrString, "Byte", 20, 0, "H", filePath, false, logoFilePath);

        rValue = sImageFile;

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
                Image copyImage = Image.FromFile(logoFilePath);
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
}