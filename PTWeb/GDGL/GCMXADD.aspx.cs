using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCMXADD : PageBase
{
    public int iID = 0;
    public string strGCDH = "GC2020-07-19-0001";
    public string strSQL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            iID = Convert.ToInt32(Request["ID"]);
            if (iID <= 0)
            {
                if (Convert.ToInt32(Request["MXID"]) > 0)
                {
                    LoadMXData();
                }
                else
                {
                    MessageBox("", "参数错误！", "/GDGL/");
                    return;
                }
            }
            else
            {
                LoadData();
            }
        }
    }

    /// <summary>
    /// 加载明细
    /// </summary>
    private void LoadMXData()
    {
        strSQL = "Select * from W_GCGD2 where id=" + Request["MXID"];
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_GCBH.Text = OP_Mode.Dtv[0]["GCDH"].ToString();

                TextBox_AZWZ.Text = OP_Mode.Dtv[0]["AZWZ"].ToString();
                TextBox_SBBH.Text = OP_Mode.Dtv[0]["SBBH"].ToString();
                TextBox_SBMC.Text = OP_Mode.Dtv[0]["SBMC"].ToString();
                TextBox_SBPP.Text = OP_Mode.Dtv[0]["SBPP"].ToString();
                TextBox_SBXH.Text = OP_Mode.Dtv[0]["SBXH"].ToString();
                TextBox_JLDW.Text = OP_Mode.Dtv[0]["JLDW"].ToString();
                TextBox_SL.Text = OP_Mode.Dtv[0]["SL"].ToString();
                TextBox_FS.Text = OP_Mode.Dtv[0]["FS"].ToString();
                TextBox_AZFS.Text = OP_Mode.Dtv[0]["AZFS"].ToString();
                TextBox_XQSM.Text = OP_Mode.Dtv[0]["YQSM"].ToString();
            }
        }
    }

    /// <summary>
    /// 加载工程编号
    /// </summary>
    private void LoadData()
    {
        strSQL = "Select * from W_GCGD1 where id=" + iID;
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_GCBH.Text = OP_Mode.Dtv[0]["GCDH"].ToString();
            }
        }
    }
    /// <summary>
    /// 数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_YZ_LinkButton1_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    /// <summary>
    /// 数据保存
    /// </summary>
    private void SaveData()
    {
        string DB_01 = TextBox_AZWZ.Text;
        string DB_02 = TextBox_SBBH.Text;
        string DB_03 = TextBox_SBMC.Text;
        string DB_04 = TextBox_SBPP.Text;
        string DB_05 = TextBox_SBXH.Text;
        string DB_06 = TextBox_JLDW.Text;
        string DB_07 = TextBox_SL.Text;
        string DB_08 = TextBox_XQSM.Text;
        string DB_09 = TextBox_FS.Text;
        string DB_10 = TextBox_AZFS.Text;

        if (Label_GCBH.Text.Length != strGCDH.Length)
        {
            MessageBox("", "工程单号获取错误，请重试。", "/GDGL/");
            return;
        }
        //if (DB_01.Length == 0 || DB_02.Length == 0 || DB_03.Length == 0 || DB_04.Length == 0 || DB_05.Length == 0 || DB_06.Length == 0 || DB_07.Length == 0 || DB_08.Length == 0 || DB_09.Length == 0)
        //{
        //    MessageBox("", "所有选项都必须填写。<br/>请检查后认真填写。");
        //    return;
        //}
        try
        {
            if (Convert.ToInt32(DB_09) < 0)
            {
                MessageBox("", "布线分数必须为大于等于0的整数。请重新填写。");
                return;
            }
            if (Convert.ToInt32(DB_10) < 0)
            {
                MessageBox("", "安装分数必须为大于等于0的整数。请重新填写。");
                return;
            }
        }
        catch
        {
            MessageBox("", "施工分数必须为正整数。请重新填写。");
            return;
        }

        if (Convert.ToInt32(Request[ID]) > 0)
        {
            strSQL = "Insert into W_GCGD2 (GCDH,AZWZ,SBBH,SBMC,SBPP,SBXH,JLDW,SL,YQSM,FS,AZFS) values ('" + Label_GCBH.Text + "','" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "','" + DB_06 + "'," + DB_07 + ",'" + DB_08 + "'," + DB_09 + "," + DB_10 + ")";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "工程明细添加成功！", "/GDGL/GCGDAdd.ASPX?ID=" + Request["ID"]);
                return;
            }
            else
            {
                MessageBox("", "明细添加错误。<br>错误：" + OP_Mode.strErrMsg);
            }
        }
        else if (Convert.ToInt32(Request["MXID"]) > 0)
        {
            strSQL = "update W_GCGD2 set AZWZ='" + DB_01 + "',SBBH='" + DB_02 + "',SBMC='" + DB_03 + "',SBPP='" + DB_04 + "',SBXH='" + DB_05 + "',JLDW='" + DB_06 + "',SL='" + DB_07 + "',YQSM='" + DB_08 + "',FS='" + DB_09 + "',AZFS=" + DB_10 + ",LTime=Getdate() WHERE ID=" + Request["MXID"];

            strSQL += " Select ID from W_GCGD1 where GCDH='" + Label_GCBH.Text + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "工程明细修改成功！", "/GDGL/GCGDAdd.ASPX?ID=" + OP_Mode.Dtv[0]["ID"].ToString());
                return;
            }
            else
            {
                MessageBox("", "明细修改错误。<br>错误：" + OP_Mode.strErrMsg);
            }
        }
    }

    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/GDGL/GCGDAdd.ASPX?ID=" + Request["ID"]);
    }
}