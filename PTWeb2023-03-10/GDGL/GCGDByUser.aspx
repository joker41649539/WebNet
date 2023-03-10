<%@ Page Title="按人员显示工程" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCGDByUser.aspx.cs" Inherits="GDGL_GCGDByUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li>工单管理</li>
            <li><a href="/GDGL/">工程工单</a></li>
            <li class="active"><a href="/GDGL/GCGDByUser.aspx">工程工单按人员</a>
                <asp:HiddenField ID="HiddenField_UserID" runat="server" />
            </li>
        </ul>
    </div>
    <div class="widget-body">
        <div class="page-header">
            <h1>工程工单<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;<a href="/GDGL/GCGDByUser.aspx">工程工单按人员</a></small></h1>
        </div>
        <div class="row col-xs-6">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:ButtonField HeaderText="姓名" CommandName="Select" SortExpression="CName" DataTextField="CName" />
                    <asp:ButtonField HeaderText="电话" CommandName="Select" SortExpression="SSDZ" DataTextField="SSDZ" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="row col-xs-6">
            <%--<asp:ScriptManager ID="ScriptManager_GridView1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="GridView1_UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>--%>
            <asp:GridView ID="GridView2" ClientIDMode="Static" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" OnRowCommand="GridView2_RowCommand" OnRowEditing="GridView2_RowEditing">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" Checked="true" Enabled="true" ID="CheckBox1"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField HeaderText="工程编号" CommandName="Select" SortExpression="SGDH" DataTextField="SGDH" />
                    <asp:ButtonField HeaderText="施工" CommandName="Select" SortExpression="flag" DataTextField="flag" />
                    <asp:ButtonField HeaderText="工程名称" CommandName="Select" SortExpression="GCMC" DataTextField="GCMC" />
<%--                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowHeader="True" ShowInsertButton="True" ShowSelectButton="True"></asp:CommandField>--%>
                </Columns>
            </asp:GridView>
            <asp:LinkButton UseSubmitBehavior="false" Visible="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Save" class="btn btn-info" runat="server" OnClick="LinkButton_Save_Click"><i class="icon-save bigger-110"></i>保  存</asp:LinkButton>
            <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView2 tr").each(function () {
            var mtd = $(this).children("td:eq(2)");
            if (mtd.text() == 0) {
                mtd.html(" <span class=\"label label-success\">布线</span>");
            }
            else if (mtd.text() == 1) {
                mtd.html(" <span class=\"label label-puple\">安装</span>");
            }
        });
    </script>
</asp:Content>

