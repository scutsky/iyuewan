<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeContactInfo2.aspx.cs" Inherits="Spread.Web.User.ChangeContactInfo2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen" href="../style/main.css">
<link rel="stylesheet" type="text/css" href="../style/setting.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="contain account-setting change-contact">
  <p class="crumbs"> <a href="../Index.aspx">首页</a> <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 账号设置</a> </p>
  <div class="box">
    <div class="tab">
      <ul class="cf">
        <li> <a href="Channelinfo.aspx">账号信息</a> </li>
        <li> <a href="ChangePassword.aspx">修改密码</a> </li>
        <li class="cur"> <a href="ChangeContactInfo.aspx">修改联系方式</a> </li>
        <li > <a href="Changealipayinfo.aspx">修改银行账号</a> </li>
        <li> <a href="UserInfo.aspx">业务员联系方式</a> </li>
      </ul>
    </div>
    <div id="main-form" class="ym-form contact-form" novalidate>
      <div class="form-group disable" >
        <table cellpadding="0" cellspacing="0" border="0"><tr>
            <td> <label class="form-label">手机号码：</label></td>
            <td style=" width:250px;"><div class="form-control"><%=model.Phone%></div></td>
            <td><a id="edit-phone-btn" href="ChangeContactInfo1.aspx" class="btn-2 edit-btn fr">修改</a></td>
        </tr>
        </table>
        </div>
      <div class="form-group disable" >
      <table cellpadding="0" cellspacing="0" border="0"><tr>
        <td> <label class="form-label">邮箱地址：</label></td>
        <td style=" width:250px;"><div class="form-control"><%=model.Email%></div></td>
        <td><a id="edit-email-btn" href="ChangeContactInfo2.aspx" class="btn-2 edit-btn fr">修改</a> </td>
        </tr>
        </table>
        </div>
      <div class="box-header m-t-20">
        <h1>修改其他联系信息</h1>
      </div>
      <input id="type" name="channelInfo.type" type="hidden" value="1">
      <div class="form-group">
        <label class="form-label"> <span class="required">*</span>QQ：</label>
        <div class="form-control">
          <input id="qqnumber" type="text" runat="server" name="channelInfo.qq" value="" >
        </div>
      </div>
      <div class="action">
          <asp:Button ID="mainbtn" runat="server" Text="保存" class="btn-1 submit-btn" 
              onclick="mainbtn_Click"/>
      </div>
    </div>
  </div>
</div>

<div id="edit-email-win" class="win-wrap setting-win" style="display: block;">
  <div class="mask"></div>
  <div class="win-inner">
    <div class="win-title cf">
      <h1>修改邮箱地址</h1>
      <div class="close-btn"> <i class="iconfont icon-close"><a href="ChangeContactInfo.aspx"><img src="../Images/erro.png" /></a></i> </div>
    </div>
    <div class="win-content">
      <div id="edit-email-form" class="ym-form" novalidate>
        <div class="phone"> <i class="iconfont icon-iphone"></i><asp:Label ID="lbPhone" runat="server"></asp:Label>
          <input id="telphone2" type="hidden" runat="server" value="">
        </div>
        <div class="form-group">
          <label class="form-label"> <span class="required" >*</span>短信验证码：</label>
          <div class="form-control">
            <input type="text" id="smsCode" runat="server"  name="channel.smsCode" value="" >
          </div>
          <a id="get-verify-btn3" href="javascript:" class="btn-2 get-verify-btn" onclick="SendVerify();">点击获取短信验证码</a> </div>
        <div class="form-group">
          <label class="form-label"> <span class="required" >*</span>新邮箱地址：</label>
          <div class="form-control">
            <input type="text" id="newEmail" runat="server" name="channel.newEmail" value="" >
          </div>
        </div>
        <div class="action">
            <asp:Button ID="emailsubmitbtn" runat="server" Text="确定" 
                class="btn-1 submit-btn" onclick="emailsubmitbtn_Click" />
        </div>
      </div>
    </div>
  </div>
</div>
<asp:HiddenField ID="hcode" runat="server" />
    <asp:HiddenField ID="hcode2" runat="server" />
    <script src="../javascript/jquery.js" type="text/javascript"></script>
<script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function SendVerify() {
        var phone = $("#<%=telphone2.ClientID%>").val();
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
                $("#<%=telphone2.ClientID%>").attr("readonly", "readonly");
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
