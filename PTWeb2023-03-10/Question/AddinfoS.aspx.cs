using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Question_Default : PageBaseQuestion
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string LoginID = string.Empty;

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

    private void UpdateExcel()
    {
        int iCount = 0;
        string TempFilPath = "~/ExcelTemp/"; // 上传路径
        if (FileUpload1.HasFile == false)
        {
            MessageBox("", "请选择需要上传的文件。");
            return;
        }
        else
        {
            string IsXsl = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();
            if (IsXsl != ".xls" & IsXsl != ".xlsx")
            {
                MessageBox("", "您选择的不是电子表格文件，请重新选择。");
                return;
            }
            if (!Directory.Exists(Server.MapPath(TempFilPath)))
            {
                Directory.CreateDirectory(Server.MapPath(TempFilPath));
            }
            string filename = FileUpload1.FileName;
            string NewName = System.DateTime.Now.ToString("yyyy-MM-dd") + System.DateTime.Now.ToString("hh") + System.DateTime.Now.ToString("mm") + System.DateTime.Now.ToString("ss") + System.DateTime.Now.ToString("ffff") + IsXsl;
            string savePath = (Server.MapPath(TempFilPath) + NewName);
            FileUpload1.SaveAs(savePath);
            DataTable dt = GetExcelDatatable(savePath, NewName);
            int iRowsNum = dt.Rows.Count;
            DataRow[] dr = dt.Select();
            if (iRowsNum > 0)
            {
                iCount = InsetData(dt); /// 插入数据库
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
        //office2007之前 仅支持.xls
        //const string cmdText = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;IMEX=1';";
        //支持.xls和.xlsx，即包括office2010等版本的   HDR=Yes代表第一行是标题，不是数据；
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

            if (sheetName != "JKZX$")
            {
                MessageBox("", "请先下载模板页面，在模板页面上添加数据后再上传信息。", "/Question/Addinfos.aspx");
            }

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
        int TempI = 0;

        int Db_UserID = Convert.ToInt32(DefaultUser);
        string Db_MDR = UserNAME;

        string Db01 = "";
        string Db02 = "";
        string Db03 = "";
        string Db04 = "";
        string Db05 = "";
        string Db06 = "";
        string Db07 = "";
        string Db08 = "";
        string Db09 = "";
        string Db10 = "";
        string Db11 = "";
        string Db12 = "";
        string Db13 = "";
        string Db14 = "";
        string Db15 = "";
        string Db16 = "";
        string Db17 = "";
        string Db18 = "";
        string Db19 = "";

        string TempMsg = string.Empty;

        foreach (DataRow dr in dt.Rows)
        {
            Db01 = dr[0].ToString().Trim();
            Db02 = dr[1].ToString().Trim();
            Db03 = dr[2].ToString().Trim();
            Db04 = dr[3].ToString().Trim();
            Db05 = dr[4].ToString().Trim();
            Db06 = dr[5].ToString().Trim();
            Db07 = dr[6].ToString().Trim();
            Db08 = dr[7].ToString().Trim();
            Db09 = dr[8].ToString().Trim();
            Db10 = dr[9].ToString().Trim();
            Db11 = dr[10].ToString().Trim();
            Db12 = dr[11].ToString().Trim();
            Db13 = dr[12].ToString().Trim();
            Db14 = dr[13].ToString().Trim();
            Db15 = dr[14].ToString().Trim();
            Db16 = dr[15].ToString().Trim();
            Db17 = dr[16].ToString().Trim();
            Db18 = dr[17].ToString().Trim();
            Db19 = dr[18].ToString().Trim();
            string strSql = "Select * from Question_Info where ZJHM='" + Db06 + "'";
            if (OP_Mode.SQLRUN(strSql))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    TempI++;
                    TempMsg += TempI.ToString() + "、姓名：" + Db02 + " " + Db06 + "<br>";
                }
                else
                {
                    strSql = "Insert into Question_Info (UserID,MDR,XZ,NAME,SQM,XQM,MPH,ZJHM,HJD,GZDW,ZZMM,LXDH,SFJZ,JZJC,JZDD,WZYY,ZYFF,LWZS,WGY,LDZ,Remark) Values ";
                    strSql += " (" + Db_UserID.ToString() + ",'" + Db_MDR + "','" + Db01 + "','" + Db02 + "','" + Db03 + "','" + Db04 + "','" + Db05 + "','" + Db06 + "','" + Db07 + "','" + Db08 + "','" + Db09 + "','" + Db10 + "','" + Db11 + "','" + Db12 + "','" + Db13 + "','" + Db14 + "','" + Db15 + "','" + Db16 + "','" + Db17 + "','" + Db18 + "','" + Db19 + "')";

                    if (!OP_Mode.SQLRUN(strSql))
                    {
                        MessageBox("", "已成功上传[" + i + "]条数据。第[" + (i + 1) + "]条数据出错。<br/>错误原因：" + OP_Mode.strErrMsg);

                        return i;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        if (TempMsg.Length > 0)
        {
            TempMsg += "以上信息库里已经存在了。请检查。<br>";
        }
        if (i > 0)
        {
            TempMsg += "成功上传[" + i + "]条数据。<br>";
        }
        if (TempMsg.Length > 0)
        {
            MessageBox("", TempMsg);
        }
        return i;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        UpdateExcel();
    }
}