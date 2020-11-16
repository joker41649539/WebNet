using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 根据CheckBoxList中选中的项，获得字符串
    /// </summary>
    /// <param name="checkBoxList">CheckBoxList控件</param>
    /// <returns>字符串，格式为“A,B,C”</returns>
    public string GetCheckBoxList(CheckBoxList checkBoxList)
    {
        string str = "";
        foreach (ListItem li in checkBoxList.Items)
        {
            if (li.Selected) str += li.Value + ";";
        }
        return str.TrimEnd(';');
    }
    /// <summary>
    /// 生成代码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strZDZW, strZDYW, strGrid, strZWZS, strSQL;
        /// gridview名称，命名前缀后缀
        strGrid = this.TextBox1.Text.Trim();
        /// 中文注释
        strZWZS = this.TextBox2.Text.Trim();
        /// 操作数据库表名
        strSQL = this.TextBox3.Text.Trim();
        /// 英文数组
        strZDYW = this.TextBox4.Text;
        /// 中文数组
        strZDZW = this.TextBox5.Text;

        string[] arrayYW = this.TextBox4.Text.Split(';');
        string[] arrayZW = this.TextBox5.Text.Split(';');

        //string[] arrayShow = GetCheckBoxList(this.CheckBoxList1).Split(';');

        bool BNoSx, BAdd, BEdit, Bdel, BCx;

        BNoSx = false;
        BAdd = false;
        BEdit = false;
        Bdel = false;
        BCx = false;

        if (this.CheckBox1.Checked)
        {
            BNoSx = true;
        }
        else
        {
            BNoSx = false;
        }

        if (this.CheckBox2.Checked)
        {
            BAdd = true;
        }
        else
        {
            BAdd = false;
        }
        if (this.CheckBox3.Checked)
        {
            BEdit = true;
        }
        else
        {
            BEdit = false;
        }
        if (this.CheckBox4.Checked)
        {
            Bdel = true;
        }
        else
        {
            Bdel = false;
        }
        if (this.CheckBox5.Checked)
        {
            BCx = true;
        }
        else
        {
            BCx = false;
        }

        if (arrayYW.Length != arrayZW.Length)
        {
            MessageBox("", "字段中文和字段英文数量不匹配，请仔细核对后填写。");
            return;
        }


        string strDiv = "<b>ASPX 页面代码：</b><br/>";

        if (BNoSx)
        {
            strDiv += "&nbsp;&lt;asp:ScriptManager ID=\"ScriptManager_" + strGrid + "\" runat=\"server\"&gt;&lt;/asp:ScriptManager&gt;";
        }
        if (BAdd)
        {
            strDiv += "&lt;div class=&quot;modal fade&quot; id=&quot;" + strGrid + "_ADD&quot; tabindex=&quot;-1&quot; role=&quot;dialog&quot;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; aria-labelledby=&quot;myModalLabel&quot; aria-hidden=&quot;true&quot;&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;modal-dialog&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;page-content&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;page-header&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;h1&gt;" + strZWZS;


            strDiv += "<span class=\"Apple-tab-span\" style=\"white-space:pre\">								</span>&lt;small&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;i class=&quot;icon-double-angle-right&quot;&gt;&lt;/i&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 添加新的" + strZWZS;


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/small&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/h1&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "<br/>";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;row&quot;&gt;";
            //////////////////////////////////////////////////////////////////////  文本框循环
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];

                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;col-xs-12&quot;&gt;  ";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;form-group&quot;&gt; ";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;label class=&quot;col-sm-3 control-label no-padding-right&quot; for=&quot;form-field-1&quot;&gt;" + arrZW + "&lt;/label&gt;";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;col-sm-9&quot;&gt;";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:TextBox ID=&quot;" + strGrid + "_TextBox_" + arrYW + "&quot; runat=&quot;server&quot; placeholder=&quot;请输入" + arrZW + "&quot; class=&quot;col-xs-12 col-sm-12&quot;&gt;&lt;/asp:TextBox&gt;";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";

            }
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";
            /////////////////////////////////////////////////////////////////////

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;clearfix form-actions&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;col-md-offset-3 col-md-9&quot;&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton  UseSubmitBehavior=\"false\" OnClientClick=\"this.setAttribute('disabled', 'disabled')\" ID=&quot;" + strGrid + "_LinkButton1&quot; class=&quot;btn btn-info&quot; OnClick=&quot;" + strGrid + "_LinkButton1_Click&quot; runat=&quot;server&quot;&gt;&lt;i class=&quot;icon-ok bigger-110&quot;&gt;&lt;/i&gt; 保 &nbsp;存&lt;/asp:LinkButton&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &amp;nbsp; &amp;nbsp;&nbsp;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;button type=&quot;button&quot; class=&quot;btn btn-default&quot; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; data-dismiss=&quot;modal&quot;&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;i class=&quot;icon-remove-sign bigger-110&quot;&gt;&lt;/i&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 关 &nbsp;闭  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/button&gt;";


            strDiv += "<br/>";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;!-- /.modal-content --&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &lt;!-- /.modal-dialog --&gt;";


            strDiv += "&nbsp; &nbsp; &lt;/div&gt; ";
        }///   模态框添加结束

        strDiv += "&nbsp; &nbsp; &lt;div class=&quot;vspace-sm&quot;&gt;&lt;/div&gt;";


        strDiv += "&nbsp; &nbsp; &lt;div class=&quot;col-sm-12&quot;&gt;";

        //////////////////////

        if (BNoSx)
        {

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:UpdatePanel ID=&quot;" + strGrid + "_UpdatePanel1&quot; runat=&quot;server&quot; UpdateMode=&quot;Always&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ContentTemplate&gt;";

        }

        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;widget-box transparent&quot;&gt;";

        if (BCx)
        {

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;widget-header widget-header-flat&quot;&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;h4 class=&quot;lighter&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;i class=&quot;icon-user&quot;&gt;&lt;/i&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + strZWZS;


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/h4&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:DropDownList ID=&quot;" + strGrid + "_DropDownList1&quot; class=&quot;btn dropdown-toggle btn-sm &nbsp;btn-white&quot; runat=&quot;server&quot; ClientIDMode=&quot;Static&quot;&gt; ";

            //////////////////////////////////////////////  查询条件列表循环
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ListItem Value=&quot;" + arrYW + "&quot;&gt;" + arrZW + "&lt;/asp:ListItem&gt;";
            }
            //////////////////////////////////////////////////

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/asp:DropDownList&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:DropDownList ID=&quot;" + strGrid + "_DropDownList_SF&quot; class=&quot;btn dropdown-toggle btn-sm &nbsp;btn-white&quot; runat=&quot;server&quot; ClientIDMode=&quot;Static&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ListItem Value=&quot;=&quot;&gt;等于&lt;/asp:ListItem&gt;";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ListItem Value=&quot;LIKE&quot;&gt;包含&lt;/asp:ListItem&gt; ";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ListItem Value=&quot;&lt;&gt;&quot;&gt;不等于&lt;/asp:ListItem&gt;";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ListItem Value=&quot;&gt;&quot;&gt;大于&lt;/asp:ListItem&gt;";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ListItem Value=&quot;&lt;&quot;&gt;小于&lt;/asp:ListItem&gt;";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/asp:DropDownList&gt;  ";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:TextBox ID=&quot;" + strGrid + "_TextBox_CXTJ&quot; placeholder=&quot;条件内容&quot; runat=&quot;server&quot;&gt;&lt;/asp:TextBox&gt;";


            strDiv += "<br/>";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton runat=&quot;server&quot; class=&quot;btn btn-white btn-sm&quot; OnClick=&quot;" + strGrid + "_TJADD_Click&quot; ID=&quot;" + strGrid + "_TJADD&quot;&gt;&lt;i class=&quot;icon-plus-sign&quot;&gt;&amp;nbsp;条件添加&lt;/i&gt;&lt;/asp:LinkButton&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;widget-toolbar&quot;&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;a href=&quot;#&quot; data-action=&quot;collapse&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;i class=&quot;icon-chevron-up&quot;&gt;&lt;/i&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/a&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div id=&quot;" + strGrid + "_alerts_tj&quot; runat=&quot;server&quot; class=&quot;alert alert-success&quot; visible=&quot;false&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;button type=&quot;button&quot; class=&quot;close&quot; data-dismiss=&quot;alert&quot;&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;i class=&quot;icon-remove&quot;&gt;&lt;/i&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/button&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:Label ID=&quot;" + strGrid + "_Label1&quot; runat=&quot;server&quot; Text=&quot;&quot;&gt;&lt;/asp:Label&gt;&lt;asp:Label ID=&quot;" + strGrid + "_Label_tj&quot; runat=&quot;server&quot; Text=&quot;&quot; Visible=&quot;false&quot;&gt;&lt;/asp:Label&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton runat=&quot;server&quot; class=&quot;btn btn-white btn-sm&quot; ID=&quot;" + strGrid + "_LinkButton3&quot; OnClick=&quot;" + strGrid + "_LinkButton3_Click&quot;&gt;&lt;i class=&quot;icon-remove&quot;&gt;&amp;nbsp;清除条件&lt;/i&gt;&lt;/asp:LinkButton&gt; ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton runat=&quot;server&quot; class=&quot;btn btn-white btn-sm&quot; ID=&quot;" + strGrid + "_LinkButton4&quot; OnClick=&quot;" + strGrid + "_LinkButton4_Click&quot;&gt;&lt;i class=&quot;icon-search&quot;&gt;&amp;nbsp;查 询&lt;/i&gt;&lt;/asp:LinkButton&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";

        }

        strDiv += "<br/>";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;widget-body&quot;&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div class=&quot;widget-main no-padding&quot;&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:GridView ID=&quot;" + strGrid + "&quot; runat=&quot;server&quot;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; class=&quot;table table-striped table-bordered table-hover no-margin-bottom no-border-top&quot;  ";

        if (BCx)
        {
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AllowPaging=&quot;True&quot; PageSize=&quot;&lt;%# Convert.ToInt16(DefaultList) %&gt;&quot; OnPageIndexChanging=&quot;" + strGrid + "_PageIndexChanging&quot;";
        }

        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AllowSorting=&quot;True&quot; AutoGenerateColumns=&quot;False&quot;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; OnSorting=&quot;" + strGrid + "_Sorting&quot;  DataKeyNames=&quot;ID&quot; OnSelectedIndexChanging=&quot;" + strGrid + "_SelectedIndexChanging&quot;";

        if (BEdit)
        {
            strDiv += " OnRowCancelingEdit=&quot;" + strGrid + "_RowCancelingEdit&quot; OnRowEditing=&quot;" + strGrid + "_RowEditing&quot; OnRowUpdating=&quot;" + strGrid + "_RowUpdating&quot; ";
        }

        if (BAdd)
        {
            strDiv += " OnRowCommand=&quot;" + strGrid + "_RowCommand&quot;";
        }

        if (Bdel)
        {
            strDiv += " OnRowDataBound=&quot;" + strGrid + "_RowDataBound&quot; ";


            strDiv += " OnRowDeleting=&quot;" + strGrid + "_RowDeleting&quot;";
        }

        strDiv += "&gt; ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Columns&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ButtonField DataTextField=&quot;ID&quot; HeaderText=&quot;ID&quot; CommandName=&quot;Select&quot; SortExpression=&quot;ID&quot; Text=&quot;按钮&quot; /&gt;";

        /////// gridview 列循序显示
        for (int i = 0; i < arrayYW.Length; i++)
        {
            string arrYW = arrayYW[i];
            string arrZW = arrayZW[i];
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:BoundField DataField=&quot;" + arrYW + "&quot; SortExpression=&quot;" + arrYW + "&quot; HeaderText=&quot;" + arrZW + "&quot;&gt;&lt;/asp:BoundField&gt;";
        }
        /////// gridview 列循序显示
        if (BEdit || Bdel)
        {
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:TemplateField InsertVisible=&quot;False&quot; ShowHeader=&quot;False&quot;&gt;  ";

            if (BEdit)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;EditItemTemplate&gt;";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButton1&quot; runat=&quot;server&quot; CausesValidation=&quot;True&quot; CommandName=&quot;Update&quot; Text=&quot;&amp;lt;i class=&#39;icon-pencil bigger-130&#39;&amp;gt;&amp;lt;/i&amp;gt;&quot;&gt;&lt;/asp:LinkButton&gt;  ";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &amp;nbsp;&lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButton2&quot; runat=&quot;server&quot; CausesValidation=&quot;False&quot; CommandName=&quot;Cancel&quot; Text=&quot;&amp;lt;i class=&#39;icon-undo bigger-130&#39;&amp;gt;&amp;lt;/i&amp;gt;&quot;&gt;&lt;/asp:LinkButton&gt;  ";


                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/EditItemTemplate&gt;  ";
            }
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ItemTemplate&gt;  ";

            if (BEdit)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButton1&quot; runat=&quot;server&quot; CausesValidation=&quot;False&quot; CommandName=&quot;Edit&quot; Text=&quot;&amp;lt;i class=&#39;icon-edit bigger-130&#39;&amp;gt;&amp;lt;/i&amp;gt;&quot;&gt;&lt;/asp:LinkButton&gt;";
            }
            if (Bdel)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &amp;nbsp;&lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButton2&quot; runat=&quot;server&quot; CausesValidation=&quot;False&quot; CommandName=&quot;Delete&quot; Text=&quot;&amp;lt;i class=&#39;icon-remove-sign bigger-130&#39;&amp;gt;&amp;lt;/i&amp;gt;&quot;&gt;&lt;/asp:LinkButton&gt;";
            }
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/ItemTemplate&gt; ";

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/asp:TemplateField&gt; ";

        }
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/Columns&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;PagerTemplate&gt; ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;div&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ul class=&quot;pagination&quot;&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;li&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButton1&quot; runat=&quot;server&quot; CommandArgument=&quot;First&quot; CommandName=&quot;Page&quot;&gt;&lt;i class=&quot;icon-double-angle-left&quot;&gt;&lt;/i&gt;&lt;/asp:LinkButton&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/li&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;li&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButtonPreviousPage&quot; runat=&quot;server&quot; CommandArgument=&quot;Prev&quot;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; CommandName=&quot;Page&quot;&gt;&lt;i class=&quot;icon-angle-left&quot;&gt;&lt;/i&gt;&lt;/asp:LinkButton&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/li&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;li class=&quot;active&quot;&gt; ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;a href=&quot;#&quot;&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:Label ID=&quot;" + strGrid + "_LabelCurrentPage&quot; runat=&quot;server&quot; Text=&quot;&lt;%# ((GridView)Container.NamingContainer).PageIndex + 1 %&gt;&quot;&gt;&lt;/asp:Label&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; /";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:Label ID=&quot;" + strGrid + "_LabelPageCount&quot; runat=&quot;server&quot; Text=&quot;&lt;%# ((GridView)Container.NamingContainer).PageCount %&gt;&quot;&gt;&lt;/asp:Label&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/a&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/li&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;li&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButtonNextPage&quot; runat=&quot;server&quot; CommandArgument=&quot;Next&quot; CommandName=&quot;Page&quot;&gt;&lt;i class=&quot;icon-angle-right&quot;&gt;&lt;/i&gt;&lt;/asp:LinkButton&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/li&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;li&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButtonLastPage&quot; runat=&quot;server&quot; CommandArgument=&quot;Last&quot; CommandName=&quot;Page&quot;&gt; &lt;i class=&quot;icon-double-angle-right&quot;&gt;&lt;/i&gt;&lt;/asp:LinkButton&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/li&gt;  ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/ul&gt;  ";

        if (BAdd)  /// 模态框添加按钮 
        {
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ul class=&quot;pagination&quot;&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;li&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:LinkButton ID=&quot;" + strGrid + "_LinkButton_Add&quot; runat=&quot;server&quot; CommandName=&quot;" + strGrid + "_ADD&quot;&gt;&lt;i class=&quot;icon-plus-sign&quot;&gt;&amp;nbsp;" + strZWZS + "添加&lt;/i&gt;&lt;/asp:LinkButton&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/li&gt;  ";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/ul&gt;  ";

        } /// 模态框添加按钮 结束
        /// 
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/PagerTemplate&gt;";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/asp:GridView&gt; ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";


        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";

        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt; ";



        if (BNoSx)
        {
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/ContentTemplate&gt;";


            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/asp:UpdatePanel&gt;";
        }

        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &lt;!-- /widget-box --&gt; ";


        strDiv += "&nbsp; &nbsp; &lt;/div&gt; ";


        strDiv += "<br/>";

        /////////////////////////////////////////////////////////////////////////
        strDiv += "<b>CS 后台代码：</b><br/>";
        /////////////////////////////////////////////////////////////////////////


        strDiv += "&nbsp; &nbsp; #region &quot;" + strGrid + " 读取" + strZWZS + " 相关代码&quot;";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; /// 模块列表读取  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; private void Load_" + strGrid + "()";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; // 获取GridView排序数据列及排序方向  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string sortExpression = this." + strGrid + ".Attributes[&quot;SortExpression&quot;]; ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string sortDirection = this." + strGrid + ".Attributes[&quot;SortDirection&quot;];";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string strSQL;";
        strDiv += "</p>";
        if (BCx)
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (this." + strGrid + "_Label_tj.Text.Length &gt; 0)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; strSQL = &quot;SELECT * FROM " + strSQL + " where &quot; + this." + strGrid + "_Label_tj.Text.Trim() + &quot; ORDER BY ID&quot;;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
        }
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; strSQL = &quot;SELECT * FROM " + strSQL + " ORDER BY ID&quot;;";
        strDiv += "</p>";
        if (BCx)
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
        }
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (OP_Mode.SQLRUN(strSQL))";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; /// 设置排序 ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if ((!string.IsNullOrEmpty(sortExpression)) &amp;&amp; (!string.IsNullOrEmpty(sortDirection)))";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; OP_Mode.Dtv.Sort = string.Format(&quot;{0} {1}&quot;, sortExpression, sortDirection);";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; /// 设置翻页层始终显示 ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "<br/>";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (OP_Mode.Dtv.Count == 0)";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; OP_Mode.Dtv.AddNew();  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "<br/>";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + ".DataSource = OP_Mode.Dtv; ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + ".DataBind(); ";
        strDiv += "</p>";
        if (BAdd)
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + ".BottomPagerRow.Visible = true; ";
            strDiv += "</p>";
        }
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, strSQL + &quot;&lt;br/&gt;&quot; + OP_Mode.strErrMsg);";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return;  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_Sorting(object sender, GridViewSortEventArgs e)  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; // 从事件参数获取排序数据列";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string sortExpression = e.SortExpression.ToString();";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; // 假定为排序方向为“顺序”";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string sortDirection = &quot;ASC&quot;;  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (sortExpression == this." + strGrid + ".Attributes[&quot;SortExpression&quot;])";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //获得下一次的排序状态 ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; sortDirection = (this." + strGrid + ".Attributes[&quot;SortDirection&quot;].ToString() == sortDirection ? &quot;DESC&quot; : &quot;ASC&quot;);";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; // 重新设定GridView排序数据列及排序方向  ";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + ".Attributes[&quot;SortExpression&quot;] = sortExpression;";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + ".Attributes[&quot;SortDirection&quot;] = sortDirection;";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; }";
        strDiv += "</p>";
        if (BCx)
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_PageIndexChanging(object sender, GridViewPageEventArgs e) ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; // 得到该控件";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; GridView theGrid = sender as GridView;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; int newPageIndex = 0;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (e.NewPageIndex == -3)  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //点击了Go按钮";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TextBox txtNewPageIndex = null; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; GridViewRow pagerRow = theGrid.BottomPagerRow;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (pagerRow != null)  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //得到text控件";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; txtNewPageIndex = pagerRow.FindControl(&quot;txtNewPageIndex&quot;) as TextBox;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (txtNewPageIndex != null)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //得到索引";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //点击了其他的按钮";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; newPageIndex = e.NewPageIndex;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; //防止新索引溢出  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; newPageIndex = newPageIndex &lt; 0 ? 0 : newPageIndex; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; newPageIndex = newPageIndex &gt;= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; //得到新的值 ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; theGrid.PageIndex = newPageIndex;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; //重新绑定";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";
        }
        if (BEdit)
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_RowEditing(object sender, GridViewEditEventArgs e)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; " + strGrid + ".EditIndex = e.NewEditIndex;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; //" + strGrid + ".EditRowStyle.BackColor = Color.FromName(&quot;#CAD3E4&quot;); ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";

            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; " + strGrid + ".SelectedIndex = -1;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; " + strGrid + ".EditIndex = -1;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";

            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_RowUpdating(object sender, GridViewUpdateEventArgs e) ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string ID = " + strGrid + ".DataKeys[e.RowIndex].Values[0].ToString(); ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; /// 模块名称 ";
            strDiv += "</p>";
            ////   数据更新字段循环开始
            /////// gridview 列循序显示
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];
                strDiv += "<p>";
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string DB_0" + (i + 1).ToString() + " = ((TextBox)" + strGrid + ".Rows[e.RowIndex].Cells[" + (i + 1).ToString() + "].Controls[0]).Text.ToString().Replace(\"'\", \"\\\"\");";
                strDiv += "</p>";
            }
            /////////////////////////////////////

            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (!(DB_01.Length &gt; 0))";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;" + arrayZW[0] + "不允许为空！&lt;br/&gt;请认真填写。&quot;); ";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox( &quot;&quot;, &quot;" + arrayZW[0] + "不允许为空！&lt;br/&gt;请认真填写。&quot;); ";
            }

            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";

            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string strSQL = string.Empty;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; strSQL = &quot;Update " + strSQL + " SET ";


            ////   数据更新字段循环开始
            /////// gridview 列循序显示
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];
                strDiv += " " + arrYW + "=&#39;&quot; + DB_0" + (i + 1).ToString() + " + &quot;&#39;,";
            }

            strDiv += " LTIME=GETDATE() WHERE ID=&quot; + ID;";


            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (OP_Mode.SQLRUN(strSQL))";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;数据更新成功!&quot;);";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;数据更新成功!&quot;);";
            }
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;数据更新失败！&lt;br/&gt;错误：&quot; + OP_Mode.strErrMsg);";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;数据更新失败！&lt;br/&gt;错误：&quot; + OP_Mode.strErrMsg);";
            }
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; " + strGrid + ".SelectedIndex = -1;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; " + strGrid + ".EditIndex = -1;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";

        }

        strDiv += "</p>";
        if (BAdd) /// 数据保存结束
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; ///&nbsp;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_RowCommand(object sender, GridViewCommandEventArgs e) ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (e.CommandName == &quot;" + strGrid + "_ADD&quot;)  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            if (BNoSx)
            {
                strDiv += "<p>";
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ScriptManager.RegisterStartupScript(" + strGrid + "_UpdatePanel1, this.GetType(), &quot;sKey&quot;, &quot;$(&#39;#" + strGrid + "_ADD&#39;).modal(&#39;show&#39;);&quot;, true);";
                strDiv += "</p>";
            }
            else
            {
                strDiv += "<p>";
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.Page.ClientScript.RegisterStartupScript(typeof(string), &quot;sKey&quot;, \"&lt;script language=JavaScript&gt;$(&#39;#" + strGrid + "_ADD&#39;).modal(&#39;show&#39;)&lt;/script&gt;\");";
                strDiv += "</p>";
            }
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";


            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// 模块数据保存  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_LinkButton1_Click(object sender, EventArgs e)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";

            //////////////////////
            /////// gridview 列循序显示
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];
                strDiv += "<p>";
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; /// " + arrZW + " ";
                strDiv += "</p>";
                strDiv += "<p>";
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string DB_0" + (i + 1).ToString() + " = this." + strGrid + "_TextBox_" + arrYW + ".Text.Trim().Replace(\"'\", \"\\\"\");";
                strDiv += "</p>";
            }
            ////////////////////////////////////

            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (!(DB_01.Length &gt; 0))";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;登录名称不允许为空！&lt;br/&gt;请认真填写。&quot;); ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string strSQL;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; strSQL = &quot;Insert into " + strSQL + " (";

            /////// gridview 列循序显示
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];
                strDiv += " " + arrYW + ",";
            }
            strDiv += "CTIME,LTIME) VALUES (";

            /////// gridview 列循序显示
            for (int i = 0; i < arrayYW.Length; i++)
            {
                string arrYW = arrayYW[i];
                string arrZW = arrayZW[i];
                strDiv += "&#39;&quot; + DB_0" + (i + 1).ToString() + " + &quot;&#39;,";
            }

            strDiv += "GETDATE(),GETDATE()) &quot;;  ";

            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (OP_Mode.SQLRUN(strSQL))";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;" + strZWZS + "信息添加成功!&quot;, Request.Url.LocalPath);";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;" + strZWZS + "信息添加成功!&quot;, Request.Url.LocalPath);";
            }
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;" + strZWZS + "信息添加失败！&lt;br/&gt;错误：&quot; + OP_Mode.strErrMsg);";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;" + strZWZS + "信息添加失败！&lt;br/&gt;错误：&quot; + OP_Mode.strErrMsg);";
            }
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";
        } /// 数据保存结束
        /// 
        if (Bdel)
        {
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; ///&nbsp;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_RowDataBound(object sender, GridViewRowEventArgs e)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; //如果是绑定数据行&nbsp;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (e.Row.RowType == DataControlRowType.DataRow)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";

            int TempI = 3;
            if (Bdel) /// 如果光有删除的时候调整参数数量
            {
                if (!BEdit)
                {
                    TempI = 1;
                }
            }

            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ((LinkButton)e.Row.Cells[" + (arrayYW.Length + 1).ToString() + "].Controls[" + TempI + "]).Attributes.Add(&quot;onclick&quot;, &quot;javascript:return confirm(&#39;你确认要删除：【\\&quot;&quot; + e.Row.Cells[1].Text + &quot;\\&quot; 】吗?&#39;)&quot;);";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";

            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// 模块删除 ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_RowDeleting(object sender, GridViewDeleteEventArgs e) ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string ID = " + strGrid + ".DataKeys[e.RowIndex].Values[0].ToString(); ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string strSQL = &quot;Delete from " + strSQL + " where ID=&quot; + ID;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (OP_Mode.SQLRUN(strSQL))";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;指定数据删除成功^_^！&quot;);";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;指定数据删除成功^_^！&quot;);";

            }
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            if (BNoSx)
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(" + strGrid + "_UpdatePanel1, &quot;&quot;, &quot;指定数据删除错误。&lt;br/&gt;&quot; + OP_Mode.strErrMsg);";
            }
            else
            {
                strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBox(&quot;&quot;, &quot;指定数据删除错误。&lt;br/&gt;&quot; + OP_Mode.strErrMsg);";
            }
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";
        }
        strDiv += "<p>";

        if (BCx)
        {
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; ///&nbsp;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_TJADD_Click(object sender, EventArgs e)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; string strDiv = string.Empty;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (this." + strGrid + "_TextBox_CXTJ.Text.Length == 0)  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_TextBox_CXTJ.Text = &quot;空&quot;; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (this." + strGrid + "_Label1.Text.Length &gt; 0)  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label1.Text += &quot;&lt;b&gt;并且&lt;/b&gt;&lt;br /&gt;&quot;; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label_tj.Text += &quot; and &quot;; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label1.Text += this." + strGrid + "_DropDownList1.SelectedItem.Text + &quot;&amp;nbsp;&quot; + this." + strGrid + "_DropDownList_SF.SelectedItem.Text + &quot;&amp;nbsp;&quot; + this." + strGrid + "_TextBox_CXTJ.Text + &quot;&amp;nbsp;&quot;; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; if (this." + strGrid + "_DropDownList_SF.SelectedValue == &quot;LIKE&quot;) ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label_tj.Text += &quot; &quot; + this." + strGrid + "_DropDownList1.SelectedValue + &quot; &quot; + this." + strGrid + "_DropDownList_SF.SelectedValue + &quot; &quot; + &quot;&#39;%&quot; + this." + strGrid + "_TextBox_CXTJ.Text.Trim() + &quot;%&#39;&quot;;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; else";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label_tj.Text += &quot; &quot; + this." + strGrid + "_DropDownList1.SelectedValue + &quot; &quot; + this." + strGrid + "_DropDownList_SF.SelectedValue + &quot; &quot; + &quot;&#39;&quot; + this." + strGrid + "_TextBox_CXTJ.Text.Trim() + &quot;&#39;&quot;; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_TextBox_CXTJ.Text = string.Empty;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_alerts_tj.Visible = true;  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// 清除查询条件  ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_LinkButton3_Click(object sender, EventArgs e)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_TextBox_CXTJ.Text = string.Empty;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label1.Text = string.Empty;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_Label_tj.Text = string.Empty;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; this." + strGrid + "_alerts_tj.Visible = false; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// 查询 ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;/summary&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; ";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_LinkButton4_Click(object sender, EventArgs e)";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; {";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; Load_" + strGrid + "();";
            strDiv += "</p>";
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; }";
            strDiv += "</p>";
        }
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; protected void " + strGrid + "_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; {";
        strDiv += "</p>";
        /////// gridview 列循序显示
        for (int i = 0; i < arrayYW.Length; i++)
        {
            string arrYW = arrayYW[i];
            string arrZW = arrayZW[i];
            strDiv += "<p>";
            strDiv += "&nbsp; &nbsp; &nbsp; &nbsp; " + strGrid + ".Rows[e.NewSelectedIndex].Cells[" + (i).ToString() + "].BackColor = Color.FromName(&quot;#CAD3E4&quot;); ";
            strDiv += "</p>";
        }

        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; }";
        strDiv += "</p>";
        strDiv += "<p>";
        strDiv += "&nbsp; &nbsp; #endregion";
        strDiv += "</p>";

        this.strCode.InnerHtml = strDiv;


        MessageBox("", "代码已生成成功。<br/>请酌情修改。<br/>1、生成删除提示错误，需要加 反斜杠。<br/>2、数据添加修改的时候需要添加数据验证信息。");

    }
}