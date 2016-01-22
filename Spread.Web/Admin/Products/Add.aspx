<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Spread.Web.Admin.Products.Add" ValidateRequest="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发布产品</title>
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
           //上传图片
        $("#btnUpload").click(function() {
            $.post("exec/UploadFile.ashx", { upfile: getPath($("#imgfile")) }, function(json) {
               //json.result为upload.ashx文件返回的值
                alert(json.result);
            },"json");
        });
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 产品管理 &gt; 添加产品</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">添加产品</th>
        </tr>
        <tr>
            <td align="right">产品名称：</td>
            <td>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="产品名称" HintInfo="控制在50个字数内，如“单品”。"></asp:TextBox>
            
            </td>
        </tr>
         <tr>
            <td align="right">计费模式：</td>
            <td>
            <asp:TextBox ID="txtBrand" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="计费模式" HintInfo="控制在50个字数内，如“CPS”。"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td align="right">录入人：</td>
            <td>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="input w250 required" 
            maxlength="50" HintTitle="管理员" HintInfo="控制在50个字数内，如“管理员”。"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td align="right">状态：</td>
            <td><asp:DropDownList id="ddlClassId" CssClass=" required" runat="server">
            <asp:ListItem Value="0">待审核</asp:ListItem>
            <asp:ListItem Value="1">推广中</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">是否顶置：</td>
            <td>
                <asp:CheckBox ID="cbIsTop" runat="server" /></td>
        </tr>
         <tr>
            <td align="right">是否隐藏：</td>
            <td><asp:CheckBox ID="cbIsLock" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">产品简介：</td>
            <td>
            <asp:TextBox ID="txtKeyword" runat="server" CssClass="input"  TextMode="MultiLine" Width="95%" Height="100px"
            maxlength="500" HintTitle="产品简介" HintInfo="控制在250个字数内"></asp:TextBox>
            </td>
        </tr>  
    </table>
    <div style="margin-top:10px;text-align:center;">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" onclick="btnSave_Click" 
        />
  &nbsp;
  <input name="重置" type="reset" class="submit" value="重置" />
</div>
    </form>
</body>
</html>
