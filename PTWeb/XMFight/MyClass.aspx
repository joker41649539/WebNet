﻿<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="MyClass.aspx.cs" Inherits="XMFight_MyClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="alert alert-block alert-success" runat="server" visible="false" id="Div_AllMsg">
        <h5>公告消息</h5>
        <h6>明天放假休息</h6>
    </div>
    <div class="btn-group" runat="server" id="Div_Students">
        <%-- <a href="#" class="btn btn-sm btn-primary">陆博文</a>
        <a href="#" class="btn btn-sm btn-pink">陆博语</a>--%>
    </div>
    <div class="row">
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid4">
                <span class="green">
                    <i class="icon-twitter-sign icon-2x green"></i>
                    &nbsp; 剩余
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label_Sum" runat="server" Text="0"></asp:Label>
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
                    <asp:Label ID="Label_KG" runat="server" Text="0"></asp:Label>
                    课时</h4>
            </div>
            <div class="grid4">
                <span class="red">
                    <i class="icon-twitter-sign icon-2x red"></i>
                    &nbsp; 储备金
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label_CBJ" runat="server" Text="0"></asp:Label>
                    元</h4>
            </div>
        </div>
        <div class="hr hr8 hr-double"></div>
        <div class="content">
            <h4>课程有效截止日期：<asp:Label ID="Label_KCYXQZ" runat="server" Text="2022-11-01"></asp:Label></h4>
        </div>
        <div class="hr hr8 hr-double"></div>
        <div class="center" runat="server" id="Div_ClassTime">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                <asp:ListItem Value="14">&nbsp;&nbsp;周二 15:00&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="15">&nbsp;&nbsp;周四 15:00&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="16">&nbsp;&nbsp;周六 10:00&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="17">&nbsp;&nbsp;周7 10:00&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="18">&nbsp;&nbsp;周8 10:00&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="19">&nbsp;&nbsp;周9 10:00&nbsp;</asp:ListItem>
            </asp:CheckBoxList>
        </div>

        <div class="hr hr8 hr-double"></div>
        <div class="clearfix" runat="server" id="Div_MyClassTime">
            <div class="grid2">
                <span class="blue">
                    <i class="icon-twitter-sign icon-2x blue"></i>
                    &nbsp; 暂未安排课程
                </span>
            </div>
        </div>
        <asp:HiddenField ID="HiddenField_ListMaxID" runat="server" />
        <div class="page-content" runat="server" id="Vied_Text" visible="false">
            <div class="input-group">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入视频网址" class="form-control search-query"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:LinkButton OnClick="LinkButton2_Click" ID="LinkButton2" class="btn btn-purple btn-sm" runat="server">保存<i class="icon-save icon-on-right bigger-110"></i></asp:LinkButton>
                </span>
            </div>
        </div>
        <div class="hr hr8 hr-double"></div>
        <h5>&nbsp;&nbsp;最近100次上课记录</h5>
        <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID,VidoUrl" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="CTime" DataFormatString="{0:yyyy-MM-dd dddd HH:mm}" SortExpression="CTime" HeaderText="日期"></asp:BoundField>
                <asp:BoundField DataField="iFlag" SortExpression="iFlag" HeaderText="状态"></asp:BoundField>
                <asp:BoundField DataField="iCount" SortExpression="iCount" DataFormatString="{0:F0}" HeaderText="课时"></asp:BoundField>
                <asp:ButtonField HeaderText="课程情况" DataTextField="NewText" CommandName="select"></asp:ButtonField>
                <%--<asp:TemplateField HeaderText="课程情况">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" Text='<%# Eval("NewText") %>' NavigateUrl='<%# Eval("VidoUrl") %>' ID="HyperLink1"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <PagerTemplate>
                <div>
                    <ul class="pagination">
                        <li>
                            <asp:LinkButton ID="GridView1_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="GridView1_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                        </li>
                        <li class="active"><a href="#">
                            <asp:Label ID="GridView1_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                            /                                                   
                            <asp:Label ID="GridView1_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                        </a></li>
                        <li>
                            <asp:LinkButton ID="GridView1_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="GridView1_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </PagerTemplate>
        </asp:GridView>
        <%--<div class="grid3">
            <span class="grey">
                <i class="icon-pinterest-sign icon-2x red"></i>
                &nbsp; pins
            </span>
            <h4 class="bigger pull-right">1,050</h4>
        </div>--%>
    </div>
    <%-- <h3>课程安排</h3>
    <hr />
    <div class="row">--%>
    <div runat="server" id="Div_PhotoList" visible="false"></div>
    <%--</div>
    <hr />--%>
    <script src="/assets/js/jquery-2.0.3.min.js"></script>
    <script>
        // 字符替换
        $("#GridView1 tr").each(function () {
            var mtd = $(this).children("td:eq(1)");
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

