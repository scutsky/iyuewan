<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Spread.Web.User.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../style/main.css" rel="stylesheet" type="text/css" />
    <link href="../style/setting.css" rel="stylesheet" type="text/css" />
    <link href="../style/validator.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 内容区 -->

<div class="contain account-setting change-password">
  <p class="crumbs"> <a href="/Index.aspx">首页</a> <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 账号设置</a> </p>
  <div class="box">
    <div class="tab">
      <ul class="cf">
        <li> <a href="Channelinfo.aspx">账号信息</a> </li>
        <li class="cur"> <a href="ChangePassword.aspx">修改密码</a> </li>
        <li > <a href="ChangeContactInfo.aspx">修改联系方式</a> </li>
        <li > <a href="Changealipayinfo.aspx">修改银行账号</a> </li>
        <li> <a href="UserInfo.aspx">业务员联系方式</a> </li>
      </ul>
    </div>
    <div id="form"  class="ym-form"  novalidate>
      <div class="form-group disable">
        <label class="form-label">手机号码：</label>
        <div class="form-control phone-num"> <span><%=model.Phone %></span>
          <input id="telphone"  runat="server" type="hidden" value="">
        </div>
      </div>
      <div class="form-group">
        <label class="form-label"><span class="required" >*</span>短信验证码：</label>
        <div class="form-control">
          <input type="text" id="smsCode" name="channel.smsCode" value=""  runat="server"/>
        </div>
        <span id="ctl00_main_smsCodeTip"></span>
        <div style=" padding-left:117px;" onclick="SendVerify();"><a id="get-verify-btn" href="javascript:" class="btn-2 get-verify-btn">点击获取短信验证码</a> </div>
        </div>
      <div class="form-group">
        <label class="form-label"><span class="required" >*</span>原始密码：</label>
        <div class="form-control">
          <input type="password" id="sourcePass"  name="channel.sourcePass" value="" runat="server"/>
        </div>
        <span id="ctl00_main_sourcePassTip"></span>
      </div>
      <div class="form-group">
        <label class="form-label"><span class="required" >*</span>新密码：</label>
        <div class="form-control">
          <input id="password" type="password" name="channel.newPass" value="" runat="server" />
        </div>
        <span id="ctl00_main_passwordTip"></span>
      </div>
      <div class="form-group">
        <label class="form-label"><span class="required" >*</span>确认密码：</label>
        <div class="form-control">
          <input type="password" id="confirmPass" name="channel.confirmPass" value=""  runat="server" />
        </div>
        <span id="ctl00_main_confirmPassTip"></span>
      </div>
      <div class="action">
          <asp:Button ID="submitbtn" runat="server" Text="保存" class="btn-1 submit-btn" 
              onclick="submitbtn_Click" />
      </div>
    </div>
  </div>
</div>
 <script src="../javascript/jquery.js" type="text/javascript"></script>
<script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
  <script src="../javascript/formValidator-4.0.1.js" type="text/javascript"></script>
    <script src="../javascript/formValidatorRegex.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(function () {
        

        $.formValidator.initConfig({
            submitButtonID: "ctl00_main_submitbtn", debug: true, onSuccess: function () {
                // alert("校验组1通过验证，不过我不给它提交");
                //setScale();
                submitbtn.Submit();

            }, onError: function () {
                alert("具体错误，请看网页上的提示")
            }
        });
        $("#ctl00_main_smsCode").formValidator({ onShow: "请输入6位验证码", onFocus: "请输入6位验证码", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 6, empty: { leftEmpty: false, rightEmpty: false, emptyError: "验证码两边不能有空符号" }, onError: "验证码输入有误!" });

        $("#ctl00_main_sourcePass").formValidator({ onShow: "请再次输入6位到20位的字符原密码", onFocus: "请再次输入6位到20位的字符原密码", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号" }, onError: "请再次输入6位到20位的字符原密码,请确认" });

        $("#ctl00_main_password").formValidator({ onShow: "请再次输入6位到20位的字符新密码", onFocus: "请再次输入6位到20位的字符新密码", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号" }, onError: "请再次输入6位到20位的字符新密码,请确认" });

        $("#ctl00_main_confirmPass").formValidator({ onShow: "请再次输入6位到20位的字符密码", onFocus: "请再次输入6位到20位的字符密码", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "重复密码两边不能有空符号" }, onError: "重复密码不能为空,请确认" }).compareValidator({ desID: "ctl00_main_password", operateor: "=", onError: "2次密码不一致,请确认" });

    });

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
                $("#hcode").val(arr[1]);
                $("#get-verify-btn").html("发送成功，请查收！");
                $("#<%=telphone.ClientID%>").attr("readonly", "readonly");
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
