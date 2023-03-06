<%@ Page Title="" Language="C#" MasterPageFile="~/TuanGou/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="TuanGou_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="red"><b>我的报告单</b></h4>
        </div>
        <div class="panel-body">
            <div class="panel-default">
                <ul class="list-unstyled">
                    <li>
                        <i class="icon-check"></i>
                        勘察报告
                    </li>
                    <li>
                        <i class="icon-check"></i>
                        论证报告
                    </li>
                    <li>
                        <i class="icon-check"></i>
                        验收报告
                    </li>
                    <li>
                        <i class="icon-check"></i>
                        维保报告
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <img src="/images/tt.png" class="img-rounded " width="100%" height="100%" />
    </div>
</asp:Content>

