<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Spread.Web.Admin.Catalog.List" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>游戏分类管理</title>
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
           <span class="add"><a href="Add.aspx">增加顶级游戏分类</a></span>
           <b>产品分类：<a  href="List.aspx?pid=0">所有分类</a> 
               <%
                   if (this.CatalogPath != null && this.CatalogPath.Rows.Count > 0)
                    {
                        foreach (DataRow  dr in this.CatalogPath.Rows)
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
                        <th align="left">游戏分类名称</th>
                        <th align="center"  width="100">映射分类编号</th>
                        <th width="80">属性</th>
                        <th width="90">优先级别</th>
                        <th width="120">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                          <asp:HiddenField ID="txtClassId" runat="server" Value='<%#Eval("Id") %>' />
                          <asp:HiddenField ID="txtClassLayer" runat="server" Value='<%#Eval("ClassLayer") %>' />
                          <%# Eval("ID") %>
                        </td>
                        <td>
                          <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                          <%# getSubLink(Eval("ID"), Eval("Title"), Eval("ClassLayer"))%>
                        </td>
                        <td>
                          <%# Eval("CatalogID") %>
                        </td>
                        <td>
                          <asp:ImageButton ID="ibtnShow" CommandName="ibtnShow" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsShow")) == 1 ? "../Images/ico-2.png" : "../Images/ico-2_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsShow")) == 1 ? "取消展示" : "设置展示"%>' />
                          <asp:ImageButton ID="ibtnMenu" CommandName="ibtnMenu" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsMenu")) == 1 ? "../Images/ico-1.png" : "../Images/ico-1_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsMenu")) == 1 ? "取消菜单" : "设置菜单"%>' />
                          <asp:ImageButton ID="ibtnLock" CommandName="ibtnLock" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsLock")) == 1 ? "../Images/ico-3.png" : "../Images/ico-3_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsLock")) == 1 ? "取消锁定" : "设置锁定"%>' />
                          </td>
                        <td align="center"><%# Eval("ClassOrder") %></td>
                        <td align="left">
                            <span><a href="Add.aspx?classId=<%# Eval("Id") %>">添加子类</a></span>
                            <span><a href="Edit.aspx?classId=<%# Eval("Id") %>">修改</a></span>
                            <span><asp:LinkButton ID="lbDel" CommandName="btndel" runat="server" OnClientClick="return confirm( '该操作会删除本游戏分类和下属游戏分类，确定要删除吗？ ');">删除</asp:LinkButton></span>
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
