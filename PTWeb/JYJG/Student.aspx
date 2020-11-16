<%@ Page Title="学生管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="JYJG_Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/JYJG/Class.aspx">班级管理</a></li>
            <li class="active"><a href="#">学生管理</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>班级管理<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;学生管理</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加学生</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">
                            <asp:Label ID="Label1" runat="server" Text="学生列表"></asp:Label></span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div id="HtmlGrid" runat="server" class="infobox-container">
                            <div class="infobox infobox-red">
                                <div class="infobox-icon"><i class="icon-user"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">学生一(30/40)</span>
                                    <div class="infobox-content"><a href="#"><i class=" icon-calendar"></i>&nbsp;签到</a><a href="#">&nbsp;&nbsp;<i class=" icon-camera"></i>&nbsp;点评</a><a href="#">&nbsp;&nbsp;<i class=" icon-edit"></i>&nbsp;编辑</a></div>
                                </div>
                            </div>
                            <div class="infobox infobox-blue">
                                <div class="infobox-icon"><i class="icon-user"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">学生二(30/40)</span>
                                    <div class="infobox-content"><a href="#"><i class=" icon-calendar"></i>&nbsp;签到</a><a href="#">&nbsp;&nbsp;<i class=" icon-camera"></i>&nbsp;点评</a></div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-user"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">学生三(30/40)</span>
                                    <div class="infobox-content"><a href="#"><i class=" icon-calendar"></i>&nbsp;签到</a><a href="#">&nbsp;&nbsp;<i class=" icon-camera"></i>&nbsp;点评</a></div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-user"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">学生三(30/40)</span>
                                    <div class="infobox-content"><a href="#"><i class=" icon-calendar"></i>&nbsp;签到</a><a href="#">&nbsp;&nbsp;<i class=" icon-camera"></i>&nbsp;点评</a></div>
                                </div>
                            </div>
                            <div class="infobox infobox-green">
                                <div class="infobox-icon"><i class="icon-user"></i></div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">学生三(30/40)</span>
                                    <div class="infobox-content"><a href="#"><i class=" icon-calendar"></i>&nbsp;签到</a><a href="#">&nbsp;&nbsp;<i class=" icon-camera"></i>&nbsp;点评</a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="page-content">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">姓名</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="TextBox_XSMC" runat="server" placeholder="请输入学生姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">性别</label>
                                        <div class="col-sm-9">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2">
                                                <asp:ListItem Selected="True" Value="0">&nbsp;&nbsp;男&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="1">&nbsp;&nbsp;女&nbsp;&nbsp;</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">累计课时</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="TextBox_LJKS" runat="server" placeholder="请输入累计课时(数字),如输入0或不输入则无课时限制" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix form-actions">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_JG_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_JG_LinkButton1_Click" ><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                                    &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

