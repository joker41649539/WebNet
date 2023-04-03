<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkPlan.aspx.cs" Inherits="GDGL_WorkPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="HiddenField_UserID" runat="server" />
    <div class="modal fade" id="GCList" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog ">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox_GCMC" ClientIDMode="Static" placeholder="请输入工程关键字" class="form-control" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
                    </div>
                    <br />
                    <asp:GridView ID="GridView_GC" AllowSorting="True" OnSorting="GridView_GC_Sorting" OnPageIndexChanging="GridView_GC_PageIndexChanging" AllowPaging="true" PageSize="10" OnRowCommand="GridView_GC_RowCommand" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" DataKeyNames="ID,GCMC" runat="server">
                        <Columns>
                            <asp:ButtonField DataTextField="GCDD" SortExpression="GCDD" CommandName="Select" HeaderText="地点"></asp:ButtonField>
                            <asp:ButtonField DataTextField="GCMC" SortExpression="GCMC" CommandName="Select" HeaderText="工程名称"></asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                    <div class="form-group">
                        <asp:RadioButtonList ClientIDMode="Static" ID="RadioButtonList1" RepeatColumns="6" runat="server">
                            <asp:ListItem Selected="True">工程</asp:ListItem>
                            <asp:ListItem>维保</asp:ListItem>
                            <asp:ListItem>学习</asp:ListItem>
                            <asp:ListItem>开会</asp:ListItem>
                            <asp:ListItem>请假</asp:ListItem>
                            <asp:ListItem>其它</asp:ListItem>
                        </asp:RadioButtonList>
                        <h3><b>说明信息</b></h3>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TextBox_Remark" runat="server" TextMode="MultiLine" placeholder="如有需要说明的信息，请填写" class="col-xs-12 col-sm-12"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info"
                        data-dismiss="modal">
                        取  消
                    </button>
                    <asp:Button ID="Button1" OnClick="Button1_Click" class="btn btn-success" runat="server" Text="确  定" />
                </div>
            </div>
        </div>
    </div>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/GDGL/WorkPlan.aspx">工作计划</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>工作计划<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;工作计划安排</small></h1>
        </div>
        <div class="page-content">
            <div class="input-group">
                <asp:TextBox ID="TextBox_Time" ClientIDMode="Static" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker" runat="server"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
            </div>
            <hr />
            <asp:GridView ID="GridView_WorkPlan" OnRowDeleting="GridView_WorkPlan_RowDeleting" AllowSorting="True" OnSorting="GridView_WorkPlan_Sorting" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID,WID" OnRowCommand="GridView_WorkPlan_RowCommand" OnSelectedIndexChanged="GridView_WorkPlan_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField DataTextField="CName" SortExpression="CName" CommandName="Select" HeaderText="姓名"></asp:ButtonField>
                    <asp:BoundField DataField="GCDD" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" SortExpression="GCDD" HeaderText="地点"></asp:BoundField>
                    <asp:BoundField DataField="NRemark" SortExpression="NRemark" HeaderText="说明"></asp:BoundField>
                    <asp:BoundField DataField="LTime" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" SortExpression="lt" HeaderText="日期"></asp:BoundField>
                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        jQuery(function ($) {
            $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });
        });
    </script>
</asp:Content>

