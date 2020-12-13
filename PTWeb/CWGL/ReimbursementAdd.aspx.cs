using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
        }
    }

    /// <summary>
    /// 加载基础数据
    /// </summary>

    private void LoadDefaultData()
    {
        TextBoxSTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        try
        {
            int IID = Convert.ToInt32(Request["ID"]);
            if (IID > 0)
            {
                string strSQL = "Select UserName,BXLX,(Select sum(BXJE) from W_BXD2 where BXDH=W_BXD1.BXDH ) ZJE,W_BXD1.Remark,W_BXD1.FLAG,W_BXD2.* from w_BXD1,W_BXD2 where W_BXD1.BXDH=W_BXD2.BXDH and W_BXD1.id=" + IID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        bool bDel = true;
                        Label_No.Text = OP_Mode.Dtv[0]["BXDH"].ToString();
                        TextBox_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                        if (OP_Mode.Dtv[0]["FLAG"].ToString() == "0")
                        {
                            Label_Flag.Text = "待提交";
                            Label_Flag.ForeColor = Color.Green;
                        }
                        else if (OP_Mode.Dtv[0]["FLAG"].ToString() == "1")
                        {
                            bDel = false;
                            Label_Flag.Text = "已完成";
                            Label_Flag.ForeColor = Color.Red;
                        }

                        RadioButtonList1.SelectedValue = OP_Mode.Dtv[0]["BXLX"].ToString();
                        RadioChanged();

                        Label_CName.Text = OP_Mode.Dtv[0]["UserName"].ToString();
                        Label_Sumje.Text = OP_Mode.Dtv[0]["ZJE"].ToString();

                        if (Convert.ToDouble(OP_Mode.Dtv[0]["ZJE"]) > 0)
                        {
                            RadioButtonList1.Enabled = false;
                            TextBox_Remark.Enabled = false;
                        }
                        // 生成明细
                        for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                        {
                            AddImagesShow(OP_Mode.Dtv[i]["Image"].ToString(), Convert.ToDateTime(OP_Mode.Dtv[i]["Occurrence"]).ToString("yyyy-MM-dd"), OP_Mode.Dtv[i]["KZXM"].ToString(), OP_Mode.Dtv[i]["TXR"].ToString(), OP_Mode.Dtv[i]["MC"].ToString(), OP_Mode.Dtv[i]["Becity"].ToString(), OP_Mode.Dtv[i]["Arrival"].ToString(), Convert.ToDouble(OP_Mode.Dtv[i]["BXJE"]), OP_Mode.Dtv[i]["Remark"].ToString(), Convert.ToDouble(OP_Mode.Dtv[i]["BreakFirst"]), Convert.ToDouble(OP_Mode.Dtv[i]["ZCBZ"]), Convert.ToDouble(OP_Mode.Dtv[i]["WCBZ"]), Convert.ToDouble(OP_Mode.Dtv[i]["ZSBZ"]), Convert.ToDouble(OP_Mode.Dtv[i]["DRZS"]), Convert.ToInt32(OP_Mode.Dtv[i]["ID"]), bDel);
                        }
                    }
                }
            }
            else
            {
                Label_No.Text = "等待生成编号";
                Label_CName.Text = UserNAME;
            }
        }
        catch
        {
            Label_No.Text = "待生成编号";
        }
        /// 依据选择显示文本框
        ShowTextBox();
    }

    /// <summary>
    /// 依据条件显示可用的TextBox
    /// </summary>
    private void ShowTextBox()
    {
        if (DropDownList1.SelectedValue == "交通费" || DropDownList1.SelectedValue == "运输费")
        {
            TBreakfirst.Visible = false;
            TZC.Visible = false;
            TWC.Visible = false;
            TZS.Visible = false;
            TDRZS.Visible = false;
            TMC.Visible = false;
            TCFDD.Visible = true;
            TDDDD.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "补助")
        {
            TBreakfirst.Visible = true;
            TZC.Visible = true;
            TWC.Visible = true;
            TZS.Visible = true;
            TDRZS.Visible = true;
            TMC.Visible = false;
            TCFDD.Visible = false;
            TDDDD.Visible = false;
        }
        else if (DropDownList1.SelectedValue == "采购物资")
        {
            TBreakfirst.Visible = false;
            TZC.Visible = false;
            TWC.Visible = false;
            TZS.Visible = false;
            TDRZS.Visible = false;
            TMC.Visible = true;
            TCFDD.Visible = false;
            TDDDD.Visible = false;
        }
        else
        {
            TBreakfirst.Visible = false;
            TZC.Visible = false;
            TWC.Visible = false;
            TZS.Visible = false;
            TDRZS.Visible = false;
            TMC.Visible = false;
            TCFDD.Visible = false;
            TDDDD.Visible = false;
        }
    }
    /// <summary>
    ///  
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioChanged();
    }

    private void RadioChanged()
    {
        if (RadioButtonList1.SelectedValue == "0")
        {
            LabelRadioText.InnerText = "施工编号：";
        }
        else if (RadioButtonList1.SelectedValue == "1")
        {
            LabelRadioText.InnerText = "事由：";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            LabelRadioText.InnerText = "事由：";
        }

    }

    /// <summary>
    /// 添加图片显示
    /// </summary>
    private void AddImagesShow(String imageName, String strSTime, String strKZXM, String strTXR, String strMC, String strBecity, String strArrival, Double strNum, String strRemark2, double db_Bk, double Db_ZC, double DB_WC, double Db_ZS, double DB_DRZS, int MXID, bool del)
    {
        WellList.InnerHtml += " <div class=\"well\">";
        WellList.InnerHtml += "   <h4 class=\"green smaller lighter\">" + DropDownList1.SelectedValue + "</h4>";
        WellList.InnerHtml += " <a href='" + imageName + "'><img src=\"" + imageName + "\" style =\"height:40px;\" /></a>";
        WellList.InnerHtml += " 发生时间：" + strSTime + " ";

        if (DropDownList1.SelectedValue == "交通费" || DropDownList1.SelectedValue == "运输费")
        {
            WellList.InnerHtml += " 路程：" + strBecity.ToString() + " - " + strArrival.ToString() + " ";
        }
        else if (DropDownList1.SelectedValue == "补助")
        {
            if (db_Bk > 0)
            {
                WellList.InnerHtml += " 早餐补助：" + db_Bk + " ";
            }
            if (Db_ZC > 0)
            {
                WellList.InnerHtml += " 午餐补助：" + Db_ZC + " ";
            }
            if (DB_WC > 0)
            {
                WellList.InnerHtml += " 晚餐补助：" + DB_WC + " ";
            }
            if (Db_ZS > 0)
            {
                WellList.InnerHtml += " 住宿补助：" + Db_ZS + " ";
            }
            if (DB_DRZS > 0)
            {
                WellList.InnerHtml += " 多人住宿：" + DB_DRZS + " ";
            }
            if (strTXR.Length > 0)
            {
                WellList.InnerHtml += "  同行人：" + strTXR + " ";
            }
        }
        else if (DropDownList1.SelectedValue == "采购物资")
        {
            WellList.InnerHtml += " 货物名称：" + strMC + " ";
            WellList.InnerHtml += " 路径：" + strBecity + "-" + strArrival + " ";
        }
        WellList.InnerHtml += " <br/>总金额：" + strNum + " ";
        if (strRemark2.Length > 0)
        {
            WellList.InnerHtml += " 备注说明：" + strRemark2 + " ";
        }
        if (del)
        {
            WellList.InnerHtml += "   <a href=\"\\CWGL\\BXDMXDel.aspx?MXID=" + MXID + "&ID=" + Label_No.Text + "\"><h3 class=\"red smaller lighter\">删 除</h3></a>";
        }
        WellList.InnerHtml += " </div>";
    }

    /// <summary>
    /// 清除文本框
    /// </summary>
    private void ClearTextbox()
    {
        TextBoxSTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        TextBox_Breakfirst.Text = string.Empty;
        TextBox_ZC.Text = string.Empty;
        TextBox_WC.Text = string.Empty;
        TextBox_ZS.Text = string.Empty;
        TextBox_DRZS.Text = string.Empty;
        TextBox_TXR.Text = string.Empty;
        TextBox_MC.Text = string.Empty;
        TextBox_Becity.Text = string.Empty;
        TextBox_Arrival.Text = string.Empty;
        TextBox_Num.Text = string.Empty;
        TextBox_Remark2.Text = string.Empty;
    }

    /// <summary>
    /// 添加下一条
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {///上传图片，并且显示出来

        if (SaveData())
        {

        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    private bool SaveData()
    {
        bool rValue = false;
        /// 1、输入判断
        string ErrMsg = string.Empty;
        int i = 0;
        if (Label_CName.Text != UserNAME)
        {
            i = i + 1;
            ErrMsg += i + "、您只能编辑您自己的单据。<br>";
        }
        if (Label_Flag.Text != "待提交")
        {
            i = i + 1;
            ErrMsg += i + "、已经提交的单据是不允许保存的。<br>";
        }

        if (ErrMsg.Length == 0)
        {
            if (DropDownList1.SelectedValue == "交通费" || DropDownList1.SelectedValue == "运输费")
            {
                TCFDD.Visible = true;
                TDDDD.Visible = true;
                if (TextBox_Becity.Text.Length <= 0)
                {
                    i = i + 1;
                    ErrMsg += i + "、出发地点必须填写。<br>";
                }
                if (TextBox_Arrival.Text.Length <= 0)
                {
                    i = i + 1;
                    ErrMsg += i + "、到达地点必须填写。<br>";
                }
            }
            else if (DropDownList1.SelectedValue == "补助")
            {
                TBreakfirst.Visible = true;
                TZC.Visible = true;
                TWC.Visible = true;
                TZS.Visible = true;
                TDRZS.Visible = true;
                if (TextBox_Breakfirst.Text.Length <= 0 && TextBox_ZC.Text.Length <= 0 && TextBox_WC.Text.Length <= 0 && TextBox_ZS.Text.Length <= 0 && TextBox_DRZS.Text.Length <= 0)
                {
                    i = i + 1;
                    ErrMsg += i + "、早餐、晚餐、住宿或者多人住宿补助至少选填一个。<br>";
                }
                if (TextBox_DRZS.Text.Length > 0 && TextBox_TXR.Text.Length <= 0)
                {
                    i = i + 1;
                    ErrMsg += i + "、多人住宿必须填写同行人。<br>";
                }
            }
            else if (DropDownList1.SelectedValue == "采购物资")
            {
                TMC.Visible = true;
                if (TextBox_MC.Text.Length <= 0)
                {
                    i = i + 1;
                    ErrMsg += i + "、物资名称必须填写。<br>";
                }
            }

            if (TextBox_Num.Text.Length <= 0)
            {
                i = i + 1;
                ErrMsg += i + "、报销金额必须填写。<br>";
            }
            else
            {
                if (Convert.ToDouble(TextBox_Num.Text) <= 0)
                {
                    i = i + 1;
                    ErrMsg += i + "、报销金额必须大于0。<br>";
                }
            }
        }

        if (ErrMsg.Length > 0)
        {
            MessageBox("", ErrMsg);
            rValue = false;
        }
        else
        {
            rValue = true;
        }

        if (rValue)
        {
            String imageName = UploadTP(FileUpload1);

            if (imageName.Length > 0)
            {/// 图片上传成功

                string strSQL = string.Empty;
                int newID = 0;
                if (Label_No.Text.Length == "BXD2020-12-01-0001".Length)
                {/// 更新主表数据
                    strSQL = " Update w_bxd1 set BXLX='" + RadioButtonList1.SelectedValue + "',Remark='" + TextBox_Remark.Text.Replace("'", "") + "',LTIME=getdate() where BXDH='" + Label_No.Text + "'";

                    strSQL += " SELECT * FROM w_bxd1 WHERE BXDH='" + Label_No.Text + "'";
                }
                else
                {/// 插入数据 
                    //1、插入主表数据
                    strSQL = " Insert into w_bxd1 (UserName,BXDH,FLAG,BXLX,Remark) values ('" + UserNAME + "',(SELECT  'BXD'+CONVERT(VARCHAR(10),GETDATE(),120) + '-' + RIGHT('0000' + CAST(ISNULL(MAX(RIGHT(BXDH,4)),'0000') + 1 AS VARCHAR),4) FROM w_bxd1 WHERE CONVERT(VARCHAR(10),GETDATE(),120) = CONVERT(VARCHAR(10),CTIME,120)),0," + RadioButtonList1.SelectedValue + ",'" + TextBox_Remark.Text.Replace("'", "") + "')";

                    /// 查询主表数据（用来显示新插入的报销单编号
                    strSQL += " SELECT * FROM w_bxd1 WHERE ID=SCOPE_IDENTITY()";
                }

                /// 运行脚本
                if (OP_Mode.SQLRUN(strSQL))
                {
                    rValue = true;
                    newID = Convert.ToInt32(OP_Mode.Dtv[0]["ID"]);
                    double db_Bk, Db_ZC, DB_WC, Db_ZS, DB_DRZS;

                    if (TextBox_Breakfirst.Text.Replace("'", "").Length == 0)
                    {
                        db_Bk = 0;
                    }
                    else
                    {
                        db_Bk = Convert.ToDouble(TextBox_Breakfirst.Text.Replace("'", ""));
                    }
                    if (TextBox_ZC.Text.Replace("'", "").Length == 0)
                    {
                        Db_ZC = 0;
                    }
                    else
                    {
                        Db_ZC = Convert.ToDouble(TextBox_ZC.Text.Replace("'", ""));
                    }

                    if (TextBox_WC.Text.Replace("'", "").Length == 0)
                    {
                        DB_WC = 0;
                    }
                    else
                    {
                        DB_WC = Convert.ToDouble(TextBox_WC.Text.Replace("'", ""));
                    }
                    if (TextBox_ZS.Text.Replace("'", "").Length == 0)
                    {
                        Db_ZS = 0;
                    }
                    else
                    {
                        Db_ZS = Convert.ToDouble(TextBox_ZS.Text.Replace("'", ""));
                    }
                    if (TextBox_DRZS.Text.Replace("'", "").Length == 0)
                    {
                        DB_DRZS = 0;
                    }
                    else
                    {
                        DB_DRZS = Convert.ToDouble(TextBox_DRZS.Text.Replace("'", ""));
                    }

                    string strKZXM, strSTime, strTXR, strMC, strBecity, strArrival, strRemark2;
                    double strNum;
                    strKZXM = DropDownList1.SelectedValue.Replace("'", "");// 报销项目
                    strSTime = TextBoxSTime.Text.Replace("'", "");//报销时间
                    strTXR = TextBox_TXR.Text.Replace("'", "");// 同行人
                    strMC = TextBox_MC.Text.Replace("'", "");// 名称
                    strBecity = TextBox_Becity.Text.Replace("'", "");// 出发地点
                    strArrival = TextBox_Arrival.Text.Replace("'", "");//到达地点
                    strNum = Convert.ToDouble(TextBox_Num.Text);// 报销金额
                    strRemark2 = TextBox_Remark2.Text.Replace("'", "");//报销说明信息

                    Label_No.Text = OP_Mode.Dtv[0]["BXDH"].ToString();// 订单号
                    imageName = "\\BxImages\\" + imageName;
                    /// 插入明细数据
                    strSQL = "Insert into w_bxd2 (BXDH,KZXM,Occurrence,BreakFirst,ZCBZ,WCBZ,ZSBZ,DRZS,TXR,MC,Becity,Arrival,BXJE,Remark,Image)";
                    strSQL += " values ('" + Label_No.Text.Replace("'", "") + "','" + strKZXM + "','" + strSTime + "',";
                    strSQL += " " + db_Bk + "," + Db_ZC + "," + DB_WC + ", ";
                    strSQL += " " + Db_ZS + "," + DB_DRZS + ",'" + strTXR + "',";
                    strSQL += " '" + strMC + "','" + strBecity + "','" + strArrival + "'," + strNum + ",'" + strRemark2 + "','" + imageName + "')";
                    strSQL += " SELECT * FROM w_bxd2 WHERE ID=SCOPE_IDENTITY()";

                    if (OP_Mode.SQLRUN(strSQL))
                    {
                        AddImagesShow(imageName, strSTime, strKZXM, strTXR, strMC, strBecity, strArrival, strNum, strRemark2, db_Bk, Db_ZC, DB_WC, Db_ZS, DB_DRZS, Convert.ToInt32(OP_Mode.Dtv[0]["ID"]), true);
                        ClearTextbox();
                        Label_Sumje.Text = (Convert.ToDouble(Label_Sumje.Text) + strNum).ToString();
                    }
                    else
                    {
                        MessageBox("", "报销单明细保存错误：<br/>" + strSQL);
                        rValue = false;
                    }
                }
                else
                {
                    MessageBox("", "报销单保存错误：<br/>" + OP_Mode.strErrMsg);
                    rValue = false;
                }
            }
            else
            {// 
                MessageBox("", "必须上传图片信息。");
                rValue = false;
            }
        }

        return rValue;
    }

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
                string path = Server.MapPath("~/BxImages/" + newname);

                string URLpath = Server.MapPath("\\BxImages\\" + newname);

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
                            ystp(fileName.PostedFile, "~/BxImages/" + newname);
                        }

                        //string imageName = "BX" + newname;
                        //string newpath = Server.MapPath(@"/BxImages/" + imageName);

                        return newname;
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
    /// 单选框选择变化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowTextBox();
    }
}