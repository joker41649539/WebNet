<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Partner_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Partner/">协同人员管理</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1><a href="/Partner/">协同人员管理</a><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;协同人员列表</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a href="/Partner/PartnerAdd.ASPX" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加协同人员</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#finsh">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">已审核</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">待审核</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="finsh" class="tab-pane in active">
                    <div class="page-content">
                        <!--已审核开始 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Partner3" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDeleting="GridView_Partner3_RowDeleting" OnRowDataBound="GridView_Partner3_RowDataBound" OnDataBinding="GridView_Partner3_DataBinding">
                                <Columns>
                                    <asp:HyperLinkField DataTextField="CName" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Partner/PartnerInfo.aspx?id={0}" HeaderText="姓名"></asp:HyperLinkField>
                                    <asp:TemplateField HeaderText="电话">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Text='<%# Eval("ssdz") %>' NavigateUrl='<%#"tel:"+Eval("ssdz") %>' ID="HyperLink1"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="zjhm" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" SortExpression="zjhm" HeaderText="证件号码"></asp:BoundField>
                                    <asp:BoundField DataField="CTime" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" DataFormatString="{0:yyyy-MM-dd}" SortExpression="CTime" HeaderText="提交日期"></asp:BoundField>
                                    <asp:BoundField DataField="LTime" DataFormatString="{0:yyyy-MM-dd}" SortExpression="LTime" HeaderText="更新日期"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--已审核结束 //-->
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        <!--待审核开始 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Partner2" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDeleting="GridView_Partner2_RowDeleting">
                                <Columns>
                                    <asp:HyperLinkField DataTextField="CName" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Partner/PartnerInfo.aspx?id={0}" HeaderText="姓名"></asp:HyperLinkField>
                                    <asp:TemplateField HeaderText="电话">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Text='<%# Eval("ssdz") %>' NavigateUrl='<%#"tel:"+Eval("ssdz") %>' ID="HyperLink1"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="zjhm" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" SortExpression="zjhm" HeaderText="证件号码"></asp:BoundField>
                                    <asp:BoundField DataField="CTime" ItemStyle-CssClass="hidden-480" HeaderStyle-CssClass="hidden-480" DataFormatString="{0:yyyy-MM-dd}" SortExpression="CTime" HeaderText="提交日期"></asp:BoundField>
                                    <asp:BoundField DataField="LTime" DataFormatString="{0:yyyy-MM-dd}" SortExpression="LTime" HeaderText="更新日期"></asp:BoundField>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" OnClientClick="javascript:return confirm('你确认要删除吗?')" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="hidden-480" />
                                        <HeaderStyle CssClass="hidden-480" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--待审核结束 //-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

