using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            if (!QXBool(38, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有填写报销单的权限。", Defaut_QX_URL);
                return;
            }
            else
            {
                LoadDefaultData();
            }
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

            HyperLink1.NavigateUrl = "/CWGL/SearchQD.aspx?BXDID=" + IID;
            if (IID > 0)
            {
                string strSQL = "Select UserName,BXLX,SKR,(Select sum(BXJE) from W_BXD2 where BXDH=W_BXD1.BXDH ) ZJE,W_BXD1.Remark RemarkSum,W_BXD1.FLAG,(Select top 1 Remark from w_examine where djbh=W_BXD1.BXDH and ireturn<>0 order by ltime desc) ReturnMSG,W_BXD2.* from w_BXD1,W_BXD2 where W_BXD1.BXDH=W_BXD2.BXDH and W_BXD1.id=" + IID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        bool bDel = true;
                        Label_No.Text = OP_Mode.Dtv[0]["BXDH"].ToString();
                        TextBox_Remark.Text = OP_Mode.Dtv[0]["RemarkSum"].ToString();

                        TextBox_Cname.Text = OP_Mode.Dtv[0]["SKR"].ToString();

                        if (OP_Mode.Dtv[0]["ReturnMSG"].ToString().Length > 0)
                        { /// 被退回单据
                            ReturnMsg.InnerHtml += " <div class=\"well\">";
                            ReturnMsg.InnerHtml += "   <h4 class=\"red smaller lighter\">单据被退回</h4>";
                            ReturnMsg.InnerHtml += " <h2>" + OP_Mode.Dtv[0]["ReturnMSG"].ToString() + "</h2>";
                            ReturnMsg.InnerHtml += " </div>";
                        }

                        Label_Flag.Text = FlagToName(Convert.ToInt32(OP_Mode.Dtv[0]["FLAG"]));

                        if (Convert.ToInt32(OP_Mode.Dtv[0]["FLAG"]) > 0)
                        {
                            TextBox_Remark.Enabled = false;
                        }
                        else
                        {
                            TextBox_Remark.Enabled = true;
                        }

                        if (OP_Mode.Dtv[0]["FLAG"].ToString() == "0")
                        {
                            Label_Flag.ForeColor = Color.Green;
                        }
                        else if (OP_Mode.Dtv[0]["FLAG"].ToString() == "1")
                        {
                            bDel = false;
                            Label_Flag.ForeColor = Color.Red;
                        }
                        else
                        {
                            bDel = false;
                        }

                        RadioButtonList1.SelectedValue = OP_Mode.Dtv[0]["BXLX"].ToString();
                        RadioChanged();

                        Label_CName.Text = OP_Mode.Dtv[0]["UserName"].ToString();
                        Label_Sumje.Text = OP_Mode.Dtv[0]["ZJE"].ToString();

                        //if (Convert.ToDouble(OP_Mode.Dtv[0]["ZJE"]) > 0)
                        //{/// 总金额大于0 也允许修改报销类型。
                        //    RadioButtonList1.Enabled = false;
                        //    //TextBox_Remark.Enabled = false;
                        //}
                        HiddenField1.Value = iClass(OP_Mode.Dtv[0]["KZXM"].ToString()).ToString(); // 设置单据类型
                        // 生成明细
                        for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                        {
                            if (OP_Mode.Dtv[i]["ID"].ToString() == Request["MXID"])
                            {
                                DropDownList1.SelectedValue = OP_Mode.Dtv[i]["KZXM"].ToString();
                                TextBoxSTime.Text = Convert.ToDateTime(OP_Mode.Dtv[i]["Occurrence"]).ToString("yyyy-MM-dd");

                                if (OP_Mode.Dtv[i]["BreakFirst"].ToString() != "0.00")
                                {
                                    TextBox_Breakfirst.Text = OP_Mode.Dtv[i]["BreakFirst"].ToString();
                                }
                                if (OP_Mode.Dtv[i]["ZCBZ"].ToString() != "0.00")
                                {
                                    TextBox_ZC.Text = OP_Mode.Dtv[i]["ZCBZ"].ToString();
                                }
                                if (OP_Mode.Dtv[i]["WCBZ"].ToString() != "0.00")
                                {
                                    TextBox_WC.Text = OP_Mode.Dtv[i]["WCBZ"].ToString();
                                }
                                if (OP_Mode.Dtv[i]["ZSBZ"].ToString() != "0.00")
                                {
                                    TextBox_ZS.Text = OP_Mode.Dtv[i]["ZSBZ"].ToString();
                                }
                                if (OP_Mode.Dtv[i]["DRZS"].ToString() != "0.00")
                                {
                                    TextBox_DRZS.Text = OP_Mode.Dtv[i]["DRZS"].ToString();
                                }

                                TextBox_TXR.Text = OP_Mode.Dtv[i]["TXR"].ToString();
                                TextBox_MC.Text = OP_Mode.Dtv[i]["MC"].ToString();
                                TextBox_Becity.Text = OP_Mode.Dtv[i]["Becity"].ToString();
                                TextBox_Arrival.Text = OP_Mode.Dtv[i]["Arrival"].ToString();
                                TextBox_Arrival.Text = OP_Mode.Dtv[i]["Arrival"].ToString();
                                TextBox_Num.Text = OP_Mode.Dtv[i]["BXJE"].ToString();
                                TextBox_Remark2.Text = OP_Mode.Dtv[i]["Remark"].ToString();
                                //TextBox_DRZS.                            
                            }
                            else
                            {
                                AddImagesShow(OP_Mode.Dtv[i]["Image"].ToString(), OP_Mode.Dtv[i]["Image2"].ToString(), OP_Mode.Dtv[i]["Image3"].ToString(), Convert.ToDateTime(OP_Mode.Dtv[i]["Occurrence"]).ToString("yyyy-MM-dd"), OP_Mode.Dtv[i]["KZXM"].ToString(), OP_Mode.Dtv[i]["TXR"].ToString(), OP_Mode.Dtv[i]["MC"].ToString(), OP_Mode.Dtv[i]["Becity"].ToString(), OP_Mode.Dtv[i]["Arrival"].ToString(), Convert.ToDouble(OP_Mode.Dtv[i]["BXJE"]), OP_Mode.Dtv[i]["Remark"].ToString(), Convert.ToDouble(OP_Mode.Dtv[i]["BreakFirst"]), Convert.ToDouble(OP_Mode.Dtv[i]["ZCBZ"]), Convert.ToDouble(OP_Mode.Dtv[i]["WCBZ"]), Convert.ToDouble(OP_Mode.Dtv[i]["ZSBZ"]), Convert.ToDouble(OP_Mode.Dtv[i]["DRZS"]), Convert.ToInt32(OP_Mode.Dtv[i]["ID"]), bDel);
                            }
                        }
                    }
                }
            }
            else
            {
                Label_No.Text = "等待生成编号";
                Label_CName.Text = UserNAME;
                TextBox_Cname.Text = UserNAME;
            }
        }
        catch
        {
            Label_No.Text = "等待生成编号";
        }
        /// 依据选择显示文本框
        ShowTextBox();
    }

    /// <summary>
    /// 依据条件显示可用的TextBox
    /// </summary>
    private void ShowTextBox()
    {
        if (Label_Flag.Text != "待提交")
        {
            AddHtml.Visible = false;
            LinkButton2.Visible = false;
        }

        if (Label_No.Text == "等待生成编号")
        {
            LinkButton2.Visible = false;
        }
        if (Label_CName.Text != UserNAME)
        {
            LinkButton2.Visible = false;
        }

        if (Label_Flag.Text == "已完结")
        {
            LinkButton_Del.Visible = false;
            LinkButton_Next.Visible = false;
            LinkButton_Return.Visible = false;
        }
        else if (Label_Flag.Text == "待提交")
        {
            LinkButton_Del.Visible = true;
            LinkButton_Next.Visible = true;
            LinkButton_Return.Visible = false;
        }
        else
        {
            LinkButton_Del.Visible = false;
            LinkButton_Next.Visible = true;
            LinkButton_Return.Visible = true;
        }

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
    private void AddImagesShow(String imageName, String imageName2, String imageName3, String strSTime, String strKZXM, String strTXR, String strMC, String strBecity, String strArrival, Double strNum, String strRemark2, double db_Bk, double Db_ZC, double DB_WC, double Db_ZS, double DB_DRZS, int MXID, bool del)
    {
        WellList.InnerHtml += " <div class=\"well\">";
        WellList.InnerHtml += "   <h4 class=\"green smaller lighter\">" + strKZXM + "</h4>";

        if (imageName.Length > 10)//"\BxImages\"
        {
            WellList.InnerHtml += " <a href='" + imageName + "' target='_blank'><img src=\"" + imageName + "\" style =\"height:40px;\" /></a>";
        }
        if (imageName2.Length > 10)//"\BxImages\"
        {
            WellList.InnerHtml += " <a href='" + imageName2 + "' target='_blank'><img src=\"" + imageName2 + "\" style =\"height:40px;\" /></a>";
        }
        if (imageName3.Length > 10)//"\BxImages\"
        {
            WellList.InnerHtml += " <a href='" + imageName3 + "' target='_blank'><img src=\"" + imageName3 + "\" style =\"height:40px;\" /></a>";
        }
        WellList.InnerHtml += " 发生时间：" + strSTime + " ";

        if (strKZXM == "交通费" || strKZXM == "运输费")
        {
            WellList.InnerHtml += " 路程：" + strBecity.ToString() + " - " + strArrival.ToString() + " ";
        }
        else if (strKZXM == "补助")
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
        else if (strKZXM == "采购物资")
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
            WellList.InnerHtml += "   <a href=\"\\CWGL\\BXDMXDel.aspx?MXID=" + MXID + "&ID=" + Label_No.Text + "\"><h5 class=\"red smaller lighter\">删 除</h5></a>";
            WellList.InnerHtml += "   <a href=\"\\CWGL\\ReimbursementAdd.aspx?ID=" + Request["ID"] + "&MXID=" + MXID + "\"><h5 class=\"red smaller lighter\">修 改</h5></a>";
        }
        WellList.InnerHtml += " </div>";
    }

    /// <summary>
    /// 依据报销类别返回类型，同一张单据不允许报销多类型内容
    /// </summary>
    private int iClass(string strFYLX)
    {
        //交通费、补助  类别1
        //采购物资、运输费  类别2
        //租脚手架、开槽费、开孔费、停车费、加油费、招待费、其他 类别3
        int rValue = 0;

        int intClass = Convert.ToInt32(HiddenField1.Value);

        if (strFYLX == "交通费" || strFYLX == "补助" || strFYLX == "办公费" || strFYLX == "福利费" || strFYLX == "行政综合")
        {
            rValue = 1;
        }
        else if (strFYLX == "运输费" || strFYLX == "采购物资")
        {
            rValue = 2;
        }
        else
        {
            rValue = 3;
        }

        return rValue;
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
            MessageBox("", "数据保存成功。");
        }
        else
        {
            MessageBox("", "数据保存失败。");
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
        if (TextBox_Remark.Text.Length <= 0)
        {
            i = i + 1;
            ErrMsg += i + "、工程编号或事由必须填写。<br>";
        }
        if (Convert.ToInt32(HiddenField1.Value) > 0)
        {
            if (iClass(DropDownList1.SelectedValue) != Convert.ToInt32(HiddenField1.Value))
            {
                i = i + 1;
                ErrMsg += i + "、不同费用类型请不要填写在同一张单据上。<br>";
            }
        }
        else
        {
            HiddenField1.Value = iClass(DropDownList1.SelectedValue).ToString(); // 设置单据类型
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
            if (TextBox_Cname.Text.Length <= 0)
            {
                i = i + 1;
                ErrMsg += i + "、收款人必须填写。<br>";
            }
        }

        int MXID = 0;
        try
        {
            MXID = Convert.ToInt32(Request["MXID"].Length);
        }
        catch
        {

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
            string Image1 = String.Empty;

            int iFilCount = Request.Files.Count;

            for (int i1 = 0; i1 < iFilCount; i1++)
            {
                HttpPostedFile f = Request.Files[i1];
                Image1 += UploadTPs(f) + ";";
            }

            String imageName = String.Empty;// UploadTP(FileUpload1);
            String imageName2 = String.Empty;// UploadTP(FileUpload2);
            String imageName3 = String.Empty;// UploadTP(FileUpload3);

            string[] Images = Image1.Split(';');

            if (Images.Length > 2)
            {
                imageName3 = Images[2];
            }
            if (Images.Length > 1)
            {
                imageName2 = Images[1];
            }
            if (Images.Length > 0)
            {
                imageName = Images[0];
            }

            if (imageName.Length > 0 || DropDownList1.SelectedValue == "补助" || DropDownList1.SelectedValue == "办公费" || DropDownList1.SelectedValue == "福利费" || DropDownList1.SelectedValue == "行政综合" || DropDownList1.SelectedValue == "交通费" || MXID > 0)
            {/// 图片上传成功

                string strSQL = string.Empty;
                int newID = 0;
                if (Label_No.Text.Length == "BXD2020-12-01-0001".Length)
                {/// 更新主表数据
                    strSQL = " Update w_bxd1 set BXLX='" + RadioButtonList1.SelectedValue + "',SKR='" + TextBox_Cname.Text + "',Remark='" + TextBox_Remark.Text.Replace("'", "") + "',LTIME=getdate() where BXDH='" + Label_No.Text + "'";

                    strSQL += " SELECT * FROM w_bxd1 WHERE BXDH='" + Label_No.Text + "'";
                }
                else
                {/// 插入数据 
                    //1、插入主表数据
                    strSQL = " Insert into w_bxd1 (UserName,BXDH,FLAG,BXLX,Remark,skr) values ('" + UserNAME + "',(SELECT  'BXD'+CONVERT(VARCHAR(10),GETDATE(),120) + '-' + RIGHT('0000' + CAST(ISNULL(MAX(RIGHT(BXDH,4)),'0000') + 1 AS VARCHAR),4) FROM w_bxd1 WHERE CONVERT(VARCHAR(10),GETDATE(),120) = CONVERT(VARCHAR(10),CTIME,120)),0," + RadioButtonList1.SelectedValue + ",'" + TextBox_Remark.Text.Replace("'", "") + "','" + TextBox_Cname.Text + "')";

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
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        Label_No.Text = OP_Mode.Dtv[0]["BXDH"].ToString();// 订单号
                    }

                    if (db_Bk > 0)
                    { // 如果报销餐费补助和住宿补助 则检查是不是本人报销过。

                        strSQL = "Select * from W_BXD1,W_BXD2 where W_BXD1.bxdh=W_BXD2.BXDH and UserName='" + UserNAME + "' and Occurrence='" + TextBoxSTime.Text.Replace("'", "") + " 00:00:00.000' and breakfirst>0";// 查询是否是通行人

                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            if (OP_Mode.Dtv.Count > 0)
                            {
                                MessageBox("", "您当天已经报销过早餐补助了。<br/> 您不能再报销该费用了。");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox("", "明细保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                            return false;
                        }
                    }
                    if (Db_ZC > 0)
                    { // 如果报销餐费补助和住宿补助 则检查是不是本人报销过。

                        strSQL = "Select * from W_BXD1,W_BXD2 where W_BXD1.bxdh=W_BXD2.BXDH and UserName='" + UserNAME + "' and Occurrence='" + TextBoxSTime.Text.Replace("'", "") + " 00:00:00.000' and ZCBZ>0";// 查询是否是通行人

                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            if (OP_Mode.Dtv.Count > 0)
                            {
                                MessageBox("", "您当天已经报销过午餐补助了。<br/> 您不能再报销该费用了。");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox("", "明细保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                            return false;
                        }
                    }
                    if (DB_WC > 0)
                    { // 如果报销餐费补助和住宿补助 则检查是不是本人报销过。

                        strSQL = "Select * from W_BXD1,W_BXD2 where W_BXD1.bxdh=W_BXD2.BXDH and UserName='" + UserNAME + "' and Occurrence='" + TextBoxSTime.Text.Replace("'", "") + " 00:00:00.000' and WCBZ>0";// 查询是否是通行人

                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            if (OP_Mode.Dtv.Count > 0)
                            {
                                MessageBox("", "您当天已经报销过晚餐补助了。<br/> 您不能再报销该费用了。");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox("", "明细保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                            return false;
                        }
                    }

                    if (Db_ZS > 0)
                    { // 如果报销餐费补助和住宿补助 则检查是不是通行人报销过。

                        strSQL = "Select * from W_BXD2 where TXR='" + UserNAME + "' and Occurrence='" + TextBoxSTime.Text.Replace("'", "") + " 00:00:00.000' ";// 查询是否是通行人


                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            if (OP_Mode.Dtv.Count > 0)
                            {
                                MessageBox("", "您该天被当做同行人报销过该费用了。<br/> 您不能再报销该费用了。");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox("", "明细保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                            return false;
                        }
                    }

                    string strKZXM, strSTime, strTXR, strMC, strBecity, strArrival, strRemark2;
                    double strNum;
                    strKZXM = DropDownList1.SelectedValue.Replace("'", "");// 报销项目
                    strSTime = TextBoxSTime.Text.Replace("'", "");//报销时间
                    strTXR = TextBox_TXR.Text.Replace("'", "");// 同行人
                    strMC = TextBox_MC.Text.Replace("'", "");// 名称
                    strBecity = TextBox_Becity.Text.Replace("'", "");// 出发地点
                    strArrival = TextBox_Arrival.Text.Replace("'", "");//到达地点

                    if (DropDownList1.SelectedValue == "补助")
                    {
                        strNum = db_Bk + Db_ZC + DB_WC + Db_ZS + DB_DRZS;
                    }
                    else
                    {
                        strNum = Convert.ToDouble(TextBox_Num.Text);// 报销金额
                    }

                    strRemark2 = TextBox_Remark2.Text.Replace("'", "");//报销说明信息

                    imageName = "/BxImages/" + imageName;
                    imageName2 = "/BxImages/" + imageName2;
                    imageName3 = "/BxImages/" + imageName3;
                    if (MXID > 0)
                    {
                        strSQL = " update w_bxd2 set KZXM='" + strKZXM + "',";
                        strSQL += " Occurrence='" + strSTime + "',";
                        strSQL += " BreakFirst='" + db_Bk + "',";
                        strSQL += " ZCBZ='" + Db_ZC + "',";
                        strSQL += " WCBZ='" + DB_WC + "',";
                        strSQL += " ZSBZ='" + Db_ZS + "',";
                        strSQL += " DRZS='" + DB_DRZS + "',";
                        strSQL += " TXR='" + strTXR + "',";
                        strSQL += " MC='" + strMC + "',";
                        strSQL += " Becity='" + strBecity + "',";
                        strSQL += " Arrival='" + strArrival + "',";
                        strSQL += " BXJE='" + strNum + "',";
                        strSQL += " Remark='" + strRemark2 + "'";
                        if (imageName != "/BxImages/")
                        {
                            strSQL += " ,Image='" + imageName + "'";
                        }
                        if (imageName2 != "/BxImages/")
                        {
                            strSQL += " ,Image2='" + imageName2 + "'";
                        }
                        if (imageName3 != "/BxImages/")
                        {
                            strSQL += " ,Image3='" + imageName3 + "'";
                        }
                        strSQL += " Where ID=" + Request["MXID"] + "";
                        strSQL += " SELECT * FROM w_bxd2 WHERE ID=" + Request["MXID"];
                    }
                    else
                    {
                        /// 插入明细数据
                        strSQL = "Insert into w_bxd2 (BXDH,KZXM,Occurrence,BreakFirst,ZCBZ,WCBZ,ZSBZ,DRZS,TXR,MC,Becity,Arrival,BXJE,Remark,Image,Image2,Image3)";
                        strSQL += " values ('" + Label_No.Text.Replace("'", "") + "','" + strKZXM + "','" + strSTime + "',";
                        strSQL += " " + db_Bk + "," + Db_ZC + "," + DB_WC + ", ";
                        strSQL += " " + Db_ZS + "," + DB_DRZS + ",'" + strTXR + "',";
                        strSQL += " '" + strMC + "','" + strBecity + "','" + strArrival + "'," + strNum + ",'" + strRemark2 + "','" + imageName + "','" + imageName2 + "','" + imageName3 + "')";
                        strSQL += " SELECT * FROM w_bxd2 WHERE ID=SCOPE_IDENTITY()";
                    }
                    if (OP_Mode.SQLRUN(strSQL))
                    {
                        if (MXID > 0)
                        {
                            MessageBox("", "明细修改成功。", "/CWGL/ReimbursementAdd.ASPX?ID=" + Request["ID"]);
                        }
                        AddImagesShow(imageName, imageName2, imageName3, strSTime, strKZXM, strTXR, strMC, strBecity, strArrival, strNum, strRemark2, db_Bk, Db_ZC, DB_WC, Db_ZS, DB_DRZS, Convert.ToInt32(OP_Mode.Dtv[0]["ID"]), true);
                        ClearTextbox();
                        Label_Sumje.Text = (Convert.ToDouble(Label_Sumje.Text) + strNum).ToString();
                    }
                    else
                    {
                        MessageBox("", "报销单明细保存错误：<br/>" + strSQL + "<br/>" + OP_Mode.strErrMsg);
                        rValue = false;
                    }
                }
                else
                {
                    MessageBox("", "报销单保存错误：<br/>" + strSQL + "<br/>" + OP_Mode.strErrMsg);
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
    /// <summary>
    /// 上传图片信息
    /// </summary>
    private string UploadTPs(HttpPostedFile fileName)
    {
        string SavePath = "BxImages";// 图片保存路径  ，无需/  ~/KQImage/
        string Prefix = "BX";// 新文件名前缀
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
    private void SedMsg(int IZID)
    {
        int iQXZ = IZID;// 判断需要发送的群组的权限组ID

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
        // 取消报销单的消息提示 2023-03-03
        //if (strUsers.Length > 0)
        //{
        //    try
        //    {
        //        int ID = Convert.ToInt32(Request["ID"]);

        //        SendWorkMsgCard(strUsers, "报销单提交提示", " [" + UserNAME + "] 完成了一张报销单，需要您的审核。", "www.putian.ink/CWGL/ReimbursementAdd.aspx?ID=" + ID + "&WeChat=0");
        //    }
        //    catch
        //    {
        //    }
        //}
    }
    /// <summary>
    /// 提交状态
    /// </summary>
    private void SaveFlag()
    {
        if (Label_No.Text.Length < 18)
        {/// 单据编号不对，不允许提交
            return;
        }
        // 保存记录表  W_Examine

        int oldFlag = NameToFlag(Label_Flag.Text);// 当前状态
        int NewFlag = NextFlag(oldFlag);// 提交后他状态

        if (Label_Flag.Text == "综合部")
        {
            if (!QXBool(39, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有审核的权限。", Defaut_QX_URL);
                return;
            }
        }
        else if (Label_Flag.Text == "物资部")
        {
            if (!QXBool(40, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有审核的权限。", Defaut_QX_URL);
                return;
            }
        }
        else if (Label_Flag.Text == "工程部")
        {
            if (!QXBool(41, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有审核的权限。", Defaut_QX_URL);
                return;
            }
        }
        else if (Label_Flag.Text == "待放款" || Label_Flag.Text == "待收票" || Label_Flag.Text == "财务部")
        {
            if (!QXBool(42, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有审核的权限。", Defaut_QX_URL);
                return;
            }
        }
        else if (Label_Flag.Text == "待提交")
        {
            if (UserNAME != Label_CName.Text)
            {
                MessageBox("", "您不允许提交别人的单据。");
                return;
            }
        }

        string strSQL = " Insert into W_Examine(Class,DJBH,UserName,OldFlag,NewFlag) values ('BXD','" + Label_No.Text + "','" + UserNAME + "'," + oldFlag + "," + NewFlag + ")";

        if (Label_Flag.Text == "待提交")
        {
            strSQL += " Update W_BXD1 Set Flag=" + NewFlag + ",SKR='" + TextBox_Cname.Text + "',Remark='" + TextBox_Remark.Text + "',LTime=getdate() where BXDH='" + Label_No.Text + "'";
        }
        else
        {
            strSQL += " Update W_BXD1 Set Flag=" + NewFlag + ",LTime=getdate() where BXDH='" + Label_No.Text + "'";
        }
        if (OP_Mode.SQLRUN(strSQL))
        {

            if (NewFlag == 2)
            {//综合部
                SedMsg(11);
            }
            else if (NewFlag == 3)
            {//物资部
                SedMsg(12);
            }
            else if (NewFlag == 4)
            {//工程部
                SedMsg(2);
            }
            else if (NewFlag == 5)
            {//财务部
                SedMsg(10);
            }
            else if (NewFlag == 6)
            {//待放款
                SedMsg(10);
            }
            else if (NewFlag == 7)
            {// 待收票
                SedMsg(10);
            }

            MessageBox("", "单据提交成功。", "/CWGL/");
        }
        else
        {
            MessageBox("", "单据提交失败。<br>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 报销流程走向
    /// </summary>
    /// <returns></returns>
    private int NextFlag(int NowFlag)
    {
        int rValue = 0;

        if (NowFlag == 0)
        {
            if (HiddenField1.Value == "1")
            {// 到综合部
                rValue = 2;
            }
            else if (HiddenField1.Value == "2")
            {// 到物资岗
                rValue = 3;
            }
            else if (HiddenField1.Value == "3")
            {// 到工程岗
                rValue = 4;
            }
        }
        else if (NowFlag == 2)
        {/// 综合部 到 财务部
            rValue = 5;
        }
        else if (NowFlag == 3)
        {/// 物资岗 到 综合部
            rValue = 2;
        }
        else if (NowFlag == 4)
        {/// 工程岗 到 综合部
            rValue = 2;
        }
        else if (NowFlag == 5)
        {///财务部 到 待放款
            rValue = 6;
        }
        else if (NowFlag == 6)
        {/// 待放款 到 待收票
            rValue = 7;
        }
        else if (NowFlag == 7)
        {/// 待收票 到 已完结
            rValue = 1;
        }
        else if (NowFlag == 1)
        {/// 已完结 到 已完结
            rValue = 1;
        }

        return rValue;
    }

    /// <summary>
    /// 依据状态名称转换成数字
    /// </summary>
    /// <returns></returns>
    private int NameToFlag(string strFlag)
    {
        int rValue = 0;

        if (strFlag == "待提交")
        {
            rValue = 0;
        }
        else if (strFlag == "综合部")
        {
            rValue = 2;
        }
        else if (strFlag == "物资部")
        {
            rValue = 3;
        }
        else if (strFlag == "工程部")
        {
            rValue = 4;
        }
        else if (strFlag == "财务部")
        {
            rValue = 5;
        }
        else if (strFlag == "待放款")
        {
            rValue = 6;
        }
        else if (strFlag == "待收票")
        {
            rValue = 7;
        }
        else if (strFlag == "已完结")
        {
            rValue = 1;
        }
        return rValue;
    }
    /// <summary>
    /// 状态数字转换成名字
    /// </summary>
    /// <param name="strFlag"></param>
    /// <returns></returns>
    private string FlagToName(int strFlag)
    {
        string rValue = "待提交";

        if (strFlag == 0)
        {
            rValue = "待提交";
        }
        else if (strFlag == 2)
        {
            rValue = "综合部";
        }
        else if (strFlag == 3)
        {
            rValue = "物资部";
        }
        else if (strFlag == 4)
        {
            rValue = "工程部";
        }
        else if (strFlag == 5)
        {
            rValue = "财务部";
        }
        else if (strFlag == 6)
        {
            rValue = "待放款";
        }
        else if (strFlag == 7)
        {
            rValue = "待收票";
        }
        else if (strFlag == 1)
        {
            rValue = "已完结";
        }
        return rValue;
    }

    /// <summary>
    /// 单据退回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'>window.location='/CWGL/ReturnMSG.aspx?ID=" + Request["ID"] + "&Flag=" + NameToFlag(Label_Flag.Text) + "'</script>");
    }

    /// <summary>
    /// 单据状态提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        SaveFlag();
    }

    /// <summary>
    /// 整单删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Label_No.Text.Length < 18)
        {
            return;
        }
        if (UserNAME != Label_CName.Text)
        {
            MessageBox("", "您不允许删除别人的单据。");
            return;
        }
        if (Label_Flag.Text != "待提交")
        {
            MessageBox("", "已经提交的单据是不允许删除的。");
            return;
        }
        string strSQL = "Delete w_bxd2 from w_bxd1,w_bxd2 where w_bxd1.BXDH=w_bxd2.BXDH and w_bxd1.bxdh='" + Label_No.Text + "' ";
        strSQL += " Delete from w_bxd1 where bxdh='" + Label_No.Text + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "单据删除成功。", "/CWGL/");
            return;
        }
        else
        {
            MessageBox("", "单据删除错误。<br>" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 单独数据保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        if (SaveData())
        {
            MessageBox("", "数据保存成功。");
        }
        else
        {
            MessageBox("", "数据保存失败。");
        }
    }

    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        if (SaveDefault())
        {
            MessageBox("", "主表数据保存成功。");
        }
        else
        {
            MessageBox("", "主表数据保存失败。");
        }

    }

    private bool SaveDefault()
    {
        bool rValue = false;
        string strSQL = string.Empty;
        if (Label_Flag.Text == "待提交" & Label_No.Text != "等待生成编号")
        {
            strSQL = " Update w_bxd1 set BXLX='" + RadioButtonList1.SelectedValue + "',SKR='" + TextBox_Cname.Text + "',Remark='" + TextBox_Remark.Text.Replace("'", "") + "',LTIME=getdate() where BXDH='" + Label_No.Text + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                rValue = true;
            }
        }
        return rValue;
    }
}