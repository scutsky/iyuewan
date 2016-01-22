<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Card.aspx.cs" Inherits="Spread.Web.User.Card" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" media="screen" href="../style/main.css">
  <link rel="stylesheet" type="text/css" href="../style/gameCommon.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!-- 内容区 -->
    
 <div class="contain game-gift">
		<p class="crumbs">
			<a href="Channel.aspx">渠道</a>
			<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 游戏礼包</a>
		</p>
		<!--下面的注释是消除inline-block产生的间隙-->
		<div class="box showMsg">
			<div id="searchForm" >
				<div class="row2">
					<div class="searchGroup no-select">
						<div class="inputGroup">
							<input name="keyword" type="text" class="keyword" value="" runat="server">
						</div>
					</div>
					<!--
				-->
                    <asp:Button ID="searchBtn" runat="server" Text="搜索"  class="btn-2 searchBtn" 
                        onclick="searchBtn_Click"/>

					
				</div>
			</div>

			<div id="cardListForm" >
				<div class="table-title">选择游戏后，您可以：
                    <asp:LinkButton ID="linkInport" runat="server" onclick="linkInport_Click">批量导出游戏礼包</asp:LinkButton>
				</div>
				<input id="cardIds" name="cardIds" type="hidden" value="">
			</div>
            <asp:Repeater ID="rptList" runat="server"  >
    <HeaderTemplate>
			<table id="cardListTable" border="0" cellspacing="0" cellpadding="0" class="main-table">
				<tbody><tr class="table-head">
					<th style="width: 35px;">
						<input id="checkall"  type="checkbox" />
					</th>
					<th style="width: 125px;">游戏名称</th>
					<th style="width: 125px;">礼包名称</th>
					<th style="width: 125px;">礼包类型</th>
					<th style="width: 125px;">可用状态</th>
					<th style="width: 125px;">修改时间</th>
					<th>操作</th>
				</tr>
				  </HeaderTemplate>
      <ItemTemplate> 		
       <tr class="table-row">
       <td><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
       <td><%#Eval("gamename")%></td>
       <td><%#Eval("CardName")%></td>
       <td><%#Eval("CardType")%></td>
       <td><%#Eval("Status")%></td>
       <td><%#Eval("UpdateDate")%></td>
       <td></td>
       </tr>
       </ItemTemplate>
      <FooterTemplate>
       </tbody></table>
      </FooterTemplate>
      </asp:Repeater>
			<div id="pager">
				<div class="pager align-right">
						  <div class="pager align-right">
	  <div class="total">共有0条记录</div>
	  
	  </div>
				</div>
			</div>
		</div>
	</div>
    <asp:HiddenField ID="hdPlatform" runat="server" />
    <asp:HiddenField ID="hduid" runat="server" />
    <asp:HiddenField ID="hdcid" runat="server" />
    <asp:HiddenField ID="hdcname" runat="server" />
</asp:Content>
