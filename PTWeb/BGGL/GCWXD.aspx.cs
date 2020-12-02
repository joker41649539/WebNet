using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

public partial class GDGL_GCWXD : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(35, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没维修单的权限。", Defaut_QX_URL);
                return;
            }
            LoadData();
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void LoadData()
    {
        try
        {
            int iid = Convert.ToInt32(Request["ID"]);
            if (iid > 0)
            {
                LoadWXDByID(iid);
            }
            else
            {
                Label_dh.Text = "等待生成单号";
                Label_dh.ForeColor = Color.Red;
                Label_wxsj.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Label_WXRY.Text = UserNAME;
                Button1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = false;
                Button4.Visible = false;
                Hidden_WXRY.Value = DefaultUser;
            }
        }
        catch
        {
            Label_dh.Text = "等待生成单号";
            Label_dh.ForeColor = Color.Red;
            Label_wxsj.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            Label_WXRY.Text = UserNAME;
            Button3.Visible = false;
            Button4.Visible = false;
            Hidden_WXRY.Value = DefaultUser;
        }
    }

    /// <summary>
    /// 依据维修单ID加载维修单数据
    /// </summary>
    /// <param name="id"></param>
    private void LoadWXDByID(int id)
    {
        string strSQL;
        strSQL = "Select W_WXD.*,CNAME from W_WXD,S_USERINFO where WXRY=S_USERINFO.ID and del=0 and W_WXD.id=" + id.ToString();

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Hidden_WXRY.Value = OP_Mode.Dtv[0]["WXRY"].ToString();

                Label_DW.Text = OP_Mode.Dtv[0]["DWMC"].ToString();
                Label_dh.Text = OP_Mode.Dtv[0]["WXDH"].ToString();
                Label_WXRY.Text = OP_Mode.Dtv[0]["CNAME"].ToString();
                Label_wxsj.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["wxsj"].ToString()).ToString("yyyy-MM-dd HH:mm");
                ////////////////////

                TextBox_YH.Text = OP_Mode.Dtv[0]["YHMC"].ToString();
                TextBox_FLC.Text = OP_Mode.Dtv[0]["ZHMC"].ToString();
                TextBox_GZ.Text = OP_Mode.Dtv[0]["GZXX"].ToString();
                TextBox_WX.Text = OP_Mode.Dtv[0]["WXNR"].ToString();

                if (OP_Mode.Dtv[0]["WXFY"].ToString() == "0")
                {
                    TextBox_FY.Text = "";
                }
                else
                {
                    TextBox_FY.Text = OP_Mode.Dtv[0]["WXFY"].ToString();
                    RadioButtonList_WXFY.SelectedValue = "1";
                }

                RadioButtonList2.SelectedValue = OP_Mode.Dtv[0]["GZJY"].ToString();
                RadioButtonList3.SelectedValue = OP_Mode.Dtv[0]["SBJC"].ToString();
                RadioButtonList4.SelectedValue = OP_Mode.Dtv[0]["GZTD"].ToString();
                RadioButtonList5.SelectedValue = OP_Mode.Dtv[0]["WXJG"].ToString();

                TextBox_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                TextBox_LXDH.Text = OP_Mode.Dtv[0]["LXDH"].ToString();

                if (OP_Mode.Dtv[0]["FLAG"].ToString() == "0")
                {
                    Label_Flag.Text = "待提交";
                    Button1.Visible = true;
                    Button2.Visible = true;
                    Button3.Visible = false;
                    Button4.Visible = true;

                }
                else if (OP_Mode.Dtv[0]["FLAG"].ToString() == "1")
                {
                    Label_Flag.Text = "已完成";
                    Button1.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = true;
                    Button4.Visible = false;
                    SignDiv.InnerHtml = string.Empty;
                    SignBtnDiv.InnerHtml = string.Empty;
                }

                Image_Sign.ImageUrl = OP_Mode.Dtv[0]["QM"].ToString();
            }
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int iid = Convert.ToInt32(Request["ID"]);
            int NewID = SaveData(iid);
            if (NewID > 0)
            {
                MessageBox("", "单据保存成功。", "/BGGL/GCWXD.aspx?ID=" + NewID);
            }
            // }

        }
        catch (Exception ex)
        {
            MessageBox("", "保存错误：" + ex.ToString());
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    private int SaveData(int ID)
    {
        if (Hidden_WXRY.Value != DefaultUser)
        {
            MessageBox("", "您无权操作别人的单据，仅可以操作自己本人的单据。");
            return 0;
        }

        string strSQL = string.Empty;

        string DB_DW = Label_DW.Text.Replace("'", "\"");

        string DB_WXDH = Label_dh.Text;

        string DB_WXRY = DefaultUser;
        string DB_WXSJ = Convert.ToDateTime(Label_wxsj.Text).ToString("yyyy-MM-dd HH:mm");
        ////////////////////

        string DB_YH = TextBox_YH.Text.Replace("'", "\"");
        string DB_FLC = TextBox_FLC.Text.Replace("'", "\"");
        string DB_GZ = TextBox_GZ.Text.Replace("'", "\"");
        string DB_WX = TextBox_WX.Text.Replace("'", "\"");

        string DB_WXFY = RadioButtonList_WXFY.SelectedValue;

        string DB_FY = TextBox_FY.Text.Replace("'", "\"");

        int iDB_GZ = Convert.ToInt32(0 + RadioButtonList2.SelectedValue);
        int iDB_SBJC = Convert.ToInt32(0 + RadioButtonList3.SelectedValue);
        int IDB_GZTD = Convert.ToInt32(0 + RadioButtonList4.SelectedValue);
        int IDB_WXJG = Convert.ToInt32(0 + RadioButtonList5.SelectedValue);

        string DB_Remark = TextBox_Remark.Text.Replace("'", "\"");
        string DB_LXDH = TextBox_LXDH.Text.Replace("'", "\"");

        string DB_Sign = Image_Sign.ImageUrl;

        string DB_QM = HiddenField1.Value;

        if (HiddenField1.Value.Length > 0)
        {// 需要上传图片
            DB_QM = UploadTP(HiddenField1.Value.Substring(22));
        }
        else
        {
            DB_QM = Image_Sign.ImageUrl;
        }

        string strMSG = string.Empty;
        int i = 0;

        if (DB_YH.Length == 0)
        {
            i = i + 1;
            strMSG += i + "、银行名称必须填写。<BR>";
        }

        if (DB_FLC.Length == 0)
        {
            i = i + 1;
            strMSG += i + "、支行、分理处必须填写。<BR>";
        }

        if (DB_GZ.Length == 0)
        {
            i = i + 1;
            strMSG += i + "、故障原因必须填写。<BR>";
        }

        if (DB_WX.Length == 0)
        {
            i = i + 1;
            strMSG += i + "、维修内容必须填写。<BR>";
        }

        if (strMSG.Length > 0)
        {
            MessageBox("", strMSG);
            return 0;
        }

        if (ID > 0)
        {
            strSQL = "Update w_wxd set YHMC='" + DB_YH + "',ZHMC='" + DB_FLC + "',GZXX='" + DB_GZ + "',WXNR='" + DB_WX + "',WXFY='" + DB_FY + "',GZJY=" + iDB_GZ + ",SBJC=" + iDB_SBJC + ",GZTD=" + IDB_GZTD + ",WXJG=" + IDB_WXJG + ",REMARK='" + DB_Remark + "',LXDH='" + DB_LXDH + "',QM='" + DB_QM + "',LTime=getdate() WHERE ID=" + ID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                return ID;
                //MessageBox("", "维修单修改成功。");
            }
            else
            {
                MessageBox("", "错误：" + OP_Mode.strErrMsg);
                return 0;
            }
        }
        else
        {
            strSQL = "Insert into w_wxd (DWMC,WXDH,WXRY,WXSJ,YHMC,ZHMC,GZXX,WXNR,WXFY,GZJY,SBJC,GZTD,WXJG,REMARK,LXDH,QM,FLAG,DEL) ";
            strSQL += " values ('" + DB_DW + "',(SELECT 'SF' + CONVERT(VARCHAR(10), GETDATE(), 120) + '-' + RIGHT('0000' + CAST(ISNULL(MAX(RIGHT(WXDH, 4)), '0000') + 1 AS VARCHAR), 4) FROM w_wxd WHERE CONVERT(VARCHAR(10),GETDATE(),120) = CONVERT(VARCHAR(10), CTIME, 120)),'" + DB_WXRY + "','" + DB_WXSJ + "','" + DB_YH + "','" + DB_FLC + "','" + DB_GZ + "','" + DB_WX + "','" + DB_FY + "'," + iDB_GZ + ",";
            strSQL += iDB_SBJC + "," + IDB_GZTD + "," + IDB_WXJG + ",'" + DB_Remark + "','" + DB_LXDH + "','" + DB_QM + "',0,0) ";
            strSQL += " DECLARE @TNO int  SET @TNO = @@IDENTITY ";
            strSQL += " Select W_WXD.*,CNAME from W_WXD,S_USERINFO where WXRY = S_USERINFO.ID and W_WXD.id = @TNO";

            if (OP_Mode.SQLRUN(strSQL))
            {
                return Convert.ToInt32(OP_Mode.Dtv[0]["ID"]);
                // MessageBox("", "维修单保存成功。", "/BGGL/GCWXD.ASPX?ID=" + OP_Mode.Dtv[0]["ID"].ToString());
                //  LoadWXDByID(Convert.ToInt32(OP_Mode.Dtv[0]["ID"]));
            }
            else
            {
                MessageBox("", "错误：" + OP_Mode.strErrMsg);
                return 0;
            }
        }
    }

    /// <summary>
    /// 提交工程维修单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        try
        {
            if (Hidden_WXRY.Value != DefaultUser)
            {
                MessageBox("", "您不能提交别人的单据。");
                return;
            }
            else
            {
                int iid = Convert.ToInt32(Request["ID"]);

                if (SaveData(iid) > 0)
                {

                    if (Image_Sign.ImageUrl.Length > 0)
                    {
                        strSQL = "Update w_wxd set flag=1,LTime=getdate() where id=" + iid;
                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            SedMsg(iid);/// 给项目经理推送信息消息。
                            MessageBox("", "维修单提交成功！", "/BGGL/GCWXDLIST.ASPX");
                        }
                        else
                        {
                            MessageBox("", "错误：" + OP_Mode.strErrMsg);
                        }
                    }
                    else
                    {
                        MessageBox("", "该单据未签名，不允许提交。");
                    }
                }
                else
                {
                    MessageBox("", "数据保存失败，单据提交失败。");
                }
            }
        }
        catch
        {

        }
    }
    /// <summary>
    /// 给指定权限组的人发送消息
    /// </summary>
    /// <param name="IID">维保单的ID号码</param>
    private void SedMsg(int IID)
    {
        int iQXZ = 5;// 判断需要发送的群组的权限组ID

        string strSQL = "Select isnull(cOpenID,'') from S_YH_QXZ,S_USERINFO where QXZID=" + iQXZ.ToString() + " and USERID=id";

        string strUsers = string.Empty; // 需要发送的用户列表用 “|”分割；

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strUsers += OP_Mode.Dtv[i][0].ToString() + "|";
                }
            }
        }

        if (strUsers.Length > 0)
        {
            SendWorkMsgCard(strUsers, "维修报告单完成提示", " [" + UserNAME + "] 完成了一张维修报告单。", "ptweb.x76.com.cn/BGGL/GCWXD.ASPX?ID=" + IID + "&WeChat=0");
        }
    }

    /// <summary> 
    /// 字节流转换成图片 
    /// </summary> 
    /// <param name="byt">要转换的字节流</param> 
    /// <returns>转换得到的Image对象</returns> 
    public static Image BytToImg(byte[] byt)
    {
        MemoryStream ms = new MemoryStream(byt);
        Image img = Image.FromStream(ms);
        return img;
    }
    private string Base64StringToImage(string base64)
    {
        try
        {
            //Bitmap Imagebmp = new BitmapImage();
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream memStream = new MemoryStream(bytes);
            Bitmap b = new Bitmap(memStream);
            string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".png";//新文件名

            b.Save(Server.MapPath(@"/QMImage/" + newname));

            return newname;
        }
        catch (Exception ex)
        {
            // MessageBox("","Base64StringToImage 转换失败\nException：" + ex.Message);
            return string.Empty;
        }
    }
    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTP(string Base64Image)
    {
        string YImageName = Base64StringToImage(Base64Image);

        if (YImageName.Length > 0)
        {
            string URLpath = Server.MapPath("\\QMImage\\" + YImageName);
            /// 设置图片文字
            string strTemp = string.Empty;

            strTemp = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm");

            //添加水印
            System.Drawing.Image imgSrc = AddText(@URLpath, "50,50", "300, 100", strTemp);

            int width = imgSrc.Width;
            int height = imgSrc.Height;
            Bitmap bmp = new Bitmap(width, height);
            bmp.MakeTransparent(Color.Black);
            string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".png";//新文件名

            string imageName = "SY" + newname;
            string newpath = Server.MapPath(@"/QMImage/" + imageName);
            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //释放水印图片
            ///// 水印成功后，删除原图片
            if (File.Exists(URLpath)) { File.Delete(URLpath); }

            return "http://ptweb.x76.com.cn/QMImage/" + imageName;
        }
        else
        {
            return string.Empty;
        }



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

        int destHeight = 94;
        int destWidth = 320;

        if (height > destHeight || width > destWidth)
        {
            height = destHeight;
            width = destWidth;
        }

        Bitmap bmp = new Bitmap(width, height);

        Graphics graph = Graphics.FromImage(bmp);

        // 计算文字区域
        // 左上角
        string[] location = locationLeftTop.Split(',');
        float x1 = float.Parse(location[0]);
        float y1 = float.Parse(location[1]);
        x1 = float.Parse(Math.Round(Convert.ToDouble(width / 2), 0).ToString());
        y1 = float.Parse(Math.Round(Convert.ToDouble(height * 9 / 10), 0).ToString());
        // 右下角
        location = locationRightBottom.Split(',');
        float x2 = float.Parse(location[0]);
        float y2 = float.Parse(location[1]);

        x2 = float.Parse(Math.Round(Convert.ToDouble(width - width / 10), 0).ToString());
        y2 = float.Parse(Math.Round(Convert.ToDouble(height - height / 10), 0).ToString());

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
        // 设置白色背景
        graph.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));

        // 添加图片
        graph.DrawImage(img, 0, 0, width, height);

        graph.DrawString(text, font, new SolidBrush(Color.Black), x1, y1);

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
    /// 查看PDF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        int iid = Convert.ToInt32(Request["ID"]);
        if (iid > 0)
        {
            Response.Redirect("/BGGL/WXDPDF.ASPX?id=" + iid);
        }
    }
    /// <summary>
    /// 删除单据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        int iid = Convert.ToInt32(Request["ID"]);
        if (iid > 0)
        {
            if (Hidden_WXRY.Value != DefaultUser)
            {
                MessageBox("", "您不能删除其他人做的单据。");
            }
            else
            {
                string strSQL = "Update w_wxd set Del=1,ltime=getdate() where id=" + iid;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("", "指定单据删除成功。", "/BGGL/GCWXDList.aspx");
                }
            }
        }
    }
}