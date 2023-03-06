<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportAdd.aspx.cs" Inherits="Report_ReportAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        var i = 1
        function addFile() {
            if (i < 80) {
                var str = '<BR><input type="file" name="File" runat="server" capture="camera" accept="image/*" />'
                document.getElementById('MyFile').insertAdjacentHTML("beforeEnd", str)
            }
            else {
                alert("您一次最多只能上传80张图片！")
            }
            i++
        }
    </script>
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="/Default.aspx">首页</a>
            </li>
            <li><a href="/Report/">工作汇报</a></li>
            <li class="active">填写工作汇报</li>
        </ul>
    </div>
    <div class="hr-10"></div>
    <div class="page-header">
        <h1>工作汇报								<small><i class="icon-double-angle-right"></i>&nbsp;填写工作汇报                               </small></h1>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label8" class="col-sm-3 control-label no-padding-right" for="form-field-1">汇报单号：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_No" runat="server" Text="HBD2020-12-01-0001" Font-Bold="true"></asp:Label>
                <asp:Label ID="Label_Flag" runat="server" Text="待提交" Font-Bold="true" ForeColor="Green"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label9" class="col-sm-3 control-label no-padding-right" for="form-field-1">填报人：</label>
            <div class="col-sm-9">
                <asp:Label ID="Label_CName" runat="server" Text="填报人" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label class="col-sm-3 control-label no-padding-right" for="form-field-1">报告类型：</label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>现场勘察</asp:ListItem>
                <asp:ListItem>方案论证</asp:ListItem>
                <asp:ListItem>质检查验</asp:ListItem>
                <asp:ListItem>甲方验收</asp:ListItem>
                <asp:ListItem>公安验收</asp:ListItem>
                <asp:ListItem>参加会议</asp:ListItem>
                <asp:ListItem>参加学习</asp:ListItem>
                <asp:ListItem>投标情况</asp:ListItem>
                <asp:ListItem>其他</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_AddXCKC">
        <%--现场勘查--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label2" class="col-sm-3 control-label no-padding-right" for="form-field-1">勘察地点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_KCDD" ClientIDMode="Static" runat="server" placeholder="请填写勘察地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label1" class="col-sm-3 control-label no-padding-right" for="form-field-1">勘察日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox_KCRQ" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label3" class="col-sm-3 control-label no-padding-right" for="form-field-1">现场勘查概要说明：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server" placeholder="请输入现场勘查概要说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_FALZ">
        <%--方案论证--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label7" class="col-sm-3 control-label no-padding-right" for="form-field-1">项目名称：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox3" ClientIDMode="Static" runat="server" placeholder="请填写项目名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label12" class="col-sm-3 control-label no-padding-right" for="form-field-1">参加论证专家：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox6" ClientIDMode="Static" runat="server" placeholder="请填写专家姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label10" class="col-sm-3 control-label no-padding-right" for="form-field-1">论证日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox4" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label13" class="col-sm-3 control-label no-padding-right" for="form-field-1">论证结果：</label>
                <div class="col-sm-9">
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatColumns="3">
                        <asp:ListItem>&nbsp;通过&nbsp;</asp:ListItem>
                        <asp:ListItem>&nbsp;基本通过&nbsp;</asp:ListItem>
                        <asp:ListItem>&nbsp;不通过&nbsp;</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label11" class="col-sm-3 control-label no-padding-right" for="form-field-1">论证意见：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox5" ClientIDMode="Static" runat="server" placeholder="请输入论证意见或不通过原因，整改要求" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_ZJCYQK">
        <%--质检查验情况--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label14" class="col-sm-3 control-label no-padding-right" for="form-field-1">项目名称：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox7" ClientIDMode="Static" runat="server" placeholder="请填写项目名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label19" class="col-sm-3 control-label no-padding-right" for="form-field-1">施工编号：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox11" ClientIDMode="Static" runat="server" placeholder="请填写施工编号" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label16" class="col-sm-3 control-label no-padding-right" for="form-field-1">查验日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox9" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label15" class="col-sm-3 control-label no-padding-right" for="form-field-1">施工人员：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox8" ClientIDMode="Static" runat="server" placeholder="请填写施工人员姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label18" class="col-sm-3 control-label no-padding-right" for="form-field-1">查验问题：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox10" ClientIDMode="Static" runat="server" placeholder="请输入查验问题或整改要求" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_JFYS">
        <%--甲方验收--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label17" class="col-sm-3 control-label no-padding-right" for="form-field-1">项目名称：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox12" ClientIDMode="Static" runat="server" placeholder="请填写项目名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label20" class="col-sm-3 control-label no-padding-right" for="form-field-1">施工编号：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox13" ClientIDMode="Static" runat="server" placeholder="请填写施工编号" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label21" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox14" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label22" class="col-sm-3 control-label no-padding-right" for="form-field-1">甲方验收人员：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox15" ClientIDMode="Static" runat="server" placeholder="请填写甲方验收人员姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label23" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收结论：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox16" ClientIDMode="Static" runat="server" placeholder="验收结论，存在问题及整改要求" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_GAYS">
        <%--公安验收--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label24" class="col-sm-3 control-label no-padding-right" for="form-field-1">项目名称：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox17" ClientIDMode="Static" runat="server" placeholder="请填写项目名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label26" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox19" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label27" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收专家：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox20" ClientIDMode="Static" runat="server" placeholder="请填写验收专家姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label25" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收结果：</label>
                <div class="col-sm-9">
                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatColumns="3">
                        <asp:ListItem>&nbsp;通过&nbsp;</asp:ListItem>
                        <asp:ListItem>&nbsp;基本通过&nbsp;</asp:ListItem>
                        <asp:ListItem>&nbsp;不通过&nbsp;</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label28" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收情况：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox21" ClientIDMode="Static" runat="server" placeholder="请输入验收情况说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_CJHY">
        <%--参加会议--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label29" class="col-sm-3 control-label no-padding-right" for="form-field-1">会议主题：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox18" ClientIDMode="Static" runat="server" placeholder="请填写会议主题" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label34" class="col-sm-3 control-label no-padding-right" for="form-field-1">会议地点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox25" ClientIDMode="Static" runat="server" placeholder="请填写会议地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label30" class="col-sm-3 control-label no-padding-right" for="form-field-1">会议日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox22" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label31" class="col-sm-3 control-label no-padding-right" for="form-field-1">验收专家：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox23" ClientIDMode="Static" runat="server" placeholder="请填写验收专家姓名" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label33" class="col-sm-3 control-label no-padding-right" for="form-field-1">主办单位：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox24" ClientIDMode="Static" runat="server" placeholder="请输入主办单位" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label32" class="col-sm-3 control-label no-padding-right" for="form-field-1">人员情况：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox26" ClientIDMode="Static" runat="server" placeholder="请输入主持人、参加单位、人员" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label35" class="col-sm-3 control-label no-padding-right" for="form-field-1">主要内容：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox27" ClientIDMode="Static" runat="server" placeholder="请输入会议主要内容记录" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label36" class="col-sm-3 control-label no-padding-right" for="form-field-1">关键要点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox28" ClientIDMode="Static" runat="server" placeholder="请输入参会人员感想及关键要点说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_CJXX">
        <%--参加学习--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label37" class="col-sm-3 control-label no-padding-right" for="form-field-1">学习主题：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox29" ClientIDMode="Static" runat="server" placeholder="请填写学习主题" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label38" class="col-sm-3 control-label no-padding-right" for="form-field-1">学习地点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox30" ClientIDMode="Static" runat="server" placeholder="请填写学习地点" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label39" class="col-sm-3 control-label no-padding-right" for="form-field-1">学习日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox31" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label40" class="col-sm-3 control-label no-padding-right" for="form-field-1">主办单位：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox32" ClientIDMode="Static" runat="server" placeholder="请填写主办单位" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label41" class="col-sm-3 control-label no-padding-right" for="form-field-1">主办单位：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox33" ClientIDMode="Static" runat="server" placeholder="请输入主办单位" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label42" class="col-sm-3 control-label no-padding-right" for="form-field-1">公司参加单位：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox34" ClientIDMode="Static" runat="server" placeholder="请输入公司参加单位" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label43" class="col-sm-3 control-label no-padding-right" for="form-field-1">主要内容：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox35" ClientIDMode="Static" runat="server" placeholder="请输入学习主要内容记录" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label44" class="col-sm-3 control-label no-padding-right" for="form-field-1">关键要点：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox36" ClientIDMode="Static" runat="server" placeholder="请输入参加人员感想及关键要点说明" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_TBQK">
        <%--投标情况--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label45" class="col-sm-3 control-label no-padding-right" for="form-field-1">项目名称：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox37" ClientIDMode="Static" runat="server" placeholder="请填写项目名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label46" class="col-sm-3 control-label no-padding-right" for="form-field-1">参与投标单位：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox38" ClientIDMode="Static" runat="server" placeholder="请填参与投标单位" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label47" class="col-sm-3 control-label no-padding-right" for="form-field-1">投标日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox39" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label48" class="col-sm-3 control-label no-padding-right" for="form-field-1">评标标准：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox40" ClientIDMode="Static" runat="server" placeholder="请填写评标标准" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label49" class="col-sm-3 control-label no-padding-right" for="form-field-1">参与单位报价：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox41" ClientIDMode="Static" runat="server" placeholder="请输参与单位报价" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label53" class="col-sm-3 control-label no-padding-right" for="form-field-1">投标结果：</label>
                <div class="col-sm-9">
                    <asp:CheckBoxList ID="CheckBoxList4" runat="server" RepeatColumns="3">
                        <asp:ListItem>&nbsp;中标&nbsp;</asp:ListItem>
                        <asp:ListItem>&nbsp;未中标&nbsp;</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label50" class="col-sm-3 control-label no-padding-right" for="form-field-1">未中标原因：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox42" ClientIDMode="Static" runat="server" placeholder="请输入未中标原因" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="page-content" runat="server" id="Div_Other">
        <%--其他--%>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label51" class="col-sm-3 control-label no-padding-right" for="form-field-1">会标标题：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox43" ClientIDMode="Static" runat="server" placeholder="请填写项目名称" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label54" class="col-sm-3 control-label no-padding-right" for="form-field-1">汇报日期：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox45" ClientIDMode="Static" runat="server" placeholder="请点击选择日期" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label55" class="col-sm-3 control-label no-padding-right" for="form-field-1">详细情况：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox46" ClientIDMode="Static" runat="server" placeholder="请填写详细情况" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="form-group">
                <label runat="server" id="Label56" class="col-sm-3 control-label no-padding-right" for="form-field-1">参与单位报价：</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextBox47" ClientIDMode="Static" runat="server" placeholder="请输参与单位报价" class="col-xs-12 col-sm-12"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>


    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label4" class="col-sm-3 control-label no-padding-right" for="form-field-1">现场照片：</label>
            <div class="col-sm-9">
                <p id="MyFile">
                    <input type="file" id="img-upload" capture="camera" accept="image/*" />
                    <asp:TextBox ID="TextBox44" ClientIDMode="Static" runat="server" placeholder="请填写详细情况" class="col-xs-12 col-sm-12"></asp:TextBox>
                </p>
                <br />
                <input onclick="addFile()" type="button" class="btn btn-success" value="+" /><br />
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label5" class="col-sm-3 control-label no-padding-right" for="form-field-1">审核阅读：</label>
            <div class="col-sm-9">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4">
                    <asp:ListItem>&nbsp;运管部经理&nbsp;</asp:ListItem>
                    <asp:ListItem>&nbsp;工程部经理&nbsp;</asp:ListItem>
                    <asp:ListItem>&nbsp;财务经理&nbsp;</asp:ListItem>
                    <asp:ListItem>&nbsp;总经理&nbsp;</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="form-group">
            <label runat="server" id="Label6" class="col-sm-3 control-label no-padding-right" for="form-field-1">审阅意见：</label>
            <div class="col-sm-9">
                <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server" Width="100%" TextMode="MultiLine" placeholder="请输入您的审阅意见" class="col-xs-12 col-sm-12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="hr-10"></div>
    <div class="btn-group">
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Next" class="btn btn-success" runat="server" OnClick="LinkButton_Next_Click"><i class="icon-ok bigger-110"></i> 提  交</asp:LinkButton>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Return" class="btn btn-pink" runat="server"><i class="icon-undo bigger-110"></i> 退  回</asp:LinkButton>
        <asp:LinkButton UseSubmitBehavior="false" OnClientClick="this.setAttribute('disabled', 'disabled')" ID="LinkButton_Del" class="btn btn-danger" runat="server"> <i class=" icon-trash bigger-110"></i> 删  除</asp:LinkButton>
    </div>
  <%--  <div class="col-xs-12">
        <!-- 时间轴循环开始 //-->
        <div class="timeline-container">
            <!-- 日期循环开始 //-->
            <div class="timeline-label">
                <span class="label label-primary arrowed-in-right label-lg">
                    <b>2021-01-13</b>
                </span>
            </div>
            <div class="timeline-items">
                <div class="timeline-item clearfix">
                    <div class="timeline-info">
                        <span class="label label-info label-sm">16:22</span>
                    </div>

                    <div class="widget-box transparent">
                        <div class="widget-header widget-header-small">
                            <h5 class="smaller">
                                <a href="#" class="blue">陆总</a>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                                    非常不好，重来
                            </div>
                        </div>
                    </div>
                </div>
                <div class="timeline-item clearfix">
                    <div class="timeline-info">
                        <span class="label label-info label-sm">18:22</span>
                    </div>

                    <div class="widget-box transparent">
                        <div class="widget-header widget-header-small">
                            <h5 class="smaller">
                                <a href="#" class="blue">鹏总</a>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                非常好。
                            </div>
                        </div>
                    </div>
                </div>
                <div class="timeline-item clearfix">
                    <div class="timeline-info">
                        <span class="label label-info label-sm">18:22</span>
                    </div>

                    <div class="widget-box transparent">
                        <div class="widget-header widget-header-small">
                            <h5 class="smaller">
                                <a href="#" class="blue">鹏总</a>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                非常好。
                            </div>
                        </div>
                    </div>
                </div>
                <div class="timeline-item clearfix">
                    <div class="timeline-info">
                        <span class="label label-info label-sm">18:22</span>
                    </div>

                    <div class="widget-box transparent">
                        <div class="widget-header widget-header-small">
                            <h5 class="smaller">
                                <a href="#" class="blue">鹏总</a>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                非常好。
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- 日期循环结束 //-->
            <!-- 日期循环开始 //-->
            <div class="timeline-label">
                <span class="label label-primary arrowed-in-right label-lg">
                    <b>2021-01-13</b>
                </span>
            </div>
            <div class="timeline-items">
                <div class="timeline-item clearfix">
                    <div class="timeline-info">
                        <span class="label label-info label-sm">16:22</span>
                    </div>

                    <div class="widget-box transparent">
                        <div class="widget-header widget-header-small">
                            <h5 class="smaller">
                                <a href="#" class="blue">陆总</a>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                非常不好，重来
                            </div>
                        </div>
                    </div>
                </div>
                <div class="timeline-item clearfix">
                    <div class="timeline-info">
                        <span class="label label-info label-sm">18:22</span>
                    </div>

                    <div class="widget-box transparent">
                        <div class="widget-header widget-header-small">
                            <h5 class="smaller">
                                <a href="#" class="blue">鹏总</a>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                非常好。
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- 日期循环结束 //-->
        </div>
        <!-- 时间轴循环结束 //-->

    </div>--%>

    <script type="text/javascript" src="/assets/timepicker/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-slide.min.js"></script>
    <script type="text/javascript" src="/assets/timepicker/js/jquery-ui-timepicker-addon.js"></script>

    <script type="text/javascript">
        $(function () { $('#TextBox_KCRQ').datepicker(); });
    </script>
</asp:Content>

