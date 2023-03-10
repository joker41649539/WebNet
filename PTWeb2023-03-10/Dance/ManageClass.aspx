<%@ Page Title="" Language="C#" MasterPageFile="~/Dance/MasterPage.master" AutoEventWireup="true" CodeFile="ManageClass.aspx.cs" Inherits="Dance_ManageClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="modal fade" id="GridView_Class_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>课程管理								<small><i class="icon-double-angle-right"></i>添加新的课程管理                                </small></h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">课程名</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_ClassName" runat="server" placeholder="请输入课程名" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">老师</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_ClassTeacher" runat="server" placeholder="请输入老师" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">开始时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_ClassTimeStart" runat="server" placeholder="请输入开始时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">结束时间</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_ClassTimeEnd" runat="server" placeholder="请输入结束时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">星期</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_ClassWeek" runat="server" placeholder="请输入星期" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">最多人数</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_MaxMen" runat="server" placeholder="请输入最多人数" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">状态</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_Flag" runat="server" placeholder="请输入状态" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">排序</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_PX" runat="server" placeholder="请输入排序" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">学校</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="GridView_Class_TextBox_School" runat="server" placeholder="请输入学校" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_Class_LinkButton1" class="btn btn-info" OnClick="GridView_Class_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                <h4 class="lighter"><i class="icon-user"></i>课程管理                </h4>
                <asp:DropDownList ID="GridView_Class_DropDownList1" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="ClassName">课程名</asp:ListItem>
                    <asp:ListItem Value="ClassTeacher">老师</asp:ListItem>
                    <asp:ListItem Value="ClassTimeStart">开始时间</asp:ListItem>
                    <asp:ListItem Value="ClassTimeEnd">结束时间</asp:ListItem>
                    <asp:ListItem Value="ClassWeek">星期</asp:ListItem>
                    <asp:ListItem Value="MaxMen">最多人数</asp:ListItem>
                    <asp:ListItem Value="Flag">状态</asp:ListItem>
                    <asp:ListItem Value="PX">排序</asp:ListItem>
                    <asp:ListItem Value="School">学校</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="GridView_Class_DropDownList_SF" class="btn dropdown-toggle btn-sm  btn-white" runat="server" ClientIDMode="Static">
                    <asp:ListItem Value="=">等于</asp:ListItem>
                    <asp:ListItem Value="LIKE">包含</asp:ListItem>
                    <asp:ListItem Value="<>">不等于</asp:ListItem>
                    <asp:ListItem Value=">">大于</asp:ListItem>
                    <asp:ListItem Value="<">小于</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="GridView_Class_TextBox_CXTJ" placeholder="条件内容" runat="server"></asp:TextBox>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" OnClick="GridView_Class_TJADD_Click" ID="GridView_Class_TJADD"><i class="icon-plus-sign">&nbsp;条件添加</i></asp:LinkButton>
                <div class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a></div>
            </div>
            <div id="GridView_Class_alerts_tj" runat="server" class="alert alert-success" visible="false">
                <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
                <asp:Label ID="GridView_Class_Label1" runat="server" Text=""></asp:Label><asp:Label ID="GridView_Class_Label_tj" runat="server" Text="" Visible="false"></asp:Label>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Class_LinkButton3" OnClick="GridView_Class_LinkButton3_Click"><i class="icon-remove">&nbsp;清除条件</i></asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-white btn-sm" ID="GridView_Class_LinkButton4" OnClick="GridView_Class_LinkButton4_Click"><i class="icon-search">&nbsp;查 询</i></asp:LinkButton>
            </div>
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:GridView ID="GridView_Class" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView_Class_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView_Class_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView_Class_SelectedIndexChanging" OnRowCancelingEdit="GridView_Class_RowCancelingEdit" OnRowEditing="GridView_Class_RowEditing" OnRowUpdating="GridView_Class_RowUpdating" OnRowCommand="GridView_Class_RowCommand" OnRowDataBound="GridView_Class_RowDataBound" OnRowDeleting="GridView_Class_RowDeleting">
                        <Columns>
                            <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                            <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="课程名"></asp:BoundField>
                            <asp:BoundField DataField="ClassTeacher" SortExpression="ClassTeacher" HeaderText="老师"></asp:BoundField>
                            <asp:BoundField DataField="STime" SortExpression="ClassTimeStart" DataFormatString="{0:HH:mm}" HeaderText="开始时间"></asp:BoundField>
                            <asp:BoundField DataField="ETime" SortExpression="ClassTimeEnd" DataFormatString="{0:HH:mm}" HeaderText="结束时间"></asp:BoundField>
                            <asp:BoundField DataField="ClassWeek" SortExpression="ClassWeek" HeaderText="星期"></asp:BoundField>
                            <asp:BoundField DataField="MaxMen" SortExpression="MaxMen" HeaderText="最多人数"></asp:BoundField>
                            <asp:BoundField DataField="Flag" SortExpression="Flag" HeaderText="状态"></asp:BoundField>
                            <asp:BoundField DataField="PX" SortExpression="PX" HeaderText="排序"></asp:BoundField>
                            <asp:BoundField DataField="School" SortExpression="School" HeaderText="学校"></asp:BoundField>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="GridView_Class_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Class_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="GridView_Class_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="GridView_Class_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Class_LinkButton1" runat="server" CommandArgument="First" CommandName="Page"><i class="icon-double-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Class_LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page"><i class="icon-angle-left"></i></asp:LinkButton>
                                    </li>
                                    <li class="active"><a href="#">
                                        <asp:Label ID="GridView_Class_LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                        /                                                   
                                        <asp:Label ID="GridView_Class_LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                    </a></li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Class_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="GridView_Class_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="pagination">
                                    <li>
                                        <asp:LinkButton ID="GridView_Class_LinkButton_Add" runat="server" CommandName="GridView_Class_ADD"><i class="icon-plus-sign">&nbsp;课程管理添加</i></asp:LinkButton>
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
    <div class="row" style="height: 1100px;">
    </div>
</asp:Content>

