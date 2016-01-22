<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardEdit.aspx.cs" Inherits="Spread.Web.Admin.Channel.CardEdit" %>
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
      <b>您当前的位置：首页 &gt; 游戏礼包管理 &gt; 增加游戏礼包</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">添加礼包信息</th>
      </tr>
      <tr>
        <td width="25%" align="right">游戏名称：</td>
        <td width="75%">
            <asp:Label ID="lbgamename" runat="server" Text=""></asp:Label>

         </td>
       </tr>
       <tr>
        <td width="25%" align="right">渠道名称：</td>
        <td width="75%">
            <asp:Label ID="lbChanelName" runat="server" Text=""></asp:Label>

         </td>
       </tr>
      <tr>
        <td width="25%" align="right">礼包名称：</td>
        <td width="75%">
          <asp:TextBox ID="txtCardName" runat="server" CssClass="input required" size="30" 
            maxlength="50" HintTitle="礼包名称" HintInfo="请填写该礼包的名称，至少1个字符，小于50个字符。"></asp:TextBox>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">礼包类型：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlCardType" runat="server">
            <asp:ListItem Value="类型一">类型一</asp:ListItem>
            <asp:ListItem Value="类型二">类型二</asp:ListItem>
            </asp:DropDownList>
         </td>
       </tr>
       
       <tr>
        <td width="25%" align="right">礼包状态：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Value="可用">可用</asp:ListItem>
            <asp:ListItem Value="不可用">不可用</asp:ListItem>
            </asp:DropDownList>
         </td>
       </tr>
       
      
     </table>
    <asp:HiddenField ID="hdID" runat="server" />
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit" />
     </div>
              
    </form>
</body>
</html>
