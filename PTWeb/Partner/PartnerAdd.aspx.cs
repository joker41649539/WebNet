using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;

public partial class Partner_PartnerAdd : PageBase
{
    public string strSQL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 提交申请
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            SaveData();
        }
    }

    /// <summary>
    /// 数据验证
    /// </summary>
    /// <returns></returns>
    protected Boolean Validation()
    {
        Boolean rValue = true;
        string strErrMsg = string.Empty;
        int i = 0;

        if (TextBox_Name.Text.Length <= 0)
        {
            i++;
            strErrMsg += i.ToString() + "、真实姓名必须填写。<br>";
        }

        if (TextBox_Tel.Text.Length != 11)
        {
            i++;
            strErrMsg += i.ToString() + "、手机号码必须认真填写。<br>";
        }

        if (TextBox_No.Text.Length != 18)
        {
            i++;
            strErrMsg += i.ToString() + "、请填写您的18位身份证号码。<br>";
        }
        if (Request.Files[0].FileName.Length <= 0)
        {
            i++;
            strErrMsg += i.ToString() + "、请上传您的身份证头像面照片。<br>";
        }
        if (Request.Files[1].FileName.Length <= 0)
        {
            i++;
            strErrMsg += i.ToString() + "、请上传您的身份证国徽面照片。<br>";
        }

        if (i > 0)
        {
            strErrMsg += "请认真填写以上信息。";
            MessageBox("", strErrMsg);
            rValue = false;
        }
        else
        {
            strSQL = "Select ID from S_USERINFO where ZJHM='" + TextBox_No.Text.Replace("'", "") + "'";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    MessageBox("", "您已经在我们的系统库,请勿重复提交。");
                    rValue = false;
                }
            }
        }

        return rValue;
    }

    /// <summary>
    /// 数据保存
    /// </summary>
    private void SaveData()
    {
        string strIMGName = string.Empty;
        string strIDNo = TextBox_No.Text.Replace("'", "");
        string strCName = TextBox_Name.Text.Replace("'", "");
        int iSex = Convert.ToInt32(RadioButtonList_Six.SelectedValue);
        string strTel = TextBox_Tel.Text.Replace("'", "");
        string strRemark = TextBox_Remark.Text.Replace("'", "");

        for (int i = 1; i < Request.Files.Count + 1; i++)
        {
            strIMGName += UploadTPs(Request.Files[i - 1], strIDNo + "_" + i.ToString("00")) + ";";
        }
        if (strIMGName.Length > 0)
        {
            /// S_USERINFO FLAG=2 为待审核 3为审核通过的协同人员
            strSQL = " Insert into S_USERINFO (LoginName,Password,CName,XB,SSDZ,ZJHM,FLAG,IDIMG,Remark) values ('" + strIDNo + "','" + strIDNo + "','" + strCName + "'," + iSex + ",'" + strTel + "','" + strIDNo + "',2,'" + strIMGName + "','" + strRemark + "')";

            if (OP_Mode.SQLRUN(strSQL))
            {
                // string strUserOpenid = "LiHuan|LuXiaoJun";
                string strUserOpenid = "LiHuan"; /// 企业微信发送用户，锁死固定人员
                string strUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wwcb109f513aaa59b1&redirect_uri=http%3a%2f%2fwww.putian.ink/Partner/Default.aspx%3fWechat%3d0&response_type=code&scope=snsapi_base&state=#wechat_redirect";
                SendWorkMsgCard(strUserOpenid, "协同人员资料申请", "[" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "] 用户：[" + strCName + "] 提交了一份申请资料。请您及时处理。", strUrl);
                MessageBox("", "申请提交成功。<br>请等待审核人员审核。", "/Partner/WellCome.aspx");
                return;
            }
            else
            {
                MessageBox("", "错误：" + OP_Mode.strErrMsg + " " + strSQL);
            }
        }
        else
        {
            MessageBox("", "申请提交失败。<br>请重试。");
            return;
        }
    }


    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTPs(HttpPostedFile fileName, string NewFilName)
    {
        string name = fileName.FileName;//获取文件名称
        string IDImg = "IDImage";

        if (name.Length > 0)
        {
            int i = fileName.ContentLength;   //得到上传文件大小

            int index = name.LastIndexOf(".");

            string lastName = name.Substring(index, name.Length - index);//文件后缀

            //string newname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + lastName;//新文件名
            string newname = NewFilName + lastName;//新文件名
                                                   //  string newname = "12345" + lastName;
            string path = Server.MapPath("~/" + IDImg + "/" + newname);

            string URLpath = Server.MapPath("\\" + IDImg + "\\" + newname);

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
                        ystp(fileName, "~/" + IDImg + "/" + newname);
                    }

                    /// 设置图片文字
                    string strTemp = string.Empty;

                    strTemp = "合肥普田科技有限公司" + "\r\n人员入职使用 " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                    //添加水印
                    System.Drawing.Image imgSrc = AddText(@URLpath, "50,50", "300, 100", strTemp);

                    string imageName = "ID" + newname;
                    string newpath = Server.MapPath(@"/" + IDImg + "/" + imageName);
                    imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //释放水印图片
                    ///// 水印成功后，删除原图片
                    if (File.Exists(URLpath)) { File.Delete(URLpath); }

                    return imageName;
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

    #region 图片相关
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
    /// 地球半径
    /// </summary>
    private static double EARTH_RADIUS = 6378.137;

    private static double rad(double d)
    {
        return d * Math.PI / 180.0;
    }
    /// <summary>
    /// 计算两点直线距离
    /// </summary>
    /// <param name="lat1"></param>
    /// <param name="lng1"></param>
    /// <param name="lat2"></param>
    /// <param name="lng2"></param>
    /// <returns>范围距离单位:米</returns>
    public static double getDistance(double lat1, double lng1, double lat2, double lng2)
    {
        double radLat1 = rad(lat1);
        double radLat2 = rad(lat2);
        double a = radLat1 - radLat2;
        double b = rad(lng1) - rad(lng2);
        double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2)
                + Math.Cos(radLat1) * Math.Cos(radLat2)
                * Math.Pow(Math.Sin(b / 2), 2)));
        s = s * EARTH_RADIUS;
        s = Math.Round(s * 10000d) / 10000d;
        s = s * 1000;
        return s;
    }

    #endregion 压缩图片
}