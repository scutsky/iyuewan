<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Spread.Web.Admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=webset.WebName.ToString()%> - 后台控制面板 - Spread Web Studio</title>
    <link href="../Content/Css/JqueryUI/jquery-ui-1.7.2.custom.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="images/style.css">
    <script type="text/javascript" src="../Content/Javascript/jquery-1.6.4.min.js"></script>
   <script type="text/javascript" src="../Content/Javascript/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript" src="js/manager.js"></script>
    <script type="text/javascript" src="js/png.js"></script>
</head>
<body>
<form id="form1" runat="server">

<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" style="background:#EBF5FC;">
<tbody>
  <tr>
    <td height="70" colspan="3" style="background:url(images/head_bg.gif);"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="24%" height="70"><img src="images/head_logo.png" ></td>
        <td width="76%" valign="bottom">
	  <!--导航菜单,与下面的相关联,修改时注意参数-->
          <div id="tabs">
          <ul>
            <li onclick="tabs(1);"><a href="Goods/List.aspx" target="sysMain"><span>游戏管理</span></a></li>	
            <li onclick="tabs(2);"><a href="Article/List.aspx" target="sysMain"><span>公告管理</span></a></li>
            <li onclick="tabs(3);"><a href="Products/List.aspx" target="sysMain"><span>产品管理</span></a></li>
            <li onclick="tabs(4);"><a href="User/List.aspx" target="sysMain"><span>账户管理</span></a></li>
            <li onclick="tabs(5);"><a href="Channel/List.aspx" target="sysMain"><span>渠道管理</span></a></li>       				
            <li onclick="tabs(6);"><a href="statistics/UserList.aspx" target="sysMain"><span>游戏统计</span></a></li>        
			<li onclick="tabs(7);"><a href="Admin_center.aspx" target="sysMain"><span>系统管理</span></a></li>
          </ul>
          </div>

        </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="30" colspan="3" style="padding:0px 10px;font-size:12px;background:url(images/navsub_bg.gif) repeat-x;">
    <div style="float:right;line-height:20px;"><a href="admin_center.aspx" target="sysMain">管理中心</a> | 
        <a target="_blank" href="../index.aspx">预览网站</a> | 
        <asp:LinkButton 
            ID="lbtnExit" runat="server" onclick="lbtnExit_Click">安全退出</asp:LinkButton>
        </div>
    <div style="padding-left:20px;line-height:20px;background:url(images/siteico.gif) 0px 0px no-repeat;">当前登录用户：<font color="#FF0000"><asp:Label
        ID="lblAdminName" runat="server" Text="Label"></asp:Label></font>您好，欢迎光临。</div>
    </td>
  </tr>

  <tr>
    <td align="middle" id="mainLeft" valign="top" style="background:#FFF;">
	  <div style="text-align:left;width:185px;height:100%;font-size:12px;">
        <!--导航顶部-->
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">
          <span style="padding-left:15px;font-weight:bold;color:#039;background:url(images/menu_dot.gif) no-repeat;">功能导航</span>
        </div>
        <!--导航菜单,修改时注意顺序-->
        <div class="left_menu">
          <ul>
			<li onclick="tabs(1);"><a href="Goods/List.aspx" target="sysMain"><span>游戏管理</span></a></li>
            <li onclick="tabs(2);"><a href="Article/List.aspx" target="sysMain"><span>公告管理</span></a></li>
            <li onclick="tabs(3);"><a href="Products/List.aspx" target="sysMain"><span>产品管理</span></a></li>
            <li onclick="tabs(4);"><a href="User/List.aspx" target="sysMain"><span>账户管理</span></a></li> 
            <li onclick="tabs(5);"><a href="Channel/List.aspx" target="sysMain"><span>渠道管理</span></a></li> 
            <li onclick="tabs(6);"><a href="statistics/UserList.aspx" target="sysMain"><span>游戏统计</span></a></li>
			<li onclick="tabs(7);"><a href="Admin_center.aspx" target="sysMain"><span>系统管理</span></a></li>
          </ul>
        </div>
        
        
       
        
        <!--游戏管理-->
        <div class="left_menu">
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">游戏管理</div>
          <ul>
            <li><a href="Goods/List.aspx" target="sysMain">热门游戏</a></li>
            <li><a href="Goods/GameList.aspx" target="sysMain">游戏管理</a></li>
            <li><a href="Menu/List.aspx" target="sysMain">平台管理</a></li>
            <li><a target="sysMain" href="Channel/Plist.aspx">平台渠道管理</a></li>
            <li><a target="sysMain" href="Goods/Pgamelist.aspx">平台游戏管理</a></li>  
          </ul>
         
        </div>

        <!--公告管理-->
        <div class="left_menu">
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">公告管理</div>
          <ul>
            <li><a target="sysMain" href="Article/List_type.aspx">公告分类管理</a></li>
            <li><a target="sysMain" href="Article/List.aspx">公告管理</a></li>
            
          </ul>
         
        </div>

         <!--产品管理-->
        <div class="left_menu">
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">产品管理</div>
          <ul> 
            <li><a target="sysMain" href="Products/List.aspx">产品管理</a></li>  
          </ul>
          
        </div>
         <!--资料下载-->
        <div class="left_menu">
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">账户管理</div>
          <ul> 
            <li><a target="sysMain" href="User/List.aspx">账户管理</a></li>  
          </ul>
          
        </div>

         <!--经销商-->
        <div class="left_menu">
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">渠道管理</div>
          <ul> 
            <li><a target="sysMain" href="Channel/List.aspx">渠道管理</a></li>  
          </ul>
          
        </div>

         <!--关于我们-->
        <div class="left_menu">
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">游戏统计</div>
          <ul>
            <li><a target="sysMain" href="Accounts/List.aspx">结算管理</a></li>
            <li><a target="sysMain" href="statistics/UserList.aspx">游戏统计</a></li>
            <li><a target="sysMain" href="statistics/ReportSetList.aspx">上传设置</a></li>
            <li><a target="sysMain" href="statistics/ReportUpload.aspx">上传数据</a></li>
            <li><a target="sysMain" href="statistics/ReportTempMain.aspx">上传数据日志</a></li>
          </ul>
         
        </div>

        <!--系统管理-->
        <div class="left_menu">
         <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">系统管理</div>
          <ul>
            <li><a target="sysMain" href="Config/Admin_config.aspx">系统参数设置</a></li>
            <li><a target="sysMain" href="Protocol/List.aspx">电子协议管理</a></li>
            <li><a target="sysMain" href="Manage/LogList.aspx">系统日志管理</a></li>
            <li><a target="sysMain" href="backup/SqlSet.aspx">查询分析器</a></li> 
            <li><a target="sysMain" href="Manage/List.aspx">管理员管理</a></li>
          </ul>
          
        </div>

      </div>
	</td>
	<td valign="middle" style="width:8px;background:url(images/main_cen_bg.gif) repeat-x;">
      <div id="sysBar" style="cursor:pointer;"><img id="barImg" src="images/butClose.gif" alt="关闭/打开左栏" /></div>
	</td>
	<td style="width:100%" valign="top">
      <iframe frameborder="0" id="sysMain" name="sysMain" scrolling="yes" src="admin_center.aspx" style="height:100%;visibility:inherit; width:100%;z-index:1;"></iframe>
	</td>
  </tr>
  <tr>
    <td height="28" colspan="3" bgcolor="#EBF5FC" style="padding:0px 10px;font-size:10px;color:#2C89AD;background:url(images/foot_bg.gif) repeat-x;"><%=webset.WebCopyright.ToString()%></td>
  </tr>
  </tbody>
</table>

</form>
</body>
</html>

