<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMatch.aspx.cs" Inherits="Spread.Web.Admin.statistics.ReportMatch" %>

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
      <span class="back"><a href="ReportSetList.aspx?Num=<%=Num %>">返回列表</a></span><b>您当前的位置：首页 &gt; 报表管理 &gt; 报表匹配</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">报表匹配信息</th>
      </tr>  
      <tr>
         <td width="25%" align="right">统计日期：</td>
        <td width="75%">
          <asp:Label ID="lbSumDate" runat="server" Text=""></asp:Label>
        </td>
       </tr>    
      <tr>
        <td width="25%" align="right">渠道名称：</td>
        <td width="75%">
           <asp:Label ID="lbChannelName" runat="server" Text=""></asp:Label>
        </td>
        </tr>
        <tr>
        <td width="25%" align="right">游戏名称：</td>
        <td width="75%">
           <asp:Label ID="lbGameName" runat="server" Text=""></asp:Label>
        </td>
        </tr>
        <tr>
            <td width="25%" align="right">注册值：</td>
            <td width="75%">
               <asp:Label ID="lbRegisterValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
          <tr>
            <td width="25%" align="right">消费值：</td>
            <td width="75%">
               <asp:Label ID="lbConsumptionValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td width="25%" align="right">收入：</td>
            <td width="75%">
               <asp:Label ID="lbIncome" runat="server" Text=""></asp:Label>
            </td>
        </tr>
          <tr>
            <td width="25%" align="right">分成比例：</td>
            <td width="75%">
               <asp:Label ID="lbScale" runat="server" Text=""></asp:Label>
            </td>
        </tr>
     </table>
      <div class="spClear" 
        style=" height:24px; line-height:24px; background:#F6F5FF; margin-bottom: 0px;">
        <table>
        <tr>
        <td width="95%">匹配推广数据</td>
        <td width="5%" ><asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" /></td></tr>
        </table>
        
            
     
        </div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand" >
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">编号</th>
        <th width="12%">推广游戏</th>
        <th width="12%">平台游戏</th>
        <th width="12%">平台渠道</th>
        <th width="12%">所属账户</th>
        <th width="12%">分成比例</th>
        <th width="12%">推广包状态</th>
        <th width="8%">操作</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center" ><%#Eval("Id")%><asp:HiddenField ID="lb_id" runat="server" Value='<%#Eval("Id")%>' /></td>
        <td align="center"><%#Eval("ID")%></td>
        <td align="center"><%#Eval("Bak4")%></td>
        <td align="center"><%#Eval("Bak3")%></td>
        <td align="center"><%#Eval("Bak3")%></td>
        <td align="center"><%#Eval("Status")%></td>
        <td align="center"><%#Eval("SumDate")%></td>
        <td align="center">
        <span><a href="#">选定</a></span>
         </td>
      </tr>
          
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>

    <div class="spClear"></div>

     
    </form>
</body>
</html>


