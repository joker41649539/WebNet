using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AltMessage 的摘要说明
/// </summary>
public class AltMessage : System.Web.UI.Page
{
    public AltMessage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">提示消息</param>
    public void AceMessageBox(string sMessage)
    {
        Response.Write("<script>");
       // Response.Write("$(\"#paymentComplete\").click(function() {");
        Response.Write("bootbox.setLocale(\"zh_CN\");");
        Response.Write("bootbox.confirm(\"确定把修改该条记录状态为缴费完成?\", function(result) {");
        Response.Write("if (result) {");
        Response.Write("}");
       // Response.Write(" });");
        Response.Write("</script>");

    }
}