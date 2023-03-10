<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wxdpdf.aspx.cs" Inherits="BGGL_pdf" %>

<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" type="image/x-icon" href="/images/PTLOGO.png" media="screen" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <title>普田科技工程维修单</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HyperLink ID="HyperLink1" class="btn btn-info"  runat="server">上一张</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" class="btn btn-info" runat="server">下一张</asp:HyperLink>
        <div>
            <cc1:StiWebViewer ID="StiWebViewer1" ViewMode="WholeReport" runat="server" ShowBookmarksButton="False" ShowExportDialog="False" ShowExportToBmp="False" ShowExportToCsv="False" ShowExportToDbf="False" ShowExportToDif="False" ShowExportToDocument="False" ShowExportToExcelXml="False" ShowExportToGif="False" ShowExportToHtml="False" ShowExportToJpeg="true" ShowExportToMetafile="False" ShowExportToMht="False" ShowExportToOds="False" ShowExportToOdt="False" ShowExportToPcx="False" ShowExportToPng="False" ShowExportToRtf="False" ShowExportToSvg="False" ShowExportToSvgz="False" ShowExportToSylk="False" ShowExportToText="False" ShowExportToTiff="False" ShowExportToXml="False" ShowExportToXps="False" ShowParametersButton="False" ShowViewMode="False" ShowZoom="False" ShowPrevButton="False" />
        </div>
    </form>
</body>
</html>
