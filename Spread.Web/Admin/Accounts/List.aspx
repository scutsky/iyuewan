<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Spread.Web.Admin.Accounts.List" %>

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
		    link_to:"?<%=CombUrlTxt(this.UserType, this.keywords, this.property) %>page=__id__"
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
    <div class="navigation"><b>您当前的位置：首页 &gt; 结算管理 &gt; 结算列表</b>
    <span class="btn"><asp:Button 
            ID="btnUpdate" runat="server" Text="结算" onclick="btnUpdate_Click"  /><span></div>
    <div class="spClear"></div>
   
    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">结算单号</th>
		<th width="10%">申请时间</th>
		<th width="15%">结算周期</th>
        <th width="10%">账户</th>
		<th width="6%">充值金额</th>
		<th width="6%">收入</th>
		<th width="6%">结算金额</th>
		<th width="6%">结算状态</th>
		<th width="6%">实际打款</th>
		<th width="6%">操作</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
		<td align="center"><%#Eval("ApplyTime")%></td>
		<td align="center"><%#Eval("SettlementCycle")%></td>
         <td align="center"><%#Eval("UserName")%></td>
		<td align="center"><%#Eval("Recharge")%></td>
		<td align="center"><%#Eval("Income")%></td>
		<td align="center"><%#Eval("Settlement")%></td>
		<td align="center"><%#Eval("Status")%></td>
		<td align="center"><%#Eval("ActualPlay")%></td>
		<td align="center">
        <a href="Edit.aspx?id=<%#Eval("Id")%>">审核</a>
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
            
	</div>

    <asp:HiddenField ID="hdClassid" runat="server"></asp:HiddenField>
    </form>
</body>

<script language="javascript" type="text/javascript">
    $(function () {
        $("#ddlClassId").val($("#hdClassid").val());
    });
    </script>
</html>

