<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterSuccess.aspx.cs" Inherits="Spread.Web.RegisterSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="style/register.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="contain">
    <p class="crumbs">
        <a href="Index.aspx" >首页</a>
        <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 注册</a>
    </p>
    <!--下面的注释是消除inline-block产生的间隙-->
    <div class="box register-success">
        <div class="content-wrap">
            <i class="icon"></i>
            <h1>恭喜您，注册账号成功！</h1>
            <h2>只需以下几步，即可进行推广合作</h2>
            <div class="text">
                1.新增我的渠道
                <br> 2.选择进行合作的产品
                <br> 3.获取推广包
                <br>
            </div>
            <div class="text m-t-25">
				<span id="time">10</span> 秒后自动开始新增资源...
            	<a id="redirect-link" href="Index.aspx" >立即新增我的渠道</a>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    var seajs = { config: function () { }, use: function () { } };
    var url = document.getElementById('redirect-link').getAttribute('href');
    var time = document.getElementById('time');
    var totalTime = 10;

    setInterval(function () {
        time.innerHTML = (--totalTime);
        if (totalTime <= 0) {
            window.location.href = url;
        }
    }, 1000);
</script>
</asp:Content>
