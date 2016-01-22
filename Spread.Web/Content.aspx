<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="Spread.Web.Content" %>
<%@ Register src="UserContrl/SiteMenu.ascx" tagname="SiteMenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="R-content clearfix">
	<div class="layout">
    	<div class="banner"><a href="#"><img src="images/local/banner224-1.jpg" /></a></div>
    	<div class="other-page">
       		<div class="con-box fl">
            	<div class="title-box clearfix">
                	<h2 class="fl"><asp:Label   ID="lbtitle" runat="server" ></asp:Label></h2> 
                	<p class="fr">你的位置：企业  <asp:Label   ID="lbMenu" runat="server" ></asp:Label></p>
                </div>
				
                <div class="about-us">
                	<%if (Article != null){   %>
                       <%=Article.Rows[0]["Content"].ToString()%>
                  <%}%>
                </div>
                
                <div class="img-box tc">
                </div>
                
            </div>
            
            <div class="pic-box fr">
            	<div class="link-list">
                	<div class="hd">企业</div>
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
</asp:Content>
