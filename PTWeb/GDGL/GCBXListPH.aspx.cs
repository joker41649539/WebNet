using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCBXListPH : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string LoginID;
            LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
        }
        catch
        {
            MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！", "/Login.aspx");
            return;
        }


        if (!IsPostBack)
        {
            Load_GridView_List();
        }
    }

    #region "GridView_List 读取工程工单 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_List()

    {
        string strTempHtml = string.Empty;

        // 获取GridView排序数据列及排序方向

        //string sortExpression = this.GridView_List.Attributes["SortExpression"];

        //string sortDirection = this.GridView_List.Attributes["SortDirection"];

        string strSQL;
        int iid = 0;
        try
        {
            iid = Convert.ToInt32(Request["ID"]);
        }
        catch
        {
            MessageBox("", "参数错误。", "./");
            return;
        }
        strSQL = "Select distinct W_GCGD2.ID ID,(Select top 1 USERS from W_GCGD_USERS where GCDID=W_GCGD1.ID and Charge=1 and Flag=0) ZID,SBBH,SBMC,W_GCGD1.ID IID,GCMC,AZWZ,(Select sum(FS) from W_GCGD_FS where GCMXID=W_GCGD2.ID) ZJD,(Select Count(CNAME) from W_GCGD_USERS,W_GCGD1,W_GCGD2,S_USERINFO where W_GCGD1.GCDH=W_GCGD2.GCDH and GCDID=W_GCGD1.ID and USERS=S_USERINFO.ID and W_GCGD_USERS.Flag=0 and W_GCGD2.ID=" + iid + ") BXRS from W_GCGD1,W_GCGD2,W_GCGD_USERS where azwz =(Select AZWZ from W_GCGD2 where W_GCGD2.ID=" + iid + ") and W_GCGD1.GCDH = (Select GCDH from W_GCGD2 where W_GCGD2.ID=" + iid + ") and W_GCGD2.GCDH=W_GCGD1.GCDH and W_GCGD1.ID=GCDID and USERS=" + DefaultUser + " ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            ///// 设置排序

            //if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            //{strTempHtml

            //    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            //}

            strTempHtml = "<h5>";
            if (OP_Mode.Dtv.Count > 0)
            {
                HiddenField_ZID.Value = OP_Mode.Dtv[0]["ZID"].ToString();
                HiddenField_BXRS.Value = OP_Mode.Dtv[0]["BXRS"].ToString();
                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_GCMC.NavigateUrl = "/GDGL/MyGDBXWZ.aspx?ID=" + OP_Mode.Dtv[0]["IID"].ToString();
                HiddenField_GCID.Value = OP_Mode.Dtv[0]["IID"].ToString();
                Label_AZWZ.Text = OP_Mode.Dtv[0]["AZWZ"].ToString();

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i == 0)
                    {
                        strTempHtml += OP_Mode.Dtv[i]["SBMC"].ToString() + ":<input type=\"checkbox\" name=\"ck\" value=" + OP_Mode.Dtv[i]["ID"].ToString() + " checked=\"checked\" />&nbsp;&nbsp;<a href='/GDGL/GCBX.ASPX?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "'>" + OP_Mode.Dtv[i]["SBBH"].ToString() + "</a>;";
                    }
                    else if (OP_Mode.Dtv[i - 1]["SBMC"].ToString() == OP_Mode.Dtv[i]["SBMC"].ToString())
                    {
                        strTempHtml += "<input type=\"checkbox\" name=\"ck\" value=" + OP_Mode.Dtv[i]["ID"].ToString() + " checked=\"checked\" />&nbsp;&nbsp;<a href='/GDGL/GCBX.ASPX?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "'>" + OP_Mode.Dtv[i]["SBBH"].ToString() + "</a>;";
                    }
                    else
                    {
                        strTempHtml += "<br/>" + OP_Mode.Dtv[i]["SBMC"].ToString() + ":<input type=\"checkbox\" name=\"ck\" value=" + OP_Mode.Dtv[i]["ID"].ToString() + " checked=\"checked\" />&nbsp;&nbsp;<a href='/GDGL/GCBX.ASPX?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "'>" + OP_Mode.Dtv[i]["SBBH"].ToString() + "</a>;";
                    }
                }
            }
            strTempHtml += "</h5>";

            DivList.InnerHtml = strTempHtml;

            //this.GridView_List.DataSource = OP_Mode.Dtv;

            //this.GridView_List.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_List_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        //if (sortExpression == this.GridView_List.Attributes["SortExpression"])

        //{

        //    //获得下一次的排序状态

        //    sortDirection = (this.GridView_List.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        //}

        //// 重新设定GridView排序数据列及排序方向

        //this.GridView_List.Attributes["SortExpression"] = sortExpression;

        //this.GridView_List.Attributes["SortDirection"] = sortDirection;

        Load_GridView_List();

    }

    protected void GridView_List_RowEditing(object sender, GridViewEditEventArgs e)

    {

        //GridView_List.EditIndex = e.NewEditIndex;

        //GridView_List.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_List();

    }

    protected void GridView_List_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        //GridView_List.SelectedIndex = -1;

        //GridView_List.EditIndex = -1;

        Load_GridView_List();

    }

    protected void GridView_List_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_List_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        //if (e.Row.RowType == DataControlRowType.DataRow)

        //{

        //    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

        //    {

        //        ((LinkButton)e.Row.Cells[4].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[0].Text + "\" 】吗?')");

        //    }

        //}

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_List_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {


    }

    protected void GridView_List_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {
        //string strURL = "/GDGL/GCBX.ASPX?ID=" + GridView_List.DataKeys[e.NewSelectedIndex].Value.ToString();
        //Response.Redirect(strURL);
    }

    #endregion


    /// <summary>
    /// 保存提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {/// 主安装 默认60%

        if (HiddenField_ZID.Value != DefaultUser)
        {
            MessageBox("","您非项目负责人，无需填写。");
            return;
        }
        else
        {
            int iRadioValue = Convert.ToInt32(RadioButtonList1.SelectedValue);
            if (iRadioValue <= 0)
            {
                MessageBox("", "请选择完成进度。");
            }
            else
            {
                //iZAZFS = iZAZFS * Convert.ToInt32(iRadioValue) / 100;
                SaveProgress(iRadioValue);
            }
        }
    }
    protected void LinkButton_Save_Click1(object sender, EventArgs e)
    {/// 辅安装 默认40%

        int iZAZFS = 40;

        //if (Convert.ToInt16(HiddenField_BXRS.Value) == 2)
        //{/// 双人安装默认为 55%-45%
        //    iZAZFS = 45;
        //}
        //else if (Convert.ToInt16(HiddenField_BXRS.Value) == 3)
        //{/// 三人安装默认为 4-3-3
        //    iZAZFS = 30;
        //}
        //else if (Convert.ToInt16(HiddenField_BXRS.Value) == 1)
        //{/// 单人安装为 100%
        //    iZAZFS = 0;
        //}
        //else if (Convert.ToInt16(HiddenField_BXRS.Value) > 3)
        //{
        //    MessageBox("", "同时布线人数过多，请联系相关负责人。");
        //    return;
        //}

        int iRadioValue = Convert.ToInt32(RadioButtonList1.SelectedValue);
        if (iRadioValue <= 0)
        {
            MessageBox("", "请选择完成进度。");
        }
        else
        {
            //iZAZFS = iZAZFS * Convert.ToInt32(iRadioValue) / 100;
            SaveProgress(iRadioValue);
        }
    }

    /// <summary>
    /// 保存工程进度
    /// </summary>
    private void SaveProgress(int iAZPercent)
    {
        string strSQL = string.Empty;
        string strTempMSG = string.Empty;
        int iGCMXID = 0;
        /// 获得设备明细ID
        string[] iCK = Request.Form["ck"].Split(',');

        ///备注信息
        string strRemark = TextBox_Remark.Text.Replace("'", "");

        if (iCK.Length < 1)
        {
            MessageBox("", "没有要操作的设备，请选择设备。");
            return;
        }

        for (int i = 0; i < iCK.Length; i++)
        {
            iGCMXID = Convert.ToInt32(iCK[i]);
            // 删除自己原积分
            strSQL += " Delete from W_GCGD_FS where GCMXID=" + iGCMXID;
            // 插入积分
            strSQL += " Insert into W_GCGD_FS (GCMXID,USERID,FS,Remark) Select " + iGCMXID + ",USERS,ipercent*" + iAZPercent + "/100,'" + strRemark + "' from W_GCGD_USERS where Flag=0 and GCDID=" + HiddenField_GCID.Value;
            /// 插入记录表，后期统计使用
            strSQL += " Insert into W_GCGD_FS_BXList (GCMXID,UserID,FS,Remark) Select " + iGCMXID + ",USERS,ipercent*" + iAZPercent + "/100,'" + strRemark + "' from W_GCGD_USERS where Flag=0 and GCDID=" + HiddenField_GCID.Value;
        }

        if (strSQL.Length > 0)
        {
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "布线信息填写成功。", "/GDGL/MyGDBXWZ.aspx?ID=" + HiddenField_GCID.Value);
            }
            else
            {
                MessageBox("", "布线信息填写失败。<br>错误：" + OP_Mode.strErrMsg);
            }
        }

        //foreach (GridViewRow item in GridView_List.Rows)
        //{
        //    if (item.RowType != DataControlRowType.Header)
        //    {
        //        if ((item.FindControl("CheckBox1") as CheckBox).Checked)
        //        {
        //            iGCMXID = Convert.ToInt32(GridView_List.DataKeys[Convert.ToInt32(item.RowIndex)].Value);
        //            // strSQL += " Delete from W_GCGD_USERS where id=" + GridView_List.DataKeys[Convert.ToInt32(item.RowIndex)].Value.ToString();
        //            //strTempMSG += GridView2.DataKeys[Convert.ToInt32(item.RowIndex)].Value.ToString() + ";";//cells[0]表示id在gridview中的第一列
        //            // strTempMSG += GridView_List.DataKeys[Convert.ToInt32(item.RowIndex)].Value.ToString() + ";";
        //            // 删除自己原积分
        //            strSQL += " Delete from W_GCGD_FS where GCMXID=" + iGCMXID + " and userID=" + DefaultUser;

        //            // 更新所有人的积分
        //            strSQL += " Update W_GCGD_FS set FS=" + RadioButtonList1.SelectedValue.ToString() + "/(Select count(USERID)+1 from W_GCGD_FS where GCMXID=" + iGCMXID + " and USERID!=" + DefaultUser + ") where GCMXID=" + iGCMXID;
        //            // 插入积分
        //            strSQL += " Insert into W_GCGD_FS (GCMXID,USERID,FS) values (" + iGCMXID + "," + DefaultUser + "," + RadioButtonList1.SelectedValue.ToString() + "/(Select count(USERID)+1 from W_GCGD_FS where GCMXID=" + iGCMXID + " and USERID!=" + DefaultUser + ")) ";
        //        }
        //    }
        //}
        //if (strSQL.Length > 0)
        //{
        //    if (OP_Mode.SQLRUN(strSQL))
        //    {/// 积分添加成功后重新加载页面
        //        Load_GridView_List();
        //        /// 记录积分记录
        //     //   strSQL = "Insert into W_GCGD_FS_BXlist (GCMXID,FS,USERID) Select GCMXID,FS,";

        //        RadioButtonList1.SelectedValue = null;
        //    }
        //    else
        //    {
        //        MessageBox("", "进度信息保存错误：<br>" + OP_Mode.strErrMsg);
        //    }
        //}

    }

}