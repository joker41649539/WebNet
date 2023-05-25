<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsRecordsAll.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>名称</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Title" runat="server" placeholder="请输入商品名称" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>日期</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Data" runat="server" placeholder="请输入日期" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <br />
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="btn btn-success btn-block" runat="server"><i class="icon-search"></i>&nbsp;查询</asp:LinkButton>
        </div>
    </div>
    <div class="col-xs-12">
        <asp:GridView DataKeyNames="ID" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView_Goods" ClientIDMode="Static" runat="server">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="名称"></asp:BoundField>
                <asp:BoundField DataField="HolderID" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" HeaderText="卖家"></asp:BoundField>
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
            var mtd = $(this).children("td:eq(4)");
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

