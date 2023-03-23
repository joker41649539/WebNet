﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Font = System.Drawing.Font;

public partial class Images : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Image1 = String.Empty;

        int iFilCount = Request.Files.Count;

        for (int i = 0; i < iFilCount; i++)
        {
            HttpPostedFile f = Request.Files[i];
            Image1 += UploadTPs(f, i) + ";";
        }
        if (Image1.Length > 0)
        {
            if (SaveSQLData(Image1))
            {
                MessageBox("", "上传成功。");
                LoadData();
            }
        }
    }

    private void LoadData()
    {
        string SavePath = "KQImage";// 图片保存路径  ，无需/  ~/KQImage/
        string TempHtml = string.Empty;
        string[] TemgImage;
        int DB_Class = 0;
        string DB_DJBH = string.Empty;
        try
        {
            DB_Class = Convert.ToInt32(Request["Class"]);
            DB_DJBH = Request["DJBH"];
        }
        catch
        {

        }
        string strSQL = "Select * from W_Images where iClass=" + DB_Class + " and DJBH='" + DB_DJBH + "' order by CTime desc";
        // string strSQL = "Select * from W_Images order by CTime desc";
        if (OP_Mode.SQLRUN(strSQL))
        {
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            {
                TemgImage = OP_Mode.Dtv[i]["Images"].ToString().Split(';');
                if (TemgImage.Length > 0)
                {
                    for (int ii = 0; ii < TemgImage.Length; ii++)
                    {
                        if (TemgImage[ii].Length > 0)
                        {
                            TempHtml += " <li>";
                            TempHtml += "                      <a href=\"/" + SavePath + "/" + TemgImage[ii] + "\" title=\"Photo Title\" data-rel=\"colorbox\">";
                            TempHtml += " <img alt=\"150x150\" style=\"max-width: 280px\" class=\"img-rounded\" src='/" + SavePath + "/" + TemgImage[ii] + "' />";
                            TempHtml += " <div class=\"tags\">";
                            TempHtml += "     <span class=\"label-holder\">";
                            TempHtml += "        <span class=\"label label-info arrowed-in\">" + OP_Mode.Dtv[i]["Title"].ToString() + "</span>";
                            TempHtml += "    </span>";
                            if (OP_Mode.Dtv[i]["Remark"].ToString().Length > 0)
                            {
                                TempHtml += "    <span class=\"label-holder\">";
                                TempHtml += "        <span class=\"label label-success\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span>";
                                TempHtml += "   </span>";
                            }

                            TempHtml += "    <span class=\"label-holder\">";
                            TempHtml += "        <span class=\"label label-grey\">" + OP_Mode.Dtv[i]["UserName"].ToString() + "</span>";
                            TempHtml += "   </span>";

                            TempHtml += "</div>";
                            TempHtml += "<div class=\"tools\">";
                            TempHtml += "    <a href =\"#\" >";
                            TempHtml += "        <i class=\"icon-remove red\"></i>";
                            TempHtml += "   </a>";
                            TempHtml += "</div>";
                            TempHtml += "</a>";
                            TempHtml += "</li>";
                        }
                        else
                        {
                            //continue;
                        }
                    }
                }
            }
            ShowImages.InnerHtml = TempHtml;
        }
    }

    private bool SaveSQLData(string ImagesName)
    {
        bool rValue = false;

        string DB_Title = TextBox_Title.Text.Replace("'", "");
        string DB_Remark = TextBox_Remark.Text.Replace("'", "");
        string DB_DJBH = "test";
        int iClass = 0;// 0 代表维修单
        try
        {
            iClass = Convert.ToInt32(Request["Class"]);
            DB_DJBH = Request["DJBH"];
        }
        catch
        {

        }
        string strSQL = "Insert into W_Images(Title,Images,DJBH,Remark,iClass,UserName) values ('" + DB_Title + "','" + ImagesName + "','" + DB_DJBH + "','" + DB_Remark + "'," + iClass + ",'" + UserNAME + "')";

        if (OP_Mode.SQLRUN(strSQL))
        {
            rValue = true;
        }

        return rValue;
    }

    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTPs(HttpPostedFile fileName, int sn)
    {
        string SavePath = "KQImage";// 图片保存路径  ，无需/  ~/KQImage/
        string Prefix = "Temp" + sn;// 新文件名前缀
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
    #endregion 压缩图片
}