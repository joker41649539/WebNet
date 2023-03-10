<%@ Page Title="旭铭搏击-我的订单" Language="C#" MasterPageFile="~/TuanGou/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TuanGou_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content center" style="height: auto;">
        <span class="profile-picture">
            <img id="Image_User" class="editable img-responsive" src="/images/XMFightLogo.jpg" style="max-width: 150px" />
        </span>
        <div class="space-4"></div>
        <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
            <div class="inline position-relative">
                <i class="icon-circle light-green middle"></i>
                <span id="ContentPlaceHolder1_Label_Name" class="white">旭铭搏击</span>
            </div>
        </div>
        <hr />
        <div class="widget-main no-padding">
            <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:HyperLinkField DataTextField="OfferName" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Tuangou/OfferInfo.aspx?id={0}" HeaderText="团购名称"></asp:HyperLinkField>
                    <asp:BoundField DataField="OfferPrice" SortExpression="LTime" HeaderText="团购金额"></asp:BoundField>
                    <asp:BoundField DataField="ctime" DataFormatString="{0:yyyy-MM-dd}" SortExpression="LTime" HeaderText="团购日期"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

