using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCGDAdd : PageBase
{
    public string strGCDH = "GC2020-07-19-0001";
    public int IGDID = 0;
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
            LoadData();
            Load_GridView1();
        }
    }

    private void LoadData()
    {
        int iID;
        iID = Convert.ToInt32(Request["ID"]);
        if (iID > 0)
        {
            string strSQL = " SELECT * FROM W_GCGD1 WHERE ID=" + iID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    Label_GCBH.Text = OP_Mode.Dtv[0]["GCDH"].ToString();
                    IGDID = Convert.ToInt32(OP_Mode.Dtv[0]["ID"]);

                    TextBox_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                    TextBox_gcdd.Text = OP_Mode.Dtv[0]["GCDD"].ToString();
                    TextBox_FZR.Text = OP_Mode.Dtv[0]["JFFZR"].ToString();
                    TextBox_DH.Text = OP_Mode.Dtv[0]["JFDH"].ToString();
                    TextBox_YQSM.Text = OP_Mode.Dtv[0]["QKSM"].ToString();
                    // Label_YAZFS.Text = OP_Mode.Dtv[0]["YAZFS"].ToString();
                    HiddenField_UserID.Value = OP_Mode.Dtv[0]["ZDRID"].ToString();
                    TextBox_SGBH.Text = OP_Mode.Dtv[0]["SGDH"].ToString();
                    TextBox_Map.Text = OP_Mode.Dtv[0]["TencentMapID"].ToString();
                    RadioButtonList1.SelectedValue = OP_Mode.Dtv[0]["iFlag"].ToString();
                    TextBox1.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                }
            }
        }
    }

    /// <summary>
    /// 保存工单主表信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_YZ_LinkButton1_Click(object sender, EventArgs e)
    {
        SaveData();
    }
    /// <summary>
    /// 保存工单信息
    /// </summary>

    private void SaveData()
    {
        string DB_01 = TextBox_GCMC.Text.Replace("'", "");
        string DB_02 = TextBox_gcdd.Text.Replace("'", "");
        string DB_03 = TextBox_FZR.Text.Replace("'", "");
        string DB_04 = TextBox_DH.Text.Replace("'", "");
        string DB_05 = TextBox_YQSM.Text.Replace("'", "");

        string DB_Map = TextBox_Map.Text.Replace("'", "");

        string DB_Remark = TextBox1.Text.Replace("'", "");

        int iFlag = 0;

        if (RadioButtonList1.SelectedValue.Length > 0)
        {
            iFlag = Convert.ToInt32(RadioButtonList1.SelectedValue);
        }

        if (DB_01.Length == 0 || DB_02.Length == 0 || DB_03.Length == 0 || DB_04.Length == 0 || DB_05.Length == 0)
        {
            MessageBox("", "所有选项都必须填写。<br/>请检查后认真填写。");
            return;
        }
        string strSQL = string.Empty;

        if (TextBox_SGBH.Text.Replace("'", "").Length > 0)
        {/// 判断手工单号是否重复
            strSQL = "sELECT * FROM W_WCGD1 WHERE SGDH='" + TextBox_SGBH.Text.Replace("'", "") + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    MessageBox("", "手工单号重复，请检查。");
                    return;
                }
            }
        }

        if (Label_GCBH.Text.Length == strGCDH.Length)
        {/// 修改数据
            strSQL = "Update W_GCGD1 set TencentMapID='" + DB_Map + "',Remark='" + DB_Remark + "',iFlag=" + iFlag + ", SGDH='" + TextBox_SGBH.Text.Replace("'", "") + "', GCMC='" + DB_01 + "',GCDD='" + DB_02 + "',JFFZR='" + DB_03 + "',JFDH='" + DB_04 + "',QKSM='" + DB_05 + "',LTIME=GETDATE() WHERE GCDH='" + Label_GCBH.Text + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "工单信息已经修改成功。");
            }
            else
            {
                MessageBox("", "工单信息修改失败，请重试。" + OP_Mode.strErrMsg);
            }
            return;
        }

        strSQL = " Insert into W_GCGD1 (SGDH,GCDH,GCMC,GCDD,JFFZR,JFDH,QKSM,ZDRID,TencentMapID,Remark) values ('" + TextBox_SGBH.Text.Replace("'", "") + "',(SELECT  'GC'+CONVERT(VARCHAR(10),GETDATE(),120) + '-' + RIGHT('0000' + CAST(ISNULL(MAX(RIGHT(GCDH,4)),'0000') + 1 AS VARCHAR),4) FROM W_GCGD1 WHERE CONVERT(VARCHAR(10),GETDATE(),120) = CONVERT(VARCHAR(10),CTIME,120)),'" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "'," + DefaultUser + ",'" + DB_Map + "','" + DB_Remark + "')";
        strSQL += " SELECT * FROM W_GCGD1 WHERE ID=SCOPE_IDENTITY()";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_GCBH.Text = OP_Mode.Dtv[0]["GCDH"].ToString();
                IGDID = Convert.ToInt32(OP_Mode.Dtv[0]["ID"]);
                HiddenField_UserID.Value = OP_Mode.Dtv[0]["ZDRID"].ToString();
                MessageBox("", "工程工单信息添加成功。");
            }
        }
        else
        {
            MessageBox("", "工程工单信息添加失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 添加明细
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Label_GCBH.Text.Length != strGCDH.Length)
        {
            MessageBox("", "请首先保存工程工单后再添加工单明细。");
        }
        else
        {
            if (IGDID == 0)
            {
                IGDID = Convert.ToInt32(Request["ID"]);
                Response.Redirect("/GDGL/GCMXAdd.ASPX?ID=" + IGDID);
            }
        }
    }
    #region "GridView1 读取工单明细 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView1()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_GDAdd.Attributes["SortExpression"];

        string sortDirection = this.GridView_GDAdd.Attributes["SortDirection"];

        string strSQL;

        strSQL = "SELECT *,(Select cname+cast(FS as nvarchar) +'%;' from W_GCGD_FS,S_USERINFO where GCMXID=W_GCGD2.ID and FS>0 and USERID=S_USERINFO.ID for xml path('')) BXMX,(Select cname+cast(AZFS as nvarchar) +'%;' from W_GCGD_FS,S_USERINFO where GCMXID=W_GCGD2.ID and AZFS>0 and USERID=S_USERINFO.ID for xml path('')) AZMX,(SELECT ISNULL(SUM(FS),0) YBX FROM W_GCGD_FS WHERE GCMXID=W_GCGD2.ID) YBX,(SELECT ISNULL(SUM(AZFS),0) YAZ FROM W_GCGD_FS WHERE GCMXID=W_GCGD2.ID) YAZ,isnull((Select sum(FS+AZFS)  FROM W_GCGD2 where GCDH='" + Label_GCBH.Text + "'),0) SumFS,isnull((Select sum(isnull(W_GCGD_FS.fs*W_GCGD2.FS/100,0)+isnull(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100,0)) from W_GCGD1,W_GCGD2,W_GCGD_FS where W_GCGD1.GCDH=W_GCGD2.GCDH and W_GCGD2.ID=W_GCGD_FS.GCMXID and W_GCGD1.GCDH='" + Label_GCBH.Text + "'),0) YAZFS FROM W_GCGD2 where GCDH='" + Label_GCBH.Text + "' ORDER BY ID";

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }
            this.GridView_GDAdd.DataSource = OP_Mode.Dtv;

            this.GridView_GDAdd.DataBind();

            if (OP_Mode.Dtv.Count > 0)
            {
                Label_SumFS.Text = OP_Mode.Dtv[0]["SumFS"].ToString();
                Label_YAZFS.Text = OP_Mode.Dtv[0]["YAZFS"].ToString();
                Label_WAZFS.Text = Convert.ToInt32((Convert.ToInt32(OP_Mode.Dtv[0]["SumFS"]) - Convert.ToInt32(OP_Mode.Dtv[0]["YAZFS"]))).ToString();

                //Label_YAZFS.NavigateUrl = "/GDGL/YAZFS.ASPX?ID=" + OP_Mode.Dtv[0]["ID"].ToString();
                //Label_WAZFS.NavigateUrl = "/GDGL/WAZFS.ASPX?ID=" + OP_Mode.Dtv[0]["ID"].ToString();
            }
            else
            {
                Label_SumFS.Text = "0";
                Label_YAZFS.Text = "0";
                Label_WAZFS.Text = "0";
            }
        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }
        if (GridView_GDAdd.EditIndex > -1)
        {
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[0].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[1].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[2].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[3].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[4].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[5].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[6].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[7].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[8].BackColor = Color.FromName("#FFFF00");
            //GridView1.Rows[GridView1.EditIndex].Cells[9].BackColor = Color.FromName("#FFFF00");
            //GridView1.Rows[GridView1.EditIndex].Cells[10].BackColor = Color.FromName("#FFFF00");
            GridView_GDAdd.Rows[GridView_GDAdd.EditIndex].Cells[11].BackColor = Color.FromName("#FFFF00");
        }

    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_GDAdd.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_GDAdd.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_GDAdd.Attributes["SortExpression"] = sortExpression;

        this.GridView_GDAdd.Attributes["SortDirection"] = sortDirection;

        Load_GridView1();

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[5].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[6].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[7].BackColor = Color.FromName("#FFF68F");

        GridView_GDAdd.Rows[e.NewSelectedIndex].Cells[8].BackColor = Color.FromName("#FFF68F");

    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strSQL = "Delete from W_GCGD2 where id= " + GridView_GDAdd.DataKeys[e.RowIndex][0].ToString();
        if (OP_Mode.SQLRUN(strSQL))
        {
            Load_GridView1();
            MessageBox("", "数据删除成功。");
        }
    }

    #endregion

    /// <summary>
    /// 导入电子表格
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Label_GCBH.Text.Length != strGCDH.Length)
        {
            MessageBox("", "请首先保存工程工单后再添加工单明细。");
        }
        else
        {
            try
            {
                string fileName = FileUpload1.FileName;//获取文件名
                if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
                {
                    MessageBox("", "请您选择Excel文件。");
                    return;//当无文件时,返回
                }
                string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
                if (IsXls != ".xls" && IsXls != ".xlsx")
                {
                    MessageBox("", "只可以选择Excel文件。");
                    return;//当选择的不是Excel文件时,返回
                }

                string savePath = Server.MapPath("~/file/");
                FileUpload1.SaveAs(savePath + "temp" + IsXls);

                InsetData(GetExcelDatatable(savePath + "temp" + IsXls, "GDMX"));
                Load_GridView1();
                MessageBox("", "数据导入成功。");
            }
            catch (Exception ex)
            {
                MessageBox("", "出错：" + ex.ToString());

            }
        }
    }
    /// <summary>
    /// Excel数据导入Datable
    /// </summary>
    /// <param name="fileUrl"></param>
    /// <param name="table"></param>
    /// <returns></returns>
    public System.Data.DataTable GetExcelDatatable(string fileUrl, string table)
    {
        //office2007之前 仅支持.xls  strConn = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";" + "Extended Properties = Excel 8.0;";   
        //const string cmdText = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;IMEX=1';";
        //支持.xls和.xlsx，即包括office2010等版本的 HDR=Yes代表第一行是标题，不是数据；
        const string cmdText = "Provider=Microsoft.Ace.OleDb.12.0;Data Source={0};Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
        System.Data.DataTable dt = null;
        //建立连接
        OleDbConnection conn = new OleDbConnection(string.Format(cmdText, fileUrl));
        try
        {
            //打开连接
            if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //获取Excel的第一个Sheet名称
            string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString().Trim();
            //查询sheet中的数据
            string strSql = "select * from [" + sheetName + "]";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, table);
            dt = ds.Tables[0];
            return dt;
        }
        catch (Exception exc)
        {
            throw exc;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    /// <summary>
    /// 从System.Data.DataTable导入数据到数据库
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public int InsetData(System.Data.DataTable dt)
    {
        int i = 0;
        string DB_01 = "", DB_02 = "", DB_03 = "", DB_04 = "", DB_05 = "", DB_06 = "", DB_07 = "", DB_08 = "", DB_09 = "", DB_10 = "";
        string strSQL = string.Empty;
        foreach (DataRow dr in dt.Rows)
        {
            DB_01 = dr[0].ToString().Trim();
            DB_02 = dr[1].ToString().Trim();
            DB_03 = dr[2].ToString().Trim();
            DB_04 = dr[4].ToString().Trim();
            DB_05 = dr[3].ToString().Trim();
            DB_06 = dr[5].ToString().Trim();
            DB_07 = dr[6].ToString().Trim();
            DB_08 = dr[8].ToString().Trim();
            DB_09 = dr[7].ToString().Trim();
            DB_10 = dr[9].ToString().Trim();

            strSQL += " Insert into W_GCGD2 (GCDH,AZWZ,SBBH,SBMC,SBPP,SBXH,JLDW,SL,FS,YQSM,AZFS) Values ('" + Label_GCBH.Text + "','" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "','" + DB_06 + "'," + DB_07 + "," + DB_08 + ",'" + DB_09 + "'," + DB_10 + ")";

            i++;

        }

        if (!OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "错误：" + strSQL);
        }

        return i;
    }
    /// <summary>
    /// 整单删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_Del_Click(object sender, EventArgs e)
    {
        if (HiddenField_UserID.Value != DefaultUser || Convert.ToInt32(Label_YAZFS.Text) > 0)
        {
            MessageBox("", "您无删除此单据权限，您只允许删除您自己做的并且没有完成积分的单据。");
            return;
        }
        else
        {
            DelGCGD();
        }
    }

    /// <summary>
    /// 删除工单
    /// </summary>
    public void DelGCGD()
    {
        //1、删除积分、2、删除用户 3、删除明细 4、删除主表
        string strSQL = " Delete W_GCGD_USERS from W_GCGD_USERS,W_GCGD1 where W_GCGD_USERS.GCDID=W_GCGD1.ID and W_GCGD1.GCDH='" + Label_GCBH.Text + "' ";
        strSQL += " Delete W_GCGD_FS from W_GCGD_FS,W_GCGD2 where W_GCGD2.ID=GCMXID and W_GCGD2.GCDH='" + Label_GCBH.Text + "'";
        strSQL += " Delete from W_GCGD2 Where GCDH='" + Label_GCBH.Text + "'";
        strSQL += " Delete from W_GCGD1 Where GCDH='" + Label_GCBH.Text + "'";
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "单据删除成功。", "/GDGL/GCGD.ASPX");
            return;
        }
        else
        {
            MessageBox("", "单据删除失败。<br/>错误：" + strSQL);
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_DelMX_Click(object sender, EventArgs e)
    {
        if (HiddenField_UserID.Value != DefaultUser || Convert.ToInt32(Label_YAZFS.Text) > 0)
        {
            MessageBox("", "您无删除此单据权限，您只允许删除您自己做的并且没有完成积分的单据。");
            return;
        }
        else
        {
            DelGCGDMX();
        }
    }

    /// <summary>
    /// 删除明细数据
    /// </summary>
    private void DelGCGDMX()
    {
        //1、删除积分、2、删除用户 3、删除明细 
        string strSQL = " Delete W_GCGD_USERS from W_GCGD_USERS,W_GCGD1 where W_GCGD_USERS.GCDID=W_GCGD1.ID and W_GCGD1.GCDH='" + Label_GCBH.Text + "' ";
        strSQL += " Delete W_GCGD_FS from W_GCGD_FS,W_GCGD2 where W_GCGD2.ID=GCMXID and W_GCGD2.GCDH='" + Label_GCBH.Text + "'";
        strSQL += " Delete from W_GCGD2 Where GCDH='" + Label_GCBH.Text + "'";
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "单据明细删除成功。");
            Load_GridView1();
            return;
        }
        else
        {
            MessageBox("", "单据删除失败。<br/>错误：" + strSQL);
            return;
        }
    }

    /// <summary>
    /// 跳转到上一单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        IGDID = Convert.ToInt32(Request["ID"]) - 1;
        Response.Redirect("/GDGL/GCGDAdd.ASPX?ID=" + IGDID);
    }

    /// <summary>
    /// 跳转到下一单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        IGDID = Convert.ToInt32(Request["ID"]) + 1;
        Response.Redirect("/GDGL/GCGDAdd.ASPX?ID=" + IGDID);
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("/GDGL/GCGDINFO.ASPX?GCDH=" + Label_GCBH.Text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView_GDAdd.EditIndex = e.NewEditIndex;

        Load_GridView1();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_GDAdd.EditIndex = -1;
        Load_GridView1();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {///更新数据
        int iid = Convert.ToInt32(e.Keys[0]);
        string strTemp = string.Empty;
        if (iid > -1)
        {
            string DB_AZWZ = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
            string DB_SBBH = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            string DB_SBMC = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            string DB_SBPP = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            string DB_SBXH = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            string DB_JLDW = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
            double DB_sl = Convert.ToDouble(((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[6].Controls[0])).Text);
            string DB_Remark = ((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[7].Controls[0])).Text;
            int DB_BXFS = Convert.ToInt32(((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[8].Controls[0])).Text);
            int DB_AZFS = Convert.ToInt32(((TextBox)(GridView_GDAdd.Rows[e.RowIndex].Cells[11].Controls[0])).Text);

            if (DB_AZWZ.Length <= 0 || DB_SBBH.Length <= 0 || DB_SBBH.Length <= 0 || DB_SBPP.Length <= 0 || DB_JLDW.Length <= 0 || DB_BXFS < 0 || DB_AZFS < 0)
            {
                MessageBox("", "各个字段均不允许为空，积分不允许<0,请认真检查。<br>更新失败。");
                return;
            }
            else
            {
                string strSQL = "Update W_GCGD2 Set AZWZ='" + DB_AZWZ + "',SBBH='" + DB_SBBH + "',SBMC='" + DB_SBMC + "',SBPP='" + DB_SBPP + "',SBXH='" + DB_SBXH + "',JLDW='" + DB_JLDW + "',SL=" + DB_sl + ",FS=" + DB_BXFS + ",AZFS=" + DB_AZFS + ",YQSM='" + DB_Remark + "',LTime=Getdate() Where ID=" + iid;

                if (!OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("", "更新错误。<br/>错误：" + OP_Mode.strErrMsg);
                }
                else
                {
                    MessageBox("", "数据更新成功。");
                }
            }
        }
        MessageBox("", strTemp);
        GridView_GDAdd.EditIndex = -1;
        Load_GridView1();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        PostZBData("", "", "");
    }

    /// <summary>
    /// 提交到腾讯地图存储坐标信息
    /// </summary>
    /// <param name="DB_1">内部名称</param>
    /// <param name="DB_2">坐标地址</param>
    /// <param name="DB_3">坐标</param>
    /// <returns></returns>
    private string PostZBData(string DB_1, string DB_2, string DB_3)
    {
        // 规划线路两点线路，公交
        //https://apis.map.qq.com/ws/direction/v1/transit/?from=31.853897,117.303472&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX
        // 规划线路两点线路，驾车
        //https://apis.map.qq.com/ws/direction/v1/driving/?from=31.853832,117.303437&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX
        string rValue = string.Empty;
        // 腾讯地图插入数据URL
        string PostURL = "https://apis.map.qq.com/place_cloud/data/create";
        // 腾讯地图Key
        string TententMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";
        // 腾讯地图云签到点 ID
        string TententTableID = "0p14UnzPpSeGP5XMT1";
        DB_1 = "临时设置地址名称";
        DB_3 = "31.705859,117.302176";
        DB_2 = "测试地址";
        string data = string.Empty;

        data = "{";
        data += "\"key\":\"" + TententMapKey + "\",";
        data += "\"table_id\":\"" + TententTableID + "\",";
        data += "\"data\":[";
        data += "{";
        data += "\"title\":\"" + DB_1 + "\",";
        // "address":"北京市海淀区海淀南路24号院",
        data += "\"address\":\"" + DB_2 + "\",";
        data += "\"location\":{";
        data += "\"lat\":" + DB_3.Substring(0, DB_3.IndexOf(",") + 1) + "";
        data += "\"lng\":" + DB_3.Substring(DB_3.IndexOf(",") + 1, DB_3.Length - DB_3.IndexOf(",") - 1) + "";
        data += "}";
        data += "}";
        data += "]";

        string ReturnTemp = PostWeixinPage(PostURL, data);

        TextBox_YQSM.Text = ReturnTemp + "\r\n" + data;

        return rValue;
    }

    protected void flag0_Click(object sender, EventArgs e)
    {
        MessageBox("状态0");
    }
}