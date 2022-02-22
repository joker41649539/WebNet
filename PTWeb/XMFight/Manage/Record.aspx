<%@ Page Title="今日消课" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Record.aspx.cs" Inherits="XMFight_Manage_Record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="姓名"></asp:BoundField>
                <asp:BoundField DataField="ICount" SortExpression="ICount" HeaderText="课时"></asp:BoundField>
                <asp:BoundField DataField="LTime" SortExpression="LTime" HeaderText="时间"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

