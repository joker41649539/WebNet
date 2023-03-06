using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCBXDel : PageBase
{
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
            /// 2023-02-17 取消按权限删除积分。所有人均可删除积分，积分删除后消息推送给删除者和被删除者，记录积分删除记录。
            //if (!QXBool(46, Convert.ToInt32(DefaultUser)))
            //{
            //    MessageBox("", "您没有积分的权限。", Defaut_QX_URL);
            //    return;
            //}
            //else
            //{
            try
            {
                DelJF(Convert.ToInt32(Request["ID"]));
            }
            catch
            {
                MessageBox("", "积分删除失败,请重试。", "/GDGL/");
            }
            //}
        }

    }

    /// <summary>
    /// 删除积分，并推送企业消息给涉事双方以及相关领导，并保存删除记录。
    /// </summary>
    /// <param name="IID"></param>
    private void DelJF(int IID)
    {
        /// 消息推送给 戴国平，谢丰 和 两个涉事人员
        string strSQL = string.Empty;

        string strSendMsgMan = string.Empty;

        // 固定赋值给 戴国平和谢丰
        //  strSendMsgMan = "DaiGuoPing|XieFeng_1|";

        string strMsg = string.Empty;// 需要发送的消息内容。

        // 1、工程名

        /// 查询相关信息，用于发送信息时需要的资料
        strSQL += " Select GCMC,AZWZ,SBMC,SBBH,CNAME,cOpenID,GCMXID,(Select copenid from s_userinfo where id=" + DefaultUser + ") DelManOpenId from W_GCGD1,w_gcgd2,W_GCGD_FS,S_USERINFO where W_GCGD1.GCDH=W_GCGD2.GCDH and USERID=S_USERINFO.ID and w_gcgd2.id=W_GCGD_FS.GCMXID and W_GCGD_FS.ID=" + IID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                /// 添加两个 涉事人的OPID
                strSendMsgMan += OP_Mode.Dtv[0]["cOpenID"].ToString() + "|" + OP_Mode.Dtv[0]["DelManOpenId"].ToString();
                strMsg = OP_Mode.Dtv[0]["GCMC"].ToString() + "-" + OP_Mode.Dtv[0]["AZWZ"].ToString() + "-" + OP_Mode.Dtv[0]["SBMC"].ToString() + OP_Mode.Dtv[0]["SBBH"].ToString() + " ";
                strMsg += " 里 【" + OP_Mode.Dtv[0]["CNAME"].ToString() + "】 的布线积分占比已经被 【" + UserNAME + "】 删除。 请您知晓。";
                int gcmxid = Convert.ToInt32(OP_Mode.Dtv[0]["GCMXID"].ToString());
                strSQL = " insert into W_GCGD_FS_DelList (Operator,DelMan,GCMXID,FS,MXRemark,SenMsgMan) Select '" + UserNAME + "',CNAME,gcmxid,AZFS,Remark,'" + strSendMsgMan + "' from W_GCGD_FS,S_USERINFO where USERID=S_USERINFO.ID and W_GCGD_FS.ID=" + IID;
                strSQL += " Delete from W_GCGD_FS where id=" + IID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    SendWorkMsgCard(strSendMsgMan, "工程布线积分删除通知", strMsg, "www.putian.ink/default.aspx?Wechat=0");
                    MessageBox("", "积分删除成功。", "/GDGL/GCBXListPH.ASPX?ID=" + gcmxid);
                }
                else
                {
                    MessageBox("", "积分删除失败,请重试。", "/GDGL/");
                }

            }
        }

    }
}