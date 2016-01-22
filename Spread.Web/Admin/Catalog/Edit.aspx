<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Edit.aspx.cs" Inherits="Spread.Web.Admin.Catalog.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改游戏分类</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script type="text/javascript">
        $(function() {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                success: function(label) {
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
            <span class="back"><a href="list.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 游戏分类管理 &gt; 增加游戏分类</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">修改游戏分类信息</th>
      </tr>
      <tr>
        <td width="25%" align="right">所属父游戏分类：</td>
        <td width="75%">
            <asp:Label ID="lblPid" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblPname" runat="server"></asp:Label>
          </td>
       </tr>
      <tr>
        <td width="25%" align="right">游戏分类名称：</td>
        <td width="75%">
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input required" size="30" 
            maxlength="50" HintTitle="游戏分类名称" HintInfo="请填写该游戏分类的名称，至少1个字符，小于50个字符。"></asp:TextBox>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">映射分类编号：</td>
        <td width="75%">
          <asp:TextBox ID="lblCatalodId" runat="server" CssClass="input required number" size="30" 
            maxlength="30" HintTitle="映射分类编号" HintInfo="请填写该游戏映射分类的编号，必须全数字。"></asp:TextBox>
        </td>
       </tr>
       <tr>
         <td width="25%" align="right">优先级别：</td>
         <td width="75%">
            <asp:TextBox ID="txtClassOrder" CssClass="input required number" size="10" runat="server" maxlength="9" HintTitle="游戏分类分类优先级别" HintInfo="纯数字，数字越少越向前。"></asp:TextBox>
         </td>
       </tr>
       <tr>
            <td align="right">分类属性：</td>
            <td>
                <asp:CheckBoxList ID="cblItem" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">是否展示</asp:ListItem>
                    <asp:ListItem Value="1">是否菜单</asp:ListItem>
                    <asp:ListItem Value="1">是否锁定</asp:ListItem>
                </asp:CheckBoxList>
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