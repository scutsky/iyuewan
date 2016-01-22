using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Spread.Web
{
    public partial class step2Page : System.Web.UI.Page
    {
        private string changeName = "";
        Spread.Model.User model = new Model.User();
        Spread.BLL.User bll = new BLL.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["changeName"] != null)
                {
                    model=bll.GetModelByName(Session["changeName"].ToString());
                    hdPhone.Value = model.Phone;
                }
                else
                {
                    string myScript = @"alertRedirectMsg('信息有误!','error.gif','step1Page.aspx');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
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
                string verifycookie = Request.Cookies["MSMVerifyCode"] == null ? "" : Request.Cookies["MSMVerifyCode"].Value.Trim();
                if (verifycode.Value.Replace(" ", "") != verifycookie.Replace(" ", ""))
                {
                    string myScript = @"alertMsg('验证码错误!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
                else
                {
                    Response.Redirect("step2Page.aspx");
                }
                Response.Redirect("step3Page.aspx");
            }
            catch
            {
                string myScript = @"alertMsg('验证失败!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
        }
    }
}