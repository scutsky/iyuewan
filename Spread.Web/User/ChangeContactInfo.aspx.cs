using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.User
{
    public partial class ChangeContactInfo : System.Web.UI.Page
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

        protected void mainbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.qqnumber.Value))
            {
                string myScript = @"alertMsg('QQ不能为空!','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
            if (bll.UpdateQQ(Request.Cookies["UserPage_UID"].Value.ToString(), this.qqnumber.Value))
            { 
                string myScript = @"alertRedirectMsg('QQ修改成功!','success.gif','ChangeContactInfo.aspx');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                return;
            }
        }
    }
}