using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_ReturnMSG : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 确定退回按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (TextBox_ReturnMSG.Text.Length > 0)
        {
            SaveFlag();
        }
        else
        {
            MessageBox("", "请输入退回原因。");
        }
    }

    /// <summary>
    /// 提交状态
    /// </summary>
    private void SaveFlag()
    {
        int ID = Convert.ToInt32(Request["ID"]);
        if (ID > 0)
        {/// 单据编号不对，不允许提交
            // 保存记录表  W_Examine
            int NewFlag = 0;// 提交后他状态

            string strSQL = " Insert into W_Examine(Class,DJBH,UserName,OldFlag,NewFlag,Remark,iReturn) values ('BXD',(Select BXDH From w_bxd1 where ID=" + ID + "),'" + UserNAME + "',(Select flag From w_bxd1 where ID=" + ID + ")," + NewFlag + ",'" + TextBox_ReturnMSG.Text.Replace("'", "") + "',1)";

            strSQL += " Update W_BXD1 Set Flag=" + NewFlag + ",LTime=getdate() where ID=" + ID;

            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "单据退回成功。", "/CWGL/");
            }
            else
            {
                MessageBox("", "单据退回失败。<br>错误：" + OP_Mode.strErrMsg);
                return;
            }
        }
        else
        {
            MessageBox("", "单据提交失败。<br>错误：参数错误。");
            return;
        }
    }

    /// <summary>
    /// 报销流程走向
    /// </summary>
    /// <returns></returns>
    private int NextFlag(int NowFlag)
    {
        int rValue = 0;

        if (NowFlag == 0)
        {
            //if (HiddenField1.Value == "1")
            //{// 到综合部
            //    rValue = 2;
            //}
            //else if (HiddenField1.Value == "2")
            //{// 到物资岗
            //    rValue = 3;
            //}
            //else if (HiddenField1.Value == "3")
            //{// 到工程岗
            //    rValue = 4;
            //}
        }
        else if (NowFlag == 2)
        {/// 综合部 到 代放款
            rValue = 5;
        }
        else if (NowFlag == 3)
        {/// 物资岗 到 综合部
            rValue = 2;
        }
        else if (NowFlag == 4)
        {/// 工程岗 到 综合部
            rValue = 2;
        }
        else if (NowFlag == 5)
        {/// 待放款 到 待收票
            rValue = 6;
        }
        else if (NowFlag == 6)
        {/// 待收票 到 已完结
            rValue = 1;
        }
        else if (NowFlag == 1)
        {/// 已完结 到 已完结
            rValue = 1;
        }

        return rValue;
    }
}