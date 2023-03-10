﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="WeUi_Default2" %>


<!DOCTYPE html>
<html lang="zh-cmn-Hans">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0,viewport-fit=cover">
    <meta name="wechat-enable-text-zoom-em" content="true">
    <title>WeUI</title>
    <link rel="stylesheet" href="css/weui.css">
    <link rel="stylesheet" href="css/example.css">
</head>
<body ontouchstart="">
    <script type="text/javascript">window.__wxWebEnv && (document.body.style.webkitTextSizeAdjust = JSON.parse(window.__wxWebEnv.getEnv()).fontScale + "%")</script>
    <span aria-hidden="true" id="js_a11y_comma" class="weui-hidden_abs">，</span><div role="alert" class="weui-toptips weui-toptips_warn js_tooltips">错误提示</div>
    <div class="container" id="container"></div>
    <script type="text/html" id="tpl_home">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">
                    <img src="images/logo.png" alt="WeUI" height="21px" />
                </h1>
                <p class="page__desc">WeUI 是一套同微信原生视觉体验一致的基础样式库，由微信官方设计团队为微信内网页和微信小程序量身设计，令用户的使用感知更加统一。</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <ul role="menubar" aria-label="WeUI组件列表">
                    <li role="none">
                        <div class="weui-flex js_category" aria-haspopup="true" aria-expanded="false">
                            <p class="weui-flex__item">表单</p>
                            <img src="images/icon_nav_form.png" alt=" 展开" role="button">
                        </div>
                        <div class="page__category js_categoryInner" role="menu" aria-hidden="true">
                            <div class="weui-cells page__category-content">
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="button" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Button</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <!--
                        <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="input" href="javascript:">
                            <div class="weui-cell__bd">
                                <p>Input</p>
                            </div>
                            <div class="weui-cell__ft"></div>
                        </a>
                        -->
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="form" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Form</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="list" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>List</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="slider" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Slider</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="uploader" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Uploader</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li role="none">
                        <div class="weui-flex js_category" aria-haspopup="true" aria-expanded="false">
                            <p class="weui-flex__item">基础组件</p>
                            <img src="images/icon_nav_layout.png" alt=" 展开" role="button">
                        </div>
                        <div class="page__category js_categoryInner" role="menu" aria-hidden="true">
                            <div class="weui-cells page__category-content">
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="article" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Article</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="badge" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Badge</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="flex" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Flex</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="footer" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Footer</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="gallery" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Gallery</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="grid" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Grid</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="icons" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Icons</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="loading" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Loading</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="loadmore" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Loadmore</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="panel" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Panel</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="preview" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Preview</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="progress" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Progress</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="steps" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Steps</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li role="none">
                        <div class="weui-flex js_category" aria-haspopup="true" aria-expanded="false">
                            <p class="weui-flex__item">操作反馈</p>
                            <img src="images/icon_nav_feedback.png" alt=" 展开" role="button">
                        </div>
                        <div class="page__category js_categoryInner" role="menu" aria-hidden="true">
                            <div class="weui-cells page__category-content">
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="actionsheet" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Actionsheet</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="dialog" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Dialog</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="half-screen-dialog" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Half-screen Dialog</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="msg" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Msg</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="picker" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Picker</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="toast" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Toast</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="top-tips" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>TopTips</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li role="none">
                        <div class="weui-flex js_category" aria-haspopup="true" aria-expanded="false">
                            <p class="weui-flex__item">导航相关</p>
                            <img src="images/icon_nav_nav.png" alt=" 展开" role="button">
                        </div>
                        <div class="page__category js_categoryInner" role="menu" aria-hidden="true">
                            <div class="weui-cells page__category-content">
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="navbar" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Navbar</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="tabbar" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Tabbar</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li role="none">
                        <div class="weui-flex js_category" aria-haspopup="true" aria-expanded="false">
                            <p class="weui-flex__item">搜索相关</p>
                            <img src="images/icon_nav_search.png" alt=" 展开" role="button">
                        </div>
                        <div class="page__category js_categoryInner" role="menu" aria-hidden="true">
                            <div class="weui-cells page__category-content">
                                <a class="weui-cell weui-cell_active weui-cell_access js_item" role="menuitem" data-id="searchbar" href="javascript:">
                                    <div class="weui-cell__bd">
                                        <p>Search Bar</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                            </div>
                        </div>
                    </li>
                    <li role="none">
                        <div class="weui-flex js_item" role="menuitem" data-id="layers" role="menuitem">
                            <p class="weui-flex__item">层级规范</p>
                            <img src="images/icon_nav_z-index.png" alt=" 展开" role="button">
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            function setFoot() {
                var $foot = $('.page__ft');
                if ($foot.length > 0) {
                    $foot.removeClass('j_bottom');
                    var winH = $(window).height();
                    if ($foot.offsetTop + $foot.offsetHeight < winH) {
                        $foot.addClass('j_bottom');
                    }
                }
            }
            var winH = $(window).height();
            var categorySpace = 10;
            function expandMenu() {
                setFoot();
                var $this = $(this),
                    $inner = $this.next('.js_categoryInner'),
                    $page = $this.parents('.page'),
                    $parent = $(this).parent('li');
                var innerH = $inner.data('height');

                if (!innerH) {
                    $inner.css('height', 'auto');
                    innerH = $inner.height();
                    $inner.removeAttr('style');
                    $inner.data('height', innerH);
                }

                if ($parent.hasClass('js_show')) {
                    $parent.removeClass('js_show');
                    $this.attr('aria-expanded', 'false');
                    $this.children('img').attr('alt', ' 展开');
                    $inner.attr('aria-hidden', 'true');
                    $('.js_item', $(this).siblings()).attr('tabindex', '-1');
                } else {
                    $parent.siblings().removeClass('js_show');
                    $parent.siblings().children('.js_category').attr('aria-expanded', 'false');
                    $parent.siblings().children('.js_category img').attr('alt', ' 展开');
                    $parent.siblings().children('.js_categoryInner').attr('aria-hidden', 'true');
                    $('.js_item', $parent.siblings().children('.js_categoryInner')).attr('tabindex', '-1');

                    $parent.addClass('js_show');
                    $this.attr('aria-expanded', 'true');
                    $this.children('img').attr('alt', ' 收起');
                    $inner.attr('aria-hidden', 'false');
                    $('.js_item', $(this).siblings()).attr('tabindex', '0');

                    if (this.offsetTop + this.offsetHeight + innerH > $page.scrollTop() + winH) {
                        var scrollTop = this.offsetTop + this.offsetHeight + innerH - winH + categorySpace;

                        if (scrollTop > this.offsetTop) {
                            scrollTop = this.offsetTop - categorySpace;
                        }

                        $page.scrollTop(scrollTop);
                    }
                }

                var winH = $(window).height();
                var $foot = $('body').find('.page__ft');
                if ($foot.length < 1) return;

                if ($foot.position().top + $foot.height() < winH) {
                    $foot.addClass('j_bottom');
                } else {
                    $foot.removeClass('j_bottom');
                }
            }

            $('.js_category').attr('tabindex', '0');
            $('.js_item').attr('tabindex', '0');
            $('.js_item', $('.js_category').siblings()).attr('tabindex', '-1');

            $('.js_item').on('click', function () {
                var id = $(this).data('id');
                window.pageManager.go(id);
            });
            $('.js_category').on('click', function () {
                $(this).attr('aria-live', 'assertive');
                expandMenu.call(this);
            });
            $('.js_category').on('keydown', function (event) {
                if (event.keyCode === 13) {
                    expandMenu.call(this);
                }
            });
        });</script>
    <script type="text/html" id="tpl_layers">
        <div class="page">
            <div class="page__hd">
                <div class="j_info page__info" data-for="normal">
                    <h2 class="page__title">WeUI页面层级</h2>
                    <p class="page__desc">用于规范WeUI页面元素所属层级、层级顺序及组合规范。</p>
                </div>
                <div class="j_info page__info" data-for="popout" style="display: none;">
                    <h2 class="page__title">Popout</h2>
                    <p class="page__desc">弹出层，作为内容层和导航层的补充，用于承载弹窗通知、操作菜单、菜单、成功或加载中等状态的Toast，表单报错提示等弹出内容。</p>
                </div>
                <div class="j_info page__info" data-for="mask" style="display: none;">
                    <h2 class="page__title">Mask</h2>
                    <p class="page__desc">蒙层，配合Popout层使用，用于锁定内容层和导航层操作，不单独使用。</p>
                </div>
                <div class="j_info page__info" data-for="navigation" style="display: none;">
                    <h2 class="page__title">Navigation</h2>
                    <p class="page__desc">导航层，位于内容层之上，在用户滑动内容层时可保持位置不动，通常用于承载导航栏等需要固定在页面的元素。</p>
                </div>
                <div class="j_info page__info" data-for="content" style="display: none;">
                    <h2 class="page__title">Content</h2>
                    <p class="page__desc">内容层，承载页面主要内容。</p>
                </div>
            </div>
            <div class="page__bd">
                <div class="layers j_layers">
                    <div data-name="popout" class="j_pic j_layer layers__layer layers__layer_popout"><span>Popout</span></div>
                    <div data-name="mask" class="j_pic j_layer layers__layer layers__layer_mask"><span>Mask</span></div>
                    <div data-name="navigation" class="j_pic j_layer layers__layer layers__layer_navigation"><span>Navigation</span></div>
                    <div data-name="content" class="j_pic j_layer layers__layer layers__layer_content"><span>Content</span></div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $layers = $(".layers__layer"), $infos = $(".j_info"),
                hideTimeout;

            function showInfo(name) {
                $infos.filter("[data-for='" + name + "']").show().siblings().hide();
            }
            function hideIfLayerShowing() {
                if ($layers.filter(".j_transform").length != $layers.length) { // 展示中
                    showInfo("normal");
                    $layers.addClass("j_transform");

                    clearTimeout(hideTimeout);
                    hideTimeout = setTimeout(function () {
                        $layers.removeClass("j_hide");
                    }, 300);
                    return true;
                }
                return false;
            }
            $layers.on("transitionend webkitTransitionend", function () {
                var that = this;
                if (that.classList.contains("j_transform")) {
                    setTimeout(function () {
                        that.classList.remove("j_pic");
                    }, 500);
                } else {
                    that.classList.add("j_pic");
                }
            });
            setTimeout(function () {
                $layers.addClass("j_transform");

                $(".j_layer").on("click", function (e) {
                    if (hideIfLayerShowing()) return;

                    var target = this;
                    if (target.classList.contains("j_layer")) {
                        clearTimeout(hideTimeout);

                        var name;
                        target = $(target);
                        name = target.data("name");
                        showInfo(name);

                        target.removeClass("j_transform").siblings().addClass("j_hide");
                    }
                });
            }, 500);
        });</script>
    <script type="text/html" id="tpl_button">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Button</h1>
                <p class="page__desc">按钮</p>
            </div>
            <div class="page__bd">
                <a href="#button_default" role="button" class="weui-btn weui-btn_default">普通型</a>
                <a href="#button_bottom_fixed" role="button" class="weui-btn weui-btn_default">底部悬浮型</a>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_button_default">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Button</h1>
                <p class="page__desc">按钮</p>
            </div>
            <div class="page__bd">

                <div class="button-sp-area">
                    <a href="javascript:" role="button" class="weui-btn weui-btn_primary">主要操作</a>
                    <a href="javascript:" role="button" title="正在操作" class="weui-btn weui-btn_primary weui-btn_loading"><i class="weui-mask-loading"></i>主要操作</a>
                    <a href="javascript:" role="button" title="正在操作" class="weui-btn weui-btn_primary weui-btn_loading"><i class="weui-mask-loading"></i></span>主要操作</a>
                    <a href="javascript:" role="button" aria-disabled="true" disabled class="weui-btn weui-btn_disabled weui-btn_primary">主要操作</a>
                    <a href="javascript:" role="button" class="weui-btn weui-btn_default">次要操作</a>
                    <a href="javascript:" role="button" title="正在操作" class="weui-btn weui-btn_default weui-btn_loading"><i class="weui-mask-loading"></i>次要操作</a>
                    <a href="javascript:" role="button" aria-disabled="true" disabled class="weui-btn weui-btn_disabled weui-btn_default">次要操作</a>
                    <a href="javascript:" role="button" class="weui-btn weui-btn_warn">警示操作</a>
                    <a href="javascript:" role="button" title="正在操作" class="weui-btn weui-btn_warn weui-btn_loading"><i class="weui-mask-loading"></i>警示操作</a>
                    <a href="javascript:" role="button" aria-disabled="true" disabled class="weui-btn weui-btn_disabled weui-btn_warn">警示操作</a>
                </div>


                <div class="button-sp-area cell">
                    <a href="javascript:" role="button" class="weui-btn_cell weui-btn_cell-default">普通行按钮</a>
                    <a href="javascript:" role="button" class="weui-btn_cell weui-btn_cell-primary">强调行按钮</a>
                    <a href="javascript:" role="button" class="weui-btn_cell weui-btn_cell-primary">
                        <img alt="icon" class="weui-btn_cell__icon" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=">
                        强调行按钮
                    </a>
                    <a href="javascript:" role="button" class="weui-btn_cell weui-btn_cell-warn">警示行按钮</a>
                </div>

                <div class="button-sp-area">
                    <a href="javascript:" role="button" class="weui-btn weui-btn_mini weui-btn_primary weui-wa-hotarea">按钮</a>
                    <a href="javascript:" role="button" class="weui-btn weui-btn_mini weui-btn_default weui-wa-hotarea">按钮</a>
                    <a href="javascript:" role="button" class="weui-btn weui-btn_mini weui-btn_warn weui-wa-hotarea">按钮</a>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_button_bottom_fixed">
        <div class="page">
            <div class="weui-bottom-fixed-opr-page" id="js_wrp">
                <div class="weui-bottom-fixed-opr-page__content">
                    <div class="weui-bottom-fixed-opr-demo">Dolor tempora dolore aperiam fuga necessitatibus? Odio atque tempora deleniti voluptates voluptatem. Dolorem earum voluptas blanditiis labore quisquam? Quibusdam nesciunt consequatur aliquam ea corrupti animi, itaque consequatur neque? At porroSit nemo aliquid quas error doloremque Reiciendis ratione repellendus quae sit commodi amet architecto? Aut officiis aliquam fugit nulla at necessitatibus Optio totam quibusdam laboriosam aperiam libero! Officiis reiciendis Elit quaerat sed vero perferendis architecto consequatur. Consequuntur ad illum dolore ut accusamus. Cum possimus odit sequi quaerat beatae, eveniet. Rerum dolore ipsam quia consectetur iste Veniam mollitia dolores tempore? Dolor tempora dolore aperiam fuga necessitatibus? Odio atque tempora deleniti voluptates voluptatem. Dolorem earum voluptas blanditiis labore quisquam? Quibusdam nesciunt consequatur aliquam ea corrupti animi, itaque consequatur neque? At porroSit nemo aliquid quas error doloremque Reiciendis ratione repellendus quae sit commodi amet architecto? Aut officiis aliquam fugit nulla at necessitatibus Optio totam quibusdam laboriosam aperiam libero! Officiis reiciendis Elit quaerat sed vero perferendis architecto consequatur. Consequuntur ad illum dolore ut accusamus. Cum possimus odit sequi quaerat beatae, eveniet. Rerum dolore ipsam quia consectetur iste Veniam mollitia dolores tempore? </div>
                </div>
                <div class="weui-bottom-fixed-opr" id="js_opr">
                    <a href="javascript:;" role="button" class="weui-btn weui-btn_primary" id="js_btn">阅读并同意</a>
                    <a href="javascript:;" role="button" class="weui-btn weui-btn_default">取消</a>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        var btn = document.getElementById('js_btn');
        var wrp = document.getElementById('js_wrp');
        const btnHeight = 48;

        try {
            document.body.style.webkitTextSizeAdjust = JSON.parse(window.__wxWebEnv.getEnv()).fontScale + '%';
        } catch (e) {
            console.warn(e);
        }
        wrp.style.visibility = 'hidden';

        window.addEventListener('switched', function (e) {
            if (btn.offsetHeight > 48) {
                wrp.classList.add('weui-bottom-fixed-opr-page_btn-wrap');
            }
            wrp.style.visibility = 'visible';
        });

        function wxReady(callback) {
            if (
                typeof WeixinJSBridge === 'object' &&
                typeof window.WeixinJSBridge.invoke === 'function'
            ) {
                callback()
            } else {
                document.addEventListener('WeixinJSBridgeReady', callback, false)
            }
        }
        wxReady(function () {
            WeixinJSBridge.on('menu:setfont', function (res) {
                // ios
                document.body.style.webkitTextSizeAdjust = res.fontScale + '%';
                // android
                WeixinJSBridge.invoke("setFontSizeCallback", {
                    fontSize: res.fontSize
                });

                if (btn.offsetHeight > 48) {
                    wrp.classList.add('weui-bottom-fixed-opr-page_btn-wrap');
                } else {
                    wrp.classList.remove('weui-bottom-fixed-opr-page_btn-wrap');
                }


            });
        });</script>
    <script type="text/html" id="tpl_list">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">List</h1>
                <p class="page__desc">列表</p>
            </div>
            <div class="page__bd">
                <div class="weui-cells__title">带说明的列表项</div>
                <div class="weui-cells">
                    <div role="option" class="weui-cell ">
                        <div class="weui-cell__bd">
                            <p>标题文字</p>
                        </div>
                        <div class="weui-cell__ft">说明文字</div>
                    </div>
                    <div class="weui-cell  weui-cell_swiped">
                        <div role="option" class="weui-cell__bd" style="transform: translateX(-68px);">
                            <div class="weui-cell ">
                                <div class="weui-cell__bd">
                                    <p>标题文字</p>
                                </div>
                                <div class="weui-cell__ft">说明文字</div>
                            </div>
                        </div>
                        <div class="weui-cell__ft">
                            <a role="button" class="weui-swiped-btn weui-swiped-btn_warn" href="javascript:">删除</a>
                        </div>
                    </div>
                </div>

                <div class="weui-cells__title">带图标、说明的列表项</div>
                <div class="weui-cells">
                    <div role="option" class="weui-cell  weui-cell_example">
                        <div class="weui-cell__hd">
                            <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="" style="width: 20px; margin-right: 16px; display: block;">
                        </div>
                        <div class="weui-cell__bd">
                            <p>标题文字</p>
                        </div>
                        <div class="weui-cell__ft">说明文字</div>
                    </div>
                    <div role="option" class="weui-cell  weui-cell_example">
                        <div class="weui-cell__hd">
                            <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="" style="width: 20px; margin-right: 16px; display: block;">
                        </div>
                        <div class="weui-cell__bd">
                            <p>标题文字</p>
                        </div>
                        <div class="weui-cell__ft">说明文字</div>
                    </div>
                </div>

                <div class="weui-cells__title">带跳转的列表项</div>
                <div class="weui-cells">
                    <a class="weui-cell  weui-cell_access" href="javascript:">
                        <span class="weui-cell__bd">
                            <span>cell standard</span>
                            <div class="weui-cell__desc">副标题</div>
                        </span>
                        <span class="weui-cell__ft"></span>
                    </a>
                    <a class="weui-cell  weui-cell_access" href="javascript:">
                        <span class="weui-cell__bd">
                            <span>cell standard</span>
                        </span>
                        <span class="weui-cell__ft"></span>
                    </a>
                </div>

                <div class="weui-cells__title">带说明、跳转的列表项</div>
                <div class="weui-cells">
                    <a aria-labelledby="js_cell_tl1_tips js_cell_tl1_link" class="weui-cell weui-cell_access" href="javascript:">
                        <span class="weui-cell__bd" id="js_cell_tl1_tips" aria-hidden="true">
                            <span>cell standard</span>
                        </span>
                        <span class="weui-cell__ft" aria-hidden="true" id="js_cell_tl1_link">说明文字</span>
                    </a>
                    <a aria-labelledby="js_cell_tl2_tips js_cell_tl2_link" class="weui-cell  weui-cell_access" href="javascript:">
                        <span class="weui-cell__bd" aria-hidden="true" id="js_cell_tl2_tips">
                            <span>cell standard</span>
                        </span>
                        <span class="weui-cell__ft" aria-hidden="true" id="js_cell_tl2_link">说明文字</span>
                    </a>

                </div>

                <div class="weui-cells__title">带图标、说明、跳转的列表项</div>
                <div class="weui-cells">

                    <a aria-labelledby="js_cell_itl1_hd js_cell_itl1_bd js_cell_itl1_ft" class="weui-cell weui-cell_access weui-cell_example" href="javascript:">
                        <span class="weui-cell__hd" id="js_cell_itl1_hd" aria-hidden="true">
                            <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="头像" style="width: 20px; margin-right: 16px; display: block;"></span>
                        <span class="weui-cell__bd" id="js_cell_itl1_bd" aria-hidden="true">
                            <span>cell standard</span>
                        </span>
                        <span class="weui-cell__ft" id="js_cell_itl1_ft" aria-hidden="true">说明文字</span>
                    </a>
                    <a aria-labelledby="js_cell_itl2_hd js_cell_itl2_bd js_cell_itl2_ft" class="weui-cell weui-cell_access weui-cell_example" href="javascript:">
                        <span class="weui-cell__hd" id="js_cell_itl2_hd" aria-hidden="true">
                            <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="" style="width: 20px; margin-right: 16px; display: block;"></span>
                        <span class="weui-cell__bd" id="js_cell_itl2_bd" aria-hidden="true">
                            <span>cell standard</span>
                        </span>
                        <span class="weui-cell__ft" id="js_cell_itl2_ft" aria-hidden="true">说明文字</span>
                    </a>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_input">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Input</h1>
                <p class="page__desc">表单输入</p>
            </div>
            <div class="page__bd">
                <div class="weui-cells__title">单选列表项</div>
                <div class="weui-cells weui-cells_radio">
                    <label class="weui-cell weui-cell_active weui-check__label" for="x11">
                        <div class="weui-cell__bd">
                            <p>cell standard</p>
                        </div>
                        <div class="weui-cell__ft">
                            <input type="radio" class="weui-check" name="radio1" id="x11" />
                            <span class="weui-icon-checked"></span>
                        </div>
                    </label>
                    <label class="weui-cell weui-cell_active weui-check__label" for="x12">

                        <div class="weui-cell__bd">
                            <p>cell standard</p>
                        </div>
                        <div class="weui-cell__ft">
                            <input type="radio" name="radio1" class="weui-check" id="x12" checked="checked" />
                            <span class="weui-icon-checked"></span>
                        </div>
                    </label>
                    <a href="javascript:" class="weui-cell weui-cell_active weui-cell_link">
                        <div class="weui-cell__bd">添加更多</div>
                    </a>
                </div>
                <div class="weui-cells__title">复选列表项</div>
                <div class="weui-cells weui-cells_checkbox">
                    <label class="weui-cell weui-cell_active weui-check__label" for="s11">
                        <div class="weui-cell__hd">
                            <input type="checkbox" class="weui-check" name="checkbox1" id="s11" checked="checked" />
                            <i class="weui-icon-checked"></i>
                        </div>
                        <div class="weui-cell__bd">
                            <p>standard is dealt for u.</p>
                        </div>
                    </label>
                    <label class="weui-cell weui-cell_active weui-check__label" for="s12">
                        <div class="weui-cell__hd">
                            <input type="checkbox" name="checkbox1" class="weui-check" id="s12" />
                            <i class="weui-icon-checked"></i>
                        </div>
                        <div class="weui-cell__bd">
                            <p>standard is dealicient for u.</p>
                        </div>
                    </label>
                    <a href="javascript:" class="weui-cell weui-cell_active weui-cell_link">
                        <div class="weui-cell__bd">添加更多</div>
                    </a>
                </div>

                <div class="weui-cells__title">表单</div>
                <div class="weui-cells weui-cells_form">
                    <div class="weui-cell weui-cell_active">
                        <div class="weui-cell__hd">
                            <label class="weui-label">qq</label>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入qq号" />
                        </div>
                    </div>
                    <div class="weui-cell weui-cell_active weui-cell_vcode">
                        <div class="weui-cell__hd">
                            <label class="weui-label">手机号</label>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="tel" placeholder="请输入手机号" />
                        </div>
                        <div class="weui-cell__ft">
                            <button class="weui-vcode-btn">获取验证码</button>
                        </div>
                    </div>
                    <div class="weui-cell weui-cell_active">
                        <div class="weui-cell__hd">
                            <label for="" class="weui-label">日期</label>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="date" value="" />
                        </div>
                    </div>
                    <div class="weui-cell weui-cell_active">
                        <div class="weui-cell__hd">
                            <label for="" class="weui-label">时间</label>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="datetime-local" value="" placeholder="" />
                        </div>
                    </div>
                    <div class="weui-cell weui-cell_active weui-cell_vcode">
                        <div class="weui-cell__hd">
                            <label class="weui-label">验证码</label>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="number" placeholder="请输入验证码" />
                        </div>
                        <div class="weui-cell__ft">
                            <img class="weui-vcode-img" src="images/vcode.jpg" />
                        </div>
                    </div>
                </div>
                <div class="weui-cells__tips">底部说明文字底部说明文字</div>

                <div class="weui-cells__title">表单报错</div>
                <div class="weui-cells weui-cells_form">
                    <div class="weui-cell weui-cell_active weui-cell_warn">
                        <div class="weui-cell__hd">
                            <label for="" class="weui-label">卡号</label>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="number" pattern="[0-9]*" value="weui input error" placeholder="请输入卡号" />
                        </div>
                        <div class="weui-cell__ft">
                            <i class="weui-icon-warn"></i>
                        </div>
                    </div>
                </div>


                <div class="weui-cells__title">开关</div>
                <div class="weui-cells weui-cells_form">
                    <div class="weui-cell weui-cell_active weui-cell_switch">
                        <div class="weui-cell__bd">标题文字</div>
                        <div class="weui-cell__ft">
                            <input class="weui-switch" type="checkbox" />
                        </div>
                    </div>
                    <div class="weui-cell weui-cell_active weui-cell_switch">
                        <div class="weui-cell__bd">兼容IE Edge的版本</div>
                        <div class="weui-cell__ft">
                            <label for="switchCP" class="weui-switch-cp">
                                <input id="switchCP" class="weui-switch-cp__input" type="checkbox" checked="checked" />
                                <div class="weui-switch-cp__box"></div>
                            </label>
                        </div>
                    </div>
                </div>

                <div class="weui-cells__title">文本框</div>
                <div class="weui-cells">
                    <div class="weui-cell weui-cell_active">
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="text" placeholder="请输入文本" />
                        </div>
                    </div>
                </div>

                <div class="weui-cells__title">文本域</div>
                <div class="weui-cells weui-cells_form">
                    <div class="weui-cell weui-cell_active">
                        <div class="weui-cell__bd">
                            <textarea class="weui-textarea" placeholder="请输入文本" rows="3"></textarea>
                            <div class="weui-textarea-counter"><span>0</span>/200</div>
                        </div>
                    </div>
                </div>

                <div class="weui-cells__title">选择</div>
                <div class="weui-cells">

                    <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-before">
                        <div class="weui-cell__hd">
                            <select class="weui-select" name="select2">
                                <option value="1">+86</option>
                                <option value="2">+80</option>
                                <option value="3">+84</option>
                                <option value="4">+87</option>
                            </select>
                        </div>
                        <div class="weui-cell__bd">
                            <input class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入号码" />
                        </div>
                    </div>
                </div>
                <div class="weui-cells__title">选择</div>
                <div class="weui-cells">
                    <div class="weui-cell weui-cell_active weui-cell_select">
                        <div class="weui-cell__bd">
                            <select class="weui-select" name="select1">
                                <option selected="" value="1">微信号</option>
                                <option value="2">QQ号</option>
                                <option value="3">Email</option>
                            </select>
                        </div>
                    </div>
                    <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-after">
                        <div class="weui-cell__hd">
                            <label for="" class="weui-label">国家/地区</label>
                        </div>
                        <div class="weui-cell__bd">
                            <select class="weui-select" name="select2">
                                <option value="1">中国</option>
                                <option value="2">美国</option>
                                <option value="3">英国</option>
                            </select>
                        </div>
                    </div>
                </div>

                <label for="weuiAgree" class="weui-agree">
                    <input id="weuiAgree" type="checkbox" class="weui-agree__checkbox" />
                    <span class="weui-agree__text">阅读并同意<a href="javascript:">《相关条款》</a>
                    </span>
                </label>

                <div class="weui-btn-area">
                    <a role="button" class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">确定</a>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $tooltips = $('.js_tooltips');

            $('#showTooltips').on('click', function () {
                if ($tooltips.css('display') != 'none') return;

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $tooltips.css('display', 'block');
                setTimeout(function () {
                    $tooltips.css('display', 'none');
                }, 2000);
            });
        });</script>
    <script type="text/html" id="tpl_form">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Form</h1>
                <p class="page__desc">表单页</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="#form_page" role="button" class="weui-btn weui-btn_default">表单结构</a>
                <a style="display: none;" href="#form_primary" role="button" class="weui-btn weui-btn_default">反色表单</a>
                <a href="#form_input_status" role="button" class="weui-btn weui-btn_default">输入框状态</a>
                <a href="#form_vcode" role="button" class="weui-btn weui-btn_default">验证码</a>
                <a href="#form_checkbox" role="button" class="weui-btn weui-btn_default">复选框</a>
                <a href="#form_access" role="button" class="weui-btn weui-btn_default">跳转列表项</a>
                <a href="#form_radio" role="button" class="weui-btn weui-btn_default">单选框</a>
                <a href="#form_switch" role="button" class="weui-btn weui-btn_default">开关</a>
                <a href="#form_select" role="button" class="weui-btn weui-btn_default">原生选择框</a>
                <a href="#form_select_primary" role="button" class="weui-btn weui-btn_default">模拟选择框</a>
                <a href="#form_textarea" role="button" class="weui-btn weui-btn_default">文本域</a>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_form_primary">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">表单结构</h2>
                    <div class="weui-form__desc">展示表单页面的信息结构样式, 分别由头部区域/控件区域/提示区域/操作区域和底部信息区域组成。</div>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form weui-cells__group_form-primary">
                        <div class="weui-cells__title">表单组标题</div>
                        <div class="weui-cells">
                            <label for="js_input1" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd"><span class="weui-label">微信号</span></div>
                                <div class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" placeholder="填写本人微信号" />
                                </div>
                            </label>
                            <label for="js_input2" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd"><span class="weui-label">昵称</span></div>
                                <div class="weui-cell__bd">
                                    <input id="js_input2" class="weui-input" placeholder="填写本人微信号的昵称" />
                                </div>
                            </label>
                        </div>
                    </div>
                    <div class="weui-cells__group weui-cells__group_form weui-cells__group_form-primary">
                        <div class="weui-cells__title">表单组标题</div>
                        <div class="weui-cells">
                            <div class="weui-cell weui-cell_active weui-cell_select">
                                <div class="weui-cell__bd">
                                    <select class="weui-select" name="select1">
                                        <option selected="" value="1">微信号</option>
                                        <option value="2">QQ号</option>
                                        <option value="3">Email</option>
                                    </select>
                                </div>
                            </div>
                            <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-before">
                                <div class="weui-cell__hd">
                                    <select class="weui-select" name="select2">
                                        <option value="1">+86</option>
                                        <option value="2">+80</option>
                                        <option value="3">+84</option>
                                        <option value="4">+87</option>
                                    </select>
                                </div>
                                <label for="js_input1" class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </label>
                            </div>
                            <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-after">
                                <div class="weui-cell__hd">
                                    <label for="" class="weui-label">国家</label>
                                </div>
                                <div class="weui-cell__bd">
                                    <select class="weui-select" name="select2">
                                        <option value="1">中国</option>
                                        <option value="2">美国</option>
                                        <option value="3">英国</option>
                                    </select>
                                </div>
                            </div>
                            <label for="js_input3" class="weui-cell weui-cell_active weui-cell_wrap">
                                <div class="weui-cell__hd">
                                    <span class="weui-label">手机号</span>
                                </div>
                                <div class="weui-cell__bd">
                                    <span class="weui-cell__control">+86</span>
                                    <input id="js_input3" class="weui-input  weui-cell__control weui-cell__control_flex" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </div>
                            </label>
                        </div>
                    </div>
                    <div class="weui-cells__group weui-cells__group_form weui-cells__group_form-primary">
                        <div class="weui-cells">
                            <label for="cb" class="weui-cell weui-cell_active weui-cell_switch">
                                <div class="weui-cell__bd" id="cb_txt" aria-hidden="true">标题文字</div>
                                <div class="weui-cell__ft">
                                    <input aria-labelledby="cb_txt" id="cb" class="weui-switch" type="checkbox" />
                                </div>
                            </label>
                        </div>
                    </div>
                    <div class="weui-cells__group weui-cells__group_form weui-cells__group_form-primary">
                        <div class="weui-cells">
                            <a class="weui-cell weui-cell_access" href="javascript:">
                                <div class="weui-cell__bd">
                                    <p>cell standard</p>
                                </div>
                                <div class="weui-cell__ft"></div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="weui-form__tips-area">
                    <p class="weui-form__tips">
                        表单页提示，居中对齐
                    </p>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" disabled aria-disabled="true" class="weui-btn weui-btn_primary weui-btn_disabled" href="javascript:" id="showTooltips">确定</a>
                </div>
                <div class="weui-form__tips-area">
                    <p class="weui-form__tips">
                        表单页提示，居中对齐
                    </p>
                </div>
                <div class="weui-form__extra-area">
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:" class="weui-footer__link">底部链接文本</a>
                        </p>
                        <p class="weui-footer__text">Copyright © 2008-2019 weui.io</p>
                    </div>
                </div>
            </div>
            <div role="alert" id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $toast = $('#js_toast');
            var $input = $('#js_input');
            $input.on('input', function () {
                if ($input.val()) {
                    $('#showTooltips').removeClass('weui-btn_disabled');
                    $('#showTooltips').attr('aria-disabled', 'false');
                    $('#showTooltips').removeAttr('disabled');
                } else {
                    $('#showTooltips').addClass('weui-btn_disabled');
                    $('#showTooltips').addClass('weui-btn_disabled');
                    $('#showTooltips').attr('aria-disabled', 'true');
                    $('#showTooltips').addAttr('disabled');
                }
            });
            $('#showTooltips').on('click', function () {
                if ($(this).hasClass('weui-btn_disabled')) return;

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $toast.attr('aria-live', 'assertive');
                $toast.fadeIn(100);
                setTimeout(function () {
                    $toast.attr('aria-live', 'off');
                    $toast.fadeOut(100);
                }, 2000);
            });

            //$('.weui-cell').on('click', function(){
            //  $(this).find('input').trigger('focus');
            //});
        });</script>
    <script type="text/html" id="tpl_form_page">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">表单结构</h2>
                    <div class="weui-form__desc">展示表单页面的信息结构样式, 分别由头部区域/控件区域/提示区域/操作区域和底部信息区域组成。</div>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells__title">表单组标题</div>
                        <div class="weui-cells">
                            <label for="js_input1" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd"><span class="weui-label">微信号</span></div>
                                <div class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" placeholder="填写本人微信号" />
                                </div>
                            </label>
                            <label for="js_input2" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd"><span class="weui-label">昵称</span></div>
                                <div class="weui-cell__bd">
                                    <input id="js_input2" class="weui-input" placeholder="填写本人微信号的昵称" />
                                </div>
                            </label>
                            <label for="js_input3" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd">
                                    <span class="weui-label">联系电话</span><div class="weui-cell__desc">副标题</div>
                                </div>
                                <div class="weui-cell__bd">
                                    <input id="js_input3" class="weui-input" placeholder="填写绑定的电话号码" type="number" pattern="[0-9]*" />
                                </div>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="weui-form__tips-area">
                    <p class="weui-form__tips">
                        表单页提示，居中对齐
                    </p>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" disabled aria-disabled="true" class="weui-btn weui-btn_primary weui-btn_disabled" href="javascript:" id="showTooltips">确定</a>
                </div>
                <div class="weui-form__tips-area">
                    <p class="weui-form__tips">
                        表单页提示，居中对齐
                    </p>
                </div>
                <div class="weui-form__extra-area">
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:" class="weui-footer__link">底部链接文本</a>
                        </p>
                        <p class="weui-footer__text">Copyright © 2008-2019 weui.io</p>
                    </div>
                </div>
            </div>
            <div role="alert" id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $toast = $('#js_toast');
            var $input = $('#js_input');
            $input.on('input', function () {
                if ($input.val()) {
                    $('#showTooltips').removeClass('weui-btn_disabled');
                    $('#showTooltips').attr('aria-disabled', 'false');
                    $('#showTooltips').removeAttr('disabled');
                } else {
                    $('#showTooltips').addClass('weui-btn_disabled');
                    $('#showTooltips').addClass('weui-btn_disabled');
                    $('#showTooltips').attr('aria-disabled', 'true');
                    $('#showTooltips').addAttr('disabled');
                }
            });
            $('#showTooltips').on('click', function () {
                if ($(this).hasClass('weui-btn_disabled')) return;

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $toast.attr('aria-live', 'assertive');
                $toast.fadeIn(100);
                setTimeout(function () {
                    $toast.attr('aria-live', 'off');
                    $toast.fadeOut(100);
                }, 2000);
            });

            //$('.weui-cell').on('click', function(){
            //  $(this).find('input').trigger('focus');
            //});
        });</script>
    <script type="text/html" id="tpl_form_input_status">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">输入框状态</h2>
                    <div class="weui-form__desc">可体验表单输入的反馈状态。显示报错信息有两种类型，一种是超过1个输入项的时候，用置顶tipsbar报错信息，告知错误原因，页面聚焦到对应的报错区域，内容标红色，另一种是在当前输入项位置报错，适用于只有1个输入项的时候，用户焦点主要是输入区域。</div>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells__title">表单报错：置顶tipsbar报错信息</div>
                        <div class="weui-cells">
                            <label for="js_input1" class="weui-cell weui-cell_active" id="js_cell">
                                <div class="weui-cell__hd"><span class="weui-label">卡号</span></div>
                                <div class="weui-cell__bd weui-flex">
                                    <input id="js_input1" class="weui-input" type="text" pattern="[0-9]*" placeholder="请输入16位数卡号" maxlength="16" />
                                    <button id="js_input_clear" class="weui-btn_reset weui-btn_icon weui-btn_input-clear">
                                        <i class="weui-icon-clear"></i>
                                    </button>
                                </div>
                            </label>
                            <label for="js_input2" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd"><span class="weui-label">持卡人</span></div>
                                <div class="weui-cell__bd weui-flex">
                                    <input id="js_input2" class="weui-input" type="text" placeholder="请输入持卡人姓名" />
                                </div>
                            </label>
                        </div>
                    </div>
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells__title">表单报错：当前项位置报错</div>
                        <div class="weui-cells">
                            <label for="js_current_input" class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd"><span class="weui-label">金额</span></div>
                                <div class="weui-cell__bd weui-flex">
                                    <input id="js_current_input" class="weui-input" type="text" placeholder="请输入金额" />
                                </div>
                            </label>
                        </div>
                        <div role="alert" id="js_current_tips" style="display: none;" class="weui-cells__tips weui-cells__tips_warn">最多支持8位数</div>
                    </div>
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells__title">表单只读、置灰</div>
                        <div class="weui-cells">
                            <label for="js_input3" class="weui-cell weui-cell_active weui-cell_readonly">
                                <div class="weui-cell__hd"><span class="weui-label">EMail</span></div>
                                <div class="weui-cell__bd">
                                    <input id="js_input3" class="weui-input" placeholder="请输入EMail" value="1234567" readonly />
                                </div>
                            </label>
                            <label for="js_input4" class="weui-cell weui-cell_active weui-cell_disabled">
                                <div class="weui-cell__hd"><span class="weui-label">微信号</span></div>
                                <div class="weui-cell__bd">
                                    <input id="js_input4" class="weui-input" placeholder="请输入微信号" value="WeUI" disabled />
                                </div>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" aria-disabled="true" disabled class="weui-btn weui-btn_primary weui-btn_disabled" href="javascript:" id="showTooltips">确定</a>
                </div>
            </div>
            <div role="alert" id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $tooltips = $('.js_tooltips');
            var $toast = $('#js_toast');
            var $input = $('#js_input1');
            var $inputClear = $('#js_input_clear');
            var $cell = $('#js_cell');
            var $currentInput = $('#js_current_input');

            $input.on('input', function () {
                var $value = $input.val();
                if ($cell.hasClass('weui-cell_warn')) {
                    $cell.removeClass('weui-cell_warn');
                }
                if ($value) {
                    $('#showTooltips').removeClass('weui-btn_disabled');
                    $('#showTooltips').removeAttr('disabled');
                    $('#showTooltips').attr('aria-disabled', 'false');
                } else {
                    $('#showTooltips').addClass('weui-btn_disabled');
                    $('#showTooltips').addAttr('disabled');
                    $('#showTooltips').attr('aria-disabled', 'true');
                }
            });
            $currentInput.on('input', function () {
                var $value = $currentInput.val();
                if ($value) {
                    $('#js_current_tips').css('display', 'block');
                } else {
                    $('#js_current_tips').css('display', 'none');
                }
            });
            $('#showTooltips').on('click', function () {
                if ($(this).hasClass('weui-btn_disabled')) return;

                var $value = $input.val();
                if ($tooltips.css('display') != 'none') return;

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                if ($value.length < 16) {
                    $cell.addClass('weui-cell_warn');
                    $tooltips.fadeIn(100);
                    setTimeout(function () {
                        $tooltips.fadeOut(100);
                    }, 2000);
                } else {
                    $toast.fadeIn(100);
                    $toast.attr('aria-live', 'assertive');
                    setTimeout(function () {
                        $toast.fadeOut(100);
                        $toast.attr('aria-live', 'off');
                    }, 2000);
                }
            });
            $inputClear.on('click', function () {
                $input.val('');
            });
        });</script>
    <script type="text/html" id="tpl_form_vcode">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">验证码</h2>
                    <div class="weui-form__desc">验证手机号样式</div>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells">
                            <div class="weui-cell weui-cell_active">
                                <div class="weui-cell__hd">
                                    <label for="js_input1" class="weui-label">手机号</label>
                                </div>
                                <div class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入手机号" value="12345678907" />
                                </div>
                                <div class="weui-cell__ft">
                                    <button type="button" id="showIOSDialog1" class="weui-btn_reset weui-btn_icon">
                                        <i role="img" alt="帮助" class="js_target weui-icon-info-circle"></i>
                                    </button>
                                </div>
                            </div>
                            <div id="js_cell_vcode" class="weui-cell weui-cell_active weui-cell_vcode weui-cell_wrap">
                                <div class="weui-cell__hd">
                                    <label for="js_input2" class="weui-label">验证码</label>
                                </div>
                                <div class="weui-cell__bd weui-flex">
                                    <input id="js_input2" class="weui-input weui-cell__control weui-cell__control_flex" type="text" pattern="[0-9]*" id="js_input" placeholder="输入验证码" maxlength="6" />
                                    <button id="js_input_clear" class="weui-btn_reset weui-btn_icon weui-btn_input-clear">
                                        <i class="weui-icon-clear"></i>
                                    </button>
                                    <button id="js_btn_vcode" role="button" class="js_target weui-cell__control weui-btn weui-btn_default weui-vcode-btn">获取验证码</button>
                                </div>
                            </div>
                        </div>
                        <div class="weui-cells__tips"><a class="weui-link weui-wa-hotarea" href="javascript:">收不到验证码</a></div>
                    </div>
                </div>
                <div class="weui-form__tips-area">
                    <label id="weuiAgree" for="weuiAgreeCheckbox" class="weui-agree weui-wa-hotarea">
                        <input id="weuiAgreeCheckbox" type="checkbox" class="weui-agree__checkbox" /><span class="weui-agree__text">阅读并同意<a href="/example/" target="_blank">《相关条款》</a>
                        </span>
                    </label>
                </div>
                <div class="weui-form__opr-area">
                    <button class="weui-btn weui-btn_primary" type="button" id="showTooltips">确定</button>
                </div>
            </div>
            <div role="alert" id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
            <div role="alert" id="js_agree_msg" class="weui-hidden_abs" style="display: none;">未同意《相关条款》</div>
            <div id="dialogs">
                <!--BEGIN dialog1-->
                <div role="dialog" aria-modal="true" class="js_dialog" id="iosDialog1" style="display: none;">
                    <div class="weui-mask"></div>
                    <div id="js_half_screen_dialog" class="weui-half-screen-dialog">
                        <div class="weui-half-screen-dialog__hd">
                            <div class="weui-half-screen-dialog__hd__side">
                                <button id="dialogClose" class="weui-icon-btn">关闭<i class="weui-icon-close-thin"></i></button>
                            </div>
                            <div class="weui-half-screen-dialog__hd__main">
                                <strong class="weui-half-screen-dialog__title">标题</strong>
                            </div>
                        </div>
                        <div class="weui-half-screen-dialog__bd">
                            <br>
                            <br>
                            可放自定义内容
                <br>
                            <br>
                            <br>
                            <br>
                        </div>
                    </div>
                </div>
                <!--END dialog1-->
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $tooltips = $('.js_tooltips');
            var $toast = $('#js_toast');
            var $input = $('#js_input1');
            var $inputClear = $('#js_input_clear');
            var $agree = $('#weuiAgree');
            var $agreeMsg = $('#js_agree_msg');
            var $agreeCheckbox = $('#weuiAgreeCheckbox');
            var $iosDialog1 = $('#iosDialog1');
            var $halfScreenDialog = $('#js_half_screen_dialog');

            $input.on('input', function () {
                var $value = $input.val();
                if ($value) {
                    $('#showTooltips').removeAttr('disabled');
                    $('#showTooltips').attr('aria-disabled', 'false');
                } else {
                    $('#showTooltips').addAttr('disabled');
                    $('#showTooltips').attr('aria-disabled', 'true');
                }
            });

            //$agreeCheckbox.on('change', function(){
            //});

            $('#showTooltips').on('click', function () {
                if ($tooltips.css('display') != 'none') return;
                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                if ($agreeCheckbox.prop("checked")) {
                    $toast.fadeIn(100);
                    $toast.attr('aria-live', 'assertive');
                    setTimeout(function () {
                        $toast.fadeOut(100);
                        $toast.attr('aria-live', 'off');
                    }, 2000);
                } else {
                    $agree.addClass('weui-agree_animate');
                    $agreeMsg.show();
                    setTimeout(function () {
                        $agree.removeClass('weui-agree_animate');
                        $agreeMsg.hide();
                    }, 200);
                }
            });


            $('#dialogs').on('click', '.weui-mask', function () {
                $halfScreenDialog.removeClass('weui-half-screen-dialog_show');
                $(this).parents('.js_dialog').fadeOut(200);
                $iosDialog1.attr('aria-modal', 'false');
                $('#showIOSDialog1').attr('tabindex', '-1').trigger('focus');
            });
            $('#dialogClose').on('click', function () {
                $halfScreenDialog.removeClass('weui-half-screen-dialog_show');
                $(this).parents('.js_dialog').fadeOut(200);
                $iosDialog1.attr('aria-modal', 'false');
                $('#showIOSDialog1').attr('tabindex', '-1').trigger('focus');
            });

            $('#showIOSDialog1').on('click', function () {
                $iosDialog1.fadeIn(200);
                $halfScreenDialog.addClass('weui-half-screen-dialog_show');
                $iosDialog1.attr('aria-modal', 'true');
                setTimeout(function () {
                    $('#dialogClose').trigger('focus');
                }, 500);
            });

            $('.weui-cell').on('click', function (e) {
                if (e.target.classList.contains('js_target')) {
                    return;
                }
                $(this).find('input').trigger('focus');
            });
            $inputClear.on('click', function () {
                $input.val('');
            });

        });</script>
    <script type="text/html" id="tpl_form_access">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">跳转列表项</h2>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells">
                            <a class="weui-cell weui-cell_access" href="javascript:">
                                <div class="weui-cell__bd">
                                    <p>cell standard</p>
                                </div>
                                <div class="weui-cell__ft"></div>
                            </a>
                            <a class="weui-cell weui-cell_access" href="javascript:">
                                <div class="weui-cell__bd">
                                    <p>cell standard</p>
                                </div>
                                <div class="weui-cell__ft"></div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_form_checkbox">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">复选框样式展示</h2>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells weui-cells_checkbox">
                            <label class="weui-cell weui-cell_active weui-check__label" for="s11">
                                <div class="weui-cell__hd">
                                    <input type="checkbox" class="weui-check" name="checkbox1" id="s11" checked="checked" />
                                    <i class="weui-icon-checked"></i>
                                </div>
                                <div class="weui-cell__bd">
                                    <p>standard is dealt for u.</p>
                                </div>
                            </label>
                            <label class="weui-cell weui-cell_active weui-check__label" for="s12">
                                <div class="weui-cell__hd">
                                    <input type="checkbox" name="checkbox1" class="weui-check" id="s12" />
                                    <i class="weui-icon-checked"></i>
                                </div>
                                <div class="weui-cell__bd">
                                    <p>standard is dealicient for u.</p>
                                </div>
                            </label>
                            <label class="weui-cell weui-cell_active weui-check__label weui-cell_disabled" for="s13">
                                <div class="weui-cell__hd">
                                    <input type="checkbox" name="checkbox1" class="weui-check" checked disabled id="s13" />
                                    <i class="weui-icon-checked"></i>
                                </div>
                                <div class="weui-cell__bd">
                                    <p>standard is dealicient for u.</p>
                                </div>
                            </label>
                            <a href="javascript:" class="weui-cell weui-cell_active weui-cell_link">
                                <div class="weui-cell__bd">添加更多</div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">下一步</a>
                </div>
                <div class="weui-form__tips-area">
                    <p class="weui-form__tips">
                        点击下一步即表示<a class="weui-link weui-wa-hotarea" href="javascript:">同意用户协议</a>
                    </p>
                </div>
            </div>
            <div role="alert" id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/javascript">
        $(function () {
            var $tooltips = $('.js_tooltips');
            var $toast = $('#js_toast');

            $('#showTooltips').on('click', function () {
                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $toast.fadeIn(100);
                $toast.attr('aria-live', 'assertive');
                setTimeout(function () {
                    $toast.fadeOut(100);
                    $toast.attr('aria-live', 'off');
                }, 2000);
            });
        });</script>
    <script type="text/html" id="tpl_form_radio">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">单选框样式展示</h2>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells weui-cells_radio">
                            <label class="weui-cell weui-cell_active weui-check__label" for="x11">
                                <div class="weui-cell__bd">
                                    <p>cell standard</p>
                                </div>
                                <div class="weui-cell__ft">
                                    <input type="radio" class="weui-check" name="radio1" id="x11" />
                                    <span class="weui-icon-checked"></span>
                                </div>
                            </label>
                            <label class="weui-cell weui-cell_active weui-check__label" for="x12">

                                <div class="weui-cell__bd">
                                    <p>cell standard</p>
                                </div>
                                <div class="weui-cell__ft">
                                    <input type="radio" name="radio1" class="weui-check" id="x12" checked="checked" />
                                    <span class="weui-icon-checked"></span>
                                </div>
                            </label>
                            <a href="javascript:" class="weui-cell weui-cell_active weui-cell_link">
                                <div class="weui-cell__bd">添加更多</div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">确定</a>
                </div>
            </div>
            <div role="alert" id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $tooltips = $('.js_tooltips');
            var $toast = $('#js_toast');

            $('#showTooltips').on('click', function () {
                if ($tooltips.css('display') != 'none') return;

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $toast.fadeIn(100);
                $toast.attr('aria-live', 'assertive');
                setTimeout(function () {
                    $toast.fadeOut(100);
                    $toast.attr('aria-live', 'off');
                }, 2000);
            });
        });</script>
    <script type="text/html" id="tpl_form_switch">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">开关样式展示</h2>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells">
                            <label for="cb" class="weui-cell weui-cell_active weui-cell_switch">
                                <div class="weui-cell__bd" id="cb_txt" aria-hidden="true">标题文字</div>
                                <div class="weui-cell__ft">
                                    <input aria-labelledby="cb_txt" id="cb" class="weui-switch" type="checkbox" />
                                </div>
                            </label>
                            <label for="cb1" class="weui-cell weui-cell_active weui-cell_disabled weui-cell_switch">
                                <div class="weui-cell__bd" id="cb1_txt" aria-hidden="true">标题文字</div>
                                <div class="weui-cell__ft">
                                    <input aria-labelledby="cb1_txt" id="cb1" disabled class="weui-switch" checked type="checkbox" />
                                </div>
                            </label>
                            <label for="switchCP" class="weui-cell weui-cell_active weui-cell_switch">
                                <div class="weui-cell__bd" id="cp_txt" aria-hidden="true">兼容IE Edge的版本</div>
                                <div class="weui-cell__ft">
                                    <span class="weui-switch-cp">
                                        <input id="switchCP" aria-labelledby="cp_txt" class="weui-switch-cp__input" type="checkbox" checked="checked" />
                                        <div class="weui-switch-cp__box"></div>
                                    </span>
                                </div>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">确定</a>
                </div>
            </div>
            <div id="js_toast" style="display: none;" role="alert">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $tooltips = $('.js_tooltips');
            var $toast = $('#js_toast');

            $('#showTooltips').on('click', function () {
                if ($tooltips.css('display') != 'none') return;

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $toast.fadeIn(100);
                $toast.attr('aria-live', 'assertive');
                setTimeout(function () {
                    $toast.fadeOut(100);
                    $toast.attr('aria-live', 'off');
                }, 2000);
            });
        });</script>
    <script type="text/html" id="tpl_form_select">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">原生选择框</h2>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells">
                            <div class="weui-cell weui-cell_active weui-cell_select">
                                <div class="weui-cell__bd">
                                    <select class="weui-select" name="select1">
                                        <option selected="" value="1">微信号</option>
                                        <option value="2">QQ号</option>
                                        <option value="3">Email</option>
                                    </select>
                                </div>
                            </div>
                            <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-before">
                                <div class="weui-cell__hd">
                                    <select class="weui-select" name="select2">
                                        <option value="1">+86</option>
                                        <option value="2">+80</option>
                                        <option value="3">+84</option>
                                        <option value="4">+87</option>
                                    </select>
                                </div>
                                <label for="js_input1" class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </label>
                            </div>
                            <label for="select2" class="weui-cell weui-cell_active weui-cell_select weui-cell_select-after">
                                <div class="weui-cell__hd">
                                    <span class="weui-label">国家</span>
                                </div>
                                <div class="weui-cell__bd">
                                    <select class="weui-select" name="select2" id="select2">
                                        <option value="1">中国</option>
                                        <option value="2">美国</option>
                                        <option value="3">英国</option>
                                    </select>
                                </div>
                            </label>
                            <label for="js_input3" class="weui-cell weui-cell_active weui-cell_wrap">
                                <div class="weui-cell__hd">
                                    <span class="weui-label">手机号</span>
                                </div>
                                <div class="weui-cell__bd">
                                    <span class="weui-cell__control">+86</span>
                                    <input id="js_input3" class="weui-input  weui-cell__control weui-cell__control_flex" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </div>
                            </label>
                        </div>
                    </div>

                    <div class="weui-cells__group" style="display: none;">
                        <div class="weui-cells">
                            <div class="weui-cell weui-cell_active weui-cell_select">
                                <div class="weui-cell__bd">
                                    <select class="weui-select" name="select1">
                                        <option selected="" value="1">微信号</option>
                                        <option value="2">QQ号</option>
                                        <option value="3">Email</option>
                                    </select>
                                </div>
                            </div>
                            <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-before">
                                <div class="weui-cell__hd">
                                    <select class="weui-select" name="select2">
                                        <option value="1">+86</option>
                                        <option value="2">+80</option>
                                        <option value="3">+84</option>
                                        <option value="4">+87</option>
                                    </select>
                                </div>
                                <label for="js_input1" class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </label>
                            </div>
                            <label for="select2" class="weui-cell weui-cell_active weui-cell_select weui-cell_select-after">
                                <div class="weui-cell__hd">
                                    <span class="weui-label">国家</span>
                                </div>
                                <div class="weui-cell__bd">
                                    <select class="weui-select" name="select2" id="select2">
                                        <option value="1">中国</option>
                                        <option value="2">美国</option>
                                        <option value="3">英国</option>
                                    </select>
                                </div>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">确定</a>
                </div>
            </div>
            <div id="js_toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $toast = $('#js_toast');
            var $tooltips = $('.js_tooltips');

            $('#showTooltips').on('click', function () {

                // toptips的fixed, 如果有`animation`, `position: fixed`不生效
                $('.page.cell').removeClass('slideIn');

                $toast.fadeIn(100);
                setTimeout(function () {
                    $toast.fadeOut(100);
                }, 2000);
            });
        });</script>
    <script type="text/html" id="tpl_form_select_primary">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">模拟选择框</h2>
                    <div class="weui-form__desc">用于丰富原生选择框结构，使其更具有扩展性</div>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells">
                            <div class="weui-cell weui-cell_active weui-cell_select" role="button" aria-haspopup="listbox" id="showDatePicker">
                                <div class="weui-cell__bd">
                                    <div class="weui-select">日期</div>
                                </div>
                            </div>
                            <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-before">
                                <div class="weui-cell__hd" id="showPhone" role="button" aria-haspopup="listbox">
                                    <div class="weui-select">+86</div>
                                </div>
                                <div class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </div>
                            </div>
                            <div id="showPicker" role="button" aria-haspopup="listbox" class="weui-cell weui-cell_active weui-cell_select weui-cell_select-after">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">票种</label>
                                </div>
                                <div class="weui-cell__bd">
                                    <div class="weui-select">的士票</div>
                                </div>
                            </div>

                            <label for="js_input3" class="weui-cell weui-cell_active weui-cell_wrap">
                                <div class="weui-cell__hd">
                                    <span class="weui-label">手机号</span>
                                </div>
                                <div class="weui-cell__bd">
                                    <span class="weui-cell__control">+86</span>
                                    <input id="js_input3" class="weui-input  weui-cell__control weui-cell__control_flex" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </div>
                            </label>
                        </div>
                    </div>
                    <div class="weui-cells__group" style="display: none;">
                        <div class="weui-cells">
                            <div class="weui-cell weui-cell_active weui-cell_select" role="button" aria-haspopup="listbox" id="showDatePicker">
                                <div class="weui-cell__bd">
                                    <div class="weui-select">日期</div>
                                </div>
                            </div>
                            <div class="weui-cell weui-cell_active weui-cell_select weui-cell_select-before">
                                <div class="weui-cell__hd" id="showPhone" role="button" aria-haspopup="listbox">
                                    <div class="weui-select">+86</div>
                                </div>
                                <div class="weui-cell__bd">
                                    <input id="js_input1" class="weui-input" type="number" pattern="[0-9]*" placeholder="请输入号码" value="12345678907" />
                                </div>
                            </div>
                            <div id="showPicker" role="button" aria-haspopup="listbox" class="weui-cell weui-cell_active weui-cell_select weui-cell_select-after">
                                <div class="weui-cell__hd">
                                    <label class="weui-label">票种</label>
                                </div>
                                <div class="weui-cell__bd">
                                    <div class="weui-select">的士票</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>

    <!--
<div class="page">
    <div class="page__hd">
        <h1 class="page__title">Picker</h1>
        <p class="page__desc">多列选择器，需要配合js实现</p>
    </div>
    <div class="page__bd page__bd_spacing">
        <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showPicker">单列选择器</a>
        <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDatePicker">日期选择器</a>
    </div>
</div>
-->
    <script type="text/javascript">
        $('#showPhone').on('click', function () {
            weui.picker([{
                label: '+86',
                value: 0
            }, {
                label: '+80',
                value: 1
            }, {
                label: '+84',
                value: 2
            }, {
                label: '+87',
                value: 3
            }], {
                onChange: function (result) {
                    console.log(result);
                },
                onConfirm: function (result) {
                    console.log(result);
                },
                title: '单列选择器'
            });
        });
        $('#showPicker').on('click', function () {
            weui.picker([{
                label: '飞机票',
                value: 0
            }, {
                label: '火车票',
                value: 1
            }, {
                label: '的士票',
                value: 2
            }, {
                label: '公交票 (disabled)',
                disabled: true,
                value: 3
            }, {
                label: '其他',
                value: 4
            }], {
                onChange: function (result) {
                    console.log(result);
                },
                onConfirm: function (result) {
                    console.log(result);
                },
                title: '单列选择器'
            });
        });
        $('#showDatePicker').on('click', function () {
            weui.datePicker({
                start: 1990,
                end: new Date().getFullYear(),
                onChange: function (result) {
                    console.log(result);
                },
                onConfirm: function (result) {
                    console.log(result);
                },
                title: '多列选择器'
            });
        });</script>
    <script type="text/html" id="tpl_form_textarea">
        <div class="page">
            <div class="weui-form">
                <div class="weui-form__text-area">
                    <h2 class="weui-form__title">文本域</h2>
                    <div class="weui-form__desc">输入更多内容的输入区域样式展示</div>
                </div>
                <div class="weui-form__control-area">
                    <div class="weui-cells__group weui-cells__group_form">
                        <div class="weui-cells__title">问题描述</div>
                        <div class="weui-cells weui-cells_form">
                            <div class="weui-cell weui-cell_active">
                                <div class="weui-cell__bd">
                                    <textarea class="weui-textarea" placeholder="请描述你所发生的问题" rows="3"></textarea>
                                    <div role="option" aria-live="polite" class="weui-textarea-counter"><span>0</span>/200</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="weui-form__opr-area">
                    <a role="button" class="weui-btn weui-btn_primary" href="javascript:" id="showTooltips">确定</a>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_toast">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Toast</h1>
                <p class="page__desc">弹出式提示</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showToast">成功提示</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showWarnToast">失败提示</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showTextMoreToast">长文案提示</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showLoadingToast">正在加载提示</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showTextToast">文字提示</a>
            </div>

            <!--BEGIN toast-->
            <div role="alert" id="toast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                    <p class="weui-toast__content">已完成</p>
                </div>
            </div>

            <!--BEGIN toast-->
            <div role="alert" id="textMoreToast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast weui-toast_text-more">
                    <i class="weui-icon-warn weui-icon_toast"></i>
                    <p class="weui-toast__content">此处为长文案提示详情</p>
                </div>
            </div>

            <!--BEGIN toast-->
            <div role="alert" id="warnToast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <i class="weui-icon-warn weui-icon_toast"></i>
                    <p class="weui-toast__content">获取链接失败</p>
                </div>
            </div>

            <!-- loading toast -->
            <div role="alert" id="loadingToast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast">
                    <span class="weui-primary-loading weui-icon_toast">
                        <span class="weui-primary-loading__dot"></span>
                    </span>
                    <p class="weui-toast__content">正在加载</p>
                </div>
            </div>

            <!-- text toast -->
            <div role="alert" id="textToast" style="display: none;">
                <div class="weui-mask_transparent"></div>
                <div class="weui-toast weui-toast_text">
                    <p class="weui-toast__content">文字提示</p>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        // toast
        $(function () {
            var $toast = $('#toast');
            $('#showToast').on('click', function () {
                if ($toast.css('display') != 'none') return;

                $toast.fadeIn(100);
                setTimeout(function () {
                    $toast.fadeOut(100);
                }, 2000);
            });
        });

        // warn
        $(function () {
            var $warnToast = $('#warnToast');
            $('#showWarnToast').on('click', function () {
                if ($warnToast.css('display') != 'none') return;

                $warnToast.fadeIn(100);
                setTimeout(function () {
                    $warnToast.fadeOut(100);
                }, 2000);
            });
        });

        // text-more
        $(function () {
            var $textMoreToast = $('#textMoreToast');
            $('#showTextMoreToast').on('click', function () {
                if ($textMoreToast.css('display') != 'none') return;

                $textMoreToast.fadeIn(100);
                setTimeout(function () {
                    $textMoreToast.fadeOut(100);
                }, 2000);
            });
        });

        // loading
        $(function () {
            var $loadingToast = $('#loadingToast');
            $('#showLoadingToast').on('click', function () {
                if ($loadingToast.css('display') != 'none') return;

                $loadingToast.fadeIn(100);
                setTimeout(function () {
                    $loadingToast.fadeOut(100);
                }, 2000);
            });
        });

        // text
        $(function () {
            var $textToast = $('#textToast');
            $('#showTextToast').on('click', function () {
                if ($textToast.css('display') != 'none') return;

                $textToast.fadeIn(100);
                setTimeout(function () {
                    $textToast.fadeOut(100);
                }, 2000);
            });
        });</script>
    <script type="text/html" id="tpl_dialog">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Dialog</h1>
                <p class="page__desc">对话框</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showIOSDialog1">iOS Dialog样式一</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showIOSDialog2">iOS Dialog样式二</a>
            </div>

            <div id="dialogs">
                <!--BEGIN dialog1-->
                <div class="js_dialog" role="dialog" aria-hidden="true" aria-modal="true" aria-labelledby="js_title1" id="iosDialog1" style="display: none;">
                    <div class="weui-mask"></div>
                    <div class="weui-dialog">
                        <div class="weui-dialog__hd"><strong class="weui-dialog__title" id="js_title1">弹窗标题</strong></div>
                        <div class="weui-dialog__bd">弹窗内容，告知当前状态、信息和解决方法，描述文字尽量控制在三行内</div>
                        <div class="weui-dialog__ft">
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_default">辅助操作</a>
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_primary">主操作</a>
                        </div>
                    </div>
                </div>
                <!--END dialog1-->
                <!--BEGIN dialog2-->
                <div class="js_dialog" role="dialog" aria-hidden="true" aria-modal="true" aria-labelledby="js_title2" id="iosDialog2" style="display: none;">
                    <div class="weui-mask"></div>
                    <div class="weui-dialog">
                        <div class="weui-dialog__bd">弹窗内容，告知当前状态、信息和解决方法，描述文字尽量控制在三行内</div>
                        <div class="weui-dialog__ft">
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_primary">知道了</a>
                        </div>
                    </div>
                </div>
                <!--END dialog2-->
                <!--BEGIN dialog3-->
                <div class="js_dialog" role="dialog" aria-hidden="true" aria-modal="true" aria-labelledby="js_title3" id="androidDialog1" style="display: none;">
                    <div class="weui-mask"></div>
                    <div class="weui-dialog weui-skin_android">
                        <div class="weui-dialog__hd"><strong class="weui-dialog__title" id="js_title3">弹窗标题</strong></div>
                        <div class="weui-dialog__bd">
                            弹窗内容，告知当前状态、信息和解决方法，描述文字尽量控制在三行内
                        </div>
                        <div class="weui-dialog__ft">
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_default">辅助操作</a>
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_primary">主操作</a>
                        </div>
                    </div>
                </div>
                <!--END dialog3-->
                <!--BEGIN dialog4-->
                <div class="js_dialog" role="dialog" aria-hidden="true" aria-modal="true" aria-labelledby="js_title4" id="androidDialog2" style="display: none;">
                    <div class="weui-mask"></div>
                    <div class="weui-dialog weui-skin_android">
                        <div class="weui-dialog__bd">
                            弹窗内容，告知当前状态、信息和解决方法，描述文字尽量控制在三行内
                        </div>
                        <div class="weui-dialog__ft">
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_default">辅助操作</a>
                            <a role="button" href="javascript:" class="weui-dialog__btn weui-dialog__btn_primary">主操作</a>
                        </div>
                    </div>
                </div>
                <!--END dialog4-->
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $iosDialog1 = $('#iosDialog1'),
                $iosDialog2 = $('#iosDialog2'),
                $androidDialog1 = $('#androidDialog1'),
                $androidDialog2 = $('#androidDialog2');

            $('#dialogs').on('click', '.weui-dialog__btn', function () {
                $(this).parents('.js_dialog').fadeOut(200);
                $(this).parents('.js_dialog').attr('aria-hidden', 'true');
                $(this).parents('.js_dialog').removeAttr('tabindex');
            });

            $('#showIOSDialog1').on('click', function () {
                $iosDialog1.fadeIn(200);
                $iosDialog1.attr('aria-hidden', 'false');
                $iosDialog1.attr('tabindex', '0');
                $iosDialog1.trigger('focus');
            });
            $('#showIOSDialog2').on('click', function () {
                $iosDialog2.fadeIn(200);
                $iosDialog2.attr('aria-hidden', 'false');
                $iosDialog2.attr('tabindex', '0');
                $iosDialog2.trigger('focus');
            });
            $('#showAndroidDialog1').on('click', function () {
                $androidDialog1.fadeIn(200);
                $androidDialog1.attr('aria-hidden', 'false');
                $androidDialog1.attr('tabindex', '0');
                $androidDialog1.trigger('focus');
            });
            $('#showAndroidDialog2').on('click', function () {
                $androidDialog2.fadeIn(200);
                $androidDialog2.attr('aria-hidden', 'false');
                $androidDialog2.attr('tabindex', '0');
                $androidDialog2.trigger('focus');
            });
        });</script>
    <script type="text/html" id="tpl_half-screen-dialog">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Half-screen Dialog</h1>
                <p class="page__desc">半屏组件</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDialog1">样式一</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDialog2">样式二</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDialog3">样式三</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDialog4">样式四</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDialog5">样式五</a>
            </div>

            <div id="dialogs">
                <div id="dialogWrap1" class="js_dialog_wrap" ref="showDialog1" aria-labelledby="js_title1" role="dialog" aria-modal="false" aria-hidden="true" style="display: none;">
                    <div id="mask1" class="js_close weui-mask"></div>
                    <div id="js_dialog_1" class="js_dialog weui-half-screen-dialog">
                        <div class="weui-half-screen-dialog__hd">
                            <div class="weui-half-screen-dialog__hd__side">
                                <button class="js_close weui-btn_icon weui-wa-hotarea">关闭<i class="weui-icon-close-thin"></i></button>
                            </div>
                            <div class="weui-half-screen-dialog__hd__main">
                                <strong class="weui-half-screen-dialog__title" id="js_title1">标题</strong>
                                <span class="weui-half-screen-dialog__subtitle">副标题</span>
                            </div>
                        </div>
                        <div class="weui-half-screen-dialog__bd">
                            <br>
                            <br>
                            可放自定义内容
                  <br>
                            <br>
                            <br>
                            <br>
                        </div>
                    </div>
                </div>
                <div id="dialogWrap2" class="js_dialog_wrap" ref="showDialog2" aria-labelledby="js_title2" role="dialog" aria-modal="false" aria-hidden="true" style="display: none;">
                    <div id="mask2" class="js_close weui-mask"></div>
                    <div id="js_dialog_2" class="js_dialog weui-half-screen-dialog weui-half-screen-dialog_bottom-fixed">
                        <div class="weui-half-screen-dialog__hd">
                            <div class="weui-half-screen-dialog__hd__side">
                                <button class="js_close weui-btn_icon weui-wa-hotarea">关闭<i class="weui-icon-slide-down"></i></button>
                                <button style="display: none;" class="weui-btn_icon weui-wa-hotarea">返回<i class="weui-icon-back-arrow-thin"></i></button>
                                <button style="display: none;" class="js_close weui-btn_icon weui-wa-hotarea">关闭<i class="weui-icon-close-thin"></i></button>
                            </div>
                            <div class="weui-half-screen-dialog__hd__main">
                                <strong class="weui-half-screen-dialog__title" id="js_title2">标题</strong>
                            </div>
                            <div class="weui-half-screen-dialog__hd__side">
                                <button class="weui-btn_icon weui-wa-hotarea">更多<i class="weui-icon-more"></i></button>
                            </div>
                        </div>
                        <div class="weui-half-screen-dialog__bd">
                            <div class="weui-bottom-fixed-opr-page" id="js_wrap_wrp">
                                <div class="weui-bottom-fixed-opr-page__content" id="js_wrap_content">
                                    <p class="weui-half-screen-dialog__desc">
                                        辅助描述内容，可根据实际需要安排
                                    </p>
                                    <p class="weui-half-screen-dialog__tips" role="option">
                                        辅助提示内容，可根据实际需要安排
                    Dolor adipisci quidem consequuntur similique consequuntur doloribus modi possimus sunt voluptas qui Aspernatur natus error quisquam quidem ipsa corrupti! Dignissimos quasi quis natus fugiat odio in? Mollitia molestias error earum.
                    Dolor adipisci quidem consequuntur similique consequuntur doloribus modi possimus sunt voluptas qui Aspernatur natus error quisquam quidem ipsa corrupti! Dignissimos quasi quis natus fugiat odio in? Mollitia molestias error earum.
                    Dolor adipisci quidem consequuntur similique consequuntur doloribus modi possimus sunt voluptas qui Aspernatur natus error quisquam quidem ipsa corrupti! Dignissimos quasi quis natus fugiat odio in? Mollitia molestias error earum.
                    Dolor adipisci quidem consequuntur similique consequuntur doloribus modi possimus sunt voluptas qui Aspernatur natus error quisquam quidem ipsa corrupti! Dignissimos quasi quis natus fugiat odio in? Mollitia molestias error earum.
                    Dolor adipisci quidem consequuntur similique consequuntur doloribus modi possimus sunt voluptas qui Aspernatur natus error quisquam quidem ipsa corrupti! Dignissimos quasi quis natus fugiat odio in? Mollitia molestias error earum.
                                    </p>
                                </div>
                                <div class="weui-bottom-fixed-opr">
                                    <a href="javascript:;" role="button" id="js_wrap_btn" class="js_close weui-btn weui-btn_primary">同意并完成</a>
                                    <a href="javascript:;" role="button" class="js_close weui-btn weui-btn_default">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="dialogWrap3" class="js_dialog_wrap" ref="showDialog3" aria-label="弹窗标题" role="dialog" aria-modal="false" aria-hidden="true" style="display: none;">
                    <div aria-label="关闭" role="button" class="js_close weui-mask"></div>
                    <div id="js_dialog_3" class="js_dialog weui-half-screen-dialog weui-half-screen-dialog_large">
                        <div class="weui-half-screen-dialog__hd">
                            <div class="weui-half-screen-dialog__hd__main">
                                <div class="weui-flex" style="align-items: center; font-size: 14px;">
                                    <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="" style="width: 24px; margin-right: 8px; border-radius: 50%; display: block;">
                                    昵称
                                </div>
                            </div>
                        </div>
                        <div class="weui-half-screen-dialog__bd">
                            <br>
                            可放自定义内容
                  <br>
                        </div>
                        <div class="weui-half-screen-dialog__ft">
                            <div class="weui-half-screen-dialog__btn-area">
                                <a href="javascript:" class="js_close weui-btn weui-btn_default">次要操作</a>
                                <a href="javascript:" class="js_close weui-btn weui-btn_primary">主要操作</a>
                            </div>
                            <div class="weui-half-screen-dialog__attachment-area">
                                <a class="weui-link" href="javacript:;">附加操作</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="dialogWrap4" class="js_dialog_wrap" ref="showDialog4" aria-label="弹窗标题" role="dialog" aria-modal="false" aria-hidden="true" style="display: none;">
                    <div aria-label="关闭" role="button" class="js_close weui-mask"></div>
                    <div id="js_dialog_4" class="js_dialog weui-half-screen-dialog">
                        <div class="weui-half-screen-dialog__hd">
                            <div class="weui-half-screen-dialog__hd__main">
                                <div class="weui-flex" style="align-items: center; font-size: 14px;">
                                    <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="" style="width: 24px; margin-right: 8px; border-radius: 50%; display: block;">
                                    昵称
                                </div>
                            </div>
                        </div>
                        <div class="weui-half-screen-dialog__bd">
                            <br>
                            可放自定义内容
                  <br>
                        </div>
                        <div class="weui-half-screen-dialog__ft">
                            <div id="js_wrap_btn_area" class="weui-half-screen-dialog__btn-area">
                                <a id="js_wrap_btn_1" href="javascript:" class="js_close weui-btn weui-btn_default">非主要操作</a>
                                <a href="javascript:" class="js_close weui-btn weui-btn_primary">主要操作</a>
                            </div>
                            <div class="weui-half-screen-dialog__attachment-area">
                                <a class="weui-link" href="javacript:;">附加操作</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="dialogWrap5" class="js_dialog_wrap" ref="showDialog5" aria-labelledby="js_title5" role="dialog" aria-modal="false" aria-hidden="true" style="display: none;">
                    <div id="js_close" class="js_close weui-mask"></div>
                    <div id="js_dialog_5" class="js_dialog weui-half-screen-dialog weui-half-screen-dialog_slide">
                        <div class="weui-half-screen-dialog__hd">
                            <div id="js_line" class="weui-half-screen-dialog__slide-icon">
                                <i id="js_arrow" class="weui-icon-arrow"></i>
                            </div>
                        </div>
                        <div class="weui-half-screen-dialog__bd">
                            <br>
                            <br>
                            可放自定义内容
                  <br>
                            <br>
                            <br>
                            <br>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            const $dialog1 = $('#js_dialog_1');
            const $dialog2 = $('#js_dialog_2');
            const $dialog3 = $('#js_dialog_3');
            const $dialog4 = $('#js_dialog_4');
            const $dialog5 = $('#js_dialog_5');
            const $dialogWrap1 = $('#dialogWrap1');
            const $dialogWrap2 = $('#dialogWrap2');
            const $dialogWrap3 = $('#dialogWrap3');
            const $dialogWrap4 = $('#dialogWrap4');
            const $dialogWrap5 = $('#dialogWrap5');

            function closeDialog(o) {
                const $jsDialogWrap = o.parents('.js_dialog_wrap');
                $jsDialogWrap.attr('aria-hidden', 'true').attr('aria-modal', 'false').removeAttr('tabindex');
                $jsDialogWrap.fadeOut(300);
                $jsDialogWrap.find('.js_dialog').removeClass('weui-half-screen-dialog_show');
                setTimeout(function () {
                    $('#' + $jsDialogWrap.attr('ref')).trigger('focus');
                }, 300);
            }

            $('.js_dialog_wrap').on('touchmove', function (e) {
                if ($.contains(document.getElementById('js_wrap_content'), e.target)) {
                } else {
                    e.preventDefault();
                }
            });

            $('.js_close').on('click', function () {
                closeDialog($(this));
            });



            $('#showDialog1').on('click', function () {
                $dialogWrap1.fadeIn(200);
                $dialog1.addClass('weui-half-screen-dialog_show');
                setTimeout(function () {
                    $dialogWrap1.attr('aria-hidden', 'false');
                    $dialogWrap1.attr('aria-modal', 'true');
                    $dialogWrap1.attr('tabindex', '0');
                    $dialogWrap1.trigger('focus');
                }, 200)
            });
            $('#showDialog2').on('click', function () {
                $dialogWrap2.fadeIn(200);
                $dialog2.addClass('weui-half-screen-dialog_show');
                wrapPage.style.visibility = 'hidden';
                setTimeout(function () {
                    if (wrapBtn.offsetHeight > 48) {
                        wrapPage.classList.add('weui-bottom-fixed-opr-page_btn-wrap');
                    }
                    wrapPage.style.visibility = 'visible';
                }, 100);
                setTimeout(function () {
                    $dialogWrap2.attr('aria-hidden', 'false');
                    $dialogWrap2.attr('aria-modal', 'true');
                    $dialogWrap2.attr('tabindex', '0');
                    $dialogWrap2.trigger('focus');
                }, 200)
            });
            $('#showDialog3').on('click', function () {
                $dialogWrap3.attr('aria-hidden', 'false');
                $dialogWrap3.attr('aria-modal', 'true');
                $dialogWrap3.attr('tabindex', '0');
                $dialogWrap3.fadeIn(200);
                $dialog3.addClass('weui-half-screen-dialog_show');
                setTimeout(function () {
                    $dialogWrap3.trigger('focus');
                }, 200)
            });
            $('#showDialog4').on('click', function () {
                $dialogWrap4.attr('aria-hidden', 'false');
                $dialogWrap4.attr('aria-modal', 'true');
                $dialogWrap4.attr('tabindex', '0');
                $dialogWrap4.fadeIn(200);
                $dialog4.addClass('weui-half-screen-dialog_show');
                wrapArea.style.visibility = 'hidden';
                setTimeout(function () {
                    if (wrapBtn1.offsetHeight > 48) {
                        $dialog4.addClass('weui-half-screen-dialog_btn-wrap');
                    }
                    wrapArea.style.visibility = 'visible';
                }, 100);
                setTimeout(function () {
                    $dialogWrap4.trigger('focus');
                }, 200)
            });
            $('#showDialog5').on('click', function () {
                $dialogWrap5.fadeIn(200);
                js_line.style.height = 4 + 'px';
                js_line.style.borderRadius = 2 + 'px';
                js_arrow.style.opacity = 0;
                $dialog5.addClass('weui-half-screen-dialog_show');
                $dialog5.css('transform', 'translate3d(0, 0, 0)');
                setTimeout(function () {
                    $dialogWrap5.attr('aria-hidden', 'false');
                    $dialogWrap5.attr('aria-modal', 'true');
                    $dialogWrap5.attr('tabindex', '0');
                    $dialogWrap5.trigger('focus');
                }, 200)
            });

            $('#js_close').on('click', function () {
                closeDialog($(this));
                $dialog5.css('transform', 'translate3d(0, 100%, 0)');
            });


            var dialog_5 = document.getElementById('js_dialog_5');
            var js_line = document.getElementById('js_line');
            var js_arrow = document.getElementById('js_arrow');
            var start = 0
            var end = 0

            dialog_5.addEventListener('touchstart', function (e) {
                start = e.changedTouches[0].clientY;
            })

            dialog_5.addEventListener('touchmove', function (e) {
                var move = e.changedTouches[0].clientY - start;
                if (move > 0) {
                    dialog_5.style.transform = 'translate3d(0, ' + move + 'px, 0)';

                    var percent = move / 56;
                    percent = percent > 1 ? 1 : percent;
                    js_line.style.height = 4 + (16 - 4) * percent + 'px';
                    js_line.style.borderRadius = 2 + (12 - 2) * percent + 'px';

                    if (percent >= 0.5) {
                        var pear = (percent - 0.5) / 0.5;
                        js_arrow.style.opacity = pear;
                    }
                } else {
                    dialog_5.style.transform = 'translate3d(0,0,0)';
                    js_line.style.height = 4 + 'px';
                    js_line.style.borderRadius = 2 + 'px';
                    js_arrow.style.opacity = 0;
                }
            })

            dialog_5.addEventListener('touchend', function (e) {
                var move = e.changedTouches[0].clientY - start;
                end = move;
                var max = 56;
                dialog_5.style.transition = 'transform .3s';

                if (end < max) {
                    dialog_5.style.transform = 'translate3d(0,0,0)';
                    js_line.style.height = 4 + 'px';
                    js_line.style.borderRadius = 2 + 'px';
                    js_arrow.style.opacity = 0;
                    end = 0;
                } else if (end >= max) {
                    closeDialog($(this));
                    dialog_5.style.transform = 'translate3d(0,100%,0)';
                }
            })


            const wrapBtn = document.getElementById('js_wrap_btn');
            const wrapBtn1 = document.getElementById('js_wrap_btn_1');
            const wrapPage = document.getElementById('js_wrap_wrp');
            const wrapArea = document.getElementById('js_wrap_btn_area');

            try {
                document.body.style.webkitTextSizeAdjust = JSON.parse(window.__wxWebEnv.getEnv()).fontScale + '%';
            } catch (e) {
                console.warn(e);
            }

            function wxReady(callback) {
                if (
                    typeof WeixinJSBridge === 'object' &&
                    typeof window.WeixinJSBridge.invoke === 'function'
                ) {
                    callback()
                } else {
                    document.addEventListener('WeixinJSBridgeReady', callback, false)
                }
            }
            wxReady(function () {
                WeixinJSBridge.on('menu:setfont', function (res) {
                    document.body.style.webkitTextSizeAdjust = res.fontScale + '%';
                    if (wrapBtn.offsetHeight > 48) {
                        wrapPage.classList.add('weui-bottom-fixed-opr-page_btn-wrap');
                    } else {
                        wrapPage.classList.remove('weui-bottom-fixed-opr-page_btn-wrap');
                    }
                    if (wrapBtn1.offsetHeight > 48) {
                        $dialog4.addClass('weui-half-screen-dialog_btn-wrap');
                    } else {
                        $dialog4.removeClass('weui-half-screen-dialog_btn-wrap');
                    }
                });
            });

        });</script>
    <script type="text/html" id="tpl_progress">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Progress</h1>
                <p class="page__desc">进度条</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <div class="weui-progress">
                    <div class="weui-progress__bar">
                        <div class="weui-progress__inner-bar js_progress" style="width: 0%;"></div>
                    </div>
                    <a href="javascript:" role="button" class="weui-wa-hotarea weui-progress__opr">
                        <i role="img" aria-label="取消" class="weui-icon-cancel"></i>
                    </a>
                    <span id="js_current" role="alert" class="weui-hidden_abs">0%</span>
                </div>

                <br>
                <div class="weui-progress">
                    <div class="weui-progress__bar">
                        <div class="weui-progress__inner-bar js_progress" style="width: 50%;"></div>
                    </div>
                    <a href="javascript:" role="button" class="weui-wa-hotarea weui-progress__opr">
                        <i role="img" aria-label="取消" class="weui-icon-cancel"></i>
                    </a>
                    <span id="js_current" role="alert" class="weui-hidden_abs">50%</span>
                </div>
                <br>
                <div class="weui-progress">
                    <div class="weui-progress__bar">
                        <div class="weui-progress__inner-bar js_progress" style="width: 80%;"></div>
                    </div>
                    <a href="javascript:" role="button" class="weui-progress__opr">
                        <i role="img" aria-label="取消" class="weui-icon-cancel"></i>
                    </a>
                    <span id="js_current" role="alert" class="weui-hidden_abs">80%</span>
                </div>
                <div class="weui-btn-area">
                    <button type="button" class="weui-btn weui-btn_primary" id="btnUpload">上传</button>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $progress = $('.js_progress'),
                $btnUpload = $('#btnUpload');
            var progress = 0;
            var $current = $('#js_current');
            var currentDate = +new Date();

            window.test = $current;

            function next() {
                if (progress > 10) {
                    if (+new Date() - currentDate > 3000) {
                        $current.text('已上传百分之' + progress);
                        currentDate = +new Date()
                    }
                }
                if (progress === 100) {
                    $current.text('已上传百分之' + progress);
                    progress = 0;
                    $btnUpload.removeClass('weui-btn_disabled');
                    return;
                }
                $progress.css({ width: progress + '%' });
                progress = ++progress;
                setTimeout(next, 20);
            }

            $btnUpload.on('click', function () {
                if ($btnUpload.hasClass('weui-btn_disabled')) return;

                $btnUpload.addClass('weui-btn_disabled');
                next();
            });
        });</script>
    <script type="text/html" id="tpl_steps">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Steps</h1>
                <p class="page__desc">步骤条</p>
            </div>
            <div class="page__bd">
                <a href="#steps_vertical" role="button" class="weui-btn weui-btn_default">垂直型</a>
                <a href="#steps_horizonal" role="button" class="weui-btn weui-btn_default">水平型</a>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_steps_vertical">
        <div class="page">
            <ul class="weui-steps weui-steps_vertical">
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_vertical">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_vertical">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success weui-steps__item_icon-prev">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_icon">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                        <i class="weui-icon weui-icon-waiting weui-steps__icon"></i>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_vertical">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_icon-prev weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_icon weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                        <i class="weui-icon weui-icon-success weui-steps__icon"></i>
                    </div>
                </li>
            </ul>
        </div>
    </script>
    <script type="text/html" id="tpl_steps_horizonal">
        <div class="page">
            <ul class="weui-steps weui-steps_horizonal">
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_horizonal">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_horizonal">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_horizonal">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner" style="display: none">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>

            <ul class="weui-steps weui-steps_horizonal" style="display: none;">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_horizonal-primary" style="display: none;">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
            <ul class="weui-steps weui-steps_horizonal-center" style="display: none;">
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item weui-steps__item_success">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
                <li class="weui-steps__item">
                    <div class="weui-steps__item__inner">
                        <strong class="weui-steps__item__title">标题</strong>
                        <span class="weui-steps__item__desc">描述内容详情</span>
                    </div>
                </li>
            </ul>
        </div>
    </script>
    <script type="text/html" id="tpl_msg">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Msg</h1>
                <p class="page__desc">提示页</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="#msg_success" role="button" class="weui-btn weui-btn_default">成功提示页</a>
                <a href="#msg_warn" role="button" class="weui-btn weui-btn_default">失败提示页</a>
                <a href="#msg_text" role="button" class="weui-btn weui-btn_default">无图标提示页</a>
                <a href="#msg_text_primary" role="button" class="weui-btn weui-btn_default">无图标提示页</a>
                <a href="#msg_custom_area_preview" role="button" class="weui-btn weui-btn_default">key-value场景</a>
                <a href="#msg_custom_area_tips" role="button" class="weui-btn weui-btn_default">描述列表场景</a>
                <a href="#msg_custom_area_cell" role="button" class="weui-btn weui-btn_default">跳转列表场景</a>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_success">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 class="weui-msg__title">操作成功</h2>
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_primary">推荐操作</a>
                    </p>
                </div>
                <div class="weui-msg__tips-area">
                    <p class="weui-msg__tips">提示详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                </div>
                <div class="weui-msg__extra-area">
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:" class="weui-wa-hotarea weui-footer__link">底部链接文本</a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2008-2016 weui.io</p>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_warn">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-warn weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 class="weui-msg__title">操作失败</h2>
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                </div>
                <div class="weui-msg__tips-area">
                    <p class="weui-msg__tips">提示详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_default">辅助操作</a>
                    </p>
                </div>
                <div class="weui-msg__extra-area">
                    <div class="weui-footer">
                        <p class="weui-footer__links">
                            <a href="javascript:" class="weui-wa-hotarea weui-footer__link">底部链接文本</a>
                        </p>
                        <p class="weui-footer__text">Copyright &copy; 2008-2016 weui.io</p>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_text">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__text-area">
                    <h2 class="weui-msg__title">操作成功</h2>
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_primary">推荐操作</a>
                    </p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_text_primary">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__text-area">
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现</p>
                    <p class="weui-msg__desc-primary">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现</p>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_primary">推荐操作</a>
                    </p>
                </div>
                <div class="weui-msg__tips-area">
                    <p class="weui-msg__tips">提示详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea" href="javascript:">文字链接</a></p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_custom_area_preview">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 class="weui-msg__title">操作成功</h2>
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                    <div class="weui-msg__custom-area">
                        <ul class="weui-form-preview__list">
                            <li role="option" class="weui-form-preview__item">
                                <label class="weui-form-preview__label">姓名</label><p class="weui-form-preview__value">张三</p>
                            </li>
                            <li role="option" class="weui-form-preview__item">
                                <label class="weui-form-preview__label">微信号</label><p class="weui-form-preview__value">zhangsan</p>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_primary">推荐操作</a>
                    </p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_custom_area_tips">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 class="weui-msg__title">操作成功</h2>
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                    <div class="weui-msg__custom-area">
                        <ul class="weui-list-tips">
                            <li role="option" class="weui-list-tips__item">列表提示项</li>
                            <li role="option" class="weui-list-tips__item">列表提示项</li>
                            <li role="option" class="weui-list-tips__item">列表提示项</li>
                        </ul>
                    </div>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_primary">推荐操作</a>
                    </p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_msg_custom_area_cell">
        <div class="page">
            <div class="weui-msg">
                <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                <div class="weui-msg__text-area">
                    <h2 class="weui-msg__title">操作成功</h2>
                    <p class="weui-msg__desc">内容详情，可根据实际需要安排，如果换行则不超过规定长度，居中展现<a class="weui-wa-hotarea weui-link" href="javascript:">文字链接</a></p>
                    <div class="weui-msg__custom-area">
                        <div class="weui-cells__group weui-cells__group_form">
                            <div class="weui-cells">
                                <a class="weui-cell weui-cell_access" href="javascript:">
                                    <span class="weui-cell__bd">cell standard</span>
                                    <span class="weui-cell__ft"></span>
                                </a>
                                <a class="weui-cell weui-cell_access" href="javascript:">
                                    <span class="weui-cell__bd">cell standard</span>
                                    <span class="weui-cell__ft"></span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="weui-msg__opr-area">
                    <p class="weui-btn-area">
                        <a href="javascript:history.back();" role="button" class="weui-btn weui-btn_primary">推荐操作</a>
                    </p>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_article">
        <div class="page">
            <article class="weui-article">
                <h1>文章页大标题</h1>
                <section>
                    <h2>二级标题</h2>
                    <section>
                        <h3>三级标题</h3>
                        <section>
                            <h4>四级标题</h4>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
          tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
          cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
          proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                            </p>
                            <p>
                                <img src="images/pic_article.png" alt="配图">
                                <img src="images/pic_article.png" alt="配图">
                            </p>
                        </section>
                        <section>
                            <h4>列表示例</h4>
                            <section>
                                <h5>原生无序列表</h5>
                                <ul>
                                    <li>Elit quo illum ut voluptate possimus. Maxime</li>
                                    <li>Elit quo illum ut voluptate possimus. Maxime
                <ul>
                    <li>Elit facilis nam nam</li>
                    <li>Elit facilis nam nam</li>
                    <li>Elit facilis nam nam</li>
                </ul>
                                    </li>
                                    <li>Elit quo illum ut voluptate possimus. Maxime</li>
                                </ul>
                            </section>
                            <section>
                                <h5>原生有序列表</h5>
                                <ol>
                                    <li>Elit quo illum ut voluptate possimus. Maxime</li>
                                    <li>Elit quo illum ut voluptate possimus. Maxime
                <ol>
                    <li>Adipisicing adipisci labore deleniti</li>
                    <li>Adipisicing adipisci labore deleniti</li>
                    <li>Adipisicing adipisci labore deleniti</li>
                </ol>
                                    </li>
                                    <li>Elit quo illum ut voluptate possimus. Maxime</li>
                                </ol>
                            </section>
                            <section>
                                <h5>原生段落列表（需要自行添加class）</h5>
                                <ol class="weui-article__list_inside">
                                    <li>Elit quo illum ut voluptateElit quo illum ut voluptate possimus. Maxime</li>
                                    <li>Elit quo illum ut voluptate possimus. Maxime
                <ol>
                    <li>Adipisicing adipisci labore delenitAdipisicing adipisci labore delenitiiAdipisicing adipisci labore deleniti</li>
                    <li>Adipisicing adipisci labore deleniti</li>
                    <li>Adipisicing adipisci labore deleniti</li>
                </ol>
                                    </li>
                                    <li>Elit quo illum ut voluptate possimus. Maxime</li>
                                </ol>
                            </section>
                            <section>
                                <h5>自定义序号列表（需要自行添加class）</h5>
                                <ol class="weui-article__list_none">
                                    <li>1 Elit quo illum ut voluptateElit quo illum ut voluptate possimus. Maxime</li>
                                    <li>2 Elit quo illum ut voluptate possimus. Maxime
                <ol>
                    <li>2.1 Adipisicing adipisci labore delenitAdipisicing adipisci labore delenitiiAdipisicing adipisci labore deleniti</li>
                    <li>2.2 Adipisicing adipisci labore deleniti</li>
                    <li>2.3 Adipisicing adipisci labore deleniti</li>
                </ol>
                                    </li>
                                    <li>3 Elit quo illum ut voluptate possimus. Maxime</li>
                                </ol>
                            </section>
                        </section>
                    </section>
                </section>
                <section>
                    <h2>无障碍焦点整合示例</h2>
                    <section>
                        <p class="weui-a11y-combo">
                            <input class="weui-a11y-combo__helper" aria-labelledby="txt1 txt2" type="text" readonly role="option">
                            <span id="txt1" class="weui-a11y-combo__content" aria-hidden="true">Ipsum cum soluta laudantium aperiam rem? Accusamus nostrum itaque sint?
                            </span>
                            <a id="txt2" class="weui-a11y-combo__content weui-link weui-wa-hotarea " href="#">read more</a>
                        </p>
                    </section>
                </section>
            </article>
        </div>
    </script>
    <script type="text/html" id="tpl_navbar">
        <div class="page">
            <div class="page__bd" style="height: 100%;">
                <div class="weui-tab">
                    <div class="weui-navbar">
                        <div role="tab" aria-selected="true" aria-controls="panel1" id="tab1" class="weui-navbar__item weui-bar__item_on">
                            选项一
                        </div>
                        <div role="tab" aria-controls="panel2" id="tab2" class="weui-navbar__item">
                            选项二
                        </div>
                        <div role="tab" aria-controls="panel3" id="tab3" class="weui-navbar__item">
                            选项三
                        </div>
                    </div>
                    <div role="tabpanel" id="panel1" aria-labelledby="tab1" class="weui-tab__panel">Sit sit quibusdam assumenda facilis magnam temporibus? Molestiae qui ad accusantium minus mollitia Esse maiores voluptates suscipit fugit veritatis numquam repellat omnis. Dolores facilis deleniti reiciendis ea beatae Quaerat soluta</div>
                    <div style="display: none;" role="tabpanel" id="panel2" aria-labelledby="tab2" class="weui-tab__panel">Consectetur neque facere modi recusandae tempore. Sit repellendus qui voluptatibus voluptas porro perspiciatis. Incidunt iusto soluta esse ipsum ex. Consectetur blanditiis dolor facere dignissimos minus quam libero? Nemo voluptas aperiam?</div>
                    <div style="display: none;" role="tabpanel" id="panel3" aria-labelledby="tab3" class="weui-tab__panel">Dolor magnam expedita ex beatae maiores assumenda Doloribus et totam numquam officiis beatae Sint eos saepe magnam error aut Doloremque necessitatibus eligendi quod fuga debitis. Error ad optio repellendus amet.</div>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            $('.weui-navbar__item').on('click', function () {
                $(this).attr('aria-selected', 'true').addClass('weui-bar__item_on');
                $(this).siblings('.weui-bar__item_on').removeClass('weui-bar__item_on').attr('aria-selected', 'false');
                var panelId = '#' + $(this).attr('aria-controls');
                $(panelId).css('display', 'block');
                $(panelId).siblings('.weui-tab__panel').css('display', 'none');
            });
        });</script>
    <script type="text/html" id="tpl_tabbar">
        <div class="page">
            <div class="page__bd" style="height: 100%;">
                <div class="weui-tab">
                    <div id="panel1" role="tabpanel" aria-labelledby="tab1" class="weui-tab__panel">Lorem repellat eius consectetur ab pariatur! Facere cum dignissimos sequi error perferendis quis Ipsa reiciendis earum cumque reprehenderit tenetur ab vero modi. Soluta tempore minima tempora quae voluptate! Sunt delectus?</div>
                    <div id="panel2" role="tabpanel" aria-labelledby="tab2" class="weui-tab__panel" style="display: none;">Dolor eum rerum magnam voluptatem omnis fuga, dolore libero quibusdam cupiditate Sequi vero rem corrupti hic veritatis Atque exercitationem odit odit ducimus esse, sapiente laborum inventore! Ipsum harum quo minus</div>
                    <div id="panel3" role="tabpanel" aria-labelledby="tab3" class="weui-tab__panel" style="display: none;">Elit deserunt dolore nemo harum neque libero numquam, minima nam Atque nesciunt iusto aperiam eligendi praesentium ratione? Quasi iste odio itaque doloribus hic? Est aliquam recusandae dolore ratione quos. Saepe</div>
                    <div id="panel4" role="tabpanel" aria-labelledby="tab4" class="weui-tab__panel" style="display: none;">Amet dignissimos doloribus voluptate maxime dolorem quia Deleniti eligendi similique nisi corrupti eius aut Unde nesciunt quos quos sapiente dolorem? Odit soluta repudiandae accusantium ducimus totam accusamus. Rem ad numquam</div>
                    <div role="tablist" aria-label="选项卡标题" class="weui-tabbar">
                        <div id="tab1" role="tab" aria-labelledby="t1_title" aria-describedby="t1_tips" aria-selected="true" aria-controls="panel1" class="weui-tabbar__item weui-bar__item_on">
                            <div id="t1_tips" aria-hidden="true" style="display: inline-block; position: relative;">
                                <img src="images/icon_tabbar.png" alt="" class="weui-tabbar__icon">
                                <span class="weui-badge" style="position: absolute; top: -2px; right: -13px;">8</span>
                            </div>
                            <p id="t1_title" aria-hidden="true" class="weui-tabbar__label">微信</p>
                        </div>
                        <div id="tab2" role="tab" aria-labelledby="t2_title" aria-selected="false" aria-controls="panel2" class="weui-tabbar__item">
                            <img src="images/icon_tabbar.png" alt="" class="weui-tabbar__icon">
                            <p aria-hidden="true" id="t2_title" class="weui-tabbar__label">通讯录</p>
                        </div>
                        <div id="tab3" role="tab" aria-labelledby="t3_title" aria-describedby="t3_tips" aria-selected="false" aria-controls="panel3" class="weui-tabbar__item">
                            <div id="t3_tips" aria-hidden="true" style="display: inline-block; position: relative;">
                                <img src="images/icon_tabbar.png" alt="" class="weui-tabbar__icon">
                                <span class="weui-badge weui-badge_dot" role="img" alt="new" style="position: absolute; top: 0; right: -6px;"></span>
                            </div>
                            <p id="t3_title" aria-hidden="true" class="weui-tabbar__label">发现</p>
                        </div>
                        <div id="tab4" role="tab" aria-labelledby="t4_title" aria-selected="false" aria-controls="panel4" class="weui-tabbar__item">
                            <img src="images/icon_tabbar.png" alt="" class="weui-tabbar__icon">
                            <p class="weui-tabbar__label" aria-hidden="true" id="t4_title">我</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            $('.weui-tabbar__item').on('click', function () {
                $(this).attr('aria-selected', 'true').addClass('weui-bar__item_on');
                $(this).siblings('.weui-bar__item_on').removeClass('weui-bar__item_on').attr('aria-selected', 'false');
                var panelId = '#' + $(this).attr('aria-controls');
                $(panelId).css('display', 'block');
                $(panelId).siblings('.weui-tab__panel').css('display', 'none');
            });
        });</script>
    <script type="text/html" id="tpl_panel">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Panel</h1>
                <p class="page__desc">面板</p>
            </div>
            <div class="page__bd">
                <div class="weui-panel weui-panel_access">
                    <div class="weui-panel__hd">图文组合列表</div>
                    <div class="weui-panel__bd">
                        <a aria-labelledby="js_p1m1_bd" href="javascript:" class="weui-media-box weui-media-box_appmsg">
                            <div aria-hidden="true" class="weui-media-box__hd">
                                <img class="weui-media-box__thumb" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHgAAAB4CAMAAAAOusbgAAAAeFBMVEUAwAD///+U5ZTc9twOww7G8MYwzDCH4YcfyR9x23Hw+/DY9dhm2WZG0kbT9NP0/PTL8sux7LFe115T1VM+zz7i+OIXxhes6qxr2mvA8MCe6J6M4oz6/frr+us5zjn2/fa67rqB4IF13XWn6ad83nxa1loqyirn+eccHxx4AAAC/klEQVRo3u2W2ZKiQBBF8wpCNSCyLwri7v//4bRIFVXoTBBB+DAReV5sG6lTXDITiGEYhmEYhmEYhmEYhmEY5v9i5fsZGRx9PyGDne8f6K9cfd+mKXe1yNG/0CcqYE86AkBMBh66f20deBc7wA/1WFiTwvSEpBMA2JJOBsSLxe/4QEEaJRrASP8EVF8Q74GbmevKg0saa0B8QbwBdjRyADYxIhqxAZ++IKYtciPXLQVG+imw+oo4Bu56rjEJ4GYsvPmKOAB+xlz7L5aevqUXuePWVhvWJ4eWiwUQ67mK51qPj4dFDMlRLBZTqF3SDvmr4BwtkECu5gHWPkmDfQh02WLxXuvbvC8ku8F57GsI5e0CmUwLz1kq3kD17R1In5816rGvQ5VMk5FEtIiWislTffuDpl/k/PzscdQsv8r9qWq4LRWX6tQYtTxvI3XyrwdyQxChXioOngH3dLgOFjk0all56XRi/wDFQrGQU3Os5t0wJu1GNtNKHdPqYaGYQuRDfbfDf26AGLYSyGS3ZAK4S8XuoAlxGSdYMKwqZKM9XJMtyqXi7HX/CiAZS6d8bSVUz5J36mEMFDTlAFQzxOT1dzLRljjB6+++ejFqka+mXIe6F59mw22OuOw1F4T6lg/9VjL1rLDoI9Xzl1MSYDNHnPQnt3D1EE7PrXjye/3pVpr1Z45hMUdcACc5NVQI0bOdS1WA0wuz73e7/5TNqBPhQXPEFGJNV2zNqWI7QKBd2Gn6AiBko02zuAOXeWIXjV0jNqdKegaE/kJQ6Bfs4aju04lMLkA2T5wBSYPKDGF3RKhFYEa6A1L1LG2yacmsaZ6YPOSAMKNsO+N5dNTfkc5Aqe26uxHpx7ZirvgCwJpWq/lmX1hA7LyabQ34tt5RiJKXSwQ+0KU0V5xg+hZrd4Bn1n4EID+WkQdgLfRNtvil9SPfwy+WQ7PFBWQz6dGWZBLkeJFXZGCfLUjCgGgqXo5TuSu3cugdcTv/HjqnBTEMwzAMwzAMwzAMwzAMw/zf/AFbXiOA6frlMAAAAABJRU5ErkJggg==" alt="">
                            </div>
                            <div aria-hidden="true" id="js_p1m1_bd" class="weui-media-box__bd">
                                <strong class="weui-media-box__title">标题一</strong>
                                <p class="weui-media-box__desc">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                            </div>
                        </a>
                        <a aria-labelledby="js_p1m2_bd" href="javascript:" class="weui-media-box weui-media-box_appmsg">
                            <div aria-hidden="true" class="weui-media-box__hd">
                                <img class="weui-media-box__thumb" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHgAAAB4CAMAAAAOusbgAAAAeFBMVEUAwAD///+U5ZTc9twOww7G8MYwzDCH4YcfyR9x23Hw+/DY9dhm2WZG0kbT9NP0/PTL8sux7LFe115T1VM+zz7i+OIXxhes6qxr2mvA8MCe6J6M4oz6/frr+us5zjn2/fa67rqB4IF13XWn6ad83nxa1loqyirn+eccHxx4AAAC/klEQVRo3u2W2ZKiQBBF8wpCNSCyLwri7v//4bRIFVXoTBBB+DAReV5sG6lTXDITiGEYhmEYhmEYhmEYhmEY5v9i5fsZGRx9PyGDne8f6K9cfd+mKXe1yNG/0CcqYE86AkBMBh66f20deBc7wA/1WFiTwvSEpBMA2JJOBsSLxe/4QEEaJRrASP8EVF8Q74GbmevKg0saa0B8QbwBdjRyADYxIhqxAZ++IKYtciPXLQVG+imw+oo4Bu56rjEJ4GYsvPmKOAB+xlz7L5aevqUXuePWVhvWJ4eWiwUQ67mK51qPj4dFDMlRLBZTqF3SDvmr4BwtkECu5gHWPkmDfQh02WLxXuvbvC8ku8F57GsI5e0CmUwLz1kq3kD17R1In5816rGvQ5VMk5FEtIiWislTffuDpl/k/PzscdQsv8r9qWq4LRWX6tQYtTxvI3XyrwdyQxChXioOngH3dLgOFjk0all56XRi/wDFQrGQU3Os5t0wJu1GNtNKHdPqYaGYQuRDfbfDf26AGLYSyGS3ZAK4S8XuoAlxGSdYMKwqZKM9XJMtyqXi7HX/CiAZS6d8bSVUz5J36mEMFDTlAFQzxOT1dzLRljjB6+++ejFqka+mXIe6F59mw22OuOw1F4T6lg/9VjL1rLDoI9Xzl1MSYDNHnPQnt3D1EE7PrXjye/3pVpr1Z45hMUdcACc5NVQI0bOdS1WA0wuz73e7/5TNqBPhQXPEFGJNV2zNqWI7QKBd2Gn6AiBko02zuAOXeWIXjV0jNqdKegaE/kJQ6Bfs4aju04lMLkA2T5wBSYPKDGF3RKhFYEa6A1L1LG2yacmsaZ6YPOSAMKNsO+N5dNTfkc5Aqe26uxHpx7ZirvgCwJpWq/lmX1hA7LyabQ34tt5RiJKXSwQ+0KU0V5xg+hZrd4Bn1n4EID+WkQdgLfRNtvil9SPfwy+WQ7PFBWQz6dGWZBLkeJFXZGCfLUjCgGgqXo5TuSu3cugdcTv/HjqnBTEMwzAMwzAMwzAMwzAMw/zf/AFbXiOA6frlMAAAAABJRU5ErkJggg==" alt="">
                            </div>
                            <div aria-hidden="true" id="js_p1m2_bd" class="weui-media-box__bd">
                                <strong class="weui-media-box__title">标题二</strong>
                                <p class="weui-media-box__desc">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                            </div>
                        </a>
                    </div>
                    <div class="weui-panel__ft">
                        <a href="javascript:" class="weui-cell weui-cell_active weui-cell_access weui-cell_link">
                            <span class="weui-cell__bd">查看更多</span>
                            <span class="weui-cell__ft"></span>
                        </a>
                    </div>
                </div>
                <div class="weui-panel weui-panel_access">
                    <div class="weui-panel__hd">文字组合列表</div>
                    <div class="weui-panel__bd">
                        <div role="option" class="weui-media-box weui-media-box_text">
                            <strong class="weui-media-box__title">标题一</strong>
                            <p class="weui-media-box__desc">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                        </div>
                        <div role="option" class="weui-media-box weui-media-box_text">
                            <strong class="weui-media-box__title">标题二</strong>
                            <p class="weui-media-box__desc">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                        </div>
                    </div>
                    <div class="weui-panel__ft">
                        <a href="javascript:" class="weui-cell weui-cell_active weui-cell_access weui-cell_link">
                            <span class="weui-cell__bd">查看更多</span>
                            <span class="weui-cell__ft"></span>
                        </a>
                    </div>
                </div>
                <div class="weui-panel">
                    <div class="weui-panel__hd">小图文组合列表</div>
                    <div class="weui-panel__bd">
                        <div class="weui-media-box weui-media-box_small-appmsg">
                            <div class="weui-cells">
                                <a aria-labelledby="t1 t2" class="weui-cell weui-cell_active weui-cell_access weui-cell_example" href="javascript:">
                                    <div aria-hidden="true" id="t1" class="weui-cell__hd">
                                        <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="">
                                    </div>
                                    <div aria-hidden="true" id="t2" class="weui-cell__bd weui-cell_primary">
                                        <p>文字标题</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                                <a aria-labelledby="t3 t4" class="weui-cell weui-cell_active weui-cell_access weui-cell_example" href="javascript:">
                                    <div aria-hidden="true" id="t3" class="weui-cell__hd">
                                        <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=" alt="">
                                    </div>
                                    <div aria-hidden="true" id="t4" class="weui-cell__bd weui-cell_primary">
                                        <p>文字标题</p>
                                    </div>
                                    <div class="weui-cell__ft"></div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="weui-panel">
                    <div class="weui-panel__hd">文字列表附来源</div>
                    <div class="weui-panel__bd">
                        <div role="link" aria-labelledby="js_p4m1_title js_a11y_comma js_p4m1_desc" aria-describedby="js_p4m1_source js_a11y_comma js_p4m1_time js_a11y_comma js_p4m1_extra" class="weui-media-box weui-media-box_text">
                            <strong aria-hidden="true" class="weui-media-box__title" id="js_p4m1_title">标题一</strong>
                            <p class="weui-media-box__desc" aria-hidden="true" id="js_p4m1_desc">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                            <ul class="weui-media-box__info" aria-hidden="true">
                                <li class="weui-media-box__info__meta" aria-hidden="true" id="js_p4m1_source">文字来源</li>
                                <li class="weui-media-box__info__meta" aria-hidden="true" id="js_p4m1_time">时间</li>
                                <li class="weui-media-box__info__meta weui-media-box__info__meta_extra" aria-hidden="true" id="js_p4m1_extra">其它信息</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_actionsheet">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">ActionSheet</h1>
                <p class="page__desc">弹出式菜单</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showIOSActionSheet">ActionSheet</a>
            </div>
            <!--BEGIN actionSheet-->
            <div>
                <div class="weui-mask" id="iosMask" style="display: none;"></div>
                <div role="dialog" aria-modal="true" tabindex="0" aria-hidden="true" class="weui-actionsheet" id="iosActionsheet">
                    <div class="weui-actionsheet__title">
                        <p class="weui-actionsheet__title-text">这是一个标题，可以为一行或者两行。</p>
                    </div>
                    <div class="weui-actionsheet__menu">
                        <div id="current1" tabindex="0" role="button" class="weui-actionsheet__cell">示例菜单</div>
                        <div role="button" tabindex="0" class="weui-actionsheet__cell">示例菜单</div>
                        <div role="button" tabindex="0" class="weui-actionsheet__cell weui-actionsheet__cell_warn">负向菜单</div>
                    </div>
                    <div class="weui-actionsheet__action">
                        <div role="button" tabindex="0" class="weui-actionsheet__cell" id="iosActionsheetCancel">取消</div>
                    </div>
                </div>
            </div>

            <div role="dialog" aria-modal="true" aria-hidden="true" class="weui-skin_android" id="androidActionsheet" style="display: none;">
                <div id="androidClose" tabindex="0" role="option" aria-label="关闭" class="weui-mask"></div>
                <div class="weui-actionsheet">
                    <div class="weui-actionsheet__menu">
                        <div tabindex="0" role="button" class="weui-actionsheet__cell">示例菜单</div>
                        <div tabindex="0" role="button" class="weui-actionsheet__cell">示例菜单</div>
                        <div tabindex="0" role="button" class="weui-actionsheet__cell">示例菜单</div>
                    </div>
                </div>
            </div>
            <!--END actionSheet-->
        </div>
    </script>

    <script type="text/javascript">
        // ios
        $(function () {
            var $iosActionsheet = $('#iosActionsheet');
            var $iosMask = $('#iosMask');

            function hideActionSheet() {
                $iosActionsheet.removeClass('weui-actionsheet_toggle').attr('aria-hidden', 'true');
                $iosMask.fadeOut(200);
                $('#showIOSActionSheet').trigger('focus');
            }

            $iosMask.on('click', hideActionSheet);
            $('#iosActionsheetCancel').on('click', hideActionSheet);
            $("#showIOSActionSheet").on("click", function () {
                $iosActionsheet.attr('aria-hidden', 'false').addClass('weui-actionsheet_toggle');
                $iosMask.fadeIn(200);
                setTimeout(function () {
                    $('#current1').trigger('focus');
                }, 200)
            });
        });

        // android
        $(function () {
            var $androidActionSheet = $('#androidActionsheet');

            $("#showAndroidActionSheet").on('click', function () {
                $androidActionSheet.attr('aria-hidden', 'false').fadeIn(200);
                setTimeout(function () {
                    $('#androidClose').trigger('focus');
                }, 200)
            });
            $('#androidClose').on('click', function () {
                $androidActionSheet.attr('aria-hidden', 'true').fadeOut(200);
                $('#showAndroidActionSheet').trigger('focus');
            });

        });</script>
    <script type="text/html" id="tpl_icons">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Icons</h1>
                <p class="page__desc">图标</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <div class="icon-box">
                    <i role="img" title="成功" aria-describedby="tip_1" class="weui-icon-success weui-icon_msg"></i>
                    <div class="icon-box__ctn" aria-hidden="true">
                        <h3 class="icon-box__title">成功</h3>
                        <p class="icon-box__desc" id="tip_1">用于表示操作顺利达成</p>
                    </div>
                </div>
                <div class="icon-box">
                    <i role="img" title="提示" aria-describedby="tip_2" class="weui-icon-info weui-icon_msg"></i>
                    <div class="icon-box__ctn" aria-hidden="true">
                        <h3 class="icon-box__title">提示</h3>
                        <p class="icon-box__desc" id="tip_2">用于表示信息提示；也常用于缺乏条件的操作拦截，提示用户所需信息</p>
                    </div>
                </div>
                <div class="icon-box">
                    <i role="img" title="普通警告" class="weui-icon-warn weui-icon_msg-primary"></i>
                    <div class="icon-box__ctn" aria-hidden="true">
                        <h3 class="icon-box__title">普通警告</h3>
                        <p class="icon-box__desc">用于表示操作后将引起一定后果的情况</p>
                    </div>
                </div>
                <div class="icon-box">
                    <i role="img" title="强烈警告" class="weui-icon-warn weui-icon_msg"></i>
                    <div class="icon-box__ctn" aria-hidden="true">
                        <h3 class="icon-box__title">强烈警告</h3>
                        <p class="icon-box__desc">用于表示操作后将引起严重的不可挽回的后果的情况</p>
                    </div>
                </div>
                <div class="icon-box">
                    <i role="img" title="等待" class="weui-icon-waiting weui-icon_msg"></i>
                    <div class="icon-box__ctn" aria-hidden="true">
                        <h3 class="icon-box__title">等待</h3>
                        <p class="icon-box__desc">用于表示等待</p>
                    </div>
                </div>
                <!--
        <div class="icon_sp_area">
            <i role="img" class="weui-icon-circle"></i>
            <i role="img" class="weui-icon-success"></i>
            <i role="img" class="weui-icon-success-circle"></i>
            <i role="img" class="weui-icon-success-no-circle"></i>
            <i role="img" class="weui-icon-success-no-circle-thin"></i>
            <i role="img" class="weui-icon-warn"></i>
            <i role="img" class="weui-icon-info-circle"></i>
            <i role="img" class="weui-icon-waiting-circle"></i>
            <i role="img" class="weui-icon-download"></i>
            <i role="img" class="weui-icon-search"></i>
            <i role="img" class="weui-icon-cancel"></i>
            <i role="img" class="weui-icon-clear"></i>
            <i role="img" class="weui-icon-arrow-bold"></i>
            <i role="img" class="weui-icon-arrow"></i>
        </div>
        <div class="icon_sp_area">
            <i role="img" class="weui-icon-close"></i>
            <i role="img" class="weui-icon-close-thin"></i>
            <i role="img" class="weui-icon-back-arrow"></i>
            <i role="img" class="weui-icon-back-arrow-thin"></i>
            <i role="img" class="weui-icon-back"></i>
            <i role="img" class="weui-icon-back-circle"></i>
        </div>
        -->
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_searchbar">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">SearchBar</h1>
                <p class="page__desc">搜索栏</p>
            </div>
            <div class="page__bd">
                <div class="weui-search-bar" id="searchBar">
                    <form id="searchForm" role="combobox" aria-haspopup="true" aria-expanded="false" aria-owns="searchResult" class="weui-search-bar__form">
                        <div class="weui-search-bar__box">
                            <i class="weui-icon-search"></i>
                            <input type="search" aria-controls="searchResult" class="weui-search-bar__input" id="searchInput" placeholder="搜索" required />
                            <a href="javascript:" role="button" title="清除" class="weui-icon-clear" id="searchClear"></a>
                        </div>
                        <label for="searchInput" class="weui-search-bar__label" id="searchText">
                            <i class="weui-icon-search"></i>
                            <span aria-hidden="true">搜索</span>
                        </label>
                    </form>
                    <a href="javascript:" role="button" class="weui-search-bar__cancel-btn" id="searchCancel">取消</a>
                </div>
                <div role="listbox" class="weui-cells searchbar-result" id="searchResult">
                    <div role="option" class="weui-cell weui-cell_active weui-cell_access">
                        <div class="weui-cell__bd weui-cell_primary">
                            <p>实时搜索文本</p>
                        </div>
                    </div>
                    <div role="option" class="weui-cell weui-cell_active weui-cell_access">
                        <div class="weui-cell__bd weui-cell_primary">
                            <p>实时搜索文本</p>
                        </div>
                    </div>
                    <div role="option" class="weui-cell weui-cell_active weui-cell_access">
                        <div class="weui-cell__bd weui-cell_primary">
                            <p>实时搜索文本</p>
                        </div>
                    </div>
                    <div role="option" class="weui-cell weui-cell_active weui-cell_access">
                        <div class="weui-cell__bd weui-cell_primary">
                            <p>实时搜索文本</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $searchBar = $('#searchBar'),
                $searchResult = $('#searchResult'),
                $searchText = $('#searchText'),
                $searchInput = $('#searchInput'),
                $searchClear = $('#searchClear'),
                $searchForm = $('#searchForm'),
                $searchCancel = $('#searchCancel');

            function hideSearchResult() {
                $searchResult.hide();
                $searchForm.attr('aria-expanded', 'false');
                $searchInput.val('');
            }
            function cancelSearch() {
                hideSearchResult();
                $searchBar.removeClass('weui-search-bar_focusing');
                $searchText.show();
            }

            $searchText.on('click', function () {
                $searchBar.addClass('weui-search-bar_focusing');
                $searchInput.focus();
            });
            $searchInput
                .on('blur', function () {
                    if (!this.value.length) cancelSearch();
                })
                .on('input', function () {
                    if (this.value.length) {
                        $searchResult.show();
                        $searchForm.attr('aria-expanded', 'true');
                    } else {
                        $searchResult.hide();
                        $searchForm.attr('aria-expanded', 'false');
                    }
                })
                ;
            $searchClear.on('click', function () {
                hideSearchResult();
                $searchInput.focus();
            });
            $searchCancel.on('click', function () {
                cancelSearch();
                $searchInput.blur();
            });
        });</script>
    <script type="text/html" id="tpl_picker">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Picker</h1>
                <p class="page__desc">多列选择器，需要配合js实现</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showPicker">单列选择器</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showDatePicker">日期选择器</a>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $('#showPicker').on('click', function () {
            weui.picker([{
                label: '飞机票',
                value: 0
            }, {
                label: '火车票',
                value: 1
            }, {
                label: '的士票',
                value: 2
            }, {
                label: '公交票 (disabled)',
                disabled: true,
                value: 3
            }, {
                label: '其他',
                value: 4
            }], {
                onChange: function (result) {
                    console.log(result);
                },
                onConfirm: function (result) {
                    console.log(result);
                },
                title: '单列选择器',
                showClose: false
            });
        });
        $('#showDatePicker').on('click', function () {
            weui.datePicker({
                start: 1990,
                end: new Date().getFullYear(),
                onChange: function (result) {
                    console.log(result);
                },
                onConfirm: function (result) {
                    console.log(result);
                },
                title: '多列选择器'
            });
        });</script>
    <script type="text/html" id="tpl_footer">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Footer</h1>
                <p class="page__desc">页脚</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <div class="weui-footer">
                    <p class="weui-footer__text">Copyright &copy; 2008-2022 weui.io</p>
                </div>
                <br>
                <br>
                <div class="weui-footer">
                    <p class="weui-footer__links">
                        <a href="javascript:" class="weui-footer__link weui-wa-hotarea">底部链接</a>
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2008-2022 weui.io</p>
                </div>
                <br>
                <br>
                <div class="weui-footer">
                    <p class="weui-footer__links">
                        <a href="javascript:" class="weui-footer__link weui-wa-hotarea">底部链接</a>
                        <a href="javascript:" class="weui-footer__link weui-wa-hotarea">底部链接</a>
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2008-2022 weui.io</p>
                </div>
                <div class="weui-footer weui-footer_fixed-bottom">
                    <p class="weui-footer__links">
                        <a href="javascript:home();" class="weui-footer__link weui-wa-hotarea">WeUI首页</a>
                    </p>
                    <p class="weui-footer__text">Copyright &copy; 2008-2022 weui.io</p>
                    <a href="//beian.miit.gov.cn/" class="page_copyright">备案号：粤B2-20090059
                    </a>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_gallery">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Gallery</h1>
                <p class="page__desc">画廊，可实现上传图片的展示或幻灯片播放</p>
            </div>
            <div style="display: none;" role="dialog" aria-labelledby="galleryImg" aria-hidden="true" aria-modal="true" class="weui-gallery" id="gallery">
                <span id="galleryImg" alt="图片详情" role="img" class="weui-gallery__img" style="background-image: url(images/pic_article.png);"></span>
                <div class="weui-gallery__opr">
                    <a role="button" aria-label="删除" href="javascript:" class="weui-gallery__del">
                        <i class="weui-icon-delete weui-icon_gallery-delete"></i>
                    </a>
                </div>
            </div>
        </div>
    </script>

    <script>
        $(function () {
            $gallery = $("#gallery");
            $galleryImg = $("#galleryImg");
            $gallery.attr('aria-hidden', 'false');
            $gallery.fadeIn(100);
            setTimeout(function () {
                $galleryImg.attr("tabindex", '-1').trigger('focus');
            }, 200);
        })</script>
    <script type="text/html" id="tpl_flex">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Flex</h1>
                <p class="page__desc">Flex布局</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <div class="weui-flex">
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                </div>
                <div class="weui-flex">
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                </div>
                <div class="weui-flex">
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                </div>
                <div class="weui-flex">
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                </div>
                <div class="weui-flex">
                    <div>
                        <div class="placeholder">weui</div>
                    </div>
                    <div class="weui-flex__item">
                        <div class="placeholder">weui</div>
                    </div>
                    <div>
                        <div class="placeholder">weui</div>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_loading">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Loading</h1>
                <p class="page__desc">正在加载</p>
            </div>
            <div class="page__bd">
                <div class="loading_demo">
                    <div class="loading_demo_inner">
                        <i role="img" aria-label="正在加载" class="weui-loading"></i>
                        <i role="img" aria-label="正在加载" class="weui-mask-loading"></i>
                        <i role="img" aria-label="正在加载" class="weui-mask-loading" style="color: var(--weui-BRAND);"></i>
                        <i role="img" aria-label="正在加载" class="weui-mask-loading" style="color: #EDEDED"></i>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_loadmore">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Loadmore</h1>
                <p class="page__desc">加载更多</p>
            </div>
            <div class="page__bd">
                <div role="alert" class="weui-loadmore">
                    <span aria-hidden="true" role="img" aria-label="正在加载" class="weui-primary-loading">
                        <i class="weui-primary-loading__dot"></i>
                    </span>
                    <span class="weui-loadmore__tips">正在加载</span>
                </div>
                <div class="weui-loadmore weui-loadmore_line">
                    <span class="weui-loadmore__tips">暂无数据</span>
                </div>
                <div role="option" class="weui-loadmore weui-loadmore_line weui-loadmore_dot">
                    <div class="weui-hidden_abs">已无更多数据</div>
                    <span class="weui-loadmore__tips"></span>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_uploader">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Uploader</h1>
                <p id="x123" class="page__desc">
                    <input class="weui-hidden_abs" readonly style="width: 1px; height: 1px;" aria-labelledby="x123" role="option">
                    上传组件，一般配合<a class="weui-wa-hotarea link" href="#gallery">组件Gallery</a>来使用。
                </p>
            </div>
            <div class="page__bd">
                <div role="dialog" aria-hidden="true" aria-modal="true" class="weui-gallery" id="gallery">
                    <span role="img" tabindex="0" class="weui-gallery__img" id="galleryImg"></span>
                    <div class="weui-gallery__opr">
                        <a role="button" aria-label="删除" href="javascript:" class="weui-gallery__del">
                            <i class="weui-icon-delete weui-icon_gallery-delete"></i>
                        </a>
                    </div>
                </div>

                <div class="weui-cells weui-cells_form">
                    <div class="weui-cell  weui-cell_uploader">
                        <div class="weui-cell__bd">
                            <div class="weui-uploader">
                                <div class="weui-uploader__hd" role="option" aria-labelledby="js_uploader_title js_a11y_comma js_uploader_current_num js_uploader_unit js_a11y_comma js_uploader_max_tips js_uploader_max_num js_uploader_unit">
                                    <p id="js_uploader_title" class="weui-uploader__title">图片上传</p>
                                    <div class="weui-uploader__info">
                                        <span id="js_uploader_current_num">0</span>/<span id="js_uploader_max_num">2</span>
                                    </div>
                                    <div id="js_uploader_unit" class="weui-hidden_abs">张</div>
                                    <div id="js_uploader_max_tips" class="weui-hidden_abs">可上传</div>
                                </div>
                                <div class="weui-uploader__bd">
                                    <ul class="weui-uploader__files" id="uploaderFiles">
                                        <li class="weui-uploader__file" role="img" aria-label="图片标题" title="轻点两下查看大图" tabindex="0" style="background-image: url(images/pic_160.png);"></li>
                                        <li class="weui-uploader__file" role="img" aria-label="图片标题" title="轻点两下查看大图" tabindex="0" style="background-image: url(images/pic_160.png);"></li>
                                        <li class="weui-uploader__file" role="img" aria-label="图片标题" title="轻点两下查看大图" tabindex="0" style="background-image: url(images/pic_160.png);"></li>
                                        <li class="weui-uploader__file weui-uploader__file_status" style="background-image: url(images/pic_160.png);">
                                            <div role="alert" class="weui-uploader__file-content">
                                                <i role="img" tabindex="0" aria-label="错误" class="weui-icon-warn"></i>
                                            </div>
                                        </li>
                                        <li class="weui-uploader__file weui-uploader__file_status" style="background-image: url(images/pic_160.png);">
                                            <div role="alert" class="weui-uploader__file-content">50%</div>
                                        </li>
                                    </ul>
                                    <div class="weui-uploader__input-box">
                                        <input id="uploaderInput" class="weui-uploader__input" type="file" accept="image/*" multiple />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var tmpl = '<li class="weui-uploader__file" role="img" tabindex="0" style="background-image:url(#url#)"></li>',
                $gallery = $("#gallery"), $galleryImg = $("#galleryImg"),
                $uploaderInput = $("#uploaderInput"),
                $uploaderFiles = $("#uploaderFiles")
                ;

            $uploaderInput.on("change", function (e) {
                var src, url = window.URL || window.webkitURL || window.mozURL, files = e.target.files;
                for (var i = 0, len = files.length; i < len; ++i) {
                    var file = files[i];

                    if (url) {
                        src = url.createObjectURL(file);
                    } else {
                        src = e.target.result;
                    }

                    $uploaderFiles.append($(tmpl.replace('#url#', src)));
                }
            });
            var currentImg;
            $uploaderFiles.on("click", "li", function () {
                $galleryImg.attr("style", this.getAttribute("style"));
                $gallery.attr('aria-hidden', 'false');
                $gallery.attr('aria-modal', 'true');
                $gallery.fadeIn(100);
                setTimeout(function () {
                    $galleryImg.attr("tabindex", '-1').trigger('focus');
                }, 200);
                currentImg = this;
            });
            $gallery.on("click", function () {
                $gallery.attr('aria-modal', 'false');
                $gallery.attr('aria-hidden', 'true');
                $gallery.fadeOut(100);
                setTimeout(function () {
                    $galleryImg.removeAttr("tabindex");
                }, 200);
                currentImg.focus();
            });
        });</script>
    <script type="text/html" id="tpl_preview">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Preview</h1>
                <p class="page__desc">表单预览</p>
            </div>
            <div class="page__bd">
                <div class="weui-form-preview">
                    <div role="option" class="weui-form-preview__hd">
                        <div class="weui-form-preview__item">
                            <label class="weui-form-preview__label">付款金额</label>
                            <em class="weui-form-preview__value">¥2400.00</em>
                        </div>
                    </div>
                    <div role="option" aria-labelledby="p1 js_a11y_comma p2 js_a11y_comma p3" class="weui-form-preview__bd">
                        <div id="p1" class="weui-form-preview__item">
                            <label class="weui-form-preview__label">商品</label>
                            <span class="weui-form-preview__value">电动打蛋机</span>
                        </div>
                        <div id="p2" class="weui-form-preview__item">
                            <label class="weui-form-preview__label">标题标题</label>
                            <span class="weui-form-preview__value">名字名字名字</span>
                        </div>
                        <div id="p3" class="weui-form-preview__item">
                            <label class="weui-form-preview__label">标题标题</label>
                            <span class="weui-form-preview__value">很长很长的名字很长很长的名字很长很长的名字很长很长的名字很长很长的名字</span>
                        </div>
                    </div>
                    <div class="weui-form-preview__ft">
                        <a role="button" class="weui-form-preview__btn weui-form-preview__btn_primary" href="javascript:">操作</a>
                    </div>
                </div>
                <br>
                <div class="weui-form-preview">
                    <div role="option" class="weui-form-preview__hd">
                        <label class="weui-form-preview__label">付款金额</label>
                        <em class="weui-form-preview__value">¥2400.00</em>
                    </div>
                    <div role="option" aria-labelledby="p4 js_a11y_comma p5 js_a11y_comma p6" class="weui-form-preview__bd">
                        <div id="p4" class="weui-form-preview__item">
                            <label class="weui-form-preview__label">商品</label>
                            <span class="weui-form-preview__value">电动打蛋机</span>
                        </div>
                        <div id="p5" class="weui-form-preview__item">
                            <label class="weui-form-preview__label">标题标题</label>
                            <span class="weui-form-preview__value">名字名字名字</span>
                        </div>
                        <div id="p6" class="weui-form-preview__item">
                            <label class="weui-form-preview__label">标题标题</label>
                            <span class="weui-form-preview__value">很长很长的名字很长很长的名字很长很长的名字很长很长的名字很长很长的名字</span>
                        </div>
                    </div>
                    <div class="weui-form-preview__ft">
                        <a role="button" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:">辅助操作</a>
                        <a role="button" class="weui-form-preview__btn weui-form-preview__btn_primary" href="javascript:">操作</a>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_grid">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Grid</h1>
                <p class="page__desc">九宫格</p>
            </div>
            <div class="weui-grids">
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
                <a href="javascript:" class="weui-grid" role="button">
                    <div class="weui-grid__icon">
                        <img src="images/icon_tabbar.png" alt="">
                    </div>
                    <p class="weui-grid__label">Grid</p>
                </a>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_badge">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Badge</h1>
                <p class="page__desc">徽章</p>
            </div>

            <div class="page__bd">
                <div class="weui-cells__title">新消息提示跟摘要信息后，统一在列表右侧</div>
                <div class="weui-cells">
                    <div role="link" aria-labelledby="js_cell_l1_bd js_cell_l1_tips" aria-describedby="js_cell_l1_note" class="weui-cell weui-cell_active weui-cell_access">
                        <div aria-hidden="true" class="weui-cell__bd" id="js_cell_l1_bd">单行列表</div>
                        <div aria-hidden="true" class="weui-cell__ft" id="js_cell_l1_bd" style="font-size: 0;">
                            <span class="demo_badge_tips" id="js_cell_l1_tips">详细信息</span>
                            <span id="js_cell_l1_note" aria-label="，有更新" class="weui-badge weui-badge_dot"></span>
                        </div>
                    </div>
                </div>

                <div class="weui-cells__title">未读数红点跟在主题信息后，统一在列表左侧</div>
                <div class="weui-cells demo_badge_cells">
                    <div role="option" aria-labelledby="b1_txt1" aria-describedby="b1_n1" class="weui-cell weui-cell_active">
                        <div class="weui-cell__hd" aria-hidden="true">
                            <img src="images/pic_160.png" alt="">
                            <span id="b1_n1" class="weui-badge" aria-label="，8个新通知">8</span>
                        </div>
                        <div class="weui-cell__bd" aria-hidden="true" id="b1_txt1">
                            <span>联系人名称</span>
                            <div class="demo_badge_desc">摘要信息</div>
                        </div>
                    </div>
                    <div role="link" aria-labelledby="b2_n1" aria-describedby="b2_txt2" class="weui-cell weui-cell_active weui-cell_access">
                        <span class="weui-cell__bd" aria-hidden="true">
                            <span class="demo_badge_title" id="b2_n1">单行列表</span>
                            <span class="weui-badge" id="b2_txt2" aria-label="，8个新通知">8</span>
                        </span>
                        <span class="weui-cell__ft" aria-hidden="true"></span>
                    </div>
                    <div role="link" aria-labelledby="b3_n1 b3_n2" aria-describedby="b3_txt1 b3_txt1_note" class="weui-cell weui-cell_active weui-cell_access">
                        <span class="weui-cell__bd" aria-hidden="true">
                            <span class="demo_badge_title" id="b3_n1">单行列表</span>
                            <span class="weui-badge" id="b3_txt1" aria-label="">8</span>
                            <span id="b3_txt1_note" class="weui-hidden_abs">个新通知，</span>
                        </span>
                        <span class="weui-cell__ft" aria-hidden="true" id="b3_n2">详细信息</span>
                    </div>

                    <div role="link" aria-labelledby="js_a11y_nt js_a11y_comma js_a11y_nb" class="weui-cell weui-cell_active weui-cell_access">
                        <span class="weui-cell__bd" aria-hidden="true">
                            <span id="js_a11y_nt" class="demo_badge_title">单行列表</span>
                            <span id="js_a11y_nb" class="weui-badge">New</span>
                        </span>
                        <span class="weui-cell__ft" aria-hidden="true"></span>
                    </div>
                </div>
            </div>
        </div>
    </script>
    <script type="text/html" id="tpl_slider">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">Slider</h1>
                <p class="page__desc">滑块</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <div class="weui-slider">
                    <div class="weui-slider__inner">
                        <div style="width: 0;" class="weui-slider__track"></div>
                        <div role="slider" aria-label="不可调滑块" style="left: 0;" class="weui-slider__handler weui-wa-hotarea"></div>
                    </div>
                </div>
                <br>
                <div class="weui-slider-box">
                    <div class="weui-slider">
                        <div id="sliderInner" class="weui-slider__inner">
                            <div id="sliderTrack" style="width: 50%;" class="weui-slider__track"></div>
                            <div role="slider" aria-label="可调滑块" id="sliderHandler" style="left: 50%;" class="weui-slider__handler weui-wa-hotarea"></div>
                        </div>
                    </div>
                    <div id="sliderValue" role="alert" class="weui-slider-box__value">50</div>
                </div>
            </div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            var $sliderTrack = $('#sliderTrack'),
                $sliderHandler = $('#sliderHandler'),
                $sliderValue = $('#sliderValue');

            var totalLen = $('#sliderInner').width(),
                startLeft = 0,
                startX = 0;

            $sliderHandler
                .on('touchstart', function (e) {
                    startLeft = parseInt($sliderHandler.css('left')) * totalLen / 100;
                    startX = e.changedTouches[0].clientX;
                })
                .on('touchmove', function (e) {
                    var dist = startLeft + e.changedTouches[0].clientX - startX,
                        percent;
                    dist = dist < 0 ? 0 : dist > totalLen ? totalLen : dist;
                    percent = parseInt(dist / totalLen * 100);
                    $sliderTrack.css('width', percent + '%');
                    $sliderHandler.css('left', percent + '%');
                    $sliderValue.text(percent);

                    e.preventDefault();
                })
                ;
        });</script>
    <script type="text/html" id="tpl_top-tips">
        <div class="page">
            <div class="page__hd">
                <h1 class="page__title">TopTips</h1>
                <p class="page__desc">顶部提示条</p>
            </div>
            <div class="page__bd page__bd_spacing">
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="showTopTips">显示提示条</a>
                <a href="javascript:" role="button" class="weui-btn weui-btn_default" id="hideTopTips">隐藏提示条</a>
            </div>

            <div role="alert" class="weui-toptips weui-toptips_warn" id="topTips">错误提示</div>
        </div>
    </script>

    <script type="text/javascript">
        $(function () {
            $('#showTopTips').on('click', function () {
                $('#topTips').fadeIn(200);
            });
            $('#hideTopTips').on('click', function () {
                $('#topTips').fadeOut(200);
            });
        });</script>
    <script type="text/template" id="footerTmpl">
        <div class="page__ft">
            <div class="page_logo_wrp">
                <a href="javascript:home()">
                    <img src="images/icon_footer_link.png" /></a>
            </div>
            <div class="weui-footer">
                <div class="weui-footer__text">
                    <a class="weui-footer__text__meta" href="//beian.miit.gov.cn/">备案号：粤B2-20090059</a>
                    <a class="weui-footer__text__meta gongan_meta" href="http://www.beian.gov.cn/portal/registerSystemInfo?recordcode=44030502009285">
                        <img src="images/pic_gongan.png">粤公网安备 44030502009285号</a>

                    <span class="weui-footer__text__meta">公司地址：深圳市南山区粤海街道麻岭社区科技中一路腾讯大厦35层</span>
                    <span class="weui-footer__text__meta">联系电话：4006 700 700</span>
                </div>
                <div class="weui-footer__text">
                    Copyright © 1998 - <span id="js_copyright_year"></span>Tencent All Rights Reserved.
                </div>
            </div>
        </div>
    </script>
    <script src="css/zepto.min.js"></script>
    <script type="text/javascript" src="https://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="https://res.wx.qq.com/t/wx_fed/weui.js/res/1.2.17/weui.min.js"></script>
    <script src="css/example.js"></script>
    <script src="css/wah.js"></script>
    <script type="text/javascript"></script>
    <script type="text/javascript">function wxReady(e) { "object" == typeof WeixinJSBridge && "function" == typeof window.WeixinJSBridge.invoke ? e() : document.addEventListener("WeixinJSBridgeReady", e, !1) } wxReady(function () { WeixinJSBridge.invoke("getUserConfig", {}, function (e) { e.isCareMode && document.body.setAttribute("data-weui-mode", "care") }) })</script>
</body>
</html>
