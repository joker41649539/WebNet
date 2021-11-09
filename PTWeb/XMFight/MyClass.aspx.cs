using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_MyClass : PageBaseXMFight
{
    public int iUserID = 16;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudentsByOpID();
            //  LoadClassList();
        }
    }

    private void LoadMyClassTime(int iStudentID)
    {
        string strTempDiv = string.Empty;
        string strSQL = "Select XMFight_ClassTime.* from XMFight_Class_Student,XMFight_ClassTime where classid=XMFight_ClassTime.ID and Flag=0 and studentid=" + iStudentID + " order by Week";
        if (OP_Mode.SQLRUN(strSQL))
        {
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            {
                strTempDiv += "  <div class=\"grid2\">";
                strTempDiv += "     <span class=\"blue\">";
                strTempDiv += "         <i class=\"icon-twitter-sign icon-2x blue\"></i>";
                strTempDiv += "         &nbsp; 每个&nbsp;" + NumtoCHWeek(Convert.ToInt32(OP_Mode.Dtv[i]["Week"]));
                strTempDiv += "     </span>";
                strTempDiv += "     <h4 class=\"bigger pull-right\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + "</h4>";
                strTempDiv += " </div>";
            }
            if (strTempDiv.Length > 0)
            {
                Div_MyClassTime.InnerHtml = strTempDiv;
                Div_MyClassTime.Visible = true;
            }
        }
    }

    private void LoadStudentsByOpID()
    {
        string strOPID = string.Empty;
        string strTempDiv = string.Empty;
        try
        {
            strOPID = Request.Cookies["WeChat_XMFight"]["COPENID"];
            // MessageBox("", strOPID);
            string strSQL = "Select ID,Name,Sex from XMFight_Student where OpenID like ('%" + strOPID + "%')";
            if (OP_Mode.SQLRUN(strSQL))
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["sex"]) == 1)
                    {/// 男孩蓝色标签
                        strTempDiv += " <a href=\"?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-primary\">" + OP_Mode.Dtv[i]["Name"].ToString() + "</a>";
                    }
                    else
                    {// 女孩紫色标签
                        strTempDiv += " <a href=\"?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-pink\">" + OP_Mode.Dtv[i]["Name"].ToString() + "</a>";
                    }
                    /// 赋值ID
                    iUserID = Convert.ToInt32(OP_Mode.Dtv[0]["ID"].ToString());
                }
            }
            if (Convert.ToInt32(Request["SID"]) > 0)
            {
                iUserID = Convert.ToInt32(Request["SID"]);
            }
        }
        catch
        {

        }

        if (strTempDiv.Length > 0)
        {
            Div_Students.InnerHtml = strTempDiv;
            Div_Students.Visible = true;

        }
        else
        {
            Div_Students.Visible = false;
        }
        /// 加载并绑定用户信息
        LoadData(iUserID);
        LoadMyClassTime(iUserID);
        Load_GridView1(iUserID);
    }

    /// <summary>
    /// 依据学生ID获取学生信息
    /// </summary>
    /// <param name="iStudentID"></param>
    private void LoadData(int iStudentID)
    {
        string strSQL = string.Empty;

        strSQL = " Select ID, Name, Sex, Remark, Tel, BrithDay, datediff(year, BrithDay, getdate()) age,HeadImg";
        strSQL += " ,sumClassCount,LastClassTime,";
        strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=2 and StudentID = a.ID),0) Leave,";
        strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=3 and StudentID = a.ID),0) Absenteeism,";
        strSQL += " isnull((Select sum(Bance) from XMFight_reserve where StudentID=a.ID),0) SumBance";
        strSQL += " from XMFight_Student a,";
        strSQL += " (Select sum(ICount) sumClassCount, MAX(CTime) LastClassTime, StudentID from XMFight_Class_Record group by StudentID) as b";
        strSQL += " where a.ID = b.StudentID and a.id=" + iStudentID;
        strSQL += " order by Name";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_Sum.Text = Convert.ToDouble(OP_Mode.Dtv[0]["sumClassCount"]).ToString("G0");
                Label_QJ.Text = OP_Mode.Dtv[0]["Absenteeism"].ToString();
                Label_KG.Text = OP_Mode.Dtv[0]["Leave"].ToString();
                Label_CBJ.Text = OP_Mode.Dtv[0]["SumBance"].ToString();
            }
        }
    }


    /// <summary>
    /// 加载并绑定课程安排
    /// </summary>
    private void LoadClassList()
    {
        string strSQL = string.Empty;

        string strDiv = string.Empty;

        strSQL = "Select * from xmfight_classTime order by week,stime";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strDiv = "<div class=\"col-xs-12 col-sm-10 col-sm-offset-1\">";

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i == 0)
                    {// 输出表头
                        strDiv += "<div class=\"timeline-container\">";
                        strDiv += " <div class=\"timeline-label\">";
                        strDiv += "  <span class=\"label label-primary arrowed-in-right label-lg\">";
                        strDiv += "   <b>" + NumtoCHWeek(Convert.ToInt32(OP_Mode.Dtv[i]["Week"])).ToString() + "</b>";
                        strDiv += "  </span>";
                        strDiv += " </div>";

                        strDiv += " <div class=\"timeline-items\">";

                        /// 同日循环
                        strDiv += "  <div class=\"timeline-item clearfix\">";
                        //strDiv += "    <div class=\"timeline-info\">";
                        //if (Convert.ToInt32(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH")) < 12)
                        //{
                        //    strDiv += "     <h5 class='red'>上&nbsp;午</h5>";
                        //}
                        //else
                        //{
                        //    strDiv += "     <h5 class='green'>下&nbsp;午</h5>";
                        //}
                        //strDiv += "    </div>";

                        strDiv += "    <div class=\"widget-box transparent\">";
                        strDiv += "     <div class=\"widget-header widget-header-small\">";
                        // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                        strDiv += "      <B><span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " &nbsp;[" + OP_Mode.Dtv[i]["Teacher"].ToString() + "]</span></B>&nbsp;"; ///消费金额
                        strDiv += "     </div>";
                        // }
                        //strDiv += "     <div class=\"widget-body\">";
                        //strDiv += "      <div class=\"widget-main\">";
                        //strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["HeadImg"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                        //strDiv += "      </div>";
                        //strDiv += "     </div>";
                        strDiv += "    </div>";
                        //////////////
                    }

                    if (i > 0)
                    {
                        if (OP_Mode.Dtv[i - 1]["Week"].ToString() != OP_Mode.Dtv[i]["Week"].ToString())
                        {
                            strDiv += "    </div>"; /// 上个日期循环结束
                            strDiv += "<div class=\"timeline-container\">";
                            strDiv += " <div class=\"timeline-label\">";
                            strDiv += "  <span class=\"label label-primary arrowed-in-right label-lg\">";
                            strDiv += "   <b>" + NumtoCHWeek(Convert.ToInt32(OP_Mode.Dtv[i]["Week"])).ToString() + "</b>";
                            strDiv += "  </span>";
                            strDiv += " </div>";

                            strDiv += " <div class=\"timeline-items\">";

                            /// 同日循环
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            //strDiv += "    <div class=\"timeline-info\">";
                            //if (Convert.ToInt32(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH")) < 12)
                            //{
                            //    strDiv += "     <h5 class='red'>上&nbsp;午</h5>";
                            //}
                            //else
                            //{
                            //    strDiv += "     <h5 class='green'>下&nbsp;午</h5>";
                            //}
                            //strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "      <B><span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " &nbsp;[" + OP_Mode.Dtv[i]["Teacher"].ToString() + "]</span></B>&nbsp;";
                            strDiv += "     </div>";
                            //  }
                            //strDiv += "     <div class=\"widget-body\">";
                            //strDiv += "      <div class=\"widget-main\">";
                            //strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                            //strDiv += "      </div>";
                            //strDiv += "     </div>";
                            strDiv += "    </div>";
                            //////////////
                        }
                        else
                        {
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            //strDiv += "    <div class=\"timeline-info\">";
                            //if (Convert.ToInt32(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH")) < 12)
                            //{
                            //    strDiv += "     <h5 class='red'>上&nbsp;午</h5>";
                            //}
                            //else
                            //{
                            //    strDiv += "     <h5 class='green'>下&nbsp;午</h5>";
                            //}
                            //strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "      <B><span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " &nbsp;[" + OP_Mode.Dtv[i]["Teacher"].ToString() + "]</span></B>&nbsp;";
                            strDiv += "     </div>";
                            //}
                            //strDiv += "     <div class=\"widget-body\">";
                            //strDiv += "      <div class=\"widget-main\">";
                            //strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                            //strDiv += "      </div>";
                            //strDiv += "     </div>";
                            strDiv += "    </div>";
                        }
                    }

                    if (i == OP_Mode.Dtv.Count - 1)
                    { // 最后一条信息，输出结尾
                        strDiv += "   </div>";
                    }
                }
                if (strDiv.Length > 0)
                {
                    Div_PhotoList.InnerHtml = strDiv;
                    Div_PhotoList.Visible = true;
                }
                else
                {
                    Div_PhotoList.InnerHtml = String.Empty;
                    Div_PhotoList.Visible = false;
                }
            }
            else
            {
                Div_PhotoList.InnerHtml = String.Empty;
                Div_PhotoList.Visible = false;
            }
        }
        else
        {
            MessageBox("", OP_Mode.strErrMsg);
            return;
        }
    }

    private string NumtoCHWeek(int Num)
    {
        string rValue = string.Empty;
        switch (Num)
        {
            case 1:
                rValue = "星期一";
                break;
            case 2:
                rValue = "星期二";
                break;
            case 3:
                rValue = "星期三";
                break;
            case 4:
                rValue = "星期四";
                break;
            case 5:
                rValue = "星期五";
                break;
            case 6:
                rValue = "星期六";
                break;
            case 7:
                rValue = "星期日";
                break;
        }
        return rValue;
    }

    #region "GridView1 读取上课记录 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView1(int iStudentID)

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView1.Attributes["SortExpression"];

        string sortDirection = this.GridView1.Attributes["SortDirection"];

        string strSQL;

        strSQL = "Select top 100 * from XMFight_Class_Record where StudentID=" + iStudentID + " order by ctime desc";

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }

            this.GridView1.DataSource = OP_Mode.Dtv;

            this.GridView1.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView1.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView1.Attributes["SortExpression"] = sortExpression;

        this.GridView1.Attributes["SortDirection"] = sortDirection;

        Load_GridView1(iUserID);

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}