<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Spread.Web.Admin.Keyword.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>关键字列表</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
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
        $(function() {
            $("#cbIsImage").bind("click",function(){
                if($(this).attr("checked") == true) {
                    $(".upordown").show();
                }else{
                    $(".upordown").hide();
                }
            });
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 扩展功能 &gt; 关键字列表</b>
    </div>
    <div style="padding-bottom:10px;">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">增加关键字</th>
        </tr>
        <tr>
            <td width="15%" align="right">关键字：</td>
            <td width="85%">
            <asp:TextBox ID="txtName" runat="server" CssClass="input required" size="30" 
            maxlength="100" minlength="1" HintTitle="关键字" HintInfo="控制在100个字符内，尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">所属类别：</td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" CssClass="required">
                </asp:DropDownList>
            </td>
        </tr>
     <%--   <tr>
            <td align="right">所属模型：</td>
            <td>
                <asp:DropDownList ID="ddlModel" runat="server" CssClass="required">
                </asp:DropDownList>
            </td>
        </tr>--%>
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
