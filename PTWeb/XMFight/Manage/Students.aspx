<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="XMFight_Manage_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-8">
            <div class="input-group">
                <input type="text" class="form-control search-query" placeholder="请输入需查询姓名" />
                <span class="input-group-btn">
                    <button type="button" class="btn btn-purple btn-sm">
                        查  询
																			<i class="icon-search icon-on-right bigger-110"></i>
                    </button>
                </span>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="widget-main no-padding">
            <div class="dialogs">
                <div runat="server" id="Div_StudentsList"></div>
            </div>
        </div>
    </div>
</asp:Content>

