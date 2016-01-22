<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="Spread.Web.Admin.Manage.LogList" %>

<%@ Import Namespace="Spread.BLL" %>
<%@ Import Namespace="Spread.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>管理员管理</title>
<link rel="stylesheet" type="text/css" href="../images/style.css" />
<link rel="stylesheet" type="text/css" href="../images/pagination.css" />
<script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
<script type="text/javascript" src="../../Content/Javascript/jquery.pagination.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script src="../Js/DateControl.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {
        
        //分页参数设置
        $("#Pagination").pagination(<%=pcount %>, {
        callback: pageselectCallback,
        prev_text: "« 上一页",
        next_text: "下一页 »",
        items_per_page:<%=pagesize %>,
		num_display_entries:3,
		current_page:<%=page %>,
		num_edge_entries:2,
		link_to:"?page=__id__"
       });
    });
    function pageselectCallback(page_id, jq) {
        //alert(page_id); 回调函数，进一步使用请参阅说明文档
    }
    
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
        <div class="navigation"><b>您当前的位置：首页 &gt; 
            扩展功能 &gt; 系统日志管理</b></div>
        <div style="padding-bottom:10px; display:none;">操作类型：<asp:DropDownList ID="ddlLogType"  CssClass="select"
                runat="server">
            <asp:ListItem Text="所有类型" Value=""></asp:ListItem>
            <asp:ListItem Text="用户注册" Value="用户注册"></asp:ListItem>
            <asp:ListItem Text="新增渠道" Value="新增渠道"></asp:ListItem>
            <asp:ListItem Text="添加游戏" Value="添加游戏"></asp:ListItem>
            </asp:DropDownList>
            账户或渠道：<asp:TextBox ID="txtUserName" runat="server" CssClass="keyword" MaxLength="20" Width="75"></asp:TextBox>
            起始日期：<asp:TextBox ID="txtStartTime" runat="server" CssClass="keyword" Columns="10" MaxLength="10" 
                onblur="setday(this);" onclick="setday(this);" Width="80"></asp:TextBox>
            截止日期：<asp:TextBox ID="txtEndTime" runat="server" CssClass="keyword"  Columns="10" MaxLength="10" 
                onblur="setday(this);" onclick="setday(this);" Width="80"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="submit" OnClick="btnSearch_Click" 
                Text=" 查询" />
        </div>
        <div>
            <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
            <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th width="7%">选择</th>
                <th width="16%">类型</th>
                <th width="12%">账户或渠道</th>
                <th width="29%">操作描述</th>
                <th width="21%">操作时间</th>
                <th width="10%">是否阅读</th>
                <th width="10%">查看</th>
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                </td>
                 <td align="center">
                    <%#Eval("LogType")%>
                </td>    
                <td align="center"><%#Eval("UserName")%></td>
                <td align="center"><%#Eval("Description")%></td>
                <td align="center">
                    <%#Eval("LogTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                </td>
                 <td align="center"><%#Eval("IsRead").ToString() == "未阅读" ? "<span style=\"color:red \">未阅读</span>" : "已阅读"%></td>
                 <td align="center"><span><asp:LinkButton ID="lbread" CommandName="btread" runat="server">查看</asp:LinkButton></span></td> 
              </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
            
            <div class="spClear"></div>
            <div style="line-height:30px;height:30px;">
              <div id="Pagination" class="right flickr"></div>
              <div class="left">
                <span class="btn_all" onclick="checkAll(this);">全选</span>
                <span class="btn_bg">
                  <asp:LinkButton ID="lbtnDel" runat="server" onclick="lbtnDel_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>
                  </span>
              &nbsp;</div>
	  </div>
    </div>
    </form>
</body>
</html>
