using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Spread.Web.UI;
using System.Data;

namespace Spread.Web
{
    public partial class Site1 : MasterPage
    {
        private Spread.BLL.WebSet bll = new Spread.BLL.WebSet();
        private Spread.BLL.contant bllContant = new Spread.BLL.contant();
        public string strHits;
        protected internal Spread.Model.WebSet webset;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            Spread.Model.contant modelContant = new Spread.Model.contant();
            //bll.Get_Config(rwc);
            string pathurl = Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString());
            webset = bll.loadConfig(pathurl);
            getUserCookies();
        }
        private string uid = string.Empty;
        private string pwd = string.Empty;
        public string UserInfo = string.Empty;
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
                Panel1.Visible = false;
            }
            else
            {
                UserInfo += " <span class=\"sep\" style=\" color:#4b4b4b;\"></span>";
                UserInfo += " <span style=\" color:#4b4b4b;\">欢迎您，<a href=\"/User/Channelinfo.aspx\" style=\" color:#4b4b4b;\">" + uid + "</a></span>";
                UserInfo += " <a href=\"../LoginOut.aspx\" class=\"loginOut\" style=\" color:#4b4b4b;\">[退出]</a>";
                Panel1.Visible = true;
               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WebName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string WebKeywords
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebCopyright
        {
            get;
            set;
        }
    }


}