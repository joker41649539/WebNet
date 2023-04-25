<%@ Page Title="" Language="C#" MasterPageFile="~/Gambling/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Gambling_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Odds1</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Odds1" runat="server" placeholder="Please Send Odds1" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Odds2</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Odds2" runat="server" placeholder="Please Send Odds2" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Odds3</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Odds3" runat="server" placeholder="Please Send Odds3" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <hr />
            <div class="btn-group">
                <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>计算</b></asp:LinkButton>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>Remark</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark" runat="server" TextMode="MultiLine" Height="150px" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

