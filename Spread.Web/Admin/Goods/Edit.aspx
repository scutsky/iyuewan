﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Spread.Web.Admin.Goods.Edit" ValidateRequest="false" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>编辑游戏</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
     <script type="text/javascript" src="../../Content/Javascript/LightBox/jquery.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.form.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
    
     <link rel="stylesheet" href="../../kindeditor-master/themes/default/default.css" />
	<link rel="stylesheet" href="../../kindeditor-master/plugins/code/prettify.css" />
	<script charset="utf-8" src="../../kindeditor-master/kindeditor.js"></script>
	<script charset="utf-8" src="../../kindeditor-master/lang/zh_CN.js"></script>
	<script charset="utf-8" src="../../kindeditor-master/plugins/code/prettify.js"></script>
	
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

        KindEditor.ready(function(K) {
            var editor1 = K.create('#content1', {
                cssPath: '../../kindeditor-master/plugins/code/prettify.css',
                uploadJson: '../../kindeditor-master/asp.net/upload_json.ashx',
                fileManagerJson: '../../kindeditor-master/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function() {
                    var self = this;
                    K.ctrl(document, 13, function() {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function() {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 热门游戏管理 &gt; 发布热门游戏</b>
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
            <td align="right">游戏简介：</td>
            <td>
            <asp:TextBox ID="txtForm" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="游戏简介" HintInfo="控制在50个字数内，如“本站”。"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td width="15%" align="right">其他备注：</td>
            <td width="85%">
            <asp:TextBox ID="txtBak5" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" HintTitle="其他备注" HintInfo="控制在100个字数内。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">游戏属性：</td>
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
            <td align="right">游戏图片：</td>
            <td>
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input w380 left"></asp:TextBox>
                <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" /></a>
                <span class="uploading">正在上传，请稍候...</span>
            </td>
        </tr>
         <tr>
            <td align="right" valign="top">游戏内容：</td>
            <td>
             <textarea id="content1" cols="100" rows="8" style="width:100%;height:300px;visibility:hidden;" runat="server"></textarea>
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
