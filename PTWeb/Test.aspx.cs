using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        Test1();
        //}
    }

    public class resultBig
    {
        public string message { get; set; }

        public string status { get; set; }

        public List<result> results { get; set; }
    }

    public class result
    {
        public string address { get; set; }
        public List<formatted_addresses> formatted_Addresses { get; set; }
    }

    public class formatted_addresses
    {
        public string rough { get; set; }
    }

    private void Test1()
    {
        string MSG = string.Empty;
        var client = new WebClient();
        client.Encoding = Encoding.UTF8;
        string strURL = "https://apis.map.qq.com/ws/geocoder/v1/?location=31.876072,117.341317&key=Q4KBZ-CNBCW-J6ER6-RWZNB-FCVYZ-TWBGX&get_poi=0";
        var data = client.DownloadString(strURL);

        string temp = data.Substring(data.IndexOf("rough") + 9);

        TextBox1.Text = data.Substring(data.IndexOf("rough") + 9, temp.IndexOf('"'));
        //var result = JsonConvert.DeserializeObject<JObject>(data);

        // var serializer = new JavaScriptSerializer();

        //"{\n    \"status\": 0,\n    \"message\": \"query ok\",\n    \"request_id\": \"77fd3d94-063d-453f-8e35-eeffa9a0eb8a\",\n    \"result\": {\n        \"location\": {\n            \"lat\": 31.85383,\n            \"lng\": 117.303457\n        },\n        \"address\": \"安徽省合肥市包河区巢湖路茶叶市场D区1号\",\n        \"formatted_addresses\": {\n            \"recommend\": \"包河区锦绣园(巢湖路西)\",\n            \"rough\": \"包河区锦绣园(巢湖路西)\"\n        },\n        \"address_component\": {\n            \"nation\": \"中国\",\n            \"province\": \"安徽省\",\n            \"city\": \"合肥市\",\n            \"district\": \"包河区\",\n            \"street\": \"巢湖路茶叶市场D区\",\n            \"street_number\": \"巢湖路茶叶市场D区1号\"\n        },\n        \"ad_info\": {\n            \"nation_code\": \"156\",\n            \"adcode\": \"340111\",\n            \"city_code\": \"156340100\",\n            \"name\": \"中国,安徽省,合肥市,包河区\",\n            \"location\": {\n                \"lat\": 31.793801,\n                \"lng\": 117.310133\n            },\n            \"nation\": \"中国\",\n            \"province\": \"安徽省\",\n            \"city\": \"合肥市\",\n            \"district\": \"包河区\"\n        },\n        \"address_reference\": {\n            \"business_area\": {\n                \"id\": \"14866831454685969030\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.8555,\n                    \"lng\": 117.303\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"famous_area\": {\n                \"id\": \"14866831454685969030\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.8555,\n                    \"lng\": 117.303\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"crossroad\": {\n                \"id\": \"258053\",\n                \"title\": \"马鞍山路/迎屏巷(路口)\",\n                \"location\": {\n                    \"lat\": 31.85514,\n                    \"lng\": 117.3011\n                },\n                \"_distance\": 260.5,\n                \"_dir_desc\": \"东南\"\n            },\n            \"town\": {\n                \"id\": \"340111002\",\n                \"title\": \"包公街道\",\n                \"location\": {\n                    \"lat\": 31.837959,\n                    \"lng\": 117.29163\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            },\n            \"street_number\": {\n                \"id\": \"475762619026716799429010\",\n                \"title\": \"巢湖路茶叶市场D区1号\",\n                \"location\": {\n                    \"lat\": 31.853847,\n                    \"lng\": 117.303718\n                },\n                \"_distance\": 24.8,\n                \"_dir_desc\": \"西\"\n            },\n            \"street\": {\n                \"id\": \"9103225048745597629\",\n                \"title\": \"巢湖路\",\n                \"location\": {\n                    \"lat\": 31.842798,\n                    \"lng\": 117.32119\n                },\n                \"_distance\": 49.8,\n                \"_dir_desc\": \"西\"\n            },\n            \"landmark_l2\": {\n                \"id\": \"11384582867635718374\",\n                \"title\": \"锦绣园\",\n                \"location\": {\n                    \"lat\": 31.853819,\n                    \"lng\": 117.30229\n                },\n                \"_distance\": 0,\n                \"_dir_desc\": \"内\"\n            }\n        }\n    }\n}"

        //JavaScriptSerializer jss = new JavaScriptSerializer();

        //resultBig tt = jss.Deserialize<resultBig>(data);

        ////tt.addressesList;
        ////var obj = serializer.Deserialize<Dictionary<string, string>>(data);


        //var obj = JsonConvert.DeserializeObject(data);

        //foreach (var key in obj.Keys)
        //{
        //    MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
        //}

        //TextBox1.Text = tt.results..result.result.ToString();
    }


}