using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_Tesp : PageBase
{
    #region pageParameters
    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //public ActionResult UploadSignature2(string src_data)
    //{
    //    Class1.Base64StrToImage(src_data, "C:\\Users\\45448\\Desktop\\1\\" + DateTime.Now.ToString("yyyyMMddHHss") + ".png");
    //    return Json(1, JsonRequestBehavior.AllowGet);
    //}

    ///// <summary>
    ///// 将Base64字符串转换为图片并保存到本地
    ///// </summary>
    ///// <param name="base64Str">base64字符串</param>
    ///// <param name="savePath">图片保存地址，如：/Content/Images/10000.png</param>
    ///// <returns></returns>
    //public static bool Base64StrToImage(string base64Str, string savePath)
    //{
    //    var ret = true;
    //    try
    //    {
    //        base64Str = base64Str.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
    //            .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", ""); //将base64头部信息替换
    //        var bitmap = Base64StrToImage(base64Str);
    //        if (bitmap != null)
    //        {
    //            //创建文件夹
    //            var folderPath = savePath.Substring(0, savePath.LastIndexOf('\\'));
    //            ////FileHelper.CreateDir(folderPath);
    //            if (!Directory.Exists(folderPath))
    //            {
    //                Directory.CreateDirectory(folderPath);
    //            }
    //            //图片后缀格式
    //            var suffix = savePath.Substring(savePath.LastIndexOf('.') + 1,
    //                savePath.Length - savePath.LastIndexOf('.') - 1).ToLower();
    //            var suffixName = suffix == "png"
    //                ? ImageFormat.Png
    //                : suffix == "jpg" || suffix == "jpeg"
    //                    ? ImageFormat.Jpeg
    //                    : suffix == "bmp"
    //                        ? ImageFormat.Bmp
    //                        : suffix == "gif"
    //                            ? ImageFormat.Gif
    //                            : ImageFormat.Jpeg;

    //            //这里复制一份对图像进行保存，否则会出现“GDI+ 中发生一般性错误”的错误提示
    //            var bmpNew = new Bitmap(bitmap);
    //            bmpNew.Save(savePath, suffixName);
    //            bmpNew.Dispose();
    //            bitmap.Dispose();
    //        }
    //        else
    //        {
    //            ret = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ret = false;
    //    }
    //    return ret;

    //}
}