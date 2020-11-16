﻿<%@ Page Title="学校作业信息添加" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="AddInfo_Add.aspx.cs" Inherits="School_AddInfo_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .containter {
            width: 320px;
            margin: auto;
        }

        .calender-wrap {
            -webkit-animation: clafade .3s ease;
            -moz-animation: clafade .3s ease;
            animation: clafade .3s ease;
            padding: 5px;
            background: #fff;
            width: 240px;
            box-shadow: 0 5px 10px rgba(0,0,0,0.2);
            border-radius: 4px;
            position: relative;
            font-family: "Microsoft yahei";
            position: absolute;
            z-index: 1000;
        }

        .calender-wrap {
            border: 1px solid #e2e2e2;
        }

            .calender-wrap:after {
                content: '';
                display: inline-block;
                border-left: 7px solid transparent;
                border-right: 7px solid transparent;
                border-bottom: 7px solid #eee;
                border-top: 0;
                border-bottom-color: #d7d7d7;
                position: absolute;
                left: 9px;
                top: -7px;
            }

            .calender-wrap:before {
                content: '';
                display: inline-block;
                border-left: 6px solid transparent;
                border-right: 6px solid transparent;
                border-bottom: 6px solid #ffffff;
                border-top: 0;
                position: absolute;
                left: 10px;
                top: -6px;
                z-index: 10;
            }

        .calender-caption {
            height: 35px;
            border-bottom: 1px solid #ddd;
            z-index: 2;
            background: #eee;
        }

        .calender-content {
            position: relative;
            overflow: hidden;
        }

            .calender-content:after {
                content: '';
                display: block;
                clear: both;
            }

        .calender-cell {
            cursor: pointer;
            float: left;
            width: 14.28571428%;
            height: 35px;
            text-align: center;
            line-height: 35px;
            font-size: 12px;
            color: #000;
            z-index: 1;
            border-bottom: 1px solid #eee;
        }

            .calender-cell:hover {
                background: #eee;
            }

        .calender-caption .calender-cell:hover {
            background: none;
        }

        .calender-cell-dark {
            cursor: no-drop;
            color: #b9b9b9;
        }

        .calender-caption .calender-cell {
            height: 35px;
            line-height: 35px;
            font-size: 13px;
            color: #111;
            font-weight: bold;
        }

        .calender-header {
            text-align: center;
            line-height: 35px;
            text-align: center;
            color: #888;
            padding-bottom: 4px;
            margin-bottom: 1px;
            background: #fff;
            position: relative;
            border-bottom: 1px solid #e6e6e6;
            font-size: 14px;
        }

        #calender-prev, #calender-next {
            text-decoration: none;
            display: block;
            width: 14.2857%;
            height: 35px;
            background: #fff;
            position: absolute;
            left: 0%;
            top: 0px;
            font-family: '宋体';
            font-size: 14px;
            color: #555;
        }

        #calender-prev, #calender-next {
            color: #999;
            font-size: 16px;
        }

            #calender-prev:hover, #calender-next:hover {
                background: #eee;
                border-radius: 5px;
                color: #222;
            }

        #calender-next {
            left: auto;
            right: 0%;
        }

        #calender-year, #calender-mon {
            cursor: pointer;
            padding: 2px 4px;
            border-radius: 3px;
            margin: 0 3px;
        }

            #calender-year:hover, #calender-mon:hover {
                background: #eee;
            }

        .calender-list {
            overflow: hidden;
        }

        .calender-list2, .calender-list3 {
            display: none;
        }

        .calender-year-cell, .calender-mon-cell {
            width: 32.41%;
            float: left;
            border-radius: 4px;
            text-align: center;
            font-size: 12px;
            padding: 15px 0;
            border: 1px solid #fff;
        }

            .calender-year-cell:hover, .calender-mon-cell:hover {
                background: #eee;
                cursor: pointer;
            }

            .calender-cell.active, .calender-year-cell.active, .calender-mon-cell.active {
                background: #23acf1;
                color: #fff;
            }

                .calender-cell.active:hover, .calender-year-cell.active:hover, .calender-mon-cell.active:hover {
                    background: #23acf1;
                    color: #fff;
                }

        .calender-button {
            border-top: 1px solid #eee;
            width: 100%;
            margin-top: -1px;
            padding: 7px 0px 2px 0;
            overflow: hidden;
        }

            .calender-button a {
                display: block;
                text-align: center;
                padding: 0px 15px;
                height: 25px;
                line-height: 25px;
                float: right;
                background: #23acf1;
                color: #fff;
                margin-right: 5px;
                cursor: pointer;
                margin-left: 5px;
                font-size: 12px;
                text-decoration: none;
            }

                .calender-button a:hover {
                    background: #0084c9;
                }

        .calender-wrap.year .calender-list, .calender-wrap.month .calender-list {
            display: none;
        }

        .calender-wrap.year .calender-list2 {
            display: block;
        }

        .calender-wrap.month .calender-list3 {
            display: block;
        }

        @keyframes clafade {
            0% {
                transform: scale(0.95);
                opacity: 0;
            }

            100% {
                transform: scale(1);
                opacity: 1;
            }
        }

        @-webkit-keyframes clafade {
            0% {
                -webkit-transform: scale(0.95);
                opacity: 0;
            }

            100% {
                -webkit-transform: scale(1);
                opacity: 1;
            }
        }
    </style>
    <script type="text/javascript">
        jQuery(function ($) {
            $('#FileUpload_TP').ace_file_input({
                style: 'well',
                btn_choose: '请点击选择图片',
                btn_change: null,
                no_icon: 'icon-cloud-upload',
                droppable: true,
                thumbnail: 'small',
                preview_error: function (filename, error_code) {

                }
            });
        });
    </script>

    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/">首页</a>
            </li>
            <li><a href="/School/AddInfo.aspx">学校信息</a></li>
            <li class="active"><a href="#">添加信息</a></li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>信息添加								<small><i class="icon-double-angle-right"></i>添加新的信息添加                                </small></h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">信息类别</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="DropDownList_Class" runat="server">
                            <asp:ListItem Value="0">公告信息</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">语文作业</asp:ListItem>
                            <asp:ListItem Value="2">数学作业</asp:ListItem>
                            <asp:ListItem Value="3">英语作业</asp:ListItem>
                            <asp:ListItem Value="4">其它作业</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">信息内容</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="GridView_ZY_TextBox_NContent" Height="150px" runat="server" placeholder="请输入信息内容“<br>为换行符”" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">URL链接</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox_URL" runat="server" placeholder="请输入完整的URL链接。列：http://www.x76.com.cn" class="col-xs-12 col-sm-12" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">插入图片</label>
                    <div class="col-sm-9">
                        <asp:FileUpload ID="FileUpload_TP" ClientIDMode="Static" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">开始时间</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="GridView_ZY_TextBox_TSTime" ClientIDMode="Static" runat="server" placeholder="请输入开始时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">结束时间</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="GridView_ZY_TextBox_TETime" ClientIDMode="Static" runat="server" placeholder="请输入结束时间" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">排序</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="GridView_ZY_TextBox_IPX" runat="server" placeholder="请输入排序数，数字越大越靠前" class="col-xs-12 col-sm-12"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-9">
                <asp:LinkButton usesubmitbehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="GridView_ZY_LinkButton1" class="btn btn-info" runat="server" OnClick="GridView_ZY_LinkButton1_Click"><i class="icon-ok bigger-110"></i> 保  存</asp:LinkButton>
                &nbsp; &nbsp;                        
                        <button type="button" class="btn btn-default" data-dismiss="modal"><i class="icon-remove-sign bigger-110"></i>关  闭</button>
            </div>
        </div>
    </div>
    <!-- 日期选择 -->
    <script>
        window.calender = (function (win, doc) {
            function C(str) {
                this.dom = doc.querySelector(str);
                this.s = {
                    date: [new Date().getFullYear(), new Date().getMonth() + 1, new Date().getDate()],
                    button: false,
                    format: 'yyyy年MM月dd日',
                    left: 0,
                    top: 0,
                    onload: function () { }
                }
            };
            C.prototype = {
                init: function () {
                    var t = this;
                    if (typeof arguments[0] == 'function') {
                        t.cb = arguments[0];
                    } else {
                        t.newS = arguments[0];
                        t.cb = arguments[1] || function () { }
                    };
                    t.yoff = false;
                    t.moff = false;
                    t.extend(t.s, t.newS);
                    t.nt = new Date();
                    t.nt.setFullYear(t.s.date[0]);
                    t.nt.setMonth(t.s.date[1] - 1);
                    var len = this.getDateLength(t.nt.getFullYear(), t.nt.getMonth())
                    t.nt.setDate(t.s.date[2] > len ? len : t.s.date[2]);
                    t.day = t.nt.getDate();
                    t.dom.onclick = function (ev) {
                        var e = ev || event;
                        t.create();
                        t.bind();
                        t.s.onload.call(this)
                        e.stopPropagation ? e.stopPropagation() : (e.cancelBubble = true)
                    };
                },
                hide: function () {
                    var t = this;
                    t.cb.call(t.dom, t.format(t.nt.getFullYear() + '/' + (t.nt.getMonth() + 1) + '/' + t.day + ' ' + new Date().getHours() + ':' + new Date().getMinutes() + ':' + new Date().getSeconds(), t.s.format));
                    if (g('.calender-wrap')) doc.body.removeChild(g('.calender-wrap'))
                },
                bind: function () {
                    var t = this;
                    var Content = g('.calender-content');
                    t.createDay();
                    var Prev = g('#calender-prev'),
                        Next = g('#calender-next'),
                        Year = g('#calender-year'),
                        Mon = g('#calender-mon');
                    if (t.s.button) {
                        var today = g('.calender-today');
                        var enter = g('.calender-ent');
                        today.onclick = function () {
                            t.nt.setFullYear(new Date().getFullYear());
                            t.nt.setMonth(new Date().getMonth());
                            t.nt.setDate(new Date().getDate());
                            t.s.date[2] = t.day = new Date().getDate()
                            t.createYear()
                            t.createDay()
                            t.createMon()
                        };
                        enter.onclick = function () {
                            t.hide();
                        }
                    }
                    Content.onclick = function (ev) {
                        var ev = ev || event;
                        var _target = ev.target || ev.srcElement;
                        if (!t.has(_target, 'calender-cell-dark')) {
                            var chl = this.children;
                            for (var i = 0; i < chl.length; i++) {
                                t.del(chl[i], 'active');
                            };
                            t.add(_target, 'active');
                            t.nt.setDate(_target.getAttribute('data-n'));
                            t.s.date[2] = t.day = _target.getAttribute('data-n')
                            if (!t.s.button) {
                                t.hide();
                            }
                        }
                    }
                    Prev.onclick = Next.onclick = function () {
                        var y = t.nt.getFullYear(), m = t.nt.getMonth();
                        if (t.moff) return
                        if (t.yoff) {
                            t.nt.setFullYear(this.id == "calender-prev" ? y -= 9 : y += 9)
                            t.createYear()
                        } else {
                            this.id == "calender-prev" ? m-- : m++;
                            t.nt.setDate(1);
                            t.nt.setMonth(m);
                            t.createDay()
                        }
                    }
                    Year.onclick = function () {
                        t.createYear();
                        t.yoff = true;
                        t.moff = false;
                        t.del(g('.calender-wrap'), 'month');
                        t.add(g('.calender-wrap'), 'year');
                    };
                    Mon.onclick = function () {
                        t.createMon();
                        t.moff = true;
                        t.yoff = false;
                        t.del(g('.calender-wrap'), 'year');
                        t.add(g('.calender-wrap'), 'month');
                    };
                },
                getDateLength: function (year, month) {
                    //获取某一月有多少天, month为实际月份，一月即为1
                    return new Date(year, month, 0).getDate();
                },
                getFirstDay: function (year, month) {
                    //获取某一月第一天是周几,month为实际月份，一月即为1,返回0即为周日
                    return new Date(year, month - 1, 0).getDay();
                },
                createMon: function () {
                    var t = this, html = '';
                    var m = t.nt.getMonth() + 1;
                    m = m == 0 ? 12 : m;
                    for (var i = 1; i <= 12; i++) {
                        html += '<div class="calender-mon-cell ' + (m == i ? 'active' : '') + ' ">' + (i) + '</div>';
                    };
                    g('.calender-list3').innerHTML = html;
                    var cells = doc.querySelectorAll('.calender-mon-cell');
                    for (var i2 = 0; i2 < cells.length; i2++) {
                        cells[i2].onclick = function () {
                            t.moff = false
                            t.del(g('.calender-wrap'), 'month');
                            t.nt.setDate(1)
                            t.nt.setMonth(+this.innerHTML - 1);
                            t.createDay();
                        }
                    }
                },
                createYear: function () {
                    var t = this, html = '', y = (t.nt.getFullYear());
                    var Year = g('#calender-year');
                    for (var i = 0; i < 9; i++) {
                        html += '<div class="calender-year-cell ' + ((y - (4 - i)) == y ? 'active' : '') + ' ">' + (y - (4 - i)) + '</div>';
                    }
                    Year.innerHTML = y
                    g('.calender-list2').innerHTML = html;
                    var cells = doc.querySelectorAll('.calender-year-cell');
                    for (var i2 = 0; i2 < cells.length; i2++) {
                        cells[i2].onclick = function () {
                            t.yoff = false;
                            t.del(g('.calender-wrap'), 'year');
                            t.nt.setFullYear(+this.innerHTML);
                            t.createDay();
                        }
                    }
                },
                createDay: function (n) {
                    var t = this,
                        y = t.nt.getFullYear(),
                        m = (t.nt.getMonth()) + 1;
                    g('#calender-year').innerHTML = m === 0 ? y - 1 : y;
                    g('#calender-mon').innerHTML = m === 0 ? 12 : two(m);
                    // if(t.nt.getMonth()+1 == t.s.date[1] && t.nt.getFullYear()==t.s.date[0] ){
                    //  t.nt.setDate(t.s.date[2]);
                    // };
                    var firstDay = this.getFirstDay(y, m),
                        length = this.getDateLength(y, m),
                        lastMonthLength = this.getDateLength(y, m - 1),
                        i, html = '';
                    t.day = t.s.date[2] > length ? length : t.s.date[2];
                    //循环输出月前空格
                    if (firstDay === 0) firstDay = 7;
                    for (i = 1; i < firstDay + 1; i++) {
                        html += '<div class="calender-cell calender-cell-dark">' + (lastMonthLength - firstDay + i) + '</div>';
                    }
                    //循环输出当前月所有天
                    for (i = 1; i < length + 1; i++) {
                        html += '<div data-n=' + i + ' class="calender-cell ' + (i == t.day ? 'active' : '') + '">' + i + '</div>';
                    }
                    //if(8-(length+firstDay)%7 !=8){
                    for (i = 1; i <= (41 - (length + (firstDay == 0 ? 7 : firstDay) - 1)) ; i++) {
                        html += '<div class="calender-cell calender-cell-dark">' + i + '</div>';
                    };
                    doc.querySelector('.calender-content').innerHTML = html
                },
                create: function () {
                    var t = this;
                    if (g('.calender-wrap')) doc.body.removeChild(g('.calender-wrap'))
                    var private_Day_title = ['一', '二', '三', '四', '五', '六', '日'];
                    //内容
                    var html = '<div class="calender-wrap">';
                    html += '<div id="calender-header" class="calender-header none-btn "><a id="calender-prev" href="javascript:;"><</a><a id="calender-next" href="javascript:;">></a> <span id="calender-year">2016</span>年<span id="calender-mon">10</span>月</div>'
                    //星期
                    html += '<div class="calender-list"><div class="calender-caption">';
                    for (i = 0; i < 7; i++) {
                        html += '<div class="calender-cell">' + private_Day_title[i] + '</div>';
                    };
                    html += '</div><div class="calender-content"></div>';
                    if (this.s.button) {
                        html += '<div class="calender-button"><a href="javascript:;" class="calender-ent">确定</a><a href="javascript:;" class="calender-today">今天</a></div>';
                    };
                    html += '</div><div class="calender-list calender-list2"></div><div class="calender-list calender-list3"></div>'
                    doc.body.insertAdjacentHTML("beforeend", html);
                    var wrap = g('.calender-wrap');
                    function setPosi() {
                        var _top = doc.documentElement.scrollTop || doc.body.scrollTop;
                        wrap.style.left = t.dom.getBoundingClientRect().left + t.s.left + 'px';;
                        wrap.style.top = t.dom.getBoundingClientRect().top + _top + t.dom.offsetHeight + t.s.top + 15 + 'px';
                    };
                    setPosi();
                    addEvent(window, 'resize', function () { setPosi() })
                    wrap.onclick = function (ev) {
                        var e = ev || event;
                        e.stopPropagation ? e.stopPropagation() : (e.cancelBubble = true)
                    }
                },
                format: function (da, format) {
                    var _newDate = new Date(da);
                    var WeekArr = ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'];
                    var o = {
                        'M+': _newDate.getMonth() + 1, //month 
                        'd+': _newDate.getDate(), //day 
                        'h+': _newDate.getHours(), //hour 
                        'm+': _newDate.getMinutes(), //minute 
                        's+': _newDate.getSeconds(), //second 
                        'q+': Math.floor((_newDate.getMonth() + 3) / 3), //quarter 
                        'S': _newDate.getMilliseconds(), //millisecond 
                        'E': WeekArr[_newDate.getDay()],
                        'e+': _newDate.getDay()
                    };
                    if (/(y+)/.test(format)) {
                        format = format.replace(RegExp.$1, (_newDate.getFullYear() + "").substr(4 - RegExp.$1.length));
                    };
                    for (var k in o) {
                        if (new RegExp('(' + k + ')').test(format)) {
                            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ('00' + o[k]).substr(('' + o[k]).length));
                        };
                    };
                    return format;
                },
                extend: function (n, n1) {
                    for (var i in n1) { n[i] = n1[i] };
                },
                has: function (o, n) {
                    return new RegExp('\\b' + n + '\\b').test(o.className);
                },
                add: function (o, n) {
                    if (!this.has(o, n)) o.className += ' ' + n;
                },
                del: function (o, n) {
                    if (this.has(o, n)) {
                        o.className = o.className.replace(new RegExp('(?:^|\\s)' + n + '(?=\\s|$)'), '').replace(/^\s*|\s*$/g, '');
                    };
                }
            };
            function g(str) { return doc.querySelector(str) };
            function addEvent(obj, name, fn) { obj.addEventListener ? obj.addEventListener(name, fn, false) : obj.attachEvent('on' + name, fn); };
            function two(num) { return num < 10 ? ('0' + num) : ('' + num) };
            addEvent(doc, 'click', function () {
                if (g('.calender-wrap')) doc.body.removeChild(g('.calender-wrap'))
            });
            function c(o) { return new C(o) }; return c;
        })(window, document);

        (function () {
            calender('#GridView_ZY_TextBox_TSTime').init({
                format: 'yyyy-MM-dd'
            }, function (date) {
                document.getElementById("GridView_ZY_TextBox_TSTime").value = date;
            });
            calender('#GridView_ZY_TextBox_TETime').init({
                format: 'yyyy-MM-dd'
            }, function (date) {
                document.getElementById("GridView_ZY_TextBox_TETime").value = date;
            });
        })();

    </script>

</asp:Content>

