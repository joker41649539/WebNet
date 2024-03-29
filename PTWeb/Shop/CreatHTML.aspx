﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="CreatHTML.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function check() {// 强制要求单人住宿超过80，多人住宿超过100 上传付款截图
            var rValue = true;
            var Stime = jQuery("#TextBox_Stime").val();
            var Interval = jQuery("#TextBox_Interval").val();
            var i = 0;
            var message = "";
            var regTime = /^([0-2][0-9]):([0-5][0-9])$/;
            var regInt = /^[1-9]\d*$/;

            //(/(^[1-9]\d*$) dialog = jqueryAlert({ 'content': "时间：" + regTime.test(Stime) + " " + Stime + " 间隔：" + regInt.test(Interval) + " " + Interval });

            //rValue = false;
            if (Stime.length <= 0 || !regTime.test(Stime)) {
                i++;
                rValue = false;
                message += i + "、抢购时间必须正确填写(例 09:50)！<br>";
            }

            if (Interval.length <= 0 || !regInt.test(Interval)) {
                i++;
                rValue = false;
                message += i + "、间隔必须是正整数！<br>";
            }
            if (!rValue) {
                dialog = jqueryAlert({ 'content': message.substring(0, message.length - 4) });
            }
            return rValue;
        }
    </script>
    <div class="col-xs-12">
        <div class="hr hr8 hr-double"></div>
        <div class="clearfix">
            <div class="grid3">
                <span class="grey bigger">
                    <i class="icon-credit-card icon-2x blue"></i>
                    &nbsp; 商品数量
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                </h4>
            </div>

            <div class="grid3">
                <span class="grey">
                    <i class="icon-credit-card icon-2x orange"></i>
                    &nbsp; 当前金额
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label2" runat="server" Text="1000"></asp:Label>
                </h4>
            </div>
            <div class="grid3">
                <span class="grey">
                    <i class="icon-credit-card icon-2x pink"></i>
                    &nbsp; 预计金额
                </span>
                <h4 class="bigger pull-right">
                    <asp:Label ID="Label3" runat="server" Text="1005"></asp:Label>
                </h4>
            </div>
        </div>
        <div class="hr hr8 hr-double"></div>
        <div class="col-sm-12" runat="server" id="Div_Date">
            <ul class="pagination center">
                <li>
                    <a href="#">05-26 10:00</a>
                </li>
                <li>
                    <a href="#">05-26 10:00</a>
                </li>
                <li class="active">
                    <a href="#">05-26 10:00</a>
                </li>
                <li>
                    <a href="#">05-26 10:00</a>
                </li>
                <li>
                    <a href="#">05-26 10:00</a>
                </li>
                <li>
                    <a href="#">05-26 10:00</a>
                </li>
            </ul>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>抢购时间</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Stime" ClientIDMode="Static" runat="server" placeholder="请输入抢购时间" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>时间间隔</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Interval" ClientIDMode="Static" runat="server" Text="1" placeholder="请输入时间间隔(分钟)" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <h3><b>WS服务器</b></h3>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox_Server" ClientIDMode="Static" runat="server" Text="ws://223.244.20.182:8090/ws" placeholder="ws://127.0.0.1:8090/ws" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="space"></div>
        <asp:GridView DataKeyNames="ID,Title,BigImg,NewPrice,Remark,InfoImg,zz,Gas" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" AutoGenerateColumns="false" ID="GridView_Goods" ClientIDMode="Static" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" Checked='<%# Bind("Selected") %>' ID="CheckBox1"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image runat="server" CssClass="img-rounded width-100" ImageUrl='<%# Eval("BigImg", "/Shop/Img/{0}") %>' ID="Image1"></asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataTextField="Title" SortExpression="Title" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Shop/GoodsRecords.aspx?id={0}" HeaderText="名称"></asp:HyperLinkField>
                <asp:HyperLinkField DataTextField="NewPrice" SortExpression="NewPrice" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Shop/GoodsRecords.aspx?id={0}" HeaderText="最近单价"></asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-xs-12">
        <div class="space"></div>
        <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="return check();" OnClick="LinkButton1_Click" CssClass="btn btn-success btn-block"><i class="icon-desktop"></i>&nbsp;创建静态页面</asp:LinkButton>
    </div>
</asp:Content>

