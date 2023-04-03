using Newtonsoft.Json;
using System.Web;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Partner_PartnerInfo : PageBase
{
    public string strSQL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string s = GetSpell("黄飞鸿");
            //MessageBox("", "拼音：" + s);
            LoadUserInfo();
            LoadBMByWork();
        }
    }

    private void LoadUserInfo()
    {
        string[] strTemp;
        try
        {
            int iUserID = Convert.ToInt32(Request["ID"]);
            strSQL = "Select * from s_UserInfo where id=" + iUserID.ToString();
            /// 人员说明信息添加链接
            HyperLink_Remark.NavigateUrl = "/Partner/PartnerRemarkAdd.aspx?ID=" + iUserID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    Label_Ctime.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["CTime"]).ToString("yyyy-MM-dd");
                    Label_IDNo.Text = OP_Mode.Dtv[0]["ZJHM"].ToString() + "&nbsp;";
                    Label_Ltime.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["LTime"]).ToString("yyyy-MM-dd");
                    Label_LXDH.Text = OP_Mode.Dtv[0]["SSDZ"].ToString();
                    Label_Name.Text = OP_Mode.Dtv[0]["CName"].ToString();
                    Label_Name1.Text = OP_Mode.Dtv[0]["CName"].ToString();
                    DropDownList_Sex.SelectedValue = OP_Mode.Dtv[0]["XB"].ToString();
                    DropDownList_Sex.Enabled = false;

                    strTemp = OP_Mode.Dtv[0]["IDIMG"].ToString().Split(';');

                    if (strTemp.Length > 0)
                    {
                        for (int i = 0; i < strTemp.Length - 1; i++)
                        {
                            DivIDImage.InnerHtml += "<a href=\"/IDImage/" + strTemp[i] + "\"><img src=\"/IDImage/" + strTemp[i] + "\" width=\"150\" class=\"img-rounded\" /></a>";
                        }

                        DivIDImage.Visible = true;
                    }
                    else
                    {
                        DivIDImage.Visible = false;
                    }

                    LoadUserInfoByWork(GetSpell(OP_Mode.Dtv[0]["CNAME"].ToString()));
                    //加载备注说明信息
                    LoadRemarkData(iUserID);
                }
            }
        }
        catch
        {
            MessageBox("", "参数错误。", "/Default.aspx");
            return;
        }
    }

    /// <summary>
    /// 加载说明信息数据并绑定到网页
    /// </summary>
    private void LoadRemarkData(int UserID)
    {
        string strTemp = string.Empty;
        strSQL = "SELECT CNAME,W_USER_REMARK.REMARK,W_USER_REMARK.CTIME,HeadUrl FROM W_USER_REMARK,S_USERINFO WHERE USERID=S_USERINFO.ID AND REMARKUSERID=" + UserID + " order by W_USER_REMARK.CTIME desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    //if (i == 0)
                    //{
                    //    strTemp += " <div class='timeline'>";
                    //    strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                    //    strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                    //    strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                    //    strTemp += "  </span>";
                    //    strTemp += " </div>";
                    //}
                    //else
                    //{
                    //    if (Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") != Convert.ToDateTime(OP_Mode.Dtv[i - 1]["CTime"]).ToString("yyyy-MM-dd") || OP_Mode.Dtv[i]["CName"].ToString() != OP_Mode.Dtv[i - 1]["CName"].ToString())
                    //    {
                    //        strTemp += " <div class='timeline'>";
                    //        strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                    //        strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                    //        strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                    //        strTemp += "  </span>";
                    //        strTemp += " </div>";
                    //    }
                    //}

                    strTemp += "<div>";
                    strTemp += "  <div class='timeline-info'>";
                    if (OP_Mode.Dtv[i]["HeadUrl"].ToString().Length > 0)
                    {
                        strTemp += "<img whidth='100%' src='" + OP_Mode.Dtv[i]["HeadUrl"].ToString() + "' />";
                    }

                    //  strTemp += "      <span class='label label-info label-sm'> " + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("HH:mm") + "</span>";
                    strTemp += "  </div>";

                    strTemp += " <h5 class='smaller'>";

                    strTemp += " <span class='label label-primary arrowed-in-right label-lg'>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</span><br/>";
                    strTemp += " <span class='label label-info label-sm'>" + OP_Mode.Dtv[i]["CName"].ToString() + " </span>";


                    strTemp += " </h5>";
                    strTemp += "          <span class='widget-toolbar'>";
                    strTemp += "              <a href='#' data-action='collapse'>";
                    strTemp += "                 <i class='icon-chevron-up'></i>";
                    strTemp += "             </a>";
                    strTemp += "         </span>";
                    strTemp += "     </div>";

                    strTemp += "     <div class='widget-body'>";
                    strTemp += "         <div class='widget-main'>";
                    //   var reg = new RegExp("\r\n", “g”);//g,表示全部替换

                    strTemp += OP_Mode.Dtv[i]["Remark"].ToString().Replace(" ", "&nbsp").Replace("\r\n", "<br>");
                    strTemp += "       </div>";
                    strTemp += "     </div>";
                }
                if (strTemp.Length > 0)
                {
                    ContentPlaceHolder1_QDList.InnerHtml = strTemp;
                }
                else
                {
                    MessageBox("", "错误：" + OP_Mode.strErrMsg);
                }
            }
        }
    }

    private void LoadUserInfoByWork(string UserID)
    {
        string accessToken = GetWorkToken();
        var serializer = new JavaScriptSerializer();
        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;//定义对象语言
        var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", accessToken, UserID);

        var getJson = client.DownloadString(url);
        //{ "errcode":0,"errmsg":"ok","userid":"ceshizhanghao","name":"测试账号","department":[19],"position":"","mobile":"12312223333","gender":"0","email":"","avatar":"","status":4,"isleader":0,"extattr":{ "attrs":[]},"telephone":"","enable":1,"hide_mobile":0,"order":[0],"main_department":19,"qr_code":"https://open.work.weixin.qq.com/wwopen/userQRCode?vcode=vc5e6d55d02cefaebd","alias":"","is_leader_in_dept":[0],"thumb_avatar":"","direct_leader":[],"biz_mail":"ceshizhanghao@hfptkjyxgs.wecom.work"}

        RootobjectUser rt = JsonConvert.DeserializeObject<RootobjectUser>(getJson);

        if (rt.errmsg == "ok")
        {
            if (rt.department.Length > 0)
            {
                //LinkButton1.Visible = false;
                HiddenField_department.Value = rt.department[0].ToString();
            }
        }
    }

    public class RootobjectUser
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string userid { get; set; }
        //   public string name { get; set; }
        public int[] department { get; set; }
        public string position { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public int status { get; set; }
        public int isleader { get; set; }
        public Extattr extattr { get; set; }
        public string telephone { get; set; }
        public int enable { get; set; }
        public int hide_mobile { get; set; }
        public int[] order { get; set; }
        public int main_department { get; set; }
        public string qr_code { get; set; }
        public string alias { get; set; }
        public int[] is_leader_in_dept { get; set; }
        public string thumb_avatar { get; set; }
        public object[] direct_leader { get; set; }
        public string biz_mail { get; set; }
    }

    public class Extattr
    {
        public object[] attrs { get; set; }
    }

    private void LoadBMByWork()
    {
        string accessToken = GetWorkToken();
        var serializer = new JavaScriptSerializer();
        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        string strTemp = string.Empty;

        int iXTRYBMID = 18;// 协同人员部门ID，固定
        var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}", accessToken, iXTRYBMID);
        var getJson = client.DownloadString(url);

        Rootobject rt = JsonConvert.DeserializeObject<Rootobject>(getJson);

        string strRadioHtml = "";

        string iDepartment = HiddenField_department.Value;

        for (int i = 1; i < rt.department.Count; i++)
        {
            strRadioHtml += "<div class=\"radio\">";
            strRadioHtml += "  <label>";
            strRadioHtml += "   <input name=\"radioBM\" value=\"" + rt.department[i].id + "\" type=\"radio\" class=\"ace\" ";
            if (iDepartment.Length > 0)
            {
                if (rt.department[i].id.ToString() == iDepartment)
                {
                    strRadioHtml += " checked=\"checked\" ";
                }
            }
            strRadioHtml += "/>";
            strRadioHtml += "<span class=\"lbl\" >&nbsp;" + rt.department[i].name + "</span>";
            strRadioHtml += "  </label>";
            strRadioHtml += "</div>";
        }
        if (strRadioHtml.Length > 0)
        {
            RadioBM.InnerHtml = strRadioHtml;
        }
        // {"errcode":0,"errmsg":"ok","department":[{"id":18,"name":"协同人员","parentid":1,"order":99992000,"department_leader":[]},{"id":19,"name":"合肥协同","parentid":18,"order":100000000,"department_leader":[]},{"id":20,"name":"六安协同","parentid":18,"order":99999000,"department_leader":[]}]}
    }

    public class Rootobject
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public List<Department> department { get; set; }
    }

    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentid { get; set; }
        public int order { get; set; }
        public object[] department_leader { get; set; }
    }

    //// https://developer.work.weixin.qq.com/devtool/interface/alone?id=10093  获取企业微信部门信息，ID为18为协同人员

    /// <summary>
    /// 审核通过
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SaveData();
        // MessageBox("", "部门：" + Request["radioBM"]);
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    private void SaveData()
    {
        // 1、插入数据到协同办公平台
        if (InsertWorker())
        {
            // 2、保存数据到数据库
            SaveSQLData();
        }
    }

    private void SaveSQLData()
    {
        int iUserID = Convert.ToInt32(Request["ID"]);

        strSQL = " Update s_userinfo set Flag=3 where id=" + iUserID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "人员信息审核成功。", "/Partner/");
        }
    }

    /// <summary>
    /// 插入数据到协同办公平台
    /// </summary>
    private bool InsertWorker()
    {
        bool rValue = false;
        int idepartment = Convert.ToInt32(Request["radioBM"]);

        var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token={0}", GetWorkTokenByAddress());

        var data = "{";

        data += "\"userid\":\"" + GetSpell(Label_Name.Text) + "\",";
        data += "\"name\":\"" + Label_Name.Text + "\",";
        data += "\"mobile\":\"" + Label_LXDH.Text + "\",";
        data += "\"department\":\"" + idepartment + "\"";

        data += "}";

        var serializer = new JavaScriptSerializer();
        var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));

        string MSG = string.Empty;

        foreach (var key in obj.Keys)
        {
            if (key == "errmsg")
            {
                if (obj[key] == "created")
                {
                    // MSG = "创建成功。";
                    rValue = true;
                }
                else
                {
                    MSG = "创建失败。错误：" + obj[key];
                }
            }
        }
        if (MSG != string.Empty)
        {
            MessageBox("", MSG);
        }
        return rValue;
    }

    /// <summary>
    /// 汉字转拼音
    /// </summary>
    /// <param name="x">汉字</param>
    /// <returns>全拼拼音</returns>
    public string GetSpell(string x)
    {
        int[] iA = new int[] { -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032, -20026, -20002, -19990, -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, -19741, -19739, -19728, -19725, -19715, -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, -19263, -19261, -19249, -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977, -18961, -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501, -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211, -18201, -18184, -18183, -18181, -18012, -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, -17733, -17730, -17721, -17703, -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, -17185, -16983, -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448, -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220, -16216, -16212, -16205, -16202, -16187, -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, -15903, -15889, -15878, -15707, -15701, -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419, -15416, -15408, -15394, -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, -15141, -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922, -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678, -14674, -14670, -14668, -14663, -14654, -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345, -14170, -14159, -14151, -14149, -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, -14087, -14083, -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601, -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356, -13343, -13340, -13329, -13326, -13318, -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, -12888, -12875, -12871, -12860, -12858, -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359, -12346, -12320, -12300, -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, -11536, -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019, -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544, -10533, -10519, -10331, -10329, -10328, -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254 };

        string[] sA = new string[] { "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian", "biao", "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan", "chang", "chao", "che", "chen", "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong", "cou", "cu", "cuan", "cui", "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao", "die", "ding", "diu", "dong", "dou", "du", "duan", "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang", "fei", "fen", "feng", "fo", "fou", "fu", "ga", "gai", "gan", "gang", "gao", "ge", "gei", "gen", "geng", "gong", "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo", "ha", "hai", "han", "hang", "hao", "he", "hei", "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun", "huo", "ji", "jia", "jian", "jiang", "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan", "kang", "kao", "ke", "ken", "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan", "lang", "lao", "le", "lei", "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu", "lv", "luan", "lue", "lun", "luo", "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", "miao", "mie", "min", "ming", "miu", "mo", "mou", "mu", "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", "neng", "ni", "nian", "niang", "niao", "nie", "nin", "ning", "niu", "nong", "nu", "nv", "nuan", "nue", "nuo", "o", "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng", "pi", "pian", "piao", "pie", "pin", "ping", "po", "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu", "qu", "quan", "que", "qun", "ran", "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa", "sai", "san", "sang", "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi", "shou", "shu", "shua", "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun", "suo", "ta", "tai", "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan", "tui", "tun", "tuo", "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao", "xie", "xin", "xing", "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin", "ying", "yo", "yong", "you", "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", "zeng", "zha", "zhai", "zhan", "zhang", "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", "zhuang", "zhui", "zhun", "zhuo", "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo" };

        byte[] B = new byte[2];
        string s = "";
        char[] c = x.ToCharArray();

        for (int j = 0; j < c.Length; j++)
        {
            B = System.Text.Encoding.Default.GetBytes(c[j].ToString());
            if ((int)(B[0]) <= 160 && (int)(B[0]) >= 0)
            {
                s += c[j];
            }
            else
            {
                for (int i = (iA.Length - 1); i >= 0; i--)
                {
                    if (iA[i] <= (int)(B[0]) * 256 + (int)(B[1]) - 65536)
                    {
                        s += sA[i];
                        break;
                    }
                }
            }
        }
        return s;
    }

    /// <summary>
    /// 启用 4;/// 人员启用状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int iUserID = Convert.ToInt32(Request["ID"]);
        int iFlag = 4;/// 人员启用状态

        strSQL = " Update s_userinfo set Flag="+ iFlag + ",LTime=getdate() where id=" + iUserID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "人员启用成功。", "/Partner/");
        }
    }

    /// <summary>
    /// 停用 3;/// 人员 状态 停用 已审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int iUserID = Convert.ToInt32(Request["ID"]);
        int iFlag = 3;/// 人员 状态 停用 已审核
        strSQL = " Update s_userinfo set Flag="+ iFlag + ",LTime=getdate() where id=" + iUserID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "人员已经停用，系统中暂不可用。", "/Partner/");
        }
    }
}