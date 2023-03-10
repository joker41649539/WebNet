using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Office.Interop.Excel;

public partial class Question_Default2 : PageBaseQuestion
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string LoginID = string.Empty;
            Button2.Visible = false;
            try
            {
                LoginID = Request.Cookies["WeChat_Question"]["USERID"].ToString();
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
        }
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Load_GridView1();
    }
    /// <summary>
    /// 查询数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (OP_Mode.Dtv.Count > 0)
        {
            // ExportForAVGTR(OP_Mode.Dtv, "Excel");
            String[] columnNames = { "列名1", "列名2" };
            byte[] excelBytes = DataTableToExcel(OP_Mode.Dtv.Table, columnNames, "数据导出");
            {
                String fileName = String.Format("{0:yyyy_MM_dd_HH_mm_ss}.xlsx", DateTime.Now);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //通知浏览器下载文件而不是打开
                Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.BinaryWrite(excelBytes);
                Response.Flush();
                Response.End();
            }
        }
        else
        {
            MessageBox("", "未查询到任何信息。");
        }
    }

    #region "GridView1 读取查询结果 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView1()
    {
        string strsql = string.Empty;
        string strTJ = string.Empty;

        string Db_01 = TextBox_Name.Text.Trim().Replace("'", "''");
        string Db_02 = TextBox_DHHM.Text.Trim().Replace("'", "''");
        string Db_03 = TextBox_ZJHM.Text.Trim().Replace("'", "''");
        string Db_04 = TextBox_XZ.Text.Trim().Replace("'", "''");
        string Db_05 = TextBox_SQ.Text.Trim().Replace("'", "''");
        string Db_06 = TextBox_XQ.Text.Trim().Replace("'", "''");
        string Db_07 = TextBox_JZ.Text.Trim().Replace("'", "''");

        if (Db_01.Length > 0)
        {
            strTJ += " Name like '%" + Db_01 + "%' ";
        }
        if (Db_02.Length > 0)
        {
            if (strTJ.Length > 0)
            {
                strTJ += " and LXDH like '%" + Db_02 + "%' ";
            }
            else
            {
                strTJ += " LXDH like '%" + Db_02 + "%' ";
            }
        }
        if (Db_03.Length > 0)
        {
            if (strTJ.Length > 0)
            {
                strTJ += " and ZJHM like '%" + Db_03 + "%' ";
            }
            else
            {
                strTJ += " ZJHM like '%" + Db_03 + "%' ";
            }
        }
        if (Db_04.Length > 0)
        {
            if (strTJ.Length > 0)
            {
                strTJ += " and XZ like '%" + Db_04 + "%' ";
            }
            else
            {
                strTJ += " XZ like '%" + Db_04 + "%' ";
            }
        }
        if (Db_05.Length > 0)
        {
            if (strTJ.Length > 0)
            {
                strTJ += " and SQM like '%" + Db_05 + "%' ";
            }
            else
            {
                strTJ += " SQM like '%" + Db_05 + "%' ";
            }
        }
        if (Db_06.Length > 0)
        {
            if (strTJ.Length > 0)
            {
                strTJ += " and XQM like '%" + Db_06 + "%' ";
            }
            else
            {
                strTJ += " XQM like '%" + Db_06 + "%' ";
            }
        }

        if (Db_07.Length > 0)
        {
            if (strTJ.Length > 0)
            {
                strTJ += " and JZJC like '%" + Db_07 + "%' ";
            }
            else
            {
                strTJ += " JZJC like '%" + Db_07 + "%' ";
            }
        }

        if (strTJ.Length > 0)
        {
            strsql = " Select * from Question_Info where " + strTJ + " order by Name";
            if (OP_Mode.SQLRUN(strsql))
            {
                /// 设置排序
                if (OP_Mode.Dtv.Count == 0)
                {

                    this.GridView1.DataSource = null;

                    this.GridView1.DataBind();

                    Button2.Visible = false;// 设置数据导出按钮隐藏
                    MessageBox("", "依据条件未查询到任何信息，请简化条件后重试。");
                }
                else
                {
                    string sortExpression = this.GridView1.Attributes["SortExpression"];

                    string sortDirection = this.GridView1.Attributes["SortDirection"];

                    if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

                    {

                        OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

                    }

                    this.GridView1.DataSource = OP_Mode.Dtv;

                    this.GridView1.DataBind();
                    Button2.Visible = true;// 设置数据导出按钮显示出来

                    Label lab_SumCount = (Label)GridView1.BottomPagerRow.FindControl("Label_SumCount");
                    lab_SumCount.Text = OP_Mode.Dtv.Count.ToString();
                }
            }
        }
        else
        {
            MessageBox("", "请任意输入一个查询条件。");
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

            System.Web.UI.WebControls.TextBox txtNewPageIndex = null;

            //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow

            GridViewRow pagerRow = theGrid.BottomPagerRow;

            if (pagerRow != null)

            {

                //得到text控件

                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as System.Web.UI.WebControls.TextBox;

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

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView1.EditIndex = e.NewEditIndex;

        //GridView1.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView1();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView1.SelectedIndex = -1;

        GridView1.EditIndex = -1;

        Load_GridView1();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)

    {


    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {


    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {
        string ID = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();

        GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

        GridView1.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

        Response.Redirect("/Question/Addinfo.aspx?ID=" + ID, false);
    }

    #endregion

    //public bool ExportForAVGTR(System.Data.DataView AVGTR, string name)
    //{
    //    //建立Excel对象
    //    Application app = new Application();
    //    try
    //    {
    //        app.Visible = false;
    //        Workbook xlBook = app.Workbooks.Add(true);
    //        Worksheet xlSheet = (Worksheet)xlBook.Worksheets[1];
    //        for (int i = 2; i < AVGTR.Table.Columns.Count - 1; i++)
    //            if (i == 2)
    //            {
    //                xlSheet.Cells[1, i + 1] = "摸底人";
    //            }
    //            else if (i == 3)
    //            {
    //                xlSheet.Cells[1, i + 1] = "乡镇";
    //            }
    //            else if (i == 4)
    //            {
    //                xlSheet.Cells[1, i + 1] = "姓名";
    //            }
    //            else if (i == 5)
    //            {
    //                xlSheet.Cells[1, i + 1] = "社区/村";
    //            }
    //            else if (i == 6)
    //            {
    //                xlSheet.Cells[1, i + 1] = "居民小组/网格";
    //            }
    //            else if (i == 7)
    //            {
    //                xlSheet.Cells[1, i + 1] = "门牌号";
    //            }
    //            else if (i == 8)
    //            {
    //                xlSheet.Cells[1, i + 1] = "证件号码";
    //            }
    //            else if (i == 9)
    //            {
    //                xlSheet.Cells[1, i + 1] = "户籍地";
    //            }
    //            else if (i == 10)
    //            {
    //                xlSheet.Cells[1, i + 1] = "现工作（学习）单位";
    //            }
    //            else if (i == 11)
    //            {
    //                xlSheet.Cells[1, i + 1] = "政治面貌";
    //            }
    //            else if (i == 12)
    //            {
    //                xlSheet.Cells[1, i + 1] = "联系电话";
    //            }
    //            else if (i == 13)
    //            {
    //                xlSheet.Cells[1, i + 1] = "是否接种";
    //            }
    //            else if (i == 14)
    //            {
    //                xlSheet.Cells[1, i + 1] = "接种剂次";
    //            }
    //            else if (i == 15)
    //            {
    //                xlSheet.Cells[1, i + 1] = "接种地点";
    //            }
    //            else if (i == 16)
    //            {
    //                xlSheet.Cells[1, i + 1] = "未种原因";
    //            }
    //            else if (i == 17)
    //            {
    //                xlSheet.Cells[1, i + 1] = "是否愿意参与志愿服务";
    //            }
    //            else if (i == 18)
    //            {
    //                xlSheet.Cells[1, i + 1] = "有无另外住处（若有请写具体）";
    //            }
    //            else if (i == 19)
    //            {
    //                xlSheet.Cells[1, i + 1] = "网格员";
    //            }
    //            else if (i == 20)
    //            {
    //                xlSheet.Cells[1, i + 1] = "楼栋长";
    //            }
    //            else if (i == 21)
    //            {
    //                xlSheet.Cells[1, i + 1] = "备注说明";
    //            }
    //            else if (i == 22)
    //            {
    //                xlSheet.Cells[1, i + 1] = "更新时间";
    //            }
    //        // xlSheet.Cells[1, i + 1] = AVGTR.Table.Columns[i].ColumnName.ToString();
    //        for (int i = 0; i < AVGTR.Table.Rows.Count; i++)
    //        {
    //            for (int j = 2; j < AVGTR.Table.Columns.Count - 1; j++)
    //            {
    //                xlSheet.Cells[i + 2, j + 1] = AVGTR.Table.Rows[i][j].ToString();
    //                xlSheet.Cells.NumberFormat = "@";
    //            }
    //        }
    //        xlSheet.Name = name;
    //        xlSheet.Cells.Font.Size = 11;
    //        xlSheet.Cells.Font.FontStyle = FontStyle.Bold;
    //        xlSheet.Cells.Font.Name = "微软雅黑";
    //        xlSheet.Columns.AutoFit();
    //    }
    //    finally
    //    {
    //        app.Visible = true;
    //    }
    //    return true;
    //}


    public Byte[] DataTableToExcel(DataTable dataTable, string[] columns, string sheetName)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage pck = new ExcelPackage())
            {

                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetName);
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        var index = dataTable.Columns.IndexOf(column);
                        ws.Cells[2, index + 1, dataTable.Rows.Count + 1, index + 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }

                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                //for (int i = 1; i <= columns.Length; i++) //设置excel列名
                //{
                //    using (ExcelRange rng = ws.Cells[1, i])
                //    {
                //        rng.Style.Font.Bold = true;
                //        rng.Value = columns[i - 1];
                //    }
                //}
                //MemoryStream ms = new MemoryStream();
                //pck.SaveAs(ms);
                //ms.Flush();
                //ms.Position = 0;//指定当前流的位置从0开始
                //return ms;
                return pck.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public byte[] StreamToBytes(Stream stream)
    {
        byte[] bytes = new byte[stream.Length];
        stream.Read(bytes, 0, bytes.Length);
        // 设置当前流的位置为流的开始
        stream.Seek(0, SeekOrigin.Begin);
        return bytes;
    }

}