using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Spread.Web.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private string uid = "";
        private string pwd = "";
        public Spread.Model.User model = new Model.User();
        Spread.BLL.User bll = new BLL.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!getUserCookies())
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    model = bll.GetModelByName(uid);
                    telphone.Value = model.Phone;
                }
            }
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = this.telphone.Value;
                Regex r = new Regex(@"(13[0-9]|18[0-9]|15[0-9]|147)\d{8}");
                if (!r.IsMatch(phone))
                {
                    string myScript = @"alertMsg('手机号码有误!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                //string verifycookie = Request.Cookies["MSMVerifyCode"] == null ? "" : Request.Cookies["MSMVerifyCode"].Value.Trim();
                //if (verifycode.Value.Replace(" ", "") != verifycookie.Replace(" ", ""))
                //{
                //    string myScript = @"alertMsg('验证码错误!','error.gif');";
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                //    return;
                //}
                //else
                //{
                //    Response.Redirect("step2Page.aspx");
                //}
                if (!bll.chkUserLogin(Request.Cookies["UserPage_UID"].Value.ToString(), this.sourcePass.Value))
                {
                    string myScript = @"alertMsg('原密码不正确!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                if (password.Value.Replace(" ", "") != confirmPass.Value.Replace(" ", ""))
                {
                    string myScript = @"alertMsg('密码不相同!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                if (bll.UpdatePassword(Request.Cookies["UserPage_UID"].Value.ToString(), this.password.Value))
                {
                    string myScript = @"alertRedirectMsg('密码修改成功!','success.gif','../Index.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                }
                else
                {
                    string myScript = @"alertMsg('密码修改错误!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
            }
            catch
            {
                string myScript = @"alertMsg('验证失败!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
        }

        private bool getUserCookies()
        {

            if (Request.Cookies["UserPage_UID"] != null)
            {
                uid = Request.Cookies["UserPage_UID"].Value.ToString();
            }
            //获取登录时的PWD(MD5加密后)
            if (Request.Cookies["UserPage_PWD"] != null)
            {
                pwd = Request.Cookies["UserPage_PWD"].Value.ToString();
            }
            //当用户名UID或者密码PWD有一项为空时
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}