<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsList.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid3">
                <span class="grey bigger">
                    <i class="icon-credit-card icon-2x blue"></i>
                    &nbsp; 商品数量
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label1" runat="server" Text="1.00"></asp:Label>
                </h4>
            </div>

            <div class="grid3">
                <span class="grey">
                    <i class="icon-credit-card icon-2x orange"></i>
                    &nbsp; 初始总金额
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label2" runat="server" Text="0.00"></asp:Label>
                </h4>
            </div>
            <div class="grid3">
                <span class="grey">
                    <i class="icon-credit-card icon-2x pink"></i>
                    &nbsp; 当前总金额
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label3" runat="server" Text="0.00"></asp:Label>
                </h4>
            </div>
        </div>
        <div class="hr hr8 hr-double"></div>
    </div>
    <div class="col-xs-12">
        <asp:GridView DataKeyNames="ID,Flag" OnRowEditing="GridView_Goods_RowEditing" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView_Goods" ClientIDMode="Static" runat="server">
            <Columns>
                <asp:HyperLinkField DataTextField="Title" SortExpression="Title" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Shop/GoodsRecords.aspx?id={0}" HeaderText="名称"></asp:HyperLinkField>
                <asp:BoundField DataField="Price" HeaderText="原价"></asp:BoundField>
                <asp:BoundField DataField="NewPrice" HeaderText="价格"></asp:BoundField>
                <asp:BoundField DataField="Flag" HeaderText="状态"></asp:BoundField>
                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Edit" CausesValidation="False" ID="LinkButton1"><i class="icon-key"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView_Goods tr").each(function () {
            var mtd = $(this).children("td:eq(3)");
            if (mtd.text() == 0) {
                mtd.html("<span class=\"label label-success\">正常</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html("<span class=\"label label-danger\">停用</span>");
            }
        });
    </script>

</asp:Content>

