<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QDSearchByDay.aspx.cs" Inherits="WeChat_QDSearchByDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    .DataGridFixedHeader  
{
  POSITION:   relative   ;  
  TOP:   expression(this.offsetParent.scrollTop);
  BACKGROUND-COLOR:   blue   ;
  height:25px;
  color:#ffffff;
  text-align:center   ;
  vertical-align:middle;
  font-weight:bold;
  font-size:13px;
  background-color:#5D7B9D;
  }--%>

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/WeChat/QDSearchByDay.aspx">签到按日期查询</a></li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>签到记录<small><i class="icon-double-angle-right"></i>&nbsp;<a href="/WeChat/QDSearch.aspx">添加详细签到</a>                                </small></h1>
        </div>
        <div class="form-group">
            <h3><b>日期：</b></h3>
            <div class="col-sm-3">
                <asp:TextBox ID="TextBox_STime" ClientIDMode="Static" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker" type="text" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="TextBox_ETime" ClientIDMode="Static" class="form-control date-picker" type="text" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <asp:LinkButton ID="LinkButton1" CssClass="btn" OnClick="LinkButton1_Click" runat="server">查询</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="page-content">
            <!--人员启用 开始 //-->
            <div class="widget-main no-padding">
                <asp:GridView ID="GridView_KQByDay" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" ColumnAutoWidth="false" AllowSorting="True" ClientIDMode="Static" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" Width="100px">
                    <RowStyle Width="120px" />
                </asp:GridView>
            </div>
            <!--人员启用 结束 //-->
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

