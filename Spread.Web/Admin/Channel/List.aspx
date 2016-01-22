<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Spread.Web.Admin.Channel.List" %>

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
           <b>您当前的位置：首页 &gt; 渠道管理 &gt; 渠道列表</b>
        </div>   
        <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center">请选择：</td>
        <td>
            <asp:DropDownList ID="ddlClassId" runat="server" CssClass="select" 
                onselectedindexchanged="ddlClassId_SelectedIndexChanged" 
                AutoPostBack="True">             
                </asp:DropDownList>&nbsp;
            <asp:Button ID="btnExport" runat="server" Text="导出" onclick="btnExport_Click" />
        </td>
        </tr>
    </table>
    <div class="spClear"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th width="15%" align="left">渠道名称</th>
                        <th width="15%" >所属账户</th>
                        <th width="15%" >推广产品</th>
                        <th width="20%">备注</th>
                        <th width="10%">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                          <asp:HiddenField ID="txtClassId" runat="server" Value='<%#Eval("Id") %>' />
                          <asp:HiddenField ID="txtClassLayer" runat="server" Value='<%#Eval("ClassLayer") %>' />
                          <%# Eval("ID") %>
                        </td>
                        <td><%# Eval("Title") %>
                        </td>
                         <td align="center"><%# Eval("username") %></td>
                        <td align="center"><%# Eval("ptitle") %></td>
                        <td align="center"><%# Eval("bak1") %></td>
                        <td align="left">
                            
                            <span><a href="Edit.aspx?id=<%# Eval("ID") %>">修改</a></span>
                            <span><a href="GameList.aspx?id=<%# Eval("ID") %>">推广游戏</a></span>
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
