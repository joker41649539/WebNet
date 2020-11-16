using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = Request.Url.AbsoluteUri + "<br/>";
            //  WeChatWorkLoad();
        }
    }

    /// <summary>
    /// 企业微信登录
    /// </summary>
    private void WeChatWorkLoad()
    {
        string accessToken = string.Empty;
        string DeBugMsg = string.Empty;

        string AppId = WebConfigurationManager.AppSettings["AgentId"];//与企业微信ID。
        string AppSecret = WebConfigurationManager.AppSettings["Secret"];

        var code = string.Empty;
        var opentid = string.Empty;
        try
        {
            code = Request.QueryString["code"];
            DeBugMsg += "code:" + code;
        }
        catch
        {

        }

        if (string.IsNullOrEmpty(code))
        {

        }
        else
        {
            string strWeixin_OpenID = string.Empty;

            string STRUSERID = string.Empty;

            if (strWeixin_OpenID == string.Empty || STRUSERID == string.Empty)
            {
                DeBugMsg += "<br> 没有所需的OPENID！";

                // this.Label1.Text = "没有所需的OPENID";
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", AppId, AppSecret);
                var data = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                var obj = serializer.Deserialize<Dictionary<string, string>>(data);

                if (!obj.TryGetValue("access_token", out accessToken))
                {
                    DeBugMsg += "<br> Token获取错误！";
                }
                else
                {
                    //opentid = obj["openid"];
                    //MessageBox("", "opentid：" + opentid);
                }

                // string tempToken = GetaccessWebToken(code);

                url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}", accessToken, code);
                data = client.DownloadString(url);
                var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);
                DeBugMsg += "userInfo：" + data.ToString();

                //                {
                //                    "errcode": 0,
                //   "errmsg": "ok",
                //   "UserId":"USERID",// 企业用户         OpenId// 非企业会员
                //   "DeviceId":"DEVICEID"
                //}



                try
                {
                    /// 企业用户
                    opentid = userInfo["UserId"].ToString();
                    Label2.Text = opentid + "<br>";

                    url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", accessToken, opentid);
                    data = client.DownloadString(url);
                    var userInfo2 = serializer.Deserialize<Dictionary<string, object>>(data);//gender 性别。0表示未定义，1表示男性，2表示女性
                    Label2.Text = "姓名：" + userInfo2["name"].ToString() + "<br>性别：" + userInfo2["gender"].ToString() + "<br>头像：" + userInfo2["thumb_avatar"].ToString();
                }
                catch
                {
                    Label2.Text = userInfo["OpenId"].ToString();
                    /// 出错了，则是非企业用户
                  //  MessageBox("", "您非企业员工！<br/>请先登陆！", "/Login.aspx");
                    return;
                }

            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SedMsg(40);
    }

    /// <summary>
    /// 给指定权限组的人发送消息
    /// </summary>
    /// <param name="IID">维保单的ID号码</param>
    private void SedMsg(int IID)
    {
        int iQXZ = 5;// 判断需要发送的群组的权限组ID

        string strSQL = "Select isnull(cOpenID,'') from S_YH_QXZ,S_USERINFO where QXZID=" + iQXZ.ToString() + " and USERID=id";

        string strUsers = string.Empty; // 需要发送的用户列表用 “|”分割；

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strUsers += OP_Mode.Dtv[i][0].ToString() + "|";
                }
            }
        }

        if (strUsers.Length > 0)
        {
            SendWorkMsgCard(strUsers, "维修报告单完成提示", " <h1>" + UserNAME + "</h1> 完成了一张维修报告单。", "ptweb.x76.com.cn/BGGL/GCWXD.ASPX?ID=" + IID + "&WeChat=0");
        }
    }
}