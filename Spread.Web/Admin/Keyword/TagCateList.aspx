<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TagCateList.aspx.cs" Inherits="Spread.Web.Admin.Keyword.TagCateList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>管理员管理</title>
<link rel="stylesheet" type="text/css" href="../images/style.css" />
<link rel="stylesheet" type="text/css" href="../images/pagination.css" />
<script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
<script type="text/javascript" src="../../Content/Javascript/jquery.pagination.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
<script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
<script type="text/javascript" src="../js/cursorfocus.js"></script>
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
        <div class="navigation"><span class="add"><a href="add.aspx">增加关键字</a></span><b>您当前的位置：首页 &gt;  扩展功能 &gt; 关键字类别列表</b></div>
        <div style="padding:5px;">&nbsp; 类别名称：<asp:TextBox ID="txtName" runat="server" 
            CssClass="input w20 required"  maxlength="20" minlength="3" HintTitle="类别名称" HintInfo="控制在20个字符内，标题文本尽量不要太长。" ></asp:TextBox>
            &nbsp;类别描述：<asp:TextBox ID="txtDesc" runat="server" CssClass="input"  HintTitle="类别描述" HintInfo="控制在100个字符内，文本尽量不要太长。"  MaxLength="100" Width="318px"></asp:TextBox>
            &nbsp;<asp:Button ID="btnSubmit" runat="server" CssClass="submit" 
                OnClick="btnSubmit_Click" OnClientClick="return CheckValidate()" Text="添加关键字类别" 
                Width="100px" />
        </div>
        <div>
            <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th width="7%">选择</th>
                <th width="15%">类别编号</th>
                <th width="25%">类别名称</th>
                <th width="30%">类别描述</th>              
                <th width="13%">操作</th>             
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                </td>
                <td><%#Eval("ID")%></td>
                <td><%#Eval("Name")%></td>
                <td><%#Eval("Desc")%></td>
                <td align="center"><span><a href="?id=<%#Eval("ID") %>">编辑</a></span></td>                         
                </td>
              </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
            
            <div class="spClear"><asp:Literal ID="LitMsg" runat="server"></asp:Literal> </div>
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
