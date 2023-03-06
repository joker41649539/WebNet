<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Bug_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Bug/">Bug处理</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>Bug<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;Bug列表</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <span class="bigger-110">Bug提交</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">待处理</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">处理中</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#finsh">
                        <i class="purple icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">已完成</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <!--待处理开始 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Bug0" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="GridView_Bug0_RowCommand">
                                <Columns>
                                    <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                    <asp:ButtonField DataTextField="Title" HeaderText="标题" CommandName="Select" SortExpression="标题" Text="按钮" />
                                    <asp:BoundField DataField="Urgency" SortExpression="Urgency" HeaderText="紧急"></asp:BoundField>
                                    <asp:BoundField DataField="CreatUserName" SortExpression="UserName" HeaderText="提交人"></asp:BoundField>
                                    <asp:BoundField DataField="CreatDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="UserName" HeaderText="提交日期"></asp:BoundField>
                                    <asp:BoundField DataField="Worker" SortExpression="Worker" HeaderText="处理人"></asp:BoundField>
                                    <asp:BoundField DataField="WorkerDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="WorkerDate" HeaderText="处理日期"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--待处理结束 //-->
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        <!--处理中开始 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Bug2" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="GridView_Bug2_RowCommand">
                                <Columns>
                                    <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                    <asp:ButtonField DataTextField="Title" HeaderText="标题" CommandName="Select" SortExpression="标题" Text="按钮" />
                                    <asp:BoundField DataField="Urgency" SortExpression="Urgency" HeaderText="紧急"></asp:BoundField>
                                    <asp:BoundField DataField="CreatUserName" SortExpression="UserName" HeaderText="提交人"></asp:BoundField>
                                    <asp:BoundField DataField="CreatDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="UserName" HeaderText="提交日期"></asp:BoundField>
                                    <asp:BoundField DataField="Worker" SortExpression="Worker" HeaderText="处理人"></asp:BoundField>
                                    <asp:BoundField DataField="WorkerDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="WorkerDate" HeaderText="处理日期"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--处理中结束 //-->
                    </div>
                </div>
                <div id="finsh" class="tab-pane">
                    <div class="page-content">
                        <!--处理完成开始 //-->
                        <div class="widget-main no-padding">
                            <asp:GridView ID="GridView_Bug1" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="GridView_Bug1_RowCommand">
                                <Columns>
                                    <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                    <asp:ButtonField DataTextField="Title" HeaderText="标题" CommandName="Select" SortExpression="标题" Text="按钮" />
                                    <asp:BoundField DataField="Urgency" SortExpression="Urgency" HeaderText="紧急"></asp:BoundField>
                                    <asp:BoundField DataField="CreatUserName" SortExpression="UserName" HeaderText="提交人"></asp:BoundField>
                                    <asp:BoundField DataField="CreatDate" DataFormatString="{0:yyyy-MM-dd}" SortExpression="UserName" HeaderText="提交日期"></asp:BoundField>
                                    <asp:BoundField DataField="Worker" SortExpression="Worker" HeaderText="处理人"></asp:BoundField>
                                    <asp:BoundField DataField="WorkerDate" DataFormatString="{0:yyyy-MM-dd}"  SortExpression="WorkerDate" HeaderText="处理日期"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!--处理完成结束 //-->
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <!--Bug提交 //-->
                    <div class="page-content">
                        <div class="page-header">
                            <h1>Bug处理<small><i class="icon-double-angle-right"></i>&nbsp;添加新的Bug                                </small></h1>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标题</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_Title" runat="server" placeholder="请输入标题" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">紧急程度</label>
                                    <div class="col-sm-9">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3">
                                            <asp:ListItem Value="0" Selected="True">&nbsp;一般&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="1">&nbsp;着急&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="2">&nbsp;加急&nbsp;</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">描述</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_Remark" TextMode="MultiLine" runat="server" placeholder="请尽量详细填写BUG描述" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix form-actions">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_Bug_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_Bug_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <!--Bug提交结束 //-->
                </div>
            </div>
        </div>
    </div>
<%--    <script src="/assets/js/jquery-2.0.3.min.js"></script>--%>
   
</asp:Content>

