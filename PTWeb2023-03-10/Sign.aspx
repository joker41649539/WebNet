<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sign.aspx.cs" Inherits="Sign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/open-iconic/1.1.1/font/css/open-iconic-bootstrap.min.css" />
    <title>签名</title>
    var width = document.documentElement.clientWidth;
  var height =  document.documentElement.clientHeight;
  if( width < height ){
      console.log(width + " " + height);
      $print =  $('#print');
      $print.width(height);
      $print.height(width);
      $print.css('top',  (height-width)/2 );
      $print.css('left',  0-(height-width)/2 );
      $print.css('transform' , 'rotate(90deg)');
      $print.css('transform-origin' , '50% 50%');
 }
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">签名</div>
            <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" runat="server" />
            <asp:Image ID="Image_Sign" ClientIDMode="Static" runat="server" />
            <div class="col-sm" style="padding: 10px;">
                <div id="signature" style="border-style: dashed; border-width: 1px;"></div>
            </div>
            <div class="footer-nav" runat="server" id="SignBtnDiv">
                <button type="button" class="btn btn-success" data-toggle="modal" id="saveBtn">确认签名</button>
                &nbsp;&nbsp;
                    <button id="clearBtn" type="button" class="btn btn-danger">清除重签</button>
            </div>
        </div>
    </form>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jSignature/2.1.3/jSignature.min.js"></script>
    <script>
        $(document).ready(function () {
            var arguments = {
                width: '100%',
                height: '300px',
                signatureLine: false,
                lineWidth: '5'
            };
            $('#signature').jSignature(arguments);
            // 清除按钮
            $('#clearBtn').click(function () {
                $('#signature').jSignature('reset');
                document.getElementById("SignDiv").style.visibility = "visible";//隐藏
            });
            // 保存按钮
            $('#saveBtn').click(function () {
                var dataPair = $('#signature').jSignature('getData', 'image');
                var signatureImage = new Image();
                signatureImage.src = 'data:' + dataPair[0] + ',' + dataPair[1];
                signatureImage.image = dataPair[1];
                document.getElementById("Image_Sign").src = signatureImage.src;
                document.getElementById("HiddenField1").value = signatureImage.src;
                document.getElementById("SignDiv").style.visibility = "hidden";//隐藏
            });
        });
    </script>
</body>
</html>
