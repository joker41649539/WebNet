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
        string[] SysPhoneNo = { "13966668241", "18755165777", "18019961118" };// 随机用户ID
        Random ran = new Random();
        int n = ran.Next(SysPhoneNo.Length);
        // SysPhoneNo[n]
        //Select @GoodsCount GoodsCount,isnull(@ByCount, 0) ByCount
        string rValue = "{\"Msg\":\"未知错误。\",\"errMsg\":\"error\"}";
        //1、判断商品是否存在。是否被销售过。
        //都不存在的话，添加记录
        string strSQL = "declare @GoodsCount int";
        strSQL += " declare @ByCount int";
        strSQL += " declare @Gas int";
        strSQL += " declare @Holder varchar(50)";
        strSQL += " declare @GoodID varchar(50)";
        strSQL += " declare @PhoneNo varchar(50)";
        strSQL += " set @PhoneNo = '" + PhoneNo + "'";
        strSQL += " set @GoodID = '" + GoodsID + "'";
        strSQL += " Select @GoodsCount = count(ID) From Shop_GoodsPrice where HtmlID = @GoodID";
        strSQL += " if @GoodsCount > 0";
        strSQL += " begin";
        strSQL += "   Select @ByCount = Count(id) from Shop_UserGoods where GoodsPriceID = @GoodID ";
        strSQL += "   if @ByCount = 0";
        strSQL += "   begin";
        strSQL += "    Select @Gas=(Select sum(Bance) from Shop_Gold where UserNo=@PhoneNo)-CEILING((Price* CONVERT(decimal(18,4),(Select SetValue from Shop_SysSet where id=1)))) from Shop_GoodsPrice where HtmlID=@GoodID";
        strSQL += "     if @Gas > 0";
        strSQL += "      begin";
        strSQL += "        Select @Holder=isnull((Select UserID from Shop_UserGoods where GoodsPriceID=(Select top 1 HtmlID from Shop_GoodsPrice where GoodsID=a.GoodsID and HtmlID!=a.HtmlID order by Ctime desc) and Flag=1),0) from Shop_GoodsPrice a where HtmlID=@GoodID";
        //strSQL += "          if @Holder = '0'";
        //strSQL += "            begin";
        //strSQL += "              set @Holder='" + SysPhoneNo[n] + "'";
        //strSQL += "            end";
        strSQL += "         update Shop_UserInfo set GoldCount=GoldCount-(Select CEILING((Price* CONVERT(decimal(18,4),(Select SetValue from Shop_SysSet where id=1)))) Gas from Shop_GoodsPrice where HtmlID=@GoodID) where PhoneNo=@PhoneNo ";// 更新用户数据
        strSQL += "         Insert into Shop_Gold (UserNo,Bance,Operator,Event) Select @PhoneNo,-1*(Select CEILING((Price* CONVERT(decimal(18,4),(Select SetValue from Shop_SysSet where id=1)))) Gas from Shop_GoodsPrice where HtmlID=@GoodID),'System',@GoodID ";//插入金豆数据
        strSQL += "         insert into Shop_UserGoods(GoodsPriceID, UserID, HolderID) select @GoodID,(Select PhoneNo From Shop_UserInfo where PhoneNo = @PhoneNo and Flag=0),@Holder";
        strSQL += "     end";
        strSQL += "   end";
        strSQL += " end";
        strSQL += " Select @GoodsCount GoodsCount,isnull(@ByCount, 0) ByCount,SCOPE_IDENTITY() ID,isnull(@Gas, 0) Gas";

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
                        rValue = "{\"Msg\":\"商品已被售出,下次请赶早。\",\"errMsg\":\"error\"}";
                    }
                    else
                    {
                        if ((Convert.ToInt32(OP_Mode.Dtv[0]["ID"]) > 0))
                        {
                            if (Convert.ToInt32(OP_Mode.Dtv[0]["ID"]) > 0)
                            { // 商品购买成功。
                                rValue = "{\"Msg\":\"商品已抢购成功。\",\"errMsg\":\"ok\"}";
                            }
                            else
                            {//
                                rValue = "{\"Msg\":\"商品抢购失败。\",\"errMsg\":\"error\"}";
                            }
                        }
                        else
                        {
                            rValue = "{\"Msg\":\"您的金豆不足，商品抢购失败。\",\"errMsg\":\"error\"}";
                        }
                    }
                }
            }
            else
            {
                rValue = "{\"Msg\":\"未查询到数据。\",\"errMsg\":\"error\"}";
            }
        }
        else
        {
            rValue = "{\"Msg\":\"数据错误：\"" + OP_Mode.strErrMsg + ",\"errMsg\":\"error\"}";
        }

        return rValue;
    }
}