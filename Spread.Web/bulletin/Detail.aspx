<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Spread.Web.bulletin.Detail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 内容区 -->
    
<div class="contain bulletin-content">
	<p class="crumbs">
		<a href="Default.aspx" >公告中心</a>
		<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp;公告详情</a>
	</p>
	<div class="box">
				<h1 class="title"><%=modArticle.Title%></h1>
        
		<div class="sub">
			<a href="Default.aspx?page=1&type=<%=modArticle.ClassId%>"><asp:Label ID="lbmenu" runat="server" ></asp:Label></a>
			<span class="line">|</span>
			<span class="time">
				<i class="iconfont icon-clock"></i>
				<span><%=modArticle.AddTime%></span>
			</span>
		</div>
		<div class="content">
			<p>
            <%=modArticle.Content%>
            </p>
		</div>
			</div>
</div>
    <script src="../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $(".content ul li").removeClass("on");
        $("#nav_bulletin").addClass("on");
    });
     </script>
</asp:Content>
