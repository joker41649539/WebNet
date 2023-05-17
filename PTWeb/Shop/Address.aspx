<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <h3 class="header smaller lighter blue"><i class="icon-globe"></i>&nbsp;收货地址</h3>
    </div>
    <div class="col-xs-12 page-content">
        <div class="well">
            <h5>安徽省合肥市瑶海区东升花园13#304室<br/>陆先生<br />13955174421</h5>
            <p class="btn-group pull-right">
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-sm" runat="server"><i class="icon-edit"></i>&nbsp;编辑</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-sm btn-danger" runat="server"><i class="icon-trash"></i>&nbsp;删除</asp:LinkButton>
            </p>
            &nbsp;
        </div>
    </div>
    <div class="col-xs-12">
        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-block btn-success" PostBackUrl="/Shop/AddressNew.aspx" runat="server"><i class="icon-globe"></i>&nbsp;添加新地址</asp:LinkButton>
    </div>
</asp:Content>

