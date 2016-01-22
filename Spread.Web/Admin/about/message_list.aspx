<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message_list.aspx.cs" Inherits="Spread.Web.Admin.about.message_list" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>留言信息管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
          
           <b>您当前的位置：首页 >关于我们 >留言信息 
              
           </b>
        </div>   
        <div style="padding-bottom:10px;"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">留言主题</th>
                        <th align="left">姓名</th>
                        <th width="100">邮箱</th>
                        <th width="80">地址</th>
                        <th width="90">邮编</th>
                        <th width="90">省份</th>
                        <th width="90">城市</th>
                        <th width="90">电话</th>
                        <th width="90">传真</th>
                        <th width="150">问题</th>
                        
                        <th width="120">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                        <asp:HiddenField ID="txtId" runat="server" Value='<%#Eval("Id") %>' />
                        <%# Eval("Subject")%></td>
                        <td><%# Eval("FullName")%></td>
                        <td><%# Eval("Mail")%></td>
                        <td><%# Eval("Address")%></td>
                        <td><%# Eval("ZipCode")%></td>
                        <td><%# Eval("Province")%></td>
                        <td><%# Eval("City")%></td>
                        <td><%# Eval("Phone")%></td>
                        <td><%# Eval("Fax")%></td>
                        <td ><%# Eval("Question")%></td>
                        <td align="center">
                            <span><asp:LinkButton ID="lbDel" CommandName="btndel" runat="server" OnClientClick="return confirm( '该操作会删除留言，确定要删除吗？ ');">删除</asp:LinkButton></span>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
 
    </form>
</body>
</html>
