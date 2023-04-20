<%@ Page Title="" Language="C#" MasterPageFile="~/Question/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Question_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="HiddenField_OpenID" runat="server" />
    <div runat="server" id="Div1"></div>
    <h1 class="center">巡检服务卡</h1>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-group">
                <label class="control-label bolder blue" for="form-field-1">测试文本</label>
                <div class="col-sm-9">
                    <input type="text" name="text1" placeholder="Username" class="col-xs-10 col-sm-5" />
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="control-label bolder blue" for="form-field-1">测试单选</label>
                <div class="col-sm-9">
                    <div class="control-group">
                        <div class="radio">
                            <label>
                                <input name="radio1" type="radio" class="ace" />
                                <span class="lbl">radio option 1</span>
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input name="radio2" type="radio" class="ace" />
                                <span class="lbl">radio option 1</span>
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input name="radio3" type="radio" class="ace" />
                                <span class="lbl">radio option 1</span>
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="control-label bolder blue" for="form-field-1">测试多选</label>
                <div class="col-sm-9">
                    <div class="control-group">
                        <div class="checkbox">
                            <label>
                                <input name="checkbox1" type="checkbox" class="ace ace-checkbox-2" />
                                <span class="lbl">choice 1</span>
                            </label>
                        </div>

                        <div class="checkbox">
                            <label>
                                <input name="checkbox2" type="checkbox" class="ace ace-checkbox-2" />
                                <span class="lbl">choice 2</span>
                            </label>
                        </div>
                        <div class="checkbox">
                            <label>
                                <input name="checkbox3" class="ace ace-checkbox-2" type="checkbox" />
                                <span class="lbl">choice 3</span>
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label class="control-label bolder blue" for="form-field-1">测试图片上传</label>
                <div class="col-sm-9">
                    <input type="file" name="UpImg" id="id-input1" accept="image/*" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="提 交" class="btn btn-success btn-block" />
    </div>
    <%-- 文件上传样式需要--%>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        jQuery(function ($) {
            //$('#id-input1,#id-input2').ace_file_input({
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
</asp:Content>

