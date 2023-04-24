<%@ Page Title="" Language="C#" MasterPageFile="~/Gambling/MasterPage.master" AutoEventWireup="true" CodeFile="Canada28.aspx.cs" Inherits="Gambling_Canada28" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%-- <meta http-equiv="Refresh" content="10">--%>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Money</b></h3>
                <div class="col-sm-9">
                    <h3><b>
                        <asp:Label ID="Label_money" runat="server" Text="000"></asp:Label>
                        <asp:CheckBox ID="CheckBox_Auto" Text="自动刷新" runat="server" />
                        BetSN：<asp:Label ID="Label_BetSN" runat="server" Text="0"></asp:Label>
                        Win：<asp:Label ID="Label_Win" runat="server" Text="0"></asp:Label>
                    </b></h3>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>BetCount</b></h3>
                <div class="col-sm-9">
                    <h3><b>
                        <asp:Label ID="Label_BetCount" runat="server" Text="0"></asp:Label>
                         BetTurnNum：<asp:Label ID="Label_TurnNum" runat="server" Text="无"></asp:Label>
                         BetPlayName：<asp:Label ID="Label_PlayName" runat="server" Text="无"></asp:Label>
                   </b></h3>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>URL</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Url" runat="server" placeholder="请输入指定网址" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Cookie</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Cookie" runat="server" placeholder="请输入Cookie" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Bet</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Bet" runat="server" placeholder="请输入Bet,中间用;间隔" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>
                    <asp:Label ID="Label_NextNum" runat="server" Text="0000000"></asp:Label></b></h3>
                <div class="col-sm-9">
                    <h3><b>
                        <asp:Label ID="Label_EndTime" runat="server" Text="000"></asp:Label></b></h3>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Remark</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="150px" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <hr />
            <div class="btn-group">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>加载</b></asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton3" class="btn btn-pink" runat="server" OnClick="LinkButton3_Click"><i class="icon-save bigger-110"></i> <b>保存数据</b></asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton2" class="btn btn-success" runat="server" OnClick="LinkButton2_Click"><i class="icon-headphones bigger-110"></i> <b>测试下注</b></asp:LinkButton>
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton4" class="btn btn-success" runat="server" OnClick="LinkButton4_Click"><i class="icon-headphones bigger-110"></i> <b>测试数据</b></asp:LinkButton>
            </div>
        </div>
        <div class="col-xs-12">
            <hr />
            <div class="col-xs-6">
                <asp:GridView ID="GridView1" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" runat="server"></asp:GridView>
            </div>
            <div class="col-xs-6">
                &nbsp;
            </div>
        </div>
    </div>
    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="20000"></asp:Timer>
</asp:Content>

