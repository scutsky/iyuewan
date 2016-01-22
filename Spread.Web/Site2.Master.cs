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
    public partial class Site2 : System.Web.UI.MasterPage
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