<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Spread.Web.Admin.statistics.UserList" %>
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
    <div class="navigation"><b>您当前的位置：首页 &gt; 游戏统计管理 &gt; 账号列表</b></div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center">请选择：</td>
        <td>
            <asp:DropDownList ID="ddlClassId" runat="server" CssClass="select" 
                onselectedindexchanged="ddlClassId_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="1" >公司</asp:ListItem>
                <asp:ListItem Value="2"  >个人</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:DropDownList ID="ddlProperty" runat="server" CssClass="select" 
                onselectedindexchanged="ddlProperty_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem Value="">所有属性</asp:ListItem>
                <asp:ListItem Value="isLock">锁定</asp:ListItem>
                <asp:ListItem Value="isNoLock">未锁定</asp:ListItem>
            </asp:DropDownList>
         
        </td>
        <td width="50" align="right">关健字：</td>
        <td width="150"><asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="60" align="center"><asp:Button ID="btnSelect" runat="server" Text="查询" 
                CssClass="submit" onclick="btnSelect_Click" /></td>
        </tr>
    </table>
    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">编号</th>
        <th align="left">账号</th>
        <th width="13%">账号属性</th>
        <th width="16%">注册时间</th>
        <th width="110">属性</th>
        <th width="8%">操作</th>
      </tr>
     
      </HeaderTemplate>
      <ItemTemplate> 
      <tr>
        <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
        <td><a href="edit.aspx?id=<%#Eval("Id") %>"><%#Eval("Name")%></a></td>
        <td align="center"><%#Eval("UserType").ToString() == "1" ? "公司" : "个人"%></td>
        <td><%#string.Format("{0:g}", Eval("RegDate"))%></td>
        <td>
          <asp:ImageButton ID="ibtnLock" CommandName="ibtnLock" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsLock")) == 1 ? "../Images/ico-5.png" : "../Images/ico-5_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsLock")) == 1 ? "取消锁定" : "设置锁定"%>' />
         
        </td>
        <td align="center">
        <span><a href="Daycount.aspx?userid=<%#Eval("Id") %>">查看数据</a></span>
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
    <div class="spClear"></div>
    <asp:HiddenField ID="hdClassid" runat="server"></asp:HiddenField>
    </form>
</body>

<script language="javascript" type="text/javascript">
    $(function () {
        $("#ddlClassId").val($("#hdClassid").val());
    });
    </script>
</html>

