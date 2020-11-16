using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class School_AddInfo_Add : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
        }
    }


    /// <summary>
    /// 读取原始数据
    /// </summary>
    private void LoadDefaultData()
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
        {
            //int id = Convert.ToInt32(Request.QueryString["ID"]);

            //string strSQL;

            //strSQL = "Select * from FF_TPNEWS WHERE ID=" + id.ToString();

            //OP_Mode.SQLRUN(strSQL);

            //if (OP_Mode.Dtv.Count > 0)
            //{
            //    //this.TextBox_Title.Text = OP_Mode.Dtv[0]["CBT"].ToString();
            //    //this.content1.Value = OP_Mode.Dtv[0]["TCONTENT"].ToString();
            //    //this.url1.Value = OP_Mode.Dtv[0]["CTPLJ"].ToString().Replace(DefaultWebURL, "");
            //    //this.DropDownList1.SelectedValue = OP_Mode.Dtv[0]["ICLASSID"].ToString();
            //}
        }
        else
        {
            GridView_ZY_TextBox_TSTime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;


            string weekstr = DateTime.Now.DayOfWeek.ToString();
            switch (weekstr)
            {
                case "Monday": weekstr = "星期一"; break;
                case "Tuesday": weekstr = "星期二"; break;
                case "Wednesday": weekstr = "星期三"; break;
                case "Thursday": weekstr = "星期四"; break;
                case "Friday": weekstr = "星期五"; break;
                case "Saturday": weekstr = "星期六"; break;
                case "Sunday": weekstr = "星期日"; break;
            }

            if (weekstr == "星期五")
            {
                DateTime TTime;

                TTime = DateTime.Now.AddDays(2);

                GridView_ZY_TextBox_TETime.Text = TTime.Year + "-" + TTime.Month + "-" + TTime.Day;
            }
            else
            {
                GridView_ZY_TextBox_TETime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            }

            LoadClass();
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_ZY_LinkButton1_Click(object sender, EventArgs e)
    {
        /// 信息类别

        string DB_01 = this.DropDownList_Class.SelectedValue.Trim().Replace("'", "\"");

        /// 信息内容

        string DB_02 = this.GridView_ZY_TextBox_NContent.Text.Trim().Replace("'", "\"");

        /// 开始时间

        string DB_03 = this.GridView_ZY_TextBox_TSTime.Text.Trim().Replace("'", "\"");

        /// 结束时间

        string DB_04 = this.GridView_ZY_TextBox_TETime.Text.Trim().Replace("'", "\"");

        /// 排序

        string DB_05 = this.GridView_ZY_TextBox_IPX.Text.Trim().Replace("'", "\"");

        /// URL

        string DB_Url = this.TextBox_URL.Text.Trim().Replace("'", "\"");

        string strSQL;


        /// 整体拆分
        if (DB_02.IndexOf("的家长") > -1)
        {
            string db_YY, db_SX, db_YW;

            int t_S_YW = DB_02.IndexOf("语文：");

            if (DB_02.IndexOf("语文:") > -1)
            {
                t_S_YW = DB_02.IndexOf("语文:");
            }

            int t_S_SX = DB_02.IndexOf("数学：");

            if (DB_02.IndexOf("数学:") > -1)
            {
                t_S_SX = DB_02.IndexOf("数学:");
            }

            int t_S_YY = DB_02.IndexOf("英语：");

            if (DB_02.IndexOf("英语:") > -1)
            {
                t_S_YY = DB_02.IndexOf("英语:");
            }

            int t_E_YW, t_E_SX, t_E_YY;

            // 作业顺序，语文、数学、英语
            if (t_S_YW < t_S_SX && t_S_YW < t_S_YY && t_S_SX < t_S_YY)
            {
                t_E_YW = t_S_SX;
                t_E_SX = t_S_YY;
                t_E_YY = DB_02.Length;
            }// 语文、英语、数学
            else if (t_S_YW < t_S_SX && t_S_YW < t_S_YY && t_S_SX < t_S_YY)
            {
                t_E_YW = t_S_YY;
                t_E_YY = t_S_SX;
                t_E_SX = DB_02.Length;
            }// 数学、语文、英语
            else if (t_S_YW < t_S_SX && t_S_YW < t_S_YY && t_S_SX < t_S_YY)
            {
                t_E_SX = t_S_YW;
                t_E_YW = t_S_YY;
                t_E_YY = DB_02.Length;
            }// 数学、英语、语文
            else if (t_S_YW < t_S_SX && t_S_YW < t_S_YY && t_S_SX < t_S_YY)
            {
                t_E_SX = t_S_YY;
                t_E_YY = t_S_YW;
                t_E_YW = DB_02.Length;
            }// 英语、语文、数学
            else if (t_S_YW < t_S_SX && t_S_YW < t_S_YY && t_S_SX < t_S_YY)
            {
                t_E_YY = t_S_YW;
                t_E_YW = t_S_SX;
                t_E_SX = DB_02.Length;
            }// 英语、数学、语文
            else if (t_S_YW < t_S_SX && t_S_YW < t_S_YY && t_S_SX < t_S_YY)
            {
                t_E_YY = t_S_SX;
                t_E_SX = t_S_YW;
                t_E_YW = DB_02.Length;
            }
            else
            {
                t_E_YW = 0;
                t_E_SX = 0;
                t_E_YY = 0;
            }

            db_YW = DB_02.Substring(t_S_YW + 3, t_E_YW - t_S_YW - 3);
            db_SX = DB_02.Substring(t_S_SX + 3, t_E_SX - t_S_SX - 3);
            db_YY = DB_02.Substring(t_S_YY + 3, t_E_YY - t_S_YY - 3);

            strSQL = string.Empty;

            db_YW = db_YW.Replace(";", "；<br>");
            db_YW = db_YW.Replace("；", "；<br>");

            db_SX = db_SX.Replace(";", "；<br>");
            db_SX = db_SX.Replace("；", "；<br>");

            db_YY = db_YY.Replace(";", "；<br>");
            db_YY = db_YY.Replace("；", "；<br>");

            if (db_YW.Length > 0)
            {
                strSQL = " Insert into School ( IClass,IFlag, NContent, TSTime, TETime, IPX,CTIME,LTIME) VALUES (1,1,'" + db_YW + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";
            }

            if (db_YW.Length > 0)
            {
                strSQL += " Insert into School ( IClass,IFlag, NContent, TSTime, TETime, IPX,CTIME,LTIME) VALUES (2,1,'" + db_SX + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";
            }

            if (db_YW.Length > 0)
            {
                strSQL += " Insert into School ( IClass,IFlag, NContent, TSTime, TETime, IPX,CTIME,LTIME) VALUES (3,1,'" + db_YY + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";
            }

        }
        else
        {
            DB_02 = DB_02.Replace(";", ";<br>");
            DB_02 = DB_02.Replace("；", ";<br>");

            if (DB_Url.Trim().Length == 0)
            {
                DB_Url = "#";
            }

            if (FileUpload_TP.PostedFile.FileName.Length > 0)
            {
                string TpNmae = UploadTP();
                if (TpNmae.Length > 0)
                {
                    strSQL = "Insert into School ( IClass,IFlag,NUrl, NContent, TSTime, TETime, IPX,CTIME,LTIME) VALUES ('" + DB_01 + "',1,'" + TpNmae + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";
                }
                else
                {
                    MessageBox("", "图片信息上传失败！<br/>错误：" + OP_Mode.strErrMsg);

                    return;
                }
            }
            else
            {
                strSQL = "Insert into School ( IClass,IFlag,NUrl, NContent, TSTime, TETime, IPX,CTIME,LTIME) VALUES ('" + DB_01 + "',1,'" + DB_Url + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";
            }
        }
        if (OP_Mode.SQLRUN(strSQL))

        {
            if (FileUpload_TP.PostedFile.FileName.Length > 0)
            {
                UploadTP();
            }
            MessageBox("", "信息添加信息添加成功!");

        }

        else

        {

            MessageBox("", "信息添加信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }
    }

    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTP()
    {
        string name = FileUpload_TP.PostedFile.FileName;//获取文件名称

        if (name.Length > 0)
        {
            if (FileUpload_TP.HasFile)
            {
                int i = this.FileUpload_TP.PostedFile.ContentLength;   //得到上传文件大小

                int index = name.LastIndexOf(".");

                string lastName = name.Substring(index, name.Length - index);//文件后缀

                string newname = DateTime.Now.ToString("yyyyMMddhhmmss") + lastName;//新文件名
                                                                                    //  string newname = "12345" + lastName;
                string path = Server.MapPath("~/upload/" + newname);

                string URLpath = Server.MapPath("\\upload\\" + newname);

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
                            FileUpload_TP.PostedFile.SaveAs(path);//保存到服务器上	 小于1M的图片不进行压缩处理
                        }
                        else
                        { /// 大于1M的图片文件压缩后上传
                            ystp(FileUpload_TP.PostedFile, "~/upload/" + newname);
                        }

                        return "/upload/" + newname;

                        //if (OP_Mode.SQLRUN(strSQL))
                        //{
                        //    /// MessageBox("", "图片文件上传成功！");
                        //    return true;
                        //}
                        //else
                        //{
                        //    //MessageBox("", "服务器正忙，请稍后再试！");
                        //    return false;
                        //}
                    }
                    catch
                    {
                        // MessageBox("", "服务器正忙，请稍后再试！");
                        return string.Empty;
                    }

                }

            }
        }
        return string.Empty;

    }

    /// <summary>
    /// 加载用户可选择的信息类别表
    /// </summary>
    private void LoadClass()
    {
        string strSQL = string.Empty;

        strSQL = "Select CLASSID,NName from School_Class_User,School_Class where USERID=" + DefaultUser + " and CLASSID=School_Class.ID ORDER BY IPX DESC";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                this.DropDownList_Class.DataSource = OP_Mode.Dtv;
                this.DropDownList_Class.DataTextField = "NName";
                this.DropDownList_Class.DataValueField = "CLASSID";
                this.DropDownList_Class.DataBind();

                this.DropDownList_Class.SelectedIndex = 0;
            }
        }

    }


    #region 压缩图片

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

    #endregion 压缩图片
}