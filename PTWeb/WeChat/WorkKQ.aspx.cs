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

public partial class WeChat_WorkKQ : PageBase
{
    #region pageParameters
    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   // 微信JS签名
            this.appId = WebConfigurationManager.AppSettings["AgentId"]; /// 企业微信ID
            this.timeStamp = getTimestamp();
            this.nonceStr = getNoncestr();
            this.signature = GenSignature_Woker(this.nonceStr, this.timeStamp);
            this.DataBind();
            this.Label_XM.Text = UserNAME;

            /// 加载考勤信息
            LoadQDList();
        }
    }
    /// <summary>
    /// 数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_JG_LinkButton1_Click(object sender, EventArgs e)
    {
        if (TextBox_JD.Text.Length == 0 || TextBox_WD.Text.Length == 0)
        {
            MessageBox("", "未获取到位置信息，请稍后再试。");
        }
        else
        {
            SaveData();
        }
    }



    /// <summary>
    /// 保存考勤数据
    /// </summary>
    private void SaveData()
    {
        string Image1 = UploadTP(FileUpload_TP);
        string Image2 = UploadTP(FileUpload_TP2);
        string Image3 = UploadTP(FileUpload_TP3);
        string Image4 = UploadTP(FileUpload_TP4);
        string Image5 = UploadTP(FileUpload_TP5);
        string Image6 = UploadTP(FileUpload_TP6);
        string Image7 = UploadTP(FileUpload_TP7);
        string Image8 = UploadTP(FileUpload_TP8);
        string Image9 = UploadTP(FileUpload_TP9);

        string strRemark = TextBox_Remark.Text.Replace("'", "\"");

        if (Image1.Length > 0)
        {
            string strSQL = "Insert into w_KQ (UserID,ZB_JD,ZB_WD,ZB_WZ,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Remark) values (" + DefaultUser + ",'" + TextBox_JD.Text + "','" + TextBox_WD.Text + "','" + TextBox_WZ.Text + "','" + Image1 + "','" + Image2 + "','" + Image3 + "','" + Image4 + "','" + Image5 + "','" + Image6 + "','" + Image7 + "','" + Image8 + "','" + Image9 + "','" + strRemark + "')";
            if (!OP_Mode.SQLRUN(strSQL))
            {//失败，则删除上传的图片

                if (File.Exists(Server.MapPath("\\KQImage\\" + Image1))) { File.Delete(Server.MapPath("\\KQImage\\" + Image1)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image2))) { File.Delete(Server.MapPath("\\KQImage\\" + Image2)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image3))) { File.Delete(Server.MapPath("\\KQImage\\" + Image3)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image4))) { File.Delete(Server.MapPath("\\KQImage\\" + Image4)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image5))) { File.Delete(Server.MapPath("\\KQImage\\" + Image5)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image6))) { File.Delete(Server.MapPath("\\KQImage\\" + Image6)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image7))) { File.Delete(Server.MapPath("\\KQImage\\" + Image7)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image8))) { File.Delete(Server.MapPath("\\KQImage\\" + Image8)); }
                if (File.Exists(Server.MapPath("\\KQImage\\" + Image9))) { File.Delete(Server.MapPath("\\KQImage\\" + Image9)); }

                MessageBox("", "签到失败，请重试！" + OP_Mode.strErrMsg);
            }
            else
            {
                MessageBox("", "签到成功。", "/");
            }
        }
        else
        {
            MessageBox("", "请拍摄一张照片。");
        }
    }
    /// <summary>
    /// 加载考勤信息
    /// </summary>
    private void LoadQDList()
    {
        string strTemp = string.Empty;
        string strSQL = string.Empty;

        strSQL = "Select w_kq.*,CName,HeadUrl from w_kq,S_USERINFO where UserID=S_USERINFO.ID and userid=" + DefaultUser + " and w_kq.ctime between '" + System.DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00' order by w_kq.ctime desc";

        //if (GridView_MSG_Label_tj.Text.Length > 0)
        //{
        //    strSQL = "Select * from w_kq,S_USERINFO where UserID=S_USERINFO.ID and " + GridView_MSG_Label_tj.Text + " order by CName,w_kq.ctime desc";
        //}

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i == 0)
                    {
                        strTemp += " <div class='timeline-label'>";
                        strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                        strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                        strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                        strTemp += "  </span>";
                        strTemp += " </div>";
                    }
                    else
                    {
                        if (Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") != Convert.ToDateTime(OP_Mode.Dtv[i - 1]["CTime"]).ToString("yyyy-MM-dd"))
                        {
                            strTemp += " <div class='timeline-label'>";
                            strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                            strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                            strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                            strTemp += "  </span>";
                            strTemp += " </div>";
                        }
                    }

                    strTemp += "<div class='timeline-item clearfix'>";
                    strTemp += "  <div class='timeline-info'>";
                    if (OP_Mode.Dtv[i]["HeadUrl"].ToString().Length > 0)
                    {
                        strTemp += "<img src='" + OP_Mode.Dtv[i]["HeadUrl"].ToString() + "' />";
                    }
                    strTemp += "      <span class='label label-info label-sm'>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("HH:mm") + "</span>";
                    strTemp += "  </div>";
                    strTemp += "  <div class='widget-box transparent'>";
                    strTemp += "      <div class='widget-header widget-header-small'>";
                    strTemp += " <h5 class='smaller'>";
                    strTemp += "  <span class='grey'><a href='#'>" + OP_Mode.Dtv[i]["ZB_WZ"] + "</a></span>";
                    strTemp += " </h5>";
                    strTemp += "          <span class='widget-toolbar'>";
                    strTemp += "              <a href='#' data-action='collapse'>";
                    strTemp += "                 <i class='icon-chevron-up'></i>";
                    strTemp += "             </a>";
                    strTemp += "         </span>";
                    strTemp += "     </div>";
                    strTemp += "     <div class='widget-body'>";
                    strTemp += "         <div class='widget-main'>";
                    if (OP_Mode.Dtv[i]["Image1"].ToString().Length > 0)
                    {
                        strTemp += "             <a href='/KQImage/" + OP_Mode.Dtv[i]["Image1"].ToString() + "'><img src='/KQImage/" + OP_Mode.Dtv[i]["Image1"].ToString() + "' /></a>";
                    }
                    if (OP_Mode.Dtv[i]["Image2"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image2"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image3"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image3"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image4"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image4"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image5"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image5"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image6"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image6"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image7"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image7"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image8"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image8"].ToString() + "' />";
                    }
                    if (OP_Mode.Dtv[i]["Image9"].ToString().Length > 0)
                    {
                        strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image9"].ToString() + "' />";
                    }
                    strTemp += OP_Mode.Dtv[i]["Remark"];
                    strTemp += "       </div>";
                    strTemp += "     </div>";
                    strTemp += "   </div>";
                    strTemp += " </div>";
                }
                if (strTemp.Length > 0)
                {
                    QDList.InnerHtml = strTemp;
                }
            }
        }
        else
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg);
        }
    }

    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTP(FileUpload fileName)
    {
        string name = fileName.PostedFile.FileName;//获取文件名称

        if (name.Length > 0)
        {
            if (fileName.HasFile)
            {
                int i = fileName.PostedFile.ContentLength;   //得到上传文件大小

                int index = name.LastIndexOf(".");

                string lastName = name.Substring(index, name.Length - index);//文件后缀

                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + lastName;//新文件名
                                                                                       //  string newname = "12345" + lastName;
                string path = Server.MapPath("~/KQImage/" + newname);

                string URLpath = Server.MapPath("\\KQImage\\" + newname);

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
                            fileName.PostedFile.SaveAs(path);//保存到服务器上	 小于1M的图片不进行压缩处理
                        }
                        else
                        { /// 大于1M的图片文件压缩后上传
                            ystp(fileName.PostedFile, "~/KQImage/" + newname);
                        }

                        /// 设置图片文字
                        string strTemp = string.Empty;
                        if (TextBox_WZ.Text.Length > 0)
                        {
                            strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "\r\n" + TextBox_WZ.Text;
                        }
                        else
                        {
                            strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm");
                        }

                        //添加水印
                        System.Drawing.Image imgSrc = AddText(@URLpath, "50,50", "300, 100", strTemp);

                        string imageName = "SY" + newname;
                        string newpath = Server.MapPath(@"/KQImage/" + imageName);
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

    ///// <summary>
    ///// 清除查询条件
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void GridView_FXX_LinkButton3_Click(object sender, EventArgs e)
    //{

    //    this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;

    //    this.GridView_MSG_Label1.Text = string.Empty;

    //    this.GridView_MSG_Label_tj.Text = string.Empty;

    //    this.GridView_FXX_alerts_tj.Visible = false;

    //    LoadQDList();
    //}
    ///// <summary>
    ///// 查询
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void GridView_FXX_LinkButton4_Click(object sender, EventArgs e)
    //{
    //    LoadQDList();
    //}
    ///// <summary>
    ///// 查询条件添加
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void GridView_MSG_TJADD_Click(object sender, EventArgs e)
    //{

    //    string strDiv = string.Empty;

    //    if (this.GridView_MSG_TextBox_CXTJ.Text.Length == 0)

    //    {
    //        this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;
    //        this.GridView_FXX_alerts_tj.Visible = false;

    //    }

    //    if (this.GridView_MSG_Label1.Text.Length > 0)

    //    {

    //        this.GridView_MSG_Label1.Text += "<b>并且</b><br />";

    //        this.GridView_MSG_Label_tj.Text += " and ";

    //    }

    //    this.GridView_MSG_Label1.Text += this.GridView_MSG_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_MSG_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_MSG_TextBox_CXTJ.Text + "&nbsp;";

    //    if (this.GridView_MSG_DropDownList_SF.SelectedValue == "LIKE")

    //    {

    //        this.GridView_MSG_Label_tj.Text += " " + this.GridView_MSG_DropDownList1.SelectedValue + " " + this.GridView_MSG_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_MSG_TextBox_CXTJ.Text.Trim() + "%'";

    //    }

    //    else

    //    {

    //        this.GridView_MSG_Label_tj.Text += " " + this.GridView_MSG_DropDownList1.SelectedValue + " " + this.GridView_MSG_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_MSG_TextBox_CXTJ.Text.Trim() + "'";

    //    }

    //    this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;

    //    this.GridView_FXX_alerts_tj.Visible = true;

    //}
}