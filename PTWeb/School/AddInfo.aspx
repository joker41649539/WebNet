<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="AddInfo.aspx.cs" Inherits="School_AddInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .containter {
            width: 320px;
            margin: auto;
        }

        .calender-wrap {
            -webkit-animation: clafade .3s ease;
            -moz-animation: clafade .3s ease;
            animation: clafade .3s ease;
            padding: 5px;
            background: #fff;
            width: 240px;
            box-shadow: 0 5px 10px rgba(0,0,0,0.2);
            border-radius: 4px;
            position: relative;
            font-family: "Microsoft yahei";
            position: absolute;
            z-index: 1000;
        }

        .calender-wrap {
            border: 1px solid #e2e2e2;
        }

            .calender-wrap:after {
                content: '';
                display: inline-block;
                border-left: 7px solid transparent;
                border-right: 7px solid transparent;
                border-bottom: 7px solid #eee;
                border-top: 0;
                border-bottom-color: #d7d7d7;
                position: absolute;
                left: 9px;
                top: -7px;
            }

            .calender-wrap:before {
                content: '';
                display: inline-block;
                border-left: 6px solid transparent;
                border-right: 6px solid transparent;
                border-bottom: 6px solid #ffffff;
                border-top: 0;
                position: absolute;
                left: 10px;
                top: -6px;
                z-index: 10;
            }

        .calender-caption {
            height: 35px;
            border-bottom: 1px solid #ddd;
            z-index: 2;
            background: #eee;
        }

        .calender-content {
            position: relative;
            overflow: hidden;
        }

            .calender-content:after {
                content: '';
                display: block;
                clear: both;
            }

        .calender-cell {
            cursor: pointer;
            float: left;
            width: 14.28571428%;
            height: 35px;
            text-align: center;
            line-height: 35px;
            font-size: 12px;
            color: #000;
            z-index: 1;
            border-bottom: 1px solid #eee;
        }

            .calender-cell:hover {
                background: #eee;
            }

        .calender-caption .calender-cell:hover {
            background: none;
        }

        .calender-cell-dark {
            cursor: no-drop;
            color: #b9b9b9;
        }

        .calender-caption .calender-cell {
            height: 35px;
            line-height: 35px;
            font-size: 13px;
            color: #111;
            font-weight: bold;
        }

        .calender-header {
            text-align: center;
            line-height: 35px;
            text-align: center;
            color: #888;
            padding-bottom: 4px;
            margin-bottom: 1px;
            background: #fff;
            position: relative;
            border-bottom: 1px solid #e6e6e6;
            font-size: 14px;
        }

        #calender-prev, #calender-next {
            text-decoration: none;
            display: block;
            width: 14.2857%;
            height: 35px;
            background: #fff;
            position: absolute;
            left: 0%;
            top: 0px;
            font-family: '宋体';
            font-size: 14px;
            color: #555;
        }

        #calender-prev, #calender-next {
            color: #999;
            font-size: 16px;
        }

            #calender-prev:hover, #calender-next:hover {
                background: #eee;
                border-radius: 5px;
                color: #222;
            }

        #calender-next {
            left: auto;
            right: 0%;
        }

        #calender-year, #calender-mon {
            cursor: pointer;
            padding: 2px 4px;
            border-radius: 3px;
            margin: 0 3px;
        }

            #calender-year:hover, #calender-mon:hover {
                background: #eee;
            }

        .calender-list {
            overflow: hidden;
        }

        .calender-list2, .calender-list3 {
            display: none;
        }

        .calender-year-cell, .calender-mon-cell {
            width: 32.41%;
            float: left;
            border-radius: 4px;
            text-align: center;
            font-size: 12px;
            padding: 15px 0;
            border: 1px solid #fff;
        }

            .calender-year-cell:hover, .calender-mon-cell:hover {
                background: #eee;
                cursor: pointer;
            }

            .calender-cell.active, .calender-year-cell.active, .calender-mon-cell.active {
                background: #23acf1;
                color: #fff;
            }

                .calender-cell.active:hover, .calender-year-cell.active:hover, .calender-mon-cell.active:hover {
                    background: #23acf1;
                    color: #fff;
                }

        .calender-button {
            border-top: 1px solid #eee;
            width: 100%;
            margin-top: -1px;
            padding: 7px 0px 2px 0;
            overflow: hidden;
        }

            .calender-button a {
                display: block;
                text-align: center;
                padding: 0px 15px;
                height: 25px;
                line-height: 25px;
                float: right;
                background: #23acf1;
                color: #fff;
                margin-right: 5px;
                cursor: pointer;
                margin-left: 5px;
                font-size: 12px;
                text-decoration: none;
            }

                .calender-button a:hover {
                    background: #0084c9;
                }

        .calender-wrap.year .calender-list, .calender-wrap.month .calender-list {
            display: none;
        }

        .calender-wrap.year .calender-list2 {
            display: block;
        }

        .calender-wrap.month .calender-list3 {
            display: block;
        }

        @keyframes clafade {
            0% {
                transform: scale(0.95);
                opacity: 0;
            }

            100% {
                transform: scale(1);
                opacity: 1;
            }
        }

        @-webkit-keyframes clafade {
            0% {
                -webkit-transform: scale(0.95);
                opacity: 0;
            }

            100% {
                -webkit-transform: scale(1);
                opacity: 1;
            }
        }
    </style>
    <script type="text/javascript">
        jQuery(function ($) {
            $('#FileUpload_TP').ace_file_input({
                style: 'well',
                btn_choose: '请点击选择图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'small',
                preview_error: function (filename, error_code) {

                }
            });
        });
    </script>

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li class="active"><a href="/School/AddInfo.aspx">学校信息</a></li>
        </ul>
    </div>
    <div class="modal fade" id="GridView_ZY_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>信息添加								<small><i class="icon-double-angle-right"></i>添加新的信息添加                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">信息类别</label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="0">公告信息</asp:ListItem>
                                    <asp:ListItem Value="1" Selected="True">语文作业</asp:ListItem>
                                    <asp:ListItem Value="2">数学作业</asp:ListItem>
                                    <asp:ListItem Value="3">英语作业</asp:ListItem>
                                    <asp:ListItem Value="4">其它作业</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">信息内容</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_ZY_TextBox_NContent" runat="server" placeholder="请输入信息内容“<br>为换行符”" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">开始时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_ZY_TextBox_TSTime" ClientIDMode="Static" runat="server" placeholder="请输入开始时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">结束时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_ZY_TextBox_TETime" ClientIDMode="Static" runat="server" placeholder="请输入结束时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">排序</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_ZY_TextBox_IPX" runat="server" placeholder="请输入排序数，数字越大越靠前" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_ZY_LinkButton1" class="btn btn-info" OnClick="GridView_ZY_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                        &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭                         </button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <div class="vspace-sm"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-header widget-header-flat">
                <h4 class="lighter"><i class="icon-user"></i>信息添加                </h4>
                <asp:DropDownList ID="GridView_ZY_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="NName">信息类别</asp:ListItem>
                    <asp:ListItem Value="NContent">信息内容</asp:ListItem>
                    <asp:ListItem Value="TSTime">开始时间</asp:ListItem>
                    <asp:ListItem Value="TETime">结束时间</asp:ListItem>
                    <asp:ListItem Value="IPX">排序</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_ZY_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_ZY_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_ZY_TJADD_Click" ID="GridView_ZY_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_ZY_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_ZY_Label1" runat="server" Text=""></asp:Label>
                <asp:Label ID="GridView_ZY_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_ZY_LinkButton3" OnClick="GridView_ZY_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_ZY_LinkButton4" OnClick="GridView_ZY_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_ZY" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_ZY_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_ZY_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_ZY_SelectedIndexChanging" OnRowCancelingEdit="GridView_ZY_RowCancelingEdit" OnRowEditing="GridView_ZY_RowEditing" OnRowUpdating="GridView_ZY_RowUpdating" OnRowCommand="GridView_ZY_RowCommand" OnRowDataBound="GridView_ZY_RowDataBound" OnRowDeleting="GridView_ZY_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="NName" SortExpression="NName" HeaderText="信息类别"></asp:BoundField>
                            <asp:BoundField DataField="NContent" SortExpression="NContent" HeaderText="信息内容"></asp:BoundField>
                            <asp:BoundField DataField="TSTime" SortExpression="TSTime" HeaderText="开始时间"></asp:BoundField>
                            <asp:BoundField DataField="TETime" SortExpression="TETime" HeaderText="结束时间"></asp:BoundField>
                            <asp:BoundField DataField="IPX" SortExpression="IPX" HeaderText="排序"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="GridView_ZY_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_ZY_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="GridView_ZY_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_ZY_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_ZY_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_ZY_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_ZY_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_ZY_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_ZY_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_ZY_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton runat="server" PostBackUrl="~/School/AddInfo_Add.aspx"><i class="icon-plus-sign">&nbsp;信息添加添加</i></asp:LinkButton>
                                        <%--                                                                                <asp:LinkButton ID="GridView_ZY_LinkButton_Add" runat="server" CommandName="GridView_ZY_ADD"><i class="icon-plus-sign">&nbsp;信息添加添加</i></asp:LinkButton>--%>
                                    </li>
                                </ul>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
    <script type='text/javascript'>$(function () { $('#GridView_ZY_TextBox_TSTime').datepicker(); });</script>
    <script type='text/javascript'>$(function () { $('#GridView_ZY_TextBox_TETime').datepicker(); });</script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>

</asp:Content>

