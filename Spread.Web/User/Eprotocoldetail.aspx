<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Eprotocoldetail.aspx.cs" Inherits="Spread.Web.User.Eprotocoldetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<!-- 内容区 -->
    

<div class="contain content1">
		<div class="word box">
			<div class="s4" style="background-color: #fff4e8;">
				<span style="color:red;width:100%;height:32px;font-weight:bold;">温馨提示</span>：
				<br>
				
				<%=model.Form %>				
			</div>
			<div class="s1"><%=model.Title %></div>
			<div id="connert">
			<%=model.Content%>

        </div>	
	</div>
</div>
  <asp:HiddenField ID="hdusername" runat="server" />
    <script src="../javascript/jquery.js" type="text/javascript"></script>
  <script language="javascript" type="text/javascript">
     
      $(function () {
          var name = $("#ctl00_main_hdusername").val();
          $("#username").val(name);
          $("#username2").val(name);
      });
  </script>
</asp:Content>
