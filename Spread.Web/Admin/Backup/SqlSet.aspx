<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlSet.aspx.cs" Inherits="Spread.Web.Admin.Backup.SqlSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发布资讯</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
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
    <style type="text/css">
        .style1
        {
            height: 47px;
        }
    </style>
</head>
<body style="padding:10px;">   
    <form id="form1" runat="server"> 
    <div class="navigation">
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 查询分析器</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">查询分析器</th>
        </tr>
        <tr id="Tr1"  runat="server">
            <td align="right" class="style1">SQL结构化查询语句：</td>
            <td class="style1">
            <asp:TextBox ID="txtSql" runat="server" CssClass="textarea wh380" HintTitle="查询分析器" 
                    maxlength="250" HintInfo="注意：不懂SQL语句，请不要轻易操作此项，以免造成数据丢失！。" 
                    TextMode="MultiLine" Height="184px" Width="532px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="2" align="left">查询结果</th>
        </tr>
        <tr id="Tr2" runat="server">
            <td align="right" class="style1"></td>
            <td class="style1" style="font-size:12px;">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>
        </table>
    <div style="margin-top:10px;text-align:center;">
  <asp:Button ID="btnSave" runat="server" Text="执行SQL" CssClass="submit" onclick="btnSave_Click" 
        />
  &nbsp;
  <input name="重置" type="reset" class="submit" value="重置" />
</div>
    </form>
</body>
</html>
