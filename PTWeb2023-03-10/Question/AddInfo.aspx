<%@ Page Title="" Language="C#" MasterPageFile="~/Question/MasterPage.master" AutoEventWireup="true" CodeFile="AddInfo.aspx.cs" Inherits="Question_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="user-profile row height-auto">
        <div class="page-header">
            <h1>信息录入</h1>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">乡镇</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_XZ" runat="server" placeholder="请输入乡镇信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">姓名</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">社区/村 </label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_SQ" runat="server" placeholder="请输入居社区/村 " class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">居民小组/网格</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_XQ" runat="server" placeholder="请输入居民小组/网格" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">门牌号</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_MPH" runat="server" placeholder="请输入门牌号" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">证件号码</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_ZJNO" runat="server" placeholder="请输入证件号码" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">户籍地</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_HJD" runat="server" placeholder="请输入户籍地" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">现工作（学习）单位</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_DW" runat="server" placeholder="请输入现工作（学习）单位" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">政治面貌</label>
                <div class="col-sm-9">
                    <asp:RadioButtonList ID="RadioButtonList_ZZMM" runat="server" RepeatColumns="3">
                        <asp:ListItem Selected="True" Value="群众">&nbsp;&nbsp;群众&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="党员">&nbsp;&nbsp;党员&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="其他">&nbsp;&nbsp;其他&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">联系电话</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_LXDH" runat="server" placeholder="请输入联系电话" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">是否接种</label>
                <div class="col-sm-9">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2">
                        <asp:ListItem Selected="True" Value="否">&nbsp;&nbsp;否&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="是">&nbsp;&nbsp;是&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">接种剂次</label>
                <div class="col-sm-9">
                    <asp:RadioButtonList ID="RadioButtonList_JZ" runat="server" RepeatColumns="1">
                        <asp:ListItem Selected="True" Value="2-1">&nbsp;&nbsp;2-1&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="2-2">&nbsp;&nbsp;2-2&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="3-1">&nbsp;&nbsp;3-1&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="3-2">&nbsp;&nbsp;3-2&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="3-3">&nbsp;&nbsp;3-3&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">接种地点</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_JZDD" runat="server" placeholder="请输入接种地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">未种原因</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_WZYY" runat="server" placeholder="请输入未种原因" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">是否愿意参与志愿服务</label>
                <div class="col-sm-9">
                    <asp:RadioButtonList ID="RadioButtonList_ZY" runat="server" RepeatColumns="2">
                        <asp:ListItem Selected="True" Value="0">&nbsp;&nbsp;否&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="1">&nbsp;&nbsp;是&nbsp;&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">有无另外住处（若有请写具体）</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_QTDZ" runat="server" placeholder="请输入具体地址" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">网格员</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_WGY" runat="server" placeholder="请输入网格员" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">楼栋长</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_LDZ" runat="server" placeholder="请输入楼栋长" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right" for="form-field-1">备注说明</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark" TextMode="MultiLine" runat="server" placeholder="如有特殊情况，请填写。" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <h5>更新时间：<asp:Label ID="Label_LTime" runat="server" Text="暂未更新"></asp:Label></h5>
            <br />
            <p>
                <asp:LinkButton ID="LinkButton1" class="btn btn-info " runat="server" OnClick="Button1_Click"><i class="icon-save bigger-110"></i> 保存数据</asp:LinkButton>
           
                <asp:LinkButton ID="LinkButton2" class="btn btn-danger " runat="server" OnClick="LinkButton2_Click"><i class="icon-trash bigger-110"></i> 数据删除</asp:LinkButton>
            </p>
        </div>
    </div>
</asp:Content>

