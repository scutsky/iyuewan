<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Individualbal.aspx.cs" Inherits="Spread.Web.User.Individualbal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" media="screen" href="../style/main.css">
    <link rel="stylesheet" type="text/css" href="../style/common.css">
<link href="../themes/base/ui.all.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" type="text/css" href="../style/index.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<!-- 内容区 -->
	<div class="contain">
		<p class="crumbs">
			<a href="../Index.aspx">首页</a>
			<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp;结算详情</a>
		</p>
		<div class="box showMsg">
			<div  id="form1"  class="cf">
				<div class="fl">
					<div class="date-range-picker">
						<i class="icon"></i>
						<input type="text" value="" runat="server" class="start-time date-picker gldp-el" id="startdate" name="startDate" readonly />
						<span class="to">to</span>
						<input type="text" value="" runat="server" class="end-time date-picker gldp-el" id="enddate" name="endDate" readonly />
					</div>
				</div>
				<div class="action fr">
					 <asp:Button ID="searchBtn" runat="server" Text="搜索" CssClass="btn-1 searchBtn" 
                    onclick="searchBtn_Click" />
				<asp:Button ID="export" runat="server" Text="导出" CssClass="btn-2 export" 
                    onclick="export_Click" />
				</div>
			</div>

			<div class="result personal-result">
            <asp:Repeater ID="rptList" runat="server" >
            <HeaderTemplate>
				<table border="0" cellspacing="0" cellpadding="0" class="main-table">
					<thead>
						<tr class="table-head">
							<th>结算单号</th>
							<th>申请时间</th>
							<th>结算周期</th>
							<th>充值金额</th>
							<th>收入</th>
							<th>结算金额</th>
							<th>结算状态</th>
							<th>实际打款</th>
							<th>结算详情</th>
						</tr>
					</thead>
					<tbody>
					  </HeaderTemplate>
              <ItemTemplate> <tr>	
						<td><%#Eval("ID")%></td>
						<td><%#Eval("ApplyTime")%></td>
						<td><%#Eval("SettlementCycle")%></td>
						<td><%#Eval("Recharge")%></td>
						<td><%#Eval("Income")%></td>
						<td><%#Eval("Settlement")%></td>
						<td><%#Eval("Status")%></td>
						<td><%#Eval("ActualPlay")%></td>
						<td><a href="statis.aspx?id=<%#Eval("ID")%>">结算详情</a></td>	
						</tr>
					</ItemTemplate>
          <FooterTemplate>
          </tbody></table>
          </FooterTemplate>
          </asp:Repeater>
				<div id="pager">
					<div class="pager align-right">
		      				  <div class="pager align-right">
	  <div class="total">共有<asp:Label ID="lbCount" runat="server" style=" background:#FFF; border:0;" Text=""></asp:Label>条记录</div>
	  
	  </div>

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
            $("#nav_individualba").addClass("on");
        });
     </script>
    <script type="text/javascript">
        $(function () {
            $("#ctl00_main_startdate").datepicker({
                changeMonth: true,   // 允许选择月份       
                changeYear: true,   // 允许选择年份       
                dateFormat: 'yy-mm-dd',  // 设置日期格式       
                closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
                duration: 'fast',
                showAnim: 'fadeIn',
                onSelect: function (dateText, inst) {
                    $("#ctl00_main_startdate").blur();
                }

            });
            $("#ctl00_main_enddate").datepicker({
                changeMonth: true,   // 允许选择月份       
                changeYear: true,   // 允许选择年份       
                dateFormat: 'yy-mm-dd',  // 设置日期格式       
                closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
                duration: 'fast',
                showAnim: 'fadeIn',
                onSelect: function (dateText, inst) {
                    $("#ctl00_main_enddate").blur();
                }

            });
        });
    </script>
</asp:Content>
