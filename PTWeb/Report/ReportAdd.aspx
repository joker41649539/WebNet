<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportAdd.aspx.cs" Inherits="Report_ReportAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/Report/">工作汇报</a></li>
            <li class="active">填写工作汇报</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>工作汇报								<small><i class="icon-double-angle-right"></i>&nbsp;填写工作汇报                               </small></h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label8" class="col-sm-3 control-label no-padding-right" for="form-field-1">汇报单号：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_No" runat="server" Text="HBD2020-12-01-0001" Font-Bold="true"></asp:Label>
                <asp:Label ID="Label_Flag" runat="server" Text="待提交" Font-Bold="true" ForeColor="Green"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label9" class="col-sm-3 control-label no-padding-right" for="form-field-1">填报人：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_CName" runat="server" Text="填报人" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报告类型：</label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>现场勘察</asp:ListItem>
                <asp:ListItem>方案论证</asp:ListItem>
                <asp:ListItem>质检查验</asp:ListItem>
                <asp:ListItem>甲方验收</asp:ListItem>
                <asp:ListItem>公安验收</asp:ListItem>
                <asp:ListItem>参加会议</asp:ListItem>
                <asp:ListItem>参加学习</asp:ListItem>
                <asp:ListItem>投标情况</asp:ListItem>
                <asp:ListItem>其他</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="page-content" runat="server" id="AddXCKC">
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label2" class="col-sm-3 control-label no-padding-right" for="form-field-1">勘察地点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_KCDD" ClientIDMode="Static" runat="server" placeholder="请填写勘察地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label1" class="col-sm-3 control-label no-padding-right" for="form-field-1">勘察日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_KCRQ" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label3" class="col-sm-3 control-label no-padding-right" for="form-field-1">现场勘查概要说明：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入现场勘查概要说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label4" class="col-sm-3 control-label no-padding-right" for="form-field-1">现场照片：</label>
                <div class="col-sm-9">
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label5" class="col-sm-3 control-label no-padding-right" for="form-field-1">审核阅读：</label>
                <div class="col-sm-9">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3">
                        <asp:ListItem>运管部经理</asp:ListItem>
                        <asp:ListItem>工程部经理</asp:ListItem>
                        <asp:ListItem>总经理</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <!-- 时间轴循环开始 //-->
            <div class="timeline-container">
                <!-- 日期循环开始 //-->
                <div class="timeline-label">
                    <span class="label label-primary arrowed-in-right label-lg">
                        <b>2021-01-13</b>
                    </span>
                </div>
                <div class="timeline-items">
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">16:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">陆总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常不好，重来
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- 日期循环结束 //-->
                <!-- 日期循环开始 //-->
                <div class="timeline-label">
                    <span class="label label-primary arrowed-in-right label-lg">
                        <b>2021-01-13</b>
                    </span>
                </div>
                <div class="timeline-items">
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">16:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">陆总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常不好，重来
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="timeline-item clearfix">
                        <div class="timeline-info">
                            <span class="label label-info label-sm">18:22</span>
                        </div>

                        <div class="widget-box transparent">
                            <div class="widget-header widget-header-small">
                                <h5 class="smaller">
                                    <a href="#" class="blue">鹏总</a>
                                </h5>
                            </div>
                            <div class="widget-body">
                                <div class="widget-main">
                                    非常好。
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- 日期循环结束 //-->
            </div>
            <!-- 时间轴循环结束 //-->
            <div class="col-xs-12">
                <div class="form-group">
                    <label runat="server" id="Label6" class="col-sm-3 control-label no-padding-right" for="form-field-1">审阅意见：</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入您的审阅意见" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="hr-10"></div>
    <div class="btn-group">
        <%--        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_YZ_LinkButton1" class="btn btn-info" runat="server"><i class="icon-save bigger-110"></i> 保  存</asp:LinkButton>--%>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Next" class="btn btn-success" runat="server"><i class="icon-ok bigger-110"></i> 提  交</asp:LinkButton>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Return" class="btn btn-pink" runat="server"><i class="icon-undo bigger-110"></i> 退  回</asp:LinkButton>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Del" class="btn btn-danger" runat="server"> <i class=" icon-trash bigger-110"></i> 删  除</asp:LinkButton>
    </div>

    <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript">
        $(function () { $('#TextBox_KCRQ').datepicker(); });
    </script>

</asp:Content>

