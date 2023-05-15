using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : PageBase
{

    #region pageParameters
    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        // Test();
        // TextBox4.Text = GetClientInternetIP();
        this.appId = WebConfigurationManager.AppSettings["CorpId"];
        this.timeStamp = getTimestamp();
        this.nonceStr = getNoncestr();
        this.signature = GenSignature(this.nonceStr, this.timeStamp);
        this.DataBind();

        Label1.Text = Request["code"];
    }
}

private string GenSignature(string nonecStr, string timeStamp)
{
    string jsApiTicket = GetJsApiTicket();
    string url = Request.Url.AbsoluteUri;

    string sourceData = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", jsApiTicket, nonecStr, timeStamp, url);

    using (SHA1 sha1 = new SHA1CryptoServiceProvider())
    {
        byte[] sourceDataBytes = Encoding.ASCII.GetBytes(sourceData);
        byte[] hashDataBytes = sha1.ComputeHash(sourceDataBytes);
        string hash = BitConverter.ToString(hashDataBytes).Replace("-", "");
        hash = hash.ToLower();
        return hash;
    }

}

private string GetJsApiTicket()
{
    string jsApiTicket = string.Empty;
    using (var client = new System.Net.WebClient()
    {
        Encoding = System.Text.Encoding.UTF8
    })
    {
        string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token={0}", GetaccessToken());
        string data = client.DownloadString(url);

        var serializer = new JavaScriptSerializer();
        var obj = serializer.Deserialize<Dictionary<string, string>>(data);

        if (!obj.TryGetValue("ticket", out jsApiTicket))
        {
            //foreach (var key in obj.Keys)
            //{
            //    MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
            //}
        }
        else
        {
            //MSG = (Convert.ToDecimal(obj["expires_in"]) / 60).ToString();

            //strSQL = "UPDATE S_TYDM SET CTIME=GETDATE(), LTIME = DATEADD(S," + obj["expires_in"] + ",GETDATE()),CTYDMZ='" + sValue + "' WHERE ITYDMLB=1";

            //if (OP_Mode.SQLRUN(strSQL))
            //{

            //}
            //foreach (var key in obj.Keys)
            //{
            //    MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
            //}

            //https://api.weixin.qq.com/cgi-bin/groups/getid?access_token=w-_XJt6nrpn3U-X1DLPBN8tGLEt5YlV9hJmLXQOQoOrlK5jSRJ7qJPV00PMvnW5SDIMvavmzvpmTyBw2cSFgcirTZ6s6-yPnp-td-P2H4EI&openid=ollQItx5i3C0IUC_sQRvEzzQfXE4&lang=zh_CN
        }
    }

    return jsApiTicket;
}

private void Test()
{
    string strTemp = string.Empty;
    strTemp += "<script src='http://res.wx.qq.com/open/js/jweixin-1.0.0.js'></script>\r\n";
    strTemp += "<script>\r\n";
    strTemp += " wx.config({\r\n";
    strTemp += " debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。\r\n";
    strTemp += "        appId: '" + WebConfigurationManager.AppSettings["CorpId"] + "', // 必填，企业号的唯一标识，此处填写企业号corpid\r\n";
    strTemp += "        timestamp: '" + getTimestamp() + "', // 必填，生成签名的时间戳\r\n";
    strTemp += "        signature: '" + GetaccessToken() + "',// 必填，签名，见附录1\r\n";
    strTemp += "        jsApiList: [\r\n";
    strTemp += "            'openLocation',\r\n";
    strTemp += "            'getLocation'\r\n";
    strTemp += "       ]\r\n";
    strTemp += "   });\r\n";
    strTemp += " wx.error(function(res) {\r\n";
    strTemp += "    alert(res.errMsg);\r\n";
    strTemp += "  });\r\n";
    strTemp += "  </script>\r\n";

    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", strTemp, false);
}

/// <summary>
/// 发送测试消息
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
protected void Button1_Click(object sender, EventArgs e)
{
    // SendWeChatDDFH("ooUML6EsI6okXuBBhZ-_l4ur204Y", "11", "11", "11", "11", "11", "11", "11", "#");

    SendWorkMsgCard("LuXiaoJun", "积分删除通知", "您的XXX项目的XXX设备的积分被XXX删除。请确认。", "www.putian.ink/default.aspx?Wechat=0");
}

protected void Button1_Click1(object sender, EventArgs e)
{
    SendWorkMsgCard("LuXiaoJun|XiWeiJia", "积分删除通知", "您的XXX项目的XXX设备的积分被XXX删除。请确认。", "www.putian.ink/default.aspx?Wechat=0");
}

#region "GridView1 读取测试 相关代码"
/// <summary>

/// 模块列表读取

/// </summary>

private void Load_GridView1()

{

    // 获取GridView排序数据列及排序方向

    string sortExpression = this.GridView1.Attributes["SortExpression"];

    string sortDirection = this.GridView1.Attributes["SortDirection"];

    string strSQL;

    strSQL = "SELECT * FROM S_Bug ORDER BY ID";

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

        this.GridView1.BottomPagerRow.Visible = true;

    }

    else

    {

        MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

        return;

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

    //string ID = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

    ///// 模块名称

    //string DB_01 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

    //string DB_02 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

    //if (!(DB_01.Length > 0))

    //{

    //    MessageBox(GridView1_UpdatePanel1, "", "ID不允许为空！<br/>请认真填写。");

    //    return;

    //}

    //string strSQL = string.Empty;

    //strSQL = "Update S_Bug SET ID='" + DB_01 + "', Title='" + DB_02 + "', LTIME=GETDATE() WHERE ID=" + ID;

    //if (OP_Mode.SQLRUN(strSQL))

    //{

    //    MessageBox(GridView1_UpdatePanel1, "", "数据更新成功!");

    //}

    //else

    //{

    //    MessageBox(GridView1_UpdatePanel1, "", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

    //    return;

    //}

    //GridView1.SelectedIndex = -1;

    //GridView1.EditIndex = -1;

    //Load_GridView1();

}

/// <summary>

/// 

/// </summary>

/// <param name="sender"></param>

/// <param name="e"></param>

protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)

{

    if (e.CommandName == "GridView1_ADD")

    {

        ScriptManager.RegisterStartupScript(GridView1_UpdatePanel1, this.GetType(), "sKey", "$('#GridView1_ADD').modal('show');", true);

    }

}

/// <summary>

/// 模块数据保存

/// </summary>

/// <param name="sender"></param>

/// <param name="e"></param>

protected void GridView1_LinkButton1_Click(object sender, EventArgs e)

{

    /// ID

    string DB_01 = this.GridView1_TextBox_ID.Text.Trim().Replace("'", "\"");

    /// 标题

    string DB_02 = this.GridView1_TextBox_Title.Text.Trim().Replace("'", "\"");

    if (!(DB_01.Length > 0))

    {

        MessageBox("", "登录名称不允许为空！<br/>请认真填写。");

        return;

    }

    string strSQL;

    strSQL = "Insert into S_Bug ( ID, Title,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "',GETDATE(),GETDATE()) ";

    if (OP_Mode.SQLRUN(strSQL))

    {

        MessageBox(GridView1_UpdatePanel1, "", "测试信息添加成功!", Request.Url.LocalPath);

    }

    else

    {

        MessageBox(GridView1_UpdatePanel1, "", "测试信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

        return;

    }

    Load_GridView1();

}

/// <summary>

/// 

/// </summary>

/// <param name="sender"></param>

/// <param name="e"></param>

protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)

{

    //如果是绑定数据行 

    if (e.Row.RowType == DataControlRowType.DataRow)

    {

        if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

        {

            ((LinkButton)e.Row.Cells[3].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");

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

    string strSQL = "Delete from S_Bug where ID=" + ID;

    if (OP_Mode.SQLRUN(strSQL))

    {

        MessageBox(GridView1_UpdatePanel1, "", "指定数据删除成功^_^！");

        Load_GridView1();

    }

    else

    {

        MessageBox(GridView1_UpdatePanel1, "", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);

    }

}

protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

{

    GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

    GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

}

    #endregion
}