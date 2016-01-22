<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="statis.aspx.cs" Inherits="Spread.Web.User.statis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../style/common.css">
<link href="../themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->
    


<div class="contain statis-game">
	<p class="crumbs">
		<a href="../Index.aspx">首页</a>
		<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 数据统计</a>
	</p>
	<div class="box showMsg">
		<div id="form1">
			<div class="cf">
                <div class="select-wrap">
					<label>平台：</label>
                    <asp:DropDownList ID="ddlMenu" runat="server" class="mySelect" style=" width:120px;">
                    </asp:DropDownList>
				</div>
				<div class="select-wrap" style=" margin-left:20px; top: -2px; left: 47px;">
					<label>渠道：</label>
                    <asp:DropDownList ID="ddlChanel" runat="server" class="mySelect" style=" width:120px;">
                    </asp:DropDownList>
				</div>
                
				<div class="select-wrap fl" style=" margin-left:20px; top: -1px; left: 36px;">
					<label>推广游戏：</label>
					<input id="gameinput" type="text" class="text" value="" placeholder="请输入游戏名称..." runat="server" style=" width:150px;" />
					
				</div>
				<div class="date-range-picker fr">
					<i class="icon"></i>
					<input type="text"  value="" class="start-time gldp-el" id="txtDate1"  runat="server" />
					<span class="to">to</span>
					<input type="text"  value="" class="end-time gldp-el" id="txtDate2" runat="server" />
				</div>
			</div>
			<div class="action">
                <asp:Button ID="searchBtn" runat="server" Text="搜索" CssClass="btn-1 searchBtn" 
                    onclick="searchBtn_Click" />
				<asp:Button ID="export" runat="server" Text="导出" CssClass="btn-2 export" 
                    onclick="export_Click" />
				
			</div>
			<input type="hidden" id="statDateStr" name="statis.statDateStr" value="">
		</div>

		<div id="result" class="result m-t-20">
         <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand" 
                onitemdatabound="rptList_ItemDataBound" >
            <HeaderTemplate>
			        <table border="0" cellspacing="0" cellpadding="0" class="main-table">
				        <tbody><tr class="table-head">
					        <th>日期</th>
					        <th>注册用户</th>
					        <th>充值金额</th>
					        <th>收入</th>
					        <th>报表导出</th>
				        </tr>
				         </HeaderTemplate>
              <ItemTemplate> 
				<tr <%#Eval("SumDate")=="总计"?"style='color:#FF8400;'":""%>>
					<td><%#Eval("SumDate")%></td>
					<td><%#Eval("num")%></td>
					<td><%#Eval("ConsumptionValue")%></td>
					<td><%#Eval("Income")%></td>
					<td>
                        <asp:LinkButton ID="lbexport" runat="server" CommandName=<%#Eval("SumDate")%> >详细报表</asp:LinkButton>
                   </tr>
				</ItemTemplate>
          <FooterTemplate>
          </tbody></table>
          </FooterTemplate>
          </asp:Repeater>

			<div id="pager">
	      				  <div class="pager align-right">
	  <div class="total">共有<asp:Label ID="lbCount" runat="server" style=" background:#FFF; border:0;" Text=""></asp:Label>条记录</div>
	  
	  </div>

			</div>
		</div>
	</div>
</div>
    <asp:HiddenField ID="hduserid" runat="server" />

    <script src="../js/jquery.js" type="text/javascript"></script>
 <script src="../js/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.datepicker.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $(".content ul li").removeClass("on");
         $("#nav_statis").addClass("on");
     });
     </script>
    <script type="text/javascript">
     $(function () {
        $("#ctl00_main_txtDate1").datepicker({
            changeMonth: true,   // 允许选择月份       
            changeYear: true,   // 允许选择年份       
            dateFormat: 'yy-mm-dd',  // 设置日期格式       
            closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
            duration: 'fast',
            showAnim: 'fadeIn',
            onSelect: function (dateText, inst) {
                $("#ctl00_main_txtDate1").blur();
            }

        });
        $("#ctl00_main_txtDate2").datepicker({
            changeMonth: true,   // 允许选择月份       
            changeYear: true,   // 允许选择年份       
            dateFormat: 'yy-mm-dd',  // 设置日期格式       
            closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
            duration: 'fast',
            showAnim: 'fadeIn',
            onSelect: function (dateText, inst) {
                $("#ctl00_main_txtDate2").blur();
            }

        });
    });
    </script>
</asp:Content>
