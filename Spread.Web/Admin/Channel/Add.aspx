﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Spread.Web.Admin.Channel.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加栏目</title>
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
      <span class="back"><a href="list.aspx?kindId=<%=kindId %>">返回列表</a></span><b>您当前的位置：首页 &gt; 类别管理 &gt; 增加类别</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">添加类别信息</th>
      </tr>
      <tr>
        <td width="25%" align="right">所属父类别：</td>
        <td width="75%">
            <asp:Label ID="lblPid" runat="server" Text="0"></asp:Label><asp:Label ID="lblPname" runat="server"></asp:Label>
          </td>
       </tr>
      <tr>
        <td width="25%" align="right">类别名称：</td>
        <td width="75%">
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input required" size="30" 
            maxlength="50" HintTitle="类别名称" HintInfo="请填写该类别的名称，至少1个字符，小于50个字符。"></asp:TextBox>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">管理导航：</td>
        <td width="75%">
          <asp:TextBox ID="txtPageUrl" runat="server" CssClass="input required" size="30" 
            maxlength="250" HintTitle="类别管理导航" HintInfo="请填写该类别的导航路径，至少1个字符，小于250个字符。如：/Admin/Products/List.aspx"></asp:TextBox>
        </td>
       </tr>
       
       <tr>
         <td width="25%" align="right">优先级别：</td>
         <td width="75%">
            <asp:TextBox ID="txtClassOrder" CssClass="input required number" size="10" runat="server" maxlength="9" HintTitle="类别分类优先级别" HintInfo="请填写该类别的名称，至少1个字符，小于50个字符。"></asp:TextBox>
         </td>
       </tr>
       <tr>
         <td width="25%" align="right">摘要：</td>
         <td width="75%">
            <asp:TextBox ID="txtZhaiyao" CssClass="input required" size="30"  runat="server" maxlength="50" HintTitle="类别摘要" HintInfo="请填写该类别的名称，至少1个字符，小于50个字符。"></asp:TextBox>
         </td>
       </tr>
       <tr>
         <td width="25%" align="right">关键字：</td>
         <td width="75%">
            <asp:TextBox ID="txtKeyword" CssClass="input required" size="30"  runat="server" maxlength="50" HintTitle="类别关键字" HintInfo="纯数字，数字越少越向前。"></asp:TextBox>
         </td>
       </tr>
       <tr>
         <td width="25%" align="right">品牌LOGO：</td>
         <td width="75%">
            <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input w380 left"></asp:TextBox>
                <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" /></a>
                <span class="uploading">正在上传，请稍候...</span>
         </td>
       </tr>
       <tr>
         <td width="25%" align="right">品牌图片：</td>
         <td width="75%">
            <asp:TextBox ID="txtImgUrl2" runat="server" CssClass="input w380 left"></asp:TextBox>
                <a href="javascript:void(0);" class="files2"><input type="file" id="FileUpload2" name="FileUpload2" /></a>
                <span class="uploading2">正在上传，请稍候...</span>
         </td>
       </tr>
       <tr  width="75%">
            <td width="25%" align="right">属性：</td>
            <td>
                <asp:CheckBoxList ID="cblItem" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">  
                    <asp:ListItem Value="1">置顶</asp:ListItem>
                </asp:CheckBoxList>
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