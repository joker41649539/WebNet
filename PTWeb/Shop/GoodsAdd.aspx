<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsAdd.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function check() {
            var rValue = false;
            var Title = document.getElementById("TextBox_Name").value;
            var Price = document.getElementById("TextBox_Price").value;
            var Time = document.getElementById("TextBox_Time").value;
            var Remark = document.getElementById("TextBox_Remark").value;
            var BigImage = document.getElementById("id-input0").value;
            var InfoImage = document.getElementById("id-input1").value;

            var float = /^(-?\d+)(\.\d+)?$/; // 浮点数正则表达式 ([0-9][0-9])
            var regTime = /^([0-2][0-9]):([0-5][0-9])$/;

            dialog = jqueryAlert({ 'content': "时间格式：" + regTime.test(Time) });

            //if (float.test(Price) == false) {
            //    dialog = jqueryAlert({ 'content': "单价必须为数字。" });
            //    var rValue = false;
            //}
            return rValue;
        }

        jQuery(function ($) {
            $('#id-input1').ace_file_input({
                style: 'well',
                btn_choose: '点击上传图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large'
            }).on('change', function () {
                CreateInput();
            });
        });

        var i = 2;// 用于计算ID
        function CreateInput() {
            var input = document.createElement("input");
            var MaxCount = 10; // 最大数量
            i++
            input.type = "file";
            input.accept = "image/*";// 文件类型
            input.name = "AddImg";
            input.id = "id-input" + i;
            document.getElementById("showText").appendChild(input);
            jQuery(function ($) {
                $('#' + input.id + '').ace_file_input({
                    style: 'well',
                    btn_choose: '点击上传图片',
                    btn_change: null,
                    no_icon: 'icon-cloud-upload',
                    droppable: true,
                    thumbnail: 'large'
                }).on('change', function () {
                    if (i < MaxCoun) { //达到最大数量后不添加
                        CreateInput();//图片选择后，自动添加
                    }
                });
            });
        }
    </script>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>商品名称</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Name" ClientIDMode="Static" runat="server" placeholder="请输入商品名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>单价</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Price" ClientIDMode="Static" runat="server" placeholder="请输入单价" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>开拍时间</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Time" ClientIDMode="Static" runat="server" placeholder="请输入时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>产品大图</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input0" accept="image/*" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>详细信息</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark" ClientIDMode="Static" TextMode="MultiLine" runat="server" placeholder="请输入产品说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>产品图片</b></h3>
                <div class="col-sm-9 widget-main" id="showText">
                    <input name="AddImg" accept="image/*" type="file" id="id-input1" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <asp:Button ID="Button_Save" OnClick="Button_Save_Click" OnClientClick="return check();" CssClass="btn btn-block btn-success" runat="server" Text="确定添加" />
            <p>&nbsp;</p>
            <br />
        </div>

        <%-- 文件上传样式需要--%>
        <script src="/assets/js/bootstrap.min.js"></script>
        <script src="/assets/js/ace-elements.min.js"></script>
        <%-- 文件上传样式需要--%>
        <script type="text/javascript">
            jQuery(function ($) {
                $('#id-input0').ace_file_input({
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

    </div>
</asp:Content>

