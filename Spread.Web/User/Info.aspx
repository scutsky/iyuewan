<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Spread.Web.User.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen" href="../style/main.css">
    <link rel="stylesheet" type="text/css" href="../style/gameCommon.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<!-- 内容区 -->
    
 <div class="contain game-gift">
		<p class="crumbs">
			<a href="Channel.aspx">渠道</a>
			<a href="javascript:void(0)" class="notactive">&gt; 游戏资料</a>
		</p>
		<!--下面的注释是消除inline-block产生的间隙-->
		<div class="box showMsg">
			<div class="title">
				 <span>渠道：<asp:Label ID="lbTitle" runat="server" Text=""></asp:Label></span>
            <span>计费模式：<asp:Label ID="lbBrand" runat="server" Text=""></asp:Label></span>
            <span>推广产品：<asp:Label ID="lbPtitle" runat="server" Text=""></asp:Label></span>
			</div>

			<div id="searchForm" >
				 <div class="row2">
            <div class="searchGroup">
                <div class="inputGroup">
					<input id="searchinput" type="text" class="keyword"  runat="server">
                    <!-- 合作模式 id  -->
                  
                    <span class="placeholder" style="display: none;">输入关键字筛选游戏</span>
                    <span class="rightline"></span>
                </div>
                <div class="mySelect">
                    <span id="platform-id" class="value" data-value="">所有平台</span><i class="icon"></i>
                    <div class="options" >
                        <ul class="list">
                            <li data-value="">所有平台</li>
                            <li data-value="Flash">Flash</li>
                            <li data-value="Web">Web</li>
                            <li data-value="Wap">Wap</li>
                            <li data-value="H5">H5</li>
                            <li data-value="WP">WP</li>
                            <li data-value="Ipad">Ipad</li>
                            <li data-value="Iphone">Iphone</li>
                            <li data-value="Android">Android</li>
                            <li data-value="Symbian">Symbian</li>
                            
                        </ul>
                    </div>
                </div>
                
            </div>
            <asp:Button ID="searchbtn" runat="server" Text="搜索" class="btn-2 searchBtn" 
                onclick="searchbtn_Click"/>
        </div>
			</div>
			<div class="table-title">
                <asp:LinkButton ID="lbdownall" runat="server" onclick="lbdownall_Click">批量导出游戏资料</asp:LinkButton>
				<span style="color: #888;">（包括游戏的基础资料、大事件）</span>
			</div>
             <asp:Repeater ID="rptList" runat="server"  >
    <HeaderTemplate>
			<table border="0" cellspacing="0" cellpadding="0" class="main-table">
				<tbody>
					<tr class="table-head">
						<th>游戏名称</th>
						<th>游戏平台</th>
						<th>上架时间</th>
						<th>操作</th>
					</tr>
                     </HeaderTemplate>
                    <ItemTemplate> 
						<tr>
							<td style="width:250px;"><%#Eval("gamename")%></td>
						<td style="width:80px;"><%#Eval("Platform")%></td>
						<td style="width:150px;"><%#Eval("UpdateDate")%></td>
						<td class="links"style="width:200px;" >
                        <%# Eval("gbak2") != "" ? "<a href=\"" + Eval("gbak2") + "\" >游戏基础资料</a>" : "游戏基础资料"%>
                        <%# Eval("gbak3") != "" ? "<a href=\"" + Eval("gbak3") + "\" >游戏大事件资料</a>" : "游戏大事件资料"%>
                         </td>
					</tr>
                     </ItemTemplate>
                     <FooterTemplate>
                        </tbody></table>
                  </FooterTemplate>
                  </asp:Repeater>

			<div id="pager">
					  <div class="pager align-right">
	  <div class="total">共有<asp:Label ID="lbCount" runat="server" style=" border:0px; background:#FFF;" ></asp:Label>条记录</div>
                          
	  
	  </div>
			</div>
		</div>
	</div>

 <asp:HiddenField ID="hdPlatform" runat="server" />
    <asp:HiddenField ID="hduid" runat="server" />
    <asp:HiddenField ID="hdcid" runat="server" />
    <asp:HiddenField ID="hdcname" runat="server" />
    <script src="../javascript/jquery.js" type="text/javascript"></script>
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
    </script>
</asp:Content>
