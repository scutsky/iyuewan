<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Channeldetail.aspx.cs" Inherits="Spread.Web.User.Channeldetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" media="screen" href="../style/main.css" />    
 <link rel="stylesheet" type="text/css" href="../style/channelIndex.css"/> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 渠道详情 -->
<div id="main" class="contain">
<div id="channel-detail" class="box m-t-20 channel-detail">

	<div id="loading" class="loading">
		<div class="loading-img"></div>
		<div class="loading-tips">加载中，请稍等</div>
	</div>

	<div class="box-header cf">
		<h1>
			<span id="channel-name">
                <asp:Label ID="lbChanel" runat="server" Text=""></asp:Label></span> 的推广详情</h1>
		<div class="change-channel">更换
			<i class="iconfont icon-arrow-down"></i>
			<div class="hover-mask"></div>
			<ul id="channel-ul">
             <%
                 if (this.ChannelTitle != null && this.ChannelTitle.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.ChannelTitle.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.ChannelTitle.Rows[i];%>
                        <li><a href="Channeldetail.aspx?id=<%=dr["ID"].ToString()%>"><%=dr["title"].ToString()%></a></li>
            <%}
         }%>
			</ul>
		</div>
	</div>


	<div id="table-detail1">

	</div>
	<!-- 产品列表 -->
		<div id="table-detail2">
        <table border="0" cellspacing="0" cellpadding="0" class="main-table">
		<tr class="table-head" data-role="table-header">
			<th style="width: 125px;">推广产品</th>
			<th style="width: 85px;">计费模式</th>
			<th style="width: 85px;">状态</th>
			<th style="width: 215px;">操作</th>
			<th style="width: 85px;">数据统计</th>
			<th>电子协议</th>
		</tr>

	</tr>
		 <%
             if (this.ChannelData != null && this.ChannelData.Rows.Count > 0)
                 {
                     for (int i = 0; i < this.ChannelData.Rows.Count; i++)
                     {
                         System.Data.DataRow dr = this.ChannelData.Rows[i];%>
			<tr>
				<td><%=dr["ptitle"].ToString()%></td>
				<td><%=dr["Brand"].ToString()%></td>
				<td>
					<% if (dr["status"].ToString() == "1" || dr["status"].ToString() == "3")
        { %>
						<span class="waitForCheck">待审核</span>
					<% }
        else if (dr["status"].ToString() == "2" || dr["status"].ToString() == "4")
        { %>
						<span class="notPass">审核不通过</span>
						<div class="tips">
							?
							<div class="msg-info">
								抱歉,您的推广合作没有审核成功,您可以请尝试完善资料,重新申请
								<span class="arrows"></span>
								<span class="innerArrows"></span>
							</div>
						</div>
					<% } else if (dr["status"].ToString() == "5") { %>
							推广中
					<% } %>
				</td>
				<td><% if (dr["status"].ToString() == "1" || dr["status"].ToString() == "3")
           { %>
							<!-- 待审核 -->
						<% }
           else if (dr["status"].ToString() == "2")
           { %>
							<a data-role="delete-product"  href="javascript:">删除</a>
						<% }
           else if (dr["status"].ToString() == "5")
           { %>
                            <!--<div>游戏推广功能暂不开放</div>-->
								<div><a href="chooseGames.aspx?cooperateId=<%=dr["ID"].ToString() %>">选择推广游戏</a></div>
                                <div><a href="downloadGames.aspx?cooperateModelId=<%=dr["ID"].ToString() %>">下载推广游戏</a></div>
                                <div><a href="info.aspx?cooperateModelId=<%=dr["ID"].ToString() %>">游戏资料</a></div>
                                <div><a href="card.aspx?cooperationModelId=<%=dr["ID"].ToString() %>">游戏礼包</a></div>
						<% } %>
				</td>
				<% if (dr["status"].ToString() == "5")
       { %>
					<td><a href="/User/statis.aspx?cooperateModelId=" target="_blank">查看</a></td>
					<td><a href="/User/Eprotocoldetail.aspx"  target="_blank">查看</a></td>
				<% } else { %>
					<td></td>
					<td></td>
				<% } %>
			</tr>
		<%}
         }%>
	</table>
		</div>
	
	</div>
</div>
<script src="../javascript/jquery.js" type="text/javascript"></script>
<script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    

    function alertMsg(msg, v_icon) {
        //$.dialog.alert(msg);
        $.dialog({
            title: '提示',
            lock: true,
            icon: v_icon,
            cancel: true,
            width: 200,
            height: 80,
            max: false,
            min: false,
            content: msg
        });
    }
    function alertRedirectMsg(msg, v_icon, url) {
        $.dialog({
            title: '提示',
            lock: true,
            icon: v_icon,
            width: 200,
            height: 80,
            max: false,
            min: false,
            content: msg,
            cancelVal: '关闭',
            cancel: function () {
                window.location.href = url;
            }
        });
    }
    </script>
</asp:Content>
