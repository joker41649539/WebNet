<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">
        <h3 class="header smaller lighter blue"><i class="icon-group"></i>&nbsp;用户信息</h3>
    </div>

    <div class="col-xs-12">
        <div class="input-group">
            <asp:TextBox ID="TextBox_PhoneNo" placeholder="请输入需要查询的号码" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" class="input-group-addon" runat="server"><i class="icon-search bigger-110"></i>&nbsp;查询</asp:LinkButton>
        </div>
        <div class="hr"></div>
        <asp:GridView DataKeyNames="ID,Flag" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnRowEditing="GridView_Users_RowEditing" AutoGenerateColumns="false" ID="GridView_Users" ClientIDMode="Static" runat="server">
            <Columns>
                <asp:BoundField DataField="row_number" HeaderText="SN"></asp:BoundField>
                <asp:BoundField DataField="PhoneNo" HeaderText="用户"></asp:BoundField>
                <asp:BoundField DataField="GoldCount" HeaderText="金豆" DataFormatString="{0:F0}"></asp:BoundField>
                <asp:BoundField DataField="LTime" DataFormatString="{0: MM-dd HH:mm}" HeaderText="最后登录"></asp:BoundField>
                <asp:BoundField DataField="Flag" HeaderText="状态"></asp:BoundField>
                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Edit" CausesValidation="False" ID="LinkButton1"><i class="icon-key"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="hr hr8 hr-double"></div>
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView_Users tr").each(function () {
            var mtd = $(this).children("td:eq(4)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-success\">正常</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-danger\">停用</span>");
            }
        });
    </script>
</asp:Content>

