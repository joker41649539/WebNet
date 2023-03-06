<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="#">测试模块</a></li>
            <li class="active"><a href="#">测试界面</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="page-header">
            <h1>测试模块<small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;测试界面</small></h1>
        </div>
        <div class="tabbable">
            <ul id="myTab" class="inbox-tabs nav nav-tabs padding-16 tab-size-bigger tab-space-1">
                <li class="pull-right">
                    <a data-toggle="tab" href="#write" class="btn-new-mail">
                        <span class="btn bt1n-small btn-purple no-border">
                            <i class=" icon-envelope bigger-130"></i>
                            <span class="bigger-110">添加信息</span>
                        </span>
                    </a>
                </li>
                <li class="active">
                    <a data-toggle="tab" href="#inbox">
                        <i class="blue icon-inbox bigger-130"></i>
                        <span class="bigger-110">信息一</span>
                    </a>
                </li>
                <li>
                    <a data-toggle="tab" href="#sent">
                        <i class="orange icon-location-arrow bigger-130 "></i>
                        <span class="bigger-110">信息二</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="inbox" class="tab-pane in active">
                    <div class="page-content">
                        <asp:ScriptManager ID="ScriptManager_GridView1" runat="server"></asp:ScriptManager>
                        <div class="modal fade" id="GridView1_ADD" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="page-content">
                                    <div class="page-header">
                                        <h1>测试								<small><i class="icon-double-angle-right"></i>添加新的测试                                </small></h1>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">ID</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="GridView1_TextBox_ID" runat="server" placeholder="请输入ID" class="col-xs-12 col-sm-12"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">标题</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox ID="GridView1_TextBox_Title" runat="server" placeholder="请输入标题" class="col-xs-12 col-sm-12"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix form-actions">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView1_LinkButton1" class="btn btn-info" OnClick="GridView1_LinkButton1_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
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
                            <asp:UpdatePanel ID="GridView1_UpdatePanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="widget-box transparent">
                                        <div class="widget-body">
                                            <div class="widget-main no-padding">
                                                <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                                                    <Columns>
                                                        <asp:ButtonField DataTextField="ID" HeaderText="ID" CommandName="Select" SortExpression="ID" Text="按钮" />
                                                        <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID"></asp:BoundField>
                                                        <asp:BoundField DataField="Title" SortExpression="Title" HeaderText="标题"></asp:BoundField>
                                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="GridView1_LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="&lt;i class='icon-pencil bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="GridView1_LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="&lt;i class='icon-undo bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="GridView1_LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="&lt;i class='icon-edit bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="GridView1_LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="&lt;i class='icon-remove-sign bigger-130'&gt;&lt;/i&gt;"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                                                </a></li>
                                                                <li>
                                                                    <asp:LinkButton ID="GridView1_LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"><i class="icon-angle-right"></i></asp:LinkButton>
                                                                </li>
                                                                <li>
                                                                    <asp:LinkButton ID="GridView1_LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"> <i class="icon-double-angle-right"></i></asp:LinkButton>
                                                                </li>
                                                            </ul>
                                                            <ul class="pagination">
                                                                <li>
                                                                    <asp:LinkButton ID="GridView1_LinkButton_Add" runat="server" CommandName="GridView1_ADD"><i class="icon-plus-sign">&nbsp;测试添加</i></asp:LinkButton>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </PagerTemplate>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- /widget-box -->
                        </div>
                    </div>
                </div>
                <div id="sent" class="tab-pane">
                    <div class="page-content">
                        111
                    </div>
                </div>
                <div id="write" class="tab-pane">
                    <div class="page-content">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-sm" style="padding: 10px;">
                                    <div id="signature" style="border-style: dashed; border-width: 1px;"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <button type="button" class="btn btn-success btn-block" data-toggle="modal"
                                        data-target="#saveConfirmModel">
                                        保存</button>
                                </div>
                                <div class="col-sm">
                                    <button id="clearBtn" type="button" class="btn btn-danger btn-block">清除</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <%-- <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.0/js/bootstrap.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jSignature/2.1.3/jSignature.min.js"></script>
    <script>
        $(document).ready(function () {
            var arguments = {
                width: '100%',
                height: '300px',
                signatureLine: false,
                lineWidth: '5'
            };
            $('#signature').jSignature(arguments);
            // 清除按钮
            $('#clearBtn').click(function () {
                $('#signature').jSignature('reset');
            });
            // 保存按钮
            $('#save').click(function () {
                var dataPair = $('#signature').jSignature('getData', 'image');
                var signatureImage = new Image();
                signatureImage.src = 'data:' + dataPair[0] + ',' + dataPair[1];
                signatureImage.image = dataPair[1];

                //$.ajax({
                //    url: '/saveSignature.ashx',
                //    contentType: 'application/json; charset=utf-8',
                //    data: {
                //        signatureData: signatureImage.image
                //    },
                //    type: 'post',
                //    cache: false,
                //    success: function (result) {
                //        if (result) {
                //            if (result.status === 200) {
                //                alert('上传成功');
                //            } else {
                //                alert(result.message);
                //            }
                //        }
                //    }
                //});
            });
        });
    </script>

</asp:Content>


