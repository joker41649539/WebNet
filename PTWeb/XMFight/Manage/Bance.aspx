<%@ Page Title="财务统计" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Bance.aspx.cs" Inherits="XMFight_Manage_Bance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="btn-group">
        <a href="BanceAdd.aspx" class="btn btn-danger">资金记录</a>
    </div>
    <hr />
    <div class="input-group">
        <asp:TextBox ID="TextBox1" CssClass="width-35" runat="server"></asp:TextBox>
        - 
        <asp:TextBox ID="TextBox2" CssClass="width-35" runat="server"></asp:TextBox>
        <span class="input-group-btn">
            <asp:Button ID="Button1" class="btn" runat="server" Text="统  计" OnClick="Button1_Click" />
        </span>
    </div>
    <div class="col-sm-7 infobox-container">
        <div class="infobox infobox-pink  ">
            <div class="infobox-icon">
                <i class="icon-group"></i>
            </div>

            <div class="infobox-data">
                <span class="infobox-data-number">32</span>
                <div class="infobox-content">累计学员</div>
            </div>
            <div class="stat stat-success">8%</div>
        </div>

        <div class="infobox infobox-blue  ">
            <div class="infobox-icon">
                <i class="icon-user"></i>
            </div>

            <div class="infobox-data">
                <span class="infobox-data-number">11</span>
                <div class="infobox-content">本月新增学员</div>
            </div>

            <div class="badge badge-success">
                +32%
												<i class="icon-arrow-up"></i>
            </div>
        </div>
        <div class="infobox infobox-red">
            <div class="infobox-icon">
                <i class="icon-credit-card"></i>
            </div>

            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_LJLR" runat="server" Text="50000"></asp:Label></span>
                <div class="infobox-content">累计利润</div>
            </div>
        </div>
        <div class="infobox infobox-red">
            <div class="infobox-icon">
                <i class="icon-credit-card"></i>
            </div>

            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_LJSR" runat="server" Text="50000"></asp:Label></span>
                <div class="infobox-content">累计收入</div>
            </div>
        </div>
        <div class="infobox infobox-green  ">
            <div class="infobox-icon">
                <i class="icon-credit-card"></i>
            </div>

            <div class="infobox-data">
                <span class="infobox-data-number">
                    <asp:Label ID="Label_LJZC" runat="server" Text="50000"></asp:Label></span>
                <div class="infobox-content">累计支出</div>
            </div>
        </div>
    </div>
    <div class="row">
        <div runat="server" id="Div_BanceList"></div>
    </div>
</asp:Content>

