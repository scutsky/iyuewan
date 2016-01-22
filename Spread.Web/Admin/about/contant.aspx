<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contant.aspx.cs" Inherits="Spread.Web.Admin.about.contant" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>公司信息</title>
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
      <span class="back"><a href="../index.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;关于我们 &gt; 市场信息 &gt;修改市场信息</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">修改市场信息</th>
      </tr>
      <tr>
        <td width="25%" align="right" >市场名称：</td>
        <td width="75%" >
             
                <asp:TextBox ID="TextName" runat="server" CssClass="input required" size="25" 
            maxlength="50" minlength="3" HintTitle="修改市场名称" HintInfo="控制在20个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
       </tr>
      <tr>
        <td width="25%" align="right">副标题：</td>
        <td width="75%">
          <asp:TextBox ID="txtaddres" runat="server" CssClass="input required" size="30" 
            maxlength="50"   minlength="3" HintTitle="修改市场地址" HintInfo="请输入市场地址" ></asp:TextBox>
        </td>
       </tr>
       <tr>
        <td width="25%" align="right">市场图片：</td>
        <td width="75%">
             <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input w250 left" maxlength="250"></asp:TextBox>
           <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" /></a>
          <span class="uploading">正在上传，请稍候...</span>
        </td>
       </tr>
       <tr>
         <td width="25%" align="right">市场简介：</td>
         <td width="75%">
           
           <FCKeditorV2:FCKeditor ID="FCKeditor" runat="server" BasePath="~/FCKedit/" Height="400px"  Width="100%" Value=""></FCKeditorV2:FCKeditor>
         </td>
       </tr>
 
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click"  />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit"  runat="server"/>
     </div>
              
    </form>
</body>
</html>
