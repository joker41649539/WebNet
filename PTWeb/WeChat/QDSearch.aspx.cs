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
using System.Net;
using System.Text;
using Encoder = System.Drawing.Imaging.Encoder;

public partial class WeChat_QDSearch : PageBase
{
    #region pageParameters
    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.appId = WebConfigurationManager.AppSettings["AgentId"]; /// 企业微信ID
        this.timeStamp = getTimestamp();
        this.nonceStr = getNoncestr();
        this.signature = GenSignature_Woker(this.nonceStr, this.timeStamp);
        this.DataBind();

        if (!IsPostBack)
        {
            LoadQDList();
        }
    }

    private void LoadQDList()
    {
        string strTemp = string.Empty;
        string strSQL = string.Empty;

        // strSQL = "Select w_kq.*,CName,HeadUrl from w_kq,S_USERINFO where UserID=S_USERINFO.ID and userid=" + DefaultUser + " and w_kq.ctime between '" + System.DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00' order by w_kq.ctime desc";

        strSQL = "Select top 20 w_kq.*,CName,HeadUrl from w_kq,S_USERINFO where UserID=S_USERINFO.ID and userid=" + DefaultUser + " order by w_kq.ctime desc";

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
                        strTemp += "<img whidth='100%' src='" + OP_Mode.Dtv[i]["HeadUrl"].ToString() + "' />";
                    }

                    string StrQDFlag = OP_Mode.Dtv[i]["QDFlag"].ToString();

                    if (StrQDFlag == "维修开始")
                    {
                        strTemp += "      <span class='label label-danger label-sm'>维修开始</span>";
                    }
                    else if (StrQDFlag == "维修结束")
                    {
                        if (i + 1 < OP_Mode.Dtv.Count)
                        {
                            strTemp += "      <span class='label label-purple label-sm'>" + DiffHours(Convert.ToDateTime(OP_Mode.Dtv[i + 1]["CTime"]), Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"])).ToString("F2") + " 小时</span>";
                        }
                        strTemp += "      <span class='label label-danger label-sm'>维修结束</span>";
                    }
                    else if (StrQDFlag == "出差")
                    {
                        strTemp += "      <span class='label label-success label-sm'>出差</span>";
                    }
                    else if (StrQDFlag == "到达")
                    {
                        if (i + 1 < OP_Mode.Dtv.Count)
                        {
                            strTemp += "      <span class='label label-purple label-sm'>" + DiffHours(Convert.ToDateTime(OP_Mode.Dtv[i + 1]["CTime"]), Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"])).ToString("F2") + " 小时</span>";
                        }
                        strTemp += "      <span class='label label-success label-sm'>到达</span>";
                    }
                    else if (StrQDFlag == "施工")
                    {
                        strTemp += "      <span class='label label-warning label-sm'>施工</span>";
                    }
                    else if (StrQDFlag == "离场")
                    {
                        if (i + 1 < OP_Mode.Dtv.Count)
                        {
                            strTemp += "      <span class='label label-purple label-sm'>" + DiffHours(Convert.ToDateTime(OP_Mode.Dtv[i + 1]["CTime"]), Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"])).ToString("F2") + " 小时</span>";
                        }
                        strTemp += "      <span class='label label-warning label-sm'>离场</span>";
                    }
                    else if (StrQDFlag == "上班")
                    {
                        strTemp += "      <span class='label label-info label-sm'>上班</span>";
                    }
                    else if (StrQDFlag == "下班")
                    {
                        strTemp += "      <span class='label label-info label-sm'>下班</span>";
                    }

                    strTemp += "      <span class='label label-info label-sm'>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("HH:mm") + "</span>";
                    strTemp += "  </div>";
                    strTemp += "  <div class='widget-box transparent'>";
                    strTemp += "      <div class='widget-header widget-header-small'>";
                    strTemp += " <h5 class='smaller'>";

                    strTemp += "  <a target='_blank' href='/CWGL/MapTencent.aspx?iJD=" + OP_Mode.Dtv[i]["ZB_WD"] + "&iWD=" + OP_Mode.Dtv[i]["ZB_JD"] + "'><span class='grey'>" + OP_Mode.Dtv[i]["ZB_WZ"] + "<br/>" + OP_Mode.Dtv[i]["ZB_Name"] + "</span></a>";

                    strTemp += " </h5>";

                    strTemp += "          <span class='widget-toolbar'>";
                    strTemp += "              <a href='#' data-action='collapse'>";
                    strTemp += "                 <i class='icon-chevron-up'></i>";
                    strTemp += "             </a>";
                    strTemp += "         </span>";
                    strTemp += "     </div>";

                    strTemp += "     <div class='widget-body'>";
                    strTemp += "         <div class='widget-main'>";

                    if (i + 1 < OP_Mode.Dtv.Count)
                    {
                        if (OP_Mode.Dtv[i]["ZB_WZ"].ToString() != OP_Mode.Dtv[i + 1]["ZB_WZ"].ToString())
                        {
                            strTemp += "<input id=\"Button1\" class=\"btn btn-minier\" type=\"button\" onclick=\"init(" + OP_Mode.Dtv[i]["ZB_WD"] + "," + OP_Mode.Dtv[i]["ZB_JD"] + "," + OP_Mode.Dtv[i + 1]["ZB_WD"] + "," + OP_Mode.Dtv[i + 1]["ZB_JD"] + ")\" value=\"距上次签到距离\" />  ";
                        }
                    }
                    strTemp += OP_Mode.Dtv[i]["Remark"];
                    if (OP_Mode.Dtv[i]["Image1"].ToString().Length > 0)
                    {
                        strTemp += "             <a href='/KQImage/" + OP_Mode.Dtv[i]["Image1"].ToString() + "'><img class=\"img-rounded\" width=\"150\" src='/KQImage/" + OP_Mode.Dtv[i]["Image1"].ToString() + "' /></a>";
                    }
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

    protected void GridView_Bug_LinkButton1_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    private void SaveData()
    {
        string strJD = Hidden_JD.Value; //经度
        string strWD = Hidden_WD.Value; // 维度
        string strWZ = Hidden_WZ.Value;// 具体位置信息
        string strScreen = Hidden_Screen.Value; /// 设备分辨率

        string strMDD = TextBox_MDD.Text.Replace("'", "");
        string strRemark = TextBox_Remark.Text.Replace("'", "");

        string strName = Hidden_Name.Value; // 位置名称

        // 依据坐标地址，获取简单名称
        var client = new WebClient();
        client.Encoding = Encoding.UTF8;
        string TententMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";
        string strURL = "https://apis.map.qq.com/ws/geocoder/v1/?location=" + strWD + "," + strJD + "&key=" + TententMapKey + "&get_poi=0";
        var data = client.DownloadString(strURL);
        //"{\n    \"status\": 0,\n    \"message\": \"query ok\",\n    \"request_id\": \"77fd3d94-063d-453f-8e35-eeffa9a0eb8a\",\n    \"result\": {\n        \"location\": {\n            \"lat\": 31.85383,\n            \"lng\": 117.303457\n        },\n        \"address\": \"安徽省合肥市包河区巢湖路茶叶市场D区1号\",\n        \"formatted_addresses\": {\n            \"recommend\": \"包河区锦绣园(巢湖路西)\",\n            \"rough\": \"包河区锦绣园(巢湖路西)\"\n        },\n        \"address_component\": {\n            \"nation\": \"中国\",\n            \"province\": \"安徽省\",\n            \"city\": \"合肥市\",\n            \"district\": \"包河区\",\n            \"street\": \"巢湖路茶叶市场D区\",\n            \"street_number\": \"巢湖路茶叶市场D区1号\"\n        },\n        \"ad_info\": {\n            \"nation_code\": \"156\",\n            \"adcode\": \"340111\",\n            \"city_code\": \"156340100\",\n            \"name\": \"中国,安徽省,合肥市,包河区\",\n            \"location\": {\n                \"lat\": 31.793801,\n                \"lng\": 117.310133\n            },\n            \"nation\": \"中国\",\n            \"province\": \"安徽省\",\n            \"city\": \"合肥市\",\n            \"district\": \"包河区\"\n        },\n        \"address_reference\": {\n            \"business_area\": {\n                \"id\": \"14866831454685969030\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.8555,\n                    \"lng\": 117.303\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"famous_area\": {\n                \"id\": \"14866831454685969030\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.8555,\n                    \"lng\": 117.303\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"crossroad\": {\n                \"id\": \"258053\",\n                \"title\": \"马鞍山路/迎屏巷(路口)\",\n                \"location\": {\n                    \"lat\": 31.85514,\n                    \"lng\": 117.3011\n                },\n                \"_distance\": 260.5,\n                \"_dir_desc\": \"东南\"\n            },\n            \"town\": {\n                \"id\": \"340111002\",\n                \"title\": \"包公街道\",\n                \"location\": {\n                    \"lat\": 31.837959,\n                    \"lng\": 117.29163\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"street_number\": {\n                \"id\": \"475762619026716799429010\",\n                \"title\": \"巢湖路茶叶市场D区1号\",\n                \"location\": {\n                    \"lat\": 31.853847,\n                    \"lng\": 117.303718\n                },\n                \"_distance\": 24.8,\n                \"_dir_desc\": \"西\"\n            },\n            \"street\": {\n                \"id\": \"9103225048745597629\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.842798,\n                    \"lng\": 117.32119\n                },\n                \"_distance\": 49.8,\n                \"_dir_desc\": \"西\"\n            },\n            \"landmark_l2\": {\n                \"id\": \"11384582867635718374\",\n                \"title\": \"锦绣园\",\n                \"location\": {\n                    \"lat\": 31.853819,\n                    \"lng\": 117.30229\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            }\n        }\n    }\n}"

        string temp = data.Substring(data.IndexOf("rough") + 9);

        strName = data.Substring(data.IndexOf("rough") + 9, temp.IndexOf('"'));
        // 依据坐标地址，获取简单名称 结束

        //string Image1 = UploadTP(FileUpload_TP);

        string Image1 = String.Empty;

        int iFilCount = Request.Files.Count;

        for (int i = 0; i < iFilCount; i++)
        {
            HttpPostedFile f = Request.Files[i];
            Image1 += UploadTPs(f);
        }

        if (strJD.Length + strWD.Length + strWZ.Length < 1)
        { /// 判断是否获取到位置信息
            MessageBox("", "位置信息获取失败。请重试。");
            return;
        }
        else
        {
            string strSQL = "Insert into W_KQ (Userid,ZB_JD,ZB_WD,ZB_WZ,CTIME,Screen,Image1,MDD,Remark,ZB_Name) values (" + DefaultUser + "," + strJD + "," + strWD + ",'" + strWZ + "',getdate(),'" + strScreen + "','" + Image1 + "','" + strMDD + "','" + strRemark + "','" + strName + "')";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "签到成功。", "/WeChat/QDSearch.aspx");
            }
            else
            {
                MessageBox("", "签到失败。错误：<br>" + OP_Mode.strErrMsg);
                return;
            }
        }

    }

    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTPs(HttpPostedFile fileName)
    {
        string name = fileName.FileName;//获取文件名称

        if (name.Length > 0)
        {
            int i = fileName.ContentLength;   //得到上传文件大小

            int index = name.LastIndexOf(".");

            string lastName = name.Substring(index, name.Length - index);//文件后缀

            string newname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + lastName;//新文件名
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
                        fileName.SaveAs(path);//保存到服务器上	 小于1M的图片不进行压缩处理
                    }
                    else
                    { /// 大于1M的图片文件压缩后上传
                        ystp(fileName, "~/KQImage/" + newname);
                    }

                    /// 设置图片文字
                    string strTemp = string.Empty;
                    if (Hidden_WZ.Value.Length > 0)
                    {
                        strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\r\n" + Hidden_WZ.Value;
                    }
                    else
                    {
                        strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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
        return string.Empty;
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

                string newname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + lastName;//新文件名
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
                        if (Hidden_WZ.Value.Length > 0)
                        {
                            strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\r\n" + Hidden_WZ.Value;
                        }
                        else
                        {
                            strTemp = UserNAME + "\r\n" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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
    public double DiffHours(DateTime startTime, DateTime endTime)
    {
        TimeSpan hoursSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
        return hoursSpan.TotalHours;
    }
}