<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Spread.Web.Admin.Accounts.Edit" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>账号详细</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css">
    <script type="text/javascript" src="../../js/jquery-1.6.4.min.js"></script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation"><b>您当前的位置：首页 &gt; 结算管理 &gt;结算详细</b></div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">结算详细</th>
      </tr>
       <tr>
        <td width="25%" align="right">登录密码：</td>
        <td width="75%">
         <%=this.reportrModel.UserName%>
        </td>
      </tr>
      <tr>
        <td width="25%" align="right">申请时间：</td>
        <td width="75%">
         <%=this.reportrModel.ApplyTime%>
        </td>
      </tr>
      
      <tr>
        <td align="right">结算周期：</td>
        <td>
          <%=this.reportrModel.SettlementCycle%>
        </td>
      </tr>
      <tr>
        <td align="right">充值金额：</td>
        <td>  <%=this.reportrModel.Recharge%></td>
      </tr>
       <tr>
        <td align="right">收入：</td>
        <td>  <%=this.reportrModel.Income%></td>
      </tr>
      
      <tr>
        <td align="right">结算状态：</td>
        <td>
          <%=this.reportrModel.Status%>
        </td>
      </tr>
       <tr>
        <td align="right">结算金额：</td>
        <td> <asp:TextBox ID="txtIncome" runat="server"></asp:TextBox>
        </td>
      </tr>
       <tr>
        <td align="right">实际打款：</td>
        <td> <asp:TextBox ID="txtActualPlay" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td align="right"></td>
        <td>
        <asp:Button ID="btnSave" runat="server" Text="保存"  CssClass="submit"   onclick="btnSave_Click" />
        </td>
      </tr>
    </table>
    </form>
    
</body>
</html>

