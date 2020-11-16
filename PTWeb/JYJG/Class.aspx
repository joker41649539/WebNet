<%@ Page Title="班级管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="JYJG_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="#">教育机构</a></li>
            <li class="active"><a href="#">班级管理</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>教育机构<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;班级管理</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加班级</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">已开课</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">未开课</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <div class="infobox-container" runat="server" id="HtmlGrid">
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        测试111
                    </div>
                </div>
                <div id="write" class="tab-pane">
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
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">班级名称</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入班级名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">上课时间</label>
                                    <div class="col-sm-9">
                                        <div id="task-tab" class="tab-pane active">
                                            <ul id="tasks" class="item-list">
                                                <li class="item-orange clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData1" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期一</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime1" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime2" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>

                                                <li class="item-red clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData2" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期二</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime3" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime4" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>

                                                <li class="item-default clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData3" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期三</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime5" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime6" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>

                                                <li class="item-blue clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData4" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期四</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime7" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime8" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>

                                                <li class="item-grey clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData5" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期五</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime9" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime10" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>

                                                <li class="item-green clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData6" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期六</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime11" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime12" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>

                                                <li class="item-pink clearfix">
                                                    <label class="inline">
                                                        <asp:TextBox runat="server" type="checkbox" ID="CData7" CssClass="ace"></asp:TextBox>
                                                        <span class="lbl">&nbsp;&nbsp;星期日</span>
                                                        <asp:TextBox runat="server" type="text" ID="textboxTime13" Text="14:00" Width="50px"></asp:TextBox>
                                                        -<asp:TextBox runat="server" type="text" ID="textboxTime14" Text="14:00" Width="50px"></asp:TextBox>
                                                    </label>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">开课日期</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox21" runat="server" placeholder="请输入开课日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">截课日期</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="TextBox22" runat="server" placeholder="请输入截课日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="clearfix form-actions">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_JG_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_JG_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                                &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

