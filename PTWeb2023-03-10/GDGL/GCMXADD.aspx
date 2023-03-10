<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GCMXADD.aspx.cs" Inherits="GDGL_GCMXADD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">安装位置</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_AZWZ" runat="server" placeholder="请输入安装位置" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">设备编号</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_SBBH" runat="server" placeholder="请输入设备编号" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">设备名称</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_SBMC" runat="server" placeholder="请输入设备名称" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">设备品牌</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_SBPP" runat="server" placeholder="请输入设备品牌" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">设备型号</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_SBXH" runat="server" placeholder="请输入设备型号" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">计量单位</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_JLDW" runat="server" placeholder="请输入计量单位" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">数量</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_SL" runat="server" placeholder="请输入数量" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">布线分数</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_FS" runat="server" placeholder="请输入布线分数" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">安装分数</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_AZFS" runat="server" placeholder="请输入安装分数" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">要求说明</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_XQSM" runat="server" TextMode="MultiLine" placeholder="请输入施工要求说明" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="col-md-offset-3 col-md-9">
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_YZ_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_YZ_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
        &nbsp; &nbsp;                        
         <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn bt1n-small btn-purple no-border" runat="server" OnClick="LinkButton1_Click"> <i class=" icon-barcode bigger-130"></i> 返 回</asp:LinkButton>
    </div>
</asp:Content>

