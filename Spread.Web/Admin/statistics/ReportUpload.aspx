<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportUpload.aspx.cs" Inherits="Spread.Web.Admin.statistics.ReportUpload" %>

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
    <div class="navigation"><b>您当前的位置：首页 &gt; 数据统计 &gt; 统计列表</b></div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="5%" align="center">平台：</td>
        <td width="10%">
            <asp:DropDownList ID="ddlMenu" runat="server" CssClass="select"  > </asp:DropDownList>&nbsp;
        </td>
        <td width="10%"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
        <td width="20%" align="center">
            <asp:Button ID="btnImport" runat="server" Text="导入" CssClass="submit" onclick="btnImport_Click" />
        </td>
        </tr>
    </table>
    <div class="spClear"></div>
   <asp:Repeater ID="rptList" runat="server" >
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">编号</th>
        <th width="12%">验证结果</th>
        <th width="12%">统计日期</th>
        <th width="12%">渠道名称</th>
        <th width="12%">游戏名称</th>
        <th width="12%">注册值</th>
        <th width="12%">消费值</th>
        <th width="12%">收入</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center"><%#Eval("Id")%></td>
        <td align="center"><%#Eval("Bak3").ToString() == "匹配失败" ? "<span style=\"color:red;\">匹配失败</span>" : "<span style=\"color:#7AB5E6;\">" + Eval("Bak3") + "</span>"%></td>
        <td align="center"><%#Eval("SumDate")%></td>
        <td align="center">[<%#Eval("ChannelID")%>]<%#Eval("ChannelName")%></td>
        <td align="center"><%#Eval("GameName")%></td>
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
    <asp:HiddenField ID="hdNum" runat="server"></asp:HiddenField>
    </form>
</body>


</html>


