<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>普田科技</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="robots" content="noarchive" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimal-ui" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/dropzone.css" />

    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />

    <script src="/assets/js/ace-extra.min.js"></script>

    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/assets/alert/alert.css" />

    <script src='/assets/alert/alert.js'></script>
    <script src='/assets/alert/shCore.js'></script>
    <script src='/assets/alert/makeSy.js'></script>
    <script src="/assets/js/ace-extra.min.js"></script>

    <link rel="shortcut icon" type="image/x-icon" href="/images/ptlogo.png" media="screen" />
    <script src="/js/alert.js"></script>
</head>
<body>

    <form id="form1" runat="server" class="dropzone">
        <div class="widget-body">
            <div class="widget-main">
                <input name="AddImg" type="file" id="id-input" />
            </div>
            <div id="file"></div>
        </div>
        <hr />

        <div id="dropzone" class="row">
            <div class="fallback">
                <input name="file" type="file" multiple="" />
            </div>
        </div>
        <div class="">
            <asp:LinkButton UseSubmitBehavior="false" OnClientClick="alert('提示');" ID="LinkButton1" class="btn btn-info btn-block" runat="server" OnClick="LinkButton1_Click"><i class="icon-ok bigger-110"></i> <b>提交申请</b></asp:LinkButton>
        </div>
    </form>
    <%-- 文件上传样式需要--%>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='/assets/js/jquery-2.0.3.min.js'><" + "/script>");
    </script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/ace-elements.min.js"></script>
    <%-- 文件上传样式需要--%>
    <script src="/assets/js/dropzone.min.js"></script>
    <script type="text/javascript">
        (function () {
            window.alert = function (name) {
                var iframe = document.createElement("IFRAME");
                iframe.style.display = "none";
                iframe.setAttribute("src", 'data:text/plain');
                document.documentElement.appendChild(iframe);
                window.frames[0].window.alert(name);
                iframe.parentNode.removeChild(iframe);
            }
        })();
        jQuery(function ($) {
            $('#id-input').ace_file_input({
                style: 'well',
                btn_choose: '请点击选择图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'large'
            }).on('change', function () {
                //  swal("重要提示", "这么酷？");
                alert("提示");
            });
        });
        jQuery(function ($) {
            try {
                $(".dropzone").dropzone({
                    paramName: "file", // The name that will be used to transfer the file
                    maxFilesize: 5, // MB
                    dictDefaultMessage:
                        '<span class="bigger-150 bolder"><i class="icon-caret-right red"></i> 请点击上传文件</span>\
				<br/>\
				<i class="upload-icon icon-cloud-upload blue icon-3x"></i>'
                    ,
                    addRemoveLinks: true,
                    dictResponseError: 'Error while uploading file!',

                    //change the previewTemplate to use Bootstrap progress bars
                    previewTemplate: "<div class=\"dz-preview dz-file-preview\">\n  <div class=\"dz-details\">\n    <div class=\"dz-filename\"><span data-dz-name></span></div>\n    <div class=\"dz-size\" data-dz-size></div>\n    <img data-dz-thumbnail />\n  </div>\n  <div class=\"progress progress-small progress-striped active\"><div class=\"progress-bar progress-bar-success\" data-dz-uploadprogress></div></div>\n  <div class=\"dz-success-mark\"><span></span></div>\n  <div class=\"dz-error-mark\"><span></span></div>\n  <div class=\"dz-error-message\"><span data-dz-errormessage></span></div>\n</div>"
                });
            } catch (e) {
                alert('Dropzone.js does not support older browsers!');
            }
        });
    </script>
</body>
</html>
