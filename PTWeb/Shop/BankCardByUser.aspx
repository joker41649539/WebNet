<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="BankCardByUser.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>微信收款码</b></h3>
                <div class="col-sm-9">
                    <asp:Image ID="Image_WeChat" class="img-rounded width-100" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>支付宝收款码</b></h3>
                <div class="col-sm-9">
                    <asp:Image ID="Image_Pay" class="img-rounded width-100" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>银行卡信息</b></h3>
                <div class="col-sm-9">
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="银行名字"></asp:Label></h4>
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="开户行"></asp:Label></h4>
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="账号"></asp:Label></h4>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

