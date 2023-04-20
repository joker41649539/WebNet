using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Question_Default : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int iClassID = 0;
            try
            {
                iClassID = Convert.ToInt32(Request["ClassID"]);
                //GetWeChatOpenID();// 获取微信OPENID
                // CrieateDiv(iClassID);
            }
            catch
            {
                MessageBox("", "参数错误！", "/XMfight/Default.aspx");
                return;
            }
        }
    }

    private void CrieateDiv(int iClassID)
    {
        string strTempHtml = string.Empty;
        string strSQL = "Select * from S_Question where iClassID=" + iClassID;
        int iStyle = 0;
        string[] AirSelect;
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = "<h1 class=\"center\">" + OP_Mode.Dtv[0]["cTitle"].ToString() + "</h1>";
                for (int j = 0; j < OP_Mode.Dtv.Count; j++)
                {
                    AirSelect = OP_Mode.Dtv[j]["cContent"].ToString().Split(';');
                    iStyle = Convert.ToInt32(OP_Mode.Dtv[j]["iStyle"]);
                    //  0 单选 1 多选 2 文本 3 图片
                    switch (iStyle)
                    {
                        case 0://单选
                            strTempHtml += "<div class=\"col-xs-12\">";
                            strTempHtml += "  <div class=\"form-group\">";
                            strTempHtml += "    <label class=\"control-label bolder blue\" for=\"form-field-1\">" + OP_Mode.Dtv[j]["cName"].ToString() + "</label>";
                            strTempHtml += "    <div class=\"col-sm-9\">";
                            for (int i = 0; i < AirSelect.Length - 1; i++)
                            {
                                strTempHtml += " <div class=\"control-group\">";
                                strTempHtml += "   <div class=\"radio\">";
                                strTempHtml += "     <label>";
                                strTempHtml += "       <input name=\"form-field-radio\" type=\"radio\" class=\"ace\" />";
                                strTempHtml += "       <span class=\"lbl\">&nbsp;" + AirSelect[i] + "</span>";
                                strTempHtml += "     </label>";
                                strTempHtml += "   </div>";
                                strTempHtml += " </div>";
                            }
                            strTempHtml += "    </div>";
                            strTempHtml += " </div>";
                            strTempHtml += "</div>";
                            break;
                        case 1:// 多选
                            strTempHtml += "<div class=\"col-xs-12\">";
                            strTempHtml += "  <div class=\"form-group\">";
                            strTempHtml += "    <label class=\"control-label bolder blue\" for=\"form-field-1\">" + OP_Mode.Dtv[j]["cName"].ToString() + "</label>";
                            strTempHtml += "    <div class=\"col-sm-9\">";
                            for (int i = 0; i < AirSelect.Length - 1; i++)
                            {
                                strTempHtml += " <div class=\"control-group\">";
                                strTempHtml += "   <div class=\"radio\">";
                                strTempHtml += "     <label>";
                                strTempHtml += "       <input name=\"form-field-checkbox\" type=\"checkbox\" class=\"ace ace-checkbox-2\" />";
                                strTempHtml += "       <span class=\"lbl\">&nbsp;" + AirSelect[i] + "</span>";
                                strTempHtml += "     </label>";
                                strTempHtml += "   </div>";
                                strTempHtml += " </div>";
                            }
                            strTempHtml += "    </div>";
                            strTempHtml += " </div>";
                            strTempHtml += "</div>";
                            break;
                        case 2:// 文本框
                            strTempHtml += "<div class=\"col-xs-12\">";
                            strTempHtml += "  <div class=\"form-group\">";
                            strTempHtml += "    <label class=\"control-label bolder blue\" for=\"form-field-1\">" + OP_Mode.Dtv[j]["cName"].ToString() + "</label>";
                            strTempHtml += "    <div class=\"col-sm-9\">";
                            strTempHtml += "      <input type=\"text\" name=\"text" + j + "\" placeholder=\"请输入" + OP_Mode.Dtv[j]["cName"].ToString() + "\" class=\"col-xs-10 col-sm-5\" />";
                            strTempHtml += "    </div>";
                            strTempHtml += " </div>";
                            strTempHtml += "</div>";
                            break;
                        case 3:// 图片
                            break;
                    }
                }
            }
            if (strTempHtml.Length > 0)
            {
                Div1.InnerHtml = strTempHtml;
            }
        }
    }

    /// <summary>
    /// 微信登录
    /// </summary>
    private void GetWeChatOpenID()
    {
        /// 链接地址
        /// https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=https%3A%2F%2Fptweb.x76.com.cn%2FQuestion%2F&response_type=code&scope=snsapi_base#wechat_redirect
        string accessToken = string.Empty;
        string DeBugMsg = string.Empty;
        // 旭铭搏击
        string AppId = "wxf60778eb4d1003de";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = "4224c03a03edeba44cb4aab9b27678be";

        var code = string.Empty;
        var opentid = string.Empty;
        try
        {
            code = Request.QueryString["code"];
        }
        catch
        {
            MessageBox("", "微信Code获取错误，请重试或者联系管理员。", "/XMfight/Default.aspx");
            return;
        }

        if (string.IsNullOrEmpty(code))
        {
            MessageBox("", "微信Code获取错误，请重试或者联系管理员。", "/XMfight/Default.aspx");
            return;
        }
        else
        {
            string strWeixin_OpenID = string.Empty;

            string STRUSERID = string.Empty;

            if (strWeixin_OpenID == string.Empty || STRUSERID == string.Empty)
            {
                DeBugMsg += "<br> 没有所需的OPENID！";

                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppId, AppSecret, code);
                var data = client.DownloadString(url);
                //正确{"access_token":"67_ueOj0O0G5oECEyuIzILVqaQ4Xw53m3jTcm_4mwHgKthN1qC4ZWMkWgf41BTnTfTc4uAgon2b4bMjAVKsP5PKhGgNHwXy8M5_qVPSdkMyIoc","expires_in":7200,"refresh_token":"67_4VHmQ4Z2Y7nFSsanLvyEBs-b91DL4YKu_BxCX7wz7GYHHwjEX0aDRiqJGX0N7KMpqf7Iw-ISGeVBTSi9VaggpXBYOPYkXMGi-QkUYz-ZPVA","openid":"oDg2PuFTJIO5P0o_Q3KRG_HplGJ0","scope":"snsapi_userinfo"}
                //错误 {"errcode":40013,"errmsg":"invalid appid, rid: 642e2686-41db056e-17d82e67"}

                Rootobject rb = JsonConvert.DeserializeObject<Rootobject>(data);

                try
                {
                    opentid = rb.openid;
                    accessToken = rb.access_token;
                    if (opentid.Length <= 0)
                    {
                        MessageBox("", "微信登录Code获取OpID错误。<br>" + data.ToString(), "/XMfight/Default.aspx");
                        return;
                    }
                    else
                    {
                        HiddenField_OpenID.Value = rb.openid;
                    }
                }
                catch
                {
                    MessageBox("", "微信登录Code获取OpID错误。<br>" + data.ToString(), "/XMfight/Default.aspx");
                    return;
                }
            }
        }
    }

    /// <summary>
    ///  确认提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strTemp = string.Empty;

        strTemp += Request["text1"] + "|";
        strTemp += Request["radio1"] + "|";
        strTemp += Request["radio2"] + "|";
        strTemp += Request["radio3"] + "|";
        strTemp += Request["checkbox1"] + "|";
        strTemp += Request["checkbox2"] + "|";

        MessageBox("", "提交数据" + strTemp); ;
    }
}