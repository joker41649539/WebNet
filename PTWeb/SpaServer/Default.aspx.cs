﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpaServer_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label_Distance.Text = rValueDistance(31.85374, 117.30346, 30.94482, 118.755587);
        }
    }

    /// <summary>
    /// 依据两点坐标返回两点之间驾车距离和时间，公交距离和时间
    /// </summary>
    /// <param name="FromA1"></param>
    /// <param name="FromA2"></param>
    /// <param name="ToB1"></param>
    /// <param name="ToB2"></param>
    /// <returns>两点之间驾车距离和时间，公交距离和时间</returns>
    private string rValueDistance(double FromA1, double FromA2, double ToB1, double ToB2)
    {
        string QQMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";
        string rValue = "0";
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            // 多对多点坐标驾车距离计算
            //https://apis.map.qq.com/ws/distance/v1/matrix/?mode=driving&from=39.984092,116.306934;40.007763,116.353798&to=39.981987,116.362896;39.949227,116.394310&key=OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77
            //

            // 规划线路两点线路，驾车
            //https://apis.map.qq.com/ws/direction/v1/driving/?from=31.853832,117.303437&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX

            string strURL1 = string.Format("https://apis.map.qq.com/ws/direction/v1/driving/?from={0},{1}&to={2},{3}&key={4}", FromA1, FromA2, ToB1, ToB2, QQMapKey);
            var data1 = client.DownloadString(strURL1);
            Rootobject rb1 = JsonConvert.DeserializeObject<Rootobject>(data1);
            if (rb1.status == 0)
            { //查询成功
                rValue = (Convert.ToDouble(rb1.result.routes[0].distance) / Convert.ToDouble(1000)).ToString("#0.00");
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