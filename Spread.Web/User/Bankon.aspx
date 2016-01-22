<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bankon.aspx.cs" Inherits="Spread.Web.User.Bankon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" media="screen" href="../style/main.css">
    
<link rel="stylesheet" type="text/css" href="../style/bankCardList.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 内容区 -->
    


<div class="contain bank-card-list">
		<p class="crumbs">
			<a href="../Index.aspx">首页</a>
			<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp;银行信息</a>
		</p>
	<div class="box">
        <asp:Panel ID="Panel1" runat="server">
		<a class="btn-2 add-card" href="Bankadd.aspx">
			<i class="iconfont icon-add"></i>新增银行帐号
		</a>
		</asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
        <div class="list">
			<div class="item">
				<h1>支付账号信息:</h1>
				<label>
					<span>支付宝帐号：</span><asp:Label ID="lbPayAccount" runat="server" Text=""></asp:Label></label>
				<label>
					<span>收款人：</span><asp:Label ID="lbTrueName" runat="server" Text=""></asp:Label></label>
				<label>
					<span>生效状态：</span>即时</label>
			</div>
		</div>
        </asp:Panel>
	</div>
</div>
<script src="../js/jquery.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $(".content ul li").removeClass("on");
         $("#nav_individualba").addClass("on");
     });
     </script>
</asp:Content>
