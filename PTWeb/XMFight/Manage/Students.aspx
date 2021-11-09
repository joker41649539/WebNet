<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="XMFight_Manage_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-8">
            <div class="input-group">
                <asp:TextBox ID="TextBox1" class="form-control search-query" placeholder="请输入需查询姓名"  runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Button1" class="btn btn-purple btn-sm" runat="server" Text=" 查  询" OnClick="Button1_Click" />
                </span>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="widget-main no-padding">
            <div class="dialogs">
                <div runat="server" id="Div_StudentsList"></div>
            </div>
        </div>
    </div>
</asp:Content>

