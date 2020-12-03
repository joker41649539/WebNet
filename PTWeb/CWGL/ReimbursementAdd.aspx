<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReimbursementAdd.aspx.cs" Inherits="CWGL_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/CWGL/">财务管理</a></li>
            <li class="active">新建立报销单</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>报销单								<small><i class="icon-double-angle-right"></i>&nbsp;添加新的报销单                               </small></h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label8" class="col-sm-3 control-label no-padding-right" for="form-field-1">报销单号：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_No" runat="server" Text="BX2020-12-01-0001" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label9" class="col-sm-3 control-label no-padding-right" for="form-field-1">报销人：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_CName" runat="server" Text="报销人" Font-Bold="true">></asp:Label>
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
            <label runat="server" id="LabelRadioText" class="col-sm-3 control-label no-padding-right" for="form-field-1">工程编号：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Remark" runat="server" placeholder="请输入内容" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label1" class="col-sm-3 control-label no-padding-right" for="form-field-1">开支项目：</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">交通费及补助</asp:ListItem>
                    <asp:ListItem>采购物资</asp:ListItem>
                    <asp:ListItem>运输费</asp:ListItem>
                    <asp:ListItem>租脚手架</asp:ListItem>
                    <asp:ListItem>开槽费</asp:ListItem>
                    <asp:ListItem>开孔费</asp:ListItem>
                    <asp:ListItem>停车费</asp:ListItem>
                    <asp:ListItem>加油费</asp:ListItem>
                    <asp:ListItem>招待费</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="col-xs-12" runat="server" id="WellList">
        <div class="well">
            <h4 class="green smaller lighter">Normal Well</h4>
            Use the well as a simple effect on an element to give it an inset effect.
        </div>
    </div>
    <!-- /span -->
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label2" class="col-sm-3 control-label no-padding-right" for="form-field-1">发生日期：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBoxSTime" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label3" class="col-sm-3 control-label no-padding-right" for="form-field-1">出发地点：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Becity" ClientIDMode="Static" runat="server" placeholder="请输入出发地点" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label4" class="col-sm-3 control-label no-padding-right" for="form-field-1">到达地点：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Arrival" ClientIDMode="Static" runat="server" placeholder="请输入到达地点" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label5" class="col-sm-3 control-label no-padding-right" for="form-field-1">金额：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Num" ClientIDMode="Static" runat="server" placeholder="请输入报销金额" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label6" class="col-sm-3 control-label no-padding-right" for="form-field-1">备注说明：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Remark2" ClientIDMode="Static" runat="server" placeholder="请输入备注说明" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label7" class="col-sm-3 control-label no-padding-right" for="form-field-1">上传图片：</label>
            <div class="col-sm-9">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <div runat="server" id="UpdateImages"></div>
            <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton3" class="btn btn-mini" runat="server" OnClick="LinkButton3_Click"><b>+</b></asp:LinkButton>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="col-xs-12">
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_YZ_LinkButton1" class="btn btn-info" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
        &nbsp; &nbsp;                        
         <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn bt1n-small btn-purple no-border" runat="server"> <i class=" icon-barcode bigger-130"></i> 返 回</asp:LinkButton>
    </div>

    <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript">
        $(function () { $('#TextBoxSTime').datepicker(); });
    </script>
</asp:Content>
