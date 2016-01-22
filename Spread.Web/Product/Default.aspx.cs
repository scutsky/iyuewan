using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Spread.Web.Product
{
    
    public partial class Default : System.Web.UI.Page
    {
        public int Pid = 0;
        public int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["pid"] != null)
            {
                Pid = int.Parse(Request.Params["pid"].ToString());
            }
            if (Request.Params["id"] != null)
            {
                Id = int.Parse(Request.Params["id"].ToString());
            }
            Info();
        }


        private void Info()
        {          
            Spread.BLL.Goods bllGoods = new Spread.BLL.Goods();
            Spread.BLL.Menu bllMenu = new Spread.BLL.Menu();
            if(Pid>0){               
                DataTable dt = bllGoods.GetList(1, "ClassId=" + Pid + "", "ID ASC").Tables[0];
                if(dt.Rows.Count>0){
                    
                    lbMenu.Text = " > <a class=\"col-01\" href=\"/Product/Default.aspx?id=" + dt.Rows[0]["ID"].ToString() + "\">" + dt.Rows[0]["Title"].ToString() + "</a>";
                    this.Goods = dt;
                }
            }
            if (Id > 0)
            {
                DataTable dt = bllGoods.GetList(1, "Id=" + Id + "", "ID ASC").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lbMenu.Text = " > <a class=\"col-01\" href=\"/Product/Default.aspx?id=" + dt.Rows[0]["ID"].ToString() + "\">" + dt.Rows[0]["Title"].ToString() + "</a>";
                    this.Goods = dt;
                }
               
            }
        }

        /// <summary>
        ///  产品
        /// </summary>
        protected DataTable Goods
        {
            get;
            set;
        }

        public string MenuInfo()
        {
            StringBuilder html = new StringBuilder();
            Spread.BLL.Menu bllMenu = new Spread.BLL.Menu();
            DataTable dt = bllMenu.GetList(10, "IsMenu=true", "ID Desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                html.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html.Append("<li> <a href=\"/Product/Default.aspx?pid=" + dt.Rows[i]["ID"].ToString() + "\">" + dt.Rows[i]["Title"].ToString() + "</a>");
                    html.Append(ProductInfo(dt.Rows[i]["ID"].ToString()));
                    html.Append("</li>");
                }
                html.Append("</ul>");
            }
            return html.ToString();

        }
        public string ProductInfo(string menuId)
        {
            StringBuilder html = new StringBuilder();
            Spread.BLL.Goods bllGoods = new Spread.BLL.Goods();
            DataTable dt = bllGoods.GetList(10, "ClassId=" + menuId + "", "ID ASC").Tables[0];
            if (dt.Rows.Count > 0)
            {
                html.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html.Append("<li> <a href=\"/Product/Default.aspx?id=" + dt.Rows[i]["ID"] + "\">" + dt.Rows[i]["Title"] + "</a></li>");
                }
                html.Append("</ul>");
            }
            return html.ToString();
        }
    }

   

}
