<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReimbursementAdd.aspx.cs" Inherits="CWGL_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input').ace_file_input({
                style: 'well',
                btn_choose: '请点击拍照',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large'
            }).on('change', function () {
                CreateInput();
            });
        });

        var i = 0;// 用于计算ID
        function CreateInput() {
            var input = document.createElement("input");
            var MaxCount = 3; // 最大数量
            i++
            input.type = "file";
            input.capture = "camera";// 照相机
            input.accept = "image/*";// 文件类型
            input.name = "AddImg";
            input.id = "id-input" + i;
            document.getElementById("showText").appendChild(input);
            jQuery(function ($) {
                $('#' + input.id + '').ace_file_input({
                    style: 'well',
                    btn_choose: '请点击拍照',
                    btn_change: null,
                    no_icon: 'icon-cloud-upload',
                    droppable: true,
                    thumbnail: 'large'
                }).on('change', function () {
                    if (i < MaxCount - 1) { //达到最大数量后不添加
                        CreateInput();//图片选择后，自动添加
                    }
                });
            });
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/CWGL/">财务管理</a></li>
            <li class="active">报销填报</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>报销单								<small><i class="icon-double-angle-right"></i>&nbsp;报销填报                               </small></h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label8" class="col-sm-3 control-label no-padding-right" for="form-field-1">报销单号：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_No" runat="server" Text="BX2020-12-01-0001" Font-Bold="true"></asp:Label>
                <asp:Label ID="Label_Flag" runat="server" Text="待提交" Font-Bold="true" ForeColor="Green"></asp:Label>
                <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label9" class="col-sm-3 control-label no-padding-right" for="form-field-1">报销人：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_CName" runat="server" Text="报销人" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label17" class="col-sm-3 control-label no-padding-right" for="form-field-1">收款人：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Cname" ClientIDMode="Static" runat="server" placeholder="请输入收款人" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报销类型：</label>
            &nbsp;&nbsp;
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" class="ace" RepeatColumns="3" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">&nbsp;工程施工&nbsp;</asp:ListItem>
                <asp:ListItem Value="1">&nbsp;维&nbsp;&nbsp;修&nbsp;</asp:ListItem>
                <asp:ListItem Value="2">&nbsp;其&nbsp;&nbsp;它&nbsp;</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label16" class="col-sm-3 control-label no-padding-right" for="form-field-1">总报销金额：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_Sumje" runat="server" Text="0" Font-Bold="true" ForeColor="Red"></asp:Label>
                元
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="LabelRadioText" class="col-sm-3 control-label no-padding-right" for="form-field-1">工程编号：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Remark" runat="server" placeholder="请输入内容" class="col-xs-12 col-sm-12" Width="100%" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton2" class="btn btn-mini btn-success" runat="server" OnClick="LinkButton2_Click1"><b>保&nbsp;&nbsp;存</b></asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="col-xs-12" runat="server" id="ReturnMsg" />
    <div class="col-xs-12" runat="server" id="WellList" />
    <div class="page-content" runat="server" id="AddHtml">
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label1" class="col-sm-3 control-label no-padding-right" for="form-field-1">开支项目：</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True">交通费</asp:ListItem>
                        <asp:ListItem>补助</asp:ListItem>
                        <asp:ListItem>采购物资</asp:ListItem>
                        <asp:ListItem>运输费</asp:ListItem>
                        <asp:ListItem>租脚手架</asp:ListItem>
                        <asp:ListItem>开槽费</asp:ListItem>
                        <asp:ListItem>开孔费</asp:ListItem>
                        <asp:ListItem>停车费</asp:ListItem>
                        <asp:ListItem>加油费</asp:ListItem>
                        <asp:ListItem>招待费</asp:ListItem>
                        <asp:ListItem>办公费</asp:ListItem>
                        <asp:ListItem>福利费</asp:ListItem>
                        <asp:ListItem>行政综合</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label2" class="col-sm-3 control-label no-padding-right" for="form-field-1">发生日期：</label>
                <div class="col-xs-9">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxSTime" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" data-date-format="yyyy-mm-dd" class="form-control date-picker"></asp:TextBox>
                        <span class="input-group-addon">
                            <i class="icon-calendar bigger-110"></i>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TBreakfirst">
            <div class="form-group">
                <label runat="server" id="Label10" class="col-sm-3 control-label no-padding-right" for="form-field-1">早餐补助：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Breakfirst" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TZC">
            <div class="form-group">
                <label runat="server" id="Label11" class="col-sm-3 control-label no-padding-right" for="form-field-1">中餐补助：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ZC" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TWC">
            <div class="form-group">
                <label runat="server" id="Label12" class="col-sm-3 control-label no-padding-right" for="form-field-1">晚餐补助：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_WC" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TZS">
            <div class="form-group">
                <label runat="server" id="Label13" class="col-sm-3 control-label no-padding-right" for="form-field-1">单人住宿补助：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ZS" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TDRZS">
            <div class="form-group">
                <label runat="server" id="Label14" class="col-sm-3 control-label no-padding-right" for="form-field-1">多人住宿补助：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_DRZS" ClientIDMode="Static" runat="server" class="col-xs-12 col-sm-12"></asp:TextBox>
                    <asp:TextBox ID="TextBox_TXR" ClientIDMode="Static" runat="server" placeholder="请输入同行人姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TMC">
            <div class="form-group">
                <label runat="server" id="Label15" class="col-sm-3 control-label no-padding-right" for="form-field-1">名称：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_MC" ClientIDMode="Static" runat="server" placeholder="请输入货物名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TCFDD">
            <div class="form-group">
                <label runat="server" id="Label3" class="col-sm-3 control-label no-padding-right" for="form-field-1">出发地点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Becity" ClientIDMode="Static" runat="server" placeholder="请输入出发地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12" runat="server" id="TDDDD">
            <div class="form-group">
                <label runat="server" id="Label4" class="col-sm-3 control-label no-padding-right" for="form-field-1">到达地点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Arrival" ClientIDMode="Static" runat="server" placeholder="请输入到达地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label5" class="col-sm-3 control-label no-padding-right" for="form-field-1">总金额：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Num" ClientIDMode="Static" runat="server" placeholder="请输入报销金额" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label6" class="col-sm-3 control-label no-padding-right" for="form-field-1">备注说明：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark2" ClientIDMode="Static" runat="server" placeholder="请输入备注说明" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label7" class="col-sm-3 control-label no-padding-right" for="form-field-1">上传图片：</label>
                <div class="col-sm-9 widget-main" id="showText">
                    <input name="AddImg" capture="camera" accept="image/*" type="file" id="id-input" />
                </div>
                <%--                <div class="col-sm-9">
                    <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
                    <asp:FileUpload ID="FileUpload2" runat="server" accept="image/*" />
                    <asp:FileUpload ID="FileUpload3" runat="server" accept="image/*" />
                </div>--%>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <div runat="server" id="UpdateImages"></div>
                <%--  <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-mini btn-success" runat="server" OnClick="LinkButton1_Click1"><b>保&nbsp;&nbsp;存</b></asp:LinkButton>--%>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-mini" runat="server" OnClick="LinkButton1_Click1"><b>添加下一条</b></asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="btn-group">
        <%--        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_YZ_LinkButton1" class="btn btn-info" runat="server"><i class="icon-save bigger-110"></i> 保  存</asp:LinkButton>--%>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Next" class="btn btn-success" runat="server" OnClick="LinkButton2_Click"><i class="icon-ok bigger-110"></i> 提  交</asp:LinkButton>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Return" class="btn btn-pink" runat="server" OnClick="LinkButton4_Click"><i class="icon-undo bigger-110"></i> 退  回</asp:LinkButton>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Del" class="btn btn-danger" runat="server" OnClick="LinkButton1_Click"> <i class=" icon-trash bigger-110"></i> 删  除</asp:LinkButton>
        <asp:HyperLink ID="HyperLink1" class="btn btn-info" runat="server" Target="_blank">查看轨迹</asp:HyperLink>
    </div>
    <script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>

    <script type="text/javascript">
        jQuery(function ($) {
            $('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });
        });
    </script>

</asp:Content>
