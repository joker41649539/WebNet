<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCBXList.aspx.cs" Inherits="GDGL_GCBXList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>
            <asp:HyperLink ID="Label_GCMC" runat="server">HyperLink</asp:HyperLink><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;<asp:Label ID="Label_AZWZ" runat="server" Text="Label"></asp:Label></small></h1>
    </div>
    <div class="tabbable">
        <div class="widget-box transparent">
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_List" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_List_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_List_SelectedIndexChanging" OnRowCancelingEdit="GridView_List_RowCancelingEdit" OnRowEditing="GridView_List_RowEditing" OnRowUpdating="GridView_List_RowUpdating" OnRowDataBound="GridView_List_RowDataBound" OnRowDeleting="GridView_List_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="SBBH" SortExpression="SBBH" HeaderText="设备编号"></asp:BoundField>
                            <asp:BoundField DataField="FS" SortExpression="FS" HeaderText="布线分数"></asp:BoundField>
                            <asp:BoundField DataField="YAZ" SortExpression="YAZ" HeaderText="已布线百分比"></asp:BoundField>
                            <asp:ButtonField HeaderText="安装" CommandName="Select" SortExpression="ID" Text="安装" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView_List tr").each(function () {
            var mtd = $(this).children("td:eq(2)");
            var m = $(this).children("td:eq(1)");
            if (mtd.text() == '0') {
                if (mtd.text() == m.text()) {
                    mtd.html(" <span class=\"label label-danger\">100 %</span>");
                }
                else {
                    mtd.html(" <span class=\"label label-success\">" + mtd.text() + " %</span>");
                }
            }
            else if (mtd.text() >= 100) {
                mtd.html(" <span class=\"label label-danger\">" + mtd.text() + " %</span>");
            }
            else {
                mtd.html(" <span class=\"label label-purple\">" + mtd.text() + " %</span>");
            }
        });

    </script>
</asp:Content>

