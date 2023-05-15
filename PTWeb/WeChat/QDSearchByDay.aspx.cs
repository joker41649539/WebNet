using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeChat_QDSearchByDay : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void LoadData()
    {
        string strSQL = string.Empty;
        DateTime strSTime = Convert.ToDateTime(TextBox_STime.Text);
        DateTime strETime = Convert.ToDateTime(TextBox_ETime.Text);

        int Days = Convert.ToInt32(DiffDays(strSTime, strETime));

        strSQL = "Select ID,CNAME";
        CreateGridColumn("CName", "姓名", 100, GridView_KQByDay);
        GridView_KQByDay.Width = (Days + 1) * 120;
        for (int i = 0; i < Days; i++)
        {
            CreateGridColumn(strSTime.AddDays(i).ToString("MM-dd"), strSTime.AddDays(i).ToString("MM-dd") + DateToWeekCn(strSTime.AddDays(i)), 120, GridView_KQByDay);

            strSQL += ",(Select count(ID) from W_KQ where UserID=V_GCUser.ID and CONVERT(VARCHAR(10),CTime,120)='" + strSTime.AddDays(i).ToString("yyyy-MM-dd") + "') '" + strSTime.AddDays(i).ToString("MM-dd") + "'";
        }
        strSQL += " from V_GCUser order by ID";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_KQByDay.DataSource = OP_Mode.Dtv;
                GridView_KQByDay.DataBind();
            }
        }

    }

    //创建GridView列的方法
    private void CreateGridColumn(string dataField, string headerText, int width, GridView gv)
    {
        BoundField bc = new BoundField();
        bc.DataField = dataField;
        bc.HeaderText = headerText;
        //if (!string.IsNullOrEmpty(headerStyle))
        //    bc.HeaderStyle.CssClass = headerStyle;  //若有默认样式，此行代码及对应的参数可以移除
        //if (!string.IsNullOrEmpty(itemStyle))
        //    bc.ItemStyle.CssClass = itemStyle;   //若有默认样式，此行代码及对应的参数可以移除
        gv.Columns.Add(bc);  //把动态创建的列，添加到GridView中  
        if (width > 0)
            gv.Width = new Unit(gv.Width.Value + width); //每添加一列后，要增加GridView的总体宽度  

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}