<%@ Page Title="" Language="C#" MasterPageFile="~/XMFight/MasterPage.master" AutoEventWireup="true" CodeFile="Class.aspx.cs" Inherits="XMFight_Manage_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="btn-group">
            <%--            <a href='/XMFight/Manage/AddPhoto.aspx' class="btn btn-danger btn-sm">添加学员风采</a>--%>
            <a href='/XMFight/Manage/AddStudent.aspx' class="btn btn-sm">添加学生</a>
            <a href='/XMFight/Manage/AddClass.aspx' class="btn btn-sm">添加课程</a>
            <a href='/XMFight/Manage/Students.aspx' class="btn btn-sm">学生操作</a>
        </div>
    </div>
    <div runat="server" id="Div_StudentsList"></div>
    <%--  <div class="row">
        <h5>&nbsp;2021-11-09 星期二 10:00 - 11:30</h5>
        <div class="widget-main no-padding">
            <div class="dialogs">
                <div class="itemdiv dialogdiv">
                    <div class="user">
                        <img src="/images/XMFightLogo.jpg" />
                    </div>
                    <div class="body">
                        <div class="time"><i class="icon-time"></i><span class="green">2014-07-25</span>     </div>
                        <div class="name"><a href="tel:18019961118">陆博文 <span class="label label-info arrowed-in arrowed-in-right">7 岁 </span></a></div>
                        <div class="text">
                            <h5>上节课时间：2021-11-09 </h5>
                            <h5>剩余课时：967.00 节</h5>
                            <h5>请假：4 节</h5>
                            <h5>旷课：<span class="label label-danger">5</span> 节</h5>
                            <h5 class='pink'>储备金：10 元</h5>
                        </div>
                        <div class="tools"><a href="Operation.aspx?SID=16&CID=1" class="btn btn-minier btn-success">上课           </a><a href="Operation.aspx?SID=16&CID=2" class="btn btn-minier btn-info">请假          </a><a href="Operation.aspx?SID=16&CID=3" class="btn btn-minier btn-danger">旷课          </a><a href="Operation.aspx?SID=16&CID=0" class="btn btn-minier btn-pink">储备金          </a></div>
                    </div>
                </div>
                <div class="itemdiv dialogdiv">
                    <div class="user">
                        <img src="/images/XMFightLogo.jpg" />
                    </div>
                    <div class="body">
                        <div class="time"><i class="icon-time"></i><span class="green">2011-01-03</span>     </div>
                        <div class="name"><a href="tel:18019961118">陆博语 <span class="label label-danger arrowed-in arrowed-in-right">10 岁 </span></a></div>
                        <div class="text">
                            <h5>上节课时间：2021-11-09 </h5>
                            <h5>剩余课时：998.00 节</h5>
                            <h5>请假：0 节</h5>
                            <h5>旷课：0 节</h5>
                            <h5 class='pink'>储备金：0 元</h5>
                        </div>
                        <div class="tools"><a href="Operation.aspx?SID=17&CID=1" class="btn btn-minier btn-success">上课           </a><a href="Operation.aspx?SID=17&CID=2" class="btn btn-minier btn-info">请假          </a><a href="Operation.aspx?SID=17&CID=3" class="btn btn-minier btn-danger">旷课          </a><a href="Operation.aspx?SID=17&CID=0" class="btn btn-minier btn-pink">储备金          </a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <div class="row">
        <h5>&nbsp;2021-11-10 星期三 10:00 - 11:30</h5>
        <div class="widget-main no-padding">
            <div class="dialogs">
                <div class="itemdiv dialogdiv">
                    <div class="user">
                        <img src="/images/XMFightLogo.jpg" />
                    </div>
                    <div class="body">
                        <div class="time"><i class="icon-time"></i><span class="green">2014-07-25</span>     </div>
                        <div class="name"><a href="tel:18019961118">陆博文 <span class="label label-info arrowed-in arrowed-in-right">7 岁 </span></a></div>
                        <div class="text">
                            <h5>上节课时间：2021-11-09 </h5>
                            <h5>剩余课时：967.00 节</h5>
                            <h5>请假：4 节</h5>
                            <h5>旷课：<span class="label label-danger">5</span> 节</h5>
                            <h5 class='pink'>储备金：10 元</h5>
                        </div>
                        <div class="tools"><a href="Operation.aspx?SID=16&CID=1" class="btn btn-minier btn-success">上课           </a><a href="Operation.aspx?SID=16&CID=2" class="btn btn-minier btn-info">请假          </a><a href="Operation.aspx?SID=16&CID=3" class="btn btn-minier btn-danger">旷课          </a><a href="Operation.aspx?SID=16&CID=0" class="btn btn-minier btn-pink">储备金          </a></div>
                    </div>
                </div>
                <div class="itemdiv dialogdiv">
                    <div class="user">
                        <img src="/images/XMFightLogo.jpg" />
                    </div>
                    <div class="body">
                        <div class="time"><i class="icon-time"></i><span class="green">2011-01-03</span>     </div>
                        <div class="name"><a href="tel:18019961118">陆博语 <span class="label label-danger arrowed-in arrowed-in-right">10 岁 </span></a></div>
                        <div class="text">
                            <h5>上节课时间：2021-11-09 </h5>
                            <h5>剩余课时：998.00 节</h5>
                            <h5>请假：0 节</h5>
                            <h5>旷课：0 节</h5>
                            <h5 class='pink'>储备金：0 元</h5>
                        </div>
                        <div class="tools"><a href="Operation.aspx?SID=17&CID=1" class="btn btn-minier btn-success">上课           </a><a href="Operation.aspx?SID=17&CID=2" class="btn btn-minier btn-info">请假          </a><a href="Operation.aspx?SID=17&CID=3" class="btn btn-minier btn-danger">旷课          </a><a href="Operation.aspx?SID=17&CID=0" class="btn btn-minier btn-pink">储备金          </a></div>
                    </div>
                </div>
            </div>
        </div>
    </div> --%>
</asp:Content>

