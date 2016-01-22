<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Choosegames.aspx.cs" Inherits="Spread.Web.User.Choosegames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" media="screen" href="../style/main.css">    
<link rel="stylesheet" type="text/css" href="../style/chooseGames.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<!-- 内容区 -->
    


<div class="contain">
    <p class="crumbs"><a href="Channel.aspx">我的渠道</a> <a href="javascript:void(0)" class="notactive">&gt; 选择推广游戏</a>
    </p>
    <!--下面的注释是消除inline-block产生的间隙-->
    <div class="box showMsg">
        <div class="title">
            <span>渠道：<asp:Label ID="lbTitle" runat="server" Text=""></asp:Label></span>
            <span>计费模式：<asp:Label ID="lbBrand" runat="server" Text=""></asp:Label></span>
            <span>推广产品：<asp:Label ID="lbPtitle" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="row2">
            <div class="searchGroup">
                <div class="inputGroup">
					<input id="searchinput" type="text" class="keyword"  runat="server">
                    <!-- 合作模式 id  -->
                  
                    <span class="placeholder" style="display: none;">输入关键字筛选游戏</span>
                    <span class="rightline"></span>
                </div>
                <div class="mySelect">
                    <span id="platform-id" class="value" data-value=""><%=platformId%></span><i class="icon"></i>
                    <div class="options" >
                        <ul class="list">
                            <li data-value="">所有平台</li>
                              <%
                                  if (this.MenuData != null && this.MenuData.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.MenuData.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.MenuData.Rows[i];%>
                            <li data-value="<%=dr["Title"].ToString()%>"><%=dr["Title"].ToString()%></li>
                              <%}
                                }%>
                          
                        </ul>
                    </div>
                </div>
                
            </div>
            <asp:Button ID="searchbtn" runat="server" Text="搜索" class="btn-2 searchBtn" 
                onclick="searchbtn_Click"/>
        </div>
        
        <div class="chooseGame">
            <div class="leftLineTitle">请选择要推广的游戏：</div>
              <ul id="choose-list" class="hasChoose cf">
              
                 <%
                     if (this.chooseGame != null && this.chooseGame.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.chooseGame.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.chooseGame.Rows[i];%>
                       <%--  <script type="text/javascript">
                             function chek() {
                                 $(".checkBoxGroup .gameList").find('li[data-id="' + <%=dr["gameName"].ToString()%> + '"]').addClass("checked");
                             }
                         </script>--%>
                            <li data-id="<%=dr["gameName"].ToString()%>"> 
                     <%=dr["gameName"].ToString()%> <span class="close">×</span>
                     </li>
                  <%}
                 }%>
              </ul>
        </div>

        <div id="choose-game-wrap" class="classifyModule">
             <div class="cmtitle">
                
                  <asp:Button ID="btnSave2" runat="server" Text="选好了，保存"  class="btn-1 saveBtn" 
                    OnClientClick=" return getValue();" onclick="btnSave2_Click" />
            </div>
            <div id="checkBoxGroup1" class="checkBoxGroup">
                <div class="word">A-E</div>
                <div class="topLine"></div>

               
                <ul class="gameList cf">
			     <%
             if (this.GameDataAE != null && this.GameDataAE.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.GameDataAE.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.GameDataAE.Rows[i];%>
                
                    <li data-id="<%=dr["Name"].ToString()%>"><i class="icon checkBox"></i>
                        <%=dr["Name"].ToString()%>
                    </li>
                    <%}
                 }%>
                </ul>
            </div>
            
            <div class="checkBoxGroup">
                <div class="word">F-J</div>
                <div class="topLine"></div>
                <ul class="gameList cf">
			       <%
                   if (this.GameDataFJ != null && this.GameDataFJ.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.GameDataFJ.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.GameDataFJ.Rows[i];%>
                
                    <li data-id="<%=dr["Name"].ToString()%>"><i class="icon checkBox"></i>
                        <%=dr["Name"].ToString()%>
                    </li>
                    <%}
                 }%>
                </ul>
            </div>
            
            <div class="checkBoxGroup">
                <div class="word">K-O</div>
                <div class="topLine"></div>
                <ul class="gameList cf">
                     <%
                         if (this.GameDataKO != null && this.GameDataKO.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.GameDataKO.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.GameDataKO.Rows[i];%>
                
                    <li data-id="<%=dr["Name"].ToString()%>"><i class="icon checkBox"></i>
                        <%=dr["Name"].ToString()%>
                    </li>
                    <%}
                 }%>
                 
                </ul>
            </div>
            
            <div class="checkBoxGroup">
                <div class="word">P-T</div>
                <div class="topLine"></div>
                <ul class="gameList cf">
			    
                
                     <%
                         if (this.GameDataPT != null && this.GameDataPT.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.GameDataPT.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.GameDataPT.Rows[i];%>
                
                    <li data-id="<%=dr["Name"].ToString()%>"><i class="icon checkBox"></i>
                        <%=dr["Name"].ToString()%>
                    </li>
                    <%}
                 }%>
                </ul>
            </div>
            
            <div class="checkBoxGroup">
                <div class="word">U-Z</div>
                <div class="topLine"></div>

                
                <ul class="gameList cf">
                  
                     <%
                         if (this.GameDataUZ != null && this.GameDataUZ.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.GameDataUZ.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.GameDataUZ.Rows[i];%>
                
                    <li data-id="<%=dr["Name"].ToString()%>"><i class="icon checkBox"></i>
                        <%=dr["Name"].ToString()%>
                    </li>
                    <%}
                 }%>
                </ul>
            </div>
            <div class="checkBoxGroup">
                <div class="word">其他</div>
                <div class="topLine"></div>

                
                <ul class="gameList cf">
                  
                     <%
                         if (this.GameDataQT != null && this.GameDataQT.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.GameDataQT.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.GameDataQT.Rows[i];%>
                
                    <li data-id="<%=dr["Name"].ToString()%>"><i class="icon checkBox"></i>
                        <%=dr["Name"].ToString()%>
                    </li>
                    <%}
                 }%>
                </ul>
            </div>
            

            <div class="cmtitle" style="text-align: center;margin-top: 20px;">
                <asp:Button ID="btnSave" runat="server" Text="选好了，保存"  class="btn-1 saveBtn" 
                    OnClientClick=" return getValue();" onclick="btnSave_Click" />
            </div>
        </div>
    </div>
</div>

<div id="win" class="win-wrap choose-game">
    <div class="mask"></div>
    <div class="win-inner">
        <div class="img"></div>
        <h1>保存成功</h1>
        <h2>系统正为您准备推广包，等待时间约为几分钟......</h2>
        <div class="link">
            <!-- TODO 修改为真实的资源列表 -->
			<a href="Channel.aspx" class="btn-1 fl">返回资源列表</a>
            <a id="to-dl-link" href="javascript:void(0);" class="btn-1 fr">去下载列表</a>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdPlatform" runat="server" />
<asp:HiddenField ID="hdValue" runat="server" />
<asp:HiddenField ID="hduid" runat="server" />
<asp:HiddenField ID="hdcid" runat="server" />
<asp:HiddenField ID="hdcname" runat="server" />
    <script src="../javascript/jquery.js" type="text/javascript"></script>
    <script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
    <script type="text/javascript">
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
                $("#ctl00_main_hdPlatform").val(value);
                //alert(value);
            } else {
                $("#ctl00_main_hdPlatform").val("");
                $option.css("display") == "block" ? $(this).find(".options").hide() : $(this).find(".options").show();
            }
        });

        $("#choose-list").find("li").each(function () {
            id = $(this).data("id");
            $(".checkBoxGroup .gameList").find('li[data-id="' + id + '"] i').addClass("checked");
        });

        $("#choose-list .close").click(function () {
            id = $(this).parents("li").data("id");
            $("#choose-list").find('li[data-id="' + id + '"]').remove();
            $(".checkBoxGroup .gameList").find('li[data-id="' + id + '"] i').removeClass("checked");
        });
        $("#checkall").click(function () {
            if ($(this).hasClass("checked")) {
                $("#checkall").removeClass("checked");
                $(".checkBoxGroup .gameList li").find("i").removeClass("checked");
            } else {
                $("#checkall").addClass("checked");
                $(".checkBoxGroup .gameList li").find("i").addClass("checked");
            }
        });

        var html = "";
        $(".checkBoxGroup .gameList li").click(function () {
            var item, $li = $(this).parents("li"), id = $(this).data("id");
            //var html = $("#choose-list").html();
            if ($(this).find("i").hasClass("checked")) {
                $(this).find("i").removeClass("checked");
                $("#choose-list").find('li[data-id="' + id + '"]').remove();
            } else {
                $(this).find("i").addClass("checked");
                html = '<li data-id="' + id + '">' + id + '<span class="close">×</span></li>';
                $("#choose-list").append(html);
            }
            //            var vlaue_id = "";
            //            $("#choose-list").find("li").remove();
            //            $(this).find("i").each(function () {
            //                var item, $li = $(this).parents("li"), id = $li.data("id");
            //                if ($(this).hasClass("checked")) {
            //                    vlaue_id += id + ",";
            //                    html += '<li data-id="' + id + '"> ' + $li.text() + '</li>';                   
            //                    //$("#choose-list").find('li[data-id="' + id + '"]').remove();
            //                }
            //                $("#choose-list").append(html);
            //            });
        });
        
        
        function getValue() {
        var vlaue_id="";
                $("#choose-list").find("li").each(function () {
                  id = $(this).data("id");
                  vlaue_id += id + ",";
            });
            if (vlaue_id == "") {
                alert("请选择游戏！");
                return false;
            }
            $("#ctl00_main_hdValue").val(vlaue_id);
            return true;
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
