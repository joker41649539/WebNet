<%@ Page Title="" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="AllRemember.aspx.cs" Inherits="Remember_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="page-header">
            <h1>记忆训练								<small><i class="icon-double-angle-right"></i>&nbsp;所有记忆内容                                </small></h1>
        </div>
        <div id="accordion" class="accordion-style1 panel-group" runat="server"></div>
    </div>
    <asp:Button ID="Button_Clear" runat="server" Text="清空记忆数据" class="btn btn-danger btn-block" OnClick="Button_Clear_Click"/>
</asp:Content>

