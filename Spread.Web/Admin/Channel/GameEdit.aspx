<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameEdit.aspx.cs" Inherits="Spread.Web.Admin.Channel.GameEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改类别</title>
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
            <b>您当前的位置：首页 &gt; 渠道管理 &gt; 推广游戏修改</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">修改类别信息</th>
      </tr>
      <tr>
        <td width="25%" align="right">渠道名称：</td>
        <td width="75%">
            <asp:Label ID="lbChanel" runat="server" Text=""></asp:Label>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">推广游戏：</td>
        <td width="75%">
         <asp:Label ID="lbGameName" runat="server" Text=""></asp:Label>
        </td>
       </tr>
       <tr>
         <td width="25%" align="right">平台：</td>
         <td width="75%">
            <asp:DropDownList ID="ddlMenu" runat="server" Width="120px" AutoPostBack="True" 
                 onselectedindexchanged="ddlMenu_SelectedIndexChanged" >
           </asp:DropDownList>
           </td>
       </tr>
        <tr>
         <td width="25%" align="right">平台渠道：</td>
         <td width="75%">
            <asp:DropDownList ID="ddlChanel" runat="server" Width="120px">
           </asp:DropDownList>
           </td>
       </tr>
        <tr>
         <td width="25%" align="right">平台游戏：</td>
         <td width="75%">
            <asp:DropDownList ID="ddlGame" runat="server" Width="120px">
           </asp:DropDownList>
           </td>
       </tr>
        <tr>
         <td width="25%" align="right">分成比例：</td>
         <td width="75%">
           <asp:TextBox ID="txtScale" runat="server" Height="19px" Width="120px" ></asp:TextBox>%
           </td>
       </tr>
       <tr>
         <td width="25%" align="right">推广包状态：</td>
         <td width="75%">
            <asp:DropDownList ID="ddlStatus" runat="server" Width="120px">
            <asp:ListItem Value="正在打包">正在打包</asp:ListItem>
            <asp:ListItem Value="打包完成">打包完成</asp:ListItem>
           </asp:DropDownList>
           </td>
       </tr>
       
       <tr>
         <td width="25%" align="right">更新类型：</td>
         <td width="75%">
             <asp:DropDownList ID="ddlUpdateType" runat="server" Width="120px">
            <asp:ListItem Value="N/A">N/A</asp:ListItem>
            <asp:ListItem Value="无">无</asp:ListItem>
            <asp:ListItem Value="非强制更新">非强制更新</asp:ListItem>
             <asp:ListItem Value="强制更新">强制更新</asp:ListItem>
           </asp:DropDownList>
            </td>
       </tr>
        <tr>
         <td width="25%" align="right">版本号：</td>
         <td width="75%">
            <asp:TextBox ID="txtVersion" runat="server" Width="120px" ></asp:TextBox>
           </td>
       </tr>
        <tr>
        <td width="25%" align="right">包链接：</td>
        <td width="75%">
            <asp:TextBox ID="txtBak1" runat="server" TextMode="MultiLine" Width="95%" Height="60"></asp:TextBox>
        </td>
       </tr>
      
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" onclick="btnSave_Click" />
            &nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit" />
     </div>
              
    </form>
</body>
</html>
