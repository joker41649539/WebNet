<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BXPercent.aspx.cs" Inherits="GDGL_BXPercent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
        </ul>
    </div>
    <div class="page-header">
        <h1>
            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        </h1>
    </div>
    <div class="content">
        <div class="col-xs-12" runat="server" id="Div1" visible="false">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <h3>
                    <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="姓名1"></asp:Label></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入他的占比，不用输入‘%’" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="Div2" visible="false">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <h3>
                    <asp:Label ID="Label2" Font-Bold="true" runat="server" Text="姓名1"></asp:Label></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入他的占比，不用输入‘%’" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="Div3" visible="false">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <h3>
                    <asp:Label ID="Label3" Font-Bold="true" runat="server" Text="姓名1"></asp:Label></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入他的占比，不用输入‘%’" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="Div4" visible="false">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField4" runat="server" />
                <h3>
                    <asp:Label ID="Label4" Font-Bold="true" runat="server" Text="姓名1"></asp:Label></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" placeholder="请输入他的占比，不用输入‘%’" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="Div5" visible="false">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField5" runat="server" />
                <h3>
                    <asp:Label ID="Label5" Font-Bold="true" runat="server" Text="姓名1"></asp:Label></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" placeholder="请输入他的占比，不用输入‘%’" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="Div6" visible="false">
            <div class="form-group">
                <asp:HiddenField ID="HiddenField6" runat="server" />
                <h3>
                    <asp:Label ID="Label6" Font-Bold="true" runat="server" Text="姓名1"></asp:Label></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox6" ClientIDMode="Static" runat="server" placeholder="请输入他的占比，不用输入‘%’" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-save bigger-110"></i> <b>保存设置</b></asp:LinkButton>
</asp:Content>

