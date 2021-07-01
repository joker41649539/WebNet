<%@ Page Title="" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Remember_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <span class="btn btn-warning btn-sm">Left</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-info btn-sm">Bottom</span>
        <span class="btn btn-warning btn-sm">Left</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-info btn-sm">Bottom</span>
    </p>
    <div class="well">
        <h3 class="red lighter">记忆内容</h3>
        <h6>2021-01-01 第 1 次背诵，已背诵 5 次。</h6>
        <p>
            <span class="label label-warning">Left</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-info">Bottom</span>
            <span class="label label-warning">Left</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-info">Bottom</span>
        </p>
        <div class="btn-group">
            <button class="btn btn-sm btn-success"><i class="icon-ok"></i>完成</button>
            <button class="btn btn-sm btn-danger"><i class="icon-eye-close"></i>很熟</button>
            <button class="btn btn-sm btn-info"><i class="icon-edit"></i>编辑</button>
        </div>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <%--   ReturnMsg.InnerHtml += " <div class=\"well\">";
                            ReturnMsg.InnerHtml += "   <h4 class=\"red smaller lighter\">单据被退回</h4>";
                            ReturnMsg.InnerHtml += " <h2>" + OP_Mode.Dtv[0]["ReturnMSG"].ToString() + "</h2>";
                            ReturnMsg.InnerHtml += " </div>";--%>
</asp:Content>

