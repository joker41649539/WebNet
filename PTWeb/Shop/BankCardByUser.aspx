<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="BankCardByUser.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function check() {
            var rValue = false;
            var input = document.getElementById("id-input0").value;
            if (input.length > 0) {
                $("#LinkButton_Up").attr("disabled", true);
                dialog = jqueryAlert({ 'content': "<i class=\"icon-coffee icon-3x green\"></i><br/>数据处理中，请勿刷新页面<br/>请耐心等待。" });
                $("#LinkButton_Up").text('数据处理中，请勿刷新页面，请耐心等待');
                rValue = true;
            }
            return rValue;
        }
    </script>
    <div class="row">
        <asp:HiddenField ID="HiddenField_ID" runat="server" />
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>
                    <asp:Label ID="Label_Title" runat="server" Text="Title"></asp:Label>
                </b></h3>
                <div class="col-sm-9">
                    <h1 class="red"><b>￥<span><asp:Label ID="Label_Price" runat="server" Text="0.00"></asp:Label></span></b>
                    </h1>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <asp:Image ID="Image_BigImg" class="img-rounded width-100" runat="server" />
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>联系电话</b></h3>
                <div class="col-sm-9">
                    <h3>
                        <asp:HyperLink ID="HyperLink_Tel" runat="server">139********</asp:HyperLink></h3>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>微信收款码</b></h3>
                <div class="col-sm-9">
                    <asp:Image ID="Image_WeChat" class="img-rounded width-100" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>支付宝收款码</b></h3>
                <div class="col-sm-9">
                    <asp:Image ID="Image_Pay" class="img-rounded width-100" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>银行卡信息</b></h3>
                <div class="col-sm-9">
                    <h4>
                        <asp:Label ID="Label4" runat="server" Text="姓名"></asp:Label>
                    </h4>
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="银行名字"></asp:Label>
                    </h4>
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="开户行"></asp:Label>
                    </h4>
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="账号"></asp:Label>
                    </h4>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>付款凭证</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input0" accept="image/*" />
                </div>
                <asp:Image ID="Image1" class="img-rounded width-100" runat="server" />
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:LinkButton ID="LinkButton_Up" ClientIDMode="Static" OnClick="LinkButton_Up_Click" OnClientClick="return check();" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;上传付款凭证</asp:LinkButton>
            <br />
        </div>
    </div>
    <%-- 文件上传样式需要--%>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input0,#id-input0').ace_file_input({
                style: 'well',
                btn_choose: '点击上传付款凭证',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large',// large | small
                preview_error: function (filename, error_code) {

                }
            }).on('change', function () {
                //alert("修改");
            });
        });
    </script>

</asp:Content>

