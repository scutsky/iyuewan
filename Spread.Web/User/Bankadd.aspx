<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bankadd.aspx.cs" Inherits="Spread.Web.User.Bankadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" media="screen" href="../style/main.css">
<link rel="stylesheet" type="text/css" href="../style/addBankCard.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 内容区 -->

<input id="swf-path" type="hidden" value="/public/javascripts/lib/uploadify/uploadify.swf">
<input id="redirect-url" type="hidden" value="/bank">
<div class="contain add-bank-card">
  <p class="crumbs"> <a href="http://9aapp.com/bal">结算管理</a> <a href="http://9aapp.com/bank" class="notactive">&nbsp;&gt;&nbsp; 银行列表</a> <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 新增银行账号</a> </p>
  <div class="box">
    <div class="box-header">
      <h1>新增银行账号</h1>
    </div>
    <div id="form"  class="ym-form" novalidate>
      <input type="hidden" name="bank.accountType" value="1">
      <div class="form-group">
        <label class="form-label"><span class="required" >*</span>支付宝账号：</label>
        <div class="form-control">
          <input id="cardnumber" runat="server" type="text" name="bank.bankAccount" value="" >
        </div>
      </div>
      <div class="form-group">
        <label class="form-label"><span class="required" >*</span>收款人：</label>
        <div class="form-control">
          <input id="holderName" runat="server" type="text" name="bank.holderName" value="" >
        </div>
      </div>
      <div class="action">
          <asp:Button ID="submitbtn" runat="server" Text="提交" class="btn-1 submit-btn" 
              onclick="submitbtn_Click" />
      </div>
    </div>
  </div>
</div>
<script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    

    function alertMsg(msg, v_icon) {
        //$.dialog.alert(msg);
        $.dialog({
            title: '提示',
            lock: true,
            icon: v_icon,
            cancel: true,
            width: 200,
            height: 80,
            max: false,
            min: false,
            content: msg
        });
    }
    function alertRedirectMsg(msg, v_icon, url) {
        $.dialog({
            title: '提示',
            lock: true,
            icon: v_icon,
            width: 200,
            height: 80,
            max: false,
            min: false,
            content: msg,
            cancelVal: '关闭',
            cancel: function () {
                window.location.href = url;
            }
        });
    }
</script>
</asp:Content>
