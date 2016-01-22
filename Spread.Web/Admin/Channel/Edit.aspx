<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Spread.Web.Admin.Channel.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改类别</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
   <script type="text/javascript" src="../../Content/Javascript/LightBox/jquery.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.form.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
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
            <b>您当前的位置：首页 &gt; 渠道管理 &gt; 编辑渠道</b>
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
        <td width="25%" align="right">推广产品：</td>
        <td width="75%">
         <asp:Label ID="lbProducts" runat="server" Text=""></asp:Label>
        </td>
       </tr>
       <tr>
         <td width="25%" align="right">备注：</td>
         <td width="75%">
            <asp:Label ID="lbBak1" runat="server" Text=""></asp:Label>
            </td>
       </tr>
       <tr>
         <td width="25%" align="right">所属账户：</td>
         <td width="75%">
            <asp:Label ID="lbUser" runat="server" Text=""></asp:Label></td>
       </tr>
       <tr>
         <td width="25%" align="right">状态：</td>
         <td width="75%">
          <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Value="1">待审核</asp:ListItem>
            <asp:ListItem Value="2">审核不通过</asp:ListItem>
            <asp:ListItem Value="5">推广中</asp:ListItem>
           </asp:DropDownList>
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