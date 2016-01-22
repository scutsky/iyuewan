<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportSetList.aspx.cs" Inherits="Spread.Web.Admin.statistics.ReportSetList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>账号管理</title>
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
		    link_to:"?<%=CombUrlTxt(this.keywords) %>page=__id__"
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
    <div class="navigation">
      <span class="add"><a href="ReportSetAdd.aspx">增加设置</a></span>
    <b>您当前的位置：首页 &gt; 报表设置管理 &gt; 设置列表</b></div>
    <div class="spClear"></div>
    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand" >
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">编号</th>
        <th width="12%">平台</th>
        <th width="12%">统计日期列</th>
        <th width="12%">渠道名称列</th>
        <th width="12%">游戏名称列</th>
        <th width="12%">注册值列</th>
        <th width="12%">消费值列</th>
        <th width="12%">收入列</th>
        <th width="8%">操作</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center" ><%#Eval("Id")%>
            <asp:HiddenField ID="lb_id" runat="server" Value='<%#Eval("Id")%>' />
        </td>
        <td align="center"><%#getMenuName(Eval("Bak1"))%></td>
        <td align="center"><%#getName(Eval("SumDate"))%></td>
        <td align="center"><%#getName(Eval("ChannelName"))%></td>
        <td align="center"><%#getName(Eval("GameName"))%></td>
        <td align="center"><%#getName(Eval("RegisterValue"))%></td>
        <td align="center"><%#getName(Eval("ConsumptionValue"))%></td>
        <td align="center"><%#getName(Eval("Income"))%></td>
        <td align="center">
        <span><a href="ReportSetEdit.aspx?id=<%#Eval("Id") %>">修改</a></span>
        <span><span><asp:LinkButton ID="lbDel" CommandName="btndel" runat="server" OnClientClick="return confirm( '确定要删除吗？ ');">删除</asp:LinkButton></span></span>
        </td>
      </tr>
          
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>

    <div class="spClear"></div>
    <asp:HiddenField ID="hdClassid" runat="server"></asp:HiddenField>
    </form>
</body>


</html>

