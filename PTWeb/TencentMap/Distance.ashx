<%@ WebHandler Language="C#" Class="Distance" %>

using Newtonsoft.Json;
using System;
using System.Web;

public class Distance : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var resObj = new
        {
            Distance = rValueString(context.Request["From1"].ToString(), context.Request["From2"].ToString(), context.Request["To1"].ToString(), context.Request["To2"].ToString())
        };
        context.Response.Write(JsonUtils.SerializeToJson(resObj));
    }

    /// <summary>
    /// 依据两点坐标返回两点之间驾车距离和时间，公交距离和时间
    /// </summary>
    /// <param name="FromA1"></param>
    /// <param name="FromA2"></param>
    /// <param name="ToB1"></param>
    /// <param name="ToB2"></param>
    /// <returns>两点之间驾车距离和时间，公交距离和时间</returns>
    private string rValueString(string FromA1, string FromA2, string ToB1, string ToB2)
    {
        string QQMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";
        string rValue = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            // 规划线路两点线路，驾车
            //https://apis.map.qq.com/ws/direction/v1/driving/?from=31.853832,117.303437&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX
            // 规划线路两点线路，公交
            //https://apis.map.qq.com/ws/direction/v1/transit/?from=31.853897,117.303472&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX

            string strURL1 = string.Format("https://apis.map.qq.com/ws/direction/v1/driving/?from={0},{1}&to={2},{3}&key={4}", FromA1, FromA2, ToB1, ToB2, QQMapKey);
            var data1 = client.DownloadString(strURL1);
            Rootobject rb1 = JsonConvert.DeserializeObject<Rootobject>(data1);
            if (rb1.status == 0)
            { //查询成功
                rValue = "自  驾：总共 " + rb1.result.routes[0].distance / 1000 + " KM 预计需要：" + rb1.result.routes[0].duration + " 分钟";
            }
            string strURL = string.Format("https://apis.map.qq.com/ws/direction/v1/transit/?from={0},{1}&to={2},{3}&key={4}", FromA1, FromA2, ToB1, ToB2, QQMapKey);
            var data = client.DownloadString(strURL);
            Rootobject rb = JsonConvert.DeserializeObject<Rootobject>(data);
            if (rb.status == 0)
            { //查询成功
                rValue += "<BR>乘坐公交：总共 " + rb.result.routes[0].distance / 1000 + " KM 预计需要：" + rb.result.routes[0].duration + " 分钟";
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

    public class Rootobject
    {
        public int status { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public Route[] routes { get; set; }
    }

    public class Route
    {
        public string mode { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public int traffic_light_count { get; set; }
        public int toll { get; set; }
        public Restriction restriction { get; set; }
        public float[] polyline { get; set; }
        public Step[] steps { get; set; }
        public object[] cities { get; set; }
        public object[] tags { get; set; }
        public Taxi_Fare taxi_fare { get; set; }
    }

    public class Restriction
    {
        public int status { get; set; }
    }

    public class Taxi_Fare
    {
        public int fare { get; set; }
    }

    public class Step
    {
        public string instruction { get; set; }
        public int[] polyline_idx { get; set; }
        public string road_name { get; set; }
        public string dir_desc { get; set; }
        public int distance { get; set; }
        public string act_desc { get; set; }
        public string accessorial_desc { get; set; }
    }

}