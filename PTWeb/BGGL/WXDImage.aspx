<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WXDImage.aspx.cs" Inherits="Dance_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/BGGL/">报告管理</a></li>
            <li><a href="/BGGL/GCWXDList.ASPX">工程维修单</a></li>
            <li class="active"><a href="#">查看照片</a></li>
        </ul>
    </div>
    <div class="col-xs-12">
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    机房环境(建议两张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList" class="container-fluid list" runat="server" clientidmode="Static">
                    <div class="box">
                        <div class="list-item">
                            <div class="item-img">
                                <a href="https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=1988948143,281225406&fm=26&gp=0.jpg">
                                    <img src='https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=1988948143,281225406&fm=26&gp=0.jpg' /></a>
                            </div>
                            <div class="item-tt"><a href="#" class="btn btn-block btn-danger">删 除</a></div>
                        </div>
                    </div>
                    <div class="box">
                        <div class="list-item">
                            <div class="item-img">
                                <a href="http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png">
                                    <img src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' /></a>
                            </div>
                            <div class="item-tt">机房环境1</div>
                            <div class="item-tt"><a href="#" class="btn btn-block btn-danger">删 除</a></div>
                        </div>
                    </div>
                    <div class="box">
                    </div>
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload_TP" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" />
                    <asp:TextBox ID="TextBox_Remark" ClientIDMode="Static" runat="server" placeholder="请输入所需的备注信息" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    机柜正面(每台机柜一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList2" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button2" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    机柜背面(每台机柜至少一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList3" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload2" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button3" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    后端下线(后端钢性防护一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList4" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload3" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button4" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    墙体设备安装情况(一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList5" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload4" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button5" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    网点故障维修内容(前后对比照各一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList6" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload5" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button6" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    云机预览界面(每台至少一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList7" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload6" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button7" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
        <div class="widget-box ">
            <div class="widget-header">
                <h4 class="lighter smaller">
                    <i class="icon-calendar"></i>
                    云集设置界面(前后对比照各一张)
                </h4>
            </div>
            <div class="body">
                <div id="GoodsList8" class="container-fluid list" runat="server" clientidmode="Static">
                </div>
                <div class="list-item">
                    <asp:FileUpload ID="FileUpload7" runat="server" class="btn btn-block" ClientIDMode="Static" capture="camera" value="拍照" accept="image/*" />
                    <asp:Button ID="Button8" runat="server" class="btn btn-block" Text="确定上传" />
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入退回原因" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button9" runat="server" class="btn btn-block btn-danger" Text="整单退回" />



</asp:Content>

