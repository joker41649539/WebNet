using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_Default : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(Constant.QX_S_XTMK, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有查看的权限。", Defaut_QX_URL);
                return;
            }
            LoadMK();
        }
    }

    /// <summary>
    /// 模块列表读取
    /// </summary>
    private void LoadMK()
    {
        // 获取GridView排序数据列及排序方向
        string sortExpression = this.GridView1.Attributes["SortExpression"];
        string sortDirection = this.GridView1.Attributes["SortDirection"];
        string strSQL;
        if (this.Label_tj.Text.Length > 0)
        {
            strSQL = "SELECT * FROM S_MK where " + this.Label_tj.Text.Trim() + " ORDER BY JDPX";
        }
        else
        {
            strSQL = "SELECT * FROM S_MK ORDER BY JDPX";
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

            if (this.GridView1.Rows[0].Cells[0].Text == "&nbsp;")
            {
                this.GridView1.Rows[0].Cells[1].Text = "无任何数据";
            }
            /// 设置页低按钮始终显示
            this.GridView1.BottomPagerRow.Visible = true;
        }
        else
        {
            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 此方法必重写，否则会出错 每个页面只需要一个
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

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

        LoadMK();
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
        LoadMK();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        //GridView1.EditRowStyle.BackColor = Color.FromName("#CAD3E4");
        LoadMK();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
        LoadMK();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称
        string DB_01 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 链接地址
        string DB_02 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");
        /// ICO图标
        string DB_03 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 菜单排序
        string DB_04 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 子菜单
        string DB_05 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Replace("'", "\"");
        /// 菜单显示
        string DB_06 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text.ToString().Replace("'", "\"");

        /// 模块ID
        string DB_07 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString().Replace("'", "\"");


        //int iShow = 0;
        //int iXssl = 0;
        ////int iPX = 0;

        if (!(DB_01.Length > 0))
        {
            MessageBox("", "模块名称不允许为空！<br/>请认真填写。");
            return;
        }

        if (!(DB_02.Length > 0))
        {
            DB_02 = "#";
        }

        int n;

        if (DB_05.Length > 0 && int.TryParse(DB_05, out n))
        {
            /// DB_05 = Convert.ToInt16(DB_05);
        }
        else
        {
            DB_05 = "0";
        }

        if (DB_06.Length > 0 && int.TryParse(DB_06, out n))
        {
            /// DB_06 = Convert.ToInt16(DB_05);
        }
        else
        {
            DB_06 = "0";
        }

        if (DB_07.Length > 0 && int.TryParse(DB_07, out n))
        {
            //DB_07 = Convert.ToInt16(DB_07);
        }
        else
        {
            MessageBox("", "模块ID必须为正整数！<br/>请参照规则认真填写。");
            return;
        }

        string strSQL;

        strSQL = "Update S_MK SET ID=" + DB_07 + ",MKMC='" + DB_01 + "',MKZX='" + DB_02 + "',ICO='" + DB_03 + "',JDPX='" + DB_04 + "',CS=" + DB_05 + ",SHOW=" + DB_06 + " WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox(UpdatePanel1, "", "数据更新成功!");
        }
        else
        {
            MessageBox(UpdatePanel1, "", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);
            // MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }

        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
        LoadMK();
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
        /// 菜单排序
        string DB_04 = this.TextBox4.Text.Trim().Replace("'", "\"");
        /// 子菜单
        string DB_05 = this.TextBox5.Text.Trim().Replace("'", "\"");
        /// 菜单显示
        string DB_06 = this.TextBox6.Text.Trim().Replace("'", "\"");

        /// 模块ID
        string DB_07 = this.TextBox8.Text.Trim().Replace("'", "\"");


        //int iShow = 0;
        //int iXssl = 0;
        ////int iPX = 0;

        if (!(DB_01.Length > 0))
        {
            MessageBox("", "模块名称不允许为空！<br/>请认真填写。");
            return;
        }

        if (!(DB_02.Length > 0))
        {
            DB_02 = "#";
        }

        if (!(DB_04.Length > 0))
        {
            MessageBox("", "菜单排序不允许为空！<br/>请参照规则认真填写。");
            return;
        }

        int n;

        if (DB_05.Length > 0 && int.TryParse(DB_05, out n))
        {
            /// DB_05 = Convert.ToInt16(DB_05);
        }
        else
        {
            DB_05 = "0";
        }

        if (DB_06.Length > 0 && int.TryParse(DB_06, out n))
        {
            /// DB_06 = Convert.ToInt16(DB_05);
        }
        else
        {
            DB_06 = "0";
        }

        if (DB_07.Length > 0 && int.TryParse(DB_07, out n))
        {
            //DB_07 = Convert.ToInt16(DB_07);
        }
        else
        {
            MessageBox("", "模块ID必须为正整数！<br/>请参照规则认真填写。");
            return;
        }

        string strSQL;

        strSQL = "Insert into S_MK (MKMC,MKZX,ICO,JDPX,CS,SHOW,ID) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "'," + DB_05 + "," + DB_06 + "," + DB_07 + ") ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox(UpdatePanel1, "", "模块添加成功!", Request.Url.LocalPath);
        }
        else
        {
            MessageBox(UpdatePanel1, "", "模块更新失败！<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
        LoadMK();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 15856951443 浙江省温州市苍南县钱库镇陈南工业区10号 轩雅公艺 收 15158523295
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[7].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】模块吗?')");
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

        string strSQL = "Delete from S_MK where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox(UpdatePanel1, "", "指定模块删除成功^_^！");
            LoadMK();
        }
        else
        {
            MessageBox(UpdatePanel1, "", "指定模块删除错误。<br/>" + OP_Mode.strErrMsg);
        }

        //MessageBox(UpdatePanel1, "", "模块删除暂时不启用，不允许删除^_^！");
        //LoadMK();

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
        LoadMK();
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        LoadMK();
    }
}