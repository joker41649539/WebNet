<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintReport.aspx.cs" Inherits="BBGL_PrintReport" %>

<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li class="active"><a href="#">
                <asp:Label ID="Label_Name" runat="server" Text="Label"></asp:Label></a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <cc1:StiWebViewer ID="StiWebViewer1" ViewMode="WholeReport" runat="server" ShowBookmarksButton="False" ShowExportDialog="False" ShowExportToBmp="False" ShowExportToCsv="False" ShowExportToDbf="False" ShowExportToDif="False" ShowExportToDocument="False" ShowExportToExcelXml="False" ShowExportToGif="False" ShowExportToHtml="False" ShowExportToJpeg="False" ShowExportToMetafile="False" ShowExportToMht="False" ShowExportToOds="False" ShowExportToOdt="False" ShowExportToPcx="False" ShowExportToPng="False" ShowExportToRtf="False" ShowExportToSvg="False" ShowExportToSvgz="False" ShowExportToSylk="False" ShowExportToText="False" ShowExportToTiff="False" ShowExportToXml="False" ShowExportToXps="False" ShowParametersButton="False" ShowViewMode="False" ShowZoom="False" />
</asp:Content>

