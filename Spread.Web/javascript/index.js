define("/public/javascripts/dist/app/index/index", [ "../../common/common" ], function(require) {
    require("../../common/common");
    var loginErrorCount = 0;
    var app = {
        _init: function() {
            var that = this;
            that._bind();
            if ($("#login-form").length > 0) {
                that._initValidate();
            }
            var suportPlaceHolder = function() {
                var i = document.createElement("input");
                return "placeholder" in i;
            }();
            if (!suportPlaceHolder) {
                $(".placeholder").removeClass("hide");
            }
        },
        _bind: function() {
            var that = this;
            $(".close").click(function() {
                $(this).parent().hide();
            });
            $("#submit-btn").click(function() {
                $("#login-form").submit();
            });
            // enter 提交
            $(document).keyup(function(e) {
                if (e.keyCode == 13) {
                    $("#login-form").submit();
                }
            });
            $("#notice").animate({
                bottom: 0
            }, 500);
            setTimeout(function() {
                $("#notice").animate({
                    bottom: -500
                }, 500);
            }, 3e4);
        },
        _initValidate: function() {
            $("#login-form").on("submit", function() {
                var flag = false, $submitBtn = $("#submit-btn"), requiredMessage = "请输入用户名、密码和验证码";
                if ($submitBtn.data("sending")) {
                    return false;
                }
                if ($("#verify-code").hasClass("hide")) {
                    $("#verify-code").find('input[type="text"]').val("1234");
                    requiredMessage = "请输入用户名、密码";
                }
                $(this).find("input").each(function() {
                    if ($(this).val() == "") {
                        flag = true;
                        return false;
                    }
                });
                if (flag) {
                    $("#login-error").removeClass("hide");
                    $("#common-error").text(requiredMessage);
                    $("#find-pwd-tip").addClass("hide");
                    return false;
                }
                var postData = $(this).serialize(), url = $(this).attr("action");
                $(this).find('input[type="password"]').each(function() {
                    var name = $(this).attr("name"), val = $(this).val(), reg = new RegExp(name + "=" + encodeURIComponent(val));
                    postData = postData.replace(reg, name + "=" + md5(val));
                });
                $.ajax({
                    url: url,
                    data: postData,
                    type: "POST",
                    beforeSend: function() {
                        $submitBtn.text("loading").css("opacity", .5);
                        $submitBtn.data("sending", true);
                    },
                    complete: function() {
                        $submitBtn.text("登录").css("opacity", 1);
                        $submitBtn.data("sending", false);
                    },
                    success: function(jsonData) {
                        switch (jsonData.state.code) {
                          case 2e6:
                            window.location.reload();
                            break;

                          case 5000030:
                            // 登录失败
                            $("#login-error").removeClass("hide");
                            $("#common-error").text(jsonData.state.message);
                            $("#find-pwd-tip").removeClass("hide");
                            break;

                          case 5000031:
                            // 验证码错误
                            $("#login-error").removeClass("hide");
                            $("#common-error").text(jsonData.state.message);
                            $("#find-pwd-tip").addClass("hide");
                            break;

                          case 5000034:
                            window.location.href = "phoneVerify.htm"/*tpa=http://gm.hzjiulian.com/channel/phoneVerify*/;
                            break;
                        }
                        // 登录失败次数
                        loginErrorCount = jsonData.data || loginErrorCount;
                        if (loginErrorCount >= 3) {
                            $("#verify-code").removeClass("hide").find('input[type="text"]').val("");
                        }
                        $(".checkcode .code img").click();
                    }
                });
                return false;
            });
        }
    };
    app._init();
});

define("dist/common/common", [], function(require) {
    var app = {
        _init: function() {
            var that = this;
            that._bind();
        },
        _bind: function() {
            var that = this;
            // 下拉列表事件绑定
            $(".mySelect").on("click", function(e) {
                e.stopPropagation();
                var $value = $(this).find(".value");
                var $option = $(this).find(".options");
                if (e.target.tagName === "LI") {
                    var value = $(e.target).data("value");
                    $value.html($(e.target).html()).data("value", value);
                    $(this).find("input").val(value);
                    $option.hide();
                    $(this).data("value", value).trigger("change");
                } else {
                    $option.css("display") == "block" ? $(this).find(".options").hide() : $(this).find(".options").show();
                }
            });
            $("body").on("click", function(e) {
                $(".mySelect .options").hide();
            });
            $(".mySelect").each(function() {
                var val = $(this).find("input").val();
                if (val) {
                    var text = $(this).find('li[data-value="' + val + '"]').text();
                    $(this).find(".value").attr("data-vaue", val).text(text);
                }
            });
            // 选择框事件绑定
            $(".checkBox").on("click", function() {
                $(this).toggleClass("checked");
                $(this).siblings('input[type="hidden"]').val($(this).hasClass("checked") ? 1 : 0);
            });
            // 输入框事件绑定
            $(".inputGroup").on("click", function() {
                $(this).find("input").focus();
            });
            $("body").on("focus", ".inputGroup input", function() {
                $(this).parents(".inputGroup").addClass("focus").find(".placeholder").hide();
            }).on("blur", ".inputGroup input", function() {
                var $parent = $(this).parents(".inputGroup");
                $parent.removeClass("focus");
                if ($(this).val() === "") {
                    $parent.find(".placeholder").show();
                }
            });
            // 如果搜索框有值，就将 placeholder 隐藏
            $(".inputGroup input").each(function() {
                if ($(this).val()) {
                    $(this).parents(".inputGroup").find(".placeholder").hide();
                }
            });
            var elem = document.createElement("canvas");
            var isSupportCanvas = !!(elem.getContext && elem.getContext("2d"));
            // ym-checkbox ie8 不支持 canvas，使用 canvas 检查 ie8以下的浏览器
            if (!isSupportCanvas) {
                // 检查如果设置 checked 的话，要加上 .checked 样式
                $(".ym-checkbox").each(function() {
                    if ($(this).is(":checked")) {
                        $(this).addClass("checked");
                    }
                });
                // 选择事件
                $(".ym-checkbox").parents("label").on("click", function() {
                    var $checkbox = $(this).find('input[type="checkbox"]');
                    if ($checkbox.is(":checked")) {
                        $checkbox.addClass("checked");
                    } else {
                        $checkbox.removeClass("checked");
                    }
                });
            }
        }
    };
    app._init();
});
