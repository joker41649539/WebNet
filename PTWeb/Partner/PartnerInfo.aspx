<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PartnerInfo.aspx.cs" Inherits="Partner_PartnerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/Partner/">协同人员管理</a></li>
        </ul>
    </div>
    <asp:HiddenField ID="HiddenField_department" runat="server" />
    <asp:HiddenField ID="HiddenField_WorkerOpenID" runat="server" />
    <div class="col-xs-12">
        <div class="page-header">
            <h1><a href="/Partner/">协同人员管理</a><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;协同人员信息</small></h1>
        </div>
        <div class="col-xs-12">
            <div class="space-10"></div>
            <div id="user-profile-1" class="user-profile row">
                <div class="col-sm-3 center">
                    <div>
                        <span class="profile-picture">
                            <asp:Image ID="Image_User" ImageUrl="/images/ptlogo.png" class="editable img-responsive" runat="server" Style="max-width: 280px" />
                        </span>
                        <div class="space-4"></div>
                        <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                            <div class="inline position-relative">
                                <a href="#" class="user-title-label dropdown-toggle">
                                    <i class="icon-circle light-green middle"></i>
                                    <asp:Label CssClass="white" ID="Label_Name" runat="server" Text="姓 名"></asp:Label>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="hr hr16 dotted"></div>
                    <div class="profile-contact-info" runat="server" id="DivIDImage">
                    </div>
                    <div class="profile-contact-info">
                        <div class="profile-contact-links align-center">
                            <asp:HyperLink ID="HyperLink_Remark" runat="server"><i class="icon-plus-sign bigger-120 green"></i>
                                &nbsp;添加人员描述</asp:HyperLink>
                            <a href="/Partner/Tags.aspx"><i class="icon-bookmark bigger-120 red"></i>&nbsp;标签管理</a>
                        </div>
                    </div>
                    <hr />
                    <h3>用户标签</h3>
                    <div class="profile-contact-info" runat="server" id="Div_MyTags">
                    </div>
                    <hr />
                    <h3>所有标签</h3>
                    <div class="profile-contact-info left" runat="server" id="Div_Tags">
                    </div>
                    <br />
                </div>
                <div class="col-sm-9">
                    <div class="profile-user-info profile-user-info-striped">
                        <div class="profile-info-row">
                            <div class="profile-info-name">姓 名 </div>
                            <div class="profile-info-value">
                                <asp:Label CssClass="editable" ID="Label_Name1" runat="server" Text="姓 名"></asp:Label>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">性别</div>
                            <div class="profile-info-value">
                                <asp:DropDownList ID="DropDownList_Sex" runat="server">
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">联系电话</div>
                            <div class="profile-info-value">
                                <asp:Label CssClass="editable" ID="Label_LXDH" runat="server" Text="创建时间"></asp:Label>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">身份证号码</div>
                            <div class="profile-info-value">
                                <asp:Label CssClass="editable" ID="Label_IDNo" runat="server" Text="创建时间"></asp:Label>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">创建时间 </div>
                            <div class="profile-info-value">
                                <asp:Label CssClass="editable" ID="Label_Ctime" runat="server" Text="创建时间"></asp:Label>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">最后登录时间</div>
                            <div class="profile-info-value">
                                <asp:Label CssClass="editable" ID="Label_Ltime" runat="server" Text="最后登录时间"></asp:Label>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">所属部门</div>
                            <div class="profile-info-value">
                                <div class="control-group" runat="server" id="RadioBM">
                                    <div class="radio">
                                        <label>
                                            <input name="form-field-radio" checked="checked" type="radio" class="ace" />
                                            <span class="lbl">radio option 1</span>
                                        </label>
                                    </div>
                                    <div class="radio">
                                        <label>
                                            <input name="form-field-radio" type="radio" class="ace" />
                                            <span class="lbl">radio option 2</span>
                                        </label>
                                    </div>

                                    <div class="radio">
                                        <label>
                                            <input name="form-field-radio" type="radio" class="ace" />
                                            <span class="lbl">radio option 3</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">&nbsp;</div>
                            <div class="profile-info-value">
                                <div class="btn-group">
                                    <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton1" class="btn btn-info" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok"></i> <b>申请通过</b></asp:LinkButton>
                                    <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton2" class="btn btn-success" runat="server" OnClick="LinkButton2_Click"><i class="icon-check"></i> <b>启用</b></asp:LinkButton>
                                    <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton3" class="btn btn-danger" runat="server" OnClick="LinkButton3_Click"><i class="icon-check-empty"></i> <b>停用</b></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content">
        <br />
        <div id="ContentPlaceHolder1_QDList" runat="server">
        </div>
    </div>
</asp:Content>

