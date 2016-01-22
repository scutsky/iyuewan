﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Changealipayinfo.aspx.cs" Inherits="Spread.Web.User.Changealipayinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen" href="../style/main.css" />
<link rel="stylesheet" type="text/css" href="../style/setting.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->

<div class="contain account-setting change-password">
  <p class="crumbs"> <a href="../Index.aspx">首页</a> <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 账号设置</a> </p>
  <div class="box">
    <div class="tab">
      <ul class="cf">
        <li> <a href="Channelinfo.aspx">账号信息</a> </li>
        <li> <a href="ChangePassword.aspx">修改密码</a> </li>
        <li> <a href="ChangeContactInfo.aspx">修改联系方式</a> </li>
        <li class="cur"> <a href="Changealipayinfo.aspx">修改银行账号</a> </li>
        <li> <a href="UserInfo.aspx">业务员联系方式</a> </li>
      </ul>
    </div>
    <div id="form"  class="ym-form"  novalidate>
      <div class="form-group disable">
        <label class="form-label">手机号码：</label>
        <div class="form-control phone-num"><asp:Label ID="lbPhone" runat="server"></asp:Label>
          <input id="telphone" type="hidden" value="" runat="server">
        </div>
        <div class="form-group">
          <label class="form-label"><span class="required" >*</span>短信验证码：</label>
          <div class="form-control">
            <input type="text" id="smsCode" runat="server" name="channel.smsCode" value=""  >
          </div>
          <a id="get-verify-btn" href="javascript:" class="btn-2 get-verify-btn" onclick="SendVerify();">点击获取短信验证码</a> </div>
        <div class="form-group">
          <label class="form-label"><span class="required" >*</span>支付宝账号：</label>
          <div class="form-control">
            <input id="cardnumber" runat="server" type="text" name="bank.bankAccount" value="" >
          </div>
        </div>
        <div class="form-group">
          <label class="form-label"><span class="required" >*</span>收款人：</label>
          <div class="form-control">
            <input id="bankname" runat="server" type="text" name="bank.holderName" value="" >
          </div>
        </div>
        <div class="action">
            <asp:Button ID="submitbtn" runat="server" Text="保存"  class="btn-1 submit-btn" 
                onclick="submitbtn_Click" />
        </div>
      </div>
       
    </div>
  </div>
    </div>
     <asp:HiddenField ID="hcode" runat="server" />
    <script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function SendVerify() {
        var phone = $("#<%=telphone.ClientID%>").val();
        if ($.trim(phone) == "") {
            alertMsg('手机号码不能为空', 'error.gif');
            //        $("#ctl00_main_telphoneTip").html("手机号码不能为空");
            //        $("#ctl00_main_telphoneTip").attr("class", "error");
            return false;
        }
        $("#get-verify-btn").html("发送中，请稍等");
        $.get("../SendPhoneVerify.ashx?phone=" + phone, function (date) {
            var arr = date.split("|");
            if (arr[0] == "TRUE") {
                $("#<%=hcode.ClientID%>").val(arr[1]);
                $("#get-verify-btn").html("发送成功，请查收！");
            }
            else {
                if (arr.length > 1) {
                    $("#get-verify-btn").html(arr[1]);
                } else {
                    $("#get-verify-btn").html("手机短信发送失败，请重新发送");
                }
            }
        });
    }

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
