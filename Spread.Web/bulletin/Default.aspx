<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Spread.Web.bulletin.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 内容区 -->
    <div class="contain bulletin-list">
        <p class="crumbs">
            <a href="/Index.aspx" >首页</a> <a href="/bulletin/Default.aspx" 
                class="notactive">&nbsp;&gt;&nbsp;公告中心</a>
        </p>
        <div class="box cf">
            <div class="tab">
            <%=strMenu %>
            </div>
            <ul class="list">
                <%
                         if (this.Article != null && this.Article.Rows.Count > 0)
                       {
                           for (int i = 0; i < this.Article.Rows.Count; i++)
                           {
                               System.Data.DataRow dr = this.Article.Rows[i];%>    
                    <li>
					<div class="title">
						<a href="Detail.aspx?id=<%=dr["ID"].ToString()%>" >
                        <%if (dr["IsTop"].ToString() == "True")
                          { %>
                            <span class="top">【置顶】</span>
                        <% }%>
                        <%=dr["Title"].ToString()%></a>
						<span class="time">
							<i class="iconfont icon-clock"></i>
							<span><%=dr["AddTime"].ToString()%></span>
						</span>
					</div>
					<div class="abstract">
                         <%if (dr["Form"].ToString().Length > 180){ %>
                            <%=dr["Form"].ToString().Substring(0, 180)%>...
                         <% }else{%>
                            <%=dr["Form"].ToString()%>
                         <%}%>
					</div>
				</li>
                                <%}
                       }%>
            </ul>
            <div id="pager" class="m-t-20">
                <div class="pager align-center">
                    <div class="total">
                        共有<%=Count %>条记录</div>
                </div>
            </div>
        </div>
    </div>
      <script src="../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $(".content ul li").removeClass("on");
        $("#nav_bulletin a").addClass("on");
    });
     </script>
</asp:Content>
