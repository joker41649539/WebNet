<%@ Page Title="我的信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyUserInfo.aspx.cs" Inherits="Sys_MyUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/SYS/MyUserInfo.aspx">我的信息</a></li>
        </ul>
    </div>
    <div class="modal fade" id="PassWord_Edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>密码修改</h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">原密码</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox_Old" type="password" runat="server" placeholder="请输入原密码" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">新密码</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox_New" type="password" runat="server" placeholder="请输入新密码" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">重复密码</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox_New1" type="password" runat="server" placeholder="请再输入新密码" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="LinkButton_PassWordUpdate" class="btn btn-info" OnClick="LinkButton_PassWordUpdate_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                        &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭                         </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="HeadUrl" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="page-content">
                <div class="page-header">
                    <h1>头像修改</h1>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">头像地址</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="TextBox_HeadUrl" runat="server" placeholder="请输入头像地址。列：http://xxx.xxx.com/xxx.jpg" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-3 col-md-9">
                        <asp:LinkButton ID="LinkButton_HeadUrl" class="btn btn-info" OnClick="LinkButton_HeadUrl_Click" runat="server"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                        &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭                         </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="space-10"></div>
        <div id="user-profile-1" class="user-profile row">
            <div class="col-sm-3 center">
                <div>
                    <span class="profile-picture">
                        <asp:Image ID="Image_User" class="editable img-responsive" runat="server" Style="max-width: 280px" />
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
                <div class="profile-contact-info">
                    <div class="profile-contact-links align-center">
                        <asp:LinkButton ID="LinkButton_PassWord" runat="server" OnClick="LinkButton_PassWord_Click"><i class="icon-lock bigger-120 green"></i>
                            密码修改</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton_HeardUrl" runat="server" OnClick="LinkButton_HeardUrl_Click"><i class="icon-camera bigger-120 pink"></i>
                            头像修改</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-sm-9">
                <div class="profile-user-info profile-user-info-striped">
                    <div class="profile-info-row">
                        <div class="profile-info-name">姓 名 </div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入您的姓名"></asp:TextBox>
                           <%-- <asp:Label CssClass="editable" ID="Label_Name1" runat="server" Text="姓 名"></asp:Label>--%>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">所属权限组 </div>
                        <div class="profile-info-value">
                            <asp:Label CssClass="editable" ID="Label_ZMC" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">性别</div>
                        <div class="profile-info-value">
                            <asp:DropDownList ID="DropDownList_Sex" runat="server">
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Selected="True" Value="0">女</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">联系电话</div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_LXDH" runat="server" placeholder="请输入您的联系电话"></asp:TextBox>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">身份证号码</div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_ZJNo" runat="server" placeholder="请输入身份证号码" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">徽商银行卡号</div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_KH" runat="server" placeholder="请输入徽商银行卡号" ></asp:TextBox>
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
                </div>
                <asp:LinkButton ID="LinkButton1" class="btn btn-info btn-block"  runat="server" OnClick="LinkButton1_Click"><i class="icon-save bigger-110"></i> 保存信息</asp:LinkButton>
                <div class="hr hr16 dotted"></div>
            </div>
        </div>
    </div>
</asp:Content>

