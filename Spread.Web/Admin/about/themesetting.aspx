<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="themesetting.aspx.cs" Inherits="Spread.Web.Admin.about.themesetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
            //显示关闭高级选项
            $("#upordown").toggle(function() {
                $(this).text("关闭高级选项");
                $(this).removeClass();
                $(this).addClass("up-01");
                $(".upordown").show();
            }, function() {
                $(this).text("显示高级选项");
                $(this).removeClass();
                $(this).addClass("up-02");
                $(".upordown").hide();
            });
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="../index.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;关于我们 &gt; 联系我们 &gt;修改联系方式</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">修改联系方式</th>
      </tr>
      <tr>
        <td width="25%" align="right" >联系人：</td>
        <td width="75%" >
              <asp:TextBox ID="Textpeople" runat="server" CssClass="input required" size="30" maxlength="50" minlength="3" HintTitle="修改联系姓名" HintInfo="控制在10个字以内"></asp:TextBox>
            </td>
       </tr>
      <tr>
        <td width="25%" align="right">邮编：</td>
        <td width="75%">
          <asp:TextBox ID="txtEmial" runat="server" CssClass="input required" size="30" 
           maxlength="50" minlength="3" HintTitle="修改邮编" HintInfo="请输入正确邮编,如：655500" ></asp:TextBox>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">手机：</td>
        <td width="75%">
              <asp:TextBox ID="Textphone" runat="server" CssClass="input required" 
                size="30" maxlength="50" minlength="3" HintTitle="修改手机号码" HintInfo="控制在11个字以内"></asp:TextBox>
           </td>
       </tr>
       <tr>
         <td width="25%" align="right">电话：</td>
         <td width="75%">
              <asp:TextBox ID="Textdianhau" runat="server" CssClass="input required" size="30" maxlength="50" minlength="3" HintTitle="修改电话号码" HintInfo="控制在11个字以内"></asp:TextBox>
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
              <asp:TextBox ID="Textyouxiang" runat="server" CssClass="input required" size="30" maxlength="50"  email="#Textyouxiang" minlength="3" HintTitle="修改邮箱" HintInfo="请输入正确格式的电子邮件"></asp:TextBox>
          </td>
       </tr>
   <tr>
        <td width="25%" align="right">地址：</td>
        <td width="75%"> 
              <asp:TextBox ID="Textaddress" runat="server" Height="72px" Width="287px"  TextMode="MultiLine" CssClass="input required" size="30" maxlength="50" minlength="3" HintTitle="修改地址" HintInfo="控制在50个字以内"></asp:TextBox>
           </td>
       </tr>
      
 
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="修改保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit"  runat="server"/>
     </div>
              
    </form>
</body>
</html>
