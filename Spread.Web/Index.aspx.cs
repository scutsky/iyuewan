using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Spread.Web.UI;

namespace Spread.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected internal Spread.Model.WebSet webset;
        private Spread.BLL.WebSet bll = new Spread.BLL.WebSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string pathurl = Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString());
            webset = bll.loadConfig(pathurl);
            if (!IsPostBack)
            {
                info();
                getUserCookies();
            }
        }
        private void getUserCookies()
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
                Panel2.Visible = true;
                Panel3.Visible = true;
                Panel2r.Visible = false;
            }
            else
            {
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel2r.Visible = true;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void info()
        {
            Spread.BLL.Goods bllGoods = new Spread.BLL.Goods();
            Spread.BLL.Article bllArticle = new Spread.BLL.Article();

            DataTable dt = bllGoods.GetList(6, "IsHot=1 ", "ID ASC").Tables[0];
            Article = bllArticle.GetList(6, " ", "a.AddTime DESC").Tables[0];
            Goods = dt;
        }
       
        /// <summary>
        ///  最热游戏
        /// </summary>
        protected DataTable Goods
        {
            get;
            set;
        }
        /// <summary>
        ///  最热游戏
        /// </summary>
        protected DataTable Article
        {
            get;
            set;
        }
        private string uid = string.Empty;
        private string pwd = string.Empty;
        
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Spread.Model.User model = new Model.User();
                Spread.BLL.User bll = new BLL.User();
                if (bll.chkUserLogin(this.username.Value, this.password.Value))
                {
                    Session["user_name"] = this.username.Value;
                    HttpCookie hckUID = null;       //登录的用户ID
                    HttpCookie hckPWD = null;       //登录的密码(MD5后)

                    try
                    {
                        #region 写入Cook
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
                        hckUID = new HttpCookie("UserPage_UID", this.username.Value);
                        hckPWD = new HttpCookie("UserPage_PWD", this.password.Value);

                        //保存Cookie(用户名, 密码)
                        this.Response.Cookies.Add(hckUID);
                        this.Response.Cookies.Add(hckPWD);
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        string myScript = @"alertMsg('登陆错误!','error.gif');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                        return;
                    }
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    string myScript = @"alertMsg('用户名或密码错误!','error.gif');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
                    return;
                }
            }
            catch(Exception ex)
            {
                string myScript = @"alertMsg('登陆失败,'" + ex.ToString() + "','error.gif');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", myScript, true);
            }
        }
    }
}