﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Spread.Web.Admin.Article.Edit" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>编辑公告</title>
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
      <span class="back"><a href="List.aspx?classId=<%=classId%>">返回列表</a></span><b>您当前的位置：首页 &gt; 公告管理 &gt; 编辑公告</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">修改公告</th>
        </tr>
        <tr>
            <td width="15%" align="right">公告标题：</td>
            <td width="85%">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" HintTitle="发布的文章标题" HintInfo="控制在100个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">公告作者：</td>
            <td>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="input w250 required" 
            maxlength="50" HintTitle="文章作者" HintInfo="控制在50个字数内，如“管理员”。">管理员</asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td align="right">所属栏目：</td>
            <td><asp:DropDownList id="ddlClassId" CssClass=" required" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">公告图片：</td>
            <td>
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input w380 left"></asp:TextBox>
                <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload"></a>
                <span class="uploading">正在上传，请稍候...</span>
            </td>
        </tr>
        <tr>
            <td align="right">公告简介：</td>
            <td>
            <asp:TextBox ID="txtForm" runat="server" CssClass="input w250"  TextMode="MultiLine" Height="100" Width="100%"
            maxlength="500" HintTitle="公告简介" HintInfo="控制在50个字数内，如“本站”。"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">公告内容：</td>
            <td>
            <FCKeditorV2:FCKeditor ID="FCKeditor" runat="server" BasePath="~/FCKedit/" Height="400px"  Width="100%" Value=""></FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td align="right">公告属性：</td>
            <td>
                <asp:CheckBoxList ID="cblItem" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">允许评论</asp:ListItem>
                    <asp:ListItem Value="1">置顶</asp:ListItem>
                    <asp:ListItem Value="1">推荐</asp:ListItem>
                    <asp:ListItem Value="1">热点</asp:ListItem>
                    <asp:ListItem Value="1">幻灯</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="right">浏览次数：</td>
            <td>
            <asp:TextBox ID="txtClick" runat="server" CssClass="input required number" size="10" 
            maxlength="10" HintTitle="文章的浏览次数" HintInfo="纯数字，本文章被阅读的次数。">0</asp:TextBox>
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