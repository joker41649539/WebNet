<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyGDBXWZ.aspx.cs" Inherits="GDGL_MyGDBXWZ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function myFunction() {
            var x;
            dialog = jqueryAlert({ 'title': '提示信息', 'content': '人员占比未分配,或者分配错误。<br/>请先点击人员分配人员占比。<br/>仅负责人可操作。', 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close(); } } })
            //  alert("人员占比未分配,或者分配错误。\r\n请先点击人员分配人员占比。");
            return false;
        }
    </script>
    <asp:HiddenField ID="HiddenField_ZID" runat="server" />
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
        </ul>
    </div>
    <div class="page-header">
        <h1>
            <asp:Label ID="Label_GCMC" runat="server" Text="Label"></asp:Label></h1>
    </div>
    <span class="page-content">人员： <b>[<asp:HyperLink ID="Label_BXRY" runat="server">无</asp:HyperLink>]</b></span>
    <div runat="server" class="page-content" id="Dtv_HTML"></div>
</asp:Content>

