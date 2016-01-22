<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Spread.Web.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="style/register.css" />
    <link href="style/validator.css" rel="stylesheet" type="text/css" />
    <script src="javascript/formValidator-4.0.1.js" type="text/javascript"></script>
    <script src="javascript/formValidatorRegex.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<div class="contain">
    <p class="crumbs">
        <a href="Index.aspx" >首页</a>
        <a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 注册</a>
    </p>
    <!--下面的注释是消除inline-block产生的间隙-->
    <div class="box register">
        <div id="form" >

            <div class="leftLineTitle">注册信息</div>

            <div class="resMsg">
                <div class="row">
                    <label>
                        <span class="required">*</span>登录账号：</label>
                    <div class="form-control">
                        <input id="username" type="text"  value="" class="input"  runat="server" />
                    </div>
                      <span class="notice">
                        <span id="ctl00_main_usernameTip"></span>
                      </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>密码：</label>
                    <div class="form-control">
                        <input type="password" id="password" value="" class="input" runat="server" />
                    </div>
                      <span class="notice">
                         <span id="ctl00_main_passwordTip">（请输入6位到20位的字符）</span>
                      </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>确定密码：</label>
                    <div class="form-control">
                        <input type="password" id="confirmPassword" value="" class="input" runat="server" />
                    </div>
                    <span class="notice">
                    <span id="ctl00_main_confirmPasswordTip">（请输入6位到20位的字符）</span>
                    </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>账号属性：</label>
                    <div class="form-control">
                        
                        <label class="text-left">
                            <input type="radio" id="usertype01"  name="usertype" value="1" runat="server" checked/>公司</label>
                        <label class="text-left">
                            <input type="radio" id="usertype02"  name="usertype" value="2" runat="server" />个人</label>
                    </div>
                </div>

            </div>

            <div class="leftLineTitle second">联系信息</div>

            <div class="connectMsg">
                <div id="fields1" class="fields active"  data-type="2">
                    <div class="row">
                        <label>
                            <span class="required">*</span>公司名称：</label>
                        <div class="form-control">
                            <input id="company" type="text"  value="" class="input" runat="server" />
                        </div>
                        <span class="notice">
                           <span id="ctl00_main_companyTip"></span>
                        </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>公司地址：</label>
                        <div class="form-control">
                            <input id="address" type="text"  value="" class="input" runat="server" />
                        </div>
                        <span class="notice">
                            <span id="ctl00_main_addressTip"></span>
                        </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>营业执照注册号：</label>
                        <div class="form-control">
                            <input id="license" type="text"  value="" class="input" runat="server" />
                        </div>
                         <span class="notice">
                           <span id="ctl00_main_licenseTip"></span>
                         </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>公司法人姓名：</label>
                        <div class="form-control">
                            <input id="legal" type="text" value="" class="input" runat="server" />
                        </div>
                        <span class="notice">
                            <span id="ctl00_main_legalTip"></span>
                        </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>法人身份证号：</label>
                        <div class="form-control">
                            <input id="legalidcard" type="text"  value="" class="input" runat="server" />
                        </div>
                        <span class="notice">
                            <span id="ctl00_main_legalidcardTip"></span>
                         </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>联系人：</label>
                        <div class="form-control">
                            <input id="contact" type="text" value="" class="input" runat="server" />
                        </div>
                         <span class="notice">
                            <span id="ctl00_main_contactTip"></span>
                        </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>联系人QQ：</label>
                        <div class="form-control">
                            <input id="contactqq" type="text" value="" class="input" runat="server" />
                        </div>
                         <span class="notice">
                            <span id="ctl00_main_contactqqTip"></span>
                        </span>
                    </div>
                </div>
                
                <!-- 个人信息 -->
                <div class="row">
                    <label><span class="required">*</span>邮箱地址：</label>
                    <div class="form-control">
                        <input type="text" id="email" value="" class="input" runat="server" />
                    </div>
                        <span class="notice">
                           <span id="ctl00_main_emailTip"></span>
                         </span>
                </div>

                <div class="row">
                    <label>
                        <span class="required">*</span>申请说明：</label>
                    <div class="form-control">
                        <textarea  id="remark" class="input textarea" cols="30" rows="8" runat="server" ></textarea>
                    </div>
                    <span class="notice">
                        <span id="ctl00_main_remarkTip"></span>
                        </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>手机：</label>
                    <div class="form-control">
                        <input id="telphone" type="text"  value="" class="input" runat="server"  />
                    </div>
                        <span class="notice">
                        <span id="ctl00_main_telphoneTip"></span>
                        </span>
                </div>
                <div class="row getCode">
                    <label>
                        <span class="required">*</span>短信验证码：</label>
                    <div class="form-control">
                        <input id="hcode" type="hidden" />
                        <input type="text"  id="checkCode" value="" class="input" runat="server"  />
                    </div>
                    <a id="get-verify-btn" href="javascript:void(0)" class="btn-2 get-verify-btn" onclick="SendVerify();">点击获取短信验证码</a>
                    <span class="notice">
                        <span id="ctl00_main_checkCodeTip"></span>
                        </span>
                </div>
                <div class="row">
                    <label>电话：</label>
                    <div class="form-control">
                        <input type="text" id="tel" value="" class="input" runat="server"  />
                    </div>
                     <span class="notice">
                        <span id="ctl00_main_telTip"></span>
                        </span>
                </div>
            </div>
            <asp:Button ID="submitbtn" runat="server" Text="提交" class="btn-1 submit" 
                onclick="submitbtn_Click"  />
        </div>

        <div id="form2" >

            <div class="leftLineTitle">注册信息</div>

            <div class="resMsg">
                <div class="row">
                    <label>
                        <span class="required">*</span>登录账号：</label>
                    <div class="form-control">
                        <input id="gusername" type="text"  value="" class="input"  runat="server" />
                    </div>
                    <span class="notice">
                    <span id="ctl00_main_gusernameTip"></span>
                    </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>密码：</label>
                    <div class="form-control">
                        <input type="password" id="gpassword" value="" class="input" runat="server" />
                    </div>
                    <span class="notice">
                    <span id="ctl00_main_gpasswordTip">（请输入6位到20位的字符）</span>
                    </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>确定密码：</label>
                    <div class="form-control">
                        <input type="password" id="gconfirmPassword" value="" class="input" runat="server" />
                    </div>
                    <span class="notice">
                    <span id="ctl00_main_gconfirmPasswordTip">（请输入6位到20位的字符）</span>
                    </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>账号属性：</label>
                    <div class="form-control">
                        
                        <label class="text-left">
                            <input type="radio" id="gusertype01"  name="gusertype" value="1" runat="server" checked/>公司</label>
                        <label class="text-left">
                            <input type="radio" id="gusertype02"  name="gusertype" value="2" runat="server" />个人</label>
                    </div>
                </div>

            </div>

            <div class="leftLineTitle second">联系信息</div>

            <div class="connectMsg">
               <!-- 公司信息 -->

                <div id="fields2" class="fields active" >
                    <div class="row">
                        <label>
                            <span class="required">*</span>真实姓名：</label>
                        <div class="form-control">
                            <input id="gcontactor" type="text" value="" class="input" runat="server" />
                        </div>
                         <span class="notice">
                            <span id="ctl00_main_gcontactorTip"></span>
                        </span>
                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>支付宝帐号：</label>
                        <div class="form-control">
                            <input id="gpaypalAccount" type="text"  value="" class="input" runat="server"  />
                        </div>
                        <span class="notice">
                         <span id="ctl00_main_gpaypalAccountTip"></span>
                        </span>
                    </div>
                  <%--  <div class="row">
                        <label>
                            <span class="required">*</span>身份证号：</label>
                        <div class="form-control">
                            <input id="gidcard" type="text"  value="" class="input" runat="server"  />
                        </div>
                        <span class="notice">
                         <span id="ctl00_main_gidcardTip"></span>
                        </span>
                    </div>--%>
                    <div class="row">
                        <label>
                            <span class="required">*</span>性别：</label>
                        <div class="form-control">
                            <label class="text-left">
                                <input type="radio" id="gsex01" value="1" runat="server" checked/>男</label>
                            <label class="text-left">
                                <input type="radio" id="gsex02"  value="2" runat="server" />女</label>
                        </div>

                    </div>
                    <div class="row">
                        <label>
                            <span class="required">*</span>QQ：</label>
                        <div class="form-control">
                            <input type="text" id="gqq"  value="" class="input" runat="server" />
                        </div>
                         <span class="notice">
                            <span id="ctl00_main_gqqTip"></span>
                         </span>
                    </div>
                </div>

                <!-- 个人信息 -->
                <%--<div class="row">
                    <label><span class="required">*</span>邮箱地址：</label>
                    <div class="form-control">
                        <input type="text" id="gemail" value="" class="input" runat="server" />
                    </div>
                    <span class="notice">
                       <span id="ctl00_main_gemailTip"></span>
                    </span>
                </div>--%>

                <div class="row">
                    <label>
                        <span class="required">*</span>申请说明：</label>
                    <div class="form-control">
                        <textarea  id="gremark" class="input textarea" cols="30" rows="8" runat="server" ></textarea>
                    </div>
                    <span class="notice">
                    <span id="ctl00_main_gremarkTip"></span>
                    </span>
                </div>
                <div class="row">
                    <label>
                        <span class="required">*</span>手机：</label>
                    <div class="form-control">
                        <input id="gtelphone" type="text"  value="" class="input" runat="server"  />
                    </div>
                    <span class="notice">
                    <span id="ctl00_main_gtelphoneTip"></span>
                    </span>
                </div>
                <div class="row getCode">
                    <label>
                        <span class="required">*</span>短信验证码：</label>
                    <div class="form-control">
                        <input id="ghcode" type="hidden" />
                        <input type="text"  id="gcheckCode" value="" class="input" runat="server"  />
                    </div>
                    <a id="get-verify-btn2" href="javascript:void(0)" class="btn-2 get-verify-btn" onclick="SendVerify2();">点击获取短信验证码</a>
                    <span class="notice">
                       <span id="ctl00_main_gcheckCodeTip"></span>
                    </span>
                </div>
               <%-- <div class="row">
                    <label>电话：</label>
                    <div class="form-control">
                        <input type="text" id="gtel" value="" class="input" runat="server"  />
                    </div>
                    <span class="notice">
                         <span id="ctl00_main_gtelTip"></span>
                    </span>
                </div>--%>
            </div>
                   <asp:Button ID="submitbtn2" runat="server" Text="提交" class="btn-1 submit" onclick="submitbtn2_Click" 
               />
            
        </div>
    </div>
</div>
<script src="javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
   $(function() {
    $("#form").css("display", "block");
    $("#form2").css("display", "none");
    $.formValidator.initConfig({
        submitButtonID: "ctl00_main_submitbtn", debug: true, onSuccess: function () {
            // alert("校验组1通过验证，不过我不给它提交");
            //setScale();
            //submitbtn.Submit();
            $("#ctl00_main_submitbtn").Submit();
        }, onError: function() {
            alert("具体错误，请看网页上的提示")
        }
    });
    $("#ctl00_main_username").formValidator({ onShow: "用作登录游戏推广平台，请输入英文或数字", onFocus: "用作登录游戏推广平台，请输入英文或数字", onCorrect: "&nbsp;" }).regexValidator({ regExp: "username", dataType: "enum", onError: "用作登录游戏推广平台，请输入英文或数字" });

    $("#ctl00_main_password").formValidator({ onShow: "请输入6位到20位的字符", onFocus: "请输入6位到20位的字符", onCorrect: "密码合法" }).inputValidator({ min: 6,max:20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号" }, onError: "请输入6位到20位的字符,请确认" });

    $("#ctl00_main_confirmPassword").formValidator({ onShow: "请再次输入6位到20位的字符", onFocus: "请再次输入6位到20位的字符", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "重复密码两边不能有空符号" }, onError: "重复密码不能为空,请确认" }).compareValidator({ desID: "ctl00_main_password", operateor: "=", onError: "2次密码不一致,请确认" });

    $("#ctl00_main_company").formValidator({ onShow: "公司名称不能为空", onFocus: "公司名称不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "公司名称填写错误" });

    $("#ctl00_main_address").formValidator({ onShow: "公司地址不能为空", onFocus: "公司地址不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "公司地址填写错误" });

    $("#ctl00_main_license").formValidator({ onShow: "注册号不能为空", onFocus: "注册号不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "username", dataType: "enum", onError: "注册号填写错误" });

    $("#ctl00_main_legal").formValidator({ onShow: "公司法人姓名不能为空", onFocus: "公司法人姓名不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "chinese", dataType: "enum", onError: "公司法人姓名填写错误" });

    $("#ctl00_main_legalidcard").formValidator({ onShow: "法人身份证号不能为空", onFocus: "法人身份证号不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "idcard", dataType: "enum", onError: "法人身份证号填写错误" });

    $("#ctl00_main_contact").formValidator({ onShow: "联系人不能为空", onFocus: "联系人不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "联系人填写错误" });

    $("#ctl00_main_contactqq").formValidator({ onShow: "联系人QQ不能为空", onFocus: "联系人QQ不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "intege", dataType: "enum", onError: "联系人QQ填写错误" });

    $("#ctl00_main_email").formValidator({ onShow: "邮箱地址用于接收通知", onFocus: "邮箱地址不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "email", dataType: "enum", onError: "邮箱地址填写错误" });

    $("#ctl00_main_remark").formValidator({ onShow: "申请说明不能为空", onFocus: "申请说明不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "申请说明填写错误" });

    $("#ctl00_main_telphone").formValidator({ onShow: "手机号码用于找回密码、接收通知短信", onFocus: "手机不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "mobile", dataType: "enum", onError: "手机填写错误" });

    $("#ctl00_main_checkCode").formValidator({ onShow: "短信验证码不能为空", onFocus: "短信验证码不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "intege", dataType: "enum", onError: "短信验证码填写错误" }).compareValidator({ desID: "hcode", operateor: "=", onError: "验证码不正确！" });

    $("#ctl00_main_tel").formValidator({ empty: true, onShow: "电话不能为空", onFocus: "电话不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "tel", dataType: "enum", onError: "电话填写错误" });


    $.formValidator.initConfig({ validatorGroup: "2", submitButtonID: "ctl00_main_submitbtn2", debug: true, onSuccess: function () {
            // alert("校验组1通过验证，不过我不给它提交");
        //setScale();
        $("#ctl00_main_submitbtn2").Submit();

        }, onError: function() {
            alert("具体错误，请看网页上的提示")
        }
    });
    $("#ctl00_main_gusername").formValidator({ validatorGroup: "2", onShow: "用作登录游戏推广平台，请输入英文或数字", onFocus: "用作登录游戏推广平台，请输入英文或数字", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "用作登录游戏推广平台，请输入英文或数字" });

    $("#ctl00_main_gpassword").formValidator({ validatorGroup: "2", onShow: "请输入6位到20位的字符", onFocus: "请输入6位到20位的字符", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号" }, onError: "请输入6位到20位的字符,请确认" });

    $("#ctl00_main_gconfirmPassword").formValidator({ validatorGroup: "2", onShow: "请再次输入6位到20位的字符", onFocus: "请再次输入6位到20位的字符", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 20, empty: { leftEmpty: false, rightEmpty: false, emptyError: "重复密码两边不能有空符号" }, onError: "重复密码不能为空,请确认" }).compareValidator({ desID: "ctl00_main_gpassword", operateor: "=", onError: "2次密码不一致,请确认" });

    $("#ctl00_main_gcontactor").formValidator({ validatorGroup: "2", onShow: "真实姓名不能为空", onFocus: "真实姓名不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "真实姓名填写错误" });

    $("#ctl00_main_gpaypalAccount").formValidator({ validatorGroup: "2", onShow: "支付宝帐号不能为空", onFocus: "支付宝帐号不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "支付宝帐号填写错误" });

//    $("#ctl00_main_gidcard").formValidator({ validatorGroup: "2", onShow: "身份证号不能为空", onFocus: "身份证号不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "idcard", dataType: "enum", onError: "身份证号填写错误" });

    $("#ctl00_main_gqq").formValidator({ validatorGroup: "2", onShow: "QQ不能为空", onFocus: "QQ不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "intege", dataType: "enum", onError: "QQ填写错误" });


//    $("#ctl00_main_gemail").formValidator({ validatorGroup: "2", onShow: "邮箱地址用于接收通知", onFocus: "邮箱地址不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "email", dataType: "enum", onError: "邮箱地址填写错误" });

    $("#ctl00_main_gremark").formValidator({ validatorGroup: "2", onShow: "申请说明不能为空", onFocus: "申请说明不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "notempty", dataType: "enum", onError: "申请说明填写错误" });

    $("#ctl00_main_gtelphone").formValidator({ validatorGroup: "2", onShow: "手机号码用于找回密码、接收通知短信", onFocus: "手机不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "mobile", dataType: "enum", onError: "手机填写错误" });

    $("#ctl00_main_gcheckCode").formValidator({ validatorGroup: "2", onShow: "短信验证码不能为空", onFocus: "短信验证码不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "intege", dataType: "enum", onError: "短信验证码不能为空" }).compareValidator({ desID: "ghcode", operateor: "=", onError: "验证码不正确！" });

//    $("#ctl00_main_gtel").formValidator({ empty: true, validatorGroup: "2", onShow: "电话不能为空", onFocus: "电话不能为空", onCorrect: "&nbsp;" }).regexValidator({ regExp: "tel", dataType: "enum", onError: "电话不能为空" });
});



function SendVerify() {
    var phone = $("#<%=telphone.ClientID%>").val();
    if ($.trim(phone) == "") {
        alertMsg('手机号码不能为空', 'error.gif');
        //        $("#ctl00_main_telphoneTip").html("手机号码不能为空");
        //        $("#ctl00_main_telphoneTip").attr("class", "error");
        return false;
    }
    $("#get-verify-btn").html("发送中，请稍等1");
    $.get("SendPhoneVerify.ashx?phone=" + phone, function (date) {
        var arr = date.split("|");
        if (arr[0] == "TRUE") {
            $("#hcode").val(arr[1]);
            $("#get-verify-btn").html("发送成功，请查收！");
        }
        else {
            if (arr.length > 1) {
                $("#get-verify-btn").html(arr[1]);
            } else {
                $("#get-verify-btn").html("发送失败,请重新发送");
            }
        }
    });
}

function SendVerify2() {
    var phone = $("#<%=gtelphone.ClientID%>").val();
    if ($.trim(phone) == "") {
        alertMsg('手机号码不能为空', 'error.gif');
        //        $("#ctl00_main_telphoneTip").html("手机号码不能为空");
        //        $("#ctl00_main_telphoneTip").attr("class", "error");
        return false;
    }
    $("#get-verify-btn2").html("发送中，请稍等1");
    $.get("SendPhoneVerify.ashx?phone=" + phone, function (date) {
        var arr = date.split("|");
        if (arr[0] == "TRUE") {
            $("#ghcode").val(arr[1]);
            $("#get-verify-btn2").html("发送成功，请查收！");
        }
        else {
            if (arr.length > 1) {
                $("#get-verify-btn2").html(arr[1]);
            } else {
                $("#get-verify-btn2").html("发送失败,请重新发送");
            }
        }
    });
}


$('#ctl00_main_usertype01').change(function () {
    var oInput = document.getElementById("ctl00_main_usertype01");
    if (oInput.checked) {
        $("#form").css("display", "block");
        $("#form2").css("display", "none");
        document.getElementById("ctl00_main_gusertype01").checked = true;
        document.getElementById("ctl00_main_gusertype02").checked = false;

    }
});
$('#ctl00_main_usertype02').change(function () {
    var oInput = document.getElementById("ctl00_main_usertype02");
    if (oInput.checked) {       
        $("#form").css("display", "none");
        $("#form2").css("display", "block");
        document.getElementById("ctl00_main_gusertype02").checked = true;
        document.getElementById("ctl00_main_gusertype01").checked = false;
    }
});

$('#ctl00_main_gusertype01').change(function () {
    var oInput = document.getElementById("ctl00_main_gusertype01");
    if (oInput.checked) {
        $("#form").css("display", "block");
        $("#form2").css("display", "none");
        document.getElementById("ctl00_main_usertype01").checked = true;
        document.getElementById("ctl00_main_usertype02").checked = false;
    }
});
$('#ctl00_main_gusertype02').change(function () {
    var oInput = document.getElementById("ctl00_main_gusertype02");
    if (oInput.checked) {
        $("#form").css("display", "none");
        $("#form2").css("display", "block");
        document.getElementById("ctl00_main_usertype02").checked = true;
        document.getElementById("ctl00_main_usertype01").checked = false;
    }
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
