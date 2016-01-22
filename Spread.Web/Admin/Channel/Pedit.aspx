<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedit.aspx.cs" Inherits="Spread.Web.Admin.Channel.Pedit" %>


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
      <span class="back"><a href="Plist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 平台渠道管理 &gt; 修改平台渠道</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">添加平台渠道信息</th>
      </tr>
       <tr>
        <td width="25%" align="right">平台：</td>
        <td width="75%">
            <asp:DropDownList ID="ddlMenu" runat="server">
            </asp:DropDownList>
        </td>
      <tr>
        <td width="25%" align="right">渠道名称：</td>
        <td width="75%">
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input required" size="30" 
            maxlength="50" HintTitle="渠道名称" HintInfo="请填写该渠道名称，至少1个字符，小于50个字符。"></asp:TextBox>
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

