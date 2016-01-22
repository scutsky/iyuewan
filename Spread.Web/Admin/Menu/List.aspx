<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Spread.Web.Admin.Menu.List" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>商品分类管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript">
        $(function() {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
           <span class="add"><a href="Add.aspx">增加平台分类</a></span>
           <b>产品分类：<a  href="List.aspx?pid=0">所有分类</a> 
               <%
                   if (this.MenuPath != null && this.MenuPath.Rows.Count > 0)
                    {
                        foreach (DataRow  dr in this.MenuPath.Rows)
                        {
                                %> &gt; <a  href="List.aspx?pid=<%=dr["Id"].ToString() %>"><%=dr["Title"].ToString()%></a><% 
                        }
                    }
                %>
           </b>
        </div>   
        <div style="padding-bottom:10px;"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th align="left">平台分类名称</th>
                        <th width="120">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                          <%# Eval("ID") %>
                        </td>
                        <td>
                           <%# Eval("Title")%>
                        </td>
                        <td align="left">
                            <span><a href="Edit.aspx?classId=<%# Eval("Id") %>">修改</a></span>
                            <span><asp:LinkButton ID="lbDel" CommandName="btndel" runat="server" OnClientClick="return confirm( '该操作会删除本商品分类和下属商品分类，确定要删除吗？ ');">删除</asp:LinkButton></span>
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
