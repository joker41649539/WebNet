<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="WeChat_Tesp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function add() {
            $("#AddImg").before("<br/> <input type=\"file\" name=\"UpImg\" />");
        }
        function OpenMap(iJD,iWD) {
            $("#AddImg").before("<br/> <input type=\"file\" name=\"UpImg\" />");
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">微信相关</a></li>
            <li class="active"><a href="/WeChat/KQ.aspx">签到打卡</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <input type="file" name="UpImg" />
    <input id="AddImg" type="button" value="添加图片" onclick="add()" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>

