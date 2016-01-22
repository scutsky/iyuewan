<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="theme_add.aspx.cs" Inherits="Spread.Web.Admin.about.theme_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>联系我们</title>
      <link rel="stylesheet" type="text/css" href="../images/style.css" />
</head>
 <body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="../index.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;关于我们 &gt; 联系我们 &gt;修改联系方式</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">添加联系</th>
      </tr>
      <tr>
        <td width="25%" align="right" >联系人：</td>
        <td width="75%" >
              <asp:TextBox ID="Textpeople" runat="server" CssClass="input required" size="30" ></asp:TextBox>
            </td>
       </tr>
      <tr>  
        <td width="25%" align="right">邮编：</td>
        <td width="75%">
          <asp:TextBox ID="txtEmial" runat="server" CssClass="input required" size="30" 
            maxlength="50" ></asp:TextBox>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">手机：</td>
        <td width="75%">
              <asp:TextBox ID="Textphone" runat="server" CssClass="input required" 
                size="30" ></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td width="25%" align="right">电话：</td>
         <td width="75%">
              <asp:TextBox ID="Textdianhau" runat="server" CssClass="input required" size="30" ></asp:TextBox>
          </td>
       </tr>
 
   <tr>
        <td width="25%" align="right">传真：</td>
        <td width="75%">
              <asp:TextBox ID="Textcuanzheng" runat="server" CssClass="input required" 
                size="30" ></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td width="25%" align="right">邮箱：</td>
         <td width="75%">
              <asp:TextBox ID="Textyouxiang" runat="server" CssClass="input required" size="30" ></asp:TextBox>
          </td>
       </tr>
   <tr>
        <td width="25%" align="right">地址：</td>
        <td width="75%"> 
              <asp:TextBox ID="Textaddress" runat="server" Height="72px" Width="287px"  TextMode="MultiLine" ></asp:TextBox>
           </td>
       </tr>
      
 
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="保存确定" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit"  runat="server" />
     </div>
              
    </form>
</body>
</html>
