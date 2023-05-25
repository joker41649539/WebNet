<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsRecords.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="Label_Title" runat="server" Text="Label"></asp:Label></h1>
    <div class="center">
        <asp:Image ID="Image1" class="img-rounded width-100" runat="server" />
    </div>
    <div class="col-xs-12">
        <asp:GridView DataKeyNames="ID,Flag" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView_Goods" ClientIDMode="Static" runat="server">
            <Columns>
                <asp:BoundField DataField="HolderID" HeaderText="卖家"></asp:BoundField>
                <asp:BoundField DataField="Price" HeaderText="单价"></asp:BoundField>
                <asp:BoundField DataField="UserID" HeaderText="买家"></asp:BoundField>
                <asp:BoundField DataField="Flag" HeaderText="状态"></asp:BoundField>
                <asp:BoundField DataField="CTime" DataFormatString="{0:MM-dd HH:mm}" HeaderText="时间"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView_Goods tr").each(function () {
            var mtd = $(this).children("td:eq(3)");
            if (mtd.text() == 0) {
                mtd.html("<span class=\"label label-danger\">待付款</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html("<span class=\"label label-success\">完成</span>");
            }
            else if (mtd.text() == 2) {
                mtd.html("<span class=\"label label-Warning\">待确认</span>");
            }
        });
    </script>
</asp:Content>

