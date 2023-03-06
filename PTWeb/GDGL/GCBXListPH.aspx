<%@ Page Title="工程布线安装" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCBXListPH.aspx.cs" Inherits="GDGL_GCBXListPH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function check_all(obj, cName) {
            var checkboxs = document.getElementsByName(cName);
            for (var i = 0; i < checkboxs.length; i++) {
                checkboxs[i].checked = true;
            }
        }
        function uncheck_all(obj, cName) {
            var checkboxs = document.getElementsByName(cName);
            for (var i = 0; i < checkboxs.length; i++) {
                checkboxs[i].checked = false;
            }
        }
    </script>
    <asp:HiddenField ID="HiddenField_GCID" runat="server" />
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
            <asp:HiddenField ID="HiddenField_BXRS" runat="server" />
            <asp:HyperLink ID="Label_GCMC" runat="server">HyperLink</asp:HyperLink><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;<asp:Label ID="Label_AZWZ" runat="server" Text="Label"></asp:Label></small></h1>
    </div>
    <div class="tabbable content">
        <div class="widget-box transparent">
            <div class="widget-body">
                <div class="widget-main no-padding" runat="server" id="DivList">
                    <%--<asp:GridView ID="GridView_List" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_List_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_List_SelectedIndexChanging" OnRowCancelingEdit="GridView_List_RowCancelingEdit" OnRowEditing="GridView_List_RowEditing" OnRowUpdating="GridView_List_RowUpdating" OnRowDataBound="GridView_List_RowDataBound" OnRowDeleting="GridView_List_RowDeleting">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" Checked="true" Enabled="true" ID="CheckBox1"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SBBH" SortExpression="SBBH" HeaderText="设备编号"></asp:BoundField>
                            <asp:BoundField DataField="FS" SortExpression="FS" HeaderText="布线分数"></asp:BoundField>
                            <asp:BoundField DataField="YAZ" SortExpression="YAZ" HeaderText="已布线百分比"></asp:BoundField>
                            <asp:ButtonField HeaderText="设备编号" DataTextField="SBBH" CommandName="Select" SortExpression="SBBH" />
                            <asp:ButtonField HeaderText="人员" DataTextField="AZRY" CommandName="Select" SortExpression="ID" />
                            <asp:ButtonField HeaderText="进度" DataTextField="ZJD" CommandName="Select" SortExpression="ZJD" />
                        </Columns>
                    </asp:GridView>--%>
                </div>
                <button onclick="check_all(this,'ck')" type="button" class="btn btn-success"><i class='icon-check'></i>全 布</button>
                <button onclick="uncheck_all(this,'ck')" type="button" class="btn btn-success"><i class='icon-check-empty'></i>部分布</button>
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
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="javascript:return confirm('您确定是【主装】吗？')" ID="LinkButton_Save" class="btn btn-info" runat="server" OnClick="LinkButton_Save_Click"><i class="icon-save bigger-110"></i>主 装</asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="javascript:return confirm('您确定是【辅装】吗？')" ID="LinkButton1" class="btn btn-warning" runat="server" OnClick="LinkButton_Save_Click1"><i class="icon-save bigger-110"></i>辅 装</asp:LinkButton>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
</asp:Content>

