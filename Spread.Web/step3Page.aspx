<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="step3Page.aspx.cs" Inherits="Spread.Web.step3Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/validator.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="style/main.css"/>
    <link href="style/forgetPwd.css" rel="stylesheet" type="text/css" />
    <script src="javascript/formValidator-4.0.1.js" type="text/javascript"></script>
    <script src="javascript/formValidatorRegex.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="contain">
    <p class="crumbs">
        <a href="Index.aspx" >首页</a>
        <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 忘记密码</a>
    </p>
    <!--下面的注释是消除inline-block产生的间隙-->
    <div id="form"  class="ym-form box showMsg step3">
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
        <div class="steps changePassword">
            <div class="form-group">
                <label class="form-label">新密码：</label>
                <div class="form-control">
                    <input id="password" type="password" name="password" value="" runat="server" />
                </div>
                    <span class="notice">
                        <span id="ctl00_main_passwordTip"></span>
                    </span>
            </div>
            <div class="form-group">
                <label class="form-label">确认密码：</label>
                <div class="form-control">
                    <input id="confirmpassword" type="password" name="confirmPwd" value="" runat="server" />
                </div>
                 <span class="notice">
                        <span id="ctl00_main_confirmpasswordTip"></span>
                    </span>
            </div>
            <input type="hidden" name="token" value=""/>
            <asp:Button ID="submitbtn" runat="server" Text="下一步" class="btn-1 next" 
                onclick="submitbtn_Click" />
        </div>
    </div>
</div>
<script src="javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
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
        $("#ctl00_main_password").formValidator({ onShow: "请输入6位到20位的字符", onFocus: "请输入6位到20位的字符", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号" }, onError: "请输入6位到20位的字符,请确认" });
        $("#ctl00_main_confirmpassword").formValidator({ onShow: "请再次输入6位到20位的字符", onFocus: "请再次输入6位到20位的字符", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "重复密码两边不能有空符号" }, onError: "重复密码不能为空,请确认" }).compareValidator({ desID: "ctl00_main_password", operateor: "=", onError: "2次密码不一致,请确认" });

 });




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

