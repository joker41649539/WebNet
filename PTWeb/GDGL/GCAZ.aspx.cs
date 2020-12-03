using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCAZ : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void LoadData()
    {
        string strSQL = "Select *,w_gcgd2.id IID from W_GCGD_USERS,W_GCGD1,w_gcgd2 where USERS=" + DefaultUser + " and W_GCGD1.GCDH=W_GCGD2.GCDH and W_GCGD1.ID=GCDID and w_gcgd2.id=" + Request["ID"] + " ORDER BY GCDD,AZWZ,SBBH";

        int sumSL = 0;///统计总共完成了多少；
        bool bUser = false;/// 包含了本人干的活

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_GCMC.NavigateUrl = "\\GDGL\\GCAZList.ASPX?ID=" + OP_Mode.Dtv[0]["IID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["AZWZ"].ToString();
                Label2.Text = OP_Mode.Dtv[0]["SBBH"].ToString();
                Label3.Text = OP_Mode.Dtv[0]["SBMC"].ToString();
                Label4.Text = OP_Mode.Dtv[0]["SBPP"].ToString();
                Label5.Text = OP_Mode.Dtv[0]["SBXH"].ToString();
                Label6.Text = OP_Mode.Dtv[0]["JLDW"].ToString();
                Label7.Text = OP_Mode.Dtv[0]["SL"].ToString();
                Label8.Text = OP_Mode.Dtv[0]["YQSM"].ToString();
                Label11.Text = OP_Mode.Dtv[0]["AZFS"].ToString();

                /// 加载已经安装的人员
                strSQL = "Select CNAME,AZFS,remark,S_USERINFO.ID ID from W_GCGD_FS,S_USERINFO where GCMXID=" + Request["ID"] + " and S_USERINFO.ID=W_GCGD_FS.USERID";
                if (OP_Mode.SQLRUN(strSQL))
                {
                    string strTemp = string.Empty;
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {
                        sumSL += Convert.ToInt16(OP_Mode.Dtv[i]["AZFS"]);

                        if (Convert.ToInt16(OP_Mode.Dtv[i]["ID"]) == Convert.ToInt16(DefaultUser))
                        {/// 如果是本用户，则绑定文本框的值
                            TextBox3.Text = OP_Mode.Dtv[i]["AZFS"].ToString();
                            TextBox_Remark.Text = OP_Mode.Dtv[i]["Remark"].ToString();
                            bUser = true;
                        }
                        strTemp += OP_Mode.Dtv[i]["CNAME"].ToString() + ": 安装【" + OP_Mode.Dtv[i]["AZFS"].ToString() + " %】<br/>";
                    }
                    if (strTemp.Length > 0)
                    {
                        Label10.Text = "<br/>" + strTemp;
                    }
                }

                if (bUser == false)
                {/// 如果积分>0 并且 自己没有干过活，则把剩下的赋值给文本框
                    if (sumSL > 0)
                    {// 如果不是有人干过活了，则默认值还是0，否则为剩下的。
                        TextBox3.Text = (100 - sumSL).ToString();
                    }
                    HiddenField_SYFS.Value = (100 - sumSL).ToString();// 记录剩余分数百分比
                }
                else
                {
                    HiddenField_SYFS.Value = (100 - sumSL + Convert.ToInt32(TextBox3.Text)).ToString();
                }
            }
        }
    }

    /// <summary>
    /// 确认安装
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int iFS = Convert.ToInt32(TextBox3.Text);
            if (iFS > Convert.ToInt32(HiddenField_SYFS.Value))
            {
                MessageBox("", "安装百分比不允许大于 [" + HiddenField_SYFS.Value + "]。");
                return;
            }

            string strSQL = string.Empty; // 先删除之前数据，再添加数据

            strSQL += " DECLARE @Cont INT ";

            strSQL += " Select @Cont = count(ID) from w_gcgd_fs where gcmxid=" + Request["ID"] + " and userid=" + DefaultUser + " ";

            strSQL += " if @Cont>0 ";
            strSQL += " BEGIN ";
            strSQL += " Update w_gcgd_fs set AZFS=" + iFS.ToString() + ",Remark='" + TextBox_Remark.Text.Replace("'", "") + "',Ltime=getdate() where gcmxid=" + Request["ID"] + " and userid=" + DefaultUser + " ";
            strSQL += " End";
            strSQL += " Else";
            strSQL += " BEGIN ";
            strSQL += " Insert into w_gcgd_fs (GCMXID,USERID,AZFS,Remark) values (" + Request["ID"] + "," + DefaultUser + "," + iFS.ToString() + ",'" + TextBox_Remark.Text.Replace("'", "") + "')";
            strSQL += " End";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "安装信息录入成功，您辛苦了。", "/GDGL/GCAZList.ASPX?ID=" + Request["ID"]);
            }
            else
            {
                MessageBox("", "信息保存失败，请重试。<br>错误：" + OP_Mode.strErrMsg);
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox("", "安装失败。<BR>错误：" + ex.ToString() + "<br>请重试。");
        }
    }
}