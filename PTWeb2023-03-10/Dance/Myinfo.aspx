<%@ Page Title="" Language="C#" MasterPageFile="~/Dance/MasterPage.master" AutoEventWireup="true" CodeFile="Myinfo.aspx.cs" Inherits="Dance_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="widget-box ">
                <div class="widget-header red">
                    <h4 class="lighter smaller">
                        <i class="icon-calendar red"></i>
                        预约中
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding" runat="server" id="ArrangeList">
                    </div>
                    <!-- /widget-main -->
                </div>
                <hr />
                <div class="widget-box ">
                    <div class="widget-header green">
                        <h4 class="lighter smaller">
                            <i class="icon-calendar"></i>
                            已上课程 累计[<asp:Label ID="Label_Count" runat="server" Text="0"></asp:Label>] 小时
                        </h4>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main no-padding" runat="server" id="AttendList">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

