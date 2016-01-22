define("/public/javascripts/dist/app/channel/chooseGames", ["../../common/common", "../../common/alert-window", "../../common/title-window", "../../common/base-window"], function (require) {
    require("../../common/common");
    var AlertWindow = require("../../common/alert-window");
    var alertWindow = new AlertWindow();
    var app = {
        _init: function () {
            var that = this;
            that._cacheDom();
            that._bindEvent();
        },
        _cacheDom: function () {
            var that = this;
            // 搜索输入框
            that.$searchInput = $("#search-input");
            // 全选 checkbox
            that.$selectAllCheckbox = $('[data-role="select-all-checkbox"]');
            that.$wordFilter = $('[data-role="word-filter"]');
            // checkbox
            that.$checkboxs = $(".checkBoxGroup .checkBox");
            // 搜索结果列表
            that.$searchResultList = $("#search-result-list");
            // 已选择列表
            that.$chooseList = $("#choose-list");
        },
        _bindEvent: function () {
            var that = this;
            // 搜索框 focus 效果
            that.$searchInput.focus(function () {
                $(this).parents(".searchGroup").addClass("focus");
            }).blur(function () {
                $(this).parents(".searchGroup").removeClass("focus");
            });
            // label click 效果
            $("#choose-game-wrap .checkBox").parent().click(function (e) {
                if (!$(e.target).hasClass("checkBox")) {
                    $(this).find(".checkBox").trigger("click");
                }
            });
            // 全选
            that.$selectAllCheckbox.on("click", function () {
                $(this).hasClass("checked") ? that.$checkboxs.addClass("checked") : that.$checkboxs.removeClass("checked");
                that.$selectAllCheckbox.not(this).toggleClass("checked");
            });
            that.$wordFilter.on("click", function () {
                var $items = $(this).parents(".checkBoxGroup").find(".gameList .checkBox");
                $(this).hasClass("checked") ? $items.addClass("checked") : $items.removeClass("checked");
            });
            // 删除
            that.$chooseList.on("click", ".close", function () {
                var $li = $(this).parents("li");
                that._changeCheckBoxStatus($li.data("id"), false);
                $li.remove();
            });
            // checkbox 状态改变后，对应的已选择列表随之改变
            $("#choose-game-wrap").on("click", ".checkBox", function (e) {
                that._updateChooseList();
            });
            // 即时搜索
            that._bindLiveSearch();
            // 选择搜索结果
            that._bindSelectResult();
            // 保存
            $('[data-role="save"]').click(function () {
                that._save($(this));
            });
        },
        // 即时搜索
        _bindLiveSearch: function () {
            var that = this, xhr, timeId;
            that.$searchInput.keyup(function () {
                var keyword = $(this).val(), queryData, url = $(this).data("url");
                // 清除上一次的请求
                xhr && xhr.abort();
                clearTimeout(timeId);
                if ($.trim(keyword) === "") {
                    that.$searchResultList.hide();
                    return;
                }
                queryData = {
                    cooperateId: $("#cooperate-id").val(),
                    appName: keyword,
                    platformId: $("#platform-id").data("value")
                };
                // 输入后， 400 毫秒后才请求接口
                timeId = setTimeout(function () {
                    xhr = $.get(url, queryData, function (jsonData) {
                        if (jsonData.length > 0) {
                            that.$searchResultList.show();
                            that.$searchResultList.html("");
                            for (var i = 0; i < jsonData.length; i++) {
                                var item = jsonData[i], $li = $("<li>");
                                $li.data("item", item);
                                $li.text(item.sourceAppName + " " + item.sourcePlatform);
                                that.$searchResultList.append($li);
                            }
                        } else {
                            that.$searchResultList.hide();
                        }
                    });
                }, 400);
            });
        },
        // 选择搜索结果
        _bindSelectResult: function () {
            var that = this;
            that.$searchResultList.on("click", "li", function () {
                var $this = $(this), item, dataItem = $this.data("item");
                // 复原搜索框状态
                that.$searchResultList.hide();
                that.$searchInput.val("").trigger("blur");
                item = {
                    id: dataItem.id,
                    name: $this.text()
                };
                that._addItem(item);
                // 全部的游戏列表中对应的 checkbox 要勾选
                that._changeCheckBoxStatus(item.id, true);
            });
        },
        // 更新已选择列表
        _updateChooseList: function () {
            var that = this, ids = that._getSelectedId();
            that.$checkboxs.each(function () {
                var item, $li = $(this).parents("li"), id = $li.data("id");
                if ($(this).hasClass("checked") && id) {
                    item = {
                        id: id,
                        name: $li.text()
                    };
                    that._addItem(item);
                } else if ($.inArray(id, ids) >= 0) {
                    that.$chooseList.find('li[data-id="' + id + '"]').remove();
                }
            });
        },
        // 添加到已选择
        _addItem: function (item) {
            var that = this, flag = false, html = "";
            // 如果已经添加了，就不需要再添加了
            that.$chooseList.find("li").each(function () {
                if (flag) return;
                if ($(this).data("id") === item.id) {
                    flag = true;
                }
            });
            if (flag) return;
            html += '<li data-id="' + item.id + '"> ' + item.name + ' <span class="close">×</span></li>';
            that.$chooseList.append(html);
        },
        // 获取已经选择的 id
        _getSelectedId: function () {
            var that = this, ids = [];
            that.$chooseList.find("li").each(function () {
                ids.push($(this).data("id"));
            });
            return ids;
        },
        // 改变游戏列表 对应 id 的 checkbox 的状态
        _changeCheckBoxStatus: function (id, status) {
            var that = this;
            that.$checkboxs.each(function () {
                if ($(this).parents("li").data("id") === id) {
                    status ? $(this).addClass("checked") : $(this).removeClass("checked");
                }
            });
        },
        // 保存
        _save: function ($el) {
            var that = this, ids = that._getSelectedId(), cooperateId = $("#cooperate-id").val();
            if ($('[data-role="save"]').data("sending")) {
                return;
            }
            $('[data-role="save"]').data("sending", true).text("loading").css("opacity", "0.5");
            $.post($el.data("url"), {
                cooperateId: cooperateId,
                resourceIds: ids.join(",")
            }, function (jsonData) {
                $('[data-role="save"]').data("sending", false).text("选好了，保存").css("opacity", "1");
                if (jsonData.state.code === 2e6) {
                    $("#to-dl-link").attr("href", jsonData.data);
                    $("#win").show();
                } else {
                    alertWindow.show(jsonData.state.message);
                }
            });
        }
    };
    app._init();
});

define("dist/common/common", [], function (require) {
    var app = {
        _init: function () {
            var that = this;
            that._bind();
        },
        _bind: function () {
            var that = this;
            // 下拉列表事件绑定
            $(".mySelect").on("click", function (e) {
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
            $("body").on("click", function (e) {
                $(".mySelect .options").hide();
            });
            $(".mySelect").each(function () {
                var val = $(this).find("input").val();
                if (val) {
                    var text = $(this).find('li[data-value="' + val + '"]').text();
                    $(this).find(".value").attr("data-vaue", val).text(text);
                }
            });
            // 选择框事件绑定
            $(".checkBox").on("click", function () {
                $(this).toggleClass("checked");
                $(this).siblings('input[type="hidden"]').val($(this).hasClass("checked") ? 1 : 0);
            });
            // 输入框事件绑定
            $(".inputGroup").on("click", function () {
                $(this).find("input").focus();
            });
            $("body").on("focus", ".inputGroup input", function () {
                $(this).parents(".inputGroup").addClass("focus").find(".placeholder").hide();
            }).on("blur", ".inputGroup input", function () {
                var $parent = $(this).parents(".inputGroup");
                $parent.removeClass("focus");
                if ($(this).val() === "") {
                    $parent.find(".placeholder").show();
                }
            });
            // 如果搜索框有值，就将 placeholder 隐藏
            $(".inputGroup input").each(function () {
                if ($(this).val()) {
                    $(this).parents(".inputGroup").find(".placeholder").hide();
                }
            });
            var elem = document.createElement("canvas");
            var isSupportCanvas = !!(elem.getContext && elem.getContext("2d"));
            // ym-checkbox ie8 不支持 canvas，使用 canvas 检查 ie8以下的浏览器
            if (!isSupportCanvas) {
                // 检查如果设置 checked 的话，要加上 .checked 样式
                $(".ym-checkbox").each(function () {
                    if ($(this).is(":checked")) {
                        $(this).addClass("checked");
                    }
                });
                // 选择事件
                $(".ym-checkbox").parents("label").on("click", function () {
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

define("dist/common/alert-window", ["dist/common/title-window", "dist/common/base-window"], function (require, exports, module) {
    var TitleWindow = require("dist/common/title-window");
    var html = '<div class="msg"></div><div class="action"><a href="javascript:void(0);" class="btn btn-1"></a></div>';
    var AlertWindow = function (options) {
        this.init(options);
    };
    _.extend(AlertWindow.prototype, TitleWindow.prototype, {
        title: "消息",
        width: 400,
        height: 190,
        btnText: "确定",
        cssClass: "alert-window",
        init: function (options) {
            _.extend(this, options);
            TitleWindow.prototype.init.call(this, options);
        },
        _initDom: function () {
            TitleWindow.prototype._initDom.call(this);
            this.$winContent = this.$winInner.find(".win-content");
            this.$winContent.append(html);
            this.$msg = this.$winContent.find(".msg");
            this.$okBtn = this.$winContent.find(".btn");
            this.$okBtn.text(this.btnText);
        },
        _bindEvent: function () {
            var that = this;
            TitleWindow.prototype._bindEvent.call(this);
            that.$el.on("click", ".action .btn", function () {
                that.hide();
                if (typeof that.onOKClick === "function") {
                    that.onOKClick.call(that, this);
                }
            });
        },
        show: function (msg, onOKClick) {
            TitleWindow.prototype.show.call(this);
            this.onOKClick = onOKClick;
            this.$msg.html(msg);
        }
    });
    module.exports = AlertWindow;
});

define("dist/common/title-window", ["dist/common/base-window"], function (require, exports, module) {
    var BaseWindow = require("dist/common/base-window");
    var html = '<div class="win-title cf"><h1 ></h1><div class="close-btn"><i class="iconfont icon-close"></i></div></div><div class="win-content"></div>';
    var TitleWindow = function (options) {
        this.init(options);
    };
    _.extend(TitleWindow.prototype, BaseWindow.prototype, {
        title: "title-window",
        init: function (options) {
            _.extend(this, options);
            BaseWindow.prototype.init.call(this);
            this._bindEvent();
        },
        _initDom: function () {
            BaseWindow.prototype._initDom.call(this);
            this.$winInner.append(html);
            this.$winInner.find(".win-title h1").text(this.title);
        },
        _bindEvent: function () {
            var that = this;
            that.$el.on("click", ".close-btn", function () {
                that.hide();
            });
            // esc 关闭窗口
            $(document).keyup(function (e) {
                if (e.keyCode == 27) {
                    that.hide();
                }
            });
        }
    });
    module.exports = TitleWindow;
});

define("dist/common/base-window", [], function (require, exports, module) {
    var html = '<div class="mask"></div><div class="win-inner"></div>';
    var BaseWindow = function () {
        this.init();
    };
    BaseWindow.prototype = {
        id: "win-" + new Date().getTime(),
        width: 200,
        height: 150,
        minWidth: 200,
        minHeight: 150,
        cssClass: "",
        onShow: function () { },
        onClose: function () { },
        init: function () {
            this._initDom();
        },
        show: function () {
            this.$el.show();
            this.onShow.call(this);
        },
        hide: function () {
            this.$el.hide();
            this.onClose.call(this);
        },
        _initDom: function () {
            this.$el = $('<div class="win-wrap">');
            this.$el.attr("id", this.id);
            this.$el.hide();
            if (this.cssClass) {
                this.$el.addClass(this.cssClass);
            }
            this.$el.html(html);
            this.$winInner = this.$el.find(".win-inner");
            this.$winInner.css({
                width: this.width,
                height: this.height,
                minWidth: this.minWidth,
                minHeight: this.minHeight,
                marginLeft: -this.width / 2,
                marginTop: -this.height / 2
            });
            this.$winInner.addClass(this.cssClass);
            $("body").append(this.$el);
        }
    };
    module.exports = BaseWindow;
});
