using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spread.Web
{
    public partial class LoginOut1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login("", "");
            Response.Redirect("Index.aspx");
        }

        /// <summary>
        /// 执行登录
        /// </summary>
        /// <param name="uid">登录时的ID</param>
        /// <param name="pwd">登录时的密码(MD5加密后)</param>
        protected void Login(string uid, string pwd)
        {
            HttpCookie hckUID = null;       //登录的用户ID
            HttpCookie hckPWD = null;       //登录的密码(MD5后)

            try
            {
                //判断原用户ID是否存在
                if (Request.Cookies["UserPage_UID"] != null)
                {
                    //存在时清理原有的值
                    Response.Cookies.Remove("UserPage_UID");
                }

                //判断原用户ID是否存在
                if (Request.Cookies["UserPage_PWD"] != null)
                {
                    //存在时清理原有的值
                    Response.Cookies.Remove("UserPage_PWD");
                }

                //生成Cookie(用户名, 密码)
                hckUID = new HttpCookie("UserPage_UID", uid);
                hckPWD = new HttpCookie("UserPage_PWD", pwd);

                //保存Cookie(用户名, 密码)
                this.Response.Cookies.Add(hckUID);
                this.Response.Cookies.Add(hckPWD);
            }
            catch (Exception ex)
            {

            }
        }
    }
}