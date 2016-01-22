using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Spread.Web.bulletin
{
    public partial class Default : System.Web.UI.Page
    {
        protected internal Spread.Model.WebSet webset;
        private Spread.BLL.WebSet bll = new Spread.BLL.WebSet();
        protected string strMenu;
        protected string type;
        protected int Count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["type"] != null)
                {
                    type = Request.Params["type"].ToString();
                }
                else
                {
                    type = "1";
                }
                string pathurl = Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString());
                webset = bll.loadConfig(pathurl);
                info();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void info()
        {
            Spread.BLL.Article_type bllArticletype = new Spread.BLL.Article_type();
            Spread.BLL.Article bllArticle = new Spread.BLL.Article();
            Count = bllArticle.GetCount("ClassId=" + type + "");
            Article = bllArticle.GetList("ClassId=" + type + "").Tables[0];
            DataTable dt = bllArticletype.GetList(6, " ", "Id ASC").Tables[0];
            strMenu += "<ul class=\"cf\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Id"].ToString() == type)
                {
                    strMenu += "<li class=\"cur\"><a href=\"Default.aspx?page=1&type=" + dt.Rows[i]["ID"] + "\" >" + dt.Rows[i]["Title"] + "</a></li>";
                }
                else
                {
                    strMenu += "<li ><a href=\"Default.aspx?page=1&type=" + dt.Rows[i]["ID"] + "\" >" + dt.Rows[i]["Title"] + "</a></li>";
                }
            }
            strMenu += "</ul>";
        }

        /// <summary>
        ///  最热游戏
        /// </summary>
        protected DataTable Article
        {
            get;
            set;
        }
    }
}