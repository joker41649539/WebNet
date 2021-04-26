<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="CWGL_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function method1(tableid) {//整个表格拷贝到EXCEL中
            var date = new Date();
            var exportFileContent = document.getElementById(tableid).outerHTML;
            var blob = new Blob([exportFileContent], { type: "text/plain;charset=utf-8" });         //解决中文乱码问题
            blob = new Blob([String.fromCharCode(0xFEFF), blob], { type: blob.type });
            var link = window.URL.createObjectURL(blob);
            var a = document.createElement("a");    //创建a标签
            a.download = "报销单" + date.getFullYear() + date.getMonth() + date.getDay() + ".xls";  //设置被下载的超链接目标（文件名）
            a.href = link;                            //设置a标签的链接
            document.body.appendChild(a);            //a标签添加到页面
            a.click();                                //设置a标签触发单击事件
            document.body.removeChild(a);            //移除a标签
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/CWGL/">财务管理</a></li>
            <li class="active">报销单查询</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>报销单查询							</h1>
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>报销单查询                </h4>
                <asp:DropDownList ID="GridView1_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="USERNAME">姓名</asp:ListItem>
                    <asp:ListItem Value="W_BXD1.BXDH">单据编号</asp:ListItem>
                    <asp:ListItem Value="W_BXD1.REMARK">施工编号(事由)</asp:ListItem>
                    <asp:ListItem Value="Occurrence">发生日期</asp:ListItem>
                    <asp:ListItem Value="FLAG">状态</asp:ListItem>
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView1_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView1_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView1_TJADD_Click" ID="GridView1_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <button onclick="javascript:method1('GridView1');" class="btn btn-white btn-sm"><i class="icon-plus-sign">&nbsp;导出Excel</i></button>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="ace" RepeatColumns="11" RepeatLayout="Flow">
                <asp:ListItem Text="&nbsp;交通费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;补助&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;采购物资&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;运输费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;租脚手架&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;开槽费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;开孔费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;停车费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;加油费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;招待费&nbsp;"></asp:ListItem>
                <asp:ListItem Text="&nbsp;其他&nbsp;"></asp:ListItem>
            </asp:CheckBoxList>
            <div id="GridView1_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView1_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView1_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView1_LinkButton3" OnClick="GridView1_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView1_LinkButton4" OnClick="GridView1_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
         《状态说明:2 综合部；3 物资部; 4 工程部；5 财务部；6 待放款；7 待收票；》
                </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False">
                        <Columns>
                            <asp:ButtonField DataTextField="BXDH" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="报销单号" />
                            <asp:BoundField DataField="FLAG" SortExpression="FLAG" HeaderText="状态"></asp:BoundField>
                            <asp:BoundField DataField="USERNAME" SortExpression="USERNAME" HeaderText="姓名"></asp:BoundField>
                            <asp:BoundField DataField="SY" SortExpression="SY" HeaderText="施工编号(事由)"></asp:BoundField>
                            <asp:BoundField DataField="Occurrence" SortExpression="Occurrence" HeaderText="发生日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="KZXM" SortExpression="KZXM" HeaderText="开支项目"></asp:BoundField>
                            <asp:BoundField DataField="BREAKFIRST" SortExpression="BREAKFIRST" HeaderText="早餐补助"></asp:BoundField>
                            <asp:BoundField DataField="ZCBZ" SortExpression="ZCBZ" HeaderText="中餐补助"></asp:BoundField>
                            <asp:BoundField DataField="WCBZ" SortExpression="WCBZ" HeaderText="晚餐补助"></asp:BoundField>
                            <asp:BoundField DataField="ZSBZ" SortExpression="ZSBZ" HeaderText="住宿补助"></asp:BoundField>
                            <asp:BoundField DataField="DRZS" SortExpression="DRZS" HeaderText="多人住宿"></asp:BoundField>
                            <asp:BoundField DataField="TXR" SortExpression="TXR" HeaderText="同行人"></asp:BoundField>
                            <asp:BoundField DataField="MC" SortExpression="MC" HeaderText="名称(开支项目)"></asp:BoundField>
                            <asp:BoundField DataField="BECITY" SortExpression="BECITY" HeaderText="出发城市"></asp:BoundField>
                            <asp:BoundField DataField="ARRIVAL" SortExpression="ARRIVAL" HeaderText="到达城市"></asp:BoundField>
                            <asp:BoundField DataField="BXJE" SortExpression="BXJE" HeaderText="报销金额"></asp:BoundField>
                            <asp:BoundField DataField="REMARK" SortExpression="REMARK" HeaderText="报销说明"></asp:BoundField>
                            <%--                            <asp:ImageField DataImageUrlField="image" ItemStyle-Width="100px">
                            </asp:ImageField>--%>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView1_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView1_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView1_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView1_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView1_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView1_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(1)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-success\">待提交</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-danger\">已完结</span>");
            }
            else if (mtd.text() == 2) {
                mtd.html(" <span class=\"label label-info\">综合部</span>");
            }
            else if (mtd.text() == 3) {
                mtd.html(" <span class=\"label label-info\">物资部</span>");
            }
            else if (mtd.text() == 4) {
                mtd.html(" <span class=\"label label-pink\">工程部</span>");
            }
            else if (mtd.text() == 5) {
                mtd.html(" <span class=\"label label-info\">财务部</span>");
            }
            else if (mtd.text() == 6) {
                mtd.html(" <span class=\"label label-pink\">待放款</span>");
            }
            else if (mtd.text() == 7) {
                mtd.html(" <span class=\"label label-pink\">待收票</span>");
            }
        });

        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(6)");
            if (mtd.text() == 0.00) {
                mtd.html(" ");
            }
        });
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(7)");
            if (mtd.text() == 0.00) {
                mtd.html(" ");
            }
        });
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(8)");
            if (mtd.text() == 0.00) {
                mtd.html(" ");
            }
        });
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(9)");
            if (mtd.text() == 0.00) {
                mtd.html(" ");
            }
        });
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(10)");
            if (mtd.text() == 0.00) {
                mtd.html(" ");
            }
        });

    </script>

</asp:Content>

