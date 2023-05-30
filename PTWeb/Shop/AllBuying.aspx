<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="AllBuying.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:HiddenField ID="HiddenField_AddressID" runat="server" />
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>抢购人</b></h3>
                <h5>多用户之间用“;”间隔</h5>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" TextMode="MultiLine" ClientIDMode="Static" runat="server" placeholder="请输入收货人 例：13988888888;18088888888" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="space"></div>
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-danger btn-block" runat="server"><i class="icon-shopping-cart"></i>&nbsp;一键抢购[<asp:Label ID="Label1" runat="server" Text="0"></asp:Label>]</asp:LinkButton>
        </div>
        <div class="col-xs-12">
            <div class="space"></div>
            <asp:GridView DataKeyNames="ID" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView_Goods" ClientIDMode="Static" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image runat="server" CssClass="img-rounded width-100" ImageUrl='<%# Eval("BigImg", "/Shop/Img/{0}") %>' ID="Image1"></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataTextField="Title" SortExpression="Title" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Shop/GoodsRecords.aspx?id={0}" HeaderText="名称"></asp:HyperLinkField>
                    <asp:HyperLinkField DataTextField="NewPrice" SortExpression="NewPrice" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Shop/GoodsRecords.aspx?id={0}" HeaderText="单价"></asp:HyperLinkField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

