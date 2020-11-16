<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MSGYD.ASPX.cs" Inherits="Msg_MSGYD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/MSG/MYMSG.ASPX">我的消息</a></li>
            <li class="active">阅读情况
            </li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-folder-close-alt bigger-130"></i>
                        <span class="bigger-110">未阅读</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange  icon-folder-open-alt bigger-130 "></i>
                        <span class="bigger-110">已阅读</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="widget-box transparent">
                            <div class="widget-body">
                                <div class="widget-main no-padding">
                                    <asp:GridView ID="GridView_YD" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_YD_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_YD_SelectedIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="姓名"></asp:BoundField>
                                            <asp:BoundField DataField="LTIME" SortExpression="LTIME" HeaderText="信息时间"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        <div class="page-content">
                            <div class="widget-box transparent">
                                <div class="widget-body">
                                    <div class="widget-main no-padding">
                                        <asp:GridView ID="GridView_YYD" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_YYD_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_YYD_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="CNAME" SortExpression="CNAME" HeaderText="姓名"></asp:BoundField>
                                                <asp:BoundField DataField="LTIME" SortExpression="LTIME" HeaderText="最后阅读"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

