<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BBShow.aspx.cs" Inherits="BBGL_BBShow" %>

<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/BBGL/MYBB.aspx">我的报表</a></li>
            <li class="active"><a href="/BBGL/BBShow.aspx">报表显示</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-sm-12">
        <div class="col-xs-12">
            <div class="page-content" runat="server" id="DIVSearch">
                <div class="row">
                    <div class="col-xs-12" runat="server" id="DIV1">
                        <div class="form-group">
                            <asp:Label ID="Label1" class="col-sm-3 control-label right" for="form-field-1" runat="server" Text="Label"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox1" ClientIDMode="Static" class="col-xs-12 col-sm-12" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12" runat="server" id="DIV2">
                        <div class="form-group">
                            <asp:Label ID="Label2" class="col-sm-3 control-label right" for="form-field-1" runat="server" Text="Label"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12" runat="server" id="DIV3">
                        <div class="form-group">
                            <asp:Label ID="Label3" class="col-sm-3 control-label right" for="form-field-1" runat="server" Text="Label"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12" runat="server" id="DIV4">
                        <div class="form-group">
                            <asp:Label ID="Label4" class="col-sm-3 control-label right" for="form-field-1" runat="server" Text="Label"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12" runat="server" id="DIV5">
                        <div class="form-group">
                            <asp:Label ID="Label5" class="col-sm-3 control-label right" for="form-field-1" runat="server" Text="Label"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="LinkButton_Search" class="btn btn-info " runat="server"><i class="icon-search"></i>查 询</asp:LinkButton>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
    </div>
    <cc1:StiWebViewer ID="StiWebViewer1" ViewMode="WholeReport" runat="server" ShowBookmarksButton="False" ShowExportDialog="False" ShowExportToBmp="False" ShowExportToCsv="False" ShowExportToDbf="False" ShowExportToDif="False" ShowExportToDocument="False" ShowExportToExcelXml="False" ShowExportToGif="False" ShowExportToHtml="False" ShowExportToJpeg="False" ShowExportToMetafile="False" ShowExportToMht="False" ShowExportToOds="False" ShowExportToOdt="False" ShowExportToPcx="False" ShowExportToPng="False" ShowExportToRtf="False" ShowExportToSvg="False" ShowExportToSvgz="False" ShowExportToSylk="False" ShowExportToText="False" ShowExportToTiff="False" ShowExportToXml="False" ShowExportToXps="False" ShowParametersButton="False" ShowViewMode="False" ShowZoom="False" ShowPrevButton="False" />

    <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>
<%--    <script type='text/javascript'>
        /// 调用日期选择空间 
        $(function () {
            $('#TextBox1').datepicker();
        });
    </script>--%>
</asp:Content>

