<%@ Page Title="" Language="C#" MasterPageFile="~/Gambling/MasterPage.master" AutoEventWireup="true" CodeFile="Canada28.aspx.cs" Inherits="Gambling_Canada28" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <meta http-equiv="Refresh" content="10">--%>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>网址</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Url" runat="server" placeholder="请输入指定网址" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Cookin</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Cookie" runat="server" placeholder="请输入Cookie" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Cookin</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="150px" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <hr />
            <div class="form-group">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>加载数据</b></asp:LinkButton>
            </div>
        </div>
        <div class="col-xs-12">
            <hr />
            <div class="form-group">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton2" class="btn btn-info btn-block" runat="server" OnClick="LinkButton2_Click"><i class="icon-ok bigger-110"></i> <b>下注</b></asp:LinkButton>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="col-xs-6">
                <asp:GridView ID="GridView1" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" runat="server"></asp:GridView>
            </div>
            <div class="col-xs-6">
                &nbsp;
            </div>
        </div>
    </div>
</asp:Content>

