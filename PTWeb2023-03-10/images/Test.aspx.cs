﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class images_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ystp(this.File1.PostedFile, "d:\\");
    }

    #region 压缩图片

    /// <summary>
    /// 压缩图片
    /// </summary>
    /// <param name="filePath">要压缩的图片的路径</param>
    /// <param name="filePath_ystp">压缩后的图片的路径</param>
    public void ystp(HttpPostedFile uploadFile, string newFileFullName)
    {
        if (uploadFile.ContentLength <=0)
        {
            return;
        }
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

            ept = new EncoderParameter(ecd, 30L);
            eptS.Param[0] = ept;
            bmp.Save(Server.MapPath("~/upload/12.jpg"), ici, eptS);
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

    #endregion 压缩图片


    ///// <summary>
    ///// asp.net上传图片并生成缩略图
    ///// </summary>
    ///// <param name="upImage">HtmlInputFile控件</param>
    ///// <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param>
    ///// <param name="sThumbExtension">缩略图的thumb</param>
    ///// <param name="intThumbWidth">生成缩略图的宽度</param>
    ///// <param name="intThumbHeight">生成缩略图的高度</param>
    ///// <returns>缩略图名称</returns>
    //public string UpLoadImage(HtmlInputFile upImage, string sSavePath, string sThumbExtension, int intThumbWidth, int intThumbHeight)
    //{
    //    string sThumbFile = "";
    //    string sFilename = "";
    //    if (upImage.PostedFile != null)
    //    {
    //        HttpPostedFile myFile = upImage.PostedFile;
    //        int nFileLen = myFile.ContentLength;
    //        if (nFileLen == 0)
    //            return "没有选择上传图片";
    //        //获取upImage选择文件的扩展名
    //        string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
    //        //判断是否为图片格式
    //        if (extendName != ".jpg" && extendName != ".jpge" && extendName != ".gif" && extendName != ".bmp" && extendName != ".png")
    //            return "图片格式不正确";

    //        byte[] myData = new Byte[nFileLen];
    //        myFile.InputStream.Read(myData, 0, nFileLen);
    //        sFilename = System.IO.Path.GetFileName(myFile.FileName);
    //        int file_append = 0;
    //        //检查当前文件夹下是否有同名图片,有则在文件名+1
    //        while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
    //        {
    //            file_append++;
    //            sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
    //                + file_append.ToString() + extendName;
    //        }
    //        System.IO.FileStream newFile
    //            = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename),
    //            System.IO.FileMode.Create, System.IO.FileAccess.Write);
    //        newFile.Write(myData, 0, myData.Length);
    //        newFile.Close();
    //        ////////////////////////////////////////////////////////    //以上为上传原图
    //        try
    //        {
    //            //原图加载
    //            using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
    //            {
    //                //原图宽度和高度
    //                int width = sourceImage.Width;
    //                int height = sourceImage.Height;
    //                int smallWidth;
    //                int smallHeight;
    //                //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高)
    //                if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight)
    //                {
    //                    smallWidth = intThumbWidth;
    //                    smallHeight = intThumbHeight * height / width;
    //                }
    //                else
    //                {
    //                    smallWidth = intThumbWidth * width / height;
    //                    smallHeight = intThumbHeight;
    //                }
    //                //判断缩略图在当前文件夹下是否同名称文件存在
    //                file_append = 0;
    //                sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + extendName;
    //                while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbFile)))
    //                {
    //                    file_append++;
    //                    sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
    //                        file_append.ToString() + extendName;
    //                }
    //                //缩略图保存的绝对路径
    //                string smallImagePath = System.Web.HttpContext.Current.Server.MapPath(sSavePath) + sThumbFile;
    //                //新建一个图板,以最小等比例压缩大小绘制原图
    //                using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight))
    //                {
    //                    //绘制中间图
    //                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
    //                    {
    //                        //高清,平滑
    //                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
    //                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    //                        g.Clear(Color.Black);
    //                        g.DrawImage(
    //                        sourceImage,
    //                        new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
    //                        new System.Drawing.Rectangle(0, 0, width, height),
    //                        System.Drawing.GraphicsUnit.Pixel
    //                        );
    //                    }
    //                    //新建一个图板,以缩略图大小绘制中间图
    //                    using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight))
    //                    {
    //                        //绘制缩略图  http://www.cnblogs.com/sosoft/
    //                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1))
    //                        {
    //                            //高清,平滑
    //                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
    //                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    //                            g.Clear(Color.Black);
    //                            int lwidth = (smallWidth - intThumbWidth) / 2;
    //                            int bheight = (smallHeight - intThumbHeight) / 2;
    //                            g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
    //                            g.Dispose();
    //                            bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            //出错则删除
    //            System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename));
    //            return "图片格式不正确";
    //        }
    //        //返回缩略图名称
    //        return sThumbFile;
    //    }
    //    return "没有选择图片";
    //}
}