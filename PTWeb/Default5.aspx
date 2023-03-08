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

    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />

    <script src="/assets/js/ace-extra.min.js"></script>

    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/assets/alert/alert.css" />

    <script src='/assets/alert/alert.js'></script>
    <script src='/assets/alert/shCore.js'></script>
    <script src='/assets/alert/makeSy.js'></script>

    <link rel="shortcut icon" type="image/x-icon" href="/images/ptlogo.png" media="screen" />
</head>
<body>
    <form id="form1" runat="server" class="dropzone">
        <div class="fallback">
            <input name="file" type="file" multiple="" />
        </div>
    </form>

    <script type="text/javascript">
        window.jQuery || document.write("<script src='/assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='/assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/typeahead-bs2.min.js"></script>

    <!-- page specific plugin scripts -->

    <script src="/assets/js/dropzone.min.js"></script>

    <!-- ace scripts -->

    <script src="/assets/js/ace-elements.min.js"></script>
    <script src="/assets/js/ace.min.js"></script>

    <script type="text/javascript">
        jQuery(function ($) {

            try {
                $(".dropzone").dropzone({
                    paramName: "file", // The name that will be used to transfer the file
                    maxFilesize: 5, // MB
                    //a
                    addRemoveLinks: true,
                    dictDefaultMessage:
                        '<i class="upload-icon icon-cloud-upload blue icon-3x"></i>'
                    ,
                    dictResponseError: '文件传输错误!',

                    //change the previewTemplate to use Bootstrap progress bars
                    previewTemplate: "<div class='dz-preview dz-file-preview'><div class='dz-details'> <div class='dz-filename'><span data-dz-name></span></div><div class='dz-size' data-dz-size></div><img data-dz-thumbnail /></div><div class='progress progress-small progress-striped active'><div class='progress-bar progress-bar-success' data-dz-uploadprogress></div></div><div class='dz-success-mark'><span></span></div><div class='dz-error-mark'><span></span></div><div class='dz-error-message'><span data-dz-errormessage></span></div></div>"
                    //previewTemplate: "<div class=\"dz-preview dz-file-preview\">\n  <div class=\"dz-details\">\n    <div class=\"dz-filename\"><span data-dz-name></span></div>\n    <div class=\"dz-size\" data-dz-size></div>\n    <img data-dz-thumbnail />\n  </div>\n  <div class=\"progress progress-small progress-striped active\"><div class=\"progress-bar progress-bar-success\" data-dz-uploadprogress></div></div>\n  <div class=\"dz-success-mark\"><span></span></div>\n  <div class=\"dz-error-mark\"><span></span></div>\n  <div class=\"dz-error-message\"><span data-dz-errormessage></span></div>\n</div>"
                });
            } catch (e) {
                alert('Dropzone.js does not support older browsers!');
            }

        });
    </script>
</body>
</html>
