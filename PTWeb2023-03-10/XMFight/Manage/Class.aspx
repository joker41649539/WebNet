﻿<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="XMFight_Manage_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="btn-group">
            <%--            <a href='/XMFight/Manage/AddPhoto.aspx' class="btn btn-danger btn-sm">添加学员风采</a>--%>
            <a href='/XMFight/Manage/Students.aspx' class="btn btn-sm">学生操作</a>
            <a href='/XMFight/Manage/Record.aspx' class="btn btn-sm">今日消课</a>
            <a href='/XMFight/Manage/ClassAll.aspx' class="btn btn-sm">所有课程</a>
        </div>
    </div>
    <div runat="server" id="Div_StudentsList"></div>
</asp:Content>

