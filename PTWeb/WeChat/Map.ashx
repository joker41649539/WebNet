<%@ WebHandler Language="C#" Class="Map" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class Map : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var resObj = new
        {
            address = GetZBToString(context.Request["longitude"].ToString(), context.Request["latitude"].ToString())
        };
        context.Response.Write(JsonUtils.SerializeToJson(resObj));
        //context.Response.Write("Hello World");
    }


    /// <summary>
    /// 依据坐标获得地址
    /// </summary>
    /// <returns></returns>
    public string GetZBToString(string latitude, string longitude)
    {
        string QQMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";

        string rValue = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            string url = string.Format("https://apis.map.qq.com/ws/geocoder/v1/?location={0},{1}&get_poi=1&key={2}", longitude, latitude, QQMapKey);
            var data = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var MapInfo = serializer.Deserialize<Dictionary<string, object>>(data);
            Dictionary<string, object> dataSet = (Dictionary<string, object>)MapInfo["result"];

            //使用KeyValuePair遍历数据
            foreach (KeyValuePair<string, object> item in dataSet)
            {
                if (item.Key.ToString() == "address")//获取header数据
                {
                    rValue = item.Value.ToString();
                    break;
                }
            }
        }

        return rValue;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}