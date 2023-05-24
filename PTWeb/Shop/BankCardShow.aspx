<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="BankCardShow.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="HiddenField_ID" runat="server" />
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>
                <asp:Label ID="Label_Title" runat="server" Text="Title"></asp:Label></b></h3>
            <div class="col-sm-9">
                <h1 class="red"><b>￥<span><asp:Label ID="Label_Price" runat="server" Text="0.00"></asp:Label></span></b>
                </h1>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <asp:Image ID="Image_BigImg" class="img-rounded width-100" runat="server" />
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>付款凭证</b></h3>
            <div class="col-sm-9">
                <asp:Image ID="Image1" class="img-rounded width-100" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <br />
        <asp:LinkButton ID="LinkButton_Up" OnClick="LinkButton_Up_Click" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;确认收款</asp:LinkButton>
        <br />
    </div>
</asp:Content>

