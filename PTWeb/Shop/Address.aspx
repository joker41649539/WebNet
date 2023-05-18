<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <h3 class="header smaller lighter blue"><i class="icon-globe"></i>&nbsp;收货地址</h3>
    </div>
    <div class="col-xs-12 page-content" id="Div_Address" runat="server">
    </div>
    <div class="col-xs-12">
        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-block btn-success" PostBackUrl="/Shop/AddressNew.aspx" runat="server"><i class="icon-globe"></i>&nbsp;添加新地址</asp:LinkButton>
        <div class="hr hr8 hr-double"></div>
    </div>
</asp:Content>

