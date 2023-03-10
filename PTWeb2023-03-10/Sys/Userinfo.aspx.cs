using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_Userinfo : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(Constant.QX_S_USERINFO, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有查看的权限。", Defaut_QX_URL);
                return;
            }

            LoadUserInfo();
            Load_GridView_qxz();
            LoadMenu(-1);
        }
    }

    /// <summary>
    /// 此方法必重写，否则会出错 每个页面只需要一个
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    #region "GridView1 读取用户信息 相关代码"
    /// <summary>
    /// 模块列表读取
    /// </summary>
    private void LoadUserInfo()
    {
        // 获取GridView排序数据列及排序方向
        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];
        string strSQL;
        if (this.Label_tj.Text.Length > 0)
        {
            strSQL = "SELECT * FROM S_USERINFO where " + this.Label_tj.Text.Trim() + " ORDER BY ID";
        }
        else
        {
            strSQL = "SELECT * FROM S_USERINFO ORDER BY ID";
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

            this.GridView1.BottomPagerRow.Visible = true;
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

        LoadUserInfo();
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
        LoadUserInfo();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        //GridView1.EditRowStyle.BackColor = Color.FromName("#CAD3E4");
        LoadUserInfo();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
        LoadUserInfo();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

        /// 登录名
        string DB_01 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 姓名
        string DB_02 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 性别
        string DB_03 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 所属单位
        string DB_04 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");
        ///所属对组
        string DB_05 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Replace("'", "\"");
        ///职务
        string DB_06 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text.ToString().Replace("'", "\"");
        ///证件号码
        string DB_07 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 密码
        string DB_08 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 在用标志
        string DB_09 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[9].Controls[0]).Text.ToString().Replace("'", "\"");


        //int iShow = 0;
        //int iXssl = 0;
        ////int iPX = 0;

        if (!(DB_01.Length > 0))
        {
            MessageBox(UpdatePanel1, "", "登陆名称不允许为空！<br/>请认真填写。");
            return;
        }

        if (!(DB_02.Length > 0))
        {
            MessageBox(UpdatePanel1, "", "姓名不允许为空！<br/>请认真填写。");
            return;
        }

        if (!(DB_08.Length > 5))
        {
            MessageBox(UpdatePanel1, "", "密码至少为6位！<br/>请认真填写。");
            return;
        }

        int n;

        if (DB_09.Length > 0 && int.TryParse(DB_09, out n))
        {

        }
        else
        {
            DB_09 = "1";
        }



        string strSQL = string.Empty;

        strSQL = "Update S_USERINFO SET LOGINNAME='" + DB_01 + "',CNAME='" + DB_02 + "',XB='" + DB_03 + "',SSDW='" + DB_04 + "',SSDZ='" + DB_05 + "',ZW='" + DB_06 + "',ZJHM='" + DB_07 + "',PASSWORD='" + DB_08 + "',FLAG=" + DB_09 + ",LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox(UpdatePanel1, "", "数据更新成功!");
        }
        else
        {
            MessageBox(UpdatePanel1, "", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }

        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
        LoadUserInfo();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MKADD")
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "sKey", "$('#MKADD').modal('show');", true);
        }

    }

    /// <summary>
    /// 模块数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        /// 模块名称
        string DB_01 = this.TextBox1.Text.Trim().Replace("'", "\"");
        /// 链接地址
        string DB_02 = this.TextBox2.Text.Trim().Replace("'", "\"");
        /// ICO图标
        string DB_03 = this.TextBox3.Text.Trim().Replace("'", "\"");

        //int iShow = 0;
        //int iXssl = 0;
        ////int iPX = 0;

        if (!(DB_01.Length > 0))
        {
            MessageBox("", "登录名称不允许为空！<br/>请认真填写。");
            return;
        }

        if (!(DB_02.Length > 0))
        {
            MessageBox("", "中文名不允许为空！<br/>请认真填写。");
            return;
        }

        if (!(DB_03.Length > 5))
        {
            MessageBox("", "登录密码至少要6位！<br/>请认真填写。");
            return;
        }

        string strSQL;

        strSQL = "Insert into S_USERINFO (LOGINNAME,CNAME,PASSWORD,FLAG,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "',0,GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox(UpdatePanel1, "", "用户信息添加成功!", Request.Url.LocalPath);
        }
        else
        {
            MessageBox(UpdatePanel1, "", "用户信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
        LoadUserInfo();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[12].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");
            }
        }
    }

    /// <summary>
    /// 模块删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string ID = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from S_USERINFO where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox(UpdatePanel1, "", "指定用户删除成功^_^！");
            LoadUserInfo();
        }
        else
        {
            MessageBox(UpdatePanel1, "", "指定用户删除错误。<br/>" + OP_Mode.strErrMsg);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string strDiv = string.Empty;

        if (this.TextBox7.Text.Length == 0)
        {
            this.TextBox7.Text = "空";
        }

        if (this.Label1.Text.Length > 0)
        {
            this.Label1.Text += "<b>并且</b><br />";
            this.Label_tj.Text += " and ";
        }

        this.Label1.Text += this.DropDownList1.SelectedItem.Text + "&nbsp;" + this.DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.TextBox7.Text + "&nbsp;";

        if (this.DropDownList_SF.SelectedValue == "LIKE")
        {
            this.Label_tj.Text += " " + this.DropDownList1.SelectedValue + " " + this.DropDownList_SF.SelectedValue + " " + "'%" + this.TextBox7.Text.Trim().Replace("'", "\"") + "%'";
        }
        else
        {
            this.Label_tj.Text += " " + this.DropDownList1.SelectedValue + " " + this.DropDownList_SF.SelectedValue + " " + "'" + this.TextBox7.Text.Trim().Replace("'", "\"") + "'";
        }
        this.TextBox7.Text = string.Empty;
        this.alerts_tj.Visible = true;

    }

    /// <summary>
    /// 清除查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        this.TextBox7.Text = string.Empty;
        this.Label1.Text = string.Empty;
        this.Label_tj.Text = string.Empty;
        this.alerts_tj.Visible = false;
        LoadUserInfo();
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        LoadUserInfo();
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.SelectedRow.Cells[0].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[1].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[2].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[3].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[4].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[5].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[6].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[7].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[8].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[9].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[10].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[11].BackColor = Color.FromName("#CAD3E4");
        GridView1.SelectedRow.Cells[12].BackColor = Color.FromName("#CAD3E4");

        Load_GridView_qxz();
    }
    #endregion


    #region "GridView_qxz 读取权限组 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_qxz()
    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_qxz.Attributes["SortExpression"];

        string sortDirection = this.GridView_qxz.Attributes["SortDirection"];

        string strSQL;

        string strID = "-1";

        if (GridView1.SelectedIndex > -1)
        {
            strID = GridView1.SelectedDataKey[0].ToString();
        }

        if (this.GridView_qxz_Label_tj.Text.Length > 0)
        {
            strSQL = "SELECT ID,ZMC,CAST((SELECT COUNT(USERID) FROM S_YH_QXZ WHERE QXZID=S_QXZ.ID AND USERID=" + strID + ") AS BIT ) AS ICHECK,FLAG FROM S_QXZ WHERE  " + this.GridView_qxz_Label_tj.Text.Trim();
        }
        else
        {
            strSQL = "SELECT ID,ZMC,CAST((SELECT COUNT(USERID) FROM S_YH_QXZ WHERE QXZID=S_QXZ.ID AND USERID=" + strID + ") AS BIT ) AS ICHECK,FLAG FROM S_QXZ";
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

            this.GridView_qxz.DataSource = OP_Mode.Dtv;

            this.GridView_qxz.DataBind();



            this.GridView_qxz.BottomPagerRow.Visible = true;

        }

        else
        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }



    protected void GridView_qxz_Sorting(object sender, GridViewSortEventArgs e)
    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();



        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";



        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_qxz.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_qxz.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }



        // 重新设定GridView排序数据列及排序方向

        this.GridView_qxz.Attributes["SortExpression"] = sortExpression;

        this.GridView_qxz.Attributes["SortDirection"] = sortDirection;



        Load_GridView_qxz();

    }

    protected void GridView_qxz_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        Load_GridView_qxz();

    }

    protected void GridView_qxz_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView_qxz.EditIndex = e.NewEditIndex;

        //GridView_qxz.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_qxz();



    }

    protected void GridView_qxz_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView_qxz.SelectedIndex = -1;

        GridView_qxz.EditIndex = -1;

        Load_GridView_qxz();



    }

    protected void GridView_qxz_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string ID = GridView_qxz.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_qxz.Rows[e.RowIndex].FindControl("TextBox1")).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_qxz.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "权限组名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;



        strSQL = "Update S_QXZ SET ZMC='" + DB_01 + "', FLAG='" + DB_02 + "', LTIME=GETDATE() WHERE ID=" + ID;



        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "数据更新成功!");

        }

        else
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }



        GridView_qxz.SelectedIndex = -1;

        GridView_qxz.EditIndex = -1;

        Load_GridView_qxz();

    }



    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_qxz_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "GridView_qxz_ADD")
        {

            ScriptManager.RegisterStartupScript(GridView_qxz_UpdatePanel1, this.GetType(), "sKey", "$('#GridView_qxz_ADD').modal('show');", true);

        }
        else if (e.CommandName == "GridView_qxz_Save")
        {
            string strSQL;


            if (GridView1.SelectedIndex > -1)
            {
                strSQL = " Delete from S_YH_QXZ where USERID=" + GridView1.SelectedDataKey[0].ToString() + " ";

                string stemp = string.Empty;

                for (int i = 0; i <= GridView_qxz.Rows.Count - 1; i++)
                {
                    CheckBox chkbox = (CheckBox)this.GridView_qxz.Rows[i].FindControl("CheckBox1") as CheckBox;

                    if (chkbox.Checked)
                    {
                        strSQL += " INSERT INTO S_YH_QXZ (USERID,QXZID) VALUES (" + this.GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString().Replace("'", "\"") + "," + this.GridView_qxz.DataKeys[i].Value.ToString().Replace("'", "\"") + ") ";
                    }
                }

                if (!OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox(GridView_qxz_UpdatePanel1, "", "保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                }
                else
                {
                    MessageBox(GridView_qxz_UpdatePanel1, "", "权限组分配成功！");
                }
            }
        }
    }



    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_qxz_LinkButton1_Click(object sender, EventArgs e)
    {

        /// 组名称

        string DB_01 = this.GridView_qxz_TextBox_ZMC.Text.Trim().Replace("'", "\"");

        /// 状态

        string DB_02 = this.GridView_qxz_TextBox_FLAG.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))
        {

            MessageBox("", "权限组名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;


        strSQL = "Insert into S_QXZ ( ZMC, FLAG,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "',GETDATE(),GETDATE()) ";


        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "权限组信息添加成功!", Request.Url.LocalPath);

        }

        else
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "权限组信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_qxz();

    }



    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_qxz_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {

                ((LinkButton)e.Row.Cells[3].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[2].Text + "\" 】吗?')");

            }

        }

    }


    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>


    protected void GridView_qxz_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string ID = GridView_qxz.DataKeys[e.RowIndex].Values[0].ToString();



        string strSQL = "Delete from S_QXZ where ID=" + ID;



        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "指定数据删除成功^_^！");

            Load_GridView_qxz();

        }

        else
        {

            MessageBox(GridView_qxz_UpdatePanel1, "", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);

        }



    }



    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_qxz_TJADD_Click(object sender, EventArgs e)
    {

        string strDiv = string.Empty;



        if (this.GridView_qxz_TextBox_CXTJ.Text.Length == 0)
        {

            this.GridView_qxz_TextBox_CXTJ.Text = "空";

        }



        if (this.GridView_qxz_Label1.Text.Length > 0)
        {

            this.GridView_qxz_Label1.Text += "<b>并且</b><br />";

            this.GridView_qxz_Label_tj.Text += " and ";

        }



        this.GridView_qxz_Label1.Text += this.GridView_qxz_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_qxz_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_qxz_TextBox_CXTJ.Text + "&nbsp;";



        if (this.GridView_qxz_DropDownList_SF.SelectedValue == "LIKE")
        {

            this.GridView_qxz_Label_tj.Text += " " + this.GridView_qxz_DropDownList1.SelectedValue + " " + this.GridView_qxz_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_qxz_TextBox_CXTJ.Text.Trim().Replace("'", "\"") + "%'";

        }

        else
        {

            this.GridView_qxz_Label_tj.Text += " " + this.GridView_qxz_DropDownList1.SelectedValue + " " + this.GridView_qxz_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_qxz_TextBox_CXTJ.Text.Trim().Replace("'", "\"") + "'";

        }

        this.GridView_qxz_TextBox_CXTJ.Text = string.Empty;

        this.GridView_qxz_alerts_tj.Visible = true;



    }



    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_qxz_LinkButton3_Click(object sender, EventArgs e)
    {

        this.GridView_qxz_TextBox_CXTJ.Text = string.Empty;

        this.GridView_qxz_Label1.Text = string.Empty;

        this.GridView_qxz_Label_tj.Text = string.Empty;

        this.GridView_qxz_alerts_tj.Visible = false;

        Load_GridView_qxz();

    }



    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_qxz_LinkButton4_Click(object sender, EventArgs e)
    {

        Load_GridView_qxz();

    }

    protected void GridView_qxz_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView_qxz.SelectedRow.Cells[0].BackColor = Color.FromName("#CAD3E4");
        GridView_qxz.SelectedRow.Cells[1].BackColor = Color.FromName("#CAD3E4");
        GridView_qxz.SelectedRow.Cells[2].BackColor = Color.FromName("#CAD3E4");

        string Name = GridView_qxz.DataKeys[GridView_qxz.SelectedRow.RowIndex].Values[0].ToString();
        LoadMenu(Convert.ToInt32(Name));

    }

    #endregion

    private void LoadMenu(int iQXZID)
    {
        string strDiv = "<ul class=\"nav nav-list\">";

        string strURL = HttpContext.Current.Request.Url.AbsolutePath.ToString().Substring(0, HttpContext.Current.Request.Url.AbsolutePath.ToString().IndexOf("/", 1) + 1);

        string strSQL = "SELECT CAST((SELECT COUNT(S_QXZZB.QXID) FROM S_QXZZB WHERE S_MK.ID=S_QXZZB.QXID and QXZID=" + iQXZID.ToString() + ") AS int ) AS ICHECK,* FROM S_MK WHERE JDPX IS NOT NULL AND JDPX<>'' ORDER BY JDPX";

        string strClass = "icon-dashboard";

        string strZCD = string.Empty;

        string strXLAN = string.Empty;

        string strULJW = string.Empty;

        string strActive = string.Empty;

        int JDCS = 0;
        int JDCSUP = 0;
        int JDCSDown = 0;

        string strSelect = string.Empty;

        if (OP_Mode.SQLRUN(strSQL))
        {

            for (int num = 0; num < OP_Mode.Dtv.Count; num++)
            {
                if ((int)OP_Mode.Dtv[num]["ICHECK"] != 0)
                {
                    strSelect = " checked=\"checked\" ";
                }
                else
                {
                    strSelect = string.Empty;
                }

                JDCS = (int)OP_Mode.Dtv[num]["CS"];

                if (num > 1)
                {
                    JDCSUP = (int)OP_Mode.Dtv[num - 1]["CS"];
                }
                else
                {
                    JDCSUP = 0;
                }


                if (num + 1 < OP_Mode.Dtv.Count)
                {
                    JDCSDown = (int)OP_Mode.Dtv[num + 1]["CS"];
                }
                else
                {
                    JDCSDown = 0;
                }

                ///////////////////////////////////////////////
                if (JDCSDown > JDCS)  /// 有子菜单的显示向下图标
                {
                    strZCD = " <b class=\"arrow icon-angle-down\"></b>";
                }
                else
                {
                    strZCD = "";
                }

                /// 设置默认ICO图标
                if (OP_Mode.Dtv[num]["ICO"].ToString().Length > 0)
                {
                    strClass = OP_Mode.Dtv[num]["ICO"].ToString().Trim();
                }
                else
                {
                    strClass = "icon-dashboard";
                }

                strDiv += "<li class=\"active\">";
                strDiv += "  <a  href=\"#\">";
                strDiv += "   <i class=\"" + strClass + "\"></i>";
                strDiv += "   <input name=\"checkbox_Menu\"  value=\"" + OP_Mode.Dtv[num]["ID"].ToString().Trim() + "\" type=\"checkbox\" " + strSelect + "/><span class=\"menu-text\">" + OP_Mode.Dtv[num]["MKMC"].ToString().Trim() + "</span>";
                strDiv += strZCD;
                strDiv += "  </a>";


                if (JDCSDown > JDCS)
                {
                    strDiv += " <ul class=\"submenu\">";
                }
                else
                {
                    if (num != OP_Mode.Dtv.Count)
                    {
                        strDiv += "</li>";
                    }
                }


                if (num == OP_Mode.Dtv.Count - 1)
                {
                    strDiv += "</ul></li>";
                    strDiv += "</ul>";
                }
                else
                {
                    if (JDCS > JDCSDown)
                    {
                        for (int ii = JDCSDown; ii < JDCS; ii++)
                        {
                            strDiv += "</ul></li>";
                        }
                    }
                }

                strActive = string.Empty;
            }
        }

        this.sidebar.InnerHtml = strDiv;

    }

    /// <summary>
    /// 权限保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        string[] arrayQX;
        string Name;
        try
        {
            /// 获取所有权限数组
            arrayQX = Request["checkbox_Menu"].Split(',');

            /// 获取权限组ID
            Name = GridView_qxz.DataKeys[GridView_qxz.SelectedRow.RowIndex].Values[0].ToString();
        }
        catch
        {
            /// 未选中用户组，或者是没有勾选任何权限则不做任何操作
            return;
        }

        int iQXZID = Convert.ToInt32(Name);

        /// 删除原来用户组所有权限，然后再添加新的权限
        string strSQL = " Delete from S_QXZZB where QXZID=" + iQXZID.ToString();

        for (int i = 0; i < arrayQX.Length; i++)
        {
            strSQL += " Insert into S_QXZZB (QXZID,QXID) VALUES (" + iQXZID.ToString() + "," + arrayQX[i].ToString() + ") ";
        }

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "权限组权限保存成功！");
            string strXQZID = GridView_qxz.DataKeys[GridView_qxz.SelectedRow.RowIndex].Values[0].ToString();
            LoadMenu(Convert.ToInt32(strXQZID));
            return;
        }
        else
        {
            MessageBox("出错了", "权限组权限保存错误！<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }

    }
}