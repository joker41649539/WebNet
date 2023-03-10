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

    protected void Button1_Click(object sender, EventArgs e)
    {

        int iFilCount = Request.Files.Count;

        for (int i = 0; i < iFilCount; i++)
        {
            HttpPostedFile f = Request.Files[0];
            UploadTP(f);
        }
      //  MessageBox("", "文件数量：" + Request.Files.Count.ToString());
    }

    private string UploadTP(HttpPostedFile fileName)
    {
        //string name = fileName.FileName;//获取文件名称

        //if (name.Length > 0)
        //{
        //        int i = fileName.ContentLength;   //得到上传文件大小

        //        int index = name.LastIndexOf(".");

        //        string lastName = name.Substring(index, name.Length - index);//文件后缀

        //        string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + lastName;//新文件名
        //                                                                               //  string newname = "12345" + lastName;
        //        string path = Server.MapPath("~/KQImage/" + newname);

        //        string URLpath = Server.MapPath("\\KQImage\\" + newname);

        //        if (System.IO.File.Exists(URLpath))
        //        {
        //            return string.Empty;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                if (i < 1048576)
        //                {
        //                    fileName.SaveAs(path);//保存到服务器上	 小于1M的图片不进行压缩处理
        //                }
        //                else
        //                { /// 大于1M的图片文件压缩后上传
        //                   // ystp(fileName.PostedFile, "~/KQImage/" + newname);
        //                }

        //                /// 设置图片文字
        //                string strTemp = string.Empty;
        //                if (Hidden_WZ.Value.Length > 0)
        //                {
        //                    strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "\r\n" + Hidden_WZ.Value;
        //                }
        //                else
        //                {
        //                    strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        //                }

        //                //添加水印
        //                System.Drawing.Image imgSrc = AddText(@URLpath, "50,50", "300, 100", strTemp);

        //                string imageName = "SY" + newname;
        //                string newpath = Server.MapPath(@"/KQImage/" + imageName);
        //                imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                //释放水印图片
        //                ///// 水印成功后，删除原图片
        //                if (File.Exists(URLpath)) { File.Delete(URLpath); }

        //                return imageName;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox("", "服务器正忙，请稍后再试！" + ex.ToString());
        //                return string.Empty;
        //            }

        //        }

        //}
        return string.Empty;
    }
}