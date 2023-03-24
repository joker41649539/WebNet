<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCGDAdd.aspx.cs" Inherits="GDGL_GCGDAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        ///打开维修内容选择框
        function OpenMapEdit() {
            $("#MapEdit").modal('show');
            return false
        };
        /// 数据前端检测
        function onCheck() {
            var rValue = true;
            var i = 0;
            var ErrMsg = "";
            if (document.getElementById('TextBox1').value.length <= 0) {
                i++;
                ErrMsg += i + "、地点名称必须填写。<br/>";
            }
            if (document.getElementById('TextBox2').value.length <= 0) {
                i++;
                ErrMsg += i + "、地点位置信息必须填写。<br/>";
            }
            if (document.getElementById('TextBox3').value.length <= 0) {
                i++;
                ErrMsg += i + "、经纬度信息必须填写。<br/>";
            }
            if (ErrMsg.length > 0) {
                dialog = jqueryAlert({ 'content': ErrMsg });
                rValue = false;
            }
            return rValue;
        }
    </script>
    <div class="modal fade" id="MapEdit" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog ">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">地点名称</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入内部打卡名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">地点位置信息</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入地点位置信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">经纬度信息</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入腾讯地图的经纬度信息数据" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="height: 70px">
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button2" OnClientClick="return onCheck()" OnClick="Button2_Click" class="btn btn-success" runat="server" Text="确 定" />
                    <button type="button" class="btn btn-info"
                        data-dismiss="modal">
                        取&nbsp;&nbsp;消
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/GDGL/">工单管理</a></li>
            <li class="active">添加工程工单</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>工程工单								<small><i class="icon-double-angle-right"></i>添加新的工程工单                                </small></h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">工程编号</label>
            <div class="col-sm-9">
                <h2>
                    <asp:Label ID="Label_GCBH" runat="server" Text="等待生成编号"></asp:Label></h2>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">手工编号</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_SGBH" runat="server" placeholder="请输入手工编号" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">工程名称</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_GCMC" runat="server" placeholder="请输入工程名称" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">工程地点</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_gcdd" runat="server" placeholder="请输入工程地点" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">甲方负责人</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_FZR" runat="server" placeholder="请输入甲方负责人" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">负责人电话</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_DH" runat="server" placeholder="甲方负责人电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                <asp:HiddenField ID="HiddenField_UserID" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">要求说明</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_YQSM" runat="server" TextMode="MultiLine" placeholder="请输入施工要求说明" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="col-md-offset-3 col-md-9">
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton3" class="btn btn-danger" runat="server" OnClick="LinkButton3_Click"><i class=" icon-barcode bigger-130"></i> 上一单</asp:LinkButton>
        &nbsp; &nbsp;                        
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_YZ_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_YZ_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
        &nbsp; &nbsp;                        
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-danger" runat="server" OnClick="LinkButton1_Click"><i class=" icon-barcode bigger-130"></i> 添加工程明细</asp:LinkButton>
        &nbsp; &nbsp;                        
        <asp:Button ID="Button_Del" runat="server" Text="整单删除" class="btn btn-warning" OnClick="Button_Del_Click" />
        &nbsp; &nbsp;                        
        <asp:Button ID="Button_DelMX" runat="server" Text="明细删除" class="btn btn-default" OnClick="Button_DelMX_Click" />
        &nbsp; &nbsp;                        
       <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton2" class="btn btn-danger" runat="server" OnClick="LinkButton2_Click"><i class=" icon-barcode bigger-130"></i> 下一单</asp:LinkButton>
        &nbsp; &nbsp;                        
       <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton4" class="btn btn-info" runat="server" OnClick="LinkButton4_Click"><i class=" icon-barcode bigger-130"></i> 查看报表</asp:LinkButton>
        &nbsp; &nbsp;                        
       <asp:LinkButton UseSubmitBehavior="false" OnClientClick="return OpenMapEdit()" ID="LinkButton5" class="btn btn-success" runat="server"><i class="icon-globe"></i> 坐标信息</asp:LinkButton>
    </div>

    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-info" />&nbsp;
        <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="导入Excel" OnClick="Button1_Click" />
    </div>
    <div class="widget-body">
        <div class="widget-main no-padding infobox-container" runat="server" id="Dtv_HTML">
            <div class="infobox infobox-green">
                <div class="infobox-icon">
                    <i class="icon-check"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">项目累计积分</span>
                    <div class="infobox-data-number">
                        <asp:Label ID="Label_SumFS" runat="server" Text="0"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="infobox infobox-blue2">
                <div class="infobox-icon">
                    <i class="icon-check-empty"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">已完成积分</span>
                    <div class="infobox-data-number">
                        <asp:HyperLink ID="Label_YAZFS" runat="server">HyperLink</asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="infobox infobox-red">
                <div class="infobox-icon">
                    <i class="icon-check-empty"></i>
                </div>
                <div class="infobox-data">
                    <span class="infobox-data-number">待完成积分</span>
                    <div class="infobox-data-number">
                        <asp:HyperLink ID="Label_WAZFS" runat="server">HyperLink</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="col-sm-12">
        <div class="widget-box transparent">
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <asp:ScriptManager ID="ScriptManager_GridView1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="GridView1_UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:GridView ID="GridView_GDAdd" ClientIDMode="Static" runat="server" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" DataKeyNames="ID" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                                <Columns>
                                    <asp:BoundField DataField="AZWZ" SortExpression="AZWZ" HeaderText="安装位置"></asp:BoundField>
                                    <asp:BoundField DataField="SBBH" SortExpression="SBBH" HeaderText="设备编号"></asp:BoundField>
                                    <asp:BoundField DataField="SBMC" SortExpression="SBMC" HeaderText="设备名称"></asp:BoundField>
                                    <asp:BoundField DataField="SBPP" SortExpression="SBPP" HeaderText="设备品牌"></asp:BoundField>
                                    <asp:BoundField DataField="SBXH" SortExpression="SBXH" HeaderText="设备型号"></asp:BoundField>
                                    <asp:BoundField DataField="JLDW" SortExpression="JLDW" HeaderText="计量单位"></asp:BoundField>
                                    <asp:BoundField DataField="SL" SortExpression="SL" HeaderText="数量"></asp:BoundField>
                                    <asp:BoundField DataField="YQSM" SortExpression="YQSM" HeaderText="说明"></asp:BoundField>
                                    <asp:BoundField DataField="FS" SortExpression="FS" HeaderText="布线分数"></asp:BoundField>
                                    <asp:BoundField DataField="YBX" ReadOnly="true" SortExpression="YBX" HeaderText="布线已完成"></asp:BoundField>
                                    <asp:BoundField DataField="BXMX" ReadOnly="true" SortExpression="YBX" HeaderText="布线明细"></asp:BoundField>
                                    <asp:BoundField DataField="AZFS" SortExpression="FS" HeaderText="安装分数"></asp:BoundField>
                                    <asp:BoundField DataField="YAZ" ReadOnly="true" SortExpression="YAZ" HeaderText="安装已完成"></asp:BoundField>
                                    <asp:BoundField DataField="AZMX" ReadOnly="true" SortExpression="YAZ" HeaderText="安装明细"></asp:BoundField>
                                    <%--                            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/GDGL/GCMXADD.ASPX?MXID={0}" DataTextField="ID" Text="修改" HeaderText="修改" DataTextFormatString="修改"></asp:HyperLinkField>
                            <asp:ButtonField DataTextField="ID" DataTextFormatString="删除" HeaderText="删除" CommandName="Delete" SortExpression="ID" Text="按钮" />--%>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <!-- /widget-box -->
    </div>
</asp:Content>

