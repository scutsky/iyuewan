<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportSetEdit.aspx.cs" Inherits="Spread.Web.Admin.statistics.ReportSetEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>添加栏目</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
   <script type="text/javascript" src="../../Content/Javascript/LightBox/jquery.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.form.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="ReportSetList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 报表设置管理 &gt; 修改报表设置</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">添加报表设置信息</th>
      </tr>  
      <tr>
         <td width="25%" align="right">Sheet名称：</td>
        <td width="75%">
          <asp:Label ID="lbSheet" runat="server" Text="Sheet1"></asp:Label>
        </td>
       </tr>    
      <tr>
        <td width="25%" align="right">平台：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlMenu" runat="server">
            </asp:DropDownList>
        </td>
         
        <tr>
        <td width="25%" align="right">统计日期列：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlSumDate" runat="server">
            <asp:ListItem Value="0">第一列</asp:ListItem>
            <asp:ListItem Value="1">第二列</asp:ListItem>
            <asp:ListItem Value="2">第三列</asp:ListItem>
            <asp:ListItem Value="3">第四列</asp:ListItem>
            <asp:ListItem Value="4">第五列</asp:ListItem>
            <asp:ListItem Value="5">第六列</asp:ListItem>
            <asp:ListItem Value="6">第七列</asp:ListItem>
            <asp:ListItem Value="7">第八列</asp:ListItem>
            <asp:ListItem Value="8">第九列</asp:ListItem>
            <asp:ListItem Value="9">第十列</asp:ListItem>
            <asp:ListItem Value="10">第十一列</asp:ListItem>
            <asp:ListItem Value="11">第十二列</asp:ListItem>
            <asp:ListItem Value="12">第十三列</asp:ListItem>
            <asp:ListItem Value="13">第十四列</asp:ListItem>
            <asp:ListItem Value="14">第十五列</asp:ListItem>
            </asp:DropDownList>
        </td>
       </tr>
        <tr>
        <td width="25%" align="right">渠道名称列：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlChannelName" runat="server">
            <asp:ListItem Value="0">第一列</asp:ListItem>
            <asp:ListItem Value="1">第二列</asp:ListItem>
            <asp:ListItem Value="2">第三列</asp:ListItem>
            <asp:ListItem Value="3">第四列</asp:ListItem>
            <asp:ListItem Value="4">第五列</asp:ListItem>
            <asp:ListItem Value="5">第六列</asp:ListItem>
            <asp:ListItem Value="6">第七列</asp:ListItem>
            <asp:ListItem Value="7">第八列</asp:ListItem>
            <asp:ListItem Value="8">第九列</asp:ListItem>
            <asp:ListItem Value="9">第十列</asp:ListItem>
            <asp:ListItem Value="10">第十一列</asp:ListItem>
            <asp:ListItem Value="11">第十二列</asp:ListItem>
            <asp:ListItem Value="12">第十三列</asp:ListItem>
            <asp:ListItem Value="13">第十四列</asp:ListItem>
            <asp:ListItem Value="14">第十五列</asp:ListItem>
            </asp:DropDownList>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">游戏名称列：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlGameName" runat="server">
            <asp:ListItem Value="0">第一列</asp:ListItem>
            <asp:ListItem Value="1">第二列</asp:ListItem>
            <asp:ListItem Value="2">第三列</asp:ListItem>
            <asp:ListItem Value="3">第四列</asp:ListItem>
            <asp:ListItem Value="4">第五列</asp:ListItem>
            <asp:ListItem Value="5">第六列</asp:ListItem>
            <asp:ListItem Value="6">第七列</asp:ListItem>
            <asp:ListItem Value="7">第八列</asp:ListItem>
            <asp:ListItem Value="8">第九列</asp:ListItem>
            <asp:ListItem Value="9">第十列</asp:ListItem>
            <asp:ListItem Value="10">第十一列</asp:ListItem>
            <asp:ListItem Value="11">第十二列</asp:ListItem>
            <asp:ListItem Value="12">第十三列</asp:ListItem>
            <asp:ListItem Value="13">第十四列</asp:ListItem>
            <asp:ListItem Value="14">第十五列</asp:ListItem>
            </asp:DropDownList>
        </td>
       </tr>
        <tr>
        <td width="25%" align="right">注册值列：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlRegisterValue" runat="server">
            <asp:ListItem Value="0">第一列</asp:ListItem>
            <asp:ListItem Value="1">第二列</asp:ListItem>
            <asp:ListItem Value="2">第三列</asp:ListItem>
            <asp:ListItem Value="3">第四列</asp:ListItem>
            <asp:ListItem Value="4">第五列</asp:ListItem>
            <asp:ListItem Value="5">第六列</asp:ListItem>
            <asp:ListItem Value="6">第七列</asp:ListItem>
            <asp:ListItem Value="7">第八列</asp:ListItem>
            <asp:ListItem Value="8">第九列</asp:ListItem>
            <asp:ListItem Value="9">第十列</asp:ListItem>
            <asp:ListItem Value="10">第十一列</asp:ListItem>
            <asp:ListItem Value="11">第十二列</asp:ListItem>
            <asp:ListItem Value="12">第十三列</asp:ListItem>
            <asp:ListItem Value="13">第十四列</asp:ListItem>
            <asp:ListItem Value="14">第十五列</asp:ListItem>
            </asp:DropDownList>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">消费值列：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlConsumptionValue" runat="server">
            <asp:ListItem Value="0">第一列</asp:ListItem>
            <asp:ListItem Value="1">第二列</asp:ListItem>
            <asp:ListItem Value="2">第三列</asp:ListItem>
            <asp:ListItem Value="3">第四列</asp:ListItem>
            <asp:ListItem Value="4">第五列</asp:ListItem>
            <asp:ListItem Value="5">第六列</asp:ListItem>
            <asp:ListItem Value="6">第七列</asp:ListItem>
            <asp:ListItem Value="7">第八列</asp:ListItem>
            <asp:ListItem Value="8">第九列</asp:ListItem>
            <asp:ListItem Value="9">第十列</asp:ListItem>
            <asp:ListItem Value="10">第十一列</asp:ListItem>
            <asp:ListItem Value="11">第十二列</asp:ListItem>
            <asp:ListItem Value="12">第十三列</asp:ListItem>
            <asp:ListItem Value="13">第十四列</asp:ListItem>
            <asp:ListItem Value="14">第十五列</asp:ListItem>
            </asp:DropDownList>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">收入列：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlIncome" runat="server">
            <asp:ListItem Value="0">第一列</asp:ListItem>
            <asp:ListItem Value="1">第二列</asp:ListItem>
            <asp:ListItem Value="2">第三列</asp:ListItem>
            <asp:ListItem Value="3">第四列</asp:ListItem>
            <asp:ListItem Value="4">第五列</asp:ListItem>
            <asp:ListItem Value="5">第六列</asp:ListItem>
            <asp:ListItem Value="6">第七列</asp:ListItem>
            <asp:ListItem Value="7">第八列</asp:ListItem>
            <asp:ListItem Value="8">第九列</asp:ListItem>
            <asp:ListItem Value="9">第十列</asp:ListItem>
            <asp:ListItem Value="10">第十一列</asp:ListItem>
            <asp:ListItem Value="11">第十二列</asp:ListItem>
            <asp:ListItem Value="12">第十三列</asp:ListItem>
            <asp:ListItem Value="13">第十四列</asp:ListItem>
            <asp:ListItem Value="14">第十五列</asp:ListItem>
            </asp:DropDownList>
        </td>
       </tr>
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit" />
     </div>
    </form>
</body>
</html>

