<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Spread.Web.Admin.User.Detail" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>账号详细</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css">
    <script type="text/javascript" src="../../js/jquery-1.6.4.min.js"></script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation"><b>您当前的位置：首页 &gt; 账号中心 &gt; 账号详细</b></div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">注册信息</th>
      </tr>
      <tr>
        <td width="25%" align="right">登录账号：</td>
        <td width="75%">
         <%=this.userModel.Name %>
        </td>
      </tr>
       <tr>
        <td width="25%" align="right">登录密码：</td>
        <td width="75%">
         <%=strPwd%>
        </td>
      </tr>
      <tr>
        <td align="right">账号属性：</td>
        <td>
      
          <%=this.userModel.UserType == 1 ? "公司" : "个人"%>
        </td>
      </tr>
        <asp:Panel ID="Panel1" runat="server">
       
      <tr>
        <th colspan="2" align="left">联系信息</th>
      </tr>
      <tr>
        <td align="right">真实姓名：</td>
        <td>  <asp:TextBox ID="txtTrueName" runat="server"></asp:TextBox>
       <%-- <%=this.userModel.TrueName%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">支付宝帐户：</td>
        <td><asp:TextBox ID="txtPaypalAccount" runat="server"></asp:TextBox>
         <%--<%=this.userModel.PaypalAccount%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">身份证号：</td>
        <td><asp:TextBox ID="txtIdentityCard" runat="server"></asp:TextBox>
         <%--<%=this.userModel.IdentityCard%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">性别：</td>
        <td>
            <%=this.userModel.Sex == true ? "男" : "女"%>
        </td>
      </tr>
      <tr>
        <td align="right">QQ：</td>
        <td><asp:TextBox ID="txtQQ" runat="server"></asp:TextBox>
        <%-- <%=this.userModel.QQ%>--%>
        </td>
      </tr>
       <tr>
        <td align="right">邮箱地址：</td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
     <%--   <%=this.userModel.Email%>--%>
        </td>
      </tr>
       <tr>
        <td align="right">申请说明：</td>
        <td><asp:TextBox ID="txtApplicationdesc" runat="server"></asp:TextBox>
     <%--     <%=this.userModel.Applicationdesc%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">手机：</td>
        <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
         <%-- <%=this.userModel.Phone%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">电话：</td>
        <td><asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
          <%--<%=this.userModel.Tel%>--%>
        </td>
      </tr>
      <tr>
        <td align="right"></td>
        <td>
        <asp:Button ID="btnSave" runat="server" Text="保存"  CssClass="submit"   onclick="btnSave_Click" />
        </td>
      </tr>
      </asp:Panel>
      <asp:Panel ID="Panel2" runat="server">
      <tr>
        <th colspan="2" align="left">联系信息</th>
      </tr>
      <tr>
        <td align="right">公司名称：</td>
        <td> <asp:TextBox ID="txtqCompanyName" runat="server"></asp:TextBox>
        <%--<%=this.userModel.CompanyName%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">公司地址：</td>
        <td> <asp:TextBox ID="txtqCompanyAddress" runat="server"></asp:TextBox>
        <%-- <%=this.userModel.CompanyAddress%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">营业执照注册号：</td>
        <td> <asp:TextBox ID="txtqRegistrationMark" runat="server"></asp:TextBox>
           <%-- <%=this.userModel.RegistrationMark%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">公司法人姓名：</td>
        <td><asp:TextBox ID="txtqTrueName" runat="server"></asp:TextBox>
         <%--<%=this.userModel.TrueName%>--%>
        </td>
      </tr>
       <tr>
        <td align="right">法人身份证号：</td>
        <td>
        <asp:TextBox ID="txtgIdentityCard" runat="server"></asp:TextBox>
     <%--   <%=this.userModel.IdentityCard%>--%>
        </td>
      </tr>
       <tr>
        <td align="right">联系人：</td>
        <td><asp:TextBox ID="txtqCorporateName" runat="server"></asp:TextBox>
      <%--  <%=this.userModel.CorporateName%>--%>
        </td>
      </tr>
       <tr>
        <td align="right">联系人QQ：</td>
        <td><asp:TextBox ID="txtqQQ" runat="server"></asp:TextBox>
       <%-- <%=this.userModel.QQ%>--%>
        </td>
      </tr>       
        <tr>
        <td align="right">邮箱地址：</td>
        <td><asp:TextBox ID="txtqEmail" runat="server"></asp:TextBox>
        <%--<%=this.userModel.Email%>--%>
        </td>
      </tr>
       <tr>
        <td align="right">申请说明：</td>
        <td><asp:TextBox ID="txtqApplicationdesc" runat="server"></asp:TextBox>
         <%-- <%=this.userModel.Applicationdesc%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">手机：</td>
        <td><asp:TextBox ID="txtqPhone" runat="server"></asp:TextBox>
         <%-- <%=this.userModel.Phone%>--%>
        </td>
      </tr>
      <tr>
        <td align="right">电话：</td>
        <td><asp:TextBox ID="txtqTel" runat="server"></asp:TextBox>
         <%-- <%=this.userModel.Tel%>--%>
        </td>
      </tr>
      <tr>
        <td align="right"></td>
        <td>
        <asp:Button ID="btnSave2" runat="server" Text="保存"  CssClass="submit"  onclick="btnSave2_Click" />
        </td>
      </tr>
    </asp:Panel>
    </table>
    </form>
    
</body>
</html>
