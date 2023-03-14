<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        jQuery(function ($) {
            $('#id-input').ace_file_input({
                style: 'well',
                btn_choose: '请点击选择图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large'
            }).on('change', function () {
                CreateInput();
            });
        });

        var i = 0;// 用于计算ID
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
                    btn_choose: '请点击选择图片',
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

        function beat() {
            var content = document.getElementById("TextBox_Title");//input的id
            if (content.value == "") {
                //  alert('标题不允许为空。');
                dialog = jqueryAlert({ 'title': '提示信息', 'content': '标题不允许为空。', 'modal': true, 'buttons': { '确定': function () { dialog.destroy(); dialog.close(); } } })
                return false;
            }
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li class="active">图片展示</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="row-fluid">
            <ul class="ace-thumbnails" runat="server" id="ShowImages">
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" style="max-width: 100%" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info arrowed-in">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-success">说明信息说明信息说明信息说明</span>
                            </span>
                        </div>
                        <div class="tools">
                            <a href="Test.aspx">
                                <i class="icon-remove red"></i>
                            </a>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-danger">说明信息</span>
                            </span>
                            <%-- <span class="label-holder">
                                <span class="label label-success">toast</span>
                            </span>--%>
                            <span class="label-holder">
                                <span class="label label-warning arrowed-in">删除</span>
                            </span>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-danger">说明信息</span>
                            </span>
                            <%-- <span class="label-holder">
                                <span class="label label-success">toast</span>
                            </span>--%>
                            <span class="label-holder">
                                <span class="label label-warning arrowed-in">删除</span>
                            </span>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-danger">说明信息</span>
                            </span>
                            <%-- <span class="label-holder">
                                <span class="label label-success">toast</span>
                            </span>--%>
                            <span class="label-holder">
                                <span class="label label-warning arrowed-in">删除</span>
                            </span>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-danger">说明信息</span>
                            </span>
                            <%-- <span class="label-holder">
                                <span class="label label-success">toast</span>
                            </span>--%>
                            <span class="label-holder">
                                <span class="label label-warning arrowed-in">删除</span>
                            </span>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-danger">说明信息</span>
                            </span>
                            <%-- <span class="label-holder">
                                <span class="label label-success">toast</span>
                            </span>--%>
                            <span class="label-holder">
                                <span class="label label-warning arrowed-in">删除</span>
                            </span>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="#" title="Photo Title" data-rel="colorbox">
                        <img alt="150x150" class="img-rounded" src='http://5b0988e595225.cdn.sohucs.com/images/20180510/4fb177bf1eb04ef49b55de3f5f6e82bd.png' />
                        <div class="tags">
                            <span class="label-holder">
                                <span class="label label-info">机房全景</span>
                            </span>
                            <span class="label-holder">
                                <span class="label label-danger">说明信息</span>
                            </span>
                            <%-- <span class="label-holder">
                                <span class="label label-success">toast</span>
                            </span>--%>
                            <span class="label-holder">
                                <span class="label label-warning arrowed-in">删除</span>
                            </span>
                        </div>
                    </a>
                </li>

            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">标题：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Title" ClientIDMode="Static" runat="server" placeholder="请输入图片标题" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="col-sm-3 control-label no-padding-right">描述：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_Remark" ClientIDMode="Static" runat="server" placeholder="请输入图片描述信息" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="footer">
        <div class="widget-main" id="showText">
            <input name="AddImg" accept="image/*" type="file" id="id-input" />
        </div>
        <asp:Button ID="Button1" class="btn btn-success btn-lg btn-block" OnClientClick="return beat();" OnClick="Button1_Click" runat="server" Text="上传图片" />
    </div>
</asp:Content>

