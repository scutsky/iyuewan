using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Spread.Web.Admin
{
    public partial class login : System.Web.UI.Page
    {
        Spread.BLL.Admin bll = new Spread.BLL.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginsubmit_Click(object sender, ImageClickEventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string UserPwd = txtUserPwd.Text.Trim();
            //string Code=txtCode.Text.Trim();
            string validateCode = string.Empty;
            if (Session["ValidateCode"] == null)
            {
                lbMsg.Text = "你在登陆页面停留的时间过长，验证码已失效！";
            }
            else
            {
                validateCode = Session["ValidateCode"].ToString();
            }
            if (UserName.Equals("") || UserPwd.Equals(""))
            {
                lbMsg.Text = "请输入您要登录用户名或密码";
            }
            else
            {
                #region 记录登录次数
                if (Session["AdminLoginSun"] == null)
                {
                    Session["AdminLoginSun"] = 1;
                }
                else
                {
                    Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
                }
                #endregion

                //判断登录  
                #region 判断登录
                //if (Code.Equals(""))
                //{
                //    lbMsg.Text = "验证码不能为空！";
                //}
                //else
                //{
                    //if (validateCode == Code.ToLower())
                    //{
                        if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 3)
                        {
                            lbMsg.Text = "登录错误超过3次，请关闭浏览器重新登录。";
                            Session["AdminLoginSun"] = 1;
                        }
                        else if (bll.chkAdminLogin(UserName, UserPwd))
                        {
                            Spread.Model.Admin model = new Spread.Model.Admin();
                            model = bll.GetModel(UserName);
                            Session["AdminNo"] = model.Id;
                            Session["AdminName"] = model.UserName;
                            Session["AdminType"] = model.UserType;
                            Session["AdminLevel"] = model.UserLevel;
                            //设置超时时间
                            Session.Timeout = 120;
                            Session["AdminLoginSun"] = null;

                            bll.SetLoginState(model);
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lbMsg.Text = "您输入的用户名或密码不正确";
                        }
                    //}
                    //else
                    //{
                    //    lbMsg.Text = "您输入的验证码不正确";
                    //}
                //}
                #endregion
            }
        }
    }
}
