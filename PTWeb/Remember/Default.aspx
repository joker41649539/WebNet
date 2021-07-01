<%@ Page Title="" Language="C#" MasterPageFile="~/Remember/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Remember_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     复习点的确定<br>
    1． 第一个记忆周期：5分钟<br>
    2． 第二个记忆周期：30分钟<br>
    3． 第三个记忆周期：12小时<br>
    4． 第四个记忆周期：1天<br>
    5． 第五个记忆周期：2天<br>
    6． 第六个记忆周期：4天<br>
    7． 第七个记忆周期：7天<br>
    8． 第八个记忆周期：15天<br>
    背诵方法<br>
    1． 初记单词时需要记忆的内容：<br>
    a）单词外观，b） 单词的中文释义，c） 单词的记忆法<br>
    2． 每个list的具体背诵过程（每个list按12页，每页10个单词计）：<br>
    a) 背完一页（大约5分钟），立即返回该页第一个单词开始复习（大约几十秒）<br>
    b) 按上面方法背完1～6页（大约在30分钟），回到第1页开始复习（两三分钟）<br>
    c) 按上面同样方法背完7～12页，一个list结束<br>
    d) 相当于每个list被分为12个小的单元，每个小的单元自成一个复习系统；每6个小单元组成一个大单元，2个大单元各自成为一个复习系统。背一个list总共需要一小时左右的时间。<br>
    复习过程<br>
    a) 复习方法：遮住中文释义，尽力回忆该单词的意思，几遍下来都记不住的单词可以做记号重点记忆。<br>
    b) 复习一个list所需的时间为20分钟以内<br>
    c) 当天的list最好在中午之前背完，大约12小时之后（最好睡觉前）复习当天所背的list<br>
    d) 在其后的1，2，4，7，15天后分别复习当日所背的list<br>
    e）复习的原则<br>
    时间间隔：30秒 1分钟 5分钟 30分钟 1小时 8小时 1天 2天 6天 31天<br>
    重学节省诵读时间百分数：58.2 44.2 35.8 33.7 27.8 25.4 21.1<br>
</asp:Content>

