<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plist.aspx.cs" Inherits="Spread.Web.Admin.Channel.Plist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>类别管理</title>
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
         <span class="add"><a href="PAdd.aspx">增加平台渠道管理</a></span>
           <b>您当前的位置：首页 &gt; 平台渠道管理 &gt; 平台渠道列表</b>
        </div>   
        <div class="spClear"></div>
        <div class="spClear"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th width="20%" align="left">渠道名称</th>
                        <th width="20%" align="left">所属平台</th>
                        <th width="10%">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                          <asp:HiddenField ID="lb_id" runat="server" Value='<%#Eval("Id")%>' />
                          <%# Eval("ID") %>
                        </td>
                        <td ><%# Eval("Title") %></td>
                        <td ><%# Eval("ptitle") %></td>
                     
                        <td align="center" >
                            <span><a href="Pedit.aspx?id=<%# Eval("ID") %>">修改</a></span>
                            <span><span><asp:LinkButton ID="lbDel" CommandName="btndel" runat="server" OnClientClick="return confirm( '确定要删除吗？ ');">删除</asp:LinkButton></span></span>
        
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
