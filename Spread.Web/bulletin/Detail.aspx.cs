using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spread.Common;
namespace Spread.Web.bulletin
{
    public partial class Detail : System.Web.UI.Page
    {
        Spread.BLL.Article bllArticle = new Spread.BLL.Article();
        Spread.BLL.Article_type bllArticletype = new Spread.BLL.Article_type();
        protected internal Spread.Model.Article modArticle;
        Spread.Model.Article_type modArticletype;
        protected int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                Response.Redirect("~/error.html");
                return;
            }
            if (!IsPostBack)
            {
                modArticle = bllArticle.GetModel(Id);
                if (modArticle.ClassId>0)
                {
                    modArticletype=bllArticletype.GetModel(modArticle.ClassId);
                    this.lbmenu.Text = modArticletype.Title;
                }
            }
        }
    }
}