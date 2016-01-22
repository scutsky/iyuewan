<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Downloadgames.aspx.cs" Inherits="Spread.Web.User.Downloadgames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" media="screen" href="../style/main.css" />
<link rel="stylesheet" type="text/css" href="../style/downloadGames.css"/>
    <link href="../Admin/Images/pagination.css" rel="stylesheet" type="text/css" />
    <script src="../javascript/jquery1102.js" type="text/javascript"></script>
    <script src="../Content/Javascript/jquery.pagination.js" type="text/javascript"></script>
    <script src="../javascript/jquery.zclip.js" type="text/javascript"></script>
    <style type="text/css">
.line{margin-bottom:20px;}
/* 复制提示 */
.copy-tips{position:fixed;z-index:999;bottom:50%;left:50%;margin:0 0 -20px -80px;background-color:rgba(0, 0, 0, 0.2);filter:progid:DXImageTransform.Microsoft.Gradient(startColorstr=#30000000, endColorstr=#30000000);padding:6px;}
.copy-tips-wrap{padding:10px 20px;text-align:center;border:1px solid #F4D9A6;background-color:#FFFDEE;font-size:14px;}
.pos{
  position:relative;
 
}
.pos a{ padding-top:8px; display:block;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 内容区 -->
    
     <script type="text/javascript">
        $(function() {
            //分页参数设置
            $("#Pagination").pagination(<%=pcount %>, {
            callback: pageselectCallback,
            prev_text: "« 上一页",
            next_text: "下一页 »",
            items_per_page:<%=pagesize %>,
		    num_display_entries:3,
		    current_page:<%=page %>,
		    num_edge_entries:2,
		    link_to:"?<%=CombUrlTxt(this.cooperateModelId,this.classId,this.keywords)%>page=__id__"
           });
        });
        function pageselectCallback(page_id, jq) {
           //alert(page_id); 回调函数，进一步使用请参阅说明文档
        }
        
       
    </script>

<div class="contain">
	<p class="crumbs"><a href="Channel.aspx">渠道</a> 
    <a href="javascript:void(0);void(0)" class="notactive">&gt; 下载推广游戏</a>
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
        
        <div class="table-title">
            <asp:LinkButton ID="lbdownall" runat="server" onclick="lbdownall_Click">批量导出包链接</asp:LinkButton>
        </div>



         <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand" 
            onitemdatabound="rptList_ItemDataBound" >
    <HeaderTemplate>
        <table id="table" border="0" cellspacing="0" cellpadding="0" class="main-table">
            <tbody><tr class="table-head" data-role="table-header">
               
                <th style="width: 125px;">游戏名称</th>
                <th style="width: 80px;">版本号</th>
                <th style="width: 110px;">推广包状态</th>
                <th style="width: 85px;">游戏平台</th>
                <th style="width: 85px;">更新类型</th>
				<th style="width: 80px;">更新时间</th>
                <th style="width: 100px;">操作</th>
            </tr>
              </HeaderTemplate>
      <ItemTemplate> 
      
        <tr class="table-row">
        <td><%#Eval("gameName")%>
          <asp:HiddenField ID="txtId" runat="server" Value='<%#Eval("ID")%>' />
          <asp:HiddenField ID="txtbak1" runat="server" Value='<%#Eval("bak1")%>' />
          <asp:HiddenField ID="txtVerifycode" runat="server" Value='<%#Eval("Verifycode")%>' /></td>
        <td><%#Eval("version")%></td>
        <td><%# Eval("Status").ToString() == "正在打包" ? "<span style='color:#FEC211'>正在打包</span>" : Eval("Status")%></td>
        <td><%#Eval("Bak2")%></td>
        <td><%#Eval("UpdateType")%></td>
        <td><%# Eval("Status").ToString() == "正在打包" ? "" : Eval("UpdateDate")%></td>
        <td class="links">
        
            <%#Eval("Status").ToString() == "正在打包" ? "" : "<div class=\"pos\"><a class=\"copyBtn\" href=\"javascript:;\" data-link=" + baseUrl +"/user/downloadapk.aspx?id=" + Eval("ID") + "&vc=" + Eval("Verifycode") + ">复制包链接</a> </div>"%>
            <asp:LinkButton ID="lbexport2" runat="server" ToolTip=<%#Eval("Status")%> CommandName="btnexport2"   >导出包链接</asp:LinkButton>
            <asp:LinkButton ID="lbexport3" runat="server" ToolTip=<%#Eval("Status")%> CommandName="btnexport3"  >下载包文件</asp:LinkButton>
            </td></tr>
           
             </ItemTemplate>
      <FooterTemplate>
       </tbody></table>
      </FooterTemplate>
      </asp:Repeater>

          
         <div id="Pagination" class="right flickr"></div>
    </div>
</div>



    <asp:HiddenField ID="hdPlatform" runat="server" />
    <asp:HiddenField ID="hduid" runat="server" />
    <asp:HiddenField ID="hdcid" runat="server" />
    <asp:HiddenField ID="hdcname" runat="server" />
<script type="text/javascript">
$(document).ready(function(){
/* 定义所有class为copy标签，点击后可复制被点击对象的文本 */
    $(".copyBtn").zclip({
		path: "ZeroClipboard.swf",
		copy: function () {
		    return $(this).data().link;
		},
		beforeCopy:function(){/* 按住鼠标时的操作 */
			$(this).css("color","orange");
		},
		afterCopy:function(){/* 复制成功后的操作 */
			var $copysuc = $("<div class='copy-tips'><div class='copy-tips-wrap'>☺ 复制成功</div></div>");
			$("body").find(".copy-tips").remove().end().append($copysuc);
			$(".copy-tips").fadeOut(3000);
        }
	});
/* 定义所有class为copy-input标签，点击后可复制class为input的文本 */
	$(".copy-input").zclip({
		path: "ZeroClipboard.swf",
		copy: function(){
		return $(this).parent().find(".input").val();
		},
		afterCopy:function(){/* 复制成功后的操作 */
			var $copysuc = $("<div class='copy-tips'><div class='copy-tips-wrap'>☺ 复制成功</div></div>");
			$("body").find(".copy-tips").remove().end().append($copysuc);
			$(".copy-tips").fadeOut(3000);
        }
	});
});
</script>
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


    $('#checkall').change(function () {
        if (document.getElementById('checkall').checked == true) {
            //$("#table-row").find("input[name=type]").attr("checked", true);
            $(".checkall input").attr("checked", true);
            //$("#table-row").find("input[name=type]").addClass();
        } else {
            $(".checkall input").attr("checked", false);
        }
    });
</script>
</asp:Content>
