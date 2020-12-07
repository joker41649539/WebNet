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
                string strSQL = "Select * from w_BXD1 where ID=" + IID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        Label_No.Text = OP_Mode.Dtv[0]["BXDH"].ToString();
                        TextBox_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                        if (OP_Mode.Dtv[0]["FLAG"].ToString() == "0")
                        {
                            Label_Flag.Text = "待提交";
                            Label_Flag.ForeColor = Color.Green;
                        }
                        else if (OP_Mode.Dtv[0]["FLAG"].ToString() == "1")
                        {
                            Label_Flag.Text = "已完成";
                            Label_Flag.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                Label_No.Text = "等待生成编号";
            }
        }
        catch
        {
            Label_No.Text = "待生成编号";
        }
        /// 依据选择显示文本框
        ShowTextBox();

        Label_CName.Text = UserNAME;
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
            TCFDD.Visible = true;
            TDDDD.Visible = true;
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
    private void AddImagesShow(String imageName)
    {
        if (imageName.Length > 0)
        {
            string newpath = "/BxImages/" + imageName;
            UpdateImages.InnerHtml += "<img src=\"" + newpath + "\" style =\"height:40px;\" />";
        }

        WellList.InnerHtml += " <div class=\"well\">";
        WellList.InnerHtml += "   <h4 class=\"green smaller lighter\">" + DropDownList1.SelectedValue + "</h4>";
        WellList.InnerHtml += "    2020-12-03 40 元 ";
        WellList.InnerHtml += "   <h6 class=\"red smaller lighter\"><a href=\"#\">删 除</a></h6>";
        WellList.InnerHtml += " </div>";
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
            TCFDD.Visible = true;
            TDDDD.Visible = true;
            if (TextBox_MC.Text.Length <= 0)
            {
                i = i + 1;
                ErrMsg += i + "、物资名称必须填写。<br>";
            }
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

                    Label_No.Text = OP_Mode.Dtv[0]["BXDH"].ToString();

                    /// 插入明细数据
                  //  strSQL = "Insert into w_bxd2 (BXDH,) values ()";
                }
                else
                {
                    MessageBox("", "报销单保存错误：<br/>" + OP_Mode.strErrMsg);
                    rValue = false;
                }

                /// 
                //AddImagesShow(imageName);

            }
            else
            {// 
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