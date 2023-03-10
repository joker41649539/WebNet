<%@ Page Title="" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="Remembered.aspx.cs" Inherits="Remember_Remembered" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="page-header">
            <h1>记忆计划							<small><i class="icon-double-angle-right"></i>&nbsp;今日已背诵内容                                </small></h1>
        </div>
        <div id="accordion" class="accordion-style1 panel-group" runat="server"></div>
    </div>
    <div class="row" style="height: 50px;">
    </div>
</asp:Content>

