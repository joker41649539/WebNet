<%@ Page Title="" Language="C#" MasterPageFile="~/Question/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Question_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var repeatFlag = false;
        function CheckRepeatClick() {
            if (repeatFlag == false) {
                repeatFlag = true;
                return true;
            }
            else {
                alert("数据处理中，请耐心等待……");
                return false;
            }
        }

    </script>
    <div class="user-profile row height-auto">
        <div class="page-header">
            <h1>信息查询</h1>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">姓名</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入待查询姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">电话号码</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_DHHM" runat="server" placeholder="请输入待查询号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">身份证号码</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ZJHM" runat="server" placeholder="请输入待查询身份证号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">乡镇</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_XZ" runat="server" placeholder="请输入待查询乡镇信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">社区/村</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_SQ" runat="server" placeholder="请输入待查询社区或村信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">居民小组/网格</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_XQ" runat="server" placeholder="请输入待查询居民小组或网格信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">接种剂次</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_JZ" runat="server" placeholder="请输入接种剂次信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <p>
                <asp:LinkButton ID="Button1" class="btn btn-info btn-block" runat="server" OnClick="Button1_Click"><i class="icon-search bigger-110"></i> 信息查询</asp:LinkButton>
            </p>
        </div>
        <div class="widget-body">
            <div class="widget-main no-padding">
                <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowPaging="True" PageSize="<%# Convert.ToInt16(DefaultList) %>" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:ButtonField HeaderText="详情" CommandName="Select" Text="详情" />
                        <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="姓名"></asp:BoundField>
                        <asp:BoundField DataField="ZJHM" SortExpression="ZJHM" HeaderText="证件号码"></asp:BoundField>
                        <asp:BoundField DataField="LXDH" SortExpression="LXDH" HeaderText="联系电话"></asp:BoundField>
                        <asp:BoundField DataField="JZJC" SortExpression="JZJC" HeaderText="接种剂次"></asp:BoundField>
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
                                    &nbsp; 累计：     
                                    <asp:Label ID="Label_SumCount" ClientIDMode="Inherit" runat="server" Text="0"></asp:Label>
                                    条数据
                                </a></li>
                                <li>
                                    <asp:LinkButton ID="GridView1_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="GridView1_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                </li>
                                <li></li>
                            </ul>
                        </div>
                    </PagerTemplate>
                </asp:GridView>
            </div>
        </div>
        <asp:LinkButton ID="Button2" class="btn btn-success btn-block" runat="server" OnClick="Button2_Click"><i class="icon-download bigger-110"></i> 导出查询结果</asp:LinkButton>
    </div>

</asp:Content>

