<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaycountDetail.aspx.cs" Inherits="Spread.Web.Admin.statistics.DaycountDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>账号管理</title>

    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <link rel="stylesheet" type="text/css" href="../images/pagination.css" />
    <link href="../../themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script src="../../js/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../js/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation"><b>您当前的位置：首页 &gt; 数据统计 &gt; 统计详细列表</b></div>
    <div class="spClear"></div>
  
    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="10%">统计日期</th>
        <th width="20%">渠道</th>
        <th width="13%">注册值</th>
        <th width="16%">消费值</th>
        <th width="16%">收入</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center"><%#Eval("SumDate")%></td>
        <td align="center"><%#Eval("ChannelName")%></td>
        <td align="center"><%#Eval("RegisterValue")%></td>
        <td align="center"><%#Eval("ConsumptionValue")%></td>
        <td align="center"><%#Eval("Income")%></td>
      </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>

    <div class="spClear"></div>
    <asp:HiddenField ID="hduserid" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hddate" runat="server"></asp:HiddenField>
    
    </form>
</body>

</html>

