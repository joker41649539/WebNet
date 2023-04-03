using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_BXPercent : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int iid = 0;
        if (!IsPostBack)
        {
            try
            {
                iid = Convert.ToInt32(Request["ID"]);
                LoadData(iid);
            }
            catch
            {
            }
        }
    }
    /// <summary>
    /// 加载基础数据  最多设置 6 个人
    /// </summary>
    /// <param name="IID"></param>
    private void LoadData(int IID)
    {
        string strSQL = "Select case Charge when 1 then '(主)'+ CNAME else CNAME end CName,ipercent,GCMC,W_GCGD_USERS.ID from W_GCGD_USERS,S_USERINFO,W_GCGD1 where GCDID=" + IID + " and GCDID=W_GCGD1.ID and W_GCGD_USERS.Flag=0 and USERS=S_USERINFO.ID  order by charge desc,CNAME";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                HyperLink1.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                HyperLink1.NavigateUrl = "/GDGL/MyGDBXWZ.aspx?ID=" + IID;
            }

            if (OP_Mode.Dtv.Count == 6)
            {
                HiddenField6.Value = OP_Mode.Dtv[5]["ID"].ToString();
                Label6.Text = OP_Mode.Dtv[5]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox6.Text = OP_Mode.Dtv[5]["ipercent"].ToString();
                Div6.Visible = true;

                HiddenField5.Value = OP_Mode.Dtv[4]["ID"].ToString();
                Label5.Text = OP_Mode.Dtv[4]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox5.Text = OP_Mode.Dtv[4]["ipercent"].ToString();
                Div5.Visible = true;

                HiddenField4.Value = OP_Mode.Dtv[3]["ID"].ToString();
                Label4.Text = OP_Mode.Dtv[3]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox4.Text = OP_Mode.Dtv[3]["ipercent"].ToString();
                Div4.Visible = true;

                HiddenField3.Value = OP_Mode.Dtv[2]["ID"].ToString();
                Label3.Text = OP_Mode.Dtv[2]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox3.Text = OP_Mode.Dtv[2]["ipercent"].ToString();
                Div3.Visible = true;

                HiddenField2.Value = OP_Mode.Dtv[1]["ID"].ToString();
                Label2.Text = OP_Mode.Dtv[1]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox2.Text = OP_Mode.Dtv[1]["ipercent"].ToString();
                Div2.Visible = true;

                HiddenField1.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox1.Text = OP_Mode.Dtv[0]["ipercent"].ToString();
                Div1.Visible = true;

            }
            else if (OP_Mode.Dtv.Count == 5)
            {
                Div6.Visible = false;

                HiddenField5.Value = OP_Mode.Dtv[4]["ID"].ToString();
                Label5.Text = OP_Mode.Dtv[4]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox5.Text = OP_Mode.Dtv[4]["ipercent"].ToString();
                Div5.Visible = true;

                HiddenField4.Value = OP_Mode.Dtv[3]["ID"].ToString();
                Label4.Text = OP_Mode.Dtv[3]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox4.Text = OP_Mode.Dtv[3]["ipercent"].ToString();
                Div4.Visible = true;

                HiddenField3.Value = OP_Mode.Dtv[2]["ID"].ToString();
                Label3.Text = OP_Mode.Dtv[2]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox3.Text = OP_Mode.Dtv[2]["ipercent"].ToString();
                Div3.Visible = true;

                HiddenField2.Value = OP_Mode.Dtv[1]["ID"].ToString();
                Label2.Text = OP_Mode.Dtv[1]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox2.Text = OP_Mode.Dtv[1]["ipercent"].ToString();
                Div2.Visible = true;

                HiddenField1.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox1.Text = OP_Mode.Dtv[0]["ipercent"].ToString();
                Div1.Visible = true;
            }
            else if (OP_Mode.Dtv.Count == 4)
            {
                Div6.Visible = false;

                Div5.Visible = false;

                HiddenField4.Value = OP_Mode.Dtv[3]["ID"].ToString();
                Label4.Text = OP_Mode.Dtv[3]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox4.Text = OP_Mode.Dtv[3]["ipercent"].ToString();
                Div4.Visible = true;

                HiddenField3.Value = OP_Mode.Dtv[2]["ID"].ToString();
                Label3.Text = OP_Mode.Dtv[2]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox3.Text = OP_Mode.Dtv[2]["ipercent"].ToString();
                Div3.Visible = true;

                HiddenField2.Value = OP_Mode.Dtv[1]["ID"].ToString();
                Label2.Text = OP_Mode.Dtv[1]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox2.Text = OP_Mode.Dtv[1]["ipercent"].ToString();
                Div2.Visible = true;

                HiddenField1.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox1.Text = OP_Mode.Dtv[0]["ipercent"].ToString();
                Div1.Visible = true;
            }
            else if (OP_Mode.Dtv.Count == 3)
            {
                Div6.Visible = false;

                Div5.Visible = false;

                Div4.Visible = false;

                HiddenField3.Value = OP_Mode.Dtv[2]["ID"].ToString();
                Label3.Text = OP_Mode.Dtv[2]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox3.Text = OP_Mode.Dtv[2]["ipercent"].ToString();
                Div3.Visible = true;

                HiddenField2.Value = OP_Mode.Dtv[1]["ID"].ToString();
                Label2.Text = OP_Mode.Dtv[1]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox2.Text = OP_Mode.Dtv[1]["ipercent"].ToString();
                Div2.Visible = true;

                HiddenField1.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox1.Text = OP_Mode.Dtv[0]["ipercent"].ToString();
                Div1.Visible = true;
            }
            else if (OP_Mode.Dtv.Count == 2)
            {
                Div6.Visible = false;

                Div5.Visible = false;

                Div4.Visible = false;

                Div3.Visible = false;

                HiddenField2.Value = OP_Mode.Dtv[1]["ID"].ToString();
                Label2.Text = OP_Mode.Dtv[1]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox2.Text = OP_Mode.Dtv[1]["ipercent"].ToString();
                Div2.Visible = true;

                HiddenField1.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox1.Text = OP_Mode.Dtv[0]["ipercent"].ToString();
                Div1.Visible = true;
            }
            else if (OP_Mode.Dtv.Count == 1)
            {
                Div6.Visible = false;

                Div5.Visible = false;

                Div4.Visible = false;

                Div3.Visible = false;

                Div2.Visible = false;

                HiddenField1.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Label1.Text = OP_Mode.Dtv[0]["CName"].ToString() + "<h6>请输入占比，不用输入%。</h6>";
                TextBox1.Text = OP_Mode.Dtv[0]["ipercent"].ToString();
                Div1.Visible = true;
            }
        }
    }

    /// <summary>
    /// 数据保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    private void SaveData()
    {
        string strSQL = string.Empty;
        int SumPercent = 0;
        if (HiddenField6.Value.Length > 0)
        {
            SumPercent += Convert.ToInt32(TextBox6.Text.Replace("'", ""));
            strSQL += " Update W_GCGD_USERS Set iPercent=" + TextBox6.Text.Replace("'", "") + ",LTime=Getdate() Where ID=" + HiddenField6.Value;
        }
        if (HiddenField5.Value.Length > 0)
        {
            SumPercent += Convert.ToInt32(TextBox5.Text.Replace("'", ""));
            strSQL += " Update W_GCGD_USERS Set iPercent=" + TextBox5.Text.Replace("'", "") + ",LTime=Getdate() Where ID=" + HiddenField5.Value;
        }
        if (HiddenField4.Value.Length > 0)
        {
            SumPercent += Convert.ToInt32(TextBox4.Text.Replace("'", ""));
            strSQL += " Update W_GCGD_USERS Set iPercent=" + TextBox4.Text.Replace("'", "") + ",LTime=Getdate() Where ID=" + HiddenField4.Value;
        }
        if (HiddenField3.Value.Length > 0)
        {
            SumPercent += Convert.ToInt32(TextBox3.Text.Replace("'", ""));
            strSQL += " Update W_GCGD_USERS Set iPercent=" + TextBox3.Text.Replace("'", "") + ",LTime=Getdate() Where ID=" + HiddenField3.Value;
        }
        if (HiddenField2.Value.Length > 0)
        {
            SumPercent += Convert.ToInt32(TextBox2.Text.Replace("'", ""));
            strSQL += " Update W_GCGD_USERS Set iPercent=" + TextBox2.Text.Replace("'", "") + ",LTime=Getdate() Where ID=" + HiddenField2.Value;
        }
        if (HiddenField1.Value.Length > 0)
        {
            SumPercent += Convert.ToInt32(TextBox1.Text.Replace("'", ""));
            strSQL += " Update W_GCGD_USERS Set iPercent=" + TextBox1.Text.Replace("'", "") + ",LTime=Getdate() Where ID=" + HiddenField1.Value;
        }

        if (SumPercent != 100)
        {
            MessageBox("占比和必须为100%。<br>请检查后重新填写。");
            return;
        }
        else
        {
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "人员占比保存成功。", "/GDGL/MyGDBXWZ.aspx?ID=" + Request["ID"]);
            }
        }
    }
}