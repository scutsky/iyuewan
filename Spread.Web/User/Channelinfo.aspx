<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Channelinfo.aspx.cs" Inherits="Spread.Web.User.Channelinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/main.css" rel="stylesheet" type="text/css" />
    <link href="../style/setting.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="contain account-setting account-info">
  <p class="crumbs"> <a href="/Index.aspx">首页</a> <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 账号设置</a> </p>
  <div class="box">
    <div class="tab">
      <ul class="cf">
        <li class="cur"> <a href="Channelinfo.aspx">账号信息</a> </li>
        <li> <a href="ChangePassword.aspx">修改密码</a> </li>
        <li> <a href="ChangeContactInfo.aspx">修改联系方式</a> </li>
        <li> <a href="Changealipayinfo.aspx">修改银行账号</a> </li>
        <li> <a href="UserInfo.aspx">业务员联系方式</a> </li>
      </ul>
    </div>
    <h1 class="title"><%=model.Name%></h1>
    <label> <span>账号属性：</span><%=model.UserType == 1 ? "企业" : "个人"%></label>
    <label> <span>手机：</span><%=model.Phone%></label>
    <label> <span>邮箱地址：</span><%=model.Email%></label>
    <label> <span>QQ：</span><%=model.QQ%></label>
  </div>
</div>
</asp:Content>
