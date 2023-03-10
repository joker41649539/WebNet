<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Temp.aspx.cs" Inherits="GDGL_Temp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active"><a href="/GDGL/MyBXGD.aspx">我的布线工程</a></li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>
            <a id="ContentPlaceHolder1_Label_GCMC" href="/GDGL/MyGDBXWZ.aspx?ID=565">中国农业银行六安分行金安区孙岗技防改造监控工程</a><small><i class="icon-double-angle-right"></i>&nbsp;&nbsp;<span id="ContentPlaceHolder1_Label_AZWZ">自助服务区及加钞间</span></small></h1>
    </div>
    <div class="tabbable">
        <div class="widget-box transparent">
            <div class="widget-body">
                <div class="widget-main no-padding">
                    <div class="widget-body">
                        <h5>宽动态针孔摄像机:<input type="checkbox" name="ck1" value="S1" checked="checked" />S1;<input type="checkbox" checked="checked" />S1-1;<input type="checkbox" checked="checked" />S2;<input type="checkbox" checked="checked" />S2-1;<br />
                            宽动态半球:<input type="checkbox" name="ck1" value="ck1"  checked="checked" />S3;<input type="checkbox" checked="checked" />S4;<input type="checkbox" checked="checked" />S5;<input type="checkbox" checked="checked" />S6;<br />
                            高清降噪拾音器（壁挂）:<input type="checkbox" checked="checked" />JT1;<input type="checkbox" checked="checked" />JT2;<br />
                            箱钞振动探测器:<input type="checkbox" checked="checked" />ZT1;<input type="checkbox" checked="checked" />ZT2;<input type="checkbox" checked="checked" />ZT3;<input type="checkbox" checked="checked" />ZT4;<input type="checkbox" checked="checked" />ZT5;<input type="checkbox" checked="checked" />ZT6;<input type="checkbox" checked="checked" />ZT7;<input type="checkbox" checked="checked" />ZT8;</h5>
                    </div>
                    <%-- <table cellspacing="0" rules="all" class="table table-striped table-bordered table-hover no-margin-bottom no-border-top" border="1" id="GridView_List" style="border-collapse: collapse;">
                        <tr>
                            <th scope="col">&nbsp;摄像头</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />S1;<input type="checkbox" checked="checked" />S1-1;
                                <input type="checkbox" checked="checked" />S2;<input type="checkbox" checked="checked" />S2-1;
                                <input type="checkbox" checked="checked" />S3;<input type="checkbox" checked="checked" />S4;
                                <input type="checkbox" checked="checked" />S5;<input type="checkbox" checked="checked" />S6;
                            </th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;监听</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />JT1;<input type="checkbox" checked="checked" />JT2;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;震动</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />ZT1;<input type="checkbox" checked="checked" />ZT2;
                                <input type="checkbox" checked="checked" />ZT3;<input type="checkbox" checked="checked" />ZT4;
                                <input type="checkbox" checked="checked" />ZT5;<input type="checkbox" checked="checked" />ZT6;
                                <input type="checkbox" checked="checked" />ZT7;<input type="checkbox" checked="checked" />ZT8;
                                <input type="checkbox" checked="checked" />ZT9;<input type="checkbox" checked="checked" />ZT10;
                            </th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;烟感</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />YT1;<input type="checkbox" checked="checked" />YT2;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;报警</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />B1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;灯</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />D1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;面板</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />IP1;<input type="checkbox" checked="checked" />IP2;<input type="checkbox" checked="checked" />IP3;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;键盘</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />KB;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;门磁</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />M1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;幕帘</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />MT1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;水浸</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />ST1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;红外</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />T1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;温感</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />WT1;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;门禁</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />门禁1;<input type="checkbox" checked="checked" />门禁2;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;人脸</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />人脸1;<input type="checkbox" checked="checked" />人脸2;</th>
                        </tr>
                        <tr>
                            <th scope="col">&nbsp;锁</th>
                            <th scope="col">
                                <input type="checkbox" checked="checked" />锁;</th>
                        </tr>
                    </table>--%>
                    <hr />
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="4">
                        <asp:ListItem Value="10">&nbsp;刚开始&nbsp;</asp:ListItem>
                        <asp:ListItem Value="50">&nbsp;干一半&nbsp;</asp:ListItem>
                        <asp:ListItem Value="90">&nbsp;快结束&nbsp;</asp:ListItem>
                        <asp:ListItem Value="100">&nbsp;已完成&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                    <hr />
                    <div class="widget-body">
                        <asp:TextBox ID="TextBox1" Width="100%" placeholder="如有需要请填写备注信息" runat="server" Height="60px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Save" class="btn btn-info" runat="server" OnClick="LinkButton_Save_Click"><i class="icon-save bigger-110"></i>保  存</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

