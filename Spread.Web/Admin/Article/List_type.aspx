<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List_type.aspx.cs" Inherits="Spread.Web.Admin.Article.List_type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <head id="Head1" runat="server">
    <title>类别管理</title>
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
           <span class="add"><a href="AddArticle_type.aspx?kindId=<%=kindId %>">增加公告分类</a></span><b>您当前的位置：首页 &gt; 公告分类管理管理 &gt; 公告分类列表</b>
        </div>   
        <div style="padding-bottom:10px;"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th align="left">类别名称</th>
                        <th width="90">优先级别</th>
                        <th width="100">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                         
                       <asp:Label ID="lalelid" runat="server" Text='<%# Eval("Id")%>'></asp:Label>     
                        </td>
                        <td>
                         
                          <%# Eval("Title") %>
                        </td>
                        <td align="center"><%# Eval("ClassOrder") %></td>
                        <td align="left">
                        
                    
                            
                            <span>
                            <asp:Button  ID="lbDel1" runat="server" CommandName="Del"  OnClientClick="return confirm( '该操作会删除本类别，确定要删除吗？ ');" Text="删除"   />
                           </span>
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
