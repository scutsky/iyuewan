<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameEdit.aspx.cs" Inherits="Spread.Web.Admin.Goods.GameEdit" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发布游戏</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <link href="../../themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Content/Javascript/LightBox/jquery.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.form.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
    <script src="../../js/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../js/jquery.ui.datepicker.js" type="text/javascript"></script>
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
      
        $(function () {
            $("#txtDate").datepicker({
                changeMonth: true,   // 允许选择月份       
                changeYear: true,   // 允许选择年份       
                dateFormat: 'yy-mm-dd',  // 设置日期格式       
                closeText: '关闭',   // 只有showButtonPanel: true才会显示出来       
                duration: 'fast',
                showAnim: 'fadeIn',
                onSelect: function (dateText, inst) {
                    $("#txtDate").blur();
                }

            });
    
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="GameList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 游戏管理 &gt; 发布游戏</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">发布游戏</th>
        </tr>
        <tr>
            <td width="15%" align="right">游戏名称：</td>
            <td width="85%">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" HintTitle="发布的游戏标题" HintInfo="控制在100个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>       
        <tr>
            <td align="right">版本号：</td>
            <td>
            <asp:TextBox ID="txtVersion" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="版本号" HintInfo="控制在50个字数内，如“版本号”。"></asp:TextBox>
            
            </td>
        </tr>
         <tr>
            <td align="right">游戏平台：</td>
            <td>            
                <asp:DropDownList ID="ddlPlatform" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td align="right">上架时间：</td>
            <td> <asp:TextBox ID="txtDate" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="上架时间" HintInfo="控制为时间类型，如“2015-01-01”。"></asp:TextBox> </td>
        </tr> 
        <tr>
            <td align="right">游戏首字母：</td>
            <td>            
                <asp:DropDownList ID="ddlFirstLetter" runat="server">
                 <asp:ListItem Value="">请选择</asp:ListItem>
                 <asp:ListItem Value="A-E">A-E</asp:ListItem>
                 <asp:ListItem Value="F-J">F-J</asp:ListItem>
                 <asp:ListItem Value="K-O">K-O</asp:ListItem>
                 <asp:ListItem Value="P-T">P-T</asp:ListItem>
                 <asp:ListItem Value="U-Z">U-Z</asp:ListItem>
                 <asp:ListItem Value="其他"> 其他</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">游戏基础资料：</td>
            <td> <asp:FileUpload ID="file1" runat="server" />
             <asp:Label ID="lbFile1" runat="server"></asp:Label>   
            </td>
        </tr>
       <tr>
            <td align="right">游戏大事件资料：</td>
            <td> <asp:FileUpload ID="file2" runat="server" />
            <asp:Label ID="lbFile2" runat="server"></asp:Label>
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


