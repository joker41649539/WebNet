<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCBXList.aspx.cs" Inherits="GDGL_GCBXList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>
            <asp:HiddenField ID="HiddenField_FZRID" runat="server" />
            <asp:HiddenField ID="HiddenField_GCID" runat="server" />
            <asp:HyperLink ID="Label_GCMC" runat="server">HyperLink</asp:HyperLink><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;<asp:Label ID="Label_AZWZ" runat="server" Text="Label"></asp:Label></small></h1>
    </div>
    <div class="content">
        <div class="widget-box transparent">
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <span>人员： <b>[<asp:HyperLink ID="HyperLink_User" runat="server">XXX 100%</asp:HyperLink>]</b></span>
                    <hr />
                    <asp:GridView ID="GridView_List" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_List_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_List_SelectedIndexChanging" OnRowCancelingEdit="GridView_List_RowCancelingEdit" OnRowEditing="GridView_List_RowEditing" OnRowUpdating="GridView_List_RowUpdating" OnRowDataBound="GridView_List_RowDataBound" OnRowDeleting="GridView_List_RowDeleting">
                        <Columns>
                            <asp:TemplateField AccessibleHeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ClientIDMode="Static" runat="server" Checked="true" ID="ck"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle CssClass="center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SBMC" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" SortExpression="SBMC" HeaderText="设备名称"></asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="ID" SortExpression="SBBH" DataNavigateUrlFormatString="/GDGL/GCBX.aspx?id={0}" DataTextField="SBBH" HeaderText="设备编号"></asp:HyperLinkField>
                            <asp:BoundField DataField="FS" SortExpression="FS" HeaderText="分数"></asp:BoundField>
                            <asp:BoundField DataField="BXRY" SortExpression="BXRY" HeaderText="详细情况"></asp:BoundField>
                            <asp:BoundField DataField="SumPercent" SortExpression="SumPercent" HeaderText="合计"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="4">
                    <asp:ListItem Value="10">&nbsp;刚开始&nbsp;</asp:ListItem>
                    <asp:ListItem Value="50">&nbsp;干一半&nbsp;</asp:ListItem>
                    <asp:ListItem Value="90">&nbsp;快结束&nbsp;</asp:ListItem>
                    <asp:ListItem Value="100">&nbsp;已完成&nbsp;</asp:ListItem>
                </asp:RadioButtonList>
                <hr />
                <div class="widget-body">
                    <asp:TextBox ID="TextBox_Remark" Width="100%" placeholder="如有需要请填写备注信息" runat="server" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </div>
                <asp:LinkButton UseSubmitBehavior="false" OnClick="LinkButton_Save_Click" ID="LinkButton_Save" class="btn btn-info" runat="server"><i class="icon-save bigger-110"></i>确认布线</asp:LinkButton>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
    <script>
        // 字符替换
        $("#GridView_List tr").each(function () {
            var mtd = $(this).children("td:eq(5)");
            if (mtd.text() == '0') {
                mtd.html(" <span class=\"label label-success\">等待中</span>");
            }
            else if (mtd.text() >= 100) {
                mtd.html(" <span class=\"label label-danger\">完成</span>");
            }
            else if (mtd.text() == 10) {
                mtd.html(" <span class=\"label label-info\">刚开始</span>");
            }
            else if (mtd.text() == 50) {
                mtd.html(" <span class=\"label label-pink\">干一半</span>");
            }
            else if (mtd.text() == 90) {
                mtd.html(" <span class=\"label label-purple\">快结束</span>");
            }
        });
    </script>
</asp:Content>

