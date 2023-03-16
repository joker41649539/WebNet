using OfficeOpenXml;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DefaultPH : PageBase
{
    #region pageParameters
    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 微信JS签名
        this.appId = WebConfigurationManager.AppSettings["AgentId"]; /// 企业微信ID
        this.timeStamp = getTimestamp();
        this.nonceStr = getNoncestr();
        this.signature = GenSignature_Woker(this.nonceStr, this.timeStamp);
        this.DataBind();
        if (!IsPostBack)
        {
            ShowLastQD();
            LoadGCNum();
            LoadJF();
        }
    }

    /// <summary>
    /// 读取加载积分
    /// </summary>
    private void LoadJF()
    {
        int WeekJF = 0;
        int MonthJF = 0;
        int YesDayJF = 0;
        int ToDayJF = 0;

        DateTime nowTime = DateTime.Now;
        #region 获取本周第一天
        //星期一为第一天  
        int weeknow = Convert.ToInt32(nowTime.DayOfWeek);

        //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
        weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
        int daydiff = (-1) * weeknow;

        //本周第一天  
        DateTime FirstDay = nowTime.AddDays(daydiff);
        #endregion
        string strSQL = string.Empty;
        // 1、工程安装积分计算、统计。
        strSQL += " Select";
        strSQL += " isnull((Select Sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100)  from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and USERID = " + DefaultUser + " and W_GCGD_FS.CTIME > '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'),0) DayAZFS,";
        strSQL += " isnull((Select Sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100)  from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and USERID = " + DefaultUser + " and W_GCGD_FS.CTIME > '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and W_GCGD_FS.CTIME <'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'),0) YesDayAZFS,";
        strSQL += " isnull((Select Sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100)  from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and USERID = " + DefaultUser + " and W_GCGD_FS.CTIME > '" + FirstDay.ToString("yyyy-MM-dd") + "'),0) WeekAZFS,";
        strSQL += " isnull((Select Sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100)  from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and USERID = " + DefaultUser + " and W_GCGD_FS.CTIME > '" + System.DateTime.Now.ToString("yyyy-MM-") + "01'),0) MonthAZFS,";
        // 2、工程布线积分--按照List表统计。

        // strSQL += " Select";
        strSQL += " isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS * W_GCGD2.FS / 100) NFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME > '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b, W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME < '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) DayBXFS,";
        strSQL += " isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS* W_GCGD2.FS/ 100) NFS,GCMXID from W_GCGD_FS_BXList a,(Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME > '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and LTIME < '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME < '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) YesDayBXFS,";
        strSQL += " isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS* W_GCGD2.FS/ 100) NFS,GCMXID from W_GCGD_FS_BXList a,(Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME > '" + FirstDay.ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME < '" + FirstDay.ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) WeekDayBXFS,";
        strSQL += " isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS* W_GCGD2.FS/ 100) NFS,GCMXID from W_GCGD_FS_BXList a,(Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME > '" + System.DateTime.Now.ToString("yyyy-MM-") + "01' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where UserID = " + DefaultUser + " and LTIME < '" + System.DateTime.Now.ToString("yyyy-MM-") + "01' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) MonthDayBXFS";


        // 3、维保单积分。

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                WeekJF = Convert.ToInt32(OP_Mode.Dtv[0]["WeekAZFS"]) + Convert.ToInt32(OP_Mode.Dtv[0]["WeekDayBXFS"]);
                MonthJF = Convert.ToInt32(OP_Mode.Dtv[0]["MonthAZFS"]) + Convert.ToInt32(OP_Mode.Dtv[0]["MonthDayBXFS"]);
                YesDayJF = Convert.ToInt32(OP_Mode.Dtv[0]["YesDayAZFS"]) + Convert.ToInt32(OP_Mode.Dtv[0]["YesDayBXFS"]);
                ToDayJF = Convert.ToInt32(OP_Mode.Dtv[0]["DayAZFS"]) + Convert.ToInt32(OP_Mode.Dtv[0]["DayBXFS"]);
            }
        }
        if (ToDayJF < 100)
        {
            Label_Day.ForeColor = System.Drawing.Color.Red;
            Label_Day.Font.Bold = true;
        }
        if (YesDayJF < 100)
        {
            Label_YesDay.ForeColor = System.Drawing.Color.Red;
            Label_YesDay.Font.Bold = true;
        }

        Label_Day.Text = ToDayJF.ToString();
        Label_YesDay.Text = YesDayJF.ToString();
        Label_Week.Text = WeekJF.ToString();
        Label_Month.Text = MonthJF.ToString();
    }

    /// <summary>
    /// 我要签到
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strQDRemark = RadioButtonList1.SelectedValue;
        if (strQDRemark.Length > 0)
        {
            InsertQZData(strQDRemark);
        }
        else
        {
            MessageBox("", "请点击选择签到类型。");
        }
    }

    /// <summary>
    /// 插入签到数据
    /// </summary>
    private void InsertQZData(string QDRemark)
    {
        string strJD = Hidden_JD.Value; //经度
        string strWD = Hidden_WD.Value; // 维度
        string strWZ = Hidden_WZ.Value;// 具体位置信息
        string strScreen = Hidden_Screen.Value; /// 设备分辨率
        string strName = Hidden_Name.Value; // 位置名称

        // 依据坐标地址，获取简单名称
        var client = new WebClient();
        client.Encoding = Encoding.UTF8;
        string TententMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";
        string strURL = "https://apis.map.qq.com/ws/geocoder/v1/?location=" + strWD + "," + strJD + "&key=" + TententMapKey + "&get_poi=0";
        var data = client.DownloadString(strURL);
        //"{\n    \"status\": 0,\n    \"message\": \"query ok\",\n    \"request_id\": \"77fd3d94-063d-453f-8e35-eeffa9a0eb8a\",\n    \"result\": {\n        \"location\": {\n            \"lat\": 31.85383,\n            \"lng\": 117.303457\n        },\n        \"address\": \"安徽省合肥市包河区巢湖路茶叶市场D区1号\",\n        \"formatted_addresses\": {\n            \"recommend\": \"包河区锦绣园(巢湖路西)\",\n            \"rough\": \"包河区锦绣园(巢湖路西)\"\n        },\n        \"address_component\": {\n            \"nation\": \"中国\",\n            \"province\": \"安徽省\",\n            \"city\": \"合肥市\",\n            \"district\": \"包河区\",\n            \"street\": \"巢湖路茶叶市场D区\",\n            \"street_number\": \"巢湖路茶叶市场D区1号\"\n        },\n        \"ad_info\": {\n            \"nation_code\": \"156\",\n            \"adcode\": \"340111\",\n            \"city_code\": \"156340100\",\n            \"name\": \"中国,安徽省,合肥市,包河区\",\n            \"location\": {\n                \"lat\": 31.793801,\n                \"lng\": 117.310133\n            },\n            \"nation\": \"中国\",\n            \"province\": \"安徽省\",\n            \"city\": \"合肥市\",\n            \"district\": \"包河区\"\n        },\n        \"address_reference\": {\n            \"business_area\": {\n                \"id\": \"14866831454685969030\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.8555,\n                    \"lng\": 117.303\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"famous_area\": {\n                \"id\": \"14866831454685969030\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.8555,\n                    \"lng\": 117.303\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"crossroad\": {\n                \"id\": \"258053\",\n                \"title\": \"马鞍山路/迎屏巷(路口)\",\n                \"location\": {\n                    \"lat\": 31.85514,\n                    \"lng\": 117.3011\n                },\n                \"_distance\": 260.5,\n                \"_dir_desc\": \"东南\"\n            },\n            \"town\": {\n                \"id\": \"340111002\",\n                \"title\": \"包公街道\",\n                \"location\": {\n                    \"lat\": 31.837959,\n                    \"lng\": 117.29163\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"street_number\": {\n                \"id\": \"475762619026716799429010\",\n                \"title\": \"巢湖路茶叶市场D区1号\",\n                \"location\": {\n                    \"lat\": 31.853847,\n                    \"lng\": 117.303718\n                },\n                \"_distance\": 24.8,\n                \"_dir_desc\": \"西\"\n            },\n            \"street\": {\n                \"id\": \"9103225048745597629\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.842798,\n                    \"lng\": 117.32119\n                },\n                \"_distance\": 49.8,\n                \"_dir_desc\": \"西\"\n            },\n            \"landmark_l2\": {\n                \"id\": \"11384582867635718374\",\n                \"title\": \"锦绣园\",\n                \"location\": {\n                    \"lat\": 31.853819,\n                    \"lng\": 117.30229\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            }\n        }\n    }\n}"

        string temp = data.Substring(data.IndexOf("rough") + 9);

        strName = data.Substring(data.IndexOf("rough") + 9, temp.IndexOf('"'));
        // 依据坐标地址，获取简单名称 结束

        if (strJD.Length + strWD.Length + strWZ.Length < 1)
        { /// 判断是否获取到位置信息
            MessageBox("", "位置信息获取失败。请重试。");
            return;
        }
        else
        {
            string strSQL = "Insert into W_KQ (Userid,ZB_JD,ZB_WD,ZB_WZ,CTIME,Screen,QDFlag,ZB_Name) values (" + DefaultUser + "," + strJD + "," + strWD + ",'" + strWZ + "',getdate(),'" + strScreen + "','" + QDRemark + "','" + strName + "')";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "签到成功。", "/WeChat/QDSearch.aspx");
            }
        }
    }

    /// <summary>
    /// 加载工程数量
    /// </summary>
    private void LoadGCNum()
    {
        string strSQL = "Select (Select count(*) BXCOUNT from (SELECT isnull(count(GCDID), 0) temp FROM S_YH_QXZ, W_GCGD_USERS WHERE QXZID = 3 AND USERID = " + DefaultUser + " AND W_GCGD_USERS.USERS = USERID group by GCDID) a) BXCOUNT,(Select count(*) BXCOUNT from (SELECT isnull(count(GCDID), 0) temp FROM S_YH_QXZ, W_GCGD_USERS WHERE QXZID = 4 AND USERID = " + DefaultUser + " AND W_GCGD_USERS.USERS = USERID group by GCDID) a) AZCOUNT";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_MyBXNum.Text = "[" + OP_Mode.Dtv[0]["BXCOUNT"].ToString() + "] 条布线工程";
                Label_MyAZNum.Text = "[" + OP_Mode.Dtv[0]["AZCOUNT"].ToString() + "] 条安装工程";

                //if (Convert.ToInt32(OP_Mode.Dtv[0]["BXCOUNT"]) > 0)
                //{
                //    DivBX.Visible = true;
                //}
                //else
                //{
                //    DivBX.Visible = false;
                //}

                //if (Convert.ToInt32(OP_Mode.Dtv[0]["AZCOUNT"]) > 0)
                //{
                //    DivAZ.Visible = true;
                //}
                //else
                //{
                //    DivAZ.Visible = false;
                //}
            }
        }
    }

    private void ShowLastQD()
    {
        string strTempHtml = string.Empty;
        string strSQL = "Select top 1 * from W_KQ where UserID=" + DefaultUser + " and len(QDFlag)>0 order by id desc";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (OP_Mode.Dtv[0]["QDFlag"].ToString() == "维修开始" || OP_Mode.Dtv[0]["QDFlag"].ToString() == "出差" || OP_Mode.Dtv[0]["QDFlag"].ToString() == "施工")
                {
                    strTempHtml = "<div class='alert alert-warning'>";
                }
                else
                {
                    strTempHtml = "<div class='alert alert-success'>";
                }
                strTempHtml += "      <span class='label label-purple label-sm'>已过 " + DiffHours(Convert.ToDateTime(OP_Mode.Dtv[0]["LTime"]), System.DateTime.Now).ToString("F2") + " 小时</span><br/>";
                if (Convert.ToDateTime(OP_Mode.Dtv[0]["LTime"]).ToString("yyyy-MM-dd") == System.DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    strTempHtml += "<strong>[" + Convert.ToDateTime(OP_Mode.Dtv[0]["LTime"]).ToString("HH:mm") + "] " + OP_Mode.Dtv[0]["QDFlag"].ToString() + "<br/>" + OP_Mode.Dtv[0]["ZB_NAME"].ToString() + "</strong>";
                }
                else
                {
                    strTempHtml += "<strong>[" + Convert.ToDateTime(OP_Mode.Dtv[0]["LTime"]).ToString("yyyy-MM-dd HH:mm") + "] " + OP_Mode.Dtv[0]["QDFlag"].ToString() + " " + OP_Mode.Dtv[0]["ZB_NAME"].ToString() + "</strong>";
                }
                strTempHtml += "</div>";
                string strCFlag = string.Empty;

                strCFlag = OP_Mode.Dtv[0]["QDFlag"].ToString();

                if (strCFlag == "维修开始")
                {
                    RadioButtonList1.SelectedValue = "维修结束";
                    RadioButtonList1.Enabled = false;
                }
                else if (strCFlag == "施工")
                {
                    RadioButtonList1.SelectedValue = "离场";
                    RadioButtonList1.Enabled = false;
                }
                else if (strCFlag == "出差")
                {
                    RadioButtonList1.SelectedValue = "到达";
                    RadioButtonList1.Enabled = false;
                }

                RadioButtonList1.Items.FindByValue("到达").Enabled = false;
                RadioButtonList1.Items.FindByValue("维修结束").Enabled = false;
                RadioButtonList1.Items.FindByValue("离场").Enabled = false;
            }
            else
            {
                RadioButtonList1.Items.FindByValue("到达").Enabled = false;
                RadioButtonList1.Items.FindByValue("维修结束").Enabled = false;
                RadioButtonList1.Items.FindByValue("离场").Enabled = false;
            }
        }
        if (strTempHtml.Length > 0)
        {
            Div_QDLastData.InnerHtml = strTempHtml;
        }
    }
    public double DiffHours(DateTime startTime, DateTime endTime)
    {
        TimeSpan hoursSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
        return hoursSpan.TotalHours;
    }
}