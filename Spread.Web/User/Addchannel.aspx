<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Addchannel.aspx.cs" Inherits="Spread.Web.User.Addchannel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" media="screen" href="../style/main.css">
    <link rel="stylesheet" type="text/css" href="../style/addChannel.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<!-- 内容区 -->
    
<div class="contain">

	<input id="api-add" type="hidden" value="/channel/createSubChannelCooperate">
	<input id="api-search" type="hidden" value="/channel/getCategoryDesc">

	<p class="crumbs">
		<a href="/User/Channel.aspx">我的渠道</a>
		<a href="javascript:void(0)" class="notactive">&nbsp;&gt;&nbsp; 新增渠道</a>
	</p>
	<!--下面的注释是消除inline-block产生的间j隙-->
	<div class="box showMsg">
		<div class="title">
		   
			<i class="icon"></i>补充您的渠道信息，您就可以开展推广合作了。
           
           </div>
		<div id="form" class="yourChannelMsg" novalidate>
		   
			<div class="leftLineTitle">您的渠道信息</div>

			<div class="inputDiv">
				<label class="label">渠道名称：</label>
				<div class="inputGroup">
                    <asp:TextBox ID="channelname" runat="server" CssClass="ipt-1" style="display: block;"></asp:TextBox>
				</div>
				<span class="input-tips">名称仅用于备注显示</span>
			</div>
		<%--	<div class="inputDiv">
				<label class="label align-top">行业分类：</label>
				<div class="inputGroup">
                    <asp:DropDownList ID="channeltype" runat="server"  class="mySelect">
                    <asp:ListItem Value="0" Selected>请选择</asp:ListItem>
                    <asp:ListItem Value="1">PC网站</asp:ListItem>
                    <asp:ListItem Value="5">PC软件</asp:ListItem>
                    <asp:ListItem Value="10">应用商店</asp:ListItem>
                    <asp:ListItem Value="12">手机网站</asp:ListItem>
                    <asp:ListItem Value="16">手机APP</asp:ListItem>
                    <asp:ListItem Value="19">线下预装</asp:ListItem>
                    <asp:ListItem Value="21">其他</asp:ListItem>
                    <asp:ListItem Value="23">WIFI</asp:ListItem>
                    </asp:DropDownList>
				</div>
			</div>--%>
            
			<%--<div id="extra_input_1">
                <div id="input_1" class="inputDiv" >
                    <label id="lbWebName" class="label" >网站名称：</label>
				    <div class="inputGroup">
                        <asp:TextBox ID="txtWebName" runat="server" CssClass="ipt-1" style="display: block;"></asp:TextBox>
				    </div>
                </div>
                <div  id="input_2" class="inputDiv">
                <label id="lbWebUrl" class="label"  >网站地址：</label>
				    <div class="inputGroup">
                        <asp:TextBox ID="txtWebUrl" runat="server" CssClass="ipt-1" style="display: block;"></asp:TextBox>
				    </div>
                </div>
            </div>
		</div>--%>

		<div class="spreadTable" >
			<div class="leftLineTitle" ><span >推广合作</span></div>
                <asp:Repeater ID="rptList" runat="server" >
    <HeaderTemplate>
			<table border="0" cellspacing="0" cellpadding="0" class="main-table">
				<tbody><tr class="table-head">
					<th style="width: 35px;">
						<i id="check-all" class="icon checkBox"></i>
					</th>
					<th style="width: 125px;">产品名称</th>
					<th style="width: 185px;">产品简介</th>
					<th style="width: 125px;">是否需要审核</th>
					<th style="width: 125px;">计费模式</th>
					<th>电子协议</th>
				</tr>
                 </HeaderTemplate>
      <ItemTemplate>
						<tr data-id="1">
						<td>
                            <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                            <asp:HiddenField ID="lb_id" runat="server" Value='<%#Eval("Id")%>' />
						</td>
						<td><%#Eval("Title")%></td>
						<td><%#Eval("Keyword")%></td>
                            
						<td><%#Eval("IsLock").ToString()=="0"?"是":"否"%></td>
						<td><%#Eval("Brand")%></td>
						<td>
							<i class="icon checkBox elecheck checked"></i>我已阅读并同意
							<a href="Eprotocoldetail.aspx" >电子协议</a>
						</td>
					</tr>
             </ItemTemplate>
      <FooterTemplate>
      </tbody>
      </table>
      </FooterTemplate>
        </asp:Repeater>
		</div>

		<div class="submit">
            <asp:Button ID="submitbtn" runat="server" Text="提交"  class="btn-1" 
                onclick="submitbtn_Click"/>
			<p id="fail-tip" class="failMsg"></p>
			<div class="submit-tips">需审核的产品约在2个工作日内完成审核
				<br>不需要审核的产品立即生效</div>
		</div>
	</div>
</div>
    <script src="../javascript/jquery.js" type="text/javascript"></script>
    <script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(function () {
//        $("#input_1").hide();
//        $("#input_2").hide();
        $("#extra_input_1").hide();
        $('#ctl00_main_channeltype').change(function () {
            var p1 = $(this).children('option:selected').val(); //这就是selected的值
            if (p1 == "1") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").show();
                $("#lbWebName").html("网站名称：");
                $("#lbWebUrl").html("网站地址：");
            } else if (p1 == "5") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").show();
                $("#lbWebName").html("软件名称：");
                $("#lbWebUrl").html("软件下载连接：");
            } else if (p1 == "10") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").show();
                $("#lbWebName").html("应用商店名称：");
                $("#lbWebUrl").html("应用商店下载连接：");
            } else if (p1 == "12") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").show();
                $("#lbWebName").html("网站名称：");
                $("#lbWebUrl").html("网站名称：");
            } else if (p1 == "16") {
                $("#extra_input_1").show();
                $("#lbWebName").html("APP名称：");
                $("#lbWebUrl").html("APP下载连接：");
            } else if (p1 == "19") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").hide();
                $("#lbWebName").html("自身资源说明：");
                //$("#lbWebUrl").html("APP下载连接：");
            } else if (p1 == "21") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").hide();
                $("#lbWebName").html("自身资源说明：");
                //$("#lbWebUrl").html("APP下载连接：");
            } else if (p1 == "23") {
                $("#extra_input_1").show();
                $("#input_1").show();
                $("#input_2").show()
                $("#lbWebName").html("名称：");
                $("#lbWebUrl").html("覆盖AP数量：");
            } else {
                $("#input_1").hide();
                $("#input_2").hide();
                $("#extra_input_1").hide();
                
            }
        });
    });

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
