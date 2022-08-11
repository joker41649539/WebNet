<%@ Page Title="今日消课" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Record.aspx.cs" Inherits="XMFight_Manage_Record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="姓名"></asp:BoundField>
                <asp:BoundField DataField="ICount" SortExpression="ICount" HeaderText="课时"></asp:BoundField>
                <asp:BoundField DataField="iFlag" SortExpression="iFlag" HeaderText="状态"></asp:BoundField>
                <asp:BoundField DataField="LTime" SortExpression="LTime" HeaderText="时间"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(3)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-success\">续课</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label\">消课</span>");
            }
            else if (mtd.text() == 2) {
                mtd.html(" <span class=\"label  label-info\">请假</span>");
            }
            else if (mtd.text() == 3) {
                mtd.html(" <span class=\"label label-danger\">旷课</span>");
            }
            else {
                mtd.html(" <span class=\"label label-warning\">未知</span>");
            }
        });
    </script>
</asp:Content>

