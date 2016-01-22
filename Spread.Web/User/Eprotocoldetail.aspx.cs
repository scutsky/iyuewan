using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web.User
{
    public partial class Eprotocoldetail : System.Web.UI.Page
    {
        public Spread.Model.Protocol model = new Model.Protocol();
        Spread.BLL.Protocol bll = new BLL.Protocol();
        public Spread.Model.User modeluser = new Model.User();
        Spread.BLL.User blluser = new BLL.User();
        private string uid = "";
        private string pwd = "";
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
                    modeluser = blluser.GetModelByName(uid);
                    hdusername.Value = modeluser.TrueName;
                    model.Content = bll.GetModel(1).Content;
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
    }
}