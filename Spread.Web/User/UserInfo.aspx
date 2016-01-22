<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Spread.Web.User.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen" href="../style/main.css" />
<link rel="stylesheet" type="text/css" href="../style/setting.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->

<div class="contain account-setting account-info">
  <p class="crumbs"> <a href="../Index.aspx">首页</a> <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 账号设置</a> </p>
  <div class="box">
    <div class="tab">
      <ul class="cf">
        <li> <a href="Channelinfo.aspx">账号信息</a> </li>
        <li> <a href="ChangePassword.aspx">修改密码</a> </li>
        <li> <a href="ChangeContactInfo.aspx">修改联系方式</a> </li>
        <li> <a href="Changealipayinfo.aspx">修改银行账号</a> </li>
        <li class="cur"> <a href="UserInfo.aspx">业务员联系方式</a> </li>
      </ul>
    </div>
    <label> <span>联系人：</span><asp:Label ID="lbCorporateName" runat="server" Text="" style=" text-align:left;"></asp:Label></label>
    <label> <span>手机：</span><asp:Label ID="lbPhone" runat="server" Text="" style=" text-align:left;"></asp:Label></label>
    <label> <span>QQ：</span><asp:Label ID="lbQQ" runat="server" Text="" style=" text-align:left;"></asp:Label></label>
  </div>
</div>
</asp:Content>
