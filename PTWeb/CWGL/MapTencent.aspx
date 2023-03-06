<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapTencent.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>地图查看</title>
</head>
<script charset="utf-8" src="https://map.qq.com/api/gljs?v=1.exp&key=OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77"></script>
<body>
    <div id="container"></div>
    <script type="text/javascript">
        function getQueryString(name) {
            const url_string = window.location.href; // window.location.href
            const url = new URL(url_string);
            return url.searchParams.get(name);
        }
        var iJD = getQueryString('iJD');
        var iWD = getQueryString('iWD');
        // alert(iJD + '||' + iWD);
        var center = new TMap.LatLng(iJD, iWD);

        // 初始化地图
        var map = new TMap.Map('container', {
            zoom: 18, // 设置地图缩放
            center: center, // 设置地图中心点坐标，
            pitch: 0, // 俯仰度
            rotation: 0, // 旋转角度
        });

        var marker = new TMap.MultiMarker({
            map: map,
            styles: {
                // 点标记样式
                marker: new TMap.MarkerStyle({
                    width: 20, // 样式宽
                    height: 30, // 样式高
                    anchor: { x: 10, y: 30 }, // 描点位置
                }),
            },
            geometries: [
                // 点标记数据数组
                {
                    // 标记位置(纬度，经度，高度)
                    position: center,
                },
            ],
        });

    </script>
</body>
</html>

