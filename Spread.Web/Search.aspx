<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Spread.Web.Search" %>
<%@ Register src="UserContrl/SiteMenu.ascx" tagname="SiteMenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="R-content clearfix">
	<div class="layout">
    	<div class="banner"><a href="#"><img src="images/local/banner224-4.jpg" /></a></div>
    	<div class="other-page">
       		<div class="con-box fl">
            	<div class="title-box clearfix">
                	<h2 class="fl">零件查询</h2> 
                	<p class="fr">你的位置：应用 > <a class="col-01" href="#"> 零件查询</a></p>
                </div>                
                <div class="search-box">
                    <div class="hd">请输入一个查询型号：</div>
                    <div class="bd clearfix">
                        <span><input id="Conditions1" runat="server" class="ipt ipt-1" type="text"  /></span>
                        <span><input id="Conditions2" runat="server" class="ipt ipt-2" type="text"  /></span>
                        <span><input id="Conditions3" runat="server" class="ipt ipt-3" type="text"  /></span>
                        <span><input id="Conditions4" runat="server" class="ipt ipt-4" type="text"  /></span>
                         <asp:Button ID="btnSave" runat="server" CssClass="btn2" style="color:#FFF; font-size:14px;text-indent: 0em;"  onclick="btnSave_Click" />
                       
                    </div>
                </div>
                
                <div class="search-result">
                	<h4>查询结果：</h4>
                    <ul>
                    	<li class="one">
                        	<div class="hd">类型</div>
                            <%=strType %>
                            
                        </li>
                        <li class="two">
                        	<div class="hd">描述</div>
                           <%=strDesc%>
                        </li>
                    </ul>
                </div>
                     
               
   
            </div>
            
            <div class="pic-box fr">
            	<div class="link-list">
                	<div class="hd">产品中心</div>
                    <ul class="bd">
                    	<li>
                            
                            <a href="/Directory/Default.aspx">应用目录</a></li>
                        <li><a href="/Search.aspx">零件查询</a></li>
                        <li><a href="/Directory/View.aspx">顺百市场首发产品</a></li>
                    </ul>
                </div>

                <div class="pic-list">
                <uc1:SiteMenu ID="SiteMenu1" runat="server" />
           		</div>
                
            </div>
		</div>        
	</div>
</div>
<script type="text/javascript">
    $(function () {
        if ($('.ipt-1').val() == "") {
            $('.ipt-1').inputTxt({ val: "模糊查询" });
        }
        if ($('.ipt-2').val() == "") {
            $('.ipt-2').inputTxt({ val: "类型" });
        }
        if ($('.ipt-3').val() == "") {
            $('.ipt-3').inputTxt({ val: "车厂" });
        }
        if ($('.ipt-4').val() == "") {
            $('.ipt-4').inputTxt({ val: "品牌" });
        }

    })
</script>
</asp:Content>
