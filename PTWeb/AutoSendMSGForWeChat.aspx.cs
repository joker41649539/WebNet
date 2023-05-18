using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AutoSendMSGForWeChat : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SendMSG();
        }
    }

    private void SendMSG()
    {
        string STime = System.DateTime.Now.ToString("yyyy-MM-dd");
        //string ETime = Convert.ToDateTime(STime).AddDays(-1).ToString("yyyy-MM-dd");


        //1、如有未安排工作计划的人，将人员信息推送给谢丰，让其安排其工作

        string WeiXinOpenID = "oDg2PuPqe4Er_3cN9KV3jAlyuYM4";/// 小希的 普田公众号OPID，应该是用谢丰OPID
        string NotOpenID = "oDg2PuJWASl9-zcN5NcEHV8OU3Kg"; /// 去除戴国平

        string strSQL = string.Empty;
        // 查询工程和布线所有人员名单。
        strSQL = "Select CNAME+';' from (";
        strSQL += "SELECT S_USERINFO.ID,OpenID,CName,GCID,WID,a.UserID,CZRID,nFlag,a.LTime,GCDD,GCMC,a.Remark,case gcid when 0 then '['+nFlag+']'+a.Remark else  '['+nFlag+']'+GCMC end NRemark from S_USERINFO left join (Select GCID,UserID,CZRID,nFlag,W_WorkPlan.LTime,GCDD,GCMC,W_WorkPlan.Remark,W_WorkPlan.ID WID from W_WorkPlan left join W_GCGD1 on GCID= W_GCGD1.id where W_WorkPlan.ltime between '" + STime + "' and '" + STime + "') a on UserID=S_USERINFO.ID,S_YH_QXZ where (FLAG=0  and S_USERINFO.id=S_YH_QXZ.USERID and (QXZID =3 or QXZID=4)) or FLAG=4 group by S_USERINFO.ID,OpenID,CNAME,GCID,a.UserID,CZRID,nFlag,a.LTime,GCDD,GCMC,a.Remark,WID ";
        strSQL += " ) a where nFlag is null for xml path('')";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                SendMSGByWeChart(WeiXinOpenID, "GDGL/WorkPlan.aspx", "以下人员" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " 的工作计划未安排", OP_Mode.Dtv[0][0].ToString(), System.DateTime.Now.ToString("yyyy-MM-dd"), "请尽快给以上人员安排工作计划。");
            }
        }
        int MinJF = 200;
        /// 工程+施工人员 当前积分数统计
        strSQL = "Select ID,CNAME,OpenID,cOpenID,AZJF,NowBXFS,NowWXFS,AZJF+NowBXFS+NowWXFS SumFS from  (SELECT S_USERINFO.ID,CName,OpenID,cOpenID ,isnull((Select sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100) from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and W_GCGD_FS.CTIME  between CONVERT(VARCHAR(10),GETDATE(),120)+' 00:00:00' and CONVERT(VARCHAR(10),GETDATE(),120)+' 23:59:59' and USERID = S_USERINFO.ID),0) AZJF ,isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS * W_GCGD2.FS / 100) NFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME  between CONVERT(VARCHAR(10),GETDATE(),120)+' 00:00:00' and CONVERT(VARCHAR(10),GETDATE(),120)+' 23:59:59' and USERID = S_USERINFO.ID group by GCMXID, UserID) b, W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME < CONVERT(VARCHAR(10),GETDATE(),120)+' 00:00:00' and USERID = S_USERINFO.ID group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) NowBXFS ,Isnull((Select Sum(SumJF) from W_WXD where Ltime  between CONVERT(VARCHAR(10),GETDATE(),120)+' 00:00:00' and CONVERT(VARCHAR(10),GETDATE(),120)+' 23:59:59' and W_WXD.WXRY = S_USERINFO.ID and Del = 0 and FLAG = 1),0) NowWXFS from S_USERINFO,S_YH_QXZ where (FLAG = 0  and S_USERINFO.id = S_YH_QXZ.USERID and(QXZID = 3 or QXZID = 4)) or FLAG=4 group by S_USERINFO.ID,CNAME,SSDZ,OpenID,cOpenID ) aa ";
        strSQL += " where AZJF+NowBXFS+NowWXFS<" + MinJF + " and OpenID is not null and OpenID!='" + NotOpenID + "'"; // 累计分数小于 200分 开始消息推送

        if (OP_Mode.SQLRUN(strSQL, "SendMSG"))
        {
            if (OP_Mode.Dtv1.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv1.Count; i++)
                {
                    // if (OP_Mode.Dtv1[i]["OpenID"].ToString().Length > 0 && (OP_Mode.Dtv1[i]["OpenID"].ToString() == "oDg2PuFTJIO5P0o_Q3KRG_HplGJ0" || OP_Mode.Dtv1[i]["OpenID"].ToString() == "oDg2PuPqe4Er_3cN9KV3jAlyuYM4"))
                    if (OP_Mode.Dtv1[i]["OpenID"].ToString().Length > 0)
                    {
                        WeiXinOpenID = OP_Mode.Dtv1[i]["OpenID"].ToString();
                        SendMSGByWeChart(WeiXinOpenID, "", "您今日积分截止到目前严重不足。", "您是否忘记填写今日积分。", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"), "点击前往，立即填写。如有特殊情况请联系工作人员。");
                    }
                }
            }
        }

        //1、每天晚上8点 检查积分情况，对于低于 200分的人员进行消息推送 让其填写积分
        //2、推送第二天工作计划


        //string strSQL = "Insert Into Temp1(Lu,ICOUNT) values ('00',1)";
        //OP_Mode.SQLRUN(strSQL);
    }
}