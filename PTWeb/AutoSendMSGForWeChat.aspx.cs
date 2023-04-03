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

        string WeiXinOpenID = "oDg2PuFTJIO5P0o_Q3KRG_HplGJ0";/// 陆晓钧的 普田公众号OPID，应该是用谢丰OPID

        /// 查询工程和布线所有人员名单。
        string strSQL = "Select CNAME+';' from (";
        strSQL += "SELECT S_USERINFO.ID,OpenID,CName,GCID,WID,a.UserID,CZRID,nFlag,a.LTime,GCDD,GCMC,a.Remark,case gcid when 0 then '['+nFlag+']'+a.Remark else  '['+nFlag+']'+GCMC end NRemark from S_USERINFO left join (Select GCID,UserID,CZRID,nFlag,W_WorkPlan.LTime,GCDD,GCMC,Remark,W_WorkPlan.ID WID from W_WorkPlan left join W_GCGD1 on GCID= W_GCGD1.id where W_WorkPlan.ltime between '" + STime + "' and '" + STime + "') a on UserID=S_USERINFO.ID,S_YH_QXZ where (FLAG=0  and S_USERINFO.id=S_YH_QXZ.USERID and (QXZID =3 or QXZID=4)) or FLAG=4 group by S_USERINFO.ID,OpenID,CNAME,GCID,a.UserID,CZRID,nFlag,a.LTime,GCDD,GCMC,a.Remark,WID ";
        strSQL += " ) a where nFlag is null for xml path('')";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                SendMSGByWeChart(WeiXinOpenID, "", "以下人员" + System.DateTime.Now.ToString("yyyy-MM-dd") + " 的工作计划未安排", OP_Mode.Dtv[0][0].ToString(), System.DateTime.Now.ToString("yyyy-MM-dd"), "请尽快给以上人员安排工作计划。");
            }
        }

        //1、每天晚上8点 检查积分情况，对于低于 200分的人员进行消息推送 让其填写积分
        //2、推送第二天工作计划


        //string strSQL = "Insert Into Temp1(Lu,ICOUNT) values ('00',1)";
        //OP_Mode.SQLRUN(strSQL);
    }
}