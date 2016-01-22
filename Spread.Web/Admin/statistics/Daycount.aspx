<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Daycount.aspx.cs" Inherits="Spread.Web.Admin.statistics.Daycount" %>
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
        
        $(function() {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
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
    <div style=" display:none">
    <asp:FileUpload ID="FileUpload1" runat="server" Visible=false />
     <asp:Button ID="btnImport" runat="server" Text="导入" CssClass="submit" onclick="btnImport_Click"  Visible=false
              />
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="10%" align="center">渠道：</td>
        <td width="15%">
            <asp:DropDownList ID="ddlChanel" runat="server" CssClass="select"  > </asp:DropDownList>&nbsp;
        </td>
        <td width="8%" align="center">推广游戏：</td>
        <td width="10%"><asp:TextBox ID="txtGameName" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="5%" align="right">时间：</td>
        <td width="10%"><asp:TextBox ID="txtDate1" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="20%"><asp:TextBox ID="txtDate2" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="10%"></td>
        <td width="10%" align="center">
           
            <asp:Button ID="btnSelect" runat="server" Text="查询"  CssClass="submit" onclick="btnSelect_Click" />
        </td>
        </tr>
    </table>
    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="10%">日期</th>
        <th align="left">注册用户</th>
        <th width="13%">充值金额</th>
        <th width="13%">收入</th>
        <th width="16%">报表详细</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center"><%#Eval("SumDate")%></td>
        <td><%#Eval("num")%></td>
        <td align="center"><%#Eval("ConsumptionValue")%></td>
        <td align="center"><%#Eval("Income")%></td>
        <td align="center">
        <span><a href="DaycountDetail.aspx?userid=<%=userid%>&date=<%#Eval("SumDate")%>">查看数据</a></span>
        </td>
      </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>

    <div class="spClear"></div>
    <asp:HiddenField ID="hduserid" runat="server"></asp:HiddenField>
    </form>
</body>

<script language="javascript" type="text/javascript">
    $(function () {
        $("#txtDate1").datepicker({
            changeMonth: true,   // 允许选择月份       
            changeYear: true,   // 允许选择年份       
            dateFormat: 'yy-mm-dd',  // 设置日期格式       
            closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
            duration: 'fast',
            showAnim: 'fadeIn',
            onSelect: function (dateText, inst) {
                $("#txtDate1").blur();
            }

        });
        $("#txtDate2").datepicker({
            changeMonth: true,   // 允许选择月份       
            changeYear: true,   // 允许选择年份       
            dateFormat: 'yy-mm-dd',  // 设置日期格式       
            closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
            duration: 'fast',
            showAnim: 'fadeIn',
            onSelect: function (dateText, inst) {
                $("#txtDate2").blur();
            }

        });
    });
    </script>
</html>

