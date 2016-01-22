<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Eprotocol.aspx.cs" Inherits="Spread.Web.User.Eprotocol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../style/index.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->
    


<div class="contain e-protocol">
	<p class="crumbs">
		<a href="../Index.aspx">首页</a>
		<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp;电子协议</a>
	</p>
	<div class="box" style=" padding:0px;">
		<table border="0" cellspacing="0" cellpadding="0" class="main-table">
			<tbody><tr class="table-head">
				<th>产品名称</th>
				<th>产品简介</th>
				<th>计费模式</th>
				<th>操作</th>
			</tr>
			 <%
                 if (this.Products != null && this.Products.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.Products.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.Products.Rows[i];%>
                         <% if (i == 0)
                            { %>  
			
			<tr>
				<td style="width: 50px;"><%=dr["Title"].ToString()%></td>
				<td style="max-width: 400px; max-height: 300px; overflow:auto;"><%=dr["Keyword"].ToString()%></td>
				<td style="width: 50px;"><%=dr["Brand"].ToString()%></td>
				<td style="width: 30px;"><a href="Eprotocoldetail.aspx">查看</a></td>
			</tr>
			
			<%}
                     }
                 }%>
		</tbody></table>
	</div>
</div>
  <script src="../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $(".content ul li").removeClass("on");
        $("#nav_eprotocol a").addClass("on");
    });
     </script>
</asp:Content>
