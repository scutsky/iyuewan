using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Spread.Web
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["q1"] != null && Session["q1"] != "模糊查询")
                {
                    this.Conditions1.Value = Session["q1"].ToString();
                }
                if (Session["q2"] != null && Session["q2"] != "类型")
                {
                    this.Conditions2.Value = Session["q2"].ToString();
                }
                if (Session["q3"] != null && Session["q3"] != "车厂")
                {
                    this.Conditions3.Value = Session["q3"].ToString();
                }
                if (Session["q4"] != null && Session["q4"] != "品牌")
                {
                    this.Conditions4.Value = Session["q4"].ToString(); ;
                }
                Info();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Info();
        }

        public string strType = "";
        public string strDesc = "";
        private void Info()
        {
            StringBuilder sql = new StringBuilder();
            Spread.BLL.Goods bllGoods = new Spread.BLL.Goods();
            sql.Append(" ClassId<>7905 ");
            if (!string.IsNullOrEmpty(this.Conditions1.Value) && this.Conditions1.Value != "模糊查询")
            {
                sql.Append(" and (Title like '%" + this.Conditions1.Value + "%' or Zhaiyao like '%" + this.Conditions1.Value + "%' or GType like '%" + this.Conditions1.Value + "%' or GFactory like '%" + this.Conditions1.Value + "%' or GBrand like '%" + this.Conditions1.Value + "%') ");
            }
            if (!string.IsNullOrEmpty(this.Conditions2.Value) && this.Conditions2.Value != "类型")
            {
                sql.Append(" and GType like '%" + this.Conditions2.Value + "%'");
            }
            if (!string.IsNullOrEmpty(this.Conditions3.Value) && this.Conditions3.Value != "车厂")
            {
                sql.Append(" and GFactory like '%" + this.Conditions3.Value + "%'");
            }
            if (!string.IsNullOrEmpty(this.Conditions4.Value) && this.Conditions4.Value != "品牌")
            {
                sql.Append(" and GBrand like '%" + this.Conditions4.Value + "%'");
            }
            DataTable dt = bllGoods.GetList(sql.ToString()).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strType += "<div class=\"bd\"><b>" + dt.Rows[i]["GType"] + "</b></div>";
                strDesc += "<div class=\"bd\">" + dt.Rows[i]["Form"] + "</div>";
            }
        }
    }
}