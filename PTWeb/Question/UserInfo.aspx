<%@ Page Title="我的信息" Language="C#" MasterPageFile="~/Question/MasterPage.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="Sys_MyUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="user-profile row height-auto">
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
                        <div class="profile-info-name">联系电话</div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_LXDH" runat="server" placeholder="请输入您的联系电话"></asp:TextBox>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">创建时间 </div>
                        <div class="profile-info-value">
                            <asp:Label CssClass="editable" ID="Label_Ctime" runat="server" Text="创建时间"></asp:Label>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">新密码 </div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_New" runat="server"  placeholder="请输入您的新密码" ReadOnly="False" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">确认密码 </div>
                        <div class="profile-info-value">
                            <asp:TextBox ID="TextBox_New1" runat="server" placeholder="请输入您的确认密码" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="profile-info-row">
                        <div class="profile-info-name">最后登录时间</div>

                        <div class="profile-info-value">
                            <asp:Label CssClass="editable" ID="Label_Ltime" runat="server" Text="最后登录时间"></asp:Label>
                        </div>
                    </div>
                </div>
                <asp:LinkButton ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-save bigger-110"></i> 保存信息</asp:LinkButton>
                <div class="row" style="height: 80px;">
                </div>

            </div>
        </div>
    </div>
</asp:Content>

