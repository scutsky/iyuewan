<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Spread.Web.Index" %>

<%@ Import Namespace="System.Data" %>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- 测试 -->
   <div class="clearfix mb10">
    <div class="col_left">
        <asp:Panel ID="Panel2" runat="server"> 
        <div class="login_mod">     
            <div class="tit">用户登录</div>            
                <ul>    
                    <li><span class="lb">用户名</span>
                        <div class="put">                       
                            <input type="text" id="username" value=""  runat="server"  />                           
                        </div>
                    </li>
                    <li><span class="lb">密 码</span>
                        <div class="put">
                          <input type="password"  id="password" value="" runat="server" />                          
                        </div>
                    </li>
                    <li><span class="lb">动态码</span>
                        <div class="put_mb">
                            <input class="put_mb_input" id="DynamicPassword" name="DynamicPassword" type="text" />
                            <label class="put_mb_s">sywl</label>
                        </div>
                    </li>
                    <li><span class="lb">验证码</span>
                        <div class="put code" style="padding: 0px;">
                            <input id="Captcha" name="Captcha" type="text" style="width: 70px" />
                            <label>
                            </label>
                        </div>
                        
                        <img style="border: none; cursor: pointer; height: 25px" src="/Images/Captcha/1.gif" onclick="this.src='/Images/Captcha/' + (Math.random()%30) + '.gif';"/>
                    </li>
                    <li>
                       <asp:Button ID="Button1" runat="server"  class="btn_login"   OnClick="submitbtn_Click" />
                       <!-- <input type="submit" value="" class="btn_login" onclick="return submitLoginForm();"> -->
                    </li>                  
                </ul>                
        </div>
        </asp:Panel>
         <asp:Panel ID="Panel2r" runat="server"> 
        <div class="login_mod">     
            <div class="tit"> &nbsp  </div> 
            <div class="tit"> &nbsp  </div> 
            <div class="tit">  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 登录成功！</div> 
            <div class="tit"> &nbsp</div> 
            <div class="tit"> &nbsp  </div> 
            <div class="tit">  &nbsp </div> 
           
           
        </div> 
     
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
        <div class="ebtn mb10 clearfix">
            <a href="" class="btn_reg"></a><a href="step1Page.aspx" class="btn_login2" target="_blank"></a>
        </div>
        </asp:Panel>
        
        <div class="fastway mb10 clearfix" style="height: 162px; width: 246px; overflow: hidden;">
            <a href="#" target="_blank" class="btn_newbie"></a>
            <a href="#" target="_blank" class="btn_help"></a>
            <a href="#" target="_blank" class="btn_safe"></a>
            <a href="#" target="_blank" class="btn_down"></a>
        </div>
        <div class="ad_pic">
            <a href="#" target="_blank">
                <img src="Images/e_Image1Path.jpg" ></a>
            <a style=" padding-top:8px;" href="#" target="_blank">
                <img src="Images/e_Image2Path.jpg"></a>
        </div>
    </div>

  

    <div class="col_main">
        <div class="focus mb10" id="sliderFade">
            <ul class="slider-pic">
               <li style="display: none"><a href="">
                    <img src="Images/e_DisplayImage1Path.jpg"/></a></li>
                <li style="display: list-item"><a href="">
                    <img src="Images/e_DisplayImage2Path.jpg" /></a></li>
                <li style="display: none"><a href="">
                    <img src="Images/e_DisplayImage3Path.jpg" /></a></li>
                <li style="display: none"><a href="">
                    <img src="Images/e_DisplayImage4Path.jpg" /></a></li>     
             </ul> 
           </div>        
        <div class="box mb10">
            <div class="hd">产品介绍</div>
            <div class="product_list">
                <a href="" target="_blank">
                    <img src="Images/e_Area1ImagePath.jpg" width="625" height="160"/></a>
            </div>
        </div>
        <div class="box mb10">
            <div class="hd">热门游戏</div>
            <a href="" target="_blank">
                <img src="Images/e_Area2ImagePath.jpg" width="625" style="height:255px; margin:5px 0px 0px 0px;"/></a>
        </div>
        <div class="aboutus">
            <p>守游网络推广平台是专业的手游服务商，我们坚持以优秀的团队、领先的技术、丰富的资源，鼎力为开发商提供最便捷的市场推广渠道，为合作代理创造最丰厚的利润。</p>
        </div>
    </div>
    <div class="col_right">
        <div class="contact mb10">
            <p class="telphone">4006099590</p>
            <div class="qq_list">
                    <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=982731399&amp;site=qq&amp;menu=yes">客服</a>
                    <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=511992919&amp;site=qq&amp;menu=yes">客服</a>
                    <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=982731399&amp;site=qq&amp;menu=yes">商务合作</a>
                    <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=982731399&amp;site=qq&amp;menu=yes">投诉建议</a>
            </div>
        </div>
        <div class="box mb10" style="height: 327px; overflow: hidden;">
            <div class="hd">系统公告</div>
            <ul class="news_list" style="height: 250px; overflow: hidden;">
                      <li>
                     <%
                         if (this.Article != null && this.Article.Rows.Count > 0)
                       {
                           for (int i = 0; i < this.Article.Rows.Count; i++)
                           {
                               DataRow dr = this.Article.Rows[i];%>     
                       <p>
                       <a target="_blank" href="bulletin/Detail.aspx?id=<%=dr["ID"].ToString()%>" >
                            <span class="special">[<%=dr["TypeName"].ToString()%>]</span>   <%=dr["Title"].ToString()%></a> 
                        </p>
                        <%}
                       }%>
                       </li>
            </ul>
            <div class="more">
                <a href="bulletin/Default.aspx" target="_blank">查看更多</a>
            </div>
        </div>
        <div class="box" style="height: 313px; overflow: hidden;">
            <div class="hd">开服列表</div>
            <ul class="faq_list" style="height: 210px; overflow: hidden; margin: 0px; padding: 10px 20px;">
            <li><a href="" target="_blank">待添加...</a></li>
            </ul>
            <div class="more">
                <a  target="_blank">查看更多</a>
            </div>
        </div>
    </div>
</div>

<!-- 测试 -->
    <!-- 内容区 -->
  
   <%-- <div id="notice" class="right-notice">
        <span class="close" title="关闭">×</span>
        <div class="rn-title">
            结算及特殊对接人通知
        </div>
        <div class="content">
            <a target="_blank" href="detail-id=28.htm" >
                结算及特殊对接人通知...... </a>
        </div>
    </div>--%>
<script src="javascript/lhgdialog/lhgcore.lhgdialog.min.js?skin=mac" type="text/javascript"></script>
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
    </div>
</asp:Content>
