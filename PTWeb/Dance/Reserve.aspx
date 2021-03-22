<%@ Page Title="" Language="C#" MasterPageFile="~/Dance/MasterPage.master" AutoEventWireup="true" CodeFile="Reserve.aspx.cs" Inherits="Dance_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="widget-box ">
                <div class="widget-header red">
                    <h4 class="lighter smaller">
                        <i class="icon-calendar red"></i>
                        <asp:Label ID="Label_DataTime" runat="server" Text="2021-03-19 星期五"></asp:Label>
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <div class="dialogs">
                            <div class="itemdiv dialogdiv">
                                <div class="user">
                                    <img src="/images/DanceLogo.jpg" />
                                </div>

                                <div class="body">
                                    <div class="time">
                                        <i class="icon-time"></i>
                                        <span class="green">
                                            <asp:Label ID="Label_Time" runat="server" Text="14:00-15:00"></asp:Label></span>
                                    </div>

                                    <div class="name">
                                        <a href="#">
                                            <asp:Label ID="Label_Teacher" runat="server" Text="老师"></asp:Label>
                                        </a>
                                    </div>
                                    <div class="text">
                                        <asp:Label ID="Label_ClassName" runat="server" Text="瑜伽"></asp:Label>&nbsp;&nbsp;[<asp:Label ID="Label_NowNo" runat="server" Text="0"></asp:Label>/<asp:Label ID="Label_MaxNo" runat="server" Text="10"></asp:Label>]
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /widget-main -->
                </div>
                <hr />
                <p>
                    <asp:Button ID="Button1" runat="server" class="btn btn-danger btn-block" Text="确定预约" OnClick="Button1_Click" />
                </p>
                <!-- /widget-body -->
            </div>
        </div>
        <div class="widget-body">
            <div class="widget-main no-padding">
                <asp:GridView ID="GridView_List" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top">
                    <Columns>
                        <asp:ImageField DataImageUrlField="HeadImage">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ControlStyle Height="35px" Width="35px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Nick" SortExpression="Nick" HeaderText="昵称">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ArrangeTime" DataFormatString="{0:yyyy-MM-dd}" SortExpression="ArrangeTime" HeaderText="课程时间">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LTime" SortExpression="LTime" HeaderText="预约时间">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

