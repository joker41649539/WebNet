﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_MyClass : PageBaseXMFight
{

    public int PStudentID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户首主界面
        // 1、判断是否有CODE。 有CODE 依据CODE获取用户信息，并且写入COOKE。
        if (!IsPostBack)
        {
            string strURL = Request.Url.AbsoluteUri;
            if (strURL.IndexOf("localhost") > -1)
            {/// 测试程序，默认ID
                LoadUserInfo(6);
            }
            else
            {
                WeChatLoad();// 
            }

            LoadMSG();
            LoadStudentsByOpID();
            if (DefaultUser == "6")
            {
                LoadClassTime();
                Vied_Text.Visible = true;
            }
            else
            {
                CheckBoxList1.Visible = false;
                Vied_Text.Visible = false;
            }
           // LoadClassList();

            //  MessageBox("", "MyClass|UID：" + Request.Cookies["WeChat_XMFight"]["USERID"].ToString() + " OID:" + Request.Cookies["WeChat_XMFight"]["COPENID"].ToString());
        }
    }

    private void LoadClassTime()
    {
        int SID = 0;
        try
        {
            SID = Convert.ToInt32(Request["SID"]);
        }
        catch
        {

        }
        string strSQL = "Select XMFight_ClassTime.ID,'&nbsp;&nbsp;'+cast(XMFight_ClassTime.Week as char(1)) +' '+CONVERT(varchar(100), STime, 24) as Name,isnull(XMFight_Class_Student.ID,0) checked from XMFight_ClassTime left join XMFight_Class_Student on ClassID=XMFight_ClassTime.ID and StudentID=" + SID.ToString() + " where Flag=0";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                CheckBoxList1.Visible = true;
                CheckBoxList1.DataSource = OP_Mode.Dtv;
                CheckBoxList1.DataTextField = "Name";
                CheckBoxList1.DataValueField = "ID";
                CheckBoxList1.DataBind();

                int i = -1;
                foreach (ListItem litem in CheckBoxList1.Items)
                {
                    i++;
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["checked"]) > 0)
                    {
                        litem.Selected = true;
                    }
                    else
                    {
                        litem.Selected = false;
                    }
                }
            }
        }

    }

    /// <summary>
    /// 加载公告信息
    /// </summary>
    private void LoadMSG()
    {
        string TempHtml = string.Empty;
        string strSQL = "SELECT top 1 * FROM XMFIGHT_MSG WHERE GETDATE() BETWEEN STIME AND ETIME";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                TempHtml += "<h5>" + OP_Mode.Dtv[0]["Title"].ToString() + "</h5>";
                TempHtml += "<h6>&nbsp;&nbsp;" + OP_Mode.Dtv[0]["MsgContent"].ToString() + "</h6>";
            }
        }
        if (TempHtml.Length > 0)
        {
            Div_AllMsg.InnerHtml = TempHtml;
            Div_AllMsg.Visible = true;
        }
        else
        {
            Div_AllMsg.Visible = false;
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
            if (Request.Cookies["WeChat_XMFight"]["COPENID"] != null)
            {
                strOPID = Request.Cookies["WeChat_XMFight"]["COPENID"];
            }
            if (strOPID.Length < 1)
            {
                return;
            }
            // MessageBox("", strOPID);
            int iSID = 0;

            try
            {
                iSID = Convert.ToInt32(Request["SID"]);
            }
            catch
            {

            }
            string strSQL = string.Empty;
            if (iSID > 0 & DefaultUser == "6")
            {
                strSQL = "Select ID,Name,Sex from XMFight_Student where ID =" + iSID;
            }
            else
            {
                strSQL = "Select ID,Name,Sex from XMFight_Student where OpenID like ('%" + strOPID + "%')";
            }
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
                    PStudentID = Convert.ToInt32(OP_Mode.Dtv[0]["ID"].ToString());
                }
            }
        }
        catch
        {

        }

        if (Convert.ToInt32(Request["SID"]) > 0)
        {
            PStudentID = Convert.ToInt32(Request["SID"]);
        }
        //else
        //{
        //    if (Request.Cookies["WeChat_XMFight"]["STudentID"] != null)
        //    {
        //        PStudentID = Convert.ToInt32(Request.Cookies["WeChat_XMFight"]["STudentID"]);
        //    }
        //}

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
        LoadData(PStudentID);
        LoadMyClassTime(PStudentID);
        Load_GridView1(PStudentID);
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
        strSQL += " ,isnull((Select top 1 LTime from XMFight_Class_Record where ICount>0 and StudentID=a.ID order by CTime desc),'2021-01-01') EndTime";
        strSQL += " from XMFight_Student a,";
        strSQL += " (Select sum(ICount) sumClassCount, MAX(CTime) LastClassTime, StudentID from XMFight_Class_Record group by StudentID) as b";
        strSQL += " where a.ID = b.StudentID and a.id=" + iStudentID;
        strSQL += " order by Name";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_Sum.Text = Convert.ToDouble(OP_Mode.Dtv[0]["sumClassCount"]).ToString("G0");
                Label_KG.Text = OP_Mode.Dtv[0]["Absenteeism"].ToString();
                Label_QJ.Text = OP_Mode.Dtv[0]["Leave"].ToString();
                Label_CBJ.Text = OP_Mode.Dtv[0]["SumBance"].ToString();
                Label_KCYXQZ.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["EndTime"]).ToString("yyyy-MM-dd");
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

        strSQL = "Select top 100 *,case  when  vidourl is NULL then '' else '查阅视频' end NewText from XMFight_Class_Record where StudentID=" + iStudentID + " order by ctime desc";

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }

            this.GridView1.DataSource = OP_Mode.Dtv;

            this.GridView1.DataBind();

            if (OP_Mode.Dtv.Count > 0)
            {/// 存储ID最大值
                HiddenField_ListMaxID.Value = OP_Mode.Dtv[0]["ID"].ToString();
                TextBox1.Text = OP_Mode.Dtv[0]["VidoUrl"].ToString();
                //TextBox1.Text = OP_Mode.Dtv[0]["ID"].ToString();
            }
        }
        else
        {
            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);
            return;
        }

    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)

    {
        if (Convert.ToInt32(Request["SID"]) > 0)
        {
            PStudentID = Convert.ToInt32(Request["SID"]);
        }
        else
        {

            if (Request.Cookies["WeChat_XMFight"]["STudentID"] != null)
            {
                PStudentID = Convert.ToInt32(Request.Cookies["WeChat_XMFight"]["STudentID"]);
            }
        }

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

        Load_GridView1(PStudentID);

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        //if (Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value) > 0)
        //{
        //    Response.Redirect("https://www.meipian.cn/wap/video-work/view/index.html#/?id=9k5td9y&type=6&share_to=copy_link&user_id=73058088&uuid=8180c5331f6b441eca60031475545ad6&share_depth=1&first_share_uid=73058088&utm_medium=meipian_android&share_user_mpuuid=eebea5e7536df841470f212d37a81bf7", false);
        //    ///DeleteRecord(Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value));
        //}
        GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SID = 0;
        string strSQL = string.Empty;
        try
        {
            SID = Convert.ToInt32(Request["SID"]);
            if (SID > 0)
            {
                strSQL = " Delete XMFight_Class_Student Where StudentID=" + SID + " ";
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        strSQL += " Insert into XMFight_Class_Student (ClassID,StudentID) values (" + item.Value + "," + SID + ") ";
                    }
                    //else
                    //{
                    //    strSQL += " Delete XMFight_Class_Student Where ClassID=" + item.Value + " and StudentID=" + SID + " ";
                    //}
                }
                if (strSQL.Length > 0)
                {
                    if (OP_Mode.SQLRUN(strSQL))
                    {
                        MessageBox("", "课程安排成功。", Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        MessageBox("", "课程安排失败。<br/>错误：" + OP_Mode.strErrMsg);
                    }
                }
            }
        }
        catch
        {
            MessageBox("", "用户ID获取失败。");
        }

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Request["SID"]) > 0)
            {
                PStudentID = Convert.ToInt32(Request["SID"]);
            }
            else
            {
                if (Request.Cookies["WeChat_XMFight"]["STudentID"] != null)
                {
                    PStudentID = Convert.ToInt32(Request.Cookies["WeChat_XMFight"]["STudentID"]);
                }
            }

            //int SID = 0;
            //SID = Convert.ToInt32(Request.Cookies["WeChat_XMFight"]["USERID"]);
            int IID = Convert.ToInt32(HiddenField_ListMaxID.Value);
            string VidoURL = TextBox1.Text.Replace("'", "");
            string[] airOpenid;
            string cName = string.Empty;
            if (IID > 0)
            {
                string strSQL = "Update XMFight_Class_Record set VidoUrl='" + VidoURL + "' where ID= " + IID;
                strSQL += " Select OpenID,Name from XMFight_Student where id=" + PStudentID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        airOpenid = OP_Mode.Dtv[0]["OpenID"].ToString().Split(';');
                        cName = OP_Mode.Dtv[0]["Name"].ToString();
                        for (int i = 0; i < airOpenid.Length; i++)
                        {
                            /// 推送视频消息反馈
                            SendFKMsg(airOpenid[i], "您孩子 [" + cName + "] 本期上课视频已经生成。分享朋友圈立即享受10元储备金优惠。", "散打", System.DateTime.Now.ToString("yyyy-MM-dd"), "点击查看后可以分享朋友圈，每次分享后可联系工作人员增加10元储备金。储备金可报名直接抵扣报名费。", VidoURL);
                        }
                        MessageBox("", "视频网址保存成功。", Request.RawUrl);
                    }
                }
                else
                {
                    MessageBox("", "失败：" + strSQL);
                }
            }
        }
        catch
        {

        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            try
            {
                string strOPID = String.Empty;
                if (Request.Cookies["WeChat_XMFight"]["COPENID"] != null)
                {
                    strOPID = Request.Cookies["WeChat_XMFight"]["COPENID"];
                }
                if (strOPID.Length > 0)
                {
                    int rowNum = int.Parse(e.CommandArgument.ToString());
                    string strUrl = GridView1.DataKeys[rowNum][1].ToString();

                    if (strUrl.Length > 0 & strOPID.Length > 0)
                    {
                        /// 推送视频消息反馈

                        SendFKMsg(strOPID, "您孩子 [" + GridView1.Rows[rowNum].Cells[0].Text.Substring(0, 14) + "] 上课视频已经生成。分享朋友圈立即享受10元储备金优惠。", "散打", System.DateTime.Now.ToString("yyyy-MM-dd"), "点击查看后可以分享朋友圈，每次分享后可联系工作人员增加10元储备金。储备金可报名直接抵扣报名费。", strUrl);
                        MessageBox("您孩子 [" + GridView1.Rows[rowNum].Cells[0].Text.Substring(0, 14) + "] 上课视频已成功推送给您，请打开公众号查阅。欢迎分享。");
                    }
                }
            }
            catch
            {
                MessageBox("OpenID获取错误，无法查阅视频。");
            }
        }
    }
}