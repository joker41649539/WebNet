<%@ Page Title="" Language="C#" MasterPageFile="~/Shop/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsAdd.aspx.cs" Inherits="Shop_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input').ace_file_input({
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
            // input.capture = "camera";// 照相机
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
                    if (i < MaxCount - 1) { //达到最大数量后不添加
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
                    <asp:TextBox ID="TextBox_Name" runat="server" placeholder="请输入商品名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>单价</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Pic" runat="server" placeholder="请输入单价" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>开拍时间</b></h3>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Time" runat="server" placeholder="请输入时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>产品大图</b></h3>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input1" accept="image/*" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <h3><b>产品图片</b></h3>
                <div class="col-sm-9 widget-main" id="showText">
                    <input name="AddImg" accept="image/*" type="file" id="id-input" />
                </div>
            </div>
        </div>

        <%-- 文件上传样式需要--%>
        <script src="/assets/js/bootstrap.min.js"></script>
        <script src="/assets/js/ace-elements.min.js"></script>
        <%-- 文件上传样式需要--%>
        <script type="text/javascript">
            jQuery(function ($) {
                $('#id-input1').ace_file_input({
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

