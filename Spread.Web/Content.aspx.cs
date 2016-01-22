using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Spread.Web
{
    public partial class Content : System.Web.UI.Page
    {
        public int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                Id = int.Parse(Request.Params["id"].ToString());
                Info();
            }
            else
            {
                Response.Redirect("error.html");
            }
        }
        private void Info()
        {
            Spread.BLL.Article bllArticle = new Spread.BLL.Article();
            if (Id > 0)
            {
                DataTable dt = bllArticle.GetList(1, "Id=" + Id + "", "ID ASC").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lbtitle.Text = dt.Rows[0]["Title"].ToString();
                    lbMenu.Text = " > <a class=\"col-01\" href=\"/Content.aspx?id=" + dt.Rows[0]["ID"].ToString() + "\">" + dt.Rows[0]["Title"].ToString() + "</a>";
                    this.Article = dt;
                }

            }
        }
        /// <summary>
        ///  企业
        /// </summary>
        protected DataTable Article
        {
            get;
            set;
        }
        public string MenuInfo()
        {
            StringBuilder html = new StringBuilder();
            Spread.BLL.Article bllArticle = new Spread.BLL.Article();
            DataTable dt = bllArticle.GetList(10, "ClassId=31", "ID Desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                html.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html.Append("<li> <a href=\"/Content.aspx?id=" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Title"].ToString() + "</a>");
                   
                    html.Append("</li>");
                }
            }
            return html.ToString();

        }
        
    }
}