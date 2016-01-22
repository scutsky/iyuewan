<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="step1Page.aspx.cs" Inherits="Spread.Web.step1Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="style/main.css"/>
 <link href="style/forgetPwd.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="contain">
    <p class="crumbs">
        <a href="Index.aspx" >首页</a>
        <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 忘记密码 </a>
    </p>
    <!--下面的注释是消除inline-block产生的间隙-->
    <div id="form" class="ym-form box showMsg step1">
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
        <div class="steps yourId">
            <div class="form-group">
                <label class="form-label">输入您的账号：</label>
                <div class="form-control">
                    <input id="username" type="text" name="username" value="" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label class="form-label">输入验证码：</label>
                <div class="form-control verify-code">
                    <input id="verifycode" type="text" name="captcha" value="" runat="server" />
                </div>
                 <img id="verifyimg" style="cursor: pointer" alt="看不清，点击换一张" onclick="ChangeVerifyImg()" class="verify-code-img"
                            align="absmiddle" />
            </div>
            <asp:Button ID="submitbtn" runat="server" Text="下一步"  class="btn-1 next"  
                OnClick="submitbtn_Click"/>
            <a href="Index.aspx"  class="backLogin">返回登录</a>
        </div>
    </div>
</div>
<script src="javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript"> 
    function ChangeVerifyImg() {
        if (document.getElementById("verifyimg") != null) {
            document.getElementById("verifyimg").src = 'verifyimg.aspx?d=' + Date();
        }
    }
    //初始化
    ChangeVerifyImg();
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
