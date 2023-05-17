<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="BankCard.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>微信收款码</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input0" accept="image/*" />
                </div>
                <img src="/img/01.jpg" class="img-rounded width-100" />
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:HyperLink ID="HyperLink2" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;保存(更换)微信收款码</asp:HyperLink>
            <br />
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>支付宝收款码</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input1" accept="image/*" />
                </div>
                <img src="/img/02.jpg" class="img-rounded width-100" />
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:HyperLink ID="HyperLink3" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;保存(更换)支付宝收款码</asp:HyperLink>
            <br />
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>银行名称</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" placeholder="请输入银行名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <h3><b>开户行名称</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入您的开户行名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <h3><b>银行卡号</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请输入您的银行卡号" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <br />
            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-block btn-success" runat="server"><i class="icon-save"></i>&nbsp;保存(更新)银行卡号</asp:HyperLink>
            <br />
        </div>
        <br />
    </div>
    <%-- 文件上传样式需要--%>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input0,#id-input1').ace_file_input({
                style: 'well',
                btn_choose: '点击上传图片',
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

