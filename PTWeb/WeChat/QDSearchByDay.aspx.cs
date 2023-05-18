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
        GridView_KQByDay.Columns.Clear();
        GridView_KQByDay.DataSource = null;
        GridView_KQByDay.DataBind();
        string strSQL = string.Empty;
        DateTime strSTime = Convert.ToDateTime(TextBox_STime.Text);
        DateTime strETime = Convert.ToDateTime(TextBox_ETime.Text);

        CreateGridColumn("CName", "姓名", 150, GridView_KQByDay, 0);
        int Days = Convert.ToInt32(DiffDays(strSTime, strETime));
       // GridView_KQByDay.Width = 150;

        strSQL = "Select ID,CNAME";
        for (int i = 0; i < Days; i++)
        {
            CreateGridColumn(strSTime.AddDays(i).ToString("MM-dd"), strSTime.AddDays(i).ToString("MM-dd") + DateToWeekCn(strSTime.AddDays(i)), 120, GridView_KQByDay, i);

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
        //int length = 150;  //定义一个长度
        //int size = groupBuyList.size();  //得到集合长度
        //                                 //获得屏幕分辨路
        //DisplayMetrics dm = new DisplayMetrics();
        //getActivity().getWindowManager().getDefaultDisplay().getMetrics(dm);
        //float density = dm.density;
        ////                    Log.d(TAG, "handleMessage: "+density);
        //int gridviewWidth = (int)(size * (length + 10) * density);
        //int itemWidth = (int)(length * density);

        //LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
        //        gridviewWidth, LinearLayout.LayoutParams.MATCH_PARENT);
        //GridView_KQByDay.setLayoutParams (params); // 设置GirdView布局参数,横向布局的关键
        //GridView_KQByDay.setColumnWidth(itemWidth); // 设置列表项宽
        //GridView_KQByDay.setHorizontalSpacing(15); // 设置列表项水平间距
        //GridView_KQByDay.setStretchMode(GridView.NO_STRETCH);
        //GridView_KQByDay.setNumColumns(size); // 设置列数量=列表集合数
    }

    //创建GridView列的方法
    private void CreateGridColumn(string dataField, string headerText, int width, GridView gv, int i)
    {
        if (dataField == "CName")
        {
            BoundField bc = new BoundField();
            bc.DataField = dataField;
            bc.HeaderText = headerText;
            gv.Columns.Add(bc);  //把动态创建的列，添加到GridView中  
            bc.HeaderStyle.CssClass = "width:" + width + "px";   //若有默认样式，此行代码及对应的参数可以移除
                                                                 // if (!string.IsNullOrEmpty(itemStyle))
            bc.ItemStyle.CssClass = "width:" + width + "px";   //若有默认样式，此行代码及对应的参数可以移除
        }
        else
        {
            HyperLinkField bc = new HyperLinkField();
            string[] DataName = { "CName", headerText.Substring(0, 5) };
            bc.DataTextField = dataField;
            bc.HeaderText = headerText;
            bc.DataNavigateUrlFields = DataName;
            bc.DataNavigateUrlFormatString = "/CWGL/SearchQD.aspx?UserName={0}&Day=" + Convert.ToDateTime(TextBox_STime.Text).AddDays(i).ToString("yyyy-MM-dd");
            gv.Columns.Add(bc);  //把动态创建的列，添加到GridView中  
            bc.HeaderStyle.CssClass = "width:" + width + "px";   //若有默认样式，此行代码及对应的参数可以移除
                                                                 // if (!string.IsNullOrEmpty(itemStyle))
            bc.ItemStyle.CssClass = "width:" + width + "px";   //若有默认样式，此行代码及对应的参数可以移除
        }
        if (width > 0)
            gv.Width = new Unit(gv.Width.Value + width);

        //每添加一列后，要增加GridView的总体宽度  
        //if (!string.IsNullOrEmpty(headerStyle))
        //bc.HeaderStyle.CssClass = headerStyle;  //若有默认样式，此行代码及对应的参数可以移除
        //                                        // if (!string.IsNullOrEmpty(itemStyle))
        //bc.ItemStyle.CssClass = itemStyle;   //若有默认样式，此行代码及对应的参数可以移除

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}