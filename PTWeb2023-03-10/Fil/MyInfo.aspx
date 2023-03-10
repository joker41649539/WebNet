<%@ Page Title="" Language="C#" MasterPageFile="~/Fil/MasterPage.master" AutoEventWireup="true" CodeFile="MyInfo.aspx.cs" Inherits="Fil_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="user-profile-1" class="user-profile row height-auto">
        <div class="col-xs-12 col-sm-3 center">
            <div class="hr hr12 dotted"></div>
            <div class="clearfix">
                <div class="grid2">
                    <span class="bigger-175 blue">
                        <asp:Label ID="Label_ComputerCount" runat="server" Text="0"></asp:Label></span>
                    <br />
                    主机数量
                </div>
                <div class="grid2">
                    <span class="bigger-175 blue">
                        <asp:Label ID="Label_SumPower" runat="server" Text="0"></asp:Label></span>
                    <br />
                    累计算力
                </div>
            </div>
            <div class="hr hr16 dotted"></div>
        </div>
    </div>
    <div runat="server" id="Div_ComputerInfo">
        
    </div>
</asp:Content>

