using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCGDByUser : PageBase
{
    public string strSQL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUser();
        }
    }

    private void LoadUser()
    {
        /// 查询工程和布线所有人员名单。
        strSQL = "SELECT S_USERINFO.ID,(CNAME + ' ['+cast((Select count(id) from W_GCGD_USERS where USERS=S_USERINFO.ID) as varchar)+']') CName ,SSDZ from S_USERINFO,S_YH_QXZ where FLAG=0  and S_USERINFO.id=S_YH_QXZ.USERID and (QXZID =3 or QXZID=4) group by S_USERINFO.ID,CNAME,SSDZ order by S_USERINFO.ID";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView1.DataSource = OP_Mode.Dtv;
                GridView1.DataBind();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            LoadGCMCByUserID(Convert.ToInt32(GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value));
            // MessageBox("", "用户ID号：" + GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            //string strURL = "/Bug/BugEdit.ASPX?ID=" + GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            //Response.Redirect(strURL);
        }
    }

    /// <summary>
    /// 依据用户编号 加载工程信息
    /// </summary>
    /// <param name="UserID"></param>
    private void LoadGCMCByUserID(int UserID)
    {
        HiddenField_UserID.Value = UserID.ToString();
        strSQL = "Select SGDH,GCMC,GCDD,flag,'True' CheckTrue,W_GCGD_USERS.ID from W_GCGD_USERS,W_GCGD1 where USERS=" + UserID + " and GCDID=W_GCGD1.ID order by flag,SGDH";
        if (OP_Mode.SQLRUN(strSQL, "gcbh"))
        {
            if (OP_Mode.Dtv1.Count > 0)
            {
                GridView2.DataSource = OP_Mode.Dtv1;
                GridView2.DataBind();
                GridView2.Visible = true;
                LinkButton_Save.Visible = true;
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.Visible = false;
            }
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        string strTempMSG = string.Empty;
        strSQL = string.Empty;
        foreach (GridViewRow item in GridView2.Rows)
        {
            if (item.RowType != DataControlRowType.Header)
            {
                if (!(item.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    strSQL += " Delete from W_GCGD_USERS where id=" + GridView2.DataKeys[Convert.ToInt32(item.RowIndex)].Value.ToString();
                    //strTempMSG += GridView2.DataKeys[Convert.ToInt32(item.RowIndex)].Value.ToString() + ";";//cells[0]表示id在gridview中的第一列
                    //strTempMSG += item.RowIndex.ToString() + ";";
                }
            }
        }
        if (strSQL.Length > 0)
        {
            if (OP_Mode.SQLRUN(strSQL))
            { /// 数据库操作成功
                LoadGCMCByUserID(Convert.ToInt32(HiddenField_UserID.Value));
            }
        }
        //  MessageBox("", "选中：" + strSQL);
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView2.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView2.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Edit")
        //{
        //    LinkButton_Save.Text = "Edit?";
        //    //GridView2.EditIndex = Convert.ToInt32(e.CommandArgument);
        //}
        // MessageBox("", "提示：" + e.CommandName);
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {

        // MessageBox("", "提示：" + "编辑？");
    }
}