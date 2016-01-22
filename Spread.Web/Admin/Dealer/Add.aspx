﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Spread.Web.Admin.Dealer.Add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发布经销商</title>
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
        KindEditor.ready(function (K) {
            var editor1 = K.create('#content1', {
                cssPath: '../../kindeditor-master/plugins/code/prettify.css',
                uploadJson: '../../kindeditor-master/asp.net/upload_json.ashx',
                fileManagerJson: '../../kindeditor-master/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
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
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 经销商管理 &gt; 发布经销商</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">发布游戏</th>
        </tr>
        <tr>
            <td align="right">经销商分类：</td>
            <td><asp:DropDownList id="ddlClassId" CssClass=" required" runat="server"></asp:DropDownList></td>
        </tr>
         <tr>
            <td align="right">经销商所属省份：</td>
            <td><asp:DropDownList id="ddlBrand" CssClass=" required" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td width="15%" align="right">经销商名称：</td>
            <td width="85%">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" HintTitle="发布的经销商名称" HintInfo="控制在100个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="right">经销商简介：</td>
            <td>
            <asp:TextBox ID="txtForm" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="经销商简介" HintInfo="控制在50个字数内，如“经销商简介”。"></asp:TextBox>
            
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
