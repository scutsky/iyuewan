<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="step2Page.aspx.cs" Inherits="Spread.Web.step2Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="style/main.css"/>
<link href="style/forgetPwd.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->
    


<div class="contain">
    <p class="crumbs">
        <a href="Index.aspx" >首页</a>
        <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 忘记密码</a>
    </p>
    <!--下面的注释是消除inline-block产生的间隙-->
    <div id="form" class="ym-form box showMsg step2">
        <div class="progress">
            <span class="area1">填写账号</span>
            <div class="line1">
                <i></i>
            </div>
            <span class="area2">手机验证</span>
            <div class="line2">
                <i></i>
            </div>
            <span class="area3">修改密码</span>
        </div>
        <div class="steps sendMsg">
            <div class="form-group">
                <label class="form-label">输入手机号码：</label>
                <div class="form-control phone-num">
                    <input id="telphone" type="text" name="phoneNumber" value="" runat="server"  />
                    <asp:HiddenField ID="hdPhone" runat="server" />
                </div>
                
                <a id="get-verify-btn" href="javascript:" onclick="SendVerify();" class="btn-2 get-verify-btn">点击获取短信验证码</a>
            </div>
            <div class="form-group">
                <label class="form-label">短信验证码：</label>
                <div class="form-control">
                    <input id="verifycode" type="text" name="checkCode" value="" runat="server"  />
                </div>
            </div>
            <input type="hidden" name="token" value="" />
            <asp:Button ID="submitbtn" runat="server" Text="下一步"  class="btn-1 next" 
                onclick="submitbtn_Click" />
            <a href="Index.aspx"  class="backLogin">返回登录</a>
        </div>
    </div>
</div>
<script src="javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">


function SendVerify() {
    var phone = $("#<%=telphone.ClientID%>").val();
    var hdphone = $("#<%=hdPhone.ClientID%>").val();
    if ($.trim(phone) == "") {
        alertMsg('手机号码不能为空', 'error.gif');
//        $("#ctl00_main_telphoneTip").html("手机号码不能为空");
//        $("#ctl00_main_telphoneTip").attr("class", "error");
        return false;
    }
    if ($.trim(phone) != $.trim(hdphone)) {
        alertMsg('手机号码不相同', 'error.gif');
        return false;
    }
    $("#get-verify-btn").html("发送中，请稍等");
    $.get("SendPhoneVerify.ashx?phone=" + phone, function (date) {
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
