<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCBX.aspx.cs" Inherits="GDGL_GCBX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
            <li class="active"><a href="#">布线安装</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-sm-12" runat="server" id="Dtv_HTML">
        <h3 class="header blue lighter smaller">
            <i class="icon-reorder smaller-90"></i>
            <asp:HyperLink ID="Label_GCMC" runat="server">HyperLink</asp:HyperLink>
        </h3>
        <div>
            <h4><b>安装位置：</b><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>设备编号：</b><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>设备名称：</b><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>设备品牌：</b><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>设备型号：</b><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>计量单位：</b><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>数量：</b><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>注意事项：</b><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></h4>
            <h4><b>布线分数：</b><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></h4>
            <asp:HiddenField ID="HiddenField_SYFS" runat="server" />
        </div>
    </div>

</asp:Content>
