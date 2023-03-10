<%@ Page Title="今日消课" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Record.aspx.cs" Inherits="XMFight_Manage_Record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row page-content">
        <div class="input-group">
            <asp:TextBox ID="TextBox1" CssClass="width-35" runat="server"></asp:TextBox>
            - 
        <asp:TextBox ID="TextBox2" CssClass="width-35" runat="server"></asp:TextBox>
            <span class="input-group-btn">
                <asp:Button ID="Button1" class="btn" runat="server" Text="统  计" OnClick="Button1_Click" />
            </span>
        </div>
        <div class="row">
            <div class="hr hr8 hr-double"></div>
            <div class="clearfix">
                <div class="grid4">
                    <span class="green">
                        <i class="icon-twitter-sign icon-2x green"></i>
                        &nbsp; 消课
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label_XK" runat="server" Text="0"></asp:Label>
                        课时</h4>
                </div>
                <div class="grid4">
                    <span class="grey">
                        <i class="icon-twitter-sign icon-2x grey"></i>
                        &nbsp; 请假
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label_QJ" runat="server" Text="0"></asp:Label>
                        课时</h4>
                </div>
                <div class="grid4">
                    <span class="red">
                        <i class="icon-twitter-sign icon-2x red"></i>
                        &nbsp; 旷课
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label_KK" runat="server" Text="0"></asp:Label>
                        课时</h4>
                </div>
                <div class="grid4">
                    <span class="red">
                        <i class="icon-twitter-sign icon-2x red"></i>
                        &nbsp; 总剩余
                    </span>
                    <h4 class="bigger pull-right">
                        <asp:Label ID="Label_Sum" runat="server" Text="0"></asp:Label>
                    课时</h4>
                </div>
            </div>
            <div class="hr hr8 hr-double"></div>
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
        </div>
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

