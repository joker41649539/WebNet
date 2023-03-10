<%@ Page Title="" Language="C#" MasterPageFile="~/Question/MasterPage.master" AutoEventWireup="true" CodeFile="AddinfoS.aspx.cs" Inherits="Question_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>批量数据导入</h1>
        <br />
        <a href="/ExcelTemp/Default.xlsx">
            <asp:Label ID="Label1" class="btn btn-success btn-block" runat="server" Text="数据模板下载"></asp:Label></a>
    </div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:LinkButton ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="Button1_Click"><i class="icon-save bigger-110"></i> 导入数据</asp:LinkButton>

</asp:Content>

