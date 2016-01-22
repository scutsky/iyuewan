<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Channel.aspx.cs" Inherits="Spread.Web.User.Channel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" media="screen" href="../style/main.css" />    
 <link rel="stylesheet" type="text/css" href="../style/channelIndex.css"/>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<div id="main" class="contain">
	<input id="api-add" type="hidden" value="/channel/createCooperateModel">
	<input id="api-list" type="hidden" value="/channel/getSubChannelList">
	<input id="api-detail1" type="hidden" value="/channel/getCooperateModelsByChannel">
	<input id="api-detail2" type="hidden" value="/channel/getPreAddCooperateModelsByChannel">
	<input id="api-delete" type="hidden" value="/channel/deleteCooperateModelApply">

	<p class="crumbs">
        <a href="../Index.aspx">首页</a>
		<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp;渠道管理</a>
	</p>
	<!--下面的注释是消除inline-block产生的间隙-->
    <div class="box">
	<div class="box-header">
		<h1>渠道列表</h1>
	</div>
	<div class="action">
        
		<a href="Addchannel.aspx" class="btn-2 addChannel" id="add-channel-btn">
			<i class="iconfont icon-add"></i>新增渠道
        </a>
<!--		<div class="tips">
			?
			<div class="msg-info">
				您可以通过这里新增您的渠道。
				<span class="arrows"></span>
				<span class="innerArrows"></span>
			</div>
		</div>-->
        
	</div>
	<div id="table-channel-list">
	<table border="0" cellspacing="0" cellpadding="0" class="main-table">
		<tbody><tr class="table-head" data-role="table-header">
			<th style="width: 125px;">我的渠道</th>
			<th style="width: 125px;">推广产品</th>
			<th style="width: 215px;">备注</th>
		</tr>
		 <%
             if (this.ChannelData != null && this.ChannelData.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.ChannelData.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.ChannelData.Rows[i];%>
			<tr>
				<td>
					<a href="Channeldetail.aspx?id=<%=dr["ID"].ToString()%>" ><%=dr["Title"].ToString()%></a>
					</td>
				<td><%=dr["ptitle"].ToString()%></td>
				<td>
					<%=dr["Brand"].ToString()%>
				</td>
			</tr>
		
			<%}
                 }%>
			
		
	</tbody></table>
</div>
</div>
</div>
<script src="../javascript/jquery.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $(".content ul li").removeClass("on");
         $("#nav_channel").addClass("on");
     });
     </script>
</asp:Content>
