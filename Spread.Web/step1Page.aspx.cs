using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web
{
    public partial class step1Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Spread.Model.User model = new Model.User();
                Spread.BLL.User bll = new BLL.User();
                if (bll.chkExists(this.username.Value))
                {
                    string verifycookie = Request.Cookies["VerifyCode"] == null ? "" : Request.Cookies["VerifyCode"].Value.Trim();
                    if (verifycode.Value.Replace(" ", "") != verifycookie.Replace(" ", ""))
                    {
                        string myScript = @"alertMsg('验证码错误!','error.gif');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                        return;
                    }
                    else
                    {
                        Session["changeName"] = this.username.Value;
                        Response.Redirect("step2Page.aspx");
                    }
                }
                else
                {
                    string myScript = @"alertMsg('用户名错误!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string myScript = @"alertMsg('登陆失败,'" + ex.ToString() + "','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
        }
    }
}