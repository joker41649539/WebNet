using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_ApiGoodsPrice : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string callback = Request.QueryString["jsoncallback"];
        string data = ReturnJson(Request["PhoneNo"], Request["GoodsID"]);//"{\"title\": \"Recent Uploads tagged cat\",\"link\": \"http://www.sina.com.cn\",\"items\": [{\"title\": \"Russell 003\",\"color\": \"red\"},{\"title\": \"Cat [07.04.11]\",\"color\": \"yellow\"}]}";
        string result = string.Format("{0}({1})", callback, data);
        Response.Expires = -1;
        Response.Clear();
        Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "application/json";
        Response.Write(result);
        Response.Flush();
        Response.End();
    }

    private string ReturnJson(string PhoneNo, string GoodsID)
    {

        //declare @GoodsCount int
        //declare @ByCount int
        //declare @GoodID varchar(50)
        //declare @PhoneNo varchar(50)
        //set @PhoneNo = '18019961118'
        //set @GoodID = '202305221537304.html'
        //Select @GoodsCount = count(ID) From Shop_GoodsPrice where HtmlID = @GoodID
        //if @GoodsCount > 0
        //begin
        //  Select @ByCount = Count(id) from Shop_UserGoods where GoodsPriceID = (Select ID from Shop_GoodsPrice where HtmlID = @GoodID) 
        //  if @ByCount = 0
        //    begin
        //     insert into Shop_UserGoods(GoodsPriceID, UserID) select(Select ID from Shop_GoodsPrice where HtmlID = @GoodID) ,(Select ID From Shop_UserInfo where PhoneNo = @PhoneNo)
        //	end
        //end

        //Select @GoodsCount GoodsCount,isnull(@ByCount, 0) ByCount
        string rValue = "{\"Msg\":\"未知错误。\",\"errMsg\":\"error\"}";
        //1、判断商品是否存在。是否被销售过。
        //都不存在的话，添加记录
        string strSQL = " declare @GoodsCount int";
        strSQL += " declare @ByCount int";
        strSQL += " declare @GoodID varchar(50)";
        strSQL += " declare @PhoneNo varchar(50)";
        strSQL += " set @PhoneNo = '" + PhoneNo + "'";
        strSQL += " set @GoodID = '" + GoodsID + "'";
        strSQL += " Select @GoodsCount = count(ID) From Shop_GoodsPrice where HtmlID = @GoodID";
        strSQL += " if @GoodsCount > 0";
        strSQL += " begin";
        strSQL += "   Select @ByCount = Count(id) from Shop_UserGoods where GoodsPriceID = (Select ID from Shop_GoodsPrice where HtmlID = @GoodID) ";
        strSQL += "   if @ByCount = 0";
        strSQL += "   begin";
        strSQL += "     insert into Shop_UserGoods(GoodsPriceID, UserID) select(Select ID from Shop_GoodsPrice where HtmlID = @GoodID) ,(Select ID From Shop_UserInfo where PhoneNo = @PhoneNo and Flag=0)";
        strSQL += "   end";
        strSQL += " end";
        strSQL += " Select @GoodsCount GoodsCount,isnull(@ByCount, 0) ByCount,SCOPE_IDENTITY() ID";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (Convert.ToInt32(OP_Mode.Dtv[0]["GoodsCount"]) == 0)
                { // 没有商品信息
                    rValue = "{\"Msg\":\"商品信息错误，或者您非正常用户。\",\"errMsg\":\"error\"}";
                }
                else
                {
                    if (Convert.ToInt32(OP_Mode.Dtv[0]["ByCount"]) > 0)
                    { // 商品已经被购买过。
                        rValue = "{\"Msg\":\"商品已被购买过,不允许再次购买。\",\"errMsg\":\"error\"}";
                    }
                    else
                    {
                        if (Convert.ToInt32(OP_Mode.Dtv[0]["ID"]) > 0)
                        { // 商品购买成功。
                            rValue = "{\"Msg\":\"商品已抢购成功。\",\"errMsg\":\"ok\"}";
                        }
                        else
                        {//
                            rValue = "{\"Msg\":\"商品购买失败。您不是正常用户。\",\"errMsg\":\"error\"}";
                        }
                    }
                }
            }
        }

        return rValue;
    }
}