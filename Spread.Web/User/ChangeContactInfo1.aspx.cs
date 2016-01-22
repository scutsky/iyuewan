using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Spread.Web.User
{
    public partial class ChangeContactInfo1 : System.Web.UI.Page
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
                    lbPhone.Text = model.Phone;
                    telphone.Value = model.Phone;
                    qqnumber.Value = model.QQ;
                }
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

        

        protected void phonesubmitbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.smsCode.Value))
            {
                string myScript = @"alertMsg('原手机验证码不能为空!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            if (string.IsNullOrEmpty(this.newphone.Value))
            {
                string myScript = @"alertMsg('新手机不能为空!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            string phone = this.newphone.Value;
            Regex r = new Regex(@"(13[0-9]|18[0-9]|15[0-9]|147)\d{8}");
            if (!r.IsMatch(phone))
            {
                string myScript = @"alertMsg('手机号码有误!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            if (string.IsNullOrEmpty(this.smsCode2.Value))
            {
                string myScript = @"alertMsg('新手机验证码不能为空!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            //if (smsCode.Value != hcode.Value)
            //{
            //    string myScript = @"alertMsg('原手机验证码不正确!','error.gif');";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //    return;
            //}
            //if (smsCode2.Value != hcode2.Value)
            //{
            //    string myScript = @"alertMsg('新手机验证码不正确!','error.gif');";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            //    return;
            //}
            if (bll.UpdatePhone(Request.Cookies["UserPage_UID"].Value.ToString(), phone))
            {
                string myScript = @"alertRedirectMsg('手机修改成功!','success.gif','ChangeContactInfo.aspx');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
        }

        protected void mainbtn_Click(object sender, EventArgs e)
        {

        }
    }
}