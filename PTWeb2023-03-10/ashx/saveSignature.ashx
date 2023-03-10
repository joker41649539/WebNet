<%@ WebHandler Language="C#" Class="UploadHandler" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// UploadHandler 的摘要说明
/// </summary>
public class UploadHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        try
        {
            if (context.Request.Files.Count < 1)
            {
                new Exception("无效请求111");
            }

            HttpPostedFile file = context.Request.Files["signatureData"];
            if (file == null || file.ContentLength == 0)
            {
                new Exception("无效签名222");
            }

            // 图片保存到 服务器 signatureFiles 文件夹，文件名使用 uuid;
            string filePath = context.Server.MapPath("~/signatureFiles/") + Guid.NewGuid().ToString() + ".png";
            file.SaveAs(filePath);

            context.Response.Write(JsonConvert.SerializeObject(new
            {
                status = 200,
                message = "保存成功"
            }, Formatting.Indented));

        }
        catch (Exception E)
        {
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                status = 500,
                message = "保存失败,错误原因:" + E.Message.ToString(),
        }, Formatting.Indented));
    }
}

public bool IsReusable
{
    get
    {
        return false;
    }
}
}
