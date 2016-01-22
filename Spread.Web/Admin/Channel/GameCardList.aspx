<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameCardList.aspx.cs" Inherits="Spread.Web.Admin.Channel.GameCardList" %>

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
           <span class="add"><a href="Add.aspx">发布公告</a></span><b>您当前的位置：首页 &gt; 渠道管理 &gt; 游戏礼包列表</b>
        </div>   
        <div class="spClear"></div>
   
    <div class="spClear"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" >
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th width="15%" >游戏名称</th>
                        <th width="15%" >礼包名称</th>
                        <th width="10%" >礼包类型</th>
                        <th width="10%">可用状态</th>
                        <th width="15%">修改时间</th>
                        <th width="10%">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                          <%# Eval("ID") %>
                        </td>
                        <td><%# Eval("GameName")%></td>
                        <td ><%# Eval("CardName")%></td>
                        <td ><%# Eval("CardType")%></td>
                        <td ><%# Eval("Status")%></td>
                        <td ><%# Eval("UpdateDate")%></td>
                        <td align="left">
                            <span><a href="CardEdit.aspx?id=<%# Eval("ID") %>">修改</a></span>
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


