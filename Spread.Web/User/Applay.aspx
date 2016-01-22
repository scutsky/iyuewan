<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Applay.aspx.cs" Inherits="Spread.Web.User.Applay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen" href="../style/main.css">
  <link rel="stylesheet" type="text/css" href="../style/index.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->
    

	<div class="contain">
		<p class="crumbs">
			<a href="javascript:void(0)">结算管理</a>
			<a href="Individualbal.aspx" class="notactive">&gt; 结算记录</a>
			<a href="javascript:void(0)" class="notactive">&gt; 申请结算</a>
		</p>
		<div class="box payment">
			<div class="box-header">
				<h1>申请结算</h1>
			</div>
			<span class="payment-tip-message">申请规则：为了保障您的结算收款效率，请在每天的14点前提交结算申请，逾期则只能延后到次日再申请。结算统计周期为上月26日-本月25日，跨月份系统会在后台自动拆分成2次进行结算。 </span>
			<ul class="payment-info">
				<li>
					<span class="title">结算周期：</span>
                    <asp:Label ID="startDate" runat="server" ></asp:Label>～<asp:Label ID="endDate" runat="server" ></asp:Label>
                    <span style="color:red;width:100%;height:32px;font-weight:bold;">（务必确认周期内每天的结算金额正确，再申请结算）</span></li>
				<li>
					<span class="title">结算渠道：</span>全部渠道</li>
				<li>
					<span class="title">充值金额：</span>
                    <asp:Label ID="consumeMoney" runat="server" ></asp:Label>元
					<a href="Statis.aspx?startDateStr=<%=startDateStr%>&endDateStr=<%=endDateStr%>">查看数据明细</a>
				</li>
				<li>
					<span class="title">收入：</span>
                    <asp:Label ID="validMoney" runat="server" ></asp:Label>元
				</li>
				<li>
					<span class="title">提现方式：</span>支付宝（账号：<asp:Label ID="alipayPayeeAccount" runat="server" ></asp:Label>）</li>
				<li>
					<span class="title">收款人：</span>
                    <asp:Label ID="alipayPayeeName" runat="server" ></asp:Label></li>
				<li>
			</li></ul>
			<div class="action">
                <asp:Button ID="btnSave" runat="server" class="btn-1 submit-btn" Text="申请结算"  
                    onclick="btnSave_Click" />
				</div>
		</div>
	</div>
    <asp:HiddenField ID="hduserid" runat="server" />
    <asp:HiddenField ID="hdusername" runat="server" />
    
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".content ul li").removeClass("on");
            $("#nav_individualba").addClass("on");
        });
     </script>
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
