using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView1();
        }
    }

    #region "GridView1 读取工程工单 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView1()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView1.Attributes["SortExpression"];

        string sortDirection = this.GridView1.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView1_Label_tj.Text.Length > 0)

        {

            strSQL = "Select * from(SELECT Top 1000 (Select count(id) from W_GCGD_USERS where GCDID=W_GCGD1.ID) Selected,isnull((Select sum(W_GCGD_FS.FS*W_GCGD2.FS/100 + W_GCGD_FS.AZFS*W_GCGD2.AZFS/100) from W_GCGD_FS,W_GCGD1 as g,W_GCGD2 where GCMXID=W_GCGD2.id and g.GCDH=W_GCGD2.GCDH and (W_GCGD_FS.FS>0 or W_GCGD_FS.AZFS>0) and g.ID=W_GCGD1.ID),0) SumFS,W_GCGD1.*,CNAME FROM W_GCGD1,S_USERINFO where " + this.GridView1_Label_tj.Text.Trim() + " AND ZDRID=S_USERINFO.ID ORDER BY ID desc) a where A.SGDH LIKE 'LX%'";

        }

        else

        {

            strSQL = "Select * from(SELECT Top 1000 (Select count(id) from W_GCGD_USERS where GCDID=W_GCGD1.ID) Selected,isnull((Select sum(W_GCGD_FS.FS*W_GCGD2.FS/100 + W_GCGD_FS.AZFS*W_GCGD2.AZFS/100) from W_GCGD_FS,W_GCGD1 as g,W_GCGD2 where GCMXID=W_GCGD2.id and g.GCDH=W_GCGD2.GCDH and (W_GCGD_FS.FS>0 or W_GCGD_FS.AZFS>0) and g.ID=W_GCGD1.ID),0) SumFS,W_GCGD1.*,CNAME FROM W_GCGD1,S_USERINFO where ZDRID=S_USERINFO.ID ORDER BY W_GCGD1.ID desc) a where A.SGDH LIKE 'LX%'";

        }

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }

            /// 设置翻页层始终显示



            if (OP_Mode.Dtv.Count == 0)

            {

                OP_Mode.Dtv.AddNew();

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

        Load_GridView1();

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

        // 得到该控件

        GridView theGrid = sender as GridView;

        int newPageIndex = 0;

        if (e.NewPageIndex == -3)

        {

            //点击了Go按钮

            TextBox txtNewPageIndex = null;

            //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow

            GridViewRow pagerRow = theGrid.BottomPagerRow;

            if (pagerRow != null)

            {

                //得到text控件

                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;

            }

            if (txtNewPageIndex != null)

            {

                //得到索引

                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;

            }

        }

        else

        {

            //点击了其他的按钮

            newPageIndex = e.NewPageIndex;

        }

        //防止新索引溢出

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;

        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

        //得到新的值

        theGrid.PageIndex = newPageIndex;

        //重新绑定

        Load_GridView1();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView1_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView1_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView1_Label1.Text.Length > 0)

        {

            this.GridView1_Label1.Text += "<b>并且</b><br />";

            this.GridView1_Label_tj.Text += " and ";

        }

        this.GridView1_Label1.Text += this.GridView1_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView1_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView1_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView1_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView1_Label_tj.Text += " " + this.GridView1_DropDownList1.SelectedValue + " " + this.GridView1_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView1_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView1_Label_tj.Text += " " + this.GridView1_DropDownList1.SelectedValue + " " + this.GridView1_DropDownList_SF.SelectedValue + " " + "'" + this.GridView1_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView1_TextBox_CXTJ.Text = string.Empty;

        this.GridView1_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView1_TextBox_CXTJ.Text = string.Empty;

        this.GridView1_Label1.Text = string.Empty;

        this.GridView1_Label_tj.Text = string.Empty;

        this.GridView1_alerts_tj.Visible = false;

        Load_GridView1();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView1();

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");
        GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");
        GridView1.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");
        GridView1.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");
        GridView1.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");
        GridView1.Rows[e.NewSelectedIndex].Cells[5].BackColor = Color.FromName("#CAD3E4");
        GridView1.Rows[e.NewSelectedIndex].Cells[6].BackColor = Color.FromName("#CAD3E4");
        LoadSGRY(Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[0]));
    }

    #endregion

    /// <summary>
    /// 加载施工人员
    /// </summary>
    /// <param name="iID"></param>
    private void LoadSGRY(int iID)
    {
        if (iID > 0)
        {
            /// 施工员和安装员组用户才加载
            string strSQL = "SELECT S_USERINFO.ID,'&nbsp;'+CNAME+' '+ISNULL(SSDZ,'')+'&nbsp;&nbsp;' NAME,(Select count(id) from W_GCGD_USERS where W_GCGD_USERS.USERS=S_USERINFO.ID and GCDID=" + iID + ") Selected from S_USERINFO,S_YH_QXZ where FLAG=0  and S_USERINFO.id=S_YH_QXZ.USERID and QXZID =3 order by cname";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    this.Div1.Visible = true;
                    CheckBoxList1.DataTextField = "NAME";
                    CheckBoxList1.DataValueField = "ID";
                    CheckBoxList1.DataSource = OP_Mode.Dtv;
                    CheckBoxList1.DataBind();
                    string arr1 = string.Empty; ;
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {
                        if (Convert.ToInt32(OP_Mode.Dtv[i]["Selected"]) > 0)
                        {
                            arr1 += OP_Mode.Dtv[i]["ID"] + ",";
                        }
                    }

                    foreach (ListItem lst in this.CheckBoxList1.Items)
                    {
                        string[] arr = arr1.Trim().Split(',');
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i].ToString().Equals(lst.Value))
                            {
                                lst.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    this.Div1.Visible = false;
                }
            }
            else
            {
                MessageBox("", strSQL + " " + OP_Mode.strErrMsg);
            }

            /// 施工员和安装员组用户才加载
            strSQL = "SELECT S_USERINFO.ID,'&nbsp;'+CNAME+' '+ISNULL(SSDZ,'')+'&nbsp;&nbsp;' NAME,(Select count(id) from W_GCGD_USERS where W_GCGD_USERS.USERS=S_USERINFO.ID and GCDID=" + iID + ") Selected from S_USERINFO,S_YH_QXZ where FLAG=0  and S_USERINFO.id=S_YH_QXZ.USERID and QXZID =4 order by cname";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    this.Div1.Visible = true;
                    CheckBoxList2.DataTextField = "NAME";
                    CheckBoxList2.DataValueField = "ID";
                    CheckBoxList2.DataSource = OP_Mode.Dtv;
                    CheckBoxList2.DataBind();
                    string arr1 = string.Empty; ;
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {
                        if (Convert.ToInt32(OP_Mode.Dtv[i]["Selected"]) > 0)
                        {
                            arr1 += OP_Mode.Dtv[i]["ID"] + ",";
                        }
                    }

                    foreach (ListItem lst in this.CheckBoxList2.Items)
                    {
                        string[] arr = arr1.Trim().Split(',');
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i].ToString().Equals(lst.Value))
                            {
                                lst.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    this.Div1.Visible = false;
                }
            }
            else
            {
                MessageBox("", strSQL + " " + OP_Mode.strErrMsg);
            }
        }
    }

    /// <summary>
    /// 保存施工员数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string qxsz = string.Empty;
        string strSQL = string.Empty;
        strSQL = "Delete from W_GCGD_USERS where GCDID=" + GridView1.DataKeys[GridView1.SelectedIndex].Values[0];

        foreach (ListItem lst in this.CheckBoxList1.Items)
        {
            if (lst.Selected == true)
            {
                qxsz += lst.Value + ",";
                strSQL += " insert into W_GCGD_USERS (GCDID,USERS,flag) values (" + GridView1.DataKeys[GridView1.SelectedIndex].Values[0] + ",'" + lst.Value + "',0) ";
            }
        }

        foreach (ListItem lst in this.CheckBoxList2.Items)
        {
            if (lst.Selected == true)
            {
                qxsz += lst.Value + ",";
                strSQL += " insert into W_GCGD_USERS (GCDID,USERS,flag) values (" + GridView1.DataKeys[GridView1.SelectedIndex].Values[0] + ",'" + lst.Value + "',1) ";
            }
        }

        //strSQL = "DECLARE @ICOUNT INT";

        //strSQL += " SELECT @ICOUNT = COUNT(ID) FROM W_GCGD_USERS WHERE GCDID = " + GridView1.DataKeys[GridView1.SelectedIndex].Values[0];

        //strSQL += " IF @ICOUNT<= 0";
        //strSQL += " BEGIN";
        //strSQL += "   insert into W_GCGD_USERS (GCDID,USERS) values (" + GridView1.DataKeys[GridView1.SelectedIndex].Values[0] + ",'" + qxsz.Substring(0, qxsz.Length - 1) + "')";
        //strSQL += " END";
        //strSQL += " ELSE";
        //strSQL += " BEGIN";
        //strSQL += "   update W_GCGD_USERS set USERS='" + qxsz.Substring(0, qxsz.Length - 1) + "',LTime=getdate() where GCDID=" + GridView1.DataKeys[GridView1.SelectedIndex].Values[0];
        //strSQL += " END";
        //if (qxsz.Length > 0)
        //{
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "安装施工人员信息保存成功。");
        }
        else
        {
            MessageBox("", "安装施工人员信息保存失败。<br/>请重试。错误：" + OP_Mode.strErrMsg);
            return;
        }
        //}
    }
}