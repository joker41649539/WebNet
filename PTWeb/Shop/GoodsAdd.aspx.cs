using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    public int WebID = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(WebID, DefaultUser))
            {
                MessageBox("", "您无查看此页面的权限。", "/Shop/");
                return;
            }
        }
    }

    /// <summary>
    /// 数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_Save_Click(object sender, EventArgs e)
    {
        string srtSQL = string.Empty;
        string strTitle = TextBox_Name.Text.Replace("'", "");
        double strPrice = Convert.ToDouble(TextBox_Price.Text.Replace("'", ""));
        DateTime strStartTime = Convert.ToDateTime(TextBox_Time.Text);
        string strBigImg = string.Empty;
        string strRemark = TextBox_Remark.Text.Replace("'", ""); ;
        string strInfoImg = string.Empty;

        HttpPostedFile Bigf = Request.Files[0];
        strBigImg = UploadTPs(Bigf, 0, "GoodsBig");

        for (int i = 1; i < Request.Files.Count; i++)
        {
            strInfoImg += UploadTPs(Request.Files[i], i, "GoodsInfo") + ";";
        }

        if (strBigImg.Length > 0 & strInfoImg.Length > 0)
        {
            srtSQL = "Insert into Shop_Goods (Title,Price,StartTime,BigImg,Remark,InfoImg,Operator) values ('" + strTitle + "'," + strPrice + ",'" + strStartTime + "','" + strBigImg + "','" + strRemark + "','" + strInfoImg + "','" + DefaultUser + "')";
            if (OP_Mode.SQLRUN(srtSQL))
            {
                MessageBox("", "商品添加成功，稍后您需要生成HTML页面。", "/Shop/GoodsAdd.aspx");
                return;
            }
        }
        else
        {
            MessageBox("图片文件上传失败，请重试。");
            return;
        }
    }
}