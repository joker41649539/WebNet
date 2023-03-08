<%@ Page Title="" Language="C#" MasterPageFile="~/Tuangou/MasterPage.master" AutoEventWireup="true" CodeFile="OfferInfo.aspx.cs" Inherits="TuanGou_OfferInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="center">
        <div class="page-content" style="height: auto;">
            <span class="profile-picture">
                <img id="ContentPlaceHolder1_Image_User" class="editable img-responsive" src="/images/XMFightLogo.jpg" style="max-width: 150px" />
            </span>
            <div class="space-4"></div>
            <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                <div class="inline position-relative">
                    <a href="#" class="user-title-label dropdown-toggle">
                        <i class="icon-circle light-green middle"></i>
                        <span id="ContentPlaceHolder1_Label_Name" class="white">旭铭搏击</span>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-body">
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <h5><b>订单号</b></h5>
                    <h5 class="red">
                        <asp:Label ID="Label_DDNo" runat="server" Text="Offer"></asp:Label>
                    </h5>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group center">
                    <h3><b>
                        <asp:Label ID="Label_OfferName" runat="server" Text="Offer"></asp:Label>
                    </b></h3>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>您或孩子的姓名</b></h3>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入您或孩子的姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>手机号码</b></h3>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Tel" runat="server" placeholder="请输入能联系到您的手机号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <h3><b>说明信息</b></h3>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_Remark" runat="server" TextMode="MultiLine" placeholder="如有需要说明的信息，请填写" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>更新资料</b></asp:LinkButton>
    </div>
</asp:Content>

