<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Spread.Web.Product.Default" %>
<%@ Import Namespace="System.Data" %>
<%@ Register src="../UserContrl/SiteMenu.ascx" tagname="SiteMenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="R-content clearfix">
	<div class="layout">
    	<div class="banner"><a href="#"><img src="../Images/local/banner224-1.jpg" /></a></div>
    	<div class="other-page">
       		<div class="con-box fl">
            	<div class="title-box clearfix">
                	<h2 class="fl">产品中心</h2> 
                	<p class="fr">你的位置：<a class="col-01" href="/Product/Default.aspx"> 产品中心</a>
                    <asp:Label   ID="lbMenu" runat="server" ></asp:Label></p>
                </div>
                
                <% if (Goods==null)
                   {
                       %>
                <div class="img-box tc">
                	<img src="../Images/local/chanpian.jpg" />
                    <p>请选择一个产品，<span class="col-01">了解更多详情</span></p>
                </div>
                 <%}else{%>

                 <div class="img-box tc"><img src="<%=Goods.Rows[0]["ImgUrl"] %>" style=" width:740px; height:250px;" /></div>                
                <div class="border-title"><span>产品详情</span></div>                
                <div class="product-details">
                	<%=Goods.Rows[0]["Zhaiyao"]%>
                </div>
              
                 <%}%>
            </div>
            
            <div class="pic-box fr">
            	<div class="link-list">
                	<div class="hd">产品中心</div>
                    <ul class="bd">
                      <%=MenuInfo()%>
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

</script>
</asp:Content>
