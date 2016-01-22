<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoList.aspx.cs" Inherits="Spread.Web.Admin.means.VideoList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>视频上传管理</title>
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
		    link_to:"?<%=CombUrlTxt(this.classId, this.keywords, this.property) %>page=__id__"
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
    <div class="navigation"><span class="add"><a href="VideoAdd.aspx">上传视频</a></span><b>您当前的位置：首页 &gt; 视频管理 &gt; 视频列表</b></div>
    <div class="spClear"></div>
    
    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">选择</th>
        <th width="6%">编号</th>
        <th  align="left">视频名称</th>
        <th width="10%">发布时间</th>
        <th width="110">属性</th>
        <th width="8%">操作</th>
      </tr>
      </HeaderTemplate>
      <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
        <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
        <td><a href="edit.aspx?id=<%#Eval("Id") %>"><%#Eval("Title")%></a></td>
        
       
        <td><%#string.Format("{0:g}", Eval("AddTime"))%></td>
        <td>
          <asp:ImageButton ID="ibtnTop" CommandName="ibtnTop" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsTop")) == 1 ? "../Images/ico-1.png" : "../Images/ico-1_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsTop")) == 1 ? "取消首发产品" : "设置首发产品"%>' />
          <asp:ImageButton ID="ibtnMsg" CommandName="ibtnMsg" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsMsg")) == 1 ? "../Images/ico-0.png" : "../Images/ico-0_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsMsg")) == 1 ? "取消产品" : "设置产品"%>' /> 
          <asp:ImageButton ID="ibtnRed" CommandName="ibtnRed" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsRed")) == 1 ? "../Images/ico-2.png" : "../Images/ico-2_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsRed")) == 1 ? "取消宣传手册" : "设置宣传手册"%>' />     
          <asp:ImageButton ID="ibtnHot" CommandName="ibtnHot" runat="server" ImageUrl='<%# Convert.ToInt32(Eval("IsHot")) == 1 ? "../Images/ico-3.png" : "../Images/ico-3_.png"%>' ToolTip='<%# Convert.ToInt32(Eval("IsHot")) == 1 ? "取消海报" : "设置海报"%>' />
          
        </td>
        <td align="center"><span><a href="VideoEdit.aspx?id=<%#Eval("Id") %>">修改</a></span></td>
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
                  <asp:LinkButton ID="lbtnDel" runat="server" 
                    OnClientClick="return confirm( '确定要删除这些记录吗？ ');" onclick="lbtnDel_Click">删 除</asp:LinkButton>
                </span>
            </div>
	</div>
    </form>
</body>
</html>

