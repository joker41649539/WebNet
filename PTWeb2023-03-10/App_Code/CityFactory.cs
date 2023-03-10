using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// CityFactory 的摘要说明
/// </summary>
public class CityFactory
{
    private static CityFactory single = null;

    private CityFactory()
    { }

    public static CityFactory getInstance()
    {
        if (null == single)
        {
            single = new CityFactory();
        }
        return single;
    }

    /// <summary>
    /// 获取局内单位代码库数据
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public List<City> GetJNDWK(int? parentId)
    {
        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@parent", parentId == 0 ? 2 : parentId) };

        string commandText = "select * from W_JNDWTZ where ISJDWID = @parent ";

        DataSet ds = DBHelper.ExecuteDataset(CommandType.Text, commandText, commandParameters);
        if ((ds.Tables.Count > 0) || (ds.Tables[0].Rows.Count > 0))
        {
            List<City> result = new List<City>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                City aCity = new City();
                aCity.id = dr["id"] == DBNull.Value ? 0 : (int)dr["id"];
                aCity.name = dr["DWJC"].ToString();
                aCity.parent = dr["ISJDWID"] == DBNull.Value ? 0 : (int)dr["ISJDWID"];
                result.Add(aCity);
            }
            return result;
        }

        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool IsJNDWKChild(int id)
    {
        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@parent", id) };
        string commandText = "select count(*) cnt from W_JNDWTZ where ISJDWID = @parent ";
        return (int)DBHelper.ExecuteScalar(CommandType.Text, commandText, commandParameters) > 0;
    }


    public List<City> GetList(int? parentId, int? userID)
    {
        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@parent", parentId == null ? 0 : parentId), new SqlParameter("@userID", userID == null ? 0 : userID) };
        string commandText = string.Empty;
        if (parentId == 0)
        {
            commandText = "select * from V_WZTZ where IFLAG=1 AND ISJJD = @parent AND USERID = @userID ";
        }
        else
        {
            commandText = "select * from V_WZTZ where IFLAG=1 AND ISJJD = @parent AND USERID = @userID order by wzmc,xhgg";
        }
        DataSet ds = DBHelper.ExecuteDataset(CommandType.Text, commandText, commandParameters);
        if ((ds.Tables.Count > 0) || (ds.Tables[0].Rows.Count > 0))
        {
            List<City> result = new List<City>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                City aCity = new City();
                aCity.id = dr["id"] == DBNull.Value ? 0 : (int)dr["id"];
                if (dr["WZBH"].ToString().Length == 12)
                {
                    aCity.name = dr["WZBH"].ToString() + ") " + dr["WZMC"].ToString() + "【" + dr["JLDW"].ToString() + "】【" + dr["XHGG"].ToString() + "】" + dr["TH"].ToString() + " " + dr["CZ"].ToString() + " " + dr["JSZB"].ToString();
                }
                else
                {
                    aCity.name = dr["WZBH"].ToString() + ") " + dr["WZMC"].ToString();
                }
                aCity.parent = dr["ISJJD"] == DBNull.Value ? 0 : (int)dr["ISJJD"];
                result.Add(aCity);
            }
            return result;
        }

        return null;
    }

    public bool IsExistChild(int id, int userID)
    {
        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@parent", id), new SqlParameter("@userID", userID) };
        string commandText = "select count(*) cnt from V_WZTZ where IFLAG=1 AND ISJJD = @parent AND USERID = @userID ";
        return (int)DBHelper.ExecuteScalar(CommandType.Text, commandText, commandParameters) > 0;
    }
}