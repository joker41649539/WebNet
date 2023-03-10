using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Question_Default2 : PageBaseQuestion
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string LoginID = string.Empty;
            string strID = string.Empty;
            try
            {
                LoginID = Request.Cookies["WeChat_Question"]["USERID"].ToString();
                strID = Request["ID"];
            }
            catch
            {
            }

            if (LoginID.Length > 0)
            {

            }
            else
            {
                Response.Redirect("/Question/Login.aspx", false);
            }

            if (Convert.ToInt32(strID) > 0)
            {
                LoadData(Convert.ToInt32(strID));
                LinkButton2.Visible = true;
            }
            else
            {
                LinkButton2.Visible = false;
            }
        }
    }
    /// <summary>
    /// 加载基础数据
    /// </summary>
    /// <param name="strID"></param>
    private void LoadData(int strID)
    {
        string strSQL = "Select * from Question_Info Where id=" + strID;
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string Db01 = OP_Mode.Dtv[0][1 + 2].ToString();
                string Db02 = OP_Mode.Dtv[0][2 + 2].ToString();
                string Db03 = OP_Mode.Dtv[0][3 + 2].ToString();
                string Db04 = OP_Mode.Dtv[0][4 + 2].ToString();
                string Db05 = OP_Mode.Dtv[0][5 + 2].ToString();
                string Db06 = OP_Mode.Dtv[0][6 + 2].ToString();
                string Db07 = OP_Mode.Dtv[0][7 + 2].ToString();
                string Db08 = OP_Mode.Dtv[0][8 + 2].ToString();
                string Db09 = OP_Mode.Dtv[0][9 + 2].ToString();
                string Db10 = OP_Mode.Dtv[0][10 + 2].ToString();
                string Db11 = OP_Mode.Dtv[0][11 + 2].ToString();
                string Db12 = OP_Mode.Dtv[0][12 + 2].ToString();
                string Db13 = OP_Mode.Dtv[0][13 + 2].ToString();
                string Db14 = OP_Mode.Dtv[0][14 + 2].ToString();
                string Db15 = OP_Mode.Dtv[0][15 + 2].ToString();
                string Db16 = OP_Mode.Dtv[0][16 + 2].ToString();
                string Db17 = OP_Mode.Dtv[0][17 + 2].ToString();
                string Db18 = OP_Mode.Dtv[0][18 + 2].ToString();
                string Db19 = OP_Mode.Dtv[0][19 + 2].ToString();
                string Db20 = OP_Mode.Dtv[0][21 + 2].ToString();

                TextBox_XZ.Text = Db01;
                TextBox_Name.Text = Db02;
                TextBox_SQ.Text = Db03;
                TextBox_XQ.Text = Db04;
                TextBox_MPH.Text = Db05;
                TextBox_ZJNO.Text = Db06;
                TextBox_HJD.Text = Db07;
                TextBox_DW.Text = Db08;

                RadioButtonList_ZZMM.SelectedValue = Db09;

                TextBox_LXDH.Text = Db10;

                RadioButtonList1.SelectedValue = Db11; //RadioButtonList1 是否接种
                RadioButtonList_JZ.SelectedValue = Db12; // RadioButtonList_JZ 接种剂次

                TextBox_JZDD.Text = Db13;
                TextBox_WZYY.Text = Db14;

                RadioButtonList_ZY.SelectedValue = Db15;// RadioButtonList_ZY志愿服务

                TextBox_QTDZ.Text = Db16;
                TextBox_WGY.Text = Db17;
                TextBox_LDZ.Text = Db18;
                TextBox_Remark.Text = Db19;
                Label_LTime.Text = Db20; /// 更新时间
            }
        }
    }

    /// <summary>
    /// 数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strID = "0";
        try
        {
            strID = Request["ID"];
        }
        catch
        {

        }

        UpdateData(Convert.ToInt32(strID));

    }

    private void UpdateData(int strID)
    {
        string Db01 = TextBox_XZ.Text.Replace("'", "''");
        string Db02 = TextBox_Name.Text.Replace("'", "''");
        string Db03 = TextBox_SQ.Text.Replace("'", "''");
        string Db04 = TextBox_XQ.Text.Replace("'", "''");
        string Db05 = TextBox_MPH.Text.Replace("'", "''");
        string Db06 = TextBox_ZJNO.Text.Replace("'", "''");
        string Db07 = TextBox_HJD.Text.Replace("'", "''");
        string Db08 = TextBox_DW.Text.Replace("'", "''");
        string Db09 = RadioButtonList_ZZMM.SelectedValue;
        string Db10 = TextBox_LXDH.Text.Replace("'", "''");
        string Db11 = RadioButtonList1.SelectedValue;
        string Db12 = RadioButtonList_JZ.SelectedValue;
        string Db13 = TextBox_JZDD.Text.Replace("'", "''");
        string Db14 = TextBox_WZYY.Text.Replace("'", "''");
        string Db15 = RadioButtonList_ZY.SelectedValue;
        string Db16 = TextBox_QTDZ.Text.Replace("'", "''");
        string Db17 = TextBox_WGY.Text.Replace("'", "''");
        string Db18 = TextBox_LDZ.Text.Replace("'", "''");
        string Db19 = TextBox_Remark.Text.Replace("'", "''");

        string strSQL = string.Empty;

        if (strID > 0)
        {
            strSQL = "Update Question_Info set XZ='" + Db01 + "',NAME='" + Db02 + "',SQM='" + Db03 + "',XQM='" + Db04 + "',MPH='" + Db05 + "',ZJHM='" + Db06 + "',HJD='" + Db07 + "',GZDW='" + Db08 + "',ZZMM='" + Db09 + "',LXDH='" + Db10 + "',SFJZ='" + Db11 + "',JZJC='" + Db12 + "',JZDD='" + Db13 + "',WZYY='" + Db14 + "',ZYFF='" + Db15 + "',LWZS='" + Db16 + "',WGY='" + Db17 + "',LDZ='" + Db18 + "',Remark='" + Db19 + "',LTime=getdate() where id=" + strID;
        }
        else
        {
            strSQL = "Insert into Question_Info (XZ,NAME,SQM,XQM,MPH,ZJHM,HJD,GZDW,ZZMM,LXDH,SFJZ,JZJC,JZDD,WZYY,ZYFF,LWZS,WGY,LDZ,Remark,UserID,MDR) values ('" + Db01 + "','" + Db02 + "','" + Db03 + "','" + Db04 + "','" + Db05 + "','" + Db06 + "','" + Db07 + "','" + Db08 + "','" + Db09 + "','" + Db10 + "','" + Db11 + "','" + Db12 + "','" + Db13 + "','" + Db14 + "','" + Db15 + "','" + Db16 + "','" + Db17 + "','" + Db18 + "','" + Db19 + "'," + DefaultUser + ",'" + UserNAME + "')";
        }

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (strID > 0)
            {
                MessageBox("", "信息更新成功。");
            }
            else
            {
                MessageBox("", "信息添加成功。", "/Question/");
            }
        }
    }

    /// <summary>
    /// 数据删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string strID = "0";
        try
        {
            strID = Request["ID"];
        }
        catch
        {

        }

        if (Convert.ToInt32(strID) > 0)
        {
            string strSQL = "Delete from Question_Info where id=" + strID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "信息删除。", "/Question/");
            }
        }
    }
}