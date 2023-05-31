<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="Friends.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <asp:Image ID="Image1" class="width-100 img-rounded" runat="server" />
    </div>
    <div class="col-xs-12">
        <div class="space-10"></div>
        <asp:LinkButton ID="LinkButton1" class="btn btn-block btn-success" OnClick="LinkButton1_Click" runat="server">生成我的推广二维码</asp:LinkButton>
    </div>
</asp:Content>

