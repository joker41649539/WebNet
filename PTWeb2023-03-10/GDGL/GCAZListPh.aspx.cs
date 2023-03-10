using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GCAZListPh : PageBase
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

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_List.Attributes["SortExpression"];

        string sortDirection = this.GridView_List.Attributes["SortDirection"];

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
        strSQL = "Select distinct W_GCGD2.ID ID,GCMC,AZWZ,SBBH,W_GCGD1.ID IID,AZFS,(Select CNAME+';' from W_GCGD_FS,S_USERINFO where GCMXID=W_GCGD2.ID and AZFS>=50 and AZFS>0 and USERID=S_USERINFO.ID for xml path('')) ZAZ,(Select CNAME+';' from W_GCGD_FS,S_USERINFO where GCMXID=W_GCGD2.ID and AZFS<50 and AZFS>0 and USERID=S_USERINFO.ID for xml path('')) FAZ  from W_GCGD1,W_GCGD2,W_GCGD_USERS where azwz =(Select AZWZ from W_GCGD2 where W_GCGD2.ID=" + iid + ") and W_GCGD1.GCDH = (Select GCDH from W_GCGD2 where W_GCGD2.ID=" + iid + ") and W_GCGD2.GCDH=W_GCGD1.GCDH and W_GCGD1.ID=GCDID and USERS=" + DefaultUser + " ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }
            /// 设置翻页层始终显示
            if (OP_Mode.Dtv.Count > 0)

            {

                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_GCMC.NavigateUrl = "/GDGL/MyGDAZWZ.aspx?ID=" + OP_Mode.Dtv[0]["IID"].ToString();
                Label_AZWZ.Text = OP_Mode.Dtv[0]["AZWZ"].ToString();

            }



            this.GridView_List.DataSource = OP_Mode.Dtv;

            this.GridView_List.DataBind();

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

        if (sortExpression == this.GridView_List.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_List.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_List.Attributes["SortExpression"] = sortExpression;

        this.GridView_List.Attributes["SortDirection"] = sortDirection;

        Load_GridView_List();

    }

    protected void GridView_List_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {// 主安装
            SaveMain(Convert.ToInt32(GridView_List.DataKeys[Convert.ToInt32(e.CommandArgument)].Value));
            //  MessageBox("", "主装" + e.CommandName + GridView_List.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        }
        else if (e.CommandName == "New")
        {/// 辅助安装
            SaveSecendary(Convert.ToInt32(GridView_List.DataKeys[Convert.ToInt32(e.CommandArgument)].Value));
        }
        else if (e.CommandName == "Select")
        {/// 取消安装
            SaveCancel(Convert.ToInt32(GridView_List.DataKeys[Convert.ToInt32(e.CommandArgument)].Value));
        }
        else if (e.CommandName == "update")
        {/// 进入明细
            string strURL = "/GDGL/GCAZ.ASPX?ID=" + GridView_List.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            Response.Redirect(strURL);
        }
    }

    /// <summary>
    /// 主安装操作
    /// </summary>
    /// <param name="MXID"></param>
    private void SaveMain(int MXID)
    { ///1、判断累计多少积分，其余剩下超过50%的全部算主安装
        string strSQL = "Select ID from W_GCGD_FS where GCMXID=" + MXID + " and AZFS>0 and (USERID=" + DefaultUser + " or AZFS>49) "; // 判断是否安装过了。

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                MessageBox("", "该设备您已安装过,或者已经有主装。");
                return;
            }
            else
            {
                strSQL = "insert into W_GCGD_FS(GCMXID,USERID,AZFS) Select " + MXID + "," + DefaultUser + ",100-isnull(sum(AZFS),0) from W_GCGD_FS where GCMXID=" + MXID;
                if (!OP_Mode.SQLRUN(strSQL))
                { /// 主装填写失败
                    MessageBox("", "设备安装失败，请重试。<br/>错误:" + OP_Mode.strErrMsg);
                    return;
                }
                /// 刷新页面
                Load_GridView_List();
            }
        }

    }

    /// <summary>
    /// 辅助安装操作
    /// </summary>
    /// <param name="MXID"></param>
    private void SaveSecendary(int MXID)
    { /// 1、每人次为10%，如果超过100%，则从最多的人处扣除。
        int iFZFS = 10;// 设置辅助安装默认分数为10分；
        string strSQL = "Select ID from W_GCGD_FS where USERID=" + DefaultUser + " and GCMXID=" + MXID; // 判断是否安装过了。

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                MessageBox("", "该设备您已安装过，请勿重复填写。");
                return;
            }
            else
            {
                strSQL = " insert into W_GCGD_FS(GCMXID,USERID,AZFS) values (" + MXID + "," + DefaultUser + "," + iFZFS + ")";
                // 更新主装分数 主安装扣除指定分数
                strSQL += " update W_GCGD_FS set AZFS=AZFS - " + iFZFS + " where ID=( Select top 1 ID from W_GCGD_FS where gcmxid=" + MXID + " and USERID!=" + DefaultUser + " and AZFS>49 order by azfs desc)";


                if (!OP_Mode.SQLRUN(strSQL))
                { /// 主装填写失败
                    MessageBox("", "设备安装失败，请重试。<br/>错误:" + OP_Mode.strErrMsg);
                    return;
                }
                /// 刷新数据
                Load_GridView_List();
            }
        }
    }

    /// <summary>
    /// 取消安装操作
    /// </summary>
    /// <param name="MXID"></param>
    private void SaveCancel(int MXID)
    { // 删除自己的安装，如有主装，则百分比添加给主装
        string strSQL = string.Empty;


        // 取消辅装后，将自己的分数给主装，如无主装则不添加。 百分比>49的为主装
        strSQL += " update W_GCGD_FS set AZFS=AZFS + ISNULL((Select sum(azfs) from W_GCGD_FS where GCMXID=" + MXID + " and USERID=" + DefaultUser + "),0) where ID=( Select top 1 ID from W_GCGD_FS where gcmxid=" + MXID + " and USERID!=" + DefaultUser + " and AZFS>49 order by azfs desc)";
        strSQL += " Delete from W_GCGD_FS where USERID=" + DefaultUser + " and GCMXID=" + MXID;

        if (!OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "设备安装删除失败，请重试。<br/>错误:" + OP_Mode.strErrMsg);
            return;
        }
        /// 刷新数据
        Load_GridView_List();
    }

    #endregion


    protected void GridView_List_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}