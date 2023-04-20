<%@ WebHandler Language="C#" Class="PrivateMap" %>

using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Configuration;



public class PrivateMap : IHttpHandler
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public static string DefaultConStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var resObj = new
        {
            address = GetZBToString(context.Request["longitude"].ToString(), context.Request["latitude"].ToString())
        };
        context.Response.Write(JsonUtils.SerializeToJson(resObj));
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
        public Location location { get; set; }
        public string address { get; set; }
        public Formatted_Addresses formatted_addresses { get; set; }
        public Address_Component address_component { get; set; }
        public Ad_Info ad_info { get; set; }
        public Address_Reference address_reference { get; set; }
        public int poi_count { get; set; }
        public Pois[] pois { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Formatted_Addresses
    {
        public string recommend { get; set; }
        public string rough { get; set; }
    }

    public class Address_Component
    {
        public string nation { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
    }

    public class Ad_Info
    {
        public string nation_code { get; set; }
        public string adcode { get; set; }
        public string phone_area_code { get; set; }
        public string city_code { get; set; }
        public string name { get; set; }
        public Location1 location { get; set; }
        public string nation { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
    }

    public class Location1
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Address_Reference
    {
        public Business_Area business_area { get; set; }
        public Famous_Area famous_area { get; set; }
        public Crossroad crossroad { get; set; }
        public Town town { get; set; }
        public Street_Number street_number { get; set; }
        public Street street { get; set; }
        public Landmark_L2 landmark_l2 { get; set; }
    }

    public class Business_Area
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location2 location { get; set; }
        public int _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location2
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Famous_Area
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location3 location { get; set; }
        public int _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location3
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Crossroad
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location4 location { get; set; }
        public float _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location4
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Town
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location5 location { get; set; }
        public int _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location5
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Street_Number
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location6 location { get; set; }
        public float _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location6
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Street
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location7 location { get; set; }
        public float _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location7
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Landmark_L2
    {
        public string id { get; set; }
        public string title { get; set; }
        public Location8 location { get; set; }
        public int _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location8
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Pois
    {
        public string id { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public Location9 location { get; set; }
        public Ad_Info1 ad_info { get; set; }
        public float _distance { get; set; }
        public string _dir_desc { get; set; }
    }

    public class Location9
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Ad_Info1
    {
        public string adcode { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
    }

    public class RootobjectP
    {
        public int status { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }
        public ResultP result { get; set; }
    }

    public class ResultP
    {
        public int count { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int adcode { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int create_time { get; set; }
        public string district { get; set; }
        public int geometry_type { get; set; }
        public string id { get; set; }
        public LocationP location { get; set; }
        public string polygon { get; set; }
        public string province { get; set; }
        public string tel { get; set; }
        public string title { get; set; }
        public string ud_id { get; set; }
        public int update_time { get; set; }
        public X x { get; set; }
    }

    public class LocationP
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class X
    {
    }

    /// <summary>
    /// 依据坐标获得地址
    /// </summary>
    /// <returns></returns>
    public string GetZBToString(string latitude, string longitude)
    {
        string QQMapKey = "Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX";
        int iScope = 200;//搜索范围

        string rValue = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            //strZB = "31.85367,117.3034";
            //  https://apis.map.qq.com/place_cloud/search/nearby?key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX&table_id=0p14UnzPpSeGP5XMT1&location=31.85367,117.3034&radius=200
            /// 私有库查询地址信息
            string strURL = string.Format("https://apis.map.qq.com/place_cloud/search/nearby?key={2}&table_id=0p14UnzPpSeGP5XMT1&location={0},{1}&radius={3}", longitude, latitude, QQMapKey, iScope);
            var dataP = client.DownloadString(strURL);
            RootobjectP rbP = JsonConvert.DeserializeObject<RootobjectP>(dataP);
            if (rbP.status == 0)
            {
                if (rbP.result.count > 0)
                {/// 查询到数据了
                    rValue = rbP.result.data[0].address + ";" + rbP.result.data[0].title + ";" + GetGCMCByMapID(rbP.result.data[0].id);
                }
                else
                { // 未查询到数据

                    string url = string.Format("https://apis.map.qq.com/ws/geocoder/v1/?location={0},{1}&get_poi=1&key={2}", longitude, latitude, QQMapKey);
                    var data = client.DownloadString(url);
                    var serializer = new JavaScriptSerializer();

                    Rootobject rb = JsonConvert.DeserializeObject<Rootobject>(data);

                    rValue = rb.result.address;
                    rValue += ";" + rb.result.formatted_addresses.recommend;
                }
            }
        }

        return rValue;
    }
    // 规划线路两点线路，公交
    //https://apis.map.qq.com/ws/direction/v1/transit/?from=31.853897,117.303472&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX
    // 规划线路两点线路，驾车
    //https://apis.map.qq.com/ws/direction/v1/driving/?from=31.853832,117.303437&to=31.88075,117.345877&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX

    /// <summary>
    /// 依据地图ID查询工程信息
    /// </summary>
    /// <param name="MapID"></param>
    /// <returns>返回工程手工编号和工程名称</returns>
    private string GetGCMCByMapID(string MapID)
    {
        string rValue = string.Empty;
        // 641139784e0d8c84a62637a3 普田总部ID
        string strSQL = "Select SGDH,GCMC,nFlag from W_GCGD1,W_WorkPlan where TencentMapID='" + MapID + "' and W_GCGD1.ID=GCID and UserID=2 and W_WorkPlan.LTime between '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {// 在计划地点  正常签到
                rValue = MapID + ";" + OP_Mode.Dtv[0]["nFlag"].ToString() + ";" + OP_Mode.Dtv[0]["SGDH"].ToString() + ";" + OP_Mode.Dtv[0]["GCMC"].ToString();
            }
            else
            {// 不在计划地点   但是到私有库地点，算正常签到
                rValue = MapID;
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