<%@ Page Title="" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Remember_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<p>
        <span class="btn btn-warning btn-sm">Left</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-info btn-sm">Bottom</span>
        <span class="btn btn-warning btn-sm">Left</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-success btn-sm">Right</span>
        <span class="btn btn-danger btn-sm">Top</span>
        <span class="btn btn-info btn-sm">Bottom</span>
    </p>
    <div class="well">
        <h3 class="red lighter">记忆内容</h3>
        <h6>2021-01-01 第 1 次背诵，已背诵 5 次。</h6>
        <p>
            <span class="label label-warning">Left</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-info">Bottom</span>
            <span class="label label-warning">Left</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-success">Right</span>
            <span class="label label-danger">Top</span>
            <span class="label label-info">Bottom</span>
        </p>
        <div class="btn-group">
            <button class="btn btn-sm btn-success"><i class="icon-ok"></i>完成</button>
            <button class="btn btn-sm btn-danger"><i class="icon-eye-close"></i>很熟</button>
            <button class="btn btn-sm btn-info"><i class="icon-edit"></i>编辑</button>
        </div>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>
    <div class="well">
        <h4 class="red lighter">记忆内容</h4>
    </div>--%>
    <%--   ReturnMsg.InnerHtml += " <div class=\"well\">";
                            ReturnMsg.InnerHtml += "   <h4 class=\"red smaller lighter\">单据被退回</h4>";
                            ReturnMsg.InnerHtml += " <h2>" + OP_Mode.Dtv[0]["ReturnMSG"].ToString() + "</h2>";
    
        ReturnMsg.InnerHtml += " </div>";--%>
    <style>
        .toolbar {
            border: 1px solid #ccc;
        }

        .text {
            border: 1px solid #ccc;
            min-height: 300px;
        }
    </style>
    <div id="full-view-ad"></div>
    <textarea id="init-data" style="display: none">{&quot;__browser&quot;:{&quot;device&quot;:&quot;unknown_device&quot;,&quot;mobile&quot;:false,&quot;name&quot;:&quot;chrome&quot;,&quot;platform&quot;:&quot;pc&quot;,&quot;version&quot;:&quot;91&quot;},&quot;__constants&quot;:{&quot;gridIframeSandboxAttributes&quot;:&quot;allow-forms allow-modals allow-pointer-lock allow-presentation allow-same-origin allow-scripts&quot;},&quot;__CPDATA&quot;:{&quot;domain_iframe&quot;:&quot;https://cdpn.io&quot;,&quot;environment&quot;:&quot;production&quot;,&quot;host&quot;:&quot;codepen.io&quot;,&quot;iframe_allow&quot;:&quot;accelerometer; camera; encrypted-media; geolocation; gyroscope; microphone; midi; clipboard-read; clipboard-write&quot;,&quot;iframe_sandbox&quot;:&quot;allow-downloads allow-forms allow-modals allow-pointer-lock allow-popups allow-presentation allow-same-origin allow-scripts allow-top-navigation-by-user-activation&quot;},&quot;__user&quot;:{&quot;anon&quot;:true,&quot;base_url&quot;:&quot;/anon/&quot;,&quot;current_team_id&quot;:0,&quot;current_team_hashid&quot;:null,&quot;hashid&quot;:&quot;VoDkNZ&quot;,&quot;id&quot;:1,&quot;itemType&quot;:&quot;user&quot;,&quot;name&quot;:&quot;Captain Anonymous&quot;,&quot;paid&quot;:false,&quot;tier&quot;:0,&quot;username&quot;:&quot;anon&quot;,&quot;created_at&quot;:null,&quot;email_verified&quot;:null,&quot;collections_count&quot;:0,&quot;collections_private_count&quot;:0,&quot;followers_count&quot;:0,&quot;followings_count&quot;:0,&quot;pens_count&quot;:0,&quot;pens_private_count&quot;:0,&quot;projects_count&quot;:0,&quot;projects_private_count&quot;:0},&quot;__firebase&quot;:{&quot;config&quot;:{&quot;apiKey&quot;:&quot;AIzaSyBgLAe7N_MdFpuVofMkcQLGwwhUu5tuxls&quot;,&quot;authDomain&quot;:&quot;codepen-store-production.firebaseapp.com&quot;,&quot;databaseURL&quot;:&quot;https://codepen-store-production.firebaseio.com&quot;,&quot;disabled&quot;:false,&quot;projectId&quot;:&quot;codepen-store-production&quot;},&quot;token&quot;:&quot;eyJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJodHRwczovL2lkZW50aXR5dG9vbGtpdC5nb29nbGVhcGlzLmNvbS9nb29nbGUuaWRlbnRpdHkuaWRlbnRpdHl0b29sa2l0LnYxLklkZW50aXR5VG9vbGtpdCIsImNsYWltcyI6eyJvd25lcklkIjoiVm9Ea05aIiwiYWRtaW4iOmZhbHNlfSwiZXhwIjoxNjI2NjY3MTE5LCJpYXQiOjE2MjY2NjM1MTksImlzcyI6ImZpcmViYXNlLWFkbWluc2RrLThva3lsQGNvZGVwZW4tc3RvcmUtcHJvZHVjdGlvbi5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsInN1YiI6ImZpcmViYXNlLWFkbWluc2RrLThva3lsQGNvZGVwZW4tc3RvcmUtcHJvZHVjdGlvbi5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsInVpZCI6IlZvRGtOWiJ9.Ewr9HoomcBz6sic5IQxE8cB6_uk6raI_46qoXDusFS0peFq6cy6bKSm5b-_TyLTWxvGkVsEi7gmZ6LFsUu6kpvSiGvtH_Ejx1FAUHylm-LGOY21Mg5ieywPUrsbVakGvEpLTYArQygXJCHfwVonCfq_so1xBlhxp2k9o0HDDeRvswHGEe-U0qf_r3jOhLYNOvvAIYZNOZ-RYKcBKfheWEk-BGSd7ZruUVV1aenWxxO6EDkItQZixiHTdUKVAc_w-mxjj_jwXO3kdTkc7BAEPlnTQkDU4QPQyRm6EzH3pE-T4yoEmbvA3XX4H4iZP0wdBOZh_MmS_emoYLHcUSSQCaQ&quot;},&quot;__graphql&quot;:{&quot;data&quot;:{&quot;sessionUser&quot;:{&quot;id&quot;:&quot;VoDkNZ&quot;,&quot;name&quot;:&quot;Captain Anonymous&quot;,&quot;avatar80&quot;:&quot;https://gravatar.com/avatar/b15e0cf27861794b6faa31065e8f9950?d=https%3A%2F%2Fassets.codepen.io%2Finternal%2Favatars%2Fusers%2Fdefault.png&amp;fit=crop&amp;format=auto&amp;height=80&amp;version=0&amp;width=80&quot;,&quot;avatar512&quot;:&quot;https://gravatar.com/avatar/b15e0cf27861794b6faa31065e8f9950?d=https%3A%2F%2Fassets.codepen.io%2Finternal%2Favatars%2Fusers%2Fdefault.png&amp;fit=crop&amp;format=auto&amp;height=512&amp;version=0&amp;width=512&quot;,&quot;currentContext&quot;:{&quot;id&quot;:&quot;VoDkNZ&quot;,&quot;baseUrl&quot;:&quot;/anon&quot;,&quot;title&quot;:&quot;Captain Anonymous&quot;,&quot;name&quot;:&quot;Captain Anonymous&quot;,&quot;avatar80&quot;:&quot;https://gravatar.com/avatar/b15e0cf27861794b6faa31065e8f9950?d=https%3A%2F%2Fassets.codepen.io%2Finternal%2Favatars%2Fusers%2Fdefault.png&amp;fit=crop&amp;format=auto&amp;height=80&amp;version=0&amp;width=80&quot;,&quot;avatar512&quot;:&quot;https://gravatar.com/avatar/b15e0cf27861794b6faa31065e8f9950?d=https%3A%2F%2Fassets.codepen.io%2Finternal%2Favatars%2Fusers%2Fdefault.png&amp;fit=crop&amp;format=auto&amp;height=512&amp;version=0&amp;width=512&quot;,&quot;username&quot;:&quot;anon&quot;,&quot;contextType&quot;:&quot;USER&quot;,&quot;projectLimitations&quot;:{&quot;id&quot;:&quot;VoDkNZ&quot;,&quot;projects&quot;:0,&quot;usedProjects&quot;:0,&quot;__typename&quot;:&quot;ProjectLimitations&quot;},&quot;privateByDefault&quot;:false,&quot;__typename&quot;:&quot;User&quot;},&quot;currentTeamId&quot;:null,&quot;baseUrl&quot;:&quot;/anon&quot;,&quot;username&quot;:&quot;anon&quot;,&quot;admin&quot;:false,&quot;anon&quot;:true,&quot;pro&quot;:false,&quot;verified&quot;:null,&quot;teams&quot;:[],&quot;permissions&quot;:{&quot;id&quot;:&quot;1&quot;,&quot;canCreatePrivate&quot;:false,&quot;canUploadAssets&quot;:false,&quot;__typename&quot;:&quot;UserPermissions&quot;},&quot;__typename&quot;:&quot;User&quot;}}},&quot;__pay_stripe_public&quot;:&quot;pk_NgCjQmQs7wXOFmfNC0LKMgEkmlThn&quot;,&quot;__pay_braintree_env&quot;:&quot;production&quot;,&quot;__item&quot;:&quot;{\&quot;id\&quot;:48848634,\&quot;hashid\&quot;:\&quot;ZEpWByR\&quot;,\&quot;itemType\&quot;:\&quot;pen\&quot;,\&quot;user_id\&quot;:5405112,\&quot;slug_hash\&quot;:\&quot;ZEpWByR\&quot;,\&quot;private\&quot;:false,\&quot;slug_hash_private\&quot;:\&quot;40ac3d4d65e3c0ece8573d0a4882bacb\&quot;}&quot;,&quot;__profiled&quot;:{&quot;base_url&quot;:&quot;/xiaokyo-the-bold&quot;,&quot;hashid&quot;:&quot;ogEwWY&quot;,&quot;id&quot;:5405112,&quot;name&quot;:&quot;xiaokyo&quot;,&quot;type&quot;:&quot;user&quot;,&quot;username&quot;:&quot;xiaokyo-the-bold&quot;},&quot;__pageType&quot;:&quot;full&quot;}</textarea>
    <div id="popup-overlay" class="overlay popup-overlay"></div>
    <div id="modal-overlay" class="overlay modal-overlay"></div>
    <script src="https://cpwebassets.codepen.io/assets/common/everypage-71ee875683546ed151c5c18035e1f48d376f0a7a5455ace61e88506dd576a401.js"></script>
    <script src="https://cpwebassets.codepen.io/assets/common/analytics_and_notifications-afa6925cbcff840929f2b7c543587d5f9d7a461af81ee7ca80631c8e37ac42f2.js"></script>
    <script nonce="DSmCPOkd5UE=">
        LUX = (function () { var a = ("undefined" !== typeof (LUX) && "undefined" !== typeof (LUX.gaMarks) ? LUX.gaMarks : []); var d = ("undefined" !== typeof (LUX) && "undefined" !== typeof (LUX.gaMeasures) ? LUX.gaMeasures : []); var j = "LUX_start"; var k = window.performance; var l = ("undefined" !== typeof (LUX) && LUX.ns ? LUX.ns : (Date.now ? Date.now() : +(new Date()))); if (k && k.timing && k.timing.navigationStart) { l = k.timing.navigationStart } function f() { if (k && k.now) { return k.now() } var o = Date.now ? Date.now() : +(new Date()); return o - l } function b(n) { if (k) { if (k.mark) { return k.mark(n) } else { if (k.webkitMark) { return k.webkitMark(n) } } } a.push({ name: n, entryType: "mark", startTime: f(), duration: 0 }); return } function m(p, t, n) { if ("undefined" === typeof (t) && h(j)) { t = j } if (k) { if (k.measure) { if (t) { if (n) { return k.measure(p, t, n) } else { return k.measure(p, t) } } else { return k.measure(p) } } else { if (k.webkitMeasure) { return k.webkitMeasure(p, t, n) } } } var r = 0, o = f(); if (t) { var s = h(t); if (s) { r = s.startTime } else { if (k && k.timing && k.timing[t]) { r = k.timing[t] - k.timing.navigationStart } else { return } } } if (n) { var q = h(n); if (q) { o = q.startTime } else { if (k && k.timing && k.timing[n]) { o = k.timing[n] - k.timing.navigationStart } else { return } } } d.push({ name: p, entryType: "measure", startTime: r, duration: (o - r) }); return } function h(n) { return c(n, g()) } function c(p, o) { for (i = o.length - 1; i >= 0; i--) { var n = o[i]; if (p === n.name) { return n } } return undefined } function g() { if (k) { if (k.getEntriesByType) { return k.getEntriesByType("mark") } else { if (k.webkitGetEntriesByType) { return k.webkitGetEntriesByType("mark") } } } return a } return { mark: b, measure: m, gaMarks: a, gaMeasures: d } })(); LUX.ns = (Date.now ? Date.now() : +(new Date())); LUX.ac = []; LUX.cmd = function (a) { LUX.ac.push(a) }; LUX.init = function () { LUX.cmd(["init"]) }; LUX.send = function () { LUX.cmd(["send"]) }; LUX.addData = function (a, b) { LUX.cmd(["addData", a, b]) }; LUX_ae = []; window.addEventListener("error", function (a) { LUX_ae.push(a) }); LUX_al = []; if ("function" === typeof (PerformanceObserver) && "function" === typeof (PerformanceLongTaskTiming)) { var LongTaskObserver = new PerformanceObserver(function (c) { var b = c.getEntries(); for (var a = 0; a < b.length; a++) { var d = b[a]; LUX_al.push(d) } }); try { LongTaskObserver.observe({ type: ["longtask"] }) } catch (e) { } };
    </script>
    <script src="https://cdn.speedcurve.com/js/lux.js?id=410041" async defer crossorigin="anonymous"></script>
    <script src="https://cpwebassets.codepen.io/assets/packs/js/vendor-53029a15d07de8624ea3.chunk.js"></script>
    <script src="https://cpwebassets.codepen.io/assets/packs/js/4-d592881e48d2f95f55e3.chunk.js"></script>
    <script src="https://cpwebassets.codepen.io/assets/packs/js/everypage-c0aa85ed7de9880bb693.js"></script>
    <script src="https://cpwebassets.codepen.io/assets/editor/full/full_page_renderer-30175378e93f484abef1387dbae3f25f055fc5d1639e7bc8c2811e9ba4bbf1ab.js"></script>

    <script>
        const E = window.wangEditor;
        const editor = new E("#toolbar-container", "#text-container");
        editor.create();
    </script>
    <p>
        wangEditor 工具栏编辑区域分离
    </p>
    <div>
        <div id="toolbar-container" class="toolbar"></div>
        <div id="text-container" class="text"></div>
    </div>
    <script src="https://unpkg.com/wangeditor/dist/wangEditor.min.js"></script>
</asp:Content>

