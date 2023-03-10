<%@ Page Title="教师管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="JYJG_Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">教育机构</a></li>
            <li class="active"><a href="/JYJG/Teacher.aspx">教师管理</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>教育机构<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;教师管理</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加教师</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">在职老师</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">待职老师</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        测试000
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        测试111
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="page-content">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">所属课程</label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">机构简介</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="GridView_JG_TextBox_JGJJ" runat="server" TextMode="MultiLine" placeholder="请输入机构简介" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">LOGO</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="GridView_JG_TextBox_LOGO" runat="server" placeholder="请输入LOGO" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1">联系电话</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="GridView_JG_TextBox_LXDH" runat="server" placeholder="请输入联系电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix form-actions">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_JG_LinkButton1" class="btn btn-info" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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

