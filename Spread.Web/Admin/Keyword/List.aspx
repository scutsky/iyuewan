<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Spread.Web.Admin.Keyword.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Spread.Common" %>
<%@ Import Namespace="Spread.BLL" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>管理员管理</title>
<link rel="stylesheet" type="text/css" href="../images/style.css" />
<link rel="stylesheet" type="text/css" href="../images/pagination.css" />
<script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
<script type="text/javascript" src="../../Content/Javascript/jquery.pagination.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
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
        <div class="navigation"><span class="add"><a href="add.aspx">增加关键字</a></span><b>您当前的位置：首页 &gt;  扩展功能 &gt; 关键字列表</b></div>
        <div style="padding:5px;">&nbsp;所属类别：<asp:DropDownList ID="ddlTagCategoryId" 
                CssClass="select" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlTagCategoryId_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;</div>
        <div>
            <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th width="7%">选择</th>
                <th width="23%">关键字名称</th>
                <th width="20%">关键字类别</th>
                <th width="10%">昨日搜索次数</th>
                <th width="10%">今日搜索次数</th>
                <th width="10%">总搜索次数</th>
                <th width="20%">添加者</th>                
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                </td>
                <td><%#Eval("Name")%></td>
                <td><%# ShowClass(Eval("TagCategoryID").ToString())%></td>
                <td align="center"><%#Eval("YesterdaySearchCount")%></td>
                <td align="center"><%# Eval("DaySearchCount")%></td>
                <td><%# Eval("TotalSearchCount")%></td>
                <td><%# Function.HtmlEncode(Eval("UserName"))%></td>
                </td>
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
